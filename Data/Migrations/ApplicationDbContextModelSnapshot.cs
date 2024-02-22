﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrdersAPI.Insfractucture.Context;

#nullable disable

namespace OrdersAPI.Insfractucture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Entities.Centers.CentersCosts", b =>
                {
                    b.Property<string>("LogisticCenter")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("LogisticCenter");

                    b.ToTable("CentersCosts");
                });

            modelBuilder.Entity("Models.Entities.Centers.Regions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameRegion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Models.Entities.Centers.Segments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameSegment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("Models.Entities.Centers.Sites", b =>
                {
                    b.Property<string>("LogisticCenter")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCenterCost")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("IdRegion")
                        .HasColumnType("int");

                    b.Property<int>("IdSegment")
                        .HasColumnType("int");

                    b.Property<int>("IdTown")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("LogisticCenter");

                    b.HasIndex("IdCenterCost");

                    b.HasIndex("IdRegion");

                    b.HasIndex("IdSegment");

                    b.HasIndex("IdTown");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Models.Entities.Location.States", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameState")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Models.Entities.Location.Towns", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("NameTown")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdState");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Models.Entities.Movements.PurchaseOrderDetails", b =>
                {
                    b.Property<int>("DetalleOCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleOCId"));

                    b.Property<string>("IdItem")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("IdPackaging")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("IdPurchaseOrder")
                        .HasColumnType("int");

                    b.HasKey("DetalleOCId");

                    b.HasIndex("IdPurchaseOrder");

                    b.HasIndex("IdItem", "IdPackaging");

                    b.ToTable("PurchaseOrdersDetails");
                });

            modelBuilder.Entity("Models.Entities.Movements.PurchaseOrders", b =>
                {
                    b.Property<int>("PurchaseOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseOrder"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogisticCenter")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("MovementType")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SupplierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("PurchaseOrder");

                    b.HasIndex("LogisticCenter");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("Models.Entities.Products.Brands", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Models.Entities.Products.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Models.Entities.Products.Generics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UMA")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("Generics");
                });

            modelBuilder.Entity("Models.Entities.Products.Items", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<bool>("Active")
                        .HasMaxLength(2)
                        .HasColumnType("bit");

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ConversionFactor")
                        .HasColumnType("float");

                    b.Property<int>("GenericId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Rounding")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("GenericId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Models.Entities.Products.Packaging", b =>
                {
                    b.Property<string>("PresentacionId")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("IdItem")
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresentacionId", "IdItem");

                    b.HasIndex("IdItem");

                    b.ToTable("Packaging");
                });

            modelBuilder.Entity("Models.Entities.Stocks.Stock", b =>
                {
                    b.Property<string>("LogisticCenter")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("IdProduct")
                        .HasColumnType("nvarchar(7)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("LogisticCenter", "IdProduct");

                    b.HasIndex("IdProduct");

                    b.ToTable("Stocs");
                });

            modelBuilder.Entity("Models.Entities.Vendor.Suppliers", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("IdTown")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdTown");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Models.Entities.Centers.Sites", b =>
                {
                    b.HasOne("Models.Entities.Centers.CentersCosts", "CentersCost")
                        .WithMany("Sites")
                        .HasForeignKey("IdCenterCost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Centers.Regions", "Region")
                        .WithMany("Sites")
                        .HasForeignKey("IdRegion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Centers.Segments", "Segment")
                        .WithMany("Sites")
                        .HasForeignKey("IdSegment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Location.Towns", "Town")
                        .WithMany("Sites")
                        .HasForeignKey("IdTown")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentersCost");

                    b.Navigation("Region");

                    b.Navigation("Segment");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Models.Entities.Location.Towns", b =>
                {
                    b.HasOne("Models.Entities.Location.States", "State")
                        .WithMany("Towns")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Models.Entities.Movements.PurchaseOrderDetails", b =>
                {
                    b.HasOne("Models.Entities.Movements.PurchaseOrders", "PurchaseOrders")
                        .WithMany("Details")
                        .HasForeignKey("IdPurchaseOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Products.Packaging", "Packaging")
                        .WithMany()
                        .HasForeignKey("IdItem", "IdPackaging")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Packaging");

                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("Models.Entities.Movements.PurchaseOrders", b =>
                {
                    b.HasOne("Models.Entities.Centers.Sites", "Site")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("LogisticCenter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Vendor.Suppliers", "Supplier")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Models.Entities.Products.Generics", b =>
                {
                    b.HasOne("Models.Entities.Products.Categories", "Category")
                        .WithMany("Generics")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Models.Entities.Products.Items", b =>
                {
                    b.HasOne("Models.Entities.Products.Brands", "Brand")
                        .WithMany("Items")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Products.Generics", "Generic")
                        .WithMany("Items")
                        .HasForeignKey("GenericId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Generic");
                });

            modelBuilder.Entity("Models.Entities.Products.Packaging", b =>
                {
                    b.HasOne("Models.Entities.Products.Items", "Item")
                        .WithMany("Packaging")
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Models.Entities.Stocks.Stock", b =>
                {
                    b.HasOne("Models.Entities.Products.Items", "Item")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Centers.Sites", "Sitio")
                        .WithMany()
                        .HasForeignKey("LogisticCenter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Sitio");
                });

            modelBuilder.Entity("Models.Entities.Vendor.Suppliers", b =>
                {
                    b.HasOne("Models.Entities.Location.Towns", "Town")
                        .WithMany("Suppliers")
                        .HasForeignKey("IdTown")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Models.Entities.Centers.CentersCosts", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("Models.Entities.Centers.Regions", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("Models.Entities.Centers.Segments", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("Models.Entities.Centers.Sites", b =>
                {
                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("Models.Entities.Location.States", b =>
                {
                    b.Navigation("Towns");
                });

            modelBuilder.Entity("Models.Entities.Location.Towns", b =>
                {
                    b.Navigation("Sites");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("Models.Entities.Movements.PurchaseOrders", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Models.Entities.Products.Brands", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Models.Entities.Products.Categories", b =>
                {
                    b.Navigation("Generics");
                });

            modelBuilder.Entity("Models.Entities.Products.Generics", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Models.Entities.Products.Items", b =>
                {
                    b.Navigation("Packaging");
                });

            modelBuilder.Entity("Models.Entities.Vendor.Suppliers", b =>
                {
                    b.Navigation("PurchaseOrders");
                });
#pragma warning restore 612, 618
        }
    }
}