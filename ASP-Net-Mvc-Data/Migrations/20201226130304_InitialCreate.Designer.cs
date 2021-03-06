﻿// <auto-generated />
using System;
using ASP_Net_Mvc_Data.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ASP_Net_Mvc_Data.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20201226130304_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ASP_Net_Mvc_Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CityList");
                });

            modelBuilder.Entity("ASP_Net_Mvc_Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CountryList");
                });

            modelBuilder.Entity("ASP_Net_Mvc_Data.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PersonList");
                });

            modelBuilder.Entity("ASP_Net_Mvc_Data.Models.City", b =>
                {
                    b.HasOne("ASP_Net_Mvc_Data.Models.Country", "Country")
                        .WithMany("CityList")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("ASP_Net_Mvc_Data.Models.Person", b =>
                {
                    b.HasOne("ASP_Net_Mvc_Data.Models.City", "City")
                        .WithMany("PeopleList")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
