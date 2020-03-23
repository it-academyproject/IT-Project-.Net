using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ItAcademyProjecteNET.Lib.Models
{
    public class TeachingMaterial : Resource
    {
        public string Lesson { get; set; }
        public MaterialTypes MaterialType { get; set; }

        public string MaterialLink { get; set; }
    }
}
