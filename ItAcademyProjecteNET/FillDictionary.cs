using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoItAcademyProjecteNET.LibdeFirst.Models.Enums;
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

            var repoPerson = new PersonRepository(dbContext);

            if (repoPerson.GetPersons().Count() == 0)
            {
                var person = new Person();

                person.Name = "Lola";
                person.LastName = "Lola";
                person.Email = "123@lola.com";
                person.PersonRole = PersonRoles.Admin;
                person.PersonGender = PersonGenders.Female;
                person.Picture = "picture";
                person.Password = "12345";

                repoPerson.Add(person);
            }



            var repoEvent = new EventRepository(dbContext);

            var myevent = new Event();

            myevent.Name = "BlockChain";
            myevent.Description = "Ponencia especializada en BlockChain";
            myevent.Place = "Auditori Cibernarium";
            myevent.EventType = EventTypes.Masterclass;


            repoEvent.Add(myevent);


            var repoExercise = new ExerciseRepository(dbContext);

            var exercise = new Exercise();

            exercise.Name = "Variables";
            exercise.ShortDescription = "Manejo Variables";
            exercise.IsCommonBlock = false;
            exercise.Itinerary = Itineraries.Net;
            exercise.ResourceLevel = ResourceLevels.Basic;

            repoExercise.Add(exercise);


            var repoTeachingMaterial = new TeachingMaterialRepository(dbContext);

            var teachingMaterial = new TeachingMaterial();

            teachingMaterial.Name = "TeachMat";
            teachingMaterial.ShortDescription = "How to...";
            teachingMaterial.Description = "Learn Entity Framework";
            teachingMaterial.IsCommonBlock = false;
            teachingMaterial.Itinerary = Itineraries.Net;
            teachingMaterial.ResourceLevel = ResourceLevels.Middle;
            teachingMaterial.MaterialLink = "www.ajdfadfkjaldfjalfa";
            teachingMaterial.MaterialType = MaterialTypes.document;

            repoTeachingMaterial.Add(teachingMaterial);




        }
    }
}
