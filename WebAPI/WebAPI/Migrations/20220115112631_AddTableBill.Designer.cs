﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI;

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220115112631_AddTableBill")]
    partial class AddTableBill
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.CChiTietSanPham", b =>
                {
                    b.Property<string>("MaCTSP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("GioTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTaSP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SL")
                        .HasColumnType("int");

                    b.Property<string>("SanPhamMaSP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCTSP");

                    b.HasIndex("SanPhamMaSP");

                    b.ToTable("ChiTietSanPhams");

                    b.HasData(
                        new
                        {
                            MaCTSP = "CTSP_01",
                            Anh = "",
                            Color = "Trắng, Xanh, Vàng",
                            DonGia = 30.0,
                            GioTinh = "Nam",
                            MoTaSP = "",
                            SL = 10,
                            SanPhamMaSP = "SP_1",
                            Size = "M,X,XL"
                        },
                        new
                        {
                            MaCTSP = "CTSP_02",
                            Anh = "",
                            Color = "Đen, Xanh",
                            DonGia = 30.0,
                            GioTinh = "Nam",
                            MoTaSP = "",
                            SL = 10,
                            SanPhamMaSP = "SP_2",
                            Size = "M,X"
                        },
                        new
                        {
                            MaCTSP = "CTSP_03",
                            Anh = "",
                            Color = "Xám, Đen, Vàng, Lục",
                            DonGia = 30.0,
                            GioTinh = "Nữ",
                            MoTaSP = "",
                            SL = 10,
                            SanPhamMaSP = "SP_3",
                            Size = "S,M"
                        },
                        new
                        {
                            MaCTSP = "CTSP_04",
                            Anh = "",
                            Color = "Trắng, Đen, Đỏ, Xanh",
                            DonGia = 30.0,
                            GioTinh = "UniSex",
                            MoTaSP = "",
                            SL = 10,
                            SanPhamMaSP = "SP_4",
                            Size = "S,M,X"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.CHoaDon", b =>
                {
                    b.Property<string>("MaHD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Delete_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhachHangMaKH")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.Property<DateTime>("Update_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("MaHD");

                    b.HasIndex("KhachHangMaKH");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("WebAPI.Models.CKhachHang", b =>
                {
                    b.Property<string>("MaKH")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenKH")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKH");

                    b.ToTable("KhachHangs");

                    b.HasData(
                        new
                        {
                            MaKH = "Admin_1",
                            Avatar = "",
                            DiaChi = "CKC",
                            Email = "0306181281@CaoThang.edu.vn",
                            Pass = "81PT",
                            SDT = "0306181281",
                            Status = true,
                            TenKH = "Toàn"
                        },
                        new
                        {
                            MaKH = "Admin_2",
                            Avatar = "",
                            DiaChi = "CKC",
                            Email = "0306181363@CaoThang.edu.vn",
                            Pass = "63MT",
                            SDT = "0306181363",
                            Status = true,
                            TenKH = "Thành"
                        },
                        new
                        {
                            MaKH = "Admin_3",
                            Avatar = "",
                            DiaChi = "CKC",
                            Email = "0306181209@CaoThang.edu.vn",
                            Pass = "09ND",
                            SDT = "0306181209",
                            Status = true,
                            TenKH = "Duyên"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.CSanPham", b =>
                {
                    b.Property<string>("MaSp")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Delete_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoaiSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenSP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("MaSp");

                    b.ToTable("SanPhams");

                    b.HasData(
                        new
                        {
                            MaSp = "SP_1",
                            Delete_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified),
                            LoaiSanPham = "Áo",
                            Status = true,
                            TenSP = "Áo thun đi biển",
                            Update_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaSp = "SP_2",
                            Delete_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified),
                            LoaiSanPham = "quần",
                            Status = true,
                            TenSP = "quần bơi",
                            Update_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaSp = "SP_3",
                            Delete_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified),
                            LoaiSanPham = "Áo",
                            Status = true,
                            TenSP = "Áo thun tay dài",
                            Update_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MaSp = "SP_4",
                            Delete_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified),
                            LoaiSanPham = "Áo",
                            Status = true,
                            TenSP = "Áo thun tay ngắn",
                            Update_Date = new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebAPI.Models.CChiTietSanPham", b =>
                {
                    b.HasOne("WebAPI.Models.CSanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamMaSP");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebAPI.Models.CHoaDon", b =>
                {
                    b.HasOne("WebAPI.Models.CKhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("KhachHangMaKH");

                    b.Navigation("KhachHang");
                });
#pragma warning restore 612, 618
        }
    }
}
