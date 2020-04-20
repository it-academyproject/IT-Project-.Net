using Common.Lib.Core;
using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.Lib.Models
{
    public abstract class Resource : Entity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool IsCommonBlock { get; set; }


        [Column("Itinerary")]
        public string ItineraryString
        {
            get { return Itinerary.ToString(); }
            private set { Itinerary = value.ParseEnum<Itineraries>(); }
        }

        [NotMapped]
        public Itineraries Itinerary { get; set; }



        [Column("ResourceLevel")]
        public string ResourceLevelString
        {
            get { return ResourceLevel.ToString(); }
            private set { ResourceLevel = value.ParseEnum<ResourceLevels>(); }
        }

        [NotMapped]
        public ResourceLevels ResourceLevel { get; set; }

    }

}
