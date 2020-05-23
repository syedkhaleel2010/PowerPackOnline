using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.API.Data
{
    public class ApplicationDbContext : IdentityUserContext<ApplicationUser, int, IdentityUserClaim<int>, IdentityUserLogin<int>,
    IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<IdentityUser>(b =>
            //{
            //    b.ToTable("Users");
            //});

            //builder.Entity<IdentityUserClaim<int>>(b =>
            //{
            //    b.ToTable("UserClaim");
            //});

            //builder.Entity<IdentityUserLogin<int>>(b =>
            //{
            //    b.ToTable("UserLogin");
            //});

            //builder.Entity<IdentityRole>(b =>
            //{
            //    b.ToTable("Roles");
            //});

        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Used only for EF .NET Core CLI tools (update database/migrations etc.)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(config.GetSection("ConnectionString").Value);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
