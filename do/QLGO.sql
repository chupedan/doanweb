create database QLGO11;
drop database QLGO11
use QLGO11;

create table LOAISANPHAM (
IDLSP varchar(10) primary key not null,
TenLSP nvarchar(200) not null,
);

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
TinhTrang  BIT,
GiaBan decimal not null,
GiaGiam decimal not null,
HinhanhSP varchar(200) not null,
IDLSP varchar(10) foreign key references LOAISANPHAM(IDLSP),
IDDVT varchar(10) foreign key references DONVITINH(IDDVT),
);

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

insert into NGUOIDUNG values
('tn002', 'user1', '1', 'Asl', 'Vao', '987654321', 'alice@example.com', 0, 200, '1995-01-15', 'TN'),
('tn001', 'user1', '1', 'Asl', 'Vao', '987654321', 'alice@example.com', 0, 200, '1995-01-15', 'TN'),
('qlk001', 'user1', '1', 'Luas', 'Casu', '987654321', 'alice@example.com', 0, 200, '1995-01-15', 'QLK'),
('001', 'user1', '1', 'Clasc', 'Sow', '987654321', 'Alas@example.com', 0, 200, '1995-01-15', 'QL'),
('002', 'user1', '1', 'Alice', 'Smith', '987654321', 'alice@example.com', 0, 200, '1995-01-15', 'NV'),
('ad002', 'user1', '1', 'Cazz', 'Smith', '987654321', 'alice@example.com', 0, 200, '1995-01-15', 'QL'),
('kt001', 'user1', '1', 'Cazz', 'Smith', '987654321', 'alice@example.com', 0, 200, '1995-01-15', 'KT');

delete from NGUOIDUNG


select * from NGUOIDUNG