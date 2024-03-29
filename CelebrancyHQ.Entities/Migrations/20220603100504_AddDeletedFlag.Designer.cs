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
    [Migration("20220603100504_AddDeletedFlag")]
    partial class AddDeletedFlag
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CeremonyId")
                        .HasColumnType("int");

                    b.Property<int>("CeremonyTypeParticipantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CeremonyId");

                    b.HasIndex("CeremonyTypeParticipantId");

                    b.HasIndex("PersonId");

                    b.ToTable("CeremonyParticipants");
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

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
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(945),
                            Deleted = false,
                            Description = "A ceremony to celebrate the joining of two persons in marriage.",
                            Name = "Marriage Ceremony",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(946)
                        },
                        new
                        {
                            Id = 2,
                            Code = "Funeral",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(958),
                            Deleted = false,
                            Description = "A ceremony to celebrate the life of and remember a person who has recently passed way.",
                            Name = "Funeral Ceremony",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(959)
                        });
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyTypeParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CeremonyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CeremonyTypeId");

                    b.ToTable("CeremonyTypeParticipants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CeremonyTypeId = 1,
                            Code = "Celebrant",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1177),
                            Deleted = false,
                            Name = "Celebrant",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1178)
                        },
                        new
                        {
                            Id = 2,
                            CeremonyTypeId = 2,
                            Code = "Celebrant",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1189),
                            Deleted = false,
                            Name = "Celebrant",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1189)
                        },
                        new
                        {
                            Id = 3,
                            CeremonyTypeId = 1,
                            Code = "Couple",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1194),
                            Deleted = false,
                            Name = "Couple",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1195)
                        },
                        new
                        {
                            Id = 4,
                            CeremonyTypeId = 1,
                            Code = "Organiser",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1200),
                            Deleted = false,
                            Name = "Organiser",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1201)
                        },
                        new
                        {
                            Id = 5,
                            CeremonyTypeId = 2,
                            Code = "Organiser",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1205),
                            Deleted = false,
                            Name = "Organiser",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1206)
                        },
                        new
                        {
                            Id = 6,
                            CeremonyTypeId = 1,
                            Code = "Witness",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1216),
                            Deleted = false,
                            Name = "Witness",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1216)
                        },
                        new
                        {
                            Id = 7,
                            CeremonyTypeId = 1,
                            Code = "BridalParty",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1221),
                            Deleted = false,
                            Name = "Bridal party",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1222)
                        },
                        new
                        {
                            Id = 8,
                            CeremonyTypeId = 1,
                            Code = "InvitedGuest",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1226),
                            Deleted = false,
                            Name = "Invited guest",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1227)
                        },
                        new
                        {
                            Id = 9,
                            CeremonyTypeId = 2,
                            Code = "Deceased",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1231),
                            Deleted = false,
                            Name = "Deceased person",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1232)
                        },
                        new
                        {
                            Id = 10,
                            CeremonyTypeId = 2,
                            Code = "InvitedGuest",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1239),
                            Deleted = false,
                            Name = "Invited guest",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1239)
                        },
                        new
                        {
                            Id = 11,
                            CeremonyTypeId = 1,
                            Code = "Other",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1244),
                            Deleted = false,
                            Name = "Other",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1245)
                        },
                        new
                        {
                            Id = 12,
                            CeremonyTypeId = 2,
                            Code = "Other",
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1249),
                            Deleted = false,
                            Name = "Other",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(1250)
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

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
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(398),
                            Deleted = false,
                            Name = "CelebrancyHQ",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(399)
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

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
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(684),
                            Deleted = false,
                            EmailAddress = "system.admin@celebrancyhq.co",
                            FirstName = "CelebrancyHQ",
                            LastName = "System Administrator",
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(685)
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

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
                            Created = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(821),
                            Deleted = false,
                            EmailAddress = "system.admin@celebrancyhq.co",
                            PasswordHash = "testpassword",
                            PasswordSalt = "passwordsalt",
                            PersonId = 0,
                            Updated = new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(822)
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

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyParticipant", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.Ceremony", "Ceremony")
                        .WithMany()
                        .HasForeignKey("CeremonyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CelebrancyHQ.Entities.CeremonyTypeParticipant", "CeremonyTypeParticipant")
                        .WithMany()
                        .HasForeignKey("CeremonyTypeParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CelebrancyHQ.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ceremony");

                    b.Navigation("CeremonyTypeParticipant");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyType", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("CelebrancyHQ.Entities.CeremonyTypeParticipant", b =>
                {
                    b.HasOne("CelebrancyHQ.Entities.CeremonyType", "CeremonyType")
                        .WithMany()
                        .HasForeignKey("CeremonyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CeremonyType");
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
