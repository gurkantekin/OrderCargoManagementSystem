﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OCMS.Data.Access;

namespace OCMS.Data.Access.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220517143954_initial")]
    partial class İnitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OCMS.Data.Access.Entity.CancellationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<string>("Descipriton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastModifierUserId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CancellationRequest", "dbo");
                });

            modelBuilder.Entity("OCMS.Data.Access.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<int>("ProductCode")
                        .HasColumnType("int");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("ShippingFeeAmount")
                        .HasColumnType("float");

                    b.Property<int>("ShippingProviderId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<double>("SubTotalWithDiscount")
                        .HasColumnType("float");

                    b.Property<double>("TaxAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Order", "dbo");
                });

            modelBuilder.Entity("OCMS.Data.Access.Entity.Product", b =>
                {
                    b.Property<string>("ProductCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCode");

                    b.ToTable("Product", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
