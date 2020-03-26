using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.Lib.Models
{
    public class Student : Person
    {
        public int Absences { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime BeginData { get; set; }

        public DateTime EndData { get; set; }

        [NotMapped]
        public virtual ICollection<Event> Events { get; set; }

        [NotMapped]
        public virtual ICollection<Exercise> Exercises { get; set; }




        [Column("Itinerary")]
        public string ItineraryString
        {
            get { return Itinerary.ToString(); }
            private set { Itinerary = value.ParseEnum<Itineraries>(); }
        }

        [NotMapped]
        public Itineraries Itinerary { get; set; }



    }
}
