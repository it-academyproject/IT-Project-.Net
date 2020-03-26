using System;
using System.Collections.Generic;
using System.Text;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;

namespace ItAcademyProjecteNET.Lib.DAL.Repository
{
    public class PersonRepository 
    {
        private readonly ItAcademyDbContext _dbContext;
        //public PersonRepository()
        //{
        //    _dbContext = new ItAcademyDbContext();
        //}

        public PersonRepository(ItAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Person person)
        {
            _dbContext.Set<Person>().Add(person);
            _dbContext.SaveChanges();
        }

        public void Delete(Person person)
        {
            if (person != null)
            {
                _dbContext.Set<Person>().Remove(person);
                _dbContext.SaveChanges();                
            }
        }

    }

}
