﻿// <auto-generated />
using System;
using DManage.SystemManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DManage.SystemManagement.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SystemManagementDbContext))]
    partial class SystemManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.LicensePlateNumber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("LicensePlateNumber");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.Pallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("LicensePlateNumberId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("ProductTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlateNumberId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Pallet");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.ProductType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NodeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("WareHouse");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.WareHouseNodeMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WareHouseNodeMapping");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.WareHouseProductTypeMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ProductTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdationUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("WareHouseProductTypeMapping");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.LicensePlateNumber", b =>
                {
                    b.HasOne("DManage.SystemManagement.Domain.Entities.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.Pallet", b =>
                {
                    b.HasOne("DManage.SystemManagement.Domain.Entities.LicensePlateNumber", "LicensePlateNumber")
                        .WithMany()
                        .HasForeignKey("LicensePlateNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DManage.SystemManagement.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicensePlateNumber");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.WareHouseNodeMapping", b =>
                {
                    b.HasOne("DManage.SystemManagement.Domain.Entities.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DManage.SystemManagement.Domain.Entities.WareHouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DManage.SystemManagement.Domain.Entities.WareHouseProductTypeMapping", b =>
                {
                    b.HasOne("DManage.SystemManagement.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DManage.SystemManagement.Domain.Entities.WareHouse", "WareHouse")
                        .WithMany()
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("WareHouse");
                });
#pragma warning restore 612, 618
        }
    }
}
