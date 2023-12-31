﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainStationProject.Models.Context;

#nullable disable

namespace TrainStationProject.Migrations
{
    [DbContext(typeof(StationContext))]
    [Migration("20230930191231_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainStationProject.Models.Entites.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StationLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("TrainStationProject.Models.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrainStationProject.Models.Entites.Voyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArrivalStationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("DateTime2");

                    b.Property<int>("DepartureStationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("DateTime2");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalStationId");

                    b.HasIndex("DepartureStationId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("TrainStationProject.Models.Entites.Voyage", b =>
                {
                    b.HasOne("TrainStationProject.Models.Entites.Station", "ArrivalStation")
                        .WithMany("ArrivalStations")
                        .HasForeignKey("ArrivalStationId")
                        .IsRequired();

                    b.HasOne("TrainStationProject.Models.Entites.Station", "DepartureStation")
                        .WithMany("DepartureStations")
                        .HasForeignKey("DepartureStationId")
                        .IsRequired();

                    b.Navigation("ArrivalStation");

                    b.Navigation("DepartureStation");
                });

            modelBuilder.Entity("TrainStationProject.Models.Entites.Station", b =>
                {
                    b.Navigation("ArrivalStations");

                    b.Navigation("DepartureStations");
                });
#pragma warning restore 612, 618
        }
    }
}
