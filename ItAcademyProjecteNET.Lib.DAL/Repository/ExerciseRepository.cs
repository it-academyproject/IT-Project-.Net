using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItAcademyProjecteNET.Lib.DAL.Repository
{
    public class ExerciseRepository
    {
        private readonly ItAcademyDbContext _dbContext;

        public ExerciseRepository(ItAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Exercise exercise)
        {
            _dbContext.Set<Exercise>().Add(exercise);
            _dbContext.SaveChanges();
        }

        public void Delete(Exercise exercise)
        {
            if (exercise != null)
            {
                _dbContext.Set<Exercise>().Remove(exercise);
                _dbContext.SaveChanges();
            }
        }
    }
}
