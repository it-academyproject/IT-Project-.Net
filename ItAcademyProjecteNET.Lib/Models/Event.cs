using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        //public List<Student> Attendants { get; set; }
        [NotMapped]
        public virtual ICollection<Student> Students { get; set; }

        public string Place { get; set; }

        [Column("EventType")]
        public string EventTypeString
        {
            get { return EventType.ToString(); }
            private set { EventType = value.ParseEnum<EventTypes>(); }
        }

        [NotMapped]
        public EventTypes EventType { get; set; }

    }
}
