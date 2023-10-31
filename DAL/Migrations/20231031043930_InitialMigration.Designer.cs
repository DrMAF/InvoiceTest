﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20231031043930_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.AuthenticationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("AuthenticationTokens");
                });

            modelBuilder.Entity("Core.Domain.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Net")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal?>("TaxPercent")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal?>("TotalDiscount")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Core.Domain.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Net")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4467),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "تليفزيون",
                            NameEn = "TV"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4469),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "محمول",
                            NameEn = "Mobile"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4471),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "جهاز حاسب",
                            NameEn = "Labtop"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4473),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "سلك شبكات",
                            NameEn = "Network wire"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4475),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "مسمار",
                            NameEn = "Nail"
                        });
                });

            modelBuilder.Entity("Core.Domain.ProductUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitId");

                    b.ToTable("ProductUnits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4498),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 12000m,
                            ProductId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4503),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 8000m,
                            ProductId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4506),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 25000m,
                            ProductId = 3,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4508),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 1200m,
                            ProductId = 4,
                            UnitId = 3
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4510),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 15m,
                            ProductId = 4,
                            UnitId = 4
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4512),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 1m,
                            ProductId = 5,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4514),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "",
                            NameEn = "",
                            Price = 90m,
                            ProductId = 5,
                            UnitId = 2
                        });
                });

            modelBuilder.Entity("Core.Domain.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4419),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            Location = "Nasr city",
                            NameAr = "المركز الرئيسى",
                            NameEn = "Headquarter"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4425),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            Location = "Giza",
                            NameAr = "الفرع الأول",
                            NameEn = "First extension"
                        });
                });

            modelBuilder.Entity("Core.Domain.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4443),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "وحدة",
                            NameEn = "Item"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4446),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "كيلو",
                            NameEn = "Kilo"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4448),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "عبوة",
                            NameEn = "Bag"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4450),
                            CreatorId = 1,
                            Description = "",
                            IsDeleted = false,
                            NameAr = "متر",
                            NameEn = "Meter"
                        });
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SaltKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            CreatedAt = new DateTime(2023, 10, 31, 6, 39, 30, 580, DateTimeKind.Local).AddTicks(4217),
                            CreatorId = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@mail.com",
                            FirstName = "Admin",
                            IsDeleted = false,
                            LastName = "admin",
                            Password = "",
                            Phone = "1234",
                            SaltKey = "",
                            SecondName = "",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Core.Domain.AuthenticationToken", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Core.Domain.Invoice", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Core.Domain.InvoiceItem", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Core.Domain.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.ProductUnit", "ProductUnit")
                        .WithMany()
                        .HasForeignKey("ProductUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Invoice");

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Core.Domain.ProductUnit", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Core.Domain.Product", "Product")
                        .WithMany("ProductUnits")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Product");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Core.Domain.Store", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Core.Domain.Unit", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.HasOne("Core.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Core.Domain.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("Core.Domain.Product", b =>
                {
                    b.Navigation("ProductUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
