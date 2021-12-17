CREATE DATABASE QLBANQUANAO
GO

USE QLBANQUANAO
GO

CREATE TABLE TaiKhoan(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenDangNhap varchar(100),
	MatKhau varchar(100),
	LoaiTaiKhoan BIT, --0: admin 1: nhan vien
)

CREATE TABLE NhanVien(
	MaNhanVien int IDENTITY(1,1) PRIMARY KEY,
	HoTen nvarchar(100),
	DiaChi nvarchar(500),
	SDT char(10),
	NgayCong int,
	Luong1Ngay int,
	Thuong int,
	ID int,
	FOREIGN KEY(ID) REFERENCES TaiKhoan(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE KhuyenMai(
	MaKhuyenMai int IDENTITY(1,1) PRIMARY KEY,
	Code varchar(10),
	GiaTri int,
	SoLuongCon int,
	HanSuDung Date
)

CREATE TABLE HoaDon(
	MaHoaDon int IDENTITY(1,1) PRIMARY KEY,
	DiaChi nvarchar(500),
	ThoiGian datetime,
	LoaiHoaDon BIT, --0: hoa don nhap 1: hoa don xuat
	ID int,
	FOREIGN KEY(ID) REFERENCES TaiKhoan(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE LoaiSanPham(
	MaLoaiSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenLoaiSanPham nvarchar(300)
)

CREATE TABLE SanPham(
	MaSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenSanPham nvarchar(300),
	GiaNhap int,
	GiaXuat int,
	SoLuongCon int,
	MoTa nvarchar(Max),
	MaLoaiSanPham int,
	FOREIGN KEY(MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE DongHoaDon(
	MaSanPham int,
	MaHoaDon int,
	SoLuong int,
	FOREIGN KEY(MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(MaSanPham, MaHoaDon)
)