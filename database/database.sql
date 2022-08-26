CREATE DATABASE QLKS

GO

USE QLKS
GO
SET DATEFORMAT dmy

--TÀI KHO?N
CREATE TABLE ACCOUNT
(
	TenDN VARCHAR(50) NOT NULL PRIMARY KEY, -- tao khoa chinh
	MatKhau VARCHAR(50)NOT NULL DEFAULT 0,
	HoTen NVARCHAR(50) ,
    Email VARCHAR(50) ,
    Quyen INT DEFAULT 0,
MatKhauMoi VARCHAR(50),
)
GO

INSERT INTO ACCOUNT (TenDN, MatKhau, HoTen, Email, Quyen) VALUES ('thuydung', '12345678', N'Lê Phan Thùy Dung', '19520475@gm.uit.edu.vn', '1')
INSERT INTO ACCOUNT (TenDN, MatKhau, HoTen, Email, Quyen) VALUES ('kieuanh', '12345678', N'Phan Mai Kiều Anh', '19521209@gm.uit.edu.vn', '0')
INSERT INTO ACCOUNT (TenDN, MatKhau, HoTen, Email) VALUES ('camthuy', '12345678', N'Nguyễn Thị Cẩm Thùy', '19521209@gm.uit.edu.vn')

Select * from ACCOUNT

--LO?I PHÒNG
CREATE SCHEMA hr;

CREATE TABLE hr.LOAIPHONG
(
	MaLoaiPhong INT IDENTITY(1,1) PRIMARY KEY,
	TenLoaiPhong VARCHAR(40) NOT NULL,
	DonGia int,
)
GO



INSERT INTO hr.LOAIPHONG ( TenLoaiPhong, DonGia) VALUES ( 'Standard', '150000')
INSERT INTO hr.LOAIPHONG ( TenLoaiPhong, DonGia) VALUES ( 'Superior', '170000')
INSERT INTO hr.LOAIPHONG ( TenLoaiPhong, DonGia) VALUES ( 'Suite', '200000')
select * from hr.LOAIPhong



--PHÒNG
CREATE TABLE hr.PHONG
(
	MaPhong INT IDENTITY(1,1) PRIMARY KEY,
	MaLoaiPhong int,
	TenPhong VARCHAR(20),
	GhiChu NVARCHAR(40),
	TinhTrang NVARCHAR(40) DEFAULT N'Trống' ,  --tr?ng||có ng??i
	FOREIGN KEY (MaLoaiPhong) REFERENCES hr.LOAIPHONG(MaLoaiPhong) 
)
GO

INSERT INTO hr.PHONG ( MaLoaiPhong, TenPhong, GhiChu) VALUES ( '1', '0101', 'Không')
INSERT INTO hr.PHONG ( MaLoaiPhong, TenPhong, GhiChu) VALUES ( '2', '0102', 'Không')
INSERT INTO hr.PHONG ( MaLoaiPhong, TenPhong, GhiChu) VALUES ( '3', '0103', 'Không')
select * from hr.Phong

--LO?I KHÁCH
CREATE TABLE LOAIKHACH
(
	MaLK CHAR(4) PRIMARY KEY,
	TenLK NVARCHAR(40)
)
GO
INSERT INTO LOAIKHACH (MaLK, TenLK) VALUES ('LK01', N'Nội địa')
INSERT INTO LOAIKHACH (MaLK, TenLK) VALUES ('LK02', N'Nước Ngoài')

--KHÁCH HÀNG
CREATE TABLE KHACHHANG
(
	MaKH CHAR(5) PRIMARY KEY,
	MaLK CHAR(4),
	HoTen NVARCHAR(50),
	NgaySinh SMALLDATETIME,
	SoDT VARCHAR(20),
	CMND VARCHAR(20),
	Email VARCHAR(50),
	DiaChi NVARCHAR(50),
	
	FOREIGN KEY (MaLK) REFERENCES LOAIKHACH(MaLK)
)

GO

INSERT INTO KHACHHANG (MaKH, MaLK, HoTen, NgaySinh, SoDT, CMND, Email, DiaChi) VALUES ('KH001', 'LK01', N'Ngô Thị Tuyết Anh', '01/01/2001', '0333333333', '214214214', '19521198@gm.uit.edu.vn', N'ktx khu b')
INSERT INTO KHACHHANG (MaKH, MaLK, HoTen, NgaySinh, SoDT, CMND, Email, DiaChi) VALUES ('KH002', 'LK01', N'Nguyễn Thị Cẩm Thùy',  '01/01/2001', '0444444444', '214214214', '19520294@gm.uit.edu.vn', N'ktx khu a')
INSERT INTO KHACHHANG (MaKH, MaLK, HoTen, NgaySinh, SoDT, CMND, Email, DiaChi) VALUES ('KH003', 'LK01', N'Lê Phan Thùy Dung', '01/01/2001',  '0555555555', '214214214', '19520475@gm.uit.edu.vn', N'ktx khu a')
INSERT INTO KHACHHANG (MaKH, MaLK, HoTen, NgaySinh, SoDT, CMND, Email, DiaChi) VALUES ('KH004', 'LK02', N'Phan Mai Kiều Anh', '01/01/2001', '0666666666', '214214214', '19521209@gm.uit.edu.vn', N'ktx khu a')



--PHI?U THU
CREATE TABLE PHIEUTHUE
(
	MaPT CHAR(5) PRIMARY KEY,
	MaPhong int,
	NgayBDThue SMALLDATETIME,
	FOREIGN KEY (MaPhong) REFERENCES hr.PHONG(MaPhong),
)
GO
INSERT INTO PHIEUTHUE (MaPT, MaPhong, NgayBDThue) VALUES ('PT001', '1', '19/6/2021')
INSERT INTO PHIEUTHUE (MaPT, MaPhong, NgayBDThue) VALUES ('PT002', '2', '16/6/2021')
update hr.PHONG
set TinhTrang = N'Có ng??i'
where MaPhong = '1' 
update hr.PHONG
set TinhTrang = N'Có ng??i'
where MaPhong = '2' 

--CHI TI?T  PHI?U THUÊ
CREATE TABLE CTPT
(
	MaCTPT CHAR(5) PRIMARY KEY,
	MaPT CHAR(5),
	MaKH CHAR(5),
	FOREIGN KEY (MaPT) REFERENCES PHIEUTHUE(MaPT),
	FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
)
GO
INSERT INTO CTPT (MaCTPT, MaPT, MaKH) VALUES ('CT001', 'PT001', 'KH001')
INSERT INTO CTPT (MaCTPT, MaPT, MaKH) VALUES ('CT002', 'PT001', 'KH002')
INSERT INTO CTPT (MaCTPT, MaPT, MaKH) VALUES ('CT003', 'PT001', 'KH003')
INSERT INTO CTPT (MaCTPT, MaPT, MaKH) VALUES ('CT004', 'PT002', 'KH004')

-- HÓA ??N
CREATE TABLE HOADON
(
	MaHD CHAR(5) PRIMARY KEY,
	MaPT CHAR(5),
	MaKH CHAR(5),
	NgayLapHD SMALLDATETIME,
	SoKhach INT,
	SoNgayThue INT,
	DonGia MONEY,
	HeSo FLOAT,
	FOREIGN KEY (MaPT) REFERENCES PHIEUTHUE(MaPT),
	FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
)
GO

INSERT INTO HOADON (MaHD, MaPT, MaKH, NgayLapHD, SoKhach, SoNgayThue, DonGia, HeSo) VALUES ('HD001', 'PT001','KH001', '21/6/2021', '3', '3', '150000', '0.25')
INSERT INTO HOADON (MaHD, MaPT, MaKH, NgayLapHD, SoKhach, SoNgayThue, DonGia, HeSo) VALUES ('HD002', 'PT002', 'KH004', '20/6/2021', '1', '5', '200000', '1.5')

--THÁNG N?M
CREATE TABLE THANGNAM
(
	MaThang CHAR(2) PRIMARY KEY,
	Thang NVARCHAR(20),
)
GO
INSERT INTO THANGNAM (MaThang, Thang) VALUES ('06', N'Tháng sáu')

--CHI TI?T BÁO CÁO DOANH S? THEO THÁNG
CREATE TABLE CTBCDS
(
	MaCTBCDS CHAR(5) PRIMARY KEY,
	MaHD CHAR(5),
	MaLoaiPhong CHAR(4),
	MaThang CHAR(2),
	DoanhThu MONEY,
	TyLe FLOAT,
	FOREIGN KEY (MaThang) REFERENCES THANGNAM(MaThang),

)
GO

INSERT INTO CTBCDS (MaCTBCDS, MaHD, MaLoaiPhong, MaThang, DoanhThu, TyLe) VALUES ('BC01', 'HD001', 'LP01', '06', '487500','0')
INSERT INTO CTBCDS (MaCTBCDS, MaHD, MaLoaiPhong, MaThang, DoanhThu, TyLe) VALUES ('BC02', 'HD002', 'LP03', '06', '1500000','0')

--THAM SO
CREATE TABLE THAMSO
(
	SoLuongKhachToiDa INT,
)

INSERT INTO THAMSO (SoLuongKhachToiDa) VALUES ('3')

GO
CREATE PROC USP_GetRoomList
AS  SELECT * FROM hr.PHONG
GO

EXEC  USP_GetRoomList


GO
CREATE PROC  USP_GetRoomListByRoomName
@roomName CHAR(5)
AS  
Begin
SELECT * FROM hr.PHONG Where TenPhong = @roomName
End
GO

EXEC USP_GetRoomListByRoomName @roomName = N'0101'

CREATE PROC  USP_GetRoomInFo
@ID int
AS  
Begin
SELECT TenPhong AS N'TÊN PHÒNG', TenLoaiPhong AS N'LOẠI PHÒNG', NgayBDThue AS N'NGÀY THUÊ', DonGia AS N'GIÁ PHÒNG', HOTEN AS N'HỌ TÊN', TenLK AS N'LOẠI KHÁCH', NgaySinh AS N'NGÀY SINH', CMND, Email AS EMAIL ,DiaChi AS N'ĐỊA CHỈ'
FROM PHIEUTHUE join CTPT on PHIEUTHUE.MaPT = CTPT.MaPT
						join hr.PHONG on PHIEUTHUE.MaPhong = hr.PHONG.MaPhong
						join KHACHHANG on CTPT.MaKH = KHACHHANG.MaKH
						join hr.LOAIPHONG on hr.PHONG.MaLoaiPhong = hr.LOAIPHONG.MaLoaiPhong
						join LOAIKHACH on KHACHHANG.MaLK = LOAIKHACH.MaLK
Where hr.PHONG.MaPhong = @ID
End
GO
EXEC USP_GetRoomInFo @ID = N'1'


CREATE PROC  USP_GETCATEGORYROOM
@category CHAR(4)
AS  
Begin
SELECT TenLoaiPhong FROM hr.LoaiPhong where MaLoaiPhong = @category
End
GO
EXEC USP_GETCATEGORYROOM  @category = N'1'


CREATE PROC USP_GetCategoryRoomList
AS  SELECT * FROM hr.LOAIPHONG
GO

EXEC  USP_GetCategoryRoomList

CREATE PROC USP_DeleteRoom
@ID int
AS  DELETE FROM hr.PHONG
WHERE MaPhong = @ID

GO

EXEC  USP_DeleteRoom  @ID ='3'

CREATE PROC USP_UpdateRoom
@ID int, @NAME  VARCHAR(20)
AS  UPDATE hr.PHONG 
SET TenPhong = @NAME
WHere MaPhong = @ID
GO

EXEC  USP_UpdateRoom  @ID ='10', @NAME ='lo'

CREATE PROC USP_UpdateCategoryRoom
@ID int, @category  int
AS  UPDATE hr.PHONG
SET MaLoaiPhong = @category
WHere MaPhong = @ID
GO

EXEC   USP_UpdateCategoryRoom  @ID ='10', @category ='2'

CREATE PROC USP_UpdatePrice
@ID int, @price  money
AS  UPDATE hr.LOAIPHONG
SET DonGia = @price
WHere MaLoaiPhong= @ID
GO

EXEC   USP_UpdatePrice @ID ='3', @price  ='200000'

CREATE PROC  USP_GetPriceByCategory
@NameCategory VARCHAR(40)
AS  
Begin
SELECT DonGia FROM hr.LoaiPhong where TenLoaiPhong = @NameCategory
End
GO
EXEC USP_GetPriceByCategory  @NameCategory = N'Standard'

CREATE PROC  USP_GetIDByCategory
@NameCategory VARCHAR(40)
AS  
Begin
SELECT MaLoaiPhong FROM hr.LoaiPhong where TenLoaiPhong = @NameCategory
End
GO
EXEC USP_GetIDByCategory  @NameCategory = N'Suite'

CREATE PROC USP_GetBill
( @MaHD CHAR(5))
AS 
Begin 
SELECT MaHD AS N'Mã Hóa Đơn',TenPhong AS N'TÊN PHÒNG', TenLoaiPhong AS N'LOẠI PHÒNG', NgayBDThue AS N'Ngày thuê', TenLK AS N'Tên loại khách', HoTen AS N'Ten Khách hàng', SoKhach AS N'Sô lượng khách', SoNgayThue AS N'Số ngày thuê'
FROM HOADON    JOIN PHIEUTHUE ON PHIEUTHUE.MaPT = HOADON.MaPT
				JOIN CTPT ON PHIEUTHUE.MaPT = CTPT.MaPT	
				JOIN hr.PHONG ON PHIEUTHUE.MaPhong = hr.PHONG.MaPhong
				JOIN KHACHHANG  ON CTPT.MaKH = KHACHHANG.MaKH
				JOIN hr.LOAIPHONG ON hr.PHONG.MaLoaiPhong = hr.LOAIPHONG.MaLoaiPhong
				JOIN LOAIKHACH ON KHACHHANG.MaLK = LOAIKHACH.MaLK
				
WHERE HOADON.MaHD = @MaHD
END
GO
EXEC USP_GetBill @MaHD = N'HD001'

--DROP PROC USP_GetBill
