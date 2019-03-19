using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StARKS.Entities;
using System.IO;

namespace StARKS.Database_Context
{
    /// <summary>
    /// The app Db context.
    /// </summary>
    public class DBContext : DbContext
    {
        public DBContext()
        { }

        /// <summary>
        /// The OnConfiguring.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        /// <summary>
        /// The Students DbSet.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// The Courses DbSet.
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// The Marks DbSet.
        /// </summary>
        public DbSet<Mark> Marks { get; set; }
    }
}
