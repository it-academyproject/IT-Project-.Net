using ItAcademyProjecteNET.Lib.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ItAcademyProjecteNET.ItAcademyDbContextFactory
{
    public class ItAcademyContextFactory
    {
        public ItAcademyDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ItAcademyDbContext>();
            optionsBuilder.UseSqlServer(dbConnection, x => x.MigrationsAssembly("ItAcademyProjecteNET")); // Caution qith name: 

            return new ItAcademyDbContext(optionsBuilder.Options);
        }

    }
}
