using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.Lib.Models
{
    public class Exercise : Resource
    {
        public string AvalableTime { get; set; }

        public DateTime DeliveryDate { get; set; }

        public ExerciseStatus ExerciseStatus { get; set; }

        // public double Mark { get; set; }
    }
}
