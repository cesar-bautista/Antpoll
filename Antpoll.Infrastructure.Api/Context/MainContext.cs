using System.Data.Entity;
using Antpoll.Domain.Core.Configuration;
using Antpoll.Domain.Entities;

namespace Antpoll.Infrastructure.Api.Context
{
    public class MainContext : DbContext
    {
        public MainContext() 
            : base(ConfigManager.DefaultConnection)
        {
            Database.SetInitializer(new NullDatabaseInitializer<MainContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>()
                .ToTable("SYS_Company")
                .HasKey(k => new { k.CompanyId });

            modelBuilder.Entity<ApplicationEntity>()
                .ToTable("SYS_Application")
                .HasKey(k => new { k.ApplicationId });
        }
    }
}
