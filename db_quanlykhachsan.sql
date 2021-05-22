use master

go

create database QLKS
go

use QLKS
go


create table ChucVu(
	MaCV int identity primary key not null,
	TenCV nvarchar(50)
)

go


create table NhanVien(
	MaNhanVien int identity primary key not null,
	MaCV int,
	Hoten nvarchar(50) ,
	Sdt char(12),
	Ngaysinh date,
	Diachi nvarchar(50),
	CMND nchar(20),
	GioiTinh nvarchar(50)
	constraint fk_nhanvien foreign key (MaCV) references ChucVu(MaCV)
)

go

create table ChamCong(
	MaNhanVien int not null ,
	Ngay date not null,
	TrangThai bit,	constraint PK_Chamcong primary key (MaNhanVien, Ngay),
	constraint Fk_Chamcong foreign key (MaNhanVien) references NhanVien(MaNhanVien)
)

create table Taikhoan(
	Username nvarchar(50) primary key not null,
	Password nvarchar(50) ,
	Quantri bit,
	MaNhanVien int,
	constraint Fk_TaiKhoan foreign key (MaNhanVien) references NhanVien(MaNhanVien)
)
go

create table LoaiPhong(
	TenLoaiPhong nchar(20) primary key not null,
	Soluong int,
	GiaPhong int
)
go

create table Phong(
	MaPhong int identity not null,
	TenLoaiPhong nchar(20),
	TrangThai int,
	constraint PK_Phong primary key (MaPhong),
	constraint FK_Phong foreign key (TenLoaiPhong) references LoaiPhong(TenLoaiPhong),
)
go

create table KhachHang(
	MaKH int identity primary key not null,
	Hoten nvarchar(50),
	SDT int,
    Tuoi int,
	Email varchar(30),
	Gioitinh nvarchar(10),
	DiaChi nvarchar(50),
	TrangThai bit
)
go

create table DatPhong(
	MaDatPhong int identity not null,
	MaNhanVien int,
	MaKH int,
	NgayDat date,
	NgayDen date,
	NgayDi date,
	TienDatCoc int,
	SoLuong int,
	TrangThai int
	constraint pk_Datphong primary key (MaDatPhong),
	constraint fk_datphong foreign key (MaNhanVien) references NhanVien(MaNhanVien),
	constraint fk_datphong1 foreign key (MaKH) references KhachHang(MaKH),
)
go

create table ChiTietPhongDat(
	MaDatPhong int,
	MaPhong int,
	constraint PK_CTPD primary key (MaDatPhong, MaPhong),
	constraint FK_CTPD foreign key (MaDatPhong) references DatPhong(MaDatPhong),
	constraint FK_CTPD1 foreign key (MaPhong) references Phong(MaPhong),
)
go


create table HoaDon(
	MaHD int identity not null,
	MaDatPhong int,
	Ngaylap date default(getdate()),
	TongTien int,
	constraint pk_HoaDon primary key (MaHD),
	constraint fk_Hoadon foreign key (MaDatPhong) references DatPhong(MaDatPhong),
)	

go

insert into ChucVu values(N'Quản trị')
insert into ChucVu values(N'Nhân Viên')
go

insert into NhanVien values(1, N'Nguyễn Tiến Hà', 0912391238,'04/03/2000', N'Hà Nội',0921892181,N'Nam')
insert into NhanVien values(2, N'Đỗ Bá Hoàn', 09123121,'09/28/2000', N'Hà Nội',0921892181,N'Nam')
go

insert into Taikhoan values('admin', 'admin', 1, 1)
insert into Taikhoan values('nhanvien', 'nhanvien', 0, 2)
go
