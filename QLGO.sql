create database QLGO;

use QLGO;

create table LOAISANPHAM (
IDLSP varchar(10) primary key not null,
TenLSP nvarchar(200) not null,
);

create table DONVITINH (
IDDVT varchar(10) primary key not null,
TenDVT nvarchar(200) not null,
);

create table NHACUNGCAP (
IDNCC varchar(10) primary key not null,
TenNCC nvarchar(200) not null,
);

create table LOAINGUOIDUNG (
IDLND varchar(10) primary key not null,
TenLND nvarchar(200) not null,
Luong decimal not null,
);

create table LOAITHANHTOAN (
IDLTT varchar(10) primary key not null,
TenLTT nvarchar(200) not null,
);

create table SANPHAM (
IDSP varchar(10) primary key not null,
TenSP nvarchar(200) not null,
SLKho int not null,
SLQuay int not null,
GiaBan decimal not null,
HinhanhSP varchar(200) not null,
IDLSP varchar(10) foreign key references LOAISANPHAM(IDLSP),
IDDVT varchar(10) foreign key references DONVITINH(IDDVT),
);

create table NGUOIDUNG (
IDND varchar(10) primary key not null,
MKDN varchar(200) not null,
TenDN varchar(200) not null,
HoND varchar(50) not null,
TenND varchar(100) not null,
SDTND varchar(100) not null,
EmailND varchar(100) not null,
GioiTinh bit not null,
DiemThuong int not null,
NgaySinh datetime not null,
IDLND varchar(10) foreign key references LOAINGUOIDUNG(IDLND),
);

create table NHAPKHO (
IDPhieuNhap varchar(10) primary key not null,
NgayNhapKho datetime not null,
IDNCC varchar(10) foreign key references NHACUNGCAP(IDNCC),
IDND varchar(10) foreign key references NGUOIDUNG(IDND),
);

create table CTNHAPKHO (
IDPhieuNhap varchar(10) foreign key references NHAPKHO(IDPhieuNhap),
IDSP varchar(10) foreign key references SANPHAM(IDSP),
SLNhap int not null,
GiaNhap decimal not null,
primary key(IDPhieuNhap, IDSP)
);

--create table XUUATKHO (
--IDPhieuXuat varchar(10) primary key not null,
--NgayXuatKho datetime not null,
--IDND varchar(10) foreign key references NGUOIDUNG(IDND),
--);

--create table CTXUATKHO (
--IDPhieuXuat varchar(10) foreign key references XUUATKHO(IDPhieuXuat),
--IDSP varchar(10) foreign key references SANPHAM(IDSP),
--SLXuat int not null,
--primary key(IDPhieuXuat, IDSP)
--);

create table HOADON (
IDHD varchar(10) primary key not null,
NgayXuatHD datetime not null,
IDNV varchar(10) foreign key references NGUOIDUNG(IDND),	
IDKH varchar(10) foreign key references NGUOIDUNG(IDND),
IDLTT varchar(10) foreign key references LOAITHANHTOAN(IDLTT),	
);

create table CTHOADON (
IDHD varchar(10) foreign key references HOADON(IDHD),
IDSP varchar(10) foreign key references SANPHAM(IDSP),
SLBan int not null,
primary key(IDHD, IDSP)
);

create table TINHTRANG (
IDTT varchar(10) primary key not null,
TenTT nvarchar(50) not null
)

create table DONDATHANG (
IDDDH varchar(10) primary key not null,
IDKH varchar(10) foreign key references NGUOIDUNG(IDND),
IDNV varchar(10) foreign key references NGUOIDUNG(IDND),
IDLTT varchar(10) foreign key references LOAITHANHTOAN(IDLTT),
IDTT varchar(10) foreign key references TINHTRANG(IDTT),
TinhTrang varchar(10) not null,
NgayDatHang datetime not null,
NgayGiaoHang datetime not null,
DiaChi nvarchar(200) not null,
TenNguoiDH nvarchar(200) not null,
);


create table CTDONDATHANG (
IDDDH varchar(10) foreign key references DONDATHANG(IDDDH),
IDSP varchar(10) foreign key references SANPHAM(IDSP),
SLDat int not null,
primary key(IDDDH, IDSP)
);


