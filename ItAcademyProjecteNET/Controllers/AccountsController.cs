using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;
using ItAcademyProjecteNET.Lib.Models.Enums;
using ItAcademyProjecteNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ItAcademyProjecteNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ItAcademyDbContext _userManager;

        public AccountsController(ItAcademyDbContext context)
        {
            _userManager = context;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/Accounts/Register
        public async Task<Object> PostAccount([FromForm] Person person)
        {
            var applicationUser = new Person()
            {
                Name = person.Name,
                LastName = person.LastName,               
                Email = person.Email,
                Picture = person.Picture,
                BirthDate = person.BirthDate,
                PersonGender = person.PersonGender,
                PersonRole = person.PersonRole
            };

            try
            {
                _userManager.Persons.Add(person);
                await _userManager.SaveChangesAsync();

                return CreatedAtAction("GetPerson", new { id = person.Id }, person);
                //or
                //return Ok(CreatedAtAction("GetPerson", new { id = person.Id }, person));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //Get : /api/Accounts/Login
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            var user = _userManager.FindPersonByEmail(model.Email);
            if (user != null && _userManager.CheckPassword(user, model.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.PersonRoleString)
                };

                //claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                //claims.Add(new Claim(ClaimTypes.Role, "User"));

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                var now = DateTime.UtcNow;
                // Creamos JWT-token
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        //audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: claimsIdentity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}