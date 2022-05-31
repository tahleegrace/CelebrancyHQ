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
    [Migration("20220531093840_AddPersonsTable")]
    partial class AddPersonsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(586),
                            EmailAddress = "system.admin@celebrancyhq.co",
                            FirstName = "CelebrancyHQ",
                            LastName = "System Administrator",
                            Updated = new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(589)
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

                    b.Property<int?>("PersonId")
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
                            Created = new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(798),
                            EmailAddress = "system.admin@celebrancyhq.co",
                            PasswordHash = "testpassword",
                            PasswordSalt = "passwordsalt",
                            Updated = new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(798)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.User", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
