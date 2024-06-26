﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotoBikeShop.Data;

#nullable disable

namespace MotoBikeShop.Migrations
{
    [DbContext(typeof(motoBikeVHDbContext))]
    [Migration("20240328131900_updatehoadon")]
    partial class updatehoadon
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MotoBikeShop.Data.ChiTietHd", b =>
                {
                    b.Property<int>("MaCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCT"));

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<double>("GiamGia")
                        .HasColumnType("float");

                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int>("MaHH")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaCT");

                    b.HasIndex("MaHD");

                    b.HasIndex("MaHH");

                    b.ToTable("ChiTietHds");
                });

            modelBuilder.Entity("MotoBikeShop.Data.HangHoa", b =>
                {
                    b.Property<int>("MaHH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHH"));

                    b.Property<double?>("DonGia")
                        .HasColumnType("float");

                    b.Property<double>("GiamGia")
                        .HasColumnType("float");

                    b.Property<string>("Hinh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MaNCC")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTaDonVi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgaySX")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLanXem")
                        .HasColumnType("int");

                    b.Property<string>("TenAlias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenHH")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaHH");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaNCC");

                    b.ToTable("HangHoas");

                    b.HasData(
                        new
                        {
                            MaHH = 1,
                            DonGia = 400000.0,
                            GiamGia = 9999999.0,
                            Hinh = "xecon.png",
                            MaLoai = 1,
                            MaNCC = "NCC002",
                            MoTa = "xe này cực đẹp",
                            MoTaDonVi = "VND",
                            NgaySX = new DateTime(2024, 3, 28, 20, 18, 59, 885, DateTimeKind.Local).AddTicks(6465),
                            SoLanXem = 99,
                            TenAlias = "exciter",
                            TenHH = "Exciter"
                        },
                        new
                        {
                            MaHH = 2,
                            DonGia = 300000.0,
                            GiamGia = 9999999.0,
                            Hinh = "xega.png",
                            MaLoai = 2,
                            MaNCC = "NCC001",
                            MoTa = "xe này cực đẹp",
                            MoTaDonVi = "VND",
                            NgaySX = new DateTime(2024, 3, 28, 20, 18, 59, 885, DateTimeKind.Local).AddTicks(6482),
                            SoLanXem = 99,
                            TenAlias = "vario",
                            TenHH = "Vario"
                        },
                        new
                        {
                            MaHH = 3,
                            DonGia = 100000.0,
                            GiamGia = 9999999.0,
                            Hinh = "xeso.png",
                            MaLoai = 3,
                            MaNCC = "NCC003",
                            MoTa = "xe này cực đẹp",
                            MoTaDonVi = "VND",
                            NgaySX = new DateTime(2024, 3, 28, 20, 18, 59, 885, DateTimeKind.Local).AddTicks(6483),
                            SoLanXem = 99,
                            TenAlias = "wave-rsx",
                            TenHH = "Wave RSX"
                        });
                });

            modelBuilder.Entity("MotoBikeShop.Data.HoaDon", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHD"));

                    b.Property<string>("CachThanhToan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CachVanChuyen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaTrangThai")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<double>("PhiVanChuyen")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThaiMaTrangThai")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaHD");

                    b.HasIndex("TrangThaiMaTrangThai");

                    b.HasIndex("UserId");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("MotoBikeShop.Data.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<string>("Hinh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenLoaiAlias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loais");

                    b.HasData(
                        new
                        {
                            MaLoai = 1,
                            Hinh = "xecon.png",
                            MoTa = "Xe này để đua ",
                            TenLoai = "Xe Côn",
                            TenLoaiAlias = "xe-con"
                        },
                        new
                        {
                            MaLoai = 2,
                            Hinh = "xega.png",
                            MoTa = "Xe này để tán gái",
                            TenLoai = "Xe ga",
                            TenLoaiAlias = "xe-ga"
                        },
                        new
                        {
                            MaLoai = 3,
                            Hinh = "xeso.png",
                            MoTa = "Xe này để đi làm",
                            TenLoai = "Xe số",
                            TenLoaiAlias = "xe-so"
                        });
                });

            modelBuilder.Entity("MotoBikeShop.Data.NhaCungCap", b =>
                {
                    b.Property<string>("MaNCC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiLienLac")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenCongTy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaNCC");

                    b.ToTable("NhaCungCaps");

                    b.HasData(
                        new
                        {
                            MaNCC = "NCC001",
                            DiaChi = "Địa chỉ ABC",
                            DienThoai = "123456789",
                            Email = "info@gmail.com",
                            Logo = "logo1.png",
                            MoTa = "nhà cung cấp vip1",
                            NguoiLienLac = "Người liên hệ ABC",
                            TenCongTy = "Công ty ABC"
                        },
                        new
                        {
                            MaNCC = "NCC002",
                            DiaChi = "Địa chỉ XYZ",
                            DienThoai = "987654321",
                            Email = "info@gmail.com",
                            Logo = "logo2.png",
                            MoTa = "nhà cung cấp vip2",
                            NguoiLienLac = "Người liên hệ XYZ",
                            TenCongTy = "Công ty XYZ"
                        },
                        new
                        {
                            MaNCC = "NCC003",
                            DiaChi = "Địa chỉ DEF",
                            DienThoai = "555555555",
                            Email = "info@gmail.com",
                            Logo = "logo3.png",
                            MoTa = "nhà cung cấp vip3",
                            NguoiLienLac = "Người liên hệ DEF",
                            TenCongTy = "Công ty DEF"
                        });
                });

            modelBuilder.Entity("MotoBikeShop.Data.YeuThich", b =>
                {
                    b.Property<int>("MaYT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaYT"));

                    b.Property<int?>("MaHH")
                        .HasColumnType("int");

                    b.Property<string>("MaKH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("NgayChon")
                        .HasColumnType("datetime2");

                    b.HasKey("MaYT");

                    b.HasIndex("MaHH");

                    b.ToTable("YeuThiches");
                });

            modelBuilder.Entity("MotoBikeShop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MotoBikeShop.Models.TrangThai", b =>
                {
                    b.Property<int>("MaTrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTrangThai"));

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTrangThai");

                    b.ToTable("TrangThais");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MotoBikeShop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MotoBikeShop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoBikeShop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MotoBikeShop.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MotoBikeShop.Data.ChiTietHd", b =>
                {
                    b.HasOne("MotoBikeShop.Data.HoaDon", "HoaDon")
                        .WithMany("ChiTietHds")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoBikeShop.Data.HangHoa", "HangHoa")
                        .WithMany("ChiTietHds")
                        .HasForeignKey("MaHH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HangHoa");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("MotoBikeShop.Data.HangHoa", b =>
                {
                    b.HasOne("MotoBikeShop.Data.Loai", "MaLoaiNavigation")
                        .WithMany("HangHoas")
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoBikeShop.Data.NhaCungCap", "MaNccNavigation")
                        .WithMany()
                        .HasForeignKey("MaNCC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaLoaiNavigation");

                    b.Navigation("MaNccNavigation");
                });

            modelBuilder.Entity("MotoBikeShop.Data.HoaDon", b =>
                {
                    b.HasOne("MotoBikeShop.Models.TrangThai", null)
                        .WithMany("HoaDons")
                        .HasForeignKey("TrangThaiMaTrangThai");

                    b.HasOne("MotoBikeShop.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MotoBikeShop.Data.YeuThich", b =>
                {
                    b.HasOne("MotoBikeShop.Data.HangHoa", "HangHoa")
                        .WithMany("YeuThiches")
                        .HasForeignKey("MaHH");

                    b.Navigation("HangHoa");
                });

            modelBuilder.Entity("MotoBikeShop.Data.HangHoa", b =>
                {
                    b.Navigation("ChiTietHds");

                    b.Navigation("YeuThiches");
                });

            modelBuilder.Entity("MotoBikeShop.Data.HoaDon", b =>
                {
                    b.Navigation("ChiTietHds");
                });

            modelBuilder.Entity("MotoBikeShop.Data.Loai", b =>
                {
                    b.Navigation("HangHoas");
                });

            modelBuilder.Entity("MotoBikeShop.Models.TrangThai", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
