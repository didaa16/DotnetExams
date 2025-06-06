﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamContext))]
    partial class ExamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Colis", b =>
                {
                    b.Property<int>("ClientFK")
                        .HasColumnType("int");

                    b.Property<string>("LivreurFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateLivraison")
                        .HasColumnType("datetime2");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.Property<double>("Poids")
                        .HasColumnType("float");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.HasKey("ClientFK", "LivreurFK");

                    b.HasIndex("LivreurFK");

                    b.ToTable("Colis");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Livreur", b =>
                {
                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RasseSociale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CIN");

                    b.ToTable("Livreur");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Vehicule", b =>
                {
                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VitesseLimite")
                        .HasColumnType("int");

                    b.HasKey("Matricule");

                    b.ToTable("Vehicule");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LivreurVehicule", b =>
                {
                    b.Property<string>("LivreursCIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VehiculesMatricule")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LivreursCIN", "VehiculesMatricule");

                    b.HasIndex("VehiculesMatricule");

                    b.ToTable("Conduite", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Camion", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Vehicule");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("NbrEssieux")
                        .HasColumnType("int");

                    b.ToTable("Camions", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Voiture", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Vehicule");

                    b.Property<int>("NbrPlaces")
                        .HasColumnType("int");

                    b.ToTable("Voitures", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Colis", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Client", "Client")
                        .WithMany("Colis")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Livreur", "Livreur")
                        .WithMany("Coliss")
                        .HasForeignKey("LivreurFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Livreur");
                });

            modelBuilder.Entity("LivreurVehicule", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Livreur", null)
                        .WithMany()
                        .HasForeignKey("LivreursCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Vehicule", null)
                        .WithMany()
                        .HasForeignKey("VehiculesMatricule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Camion", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Vehicule", null)
                        .WithOne()
                        .HasForeignKey("Examen.ApplicationCore.Domain.Camion", "Matricule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Voiture", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Vehicule", null)
                        .WithOne()
                        .HasForeignKey("Examen.ApplicationCore.Domain.Voiture", "Matricule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("Colis");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Livreur", b =>
                {
                    b.Navigation("Coliss");
                });
#pragma warning restore 612, 618
        }
    }
}
