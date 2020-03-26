using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoItAcademyProjecteNET.LibdeFirst.Models.Enums;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.DAL.Repository;
using ItAcademyProjecteNET.Lib.Models;
using ItAcademyProjecteNET.Lib.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ItAcademyProjecteNET
{
    public class FillDictionary
    {
        public FillDictionary()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ItAcademyDbContext>();
            
            optionsBuilder.UseSqlServer(dbConnection, x => x.MigrationsAssembly("ItAcademyProjecteNET"));

            var dbContext = new ItAcademyDbContext(optionsBuilder.Options);

            var repo = new PersonRepository(dbContext);

            var person = new Person();

            person.Name = "Lola";
            person.LastName = "Lola";
            person.Email = "123@lola.com";
            person.PersonRole = PersonRoles.Admin;
            person.PersonGender = PersonGenders.Female;
            person.Picture = "picture";
            person.Password = "12345";          

            repo.Add(person);
        }
    }
}
