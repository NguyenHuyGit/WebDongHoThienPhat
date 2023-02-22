create database QLDHC_ThienPhat
use QLDHC_ThienPhat
create table LoaiDongHo
(
	MaLoaiDH varchar(5) primary key,
	TenLoaiDH nvarchar(30) not null 
)
create table QuocGia 
(
	MaQuocGia varchar(5) primary key,
	TenQuocGia nvarchar(30) not null
)

create table NhaCungCap
(
	MaNCC varchar(6) primary key,
	TenNCC nvarchar(30) not null,
	MaQuocGia varchar(5) foreign key references QuocGia(MaQuocGia)
	on update cascade
	on delete cascade
)

create table ChucVu 
(
	MaChucVu varchar(5) primary key,
	TenChucVu nvarchar(70) not null
)

create table QuyenDangNhapNhanVien
(
	MaQuyenDangNhap int primary key,
	TenQuyenDangNhap nvarchar(70) not null
)

create table NhanVien 
(
	MaNV varchar(6) primary key,
	HoTenNV nvarchar(100) not null, 
	NgayLamViec date not null,
	GioiTinhNV bit not null,
	SDTNV varchar(10) not null ,
	DiaChiNV nvarchar(100) not null,
	AnhNV nvarchar(100) not null,
	Luong int not null,
	Email varchar(30) not null,
	MatKhau varchar(20) not null,
	MaQuyenDangNhap int foreign key references QuyenDangNhapNhanVien(MaQuyenDangNhap),
	MaChucVu varchar(5) foreign key references ChucVu(MaChucVu)
	on update cascade
	on delete cascade
)

create table DongHo
(
	MaDH varchar(6) primary key,
	TenDongHo nvarchar(100) not null,
	AnhSanPham nvarchar(100) not null,
	GiaBan int not null,
	Mota nvarchar(150),
	GhiChu nvarchar(100),
	MaLoaiDH varchar(5) foreign key references LoaiDongHo(MaLoaiDH),
	MaNCC varchar(6) foreign key references NhaCungCap(MaNCC)
	on update cascade
	on delete cascade
)

create table LoaiKhachHang
(
	MaLoaiKH varchar(5) primary key,
	TenLoaiKH nvarchar(40) not null
)

create table KhachHang
(
	MaKH int identity(1,1) primary key,
	HoTenKH nvarchar(100) not null,
	GioiTinhKH bit not null,
	DiaChiKH nvarchar(100) not null,
	NgaySinhKH date not null,
	SoDTKH varchar(10) not null,
	Email varchar(30) not null,
	TenDangNhap nvarchar(30) not null,
	MatKhau varchar(20) not null,	
	MaLoaiKH varchar(5) foreign key references LoaiKhachHang(MaLoaiKH)
	on update cascade
	on delete cascade
)

create table HoaDonBan
(
	MaHD int identity(1,1) primary key,
	NgayDatHang datetime not null,
	NgayGiaoHang datetime not null,
	TenNguoiNhan nvarchar(20) not null,
	SDTNguoiNhan varchar(10) not null,
	DiaChiNhanHang nvarchar(150) not null,
	TinhTrangHoaDon nvarchar(30) not null,
	HinhThucThanhToan nvarchar(20) not null,
	MaNV varchar(6) foreign key references NhanVien(MaNV),
	MaKH int foreign key references KhachHang(MaKH)
	on update cascade
	on delete cascade
)

create table CTHDB
(
	MaHD int,
	SoLuong int default 1,
	DonGia int not null,
	MaDH varchar(6) foreign key references DongHo(MaDH)
	on update cascade
	on delete cascade
	constraint pk_CTHDB primary key(MaHD,MaDH)
)

alter table CTHDB add constraint fk_HDB_MaHD foreign key(MaHD) references HoaDonBan(MaHD)
	on update cascade
	on delete cascade
	
create table QuanTriVien
(
	IdAdmin int primary key,	
    Email varchar(40),
    Password varchar(40)
)

-- insert dữ liệu 
insert into QuanTriVien values(1,'huy123@gmail.com','123')d
insert into LoaiDongHo values('LDH01',N'Cổ điển'),('LDH02',N'Sang trọng'),('LDH03',N'Cao cấp'),('LDH04',N'Thể thao')
insert into QuocGia values ('QG01',N'Mỹ'),('QG02',N'Nga'),('QG03',N'Đức'),('QG04',N'Thuỵ Điển'),('QG05',N'Nga')
insert into NhaCungCap values('NCC01',N'Rolex','QG01'),('NCC02',N'Omega','QG02'),('NCC03',N'Movado','QG03'),('NCC04',N'Citizen','QG05')
insert into ChucVu values('CV01',N'Nhân viên quản lý'),('CV02',N'Nhân viên bán hàng'),('CV03',N'Nhân viên giao hàng')
insert into DongHo values
('DH01',N'Omega De Ville',N'Omega3.jpg',3000000,N'',N'','LDH02','NCC02'),
('DH02',N'Omega De Ville Prestige Automatic',N'Omega2.png',70000000,N'',N'','LDH03','NCC02'),
('DH03',N'Omega De Ville Prestige Automatic vàng trắng 18k',N'Omega1.png',200000000,N'',N'','LDH03','NCC02'),
('DH04',N'ROLEX DATEJUST MẶT SỐ BẠC DÂY ĐEO OYSTER',N'Rolex1.png',175000000,N'',N'','LDH03','NCC01'),
('DH05',N'Rolex Cosmograph Daytona Green Dial 18K Yellow Gold ',N'Rolex3.png',500000000,N'',N'','LDH03','NCC01'),
('DH06',N'ROLEX COSMOGRAPH DAYTONA ',N'Rolex4.2.png',300000000,N'',N'','LDH04','NCC01'),
('DH07',N'Citizen BM6770-51E ',N'Citizen1.jpg',5200000,N'',N'','LDH02','NCC04'),
('DH08',N'Citizen BE9180-52E ',N'citizen2.jpg',2800000,N'',N'','LDH04','NCC04'),
('DH09',N'Citizen Eco Drive',N'Citizen3.jpg',4500000,N'',N'','LDH04','NCC04'),
('DH010',N'Citizen NH8365-86M ',N'Citizen4.jpg',5300000,N'',N'','LDH02','NCC04'),
('DH011',N'Citizen NP1010-01L',N'Citizen5.jpg',8800000,N'',N'','LDH03','NCC04'),
('DH012',N'CITIZEN NP1023-17L',N'Citizen6.jpg',7600000,N'',N'','LDH01','NCC04'),
('DH013',N'Citizen Paradigm Blue Titanium Watch 43mm',N'Citizen7.png',10000000,N'',N'','LDH03','NCC04'),
('DH014',N'Citizen AW1598-70X',N'Citizen8.jpg',9200000,N'',N'','LDH03','NCC04'),
('DH015',N'Citizen BI5006-81L',N'Citizen9.jpg',3000000,N'',N'','LDH01','NCC04'),
('DH016',N'Citizen CA7008 11E',N'Citizen10.jpg',4500000,N'',N'','LDH01','NCC04'),
('DH017',N'Movado Museum 0606555 Stainless Steel Men’s Watch 40mm ',N'Movado1.jpg',16900000,N'',N'','LDH02','NCC03'),
('DH018',N'Movado Bold 3600171 Chronograph All Black Men’s 44mm',N'Movado2.jpg',25000000,N'',N'','LDH03','NCC03'),
('DH019',N'Movado Chronograph Datron 606535 PVD Watch 40mm ',N'Movado3.jpg',35700000,N'',N'','LDH03','NCC03'),
('DH020',N'Movado Sapphire 0606882 Men’s Black PVD 40mm',N'Movado4.png',46000000,N'',N'','LDH04','NCC03'),
('DH021',N'Movado Bold 3600085 Champagne Gold Women’s Watch 36mm ',N'Movado5.jpg',16000000,N'',N'','LDH02','NCC03'),
('DH022',N'Movado 0607205',N'Movado6.jpg',201000000,N'',N'','LDH01','NCC03'),
('DH023',N'Movado Men Blue Museum Sport Watch ',N'Movado7.jpeg',8270000,N'',N'','LDH04','NCC03'),
('DH024',N'Movado 3600520 ',N'Movado8.jpg',12240000,N'',N'','LDH02','NCC03'),
('DH025',N'Movado Museum 210002 ',N'Movado9.jpg',8000000,N'',N'','LDH01','NCC03'),
('DH026',N'Movado 0606234 ',N'Movado10.jpg',18000000,N'',N'','LDH02','NCC03'),
('DH027',N'OMEGA Planet Ocean Seamaster ',N'Omega4.png',4000000,N'',N'','LDH03','NCC02'),
('DH028',N'Omega Deville Prestige 36.8mm ',N'Omega5.jpg',156000000,N'',N'','LDH03','NCC02'),
('DH029',N'Rolex Submariner 116610LN Date Oystersteel',N'Rolex5.jpg',265000000,N'',N'','LDH03','NCC01'),
('DH030',N'ROLEX SUBMARINER DATE 116618LB-0003 ',N'Rolex6.jpg',295000000,N'',N'','LDH02','NCC01')
insert into LoaiKhachHang values
('LKH01',N'Khách hàng mới'),
('LKH02',N'Khách hàng thân thiết'),
('LKH03',N'Khách hàng thành viên'),
('LKH04',N'VIP')
insert into QuyenDangNhapNhanVien values
(1,N'Nhân viên quản lý'),
(2,N'Nhân viên bán hàng'),
(3,N'Nhân viên giao hàng')
insert into NhanVien values 
('NV01',N'Nguyễn Trần Nam',CAST(N'2020-10-23' AS Date),1,'0123456789',N'Nha Trang',N'male2.png',12000000,'nguyennam123@gmail.com','123',1,'CV01'),
('NV02',N'Nguyễn Thị Nhung',CAST(N'2020-5-5' AS Date),0,'0123456689',N'Nha Trang',N'female1.png',8000000,'nguyenthinhung123@gmail.com','123',2,'CV02'),
('NV03',N'Nguyễn Thị An',CAST(N'2020-9-9' AS Date),0,'0122256789',N'Phú Yên',N'female2.png',8000000,'nguyenthian123@gmail.com','123',2,'CV02'),
('NV04',N'Nguyễn Quốc Tiến',CAST(N'2020-11-5' AS Date),1,'0133456789',N'Nha Trang',N'male1.png',5000000,'nguyenquoctien123@gmail.com','123',3,'CV03')
insert into KhachHang values
(N'Nguyễn Mỹ An',0,N'Nha Trang',CAST(N'1995-10-20' AS Date),'0223456789','nguyenan@gmail.com','nguyenmyan','1','LKH01'),
(N'Nguyễn Quốc Bảo',1,N'Phú Yên',CAST(N'1992-01-20' AS Date),'0112000090','nguyenquocbao@gmail.com','nguyenquocbao','1','LKH01'),
(N'Nguyễn Bảo Nam',1,N'Nha Trang',CAST(N'1995-10-22' AS Date),'0223406000','nguyenbaonam@gmail.com','nguyenbaonam','1','LKH02'),
(N'Trinh Hoàng Yến',0,N'Nha Trang',CAST(N'1995-10-09' AS Date),'0200405060','trinhhoangyen@gmail.com','trinhhoangyen','1','LKH02'),
(N'Nguyễn Hải Tiến',1,N'Nha Trang',CAST(N'1995-05-02' AS Date),'0123456888','nguyenhaitien@gmail.com','nguyenhaitien','1','LKH01'),
(N'Đỗ Thị Thu Hà',0,N'Phú Yên',CAST(N'1993-10-20' AS Date),'0123456781','dothithuha@gmail.com','dothithuha','1','LKH02'),
(N'Nguyễn Ngọc Lan',0,N'Nha Trang',CAST(N'1997-05-05' AS Date),'0124456789','nguyenngoclan@gmail.com','nguyenngoclan','1','LKH03'),
(N'Đỗ Tấn Phát',1,N'Nha Trang',CAST(N'1999-10-02' AS Date),'0123355789','dotanphat@gmail.com','dotanphat','1','LKH04'),
(N'Lê Thị Huệ',0,N'Nha Trang',CAST(N'1992-02-20' AS Date),'0223355789','lethihue@gmail.com','lethihue','1','LKH02'),
(N'Trịnh Hoàng Long',1,N'Nha Trang',CAST(N'1994-09-02' AS Date),'0123466689','trinhhoanglong@gmail.com','trinhhoanglong','1','LKH01'),
(N'Lý Quốc Nam',1,N'Phú Yên',CAST(N'1997-08-20' AS Date),'0124446789','lyquocnam@gmail.com','lyquocnam','1','LKH01'),
(N'Trần Cẩm Tú',0,N'Nha Trang',CAST(N'1998-09-21' AS Date),'0323456789','trancamtu@gmail.com','trancamtu','1','LKH01'),
(N'Nguyễn Quốc Huy',1,N'Nha Trang',CAST(N'1999-11-11' AS Date),'0122226789','nguyenquochuy21@gmail.com','nguyenquochuy','1','LKH04'),
(N'Trịnh Xuân Lan',0,N'Nha Trang',CAST(N'1995-10-20' AS Date),'0124454789','trinhxuanlan@gmail.com','trinhxuanlan','1','LKH01'),
(N'Trần Hoàng Đức',1,N'Nha Trang',CAST(N'1997-05-20' AS Date),'0123456789','tranhoangduc@gmail.com','trinhhoangduc','1','LKH01'),
(N'Nguyễn An Nam',1,N'Nha Trang',CAST(N'1992-02-02' AS Date),'0155456789','nguyenbaonam@gmail.com','nguyenbaonam','1','LKH02'),
(N'Nguyễn Tú Trinh',0,N'Phú Yên',CAST(N'1994-10-10' AS Date),'0126456769','nguyentutrinh@gmail.com','nguyentutrinh','1','LKH02'),
(N'Đỗ Hoàng Yến',0,N'Nha Trang',CAST(N'1992-04-01' AS Date),'0423456489','dohoangyen@gmail.com','dohoangyen','1','LKH01'),
(N'Trịnh Hoàng Tôn',1,N'Nha Trang',CAST(N'1993-04-05' AS Date),'0122226789','trinhhoangton@gmail.com','trinhhoangton','1','LKH03'),
(N'Đỗ Xuân Ngọc',0,N'Phú Yên',CAST(N'1995-02-09' AS Date),'0133453789','doxuanngoc@gmail.com','doxuanngoc','1','LKH02'),
(N'Nguyễn Tuấn Hải',1,N'Nha Trang',CAST(N'1996-05-10' AS Date),'0123456799','nguyentuanhai@gmail.com','nguyentuanhai','1','LKH01'),
(N'Trần Tố Uyên',0,N'Nha Trang',CAST(N'1995-10-20' AS Date),'0128456889','trantouyen@gmail.com','trantouyen','1','LKH01'),
(N'Bùi Đình Thái',1,N'Nha Trang',CAST(N'1995-01-01' AS Date),'0125456589','buidinhthai@gmail.com','buidinhthai','1','LKH02'),
(N'Phan Thảo Như',0,N'Nha Trang',CAST(N'1991-02-08' AS Date),'0143456489','phanthaonhu@gmail.com','phanthaonhu','1','LKH01'),
(N'Nguyễn Phúc Khang',1,N'Nha Trang',CAST(N'1994-01-01' AS Date),'0122456729','nguyenphuckhang@gmail.com','nguyenphuckhang','1','LKH01'),
(N'Trần Thái Nam',1,N'Nha Trang',CAST(N'1990-01-09' AS Date),'0133426689','tranthainam@gmail.com','tranthainam','1','LKH01'),
(N'Nguyễn Thị Mỹ',0,N'Nha Trang',CAST(N'1999-11-11' AS Date),'0123252729','nguyenthimy@gmail.com','nguyenthimy','1','LKH01'),
(N'Đỗ Tú Tài',1,N'Nha Trang',CAST(N'1992-04-06' AS Date),'0124456489','dotutai@gmail.com','dotutai','1','LKH02'),
(N'Trịnh Xuân Mai',0,N'Nha Trang',CAST(N'1995-10-01' AS Date),'0113456781','trinhxuanmai@gmail.com','trinhxuanmai','1','LKH02'),
(N'Nguyễn Phú Mỹ',1,N'Nha Trang',CAST(N'1998-11-20' AS Date),'0123556785','nguyenphumy@gmail.com','nguyenphumy','1','LKH01')
insert into HoaDonBan values
(CAST(N'2021-10-02' AS Date),CAST(N'2021-10-05' AS Date),N'Liên','0234567891',N'26 Nguyễn Trãi, Nha Trang',N'Chờ xác nhận',N'','NV03',28),
(CAST(N'2021-08-20' AS Date),CAST(N'2021-08-28' AS Date),N'Tú','0224567891',N'35 Quang Trung, Nha Trang',N'Chờ thanh toán',N'Tiền mặt','NV03',23),
(CAST(N'2020-05-05' AS Date),CAST(N'2020-05-10' AS Date),N'Nam','0244567991',N'40 Cửu Long, Nha Trang',N'Đã thanh toán',N'Tiền mặt','NV03',21),
(CAST(N'2021-02-02' AS Date),CAST(N'2021-02-15' AS Date),N'An','0234567891',N'45 Lê Quý Đôn, Nha Trang',N'Đã giao hàng',N'Tiền mặt','NV02',20),
(CAST(N'2021-09-02' AS Date),CAST(N'2021-09-07' AS Date),N'Phước','0111567891',N'23 Lê Đại Hành, Nha Trang',N'Đã thanh toán',N'Tiền mặt','NV02',12),
(CAST(N'2020-05-09' AS Date),CAST(N'2020-05-12' AS Date),N'Sang','0222967891',N'29 Đường số 4, Nha Trang',N'Đã thanh toán',N'Tiền mặt','NV02',9),
(CAST(N'2020-01-02' AS Date),CAST(N'2020-03-02' AS Date),N'Hoa','0233477891',N'35 Lê Thánh Tôn, Nha Trang',N'Đã thanh toán',N'Tiền mặt','NV01',10),
(CAST(N'2021-05-09' AS Date),CAST(N'2020-05-15' AS Date),N'Tùng','0934565891',N'29 Phước Đồng , Nha Trang',N'Đã thanh toán',N'Tiền mặt','NV02',11),
(CAST(N'2021-02-02' AS Date),CAST(N'2020-02-09' AS Date),N'Sơn','0134567881',N'9 Lê Lợi, Đà Nẵng',N'Đang giao hàng',N'Tiền mặt','NV02',13),
(CAST(N'2020-01-09' AS Date),CAST(N'2020-01-16' AS Date),N'Mai','0224567892',N'35 Phước Hoà, Quảng Ngãi',N'Đã thanh toán',N'Tiền mặt','NV02',14)
insert into CTHDB values
(1,1,3000000,'DH01'),
(8,1,8000000,'DH025'),
(9,1,4500000,'DH016'),
(10,1,5200000,'DH07'),
(11,1,4500000,'DH09'),
(12,1,5200000,'DH07'),
(14,1,3000000,'DH01'),
(15,1,2800000,'DH08'),
(16,1,10000000,'DH013'),
(17,1,5200000,'DH07')

-- procedure
-- tìm kiếm đồng hồ
create procedure DongHo_TimKiem
(
	@MaDH varchar(6) =null,
	@TenDongHo nvarchar(100)=null,	
	@GiaBanMin varchar(30)=null,
	@GiaBanMax varchar(30)=null,
	@MaLoaiDH varchar(5)=null,
	@MaNCC varchar(6)=null
)
as 
begin
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
		SELECT @SqlStr = '
       SELECT * 
       FROM DongHo
       WHERE  (1=1)
       '
	   IF @MaDH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaDH LIKE ''%'+@MaDH+'%'')
              '
		IF @TenDongHo IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenDongHo LIKE N''%'+@TenDongHo+'%'')
              '
		IF @GiaBanMin IS NOT NULL and @GiaBanMax IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GiaBan Between Convert(int,'''+@GiaBanMin+''') AND Convert(int, '''+@GiaBanMax+'''))'
		IF @MaLoaiDH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaLoaiDH LIKE ''%'+@MaLoaiDH+'%'')
              '
		IF @MaNCC IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaNCC LIKE ''%'+@MaNCC+'%'')
              '
		EXEC SP_EXECUTESQL @SqlStr
end

-- tìm kiếm nhân viên
CREATE PROCEDURE NhanVien_TimKiem
    @MaNV varchar(6)=NULL,
	@HoTenNV nvarchar(100)=NULL,
	@GioiTinhNV nvarchar(3)= NULL,
	@DiaChi nvarchar(100)=NULL,
	@LuongMin varchar(30)=NULL,
	@LuongMax varchar(30)=NULL,
	@MaChucVu varchar(5)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM NhanVien
       WHERE  (1=1)
       '
IF @MaNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaNV LIKE ''%'+@MaNV+'%'')
              '
IF @HoTenNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoTenNV LIKE N''%'+@HoTenNV+'%'')
              '
IF @GioiTinhNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GioiTinhNV LIKE ''%'+@GioiTinhNV+'%'')
             '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (DiaChiNV LIKE N''%'+@DiaChi+'%'')
              '
IF @LuongMin IS NOT NULL and @LuongMax IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (Luong Between Convert(int,'''+@LuongMin+''') AND Convert(int, '''+@LuongMax+'''))
             '
IF @MaChucVu IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaChucVu LIKE ''%'+@MaChucVu+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END

--tìm kiếm khách hàng
CREATE PROCEDURE KhachHang_TimKiem   
	@HoTenKH nvarchar(100)=NULL,
	@GioiTinhKH nvarchar(3)= NULL,
	@DiaChiKH nvarchar(100)=NULL,	
	@MaLoaiKH varchar(5)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM KhachHang
       WHERE  (1=1)
       '
           
IF @HoTenKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoTenKH LIKE N''%'+@HoTenKH+'%'')
              '
IF @GioiTinhKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GioiTinhKH LIKE ''%'+@GioiTinhKH+'%'')
             '
IF @DiaChiKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (DiaChiKH LIKE N''%'+@DiaChiKH+'%'')
              '
IF @MaLoaiKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaLoaiKH LIKE ''%'+@MaLoaiKH+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END

