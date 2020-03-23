using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.Lib.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public List<Student> Attendants { get; set; }

        public string Place { get; set; }

        public EventTypes EventType { get; set; }

    }
}
