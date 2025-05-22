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



        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamActivite;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies(true);
            base.OnConfiguring(optionsBuilder);
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(i => i.Conseiller)
                .WithMany(i => i.Clients)
                .HasForeignKey(i => i.ConseillerFK)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>().HasKey(i => new { i.ClientFK, i.PackFK });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(15);
                }
            }


            //base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //base.ConfigureConventions(configurationBuilder);
        }
    }
}
