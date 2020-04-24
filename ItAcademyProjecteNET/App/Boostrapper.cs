using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using ItAcademyProjecteNET.ItAcademyDbContextFactory;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.DAL.Repository;
using ItAcademyProjecteNET.Lib.Interfaces;
using ItAcademyProjecteNET.Lib.Models;
using System;

namespace ItAcademyProjecteNET.App
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {

        }

        public IDependencyContainer Init()
        {
            var dp = new SimpleDependencyContainer();

            RegisterRepositories(dp);

            Entity.DepCon = dp;

            return dp;
        }

        public void RegisterRepositories(IDependencyContainer dp)
        {
            var studentsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new StudentsRepository(GetDbConstructor());
            });

            dp.Register<IRepository<Student>, StudentsRepository>(studentsRepoBuilder);
            dp.Register<IStudentRepository, StudentsRepository>((parameters) => new StudentsRepository(GetDbConstructor()));

        }

        private static ItAcademyDbContext GetDbConstructor()
        {
            var factory = new ItAcademyContextFactory();
            return factory.CreateDbContext(null);
        }

    }
}
