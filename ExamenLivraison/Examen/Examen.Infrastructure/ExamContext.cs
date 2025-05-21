using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Examen.Infrastructure
{
    public class ExamContext: DbContext
    {
        //DBSET


        DbSet<Colis> Colis { get; set; }
        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies(true);
            base.OnConfiguring(optionsBuilder);
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colis>()
                .HasKey(c => new { c.ClientFK, c.LivreurFK });

            modelBuilder.Entity<Livreur>()
                        .HasMany(l => l.Vehicules)
                        .WithMany(v => v.Livreurs)
                        .UsingEntity(j => j.ToTable("Conduite"));

            modelBuilder.Entity<Camion>().ToTable("Camions");
            modelBuilder.Entity<Voiture>().ToTable("Voitures");



            //base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //base.ConfigureConventions(configurationBuilder);
        }
    }
}
