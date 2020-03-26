using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItAcademyProjecteNET.Lib.DAL.Repository
{
    public class TeachingMaterialRepository
    {
        private readonly ItAcademyDbContext _dbContext;

        public TeachingMaterialRepository(ItAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TeachingMaterial teachingMaterial)
        {
            _dbContext.Set<TeachingMaterial>().Add(teachingMaterial);
            _dbContext.SaveChanges();
        }

        public void Delete(TeachingMaterial teachingMaterial)
        {
            if (teachingMaterial != null)
            {
                _dbContext.Set<TeachingMaterial>().Remove(teachingMaterial);
                _dbContext.SaveChanges();
            }
        }
    }
}
