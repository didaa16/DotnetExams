using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static Azure.Core.HttpHeader;

namespace Examen.Infrastructure
{
    public class ExamContext: DbContext
    {
        //DBSET
        DbSet<Participant> Participants { get; set; }


        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=AhmedMezni;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies(true);
            base.OnConfiguring(optionsBuilder);
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Participant)
                .WithMany(i => i.Inscriptions)
                .HasForeignKey(i => i.ParticipantFK);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Seminaire)
                .WithMany(i => i.Inscriptions)
                .HasForeignKey(i => i.SeminaireFK);

            modelBuilder.Entity<Inscription>()
                .HasKey(i => new { i.SeminaireFK, i.ParticipantFK, i.DateInscription });
            
            modelBuilder.Entity<Participant>()
                        .HasDiscriminator<char>("TypeParticipant")
                        .HasValue<Participant>('P')
                        .HasValue<Industriel>('I')
                        .HasValue<Universitaire>('U'); 

            //base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);
            //base.ConfigureConventions(configurationBuilder);
        }
    }
}
