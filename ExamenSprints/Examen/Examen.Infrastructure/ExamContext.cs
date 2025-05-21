using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Examen.Infrastructure
{
    public class ExamContext: DbContext
    {
        //DBSET

        DbSet<Tache> Taches { get; set; }

        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamSprints;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies(true);
            base.OnConfiguring(optionsBuilder);
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TacheConfig());

            //base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(200);
        }
    }
}
