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
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TeachingMaterial> TeachingMaterials { get; set; }
        //public DbSet<StudentExercise> StudentExercises { get; set; }
    }
    
}
