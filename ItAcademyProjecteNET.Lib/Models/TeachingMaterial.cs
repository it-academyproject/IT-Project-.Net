using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ItAcademyProjecteNET.Lib.Models
{
    public class TeachingMaterial : Resource
    {
        public string Lesson { get; set; }

        public string MaterialLink { get; set; }


        [Column("MaterialType")]
        public string MaterialTypeString
        {
            get { return MaterialType.ToString(); }
            private set { MaterialType = value.ParseEnum<MaterialTypes>(); }
        }

        [NotMapped]
        public MaterialTypes MaterialType { get; set; }

    }
}
