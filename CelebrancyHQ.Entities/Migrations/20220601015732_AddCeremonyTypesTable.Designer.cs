﻿// <auto-generated />
using System;
using CelebrancyHQ.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    [DbContext(typeof(CelebrancyHQContext))]
    [Migration("20220601015732_AddCeremonyTypesTable")]
    partial class AddCeremonyTypesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("CeremonyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3162),
                            Description = "A ceremony to celebrate the joining of two persons in marriage.",
                            Name = "Marriage Ceremony",
                            Updated = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3162)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3172),
                            Description = "A ceremony to celebrate the life of and remember a person who has recently passed way.",
                            Name = "Funeral Ceremony",
                            Updated = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3173)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Organisations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2627),
                            Name = "CelebrancyHQ",
                            Updated = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2633)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2942),
                            EmailAddress = "system.admin@celebrancyhq.co",
                            FirstName = "CelebrancyHQ",
                            LastName = "System Administrator",
                            Updated = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2943)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3051),
                            EmailAddress = "system.admin@celebrancyhq.co",
                            PasswordHash = "testpassword",
                            PasswordSalt = "passwordsalt",
                            PersonId = 0,
                            Updated = new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3052)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyType", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.Person", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.User", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
