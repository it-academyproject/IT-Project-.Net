using ItAcademyProjecteNET.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItAcademyProjecteNET.Lib.DAL.Context
{
    public class ItAcademyDbContext : DbContext

    {
        public ItAcademyDbContext(DbContextOptions<ItAcademyDbContext> options): base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<TeachingMaterial> TeachingMaterial { get; set; }
        public DbSet<StudentExercise> StudentExercise { get; set; }
    }
    
}
