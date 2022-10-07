﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientManager.Sql.DbContexts;

#nullable disable

namespace PatientManager.Sql.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220927042631_AddHealthInsurance")]
    partial class AddHealthInsurance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("PatientManager.Domain.Common.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("PatientManager.Domain.Common.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("HealthInsurance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("MedicalRecordNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PatientManager.Domain.Common.Entities.Attendance", b =>
                {
                    b.HasOne("PatientManager.Domain.Common.Entities.Patient", null)
                        .WithMany("Attendances")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("PatientManager.Domain.Common.Entities.Patient", b =>
                {
                    b.OwnsOne("PatientManager.Domain.Common.ValueObjects.Person", "Person", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("CPF")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("CPF");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Name");

                            b1.Property<string>("Photo")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Photo");

                            b1.Property<string>("RG")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("RG");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("PatientManager.Domain.Common.Entities.Patient", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}