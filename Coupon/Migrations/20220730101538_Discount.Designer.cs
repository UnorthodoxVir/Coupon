﻿// <auto-generated />
using System;
using Coupon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coupon.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220730101538_Discount")]
    partial class Discount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coupon.Models.CompCoupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompId");

                    b.ToTable("CompCoupons");
                });

            modelBuilder.Entity("Coupon.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("CrNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Coupon.Models.CouponCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CouponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CouponCards");
                });

            modelBuilder.Entity("Coupon.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vehicle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Coupon.Models.CompCoupon", b =>
                {
                    b.HasOne("Coupon.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Coupon.Models.CouponCard", b =>
                {
                    b.HasOne("Coupon.Models.CompCoupon", "CompCoupon")
                        .WithMany()
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coupon.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("CompCoupon");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
