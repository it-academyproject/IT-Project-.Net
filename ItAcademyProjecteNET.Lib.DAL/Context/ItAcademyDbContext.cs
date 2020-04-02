using ItAcademyProjecteNET.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasAlternateKey(p => p.Email);                
        }
        public Person FindPersonByEmail(string email)
        {
            return Persons.AsQueryable().Where(x => x.Email == email).FirstOrDefault();
        }
        public Boolean CheckPassword(Person user, string password)
        {
            var result = Persons.AsQueryable().Where(x => x.Email == user.Email && x.Password == password).FirstOrDefault();
            if (result != null)
                return true;
            else return false;
        }
    }
    
}
