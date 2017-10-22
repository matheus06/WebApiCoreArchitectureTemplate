using System.IO;
using Microsoft.EntityFrameworkCore;
using MSAP.WebApiCore.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace MSAP.WebApiCore.Infra.Data.Context
{
    public class WebApiContext : DbContext
    {
        public DbSet<Todo> Todo { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentAPI

            modelBuilder.Entity<Todo>()
                .Property(s => s.Serial)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Todo>()
                .Property(s => s.Descricao)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Todo>()
                .Property(s => s.Host)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Todo>()
                .ToTable("Todo");



            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
