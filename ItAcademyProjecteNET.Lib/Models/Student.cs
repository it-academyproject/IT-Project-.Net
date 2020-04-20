using Common.Lib.Core;
using Common.Lib.Infrastructure;
using ItAcademyProjecteNET.Lib.Interfaces;
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


        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateDni(output);

            return output;
        }

        public OperationResult<Student> Save()
        {
            var opResult = base.Save<Student>();
            return opResult;
        }

        public OperationResult<Student> Delete()
        {
            var opResult = base.Delete<Student>();
            return opResult;
        }


        #region Domain validations

        public void ValidateName(ValidationResult output)
        {
            var vr = ValidateName(this.Name);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }

        }

        public void ValidateDni(ValidationResult output)
        {
            var vr = ValidateDni(this.Dni, this.Id);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }


        #endregion

        #region Static validations

        public static ValidationResult<string> ValidateName(string name)
        {
            var output = new ValidationResult<string>();

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("The name cannot be empty!!");
            }

            if (output.IsSuccess)
                output.ValidatedResult = name;

            return output;

        }

        public static ValidationResult<string> ValidateDni(string dni, int currentId = default)
        {
            var output = new ValidationResult<string>();

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("The dni cannot be empty!");
            }

            var repo = Entity.DepCon.Resolve<IStudentRepository>();

            if (currentId == default)
            {
                var currentStudentinRepo = repo.GetStudentByDni(dni);

                if (currentStudentinRepo != null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("This DNI is already in db!");
                }

            }

            if (currentId != default)
            {
                var studentRepo = repo.Find(currentId);

                if (studentRepo == null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("Not found in DB");
                }

            }

            if (output.IsSuccess == true)
                output.ValidatedResult = dni;

            return output;
        }

        #endregion


    }
}
