using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;

namespace ItAcademyProjecteNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingMaterialsController : ControllerBase
    {
        private readonly ItAcademyDbContext _context;

        public TeachingMaterialsController(ItAcademyDbContext context)
        {
            _context = context;
        }

        // GET: api/TeachingMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachingMaterial>>> GetTeachingMaterials()
        {
            return await _context.TeachingMaterials.ToListAsync();
        }

        // GET: api/TeachingMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeachingMaterial>> GetTeachingMaterial(int id)
        {
            var teachingMaterial = await _context.TeachingMaterials.FindAsync(id);

            if (teachingMaterial == null)
            {
                return NotFound();
            }

            return teachingMaterial;
        }

        // PUT: api/TeachingMaterials/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachingMaterial(int id, TeachingMaterial teachingMaterial)
        {
            if (id != teachingMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(teachingMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachingMaterialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeachingMaterials
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TeachingMaterial>> PostTeachingMaterial(TeachingMaterial teachingMaterial)
        {
            _context.TeachingMaterials.Add(teachingMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeachingMaterial", new { id = teachingMaterial.Id }, teachingMaterial);
        }

        // DELETE: api/TeachingMaterials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeachingMaterial>> DeleteTeachingMaterial(int id)
        {
            var teachingMaterial = await _context.TeachingMaterials.FindAsync(id);
            if (teachingMaterial == null)
            {
                return NotFound();
            }

            _context.TeachingMaterials.Remove(teachingMaterial);
            await _context.SaveChangesAsync();

            return teachingMaterial;
        }

        private bool TeachingMaterialExists(int id)
        {
            return _context.TeachingMaterials.Any(e => e.Id == id);
        }
    }
}
