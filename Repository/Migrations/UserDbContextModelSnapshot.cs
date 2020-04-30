﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.UserDBContext;

namespace Repository.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.ParkingModel", b =>
                {
                    b.Property<string>("VehicalNo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChargesPerHour");

                    b.Property<string>("DriverCategory");

                    b.Property<DateTime>("EntryTime");

                    b.Property<string>("ParkingType");

                    b.Property<string>("VehicalType");

                    b.HasKey("VehicalNo");

                    b.ToTable("ParkingSpace");
                });
#pragma warning restore 612, 618
        }
    }
}
