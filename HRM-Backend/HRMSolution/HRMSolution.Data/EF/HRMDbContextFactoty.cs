using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HRMSolution.Data.EF
{
    public class HRMDbContextFactoty : IDesignTimeDbContextFactory<HRMDbContext>
    {
        
        public HRMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSetting.json")
            .Build();

            var connectionString = configuration.GetConnectionString("Data");

            var optionBuilder = new DbContextOptionsBuilder<HRMDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new HRMDbContext(optionBuilder.Options);
        }
    }
}
