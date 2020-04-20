using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoItAcademyProjecteNET.LibdeFirst.Models.Enums;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using ItAcademyProjecteNET.App;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.DAL.Repository;
using ItAcademyProjecteNET.Lib.Models;
using ItAcademyProjecteNET.Lib.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ItAcademyProjecteNET
{
    public class FillDictionary
    {
        public FillDictionary()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ItAcademyDbContext>();

            optionsBuilder.UseSqlServer(dbConnection, x => x.MigrationsAssembly("ItAcademyProjecteNET"));

            var dbContext = new ItAcademyDbContext(optionsBuilder.Options);



            //var repoPerson = new PersonRepository(dbContext);
            //if (repoPerson.GetPersons().Count() == 0)
            //{
            //    var person = new Student();

            //    person.Name = "Lola";
            //    person.LastName = "Lola";
            //    person.Email = "123@lola.com";
            //    person.PersonRole = PersonRoles.Admin;
            //    person.PersonGender = PersonGenders.Female;
            //    person.Picture = "picture";
            //    person.Password = "12345";

            //    repoPerson.Add(person);
            //}

            var boostrapper = new Bootstrapper();
            boostrapper.Init();

            var repoStu = Entity.DepCon.Resolve<IRepository<Student>>();
            if (repoStu.QueryAll().Count() == 0)
            {
                var newStudent = new Student()
                {
                    Name = "Pedro",
                    LastName = "Cortes",
                    Email = "holi@holi.com",
                    Age = 33,
                    Dni = "11111111A",
                    Password = "yaEstoy",
                    Picture = "url.picture.com",
                    PersonGender = PersonGenders.Male,
                    PersonRole = PersonRoles.Admin,
                    Absences = 0,
                };

                var op = newStudent.Save();
            }




            var repoEvent = new EventRepository(dbContext);
            var myevent = new Event
            {
                Name = "BlockChain",
                Description = "Ponencia especializada en BlockChain",
                Place = "Auditori Cibernarium",
                EventType = EventTypes.Masterclass
            };

            repoEvent.Add(myevent);


            var repoExercise = new ExerciseRepository(dbContext);
            var exercise = new Exercise
            {
                Name = "Variables",
                ShortDescription = "Manejo Variables",
                IsCommonBlock = false,
                Itinerary = Itineraries.Net,
                ResourceLevel = ResourceLevels.Basic
            };

            repoExercise.Add(exercise);


            var repoTeachingMaterial = new TeachingMaterialRepository(dbContext);
            var teachingMaterial = new TeachingMaterial
            {
                Name = "TeachMat",
                ShortDescription = "How to...",
                Description = "Learn Entity Framework",
                IsCommonBlock = false,
                Itinerary = Itineraries.Net,
                ResourceLevel = ResourceLevels.Middle,
                MaterialLink = "www.ajdfadfkjaldfjalfa",
                MaterialType = MaterialTypes.document
            };

            repoTeachingMaterial.Add(teachingMaterial);




        }
    }
}
