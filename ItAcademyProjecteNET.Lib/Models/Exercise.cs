using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.Lib.Models
{
    public class Exercise : Resource
    {
        public string AvalableTime { get; set; }

        public DateTime DeliveryDate { get; set; }


        // public double Mark { get; set; }

        [Column("ExerciseStatus")]
        public string ExerciseStatusString
        {
            get { return ExerciseStatus.ToString(); }
            private set { ExerciseStatus = value.ParseEnum<ExerciseStatus>(); }
        }

        [NotMapped]
        public ExerciseStatus ExerciseStatus { get; set; }

    }
}
