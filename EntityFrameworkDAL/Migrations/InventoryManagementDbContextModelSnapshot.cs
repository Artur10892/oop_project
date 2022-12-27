﻿// <auto-generated />
using System;
using EntityFrameworkDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkDAL.Migrations
{
    [DbContext(typeof(InventoryManagementDbContext))]
    partial class InventoryManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_100_CI_AS_SC_UTF8")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityFrameworkDAL.Entities.Customer", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserId")
                        .HasName("PK_Customer_User");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            UserId = 2
                        },
                        new
                        {
                            UserId = 3
                        },
                        new
                        {
                            UserId = 4
                        },
                        new
                        {
                            UserId = 5
                        },
                        new
                        {
                            UserId = 6
                        },
                        new
                        {
                            UserId = 7
                        },
                        new
                        {
                            UserId = 8
                        },
                        new
                        {
                            UserId = 9
                        },
                        new
                        {
                            UserId = 10
                        });
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.SalesOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("OrderStatusCode")
                        .HasColumnType("int");

                    b.Property<int>("ShipInfoId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShipInfoId");

                    b.ToTable("SalesOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 5,
                            ShipInfoId = 1,
                            TotalPrice = 295m,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 5,
                            ShipInfoId = 2,
                            TotalPrice = 276m,
                            WarehouseId = 3
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 4,
                            ShipInfoId = 1,
                            TotalPrice = 988m,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 5,
                            ShipInfoId = 3,
                            TotalPrice = 609m,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 3,
                            ShipInfoId = 2,
                            TotalPrice = 486m,
                            WarehouseId = 2
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 2,
                            ShipInfoId = 4,
                            TotalPrice = 1401m,
                            WarehouseId = 3
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 3,
                            ShipInfoId = 5,
                            TotalPrice = 534m,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 2,
                            ShipInfoId = 6,
                            TotalPrice = 405m,
                            WarehouseId = 3
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 1,
                            ShipInfoId = 4,
                            TotalPrice = 520m,
                            WarehouseId = 3
                        },
                        new
                        {
                            Id = 10,
                            Date = new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatusCode = 1,
                            ShipInfoId = 2,
                            TotalPrice = 316m,
                            WarehouseId = 2
                        });
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.SalesOrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int");

                    b.Property<int>("SoldQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 5,
                            SalesOrderId = 1,
                            SoldQuantity = 1
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 11,
                            SalesOrderId = 1,
                            SoldQuantity = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 9,
                            SalesOrderId = 1,
                            SoldQuantity = 2
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 2,
                            SalesOrderId = 2,
                            SoldQuantity = 3
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 12,
                            SalesOrderId = 2,
                            SoldQuantity = 6
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 11,
                            SalesOrderId = 3,
                            SoldQuantity = 2
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 8,
                            SalesOrderId = 3,
                            SoldQuantity = 6
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 5,
                            SalesOrderId = 3,
                            SoldQuantity = 2
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 6,
                            SalesOrderId = 3,
                            SoldQuantity = 3
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 1,
                            SalesOrderId = 4,
                            SoldQuantity = 4
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 8,
                            SalesOrderId = 4,
                            SoldQuantity = 7
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 4,
                            SalesOrderId = 5,
                            SoldQuantity = 6
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 5,
                            SalesOrderId = 6,
                            SoldQuantity = 4
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 2,
                            SalesOrderId = 6,
                            SoldQuantity = 1
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 7,
                            SalesOrderId = 6,
                            SoldQuantity = 11
                        },
                        new
                        {
                            Id = 16,
                            ProductId = 10,
                            SalesOrderId = 6,
                            SoldQuantity = 3
                        },
                        new
                        {
                            Id = 17,
                            ProductId = 8,
                            SalesOrderId = 7,
                            SoldQuantity = 8
                        },
                        new
                        {
                            Id = 18,
                            ProductId = 3,
                            SalesOrderId = 7,
                            SoldQuantity = 2
                        },
                        new
                        {
                            Id = 19,
                            ProductId = 4,
                            SalesOrderId = 8,
                            SoldQuantity = 5
                        },
                        new
                        {
                            Id = 20,
                            ProductId = 8,
                            SalesOrderId = 9,
                            SoldQuantity = 12
                        },
                        new
                        {
                            Id = 21,
                            ProductId = 9,
                            SalesOrderId = 9,
                            SoldQuantity = 4
                        },
                        new
                        {
                            Id = 22,
                            ProductId = 5,
                            SalesOrderId = 10,
                            SoldQuantity = 2
                        });
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.ShipInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentTypeCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserId");

                    b.ToTable("ShipInfo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerUserId = 2,
                            LocationId = 1,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerUserId = 3,
                            LocationId = 2,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerUserId = 4,
                            LocationId = 4,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 4,
                            CustomerUserId = 4,
                            LocationId = 6,
                            ShipmentTypeCode = 2
                        },
                        new
                        {
                            Id = 5,
                            CustomerUserId = 5,
                            LocationId = 8,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 6,
                            CustomerUserId = 2,
                            LocationId = 9,
                            ShipmentTypeCode = 3
                        },
                        new
                        {
                            Id = 7,
                            CustomerUserId = 6,
                            LocationId = 10,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 8,
                            CustomerUserId = 7,
                            LocationId = 12,
                            ShipmentTypeCode = 2
                        },
                        new
                        {
                            Id = 9,
                            CustomerUserId = 8,
                            LocationId = 14,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 10,
                            CustomerUserId = 9,
                            LocationId = 15,
                            ShipmentTypeCode = 1
                        },
                        new
                        {
                            Id = 11,
                            CustomerUserId = 10,
                            LocationId = 17,
                            ShipmentTypeCode = 3
                        },
                        new
                        {
                            Id = 12,
                            CustomerUserId = 7,
                            LocationId = 20,
                            ShipmentTypeCode = 1
                        });
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Віталій",
                            LastName = "Свистун"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1975, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Інокентій",
                            LastName = "Фірташ"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2000, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ярослав",
                            LastName = "Татарчук"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1901, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Йосиф",
                            LastName = "Дмитренко"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1993, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Констянтин",
                            LastName = "Шарапенко"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1984, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Олег",
                            LastName = "Притула"
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1979, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Анатолій",
                            LastName = "Назаренко"
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1993, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Микола",
                            LastName = "Вакуленко"
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(1994, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Степан",
                            LastName = "Барабаш"
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(1997, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Денис",
                            LastName = "Ярема"
                        });
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.Customer", b =>
                {
                    b.HasOne("EntityFrameworkDAL.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("EntityFrameworkDAL.Entities.Customer", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Customer_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.SalesOrder", b =>
                {
                    b.HasOne("EntityFrameworkDAL.Entities.ShipInfo", "ShipInfo")
                        .WithMany("SalesOrders")
                        .HasForeignKey("ShipInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SalesOrders_ShipInfo");

                    b.Navigation("ShipInfo");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.SalesOrderProduct", b =>
                {
                    b.HasOne("EntityFrameworkDAL.Entities.SalesOrder", "SalesOrder")
                        .WithMany("SalesOrderProducts")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_SalesOrderProducts_SalesOrder");

                    b.Navigation("SalesOrder");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.ShipInfo", b =>
                {
                    b.HasOne("EntityFrameworkDAL.Entities.Customer", "CustomerUser")
                        .WithMany("ShipInfos")
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ShipInfos_CustomerUser");

                    b.Navigation("CustomerUser");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.Customer", b =>
                {
                    b.Navigation("ShipInfos");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.SalesOrder", b =>
                {
                    b.Navigation("SalesOrderProducts");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.ShipInfo", b =>
                {
                    b.Navigation("SalesOrders");
                });

            modelBuilder.Entity("EntityFrameworkDAL.Entities.User", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}