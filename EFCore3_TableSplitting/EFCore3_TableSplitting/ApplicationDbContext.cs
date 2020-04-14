using System;
using System.Collections.Generic;
using System.Text;
using EFCore3_TableSplitting.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCore3_TableSplitting
{
    public class ApplicationDbContext : DbContext

    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Con esta validación se está asegurando que en caso de que, por ejemplo, optionsBuilder.UseSqlServer ya haya sido confu¡igurada
            // en otro archivo no se cree esta configuración, XEj, en ASP.NETCore MVC esta configuración se realiza en el archivo startup
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = EFCore3_TableSplitter; Integrated Security = true;")
                    // Esta opción solo debe ser usada en tiempo de desarrollo
                    .EnableSensitiveDataLogging(true)
                    //.UseLazyLoadingProxies()
                    .UseLoggerFactory(GetLoggerFactory());
            }
        }

        // El uso del Logger Factory es nuevo!
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                   builder.AddFilter(DbLoggerCategory.Database.Command.Name,
                                     LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().HasOne(x => x.Detalles)
                .WithOne(x => x.Estudiante)
                .HasForeignKey<EstudianteDetalle>(x => x.Id);

            modelBuilder.Entity<EstudianteDetalle>().ToTable("Estudiantes");
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteDetalle> EstudianteDetalles { get; set; }


    }   //*
}
