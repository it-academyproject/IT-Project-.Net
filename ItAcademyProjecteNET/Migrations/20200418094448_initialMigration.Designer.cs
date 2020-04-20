﻿// <auto-generated />
using System;
using ItAcademyProjecteNET.Lib.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItAcademyProjecteNET.Migrations
{
    [DbContext(typeof(ItAcademyDbContext))]
    [Migration("20200418094448_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Lib.Core.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity");
                });

            modelBuilder.Entity("ItAcademyProjecteNET.Lib.Models.Event", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTypeString")
                        .HasColumnName("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Event");
                });

            modelBuilder.Entity("ItAcademyProjecteNET.Lib.Models.Exercise", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<string>("AvalableTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnName("Exercise_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseStatusString")
                        .HasColumnName("ExerciseStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCommonBlock")
                        .HasColumnType("bit");

                    b.Property<string>("ItineraryString")
                        .HasColumnName("Itinerary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("Exercise_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceLevelString")
                        .HasColumnName("ResourceLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Exercise");
                });

            modelBuilder.Entity("ItAcademyProjecteNET.Lib.Models.Person", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("Person_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonGenderString")
                        .HasColumnName("PersonGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRoleString")
                        .HasColumnName("PersonRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Person");
                });

            modelBuilder.Entity("ItAcademyProjecteNET.Lib.Models.TeachingMaterial", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<string>("Description")
                        .HasColumnName("TeachingMaterial_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCommonBlock")
                        .HasColumnType("bit");

                    b.Property<string>("ItineraryString")
                        .HasColumnName("Itinerary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lesson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialTypeString")
                        .HasColumnName("MaterialType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("TeachingMaterial_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceLevelString")
                        .HasColumnName("ResourceLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("TeachingMaterial");
                });

            modelBuilder.Entity("ItAcademyProjecteNET.Lib.Models.Student", b =>
                {
                    b.HasBaseType("ItAcademyProjecteNET.Lib.Models.Person");

                    b.Property<int>("Absences")
                        .HasColumnType("int");

                    b.Property<DateTime>("BeginData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndData")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItineraryString")
                        .HasColumnName("Itinerary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Student");
                });
#pragma warning restore 612, 618
        }
    }
}