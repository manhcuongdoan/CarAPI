﻿// <auto-generated />
using System;
using CarAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarAPI.Migrations
{
    [DbContext(typeof(CarContext))]
    [Migration("20200925081853_Them quan he")]
    partial class Themquanhe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarAPI.Models.CarSpecification", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CarId");

                    b.HasIndex("CarTypeId");

                    b.ToTable("CarSpecifications");
                });

            modelBuilder.Entity("CarAPI.Models.CarType", b =>
                {
                    b.Property<int>("CarTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarTypeId");

                    b.ToTable("CarTypes");
                });

            modelBuilder.Entity("CarAPI.Models.CarSpecification", b =>
                {
                    b.HasOne("CarAPI.Models.CarType", "CarType")
                        .WithMany("CarSpecification")
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
