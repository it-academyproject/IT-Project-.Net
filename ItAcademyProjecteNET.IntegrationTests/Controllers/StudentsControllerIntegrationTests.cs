using CoItAcademyProjecteNET.LibdeFirst.Models.Enums;
using ItAcademyProjecteNET.Lib.Models;
using ItAcademyProjecteNET.Lib.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ItAcademyProjecteNET.IntegrationTests.Controllers
{
    public class StudentsControllerIntegrationTests
    {
        [Fact]
        public async Task GetStudents_ApiCallResponse()
        {

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/students");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

        }



        [Fact]
        public async Task PostStudent_ApiCallResponse()
        {
            using (var client = new TestClientProvider().Client)
            {
                var student = new Student()
                {
                    Name = "PedroTest",
                    LastName = "CortesTest",
                    Email = "holi@holi.comTest",
                    Age = 33,
                    Dni = "test",
                    Password = "test",
                    Picture = "url.test.com",
                    PersonGender = PersonGenders.Male,
                    PersonRole = PersonRoles.Admin,
                    Absences = 0,
                };

                var stuJson = JsonConvert.SerializeObject(student);

                var response = await client.PostAsync("/api/students", new StringContent(stuJson, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
