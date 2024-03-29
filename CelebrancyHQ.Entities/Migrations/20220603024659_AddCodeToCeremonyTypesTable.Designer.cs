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
    [Migration("20220603024659_AddCodeToCeremonyTypesTable")]
    partial class AddCodeToCeremonyTypesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CelebrancyHQ.Entities.Ceremony", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CeremonyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CeremonyTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CeremonyTypeId");

                    b.ToTable("Ceremonies");
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Code = "Marriage",
                            Created = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5427),
                            Description = "A ceremony to celebrate the joining of two persons in marriage.",
                            Name = "Marriage Ceremony",
                            Updated = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5427)
                        },
                        new
                        {
                            Id = 2,
                            Code = "Funeral",
                            Created = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5436),
                            Description = "A ceremony to celebrate the life of and remember a person who has recently passed way.",
                            Name = "Funeral Ceremony",
                            Updated = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5437)
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
                            Created = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(4742),
                            Name = "CelebrancyHQ",
                            Updated = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(4746)
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
                            Created = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5024),
                            EmailAddress = "system.admin@celebrancyhq.co",
                            FirstName = "CelebrancyHQ",
                            LastName = "System Administrator",
                            Updated = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5024)
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
                            Created = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5154),
                            EmailAddress = "system.admin@celebrancyhq.co",
                            PasswordHash = "testpassword",
                            PasswordSalt = "passwordsalt",
                            PersonId = 0,
                            Updated = new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5155)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.Ceremony", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.CeremonyType", "CeremonyType")
                        .WithMany()
                        .HasForeignKey("CeremonyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CeremonyType");
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
