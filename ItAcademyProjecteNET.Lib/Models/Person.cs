using CoItAcademyProjecteNET.LibdeFirst.Models.Enums;
using ItAcademyProjecteNET.Lib.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.Lib.Models
{
    public class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompleteName
        {
            get
            {
                return this.Name + " " + this.LastName;
            }
        }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set;  }


        [Column("PersonGender")]
        public string PersonGenderString
        {
            get { return PersonGender.ToString(); }
            private set { PersonGender = value.ParseEnum<PersonGenders>(); }
        }

        [NotMapped]
        public PersonGenders PersonGender { get; set; }


        [Column("PersonRole")]
        public string PersonRoleString
        {
            get { return PersonRole.ToString(); }
            private set { PersonRole = value.ParseEnum<PersonRoles>(); }
        }

        [NotMapped]
        public PersonRoles PersonRole { get; set; }


    }
}
