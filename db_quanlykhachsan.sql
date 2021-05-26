USE MASTER
GO

IF(EXISTS(SELECT * FROM SYSDATABASES WHERE NAME='QuanLyKhachSan'))
	DROP DATABASE QuanLyKhachSan
GO

CREATE DATABASE QuanLyKhachSan
GO

USE QuanLyKhachSan
GO

--bảng nhân viên
create table NhanVien(
	MaNhanVien INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TenNhanVien nvarchar(50) not null,
	SoDienThoai char(10),
	NgaySinh date not null,
	DiaChiNhanVien nvarchar(50),
	GioiTinhNV bit not null, --0: NAM, 1: NỮ
	ChucVu nvarchar(50) not null
)
go

--bảng chấm công
create table ChamCong(
	MaNhanVien int not null,
	NgayChamCong date default(getdate()) not null,
	TrangThai bit not null,	
	constraint PK_Chamcong primary key (MaNhanVien, NgayChamCong),
	foreign key (MaNhanVien) references NhanVien(MaNhanVien) ON UPDATE CASCADE ON DELETE CASCADE
)

--bảng tài khoản
create table Taikhoan(
	ID nvarchar(50) primary key not null,
	PASS nvarchar(50) not null,
	LoaiTaiKhoan bit not null, --0: quản lý, 1:admin
	MaNhanVien INT NOT NULL,
	FOREIGN KEY (MaNhanVien) references NhanVien(MaNhanVien) ON UPDATE CASCADE ON DELETE CASCADE
)
go

--bảng loại phòng
create table LoaiPhong(
	MaLoaiPhong INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TenLoaiPhong nvarchar(50) not null,
	SoluongNguoi int not null,
	GiaPhong int not null
)
go

--bảng phòng
create table Phong(
	MaPhong INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	MaLoaiPhong int not null,
	TrangThaiPhong int not null, --0: đầy, 1: còn
	foreign key (MaLoaiPhong) references LoaiPhong(MaLoaiPhong) ON UPDATE CASCADE ON DELETE CASCADE
)
go

--bảng khách hàng
create table KhachHang(
	MaKhachHang INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TenKhachHang nvarchar(50) not null,
	SDT int,
    Tuoi int not null,
	Email varchar(30),
	GioiTinh nvarchar(10) not null, --0: Nam, 1: Nữ
	DiaChiKhachHang nvarchar(50),
	CMND char(12) not null,
	TrangThai bit not null --0: người xấu, 1: người tốt
)
go

--bảng đặt phòng
create table DatPhong(
	MaDatPhong INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	MaNhanVien int not null,
	MaKhachHang int not null,
	MaLoaiPhong int not null,
	NgayDat date not null,
	NgayDen date not null,
	NgayDi date not null,
	TienDatCoc int not null,
	SoLuongPhong int not null,
	TrangThaiDatPhong int not null,
	foreign key (MaLoaiPhong) references LoaiPhong(MaLoaiPhong),
	foreign key (MaNhanVien) references NhanVien(MaNhanVien),
	foreign key (MaKhachHang) references KhachHang(MaKhachHang)
)
go

--bảng chi tiết phòng đặt
create table ChiTietPhongDat(
	MaDatPhong int,
	MaPhong int,
	constraint PK_CTPD primary key (MaDatPhong, MaPhong),
	foreign key (MaPhong) references Phong(MaPhong) ON UPDATE CASCADE ON DELETE CASCADE,
	foreign key (MaDatPhong) references DatPhong(MaDatPhong) ON UPDATE CASCADE ON DELETE CASCADE
)
go

--bảng hóa đơn
create table HoaDon(
	MaHoaDon INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	MaDatPhong int,
	NgayLap date default(getdate()),
	TongTien int not null,
	foreign key (MaDatPhong) references DatPhong(MaDatPhong) ON UPDATE CASCADE ON DELETE CASCADE
)	
go

--thêm dữ liệu nhân viên
INSERT INTO NhanVien(TenNhanVien, SoDienThoai, Ngaysinh, DiaChiNhanVien, GioiTinhNV, ChucVu) VALUES
(N'Quách Ngọc Hà', '0389149961', '04/05/2000', N'Hà Nội', 0, N'Admin'),
(N'Phạm Anh Dương', '0969055609', '05/06/2000', N'Hà Nội', 0, N'Quản lý'),
(N'Nguyễn Tiến Hà', '0936890916', '04/03/2000', N'Hà Nội', 0, N'Quản lý')
GO

INSERT INTO ChamCong(MaNhanVien, TrangThai) VALUES
(2, 1),
(3, 0)
GO

INSERT INTO Taikhoan(ID, PASS, LoaiTaiKhoan, MaNhanVien) VALUES
('admin', 1, 0, 1),
('nv1', 1, 1, 2),
('nv2', 1, 1, 3)
GO

INSERT INTO LoaiPhong(TenLoaiPhong, SoLuongNguoi, GiaPhong) VALUES
(N'Hạng nhất', 15, 7000000),
(N'Hạng thương gia', 10, 5000000),
(N'Hạng phổ thông đặc biệt', 6, 3000000),
(N'Hạng phổ thông', 4, 2500000)
GO

INSERT INTO Phong(MaLoaiPhong, TrangThaiPhong) VALUES
(1, 0),
(2, 1),
(3, 1),
(4, 0),
(3, 0),
(2, 0),
(4, 1),
(1, 1)
GO

INSERT INTO KhachHang(TenKhachHang, SDT, Tuoi, Email, Gioitinh, DiaChiKhachHang, CMND, TrangThai) VALUES --0: người xấu, 1: người tốt
(N'Phạm Duy Hưng', '0327106865', 20, 'phamhung@gmail.com', 0, N'Hà Nội', '001278910103', 1),
(N'Đỗ Bá Hoàn', '0354732260', 21, 'bahoan@gmail.com', 0, N'Hà Nội', '001356711103', 1),
(N'Lê Vũ Long', '0328026493', 21, 'vulong@gmail.com', 0, N'Phú Thọ', '001456712103', 0),
(N'Ngô Ngọc Ánh', '0347658636', 21, 'ngocanh@gmail.com', 1, N'Đà Nẵng', '001374910103', 0),
(N'Đào Thu Phương', '0583509498', 20, 'thuphuong@gmail.com', 1, N'Hải Dương', '001255510103', 0)
GO

INSERT INTO DatPhong(MaNhanVien, MaKhachHang, MaLoaiPhong, NgayDat, NgayDen, NgayDi, TienDatCoc, SoLuongPhong, TrangThaiDatPhong) VALUES
(1, 1, 2,'02/03/2021', '04/03/2021', '10/03/2021', 700000, 3, 1),
(2, 3, 1,'06/05/2021', '08/05/2021', '11/05/2021', 1500000, 2, 1)
GO

INSERT INTO ChiTietPhongDat(MaDatPhong, MaPhong) VALUES
(1, 2),
(2, 3)
GO

INSERT INTO HoaDon(MaDatPhong, TongTien) VALUES
(1, 104300000),
(2, 54500000)
GO

--hiển thị thông tin các bảng
SELECT * FROM NhanVien
SELECT * FROM ChamCong
SELECT * FROM Taikhoan
SELECT * FROM LoaiPhong
SELECT * FROM Phong
SELECT * FROM KhachHang
SELECT * FROM DatPhong
SELECT * FROM ChiTietPhongDat
SELECT * FROM HoaDon

SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, DiaChiNhanVien,
CASE
	WHEN GioiTinhNV = 0 THEN N'Nam'
	ELSE N'Nữ'
END AS GioiTinhNV, ChucVu
FROM NhanVien