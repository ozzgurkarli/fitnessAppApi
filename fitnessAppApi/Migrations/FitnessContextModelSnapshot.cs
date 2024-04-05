﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fitnessAppApi.Models;

#nullable disable

namespace fitnessAppApi.Migrations
{
    [DbContext(typeof(FitnessContext))]
    partial class FitnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fitnessAppApi.Models.InvitationCode", b =>
                {
                    b.Property<int>("UsedById")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsedById"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsedById");

                    b.ToTable("InvitationCode");
                });

            modelBuilder.Entity("fitnessAppApi.Models.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Program");
                });

            modelBuilder.Entity("fitnessAppApi.Models.ProgramMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("MoveId")
                        .HasColumnType("int");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Muscle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramMove");
                });

            modelBuilder.Entity("fitnessAppApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("InvitationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("fitnessAppApi.Models.ProgramMove", b =>
                {
                    b.HasOne("fitnessAppApi.Models.Program", null)
                        .WithMany("ProgramMoves")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("fitnessAppApi.Models.Program", b =>
                {
                    b.Navigation("ProgramMoves");
                });
#pragma warning restore 612, 618
        }
    }
}
