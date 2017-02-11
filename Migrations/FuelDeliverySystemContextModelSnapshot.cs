using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FuelDeliverySystem.Data;

namespace FuelDeliverySystem.Migrations
{
    [DbContext(typeof(FuelDeliverySystemContext))]
    partial class FuelDeliverySystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("FuelDeliverySystem.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OperatingRegionId");

                    b.Property<int>("PostalCode");

                    b.HasKey("LocationId");

                    b.HasIndex("OperatingRegionId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.OperatingRegion", b =>
                {
                    b.Property<int>("OperatingRegionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Radius");

                    b.HasKey("OperatingRegionId");

                    b.ToTable("OperatingRegion");
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Stop", b =>
                {
                    b.Property<int>("StopId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<int>("FuelPercentageUsed");

                    b.Property<int>("LocationId");

                    b.Property<int>("TripId");

                    b.HasKey("StopId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TripId");

                    b.ToTable("Stop");
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<int>("TruckId");

                    b.HasKey("TripId");

                    b.HasIndex("TruckId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Truck", b =>
                {
                    b.Property<int>("TruckId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OperatingRegionId");

                    b.HasKey("TruckId");

                    b.HasIndex("OperatingRegionId");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Location", b =>
                {
                    b.HasOne("FuelDeliverySystem.Models.OperatingRegion", "OperatingRegion")
                        .WithMany()
                        .HasForeignKey("OperatingRegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Stop", b =>
                {
                    b.HasOne("FuelDeliverySystem.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelDeliverySystem.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Trip", b =>
                {
                    b.HasOne("FuelDeliverySystem.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FuelDeliverySystem.Models.Truck", b =>
                {
                    b.HasOne("FuelDeliverySystem.Models.OperatingRegion", "OperatingRegion")
                        .WithMany()
                        .HasForeignKey("OperatingRegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
