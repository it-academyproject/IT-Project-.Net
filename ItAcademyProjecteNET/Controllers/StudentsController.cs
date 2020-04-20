using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;
using Common.Lib.Core;
using ItAcademyProjecteNET.Lib.Interfaces;
using Common.Lib.Infrastructure;

namespace ItAcademyProjecteNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IStudentRepository>();
            return await repo.QueryAll().ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await Task.Run(() =>
            {
                var repo = Entity.DepCon.Resolve<IStudentRepository>();
                var student = repo.QueryAll().FirstOrDefault(x => x.Id == id);
                
                if (student == null)
                {
                    return null;
                }
                return student;
            });
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<Student>>> PutStudent(Student student)
        {
            return await Task.Run(() =>
            {
                var or = student.Save();
                return or;
            });
        }

        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OperationResult<Student>>> PostStudent(Student student)
        {
            return await Task.Run(() =>
            {
                var sr = student.Save();
                return sr;
            });
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<Student>>> DeleteStudent(int id)
        {
            return await Task.Run(() =>
            {
                var repo = Entity.DepCon.Resolve<IStudentRepository>();
                var stuDelete = repo.QueryAll().FirstOrDefault(x => x.Id == id);
                var sr = stuDelete.Delete();
                return sr;
            });
        }

        private bool StudentExists(int id)
        {
            var repo = Entity.DepCon.Resolve<IStudentRepository>();
            return repo.QueryAll().Any(x => x.Id == id);
        }
    }
}
