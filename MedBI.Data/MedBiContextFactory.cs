using MedBI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data
{
    public class MedBIContextFactory : IDesignTimeDbContextFactory<MedBIContext>
    {
        public MedBIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedBIContext>();

            // adjust connection string to your dev SQL Server
            optionsBuilder.UseSqlServer("Server=localhost;Database=MedClaims;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new MedBIContext(optionsBuilder.Options);
        }
    }
}
