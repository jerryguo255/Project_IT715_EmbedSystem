﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestSerial_ConsoleApp;

namespace TestSerial_ConsoleApp.Migrations
{
    [DbContext(typeof(WeatherRecordDBContext))]
    [Migration("20191025083207_CreateWeatherRecordDB")]
    partial class CreateWeatherRecordDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestSerial_ConsoleApp.WeatherRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCollection")
                        .HasColumnType("datetime2");

                    b.Property<double>("HumIndoor")
                        .HasColumnType("float");

                    b.Property<double>("HumOutside")
                        .HasColumnType("float");

                    b.Property<double>("TempIndoor")
                        .HasColumnType("float");

                    b.Property<double>("TempOutside")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("WeatherRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
