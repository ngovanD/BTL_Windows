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

INSERT INTO TaiKhoan VALUES('Admin', '123', 0)
INSERT INTO TaiKhoan VALUES('dang', '123', 1)

CREATE TABLE NhanVien(
	ID int IDENTITY(1,1) PRIMARY KEY,
	MaNhanVien char(5) not null ,
	HoTen nvarchar(100),
	NgaySinh date,
	DiaChi nvarchar(500),
<<<<<<< HEAD
	SoDienThoai varchar(10),
	IdTK int,
	FOREIGN KEY(IdTK) REFERENCES TaiKhoan(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

INSERT INTO NhanVien VALUES('00001', N'ngo van dang', GETDATE(), N'Thái Bình', '0373559622', 2)

CREATE TABLE Luong(
	ID_Luong int IDENTITY(1,1) PRIMARY KEY,
	ID_NhanVien int,
	ThangNam date,
	SoNgayCong int,
	Thuong int,
	LuongCoBanNgay int,
	FOREIGN KEY(ID_NhanVien) REFERENCES NhanVien(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

INSERT INTO Luong VALUES(1, GETDATE(), 20, 0, 50000)
INSERT INTO Luong VALUES(1, '03-03-2021', 20, 0, 50000)

CREATE TABLE Luong(
	ID_Luong int IDENTITY(1,1) PRIMARY KEY,
	MaNhanVien int,
	ThangNam date,
	SoNgayCong int,
	Thuong int,
	LuongCoBanNgay int,
	FOREIGN KEY(MaNhanVien) REFERENCES NhanVien(ID) ON DELETE CASCADE ON UPDATE CASCADE
)


CREATE TABLE KhuyenMai(
	MaKhuyenMai int IDENTITY(1,1) PRIMARY KEY,
	Code varchar(10),
	GiaTri int,
	SoLuongCon int,
	HanSuDung Date
)

CREATE TABLE HoaDon(
	MaHoaDon varchar(14) PRIMARY KEY,
	DiaChi nvarchar(500),
	ThoiGian datetime,
	LoaiHoaDon BIT, --0: hoa don nhap 1: hoa don xuat
	TongTien int,
	ID int,
	FOREIGN KEY(ID) REFERENCES TaiKhoan(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE LoaiSanPham(
	MaLoaiSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenLoaiSanPham nvarchar(300)
)

insert into LoaiSanPham values('Ao')
insert into LoaiSanPham values('Vay')

CREATE TABLE SanPham(
	MaSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenSanPham nvarchar(300),
	DonGiaBan int,
	DonGiaNhap int,
	MoTa nvarchar(Max),
	HinhAnh varchar(100),
	MaLoaiSanPham int,
	FOREIGN KEY(MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham) ON DELETE CASCADE ON UPDATE CASCADE
)

insert into SanPham values('So mi', 100000, 800000, 'mo ta', 'h1.png', 1)
insert into SanPham values('So mi 2', 100000, 800000, 'mo ta', 'h1.png', 1)
insert into SanPham values('So mi 3', 100000, 800000, 'mo ta', 'h1.png', 1)

insert into SanPham values('dam ', 100000, 800000, 'mo ta', 'h1.png', 2)
insert into SanPham values('dam 2', 100000, 800000, 'mo ta', 'h1.png', 2)


CREATE TABLE KichThuoc(
	ID_KichThuoc int IDENTITY(1,1) PRIMARY KEY,
	Ten varchar(10)
)


CREATE TABLE ChiTietSanPham(
	MaSanPham int,
	ID_KichThuoc int,
	SoLuongCon int,
	FOREIGN KEY(MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(ID_KichThuoc) REFERENCES KichThuoc(ID_KichThuoc) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(MaSanPham, ID_KichThuoc)
)


CREATE TABLE DongHoaDon(
	MaSanPham int,
	ID_KichThuoc int,
	MaHoaDon varchar(14),
	SoLuong int,
	FOREIGN KEY(MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(ID_KichThuoc) REFERENCES KichThuoc(ID_KichThuoc) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(MaSanPham, ID_KichThuoc, MaHoaDon)
)