create database QLGO11;
drop database QLGO11
use QLGO11;

create table LOAISANPHAM (
IDLSP varchar(10) primary key not null,
TenLSP nvarchar(200) not null,
);

INSERT INTO LOAISANPHAM
VALUES 
('LSP001', N'Thức ăn'),


create table DONVITINH (
IDDVT varchar(10) primary key not null,
TenDVT nvarchar(200) not null,
);

create table LOAINGUOIDUNG (
IDLND varchar(10) primary key not null,
TenLND nvarchar(200) not null,
);

create table LOAITHANHTOAN (
IDLTT varchar(10) primary key not null,
TenLTT nvarchar(200) not null,
);

create table SANPHAM (
IDSP varchar(10) primary key not null,
TenSP nvarchar(200) not null,
SL int not null,
TinhTrang BIT,
GiaBan decimal not null,
GiaGiam decimal not null,
HinhanhSP varchar(200) not null,
IDLSP varchar(10) foreign key references LOAISANPHAM(IDLSP),
IDDVT varchar(10) foreign key references DONVITINH(IDDVT),
);

INSERT INTO SANPHAM (IDSP, TenSP, SL, TinhTrang, GiaBan, GiaGiam, HinhanhSP, IDLSP, IDDVT)
VALUES ('SP001', 'Pizza', 10, 1, 500.00, 450.00, 'vs.jpg', '1', '1');


create table NGUOIDUNG (
IDND varchar(10) primary key not null,
TenDN varchar(200) not null,
MKDN varchar(200) not null,
TenND varchar(100) not null,
HoND varchar(50) not null,
SDTND varchar(100) not null,
EmailND varchar(100) not null,
GioiTinh bit not null,
DiemThuong int not null,
NgaySinh datetime not null,
IDLND varchar(10) foreign key references LOAINGUOIDUNG(IDLND),
);

create table TINHTRANG (
IDTT varchar(10) primary key not null,
TenTT nvarchar(50) not null
)

create table DONDATHANG (
IDDDH varchar(10) primary key not null,
IDKH varchar(10) foreign key references NGUOIDUNG(IDND),
IDLTT varchar(10) foreign key references LOAITHANHTOAN(IDLTT),
IDTT varchar(10) foreign key references TINHTRANG(IDTT),
NgayDatHang datetime not null,
NgayGiaoHang datetime not null,
DiaChi nvarchar(200) not null,
TenNguoiDH nvarchar(200) not null,
);

INSERT INTO DONDATHANG (IDDDH, IDKH, IDLTT, IDTT, NgayDatHang, NgayGiaoHang, DiaChi, TenNguoiDH)
VALUES ('DH001', 'ND0002', '1', '1', '2024-06-01', '2024-06-05', '123 Đường ABC, Quận 1', 'Nguyen Van A');


create table CTDONDATHANG (
IDDDH varchar(10) foreign key references DONDATHANG(IDDDH),
IDSP varchar(10) foreign key references SANPHAM(IDSP),
SLDat int not null,
primary key(IDDDH, IDSP)
);

insert INTO TINHTRANG values
('1', N'Chưa duyệt'),
('2', N'Đã duyệt'),
('3', N'Đang giao hàng')

insert into LOAINGUOIDUNG(IDLND, TenLND) values 
('KH', N'Khách hàng'),
('TN', N'Thu ngân'),
('QLK', N'Quản lý kho'),
('QL', N'Quản lý'),
('NV', N'Nhân viên'),
('KT', N'Kế toán'),
('GH', N'Giao hàng');

