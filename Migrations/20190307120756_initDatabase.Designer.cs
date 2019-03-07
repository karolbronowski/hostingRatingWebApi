﻿// <auto-generated />
using hostingRatingWebApi.Database;
using hostingRatingWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace hostingRatingWebApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190307120756_initDatabase")]
    partial class initDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("hostingRatingWebApi.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatorId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("hostingRatingWebApi.Models.BrandPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountCapacity");

                    b.Property<Guid>("BrandId");

                    b.Property<string>("Databases");

                    b.Property<string>("Domains");

                    b.Property<string>("EmailAccount");

                    b.Property<string>("FtpAccounts");

                    b.Property<string>("MonthlyTransfer");

                    b.Property<string>("PackageName");

                    b.Property<decimal>("PriceForNextYear");

                    b.Property<decimal>("PriceForYear");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("BrandPackages");
                });

            modelBuilder.Entity("hostingRatingWebApi.Models.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BrandPackageId");

                    b.Property<int>("Points");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BrandPackageId");

                    b.HasIndex("UserId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("hostingRatingWebApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("hostingRatingWebApi.Models.Brand", b =>
                {
                    b.HasOne("hostingRatingWebApi.Models.User", "Creator")
                        .WithMany("AddedBrands")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("hostingRatingWebApi.Models.BrandPackage", b =>
                {
                    b.HasOne("hostingRatingWebApi.Models.Brand", "Brand")
                        .WithMany("BrandPackages")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("hostingRatingWebApi.Models.Rate", b =>
                {
                    b.HasOne("hostingRatingWebApi.Models.BrandPackage", "BrandPackage")
                        .WithMany("Rates")
                        .HasForeignKey("BrandPackageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("hostingRatingWebApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}