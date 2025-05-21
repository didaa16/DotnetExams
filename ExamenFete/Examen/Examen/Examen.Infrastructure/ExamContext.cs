using System;
using System.Collections.Generic;
using System.Drawing;
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

        DbSet<Invitation> Invitations { get; set; }

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
            modelBuilder.Entity<Invitation>()
                .HasOne(i => i.Fete)
                .WithMany(i => i.Invitations)
                .HasForeignKey(i => i.FeteFK);

            modelBuilder.Entity<Invitation>()
                .HasOne(i => i.Invite)
                .WithMany(i => i.Invitations)
                .HasForeignKey(i => i.InviteFK);

            modelBuilder.Entity<Invitation>()
                .HasKey(i => new { i.FeteFK, i.InviteFK, i.DateInvitation });

            //base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
            //base.ConfigureConventions(configurationBuilder);
        }
    }
}
