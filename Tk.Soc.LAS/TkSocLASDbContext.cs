using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Tk.Soc.LAS.Models;

namespace Tk.Soc.LAS
{
    public class TkSocLASDbContext : DbContext
    {
        public DbSet<Company> Companys { get; set; }

        private IConfiguration configuration;

        public TkSocLASDbContext()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory
                .GetCurrentDirectory())
                .AddJsonFile(@"D:\WorkCode\2020\0811\ExampleCode\Tk.Soc.LAS\appsettings.json").Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(configuration.GetConnectionString("Default"));
        }
    }
}
