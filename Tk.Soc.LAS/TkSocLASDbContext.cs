using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Tk.Soc.LAS.Models;

namespace Tk.Soc.LAS
{
    public class TkSocLASDbContext : DbContext
    {
        // public DbSet<Company> Companys { get; set; }

        public DbSet<t_svr_proc_all_history_bak> t_svr_proc_all_history_bak { get; set; }

        private IConfiguration configuration;

        public TkSocLASDbContext()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory
                .GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(configuration.GetConnectionString("Default"));
            //optionsBuilder.UseMySql(configuration.GetConnectionString("ConnectionDatabaseStr"));
        }
    }
}
