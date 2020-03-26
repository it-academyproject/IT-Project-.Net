using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItAcademyProjecteNET.Lib.DAL.Repository
{
    public class EventRepository
    {
        private readonly ItAcademyDbContext _dbContext;

        public EventRepository(ItAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Event myEvent)
        {
            _dbContext.Set<Event>().Add(myEvent);
            _dbContext.SaveChanges();
        }

        public void Delete(Event myEvent)
        {
            if (myEvent != null)
            {
                _dbContext.Set<Event>().Remove(myEvent);
                _dbContext.SaveChanges();
            }
        }

    }

}
