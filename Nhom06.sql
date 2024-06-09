CREATE DATABASE QuanLyBanVeMayBay
GO

USE QuanLyBanVeMayBay
GO

/* Tạo các bảng */

CREATE TABLE NguoiDung(
	MaNguoiDung int identity(1,1), 
	HoTen nvarchar(100) not null, 
	MatKhau nvarchar(100) not null,
	SoDienThoai nvarchar(100) not null,
	Email nvarchar(100) not null,
	NumOfRole int not null DEFAULT 1,
	CONSTRAINT PK_NguoiDung PRIMARY KEY (MaNguoiDung),
	CONSTRAINT UNQ_SoDienThoaiNguoiDung UNIQUE (SoDienThoai),
	CONSTRAINT UNQ_EmailNguoiDung UNIQUE (Email)
)
GO

CREATE TABLE KhachHangTreEm(
	MaTreEm int identity(1,1), 
	HoTen nvarchar(100) not null, 
	GioiTinh nvarchar(100) not null, 
	NgaySinh date not null, 
	MaVe int,
	CONSTRAINT PK_KhachHangTreEm PRIMARY KEY (MaTreEm)
)
GO

CREATE TABLE KhachHangNguoiLon(
	MaNguoiLon int identity(1,1), 
	HoTen nvarchar(100) not null, 
	GioiTinh nvarchar(100) not null, 
	NgaySinh date not null, 
	SoDienThoai nvarchar(100) not null, 
	Email nvarchar(100) not null, 
	DiaChi nvarchar(100), 
	MaVe int,
	CONSTRAINT PK_KhachHangNguoiLon PRIMARY KEY(MaNguoiLon)
)
GO

CREATE TABLE ChuyenBay(
	MaChuyenBay int identity(1, 1), 
	LoaiChuyenBay nvarchar(100) not null, 
	DiemDi nvarchar(100) not null, 
	DiemDen nvarchar(100) not null, 
	ThoiGianDi datetime not null, 
	ThoiGianDuKienDen datetime not null, 
	TinhTrangChuyenBay nvarchar(100) not null, 
	ChiPhi float not null,
	CONSTRAINT PK_MaChuyenBay PRIMARY KEY (MaChuyenBay)
)
GO

CREATE TABLE NguoiDung_Mua_VeMayBay(
	MaVe int, 
	MaNguoiDung int not null, 
	ThoiGianMua datetime not null,
	CONSTRAINT PK_NguoiDungMua PRIMARY KEY (MaVe)
)
GO

CREATE TABLE NguoiDung_Huy_VeMayBay(
	MaVe int, 
	MaNguoiDung int not null,
	ThoiGianHuy datetime not null,
	CONSTRAINT PK_NguoiDungHuy PRIMARY KEY (MaVe)
)
GO

CREATE TABLE HoaDon(
	MaHoaDon int identity(1, 1), 
	Thue float not null default 0.05,
	TongTien float not null, 
	ThoiGianThanhToan datetime not null,
	CONSTRAINT PK_MaHoaDon PRIMARY KEY(MaHoaDon)
)
GO

CREATE TABLE VeMayBay(
	MaVe int identity(1, 1), 
	ChoNgoi nvarchar(100) not null,
	HangVe nvarchar(100) not null,
	GiaVe float not null,
	KhoiLuongHanhLy float not null, 
	TinhTrangVe nvarchar(100) not null,
	MaHoaDon int,
	MaGoi int,
	CONSTRAINT PK_MaVe PRIMARY KEY(MaVe)
)
GO

CREATE TABLE GoiHanhLy(
	MaGoi int identity(1, 1), 
	KhoiLuongMuaThem float not null, 
	GiaTien float not null,
	CONSTRAINT PK_MaGoi PRIMARY KEY(MaGoi)
)
GO

CREATE TABLE MayBay(
	MaMaybay int identity(1, 1), 
	TenMayBay nvarchar(100) not null, 
	HangSanXuat nvarchar(100) not null,
	CONSTRAINT PK_MaMaybay PRIMARY KEY(MaMaybay)
)
GO

CREATE TABLE KhachHangNguoiLon_QuanLy_KhachHangTreEm (
    MaNguoiLon int,
    MaTreEm int,
    CONSTRAINT PK_KhachHangQuanLy PRIMARY KEY(MaNguoiLon, MaTreEm)
)
GO

CREATE TABLE MayBay_KhoiTao_ChuyenBay (
    MaChuyenBay int,
    MaMayBay int not null,
    ThoiGianKhoiTao datetime not null,
    CONSTRAINT PK_MayBayKhoiTao PRIMARY KEY(MaChuyenBay)
)
GO

CREATE TABLE ChuyenBay_PhatHanh_VeMayBay (
    MaVe int,
    MaChuyenBay int not null,
    ThoiGianPhatHanh datetime not null,
    CONSTRAINT PK_ChuyenBayPhatHanh PRIMARY KEY(MaVe)
)
GO

/* Tạo các ràng buộc khóa ngoại */

ALTER TABLE KhachHangTreEm 
ADD CONSTRAINT FK_TreEm_VeMayBay 
FOREIGN KEY (MaVe) REFERENCES VeMayBay(MaVe)
GO

ALTER TABLE KhachHangNguoiLon 
ADD CONSTRAINT FK_NguoiLon_VeMayBay 
FOREIGN KEY (MaVe) REFERENCES VeMayBay(MaVe)
GO

ALTER TABLE VeMayBay 
ADD CONSTRAINT FK_VeMayBay_HoaDon 
FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
GO

ALTER TABLE VeMayBay 
ADD CONSTRAINT FK_VeMayBay_GoiHanhLy 
FOREIGN KEY (MaGoi) REFERENCES GoiHanhLy(MaGoi)
GO

ALTER TABLE NguoiDung_Mua_VeMayBay
ADD CONSTRAINT FK_MuaVe
FOREIGN KEY (MaVe) REFERENCES VeMayBay(MaVe)
GO

ALTER TABLE NguoiDung_Mua_VeMayBay
ADD CONSTRAINT FK_NguoiDungMua 
FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
GO

ALTER TABLE NguoiDung_Huy_VeMayBay
ADD CONSTRAINT FK_HuyVe
FOREIGN KEY (MaVe) REFERENCES VeMayBay(MaVe)
GO

ALTER TABLE NguoiDung_Huy_VeMayBay
ADD CONSTRAINT FK_NguoiDungHuy 
FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
GO

ALTER TABLE KhachHangNguoiLon_QuanLy_KhachHangTreEm
ADD CONSTRAINT FK_NguoiLonQuanLy 
FOREIGN KEY (MaNguoiLon) REFERENCES KhachHangNguoiLon (MaNguoiLon)
GO

ALTER TABLE KhachHangNguoiLon_QuanLy_KhachHangTreEm
ADD CONSTRAINT FK_QuanLyTreEm
FOREIGN KEY (MaTreEm) REFERENCES KhachHangTreEm (MaTreEm)
GO

ALTER TABLE MayBay_KhoiTao_ChuyenBay
ADD CONSTRAINT FK_KhoiTaoChuyenBay
FOREIGN KEY (MaChuyenBay) REFERENCES ChuyenBay (MaChuyenBay)
GO

ALTER TABLE MayBay_KhoiTao_ChuyenBay
ADD CONSTRAINT FK_MayBayKhoiTao
FOREIGN KEY (MaMayBay) REFERENCES MayBay (MaMayBay)
GO

ALTER TABLE ChuyenBay_PhatHanh_VeMayBay
ADD CONSTRAINT FK_PhatHanhVeMayBay
FOREIGN KEY (MaVe) REFERENCES VeMayBay (MaVe)
GO

ALTER TABLE ChuyenBay_PhatHanh_VeMayBay
ADD CONSTRAINT FK_ChuyenBayPhatHanh
FOREIGN KEY (MaChuyenBay) REFERENCES ChuyenBay (MaChuyenBay)
GO

/* Tạo views */

CREATE VIEW view_ThongTinHoaDon 
AS
	SELECT 
		V.MaVe,
		V.ChoNgoi,
		V.GiaVe,
		V.KhoiLuongHanhLy,
		V.TinhTrangVe,
		G.MaGoi,
		G.KhoiLuongMuaThem,
		G.GiaTien,
		H.MaHoaDon,
		H.TongTien,
		H.Thue,
		H.ThoiGianThanhToan,
		C.MaChuyenBay,
		C.LoaiChuyenBay, 
		C.DiemDi, 
		C.DiemDen,
		C.ThoiGianDi, 
		C.ThoiGianDuKienDen,
		C.TinhTrangChuyenBay
	FROM 
		VeMayBay AS V
	JOIN 
		GoiHanhLy AS G ON V.MaGoi = G.MaGoi
	JOIN 
		HoaDon AS H ON V.MaHoaDon = H.MaHoaDon
	JOIN 
		ChuyenBay_PhatHanh_VeMayBay P ON V.MaVe = P.MaVe
	JOIN 
		ChuyenBay AS C ON C.MaChuyenBay = P.MaChuyenBay
GO

CREATE FUNCTION tracuu_HoaDon_FUNC(@MaHoaDon int)
RETURNS table
AS
	RETURN (SELECT *
			FROM view_ThongTinHoaDon
			WHERE MaHoaDon = @MaHoaDon)
GO

-- Doanh thu 

CREATE VIEW view_DoanhThu
AS
	SELECT *
	FROM HoaDon
GO

CREATE FUNCTION lay_DoanhThuTheoThang_FUNC(@nam int)
RETURNS table
AS
	RETURN (
			SELECT MONTH(ThoiGianThanhToan) as Thang, 
				   SUM(TongTien - TongTien * Thue) as DoanhThu
			FROM view_DoanhThu
			WHERE YEAR(ThoiGianThanhToan) = @nam
			GROUP BY MONTH(ThoiGianThanhToan)
	)
GO

CREATE FUNCTION lay_Nam_FUNC()
RETURNS table
AS
	RETURN (
			SELECT DISTINCT YEAR(ThoiGianThanhToan) as Nam 
			FROM view_DoanhThu
	)
GO

-- --0 - 2 - 9 (4) Cập nhập chuyến bay - Tra cứu chuyến bay - Đề xuất các chuyến bay

CREATE VIEW view_ThongTinMayBay
AS 
	SELECT *
	FROM MayBay
GO

CREATE FUNCTION lay_MaMayBay_FUNC()
RETURNS table
AS
	RETURN(
		SELECT MaMaybay
		FROM view_ThongTinMayBay
	)
GO

CREATE VIEW view_ThongTinVeMayBay
AS
	SELECT ChuyenBay.MaChuyenBay,
			VeMayBay.HangVe,
			VeMayBay.GiaVe, 
			VeMayBay.TinhTrangVe,
			COUNT(*) SoVe
	FROM ChuyenBay
		JOIN ChuyenBay_PhatHanh_VeMayBay 
			ON ChuyenBay.MaChuyenBay = ChuyenBay_PhatHanh_VeMayBay.MaChuyenBay
		JOIN VeMayBay 
			ON ChuyenBay_PhatHanh_VeMayBay.MaVe = VeMayBay.MaVe
	GROUP BY ChuyenBay.MaChuyenBay,
			VeMayBay.HangVe,
			VeMayBay.GiaVe, 
			VeMayBay.TinhTrangVe
GO

CREATE FUNCTION lay_SoLuongVeConLai_FUNC(@MaChuyenBay int, @HangVe nvarchar(100))
RETURNS int
AS
BEGIN
	DECLARE @SoVeConLai int

	SELECT @SoVeConLai = SoVe
	FROM view_ThongTinVeMayBay
	WHERE TinhTrangVe LIKE N'chưa bán' 
		AND MaChuyenBay = @MaChuyenBay
		AND HangVe LIKE @HangVe

	RETURN @SoVeConLai
END 
GO	

CREATE FUNCTION lay_GiaVeTheoHangVe_FUNC(@MaChuyenBay int, @HangVe nvarchar(100))
RETURNS float
AS
BEGIN
	DECLARE @GiaVeTheoHang float

	SELECT @GiaVeTheoHang = GiaVe
	FROM view_ThongTinVeMayBay
	WHERE MaChuyenBay = @MaChuyenBay
		AND HangVe LIKE @HangVe

	RETURN @GiaVeTheoHang 
END
GO

CREATE VIEW view_ThongTinChuyenBay 
AS
	SELECT 
		CB.MaChuyenBay,
		CB.LoaiChuyenBay, 
		CB.DiemDi,
		CB.DiemDen,
		CB.ThoiGianDi,
		CB.ThoiGianDuKienDen,
		CB.TinhTrangChuyenBay,
		CB.ChiPhi,
		MB.MaMaybay, 
		MB.TenMayBay,
		(SELECT dbo.lay_SoLuongVeConLai_FUNC(CB.MaChuyenBay, N'phổ thông')) SoVeConLaiPhoThong,
		(SELECT dbo.lay_GiaVeTheoHangVe_FUNC(CB.MaChuyenBay, N'phổ thông')) GiaVePhoThong,
		(SELECT dbo.lay_SoLuongVeConLai_FUNC(CB.MaChuyenBay, N'thương gia')) SoVeConLaiThuongGia,
		(SELECT dbo.lay_GiaVeTheoHangVe_FUNC(CB.MaChuyenBay, N'thương gia')) GiaVeThuongGia
	FROM ChuyenBay AS CB
		JOIN MayBay_KhoiTao_ChuyenBay MB_CB
			ON CB.MaChuyenBay = MB_CB.MaChuyenBay
		JOIN MayBay AS MB
			ON MB_CB.MaMayBay = MB.MaMaybay
	GROUP BY 
		CB.MaChuyenBay,
		CB.LoaiChuyenBay, 
		CB.DiemDi,
		CB.DiemDen,
		CB.ThoiGianDi,
		CB.ThoiGianDuKienDen,
		CB.TinhTrangChuyenBay,
		CB.ChiPhi,
		MB.MaMaybay, 
		MB.TenMayBay
GO

--

CREATE FUNCTION lay_DiemDi()
RETURNS TABLE
AS 
	RETURN (
		SELECT DISTINCT DiemDi
		FROM view_ThongTinChuyenBay
	)
GO

CREATE FUNCTION lay_DiemDen()
RETURNS TABLE
AS 
	RETURN (
		SELECT DISTINCT DiemDen
		FROM view_ThongTinChuyenBay
	)
GO

CREATE FUNCTION lay_TinhTrang()
RETURNS TABLE
AS
	RETURN (
		SELECT DISTINCT TinhTrangChuyenBay
		FROM view_ThongTinChuyenBay
	)
GO

--

CREATE FUNCTION lay_DeXuatChuyenBay_FUNC(
	@SoLuongDeXuat int,
	@DiemDi nvarchar(100),
	@DiemDen nvarchar(100),
	@NganSach float)
RETURNS TABLE
AS
	RETURN(
		SELECT TOP (@SoLuongDeXuat) *
		FROM view_ThongTinChuyenBay
		WHERE SoVeConLaiPhoThong IS NOT NULL 
			AND SoVeConLaiThuongGia IS NOT NULL
			AND (@DiemDi IS NULL OR DiemDi LIKE @DiemDi)
			AND (@DiemDen IS NULL OR DiemDen LIKE @DiemDen)
			AND (@NganSach IS NULL OR GiaVePhoThong <= @NganSach)
		ORDER BY (SoVeConLaiPhoThong + SoVeConLaiThuongGia) ASC
	)
GO

--

CREATE FUNCTION timkiem_ChuyenBay_FUNC (
	@DiemDi nvarchar(100), 
	@DiemDen nvarchar(100), 
	@NgayDi datetime, 
	@TinhTrangChuyenBay nvarchar(50)
)
RETURNS TABLE 
AS
	RETURN (
		SELECT *
		FROM view_ThongTinChuyenBay
		WHERE (@NgayDi IS NULL OR DATEDIFF(day, CAST(ThoiGianDi AS DATE), @NgayDi) = 0)
		  AND (@DiemDi IS NULL OR DiemDi LIKE @DiemDi)
		  AND (@DiemDen IS NULL OR DiemDen LIKE @DiemDen)
		  AND (@TinhTrangChuyenBay IS NULL OR TinhTrangChuyenBay LIKE @TinhTrangChuyenBay)
	)
GO

--4 + 3 Tìm kiếm vé máy bay

CREATE FUNCTION timkiem_VeMayBay_FUNC(
	@DiemDi nvarchar(100), 
	@DiemDen nvarchar(100), 
	@NgayDi date, 
	@SoHanhKhach int
)
RETURNs table
AS
	RETURN(
	SELECT * FROM view_ThongTinChuyenBay
	WHERE SoVeConLaiPhoThong IS NOT NULL 
		AND SoVeConLaiThuongGia IS NOT NULL
		AND DiemDi LIKE @DiemDi 
		AND DiemDen LIKE @DiemDen 
		AND DATEDIFF(day, CAST(ThoiGianDi AS DATE), @NgayDi) = 0 
		AND @SoHanhKhach <= (SoVeConLaiPhoThong + SoVeConLaiThuongGia)
	)
GO

--5 - Lấy gói hành lý

CREATE VIEW view_GoiHanhLy 
AS
	SELECT * FROM GoiHanhLy
GO

CREATE FUNCTION lay_GoiHanhLy_FUNC()
RETURNS table
AS
	RETURN(
		SELECT * 
		FROM view_GoiHanhLy
	)
GO

CREATE PROC them_GoiHanhLy_PROC @MaGoiHanhLy INT, @MaVe INT
AS
	BEGIN
		UPDATE VeMayBay
		SET MaGoi = @MaGoiHanhLy
		WHERE MaVe = @MaVe
	END
GO

--6 + 7 - Lấy danh sách chỗ ngồi
CREATE VIEW view_ThongTinChoNgoiChuyenBay
AS
	SELECT CB.MaChuyenBay, VB.MaVe, VB.HangVe, VB.GiaVe, VB.ChoNgoi, VB.TinhTrangVe
	FROM ChuyenBay CB
	join ChuyenBay_PhatHanh_VeMayBay as PH on CB.MaChuyenBay = PH.MaChuyenBay
	join VeMayBay as VB on PH.MaVe = VB.MaVe
GO

CREATE FUNCTION lay_DanhSachChoNgoi_FUNC (@MaChuyenBay int)
RETURNS table
AS
	RETURN (
			SELECT * FROM view_ThongTinChoNgoiChuyenBay
			WHERE MaChuyenBay = @MaChuyenBay
	)
GO

 --8 - Tìm kiếm thông tin cá nhân của người dùng + Lịch sử giao dịch
 CREATE VIEW view_ThongTinCaNhan
 AS 
	SELECT MaNguoiDung, HoTen, SoDienThoai, Email, MatKhau, NumOfRole
	FROM NguoiDung
GO

CREATE FUNCTION timkiem_ThongTinCaNhan_FUNC(@MaNguoiDung int)
RETURNS table
AS
	RETURN(
		SELECT * 
		FROM view_ThongTinCaNhan
		WHERE MaNguoiDung = @MaNguoiDung
	)
GO

CREATE VIEW view_LichSuGiaoDich 
AS
	SELECT ND.MaNguoiDung, ND.HoTen, ND.SoDienThoai, ND.Email, ND.NumOfRole,
		HD.MaHoaDon, HD.TongTien, HD.ThoiGianThanhToan, COUNT(VB.MaVe) as SoLuongVe
	FROM NguoiDung ND
		JOIN NguoiDung_Mua_VeMayBay MV ON ND.MaNguoiDung = MV.MaNguoiDung 
		JOIN VeMayBay VB ON MV.MaVe = VB.MaVe
		JOIN HoaDon HD ON VB.MaHoaDon = HD.MaHoaDon
	GROUP BY ND.MaNguoiDung, ND.HoTen, ND.SoDienThoai, ND.Email, ND.NumOfRole,
		HD.MaHoaDon, HD.TongTien, HD.ThoiGianThanhToan
GO

CREATE FUNCTION timkiem_LichSuGiaoDich_FUNC(@SoDienThoai nvarchar(100))
RETURNS table
AS
	RETURN(
		SELECT * FROM view_LichSuGiaoDich
		WHERE SoDienThoai LIKE @SoDienThoai
	)
GO

/* Tạo triggers */

--0 - Kiểm tra trùng chuyến bay
CREATE TRIGGER trigger_ins_upd_ChuyenBayHopLe
ON ChuyenBay
AFTER INSERT, UPDATE
AS
	BEGIN
		-- Kiểm tra chuyen bay vừa thêm có bị trùng gio bay hay khong
		DECLARE @ThoiGianDi datetime, @ThoiGianDuKienDen datetime
		SELECT @ThoiGianDi = ne.ThoiGianDi, @ThoiGianDuKienDen = ne.ThoiGianDuKienDen
		FROM inserted ne

		IF DATEDIFF(MINUTE,@ThoiGianDi, @ThoiGianDuKienDen) < 15 
		OR DATEDIFF(MINUTE, GETDATE(), @ThoiGianDi) < 15
			BEGIN
				RAISERROR (N'Thời gian khởi hành chuyến bay không hợp lệ!', 16, 1) 
				ROLLBACK;
			END

		IF EXISTS (SELECT * 
				FROM inserted ne
				WHERE EXISTS (SELECT * FROM ChuyenBay cb 
							WHERE cb.DiemDen LIKE ne.DiemDen 
							AND cb.LoaiChuyenBay LIKE ne.LoaiChuyenBay
							AND cb.DiemDi LIKE ne.DiemDi 
							AND cb.ThoiGianDi = ne.ThoiGianDi
							AND cb.ThoiGianDuKienDen = ne.ThoiGianDuKienDen
							AND cb.MaChuyenBay <> ne.MaChuyenBay))
		 BEGIN
			 -- Nếu trùng thì rollback
			 -- RAISEERROR (message_string, severity, state)
			 RAISERROR (N'Chuyến bay bị trùng', 16, 1)
			 ROLLBACK;
		 END
	END
GO

--Kiem tra so dien khoai trung khi dang ky tai khoan
CREATE TRIGGER trigger_ins_upd_DangKyTaiKhoan
ON NguoiDung
AFTER INSERT, UPDATE
AS
BEGIN
BEGIN TRY
	-- Kiểm tra số điện thoại vừa thêm có bị trùng lặp
	IF EXISTS (SELECT * FROM inserted ne
			 WHERE EXISTS ( SELECT *
							 FROM NguoiDung nd
							 WHERE nd.SoDienThoai LIKE ne.SoDienThoai 
							 AND nd.MaNguoiDung <> ne.MaNguoiDung))
		 BEGIN
			RAISERROR (N'Số điện thoại này đã được sử dụng bởi tài khoản khác', 16, 1)
		 END

	DECLARE @SoDienThoai nvarchar(100), @MatKhau nvarchar(100), @NumOfRole int
	SELECT @SoDienThoai=SoDienThoai, @MatKhau=MatKhau, @NumOfRole=NumOfRole
	FROM inserted

	DECLARE @sqlString nvarchar(2000)
	SET @sqlString= 'CREATE LOGIN [' + @SoDienThoai +'] WITH PASSWORD='''+ @MatKhau +''', 
		DEFAULT_DATABASE=[QuanLyBanVeMayBay], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF'
	EXEC (@sqlString)

	SET @sqlString= 'CREATE USER [' + @SoDienThoai +'] FOR LOGIN [' + @SoDienThoai +']'
	EXEC (@sqlString)

	IF @NumOfRole = 5
		SET @sqlString = 'ALTER SERVER ROLE sysadmin' + ' ADD MEMBER [' + @SoDienThoai +']'
	ELSE
		SET @sqlString = 'ALTER ROLE NguoiDungApp ADD MEMBER [' + @SoDienThoai +']'
	EXEC (@sqlString)
END TRY
BEGIN CATCH
	ROLLBACK
	DECLARE @ERMES NVARCHAR(100) 
	SET @ERMES = ERROR_MESSAGE()
	RAISERROR (@ERMES, 16, 1)
END CATCH
END
GO

CREATE PROCEDURE dangky_TaiKhoan_PROC 
	@HoTen nvarchar(100), 
	@SoDienThoai nvarchar(100),
	@Email nvarchar(100),
	@MatKhau nvarchar(100)
AS
BEGIN 
	INSERT INTO NguoiDung (SoDienThoai, HoTen, MatKhau, Email)
	VALUES (@SoDienThoai, @HoTen, @MatKhau, @Email)
END
GO

CREATE FUNCTION kiemtra_DangNhap_FUNC(@SoDienThoai nvarchar(100), @MatKhau nvarchar(100))
RETURNS @Connection table (
		stringConnection nvarchar(2000) NOT NULL, 
		NumOfRole int NOT NULL, 
		MaNguoiDung int NOT NULL
)
AS
BEGIN
	DECLARE @NumOfRole int, @MaNguoiDung int
	SELECT @NumOfRole = NumOfRole, @MaNguoiDung = MaNguoiDung
	FROM view_ThongTinCaNhan
	WHERE SoDienThoai LIKE @SoDienThoai AND MatKhau LIKE @MatKhau
	
	DECLARE @stringConnectionAdmin nvarchar(2000)
	SET @stringConnectionAdmin = 'Data Source=localhost;Initial Catalog=QuanLyBanVeMayBay;Integrated Security=True'

	DECLARE @stringConnectionUser nvarchar(2000)
	SET @stringConnectionUser = 'Data Source=localhost;Initial Catalog=QuanLyBanVeMayBay;' + 'User Id=' + @SoDienThoai + ';Password=' + @MatKhau + ';'

	IF @NumOfRole = 5
		INSERT INTO @Connection VALUES (@stringConnectionAdmin, @NumOfRole, @MaNguoiDung)
	ELSE IF @NumOfRole = 1
		INSERT INTO @Connection VALUES (@stringConnectionUser, @NumOfRole, @MaNguoiDung)
	ELSE 
		INSERT INTO @Connection VALUES ('0', 0, 0)
	RETURN
END
GO

CREATE PROCEDURE phathanh_VeMayBay_PROC
    @GiaVeThuongGia float,
    @GiaVePhoThong float,
    @KhoiLuongHanhLy float,
    @MaChuyenBay int 
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION TRANS_KhoiTaoVeMayBay
	-- Kiểm tra chuyến bay đã phát hành vé chưa
	IF EXISTS (SELECT * 
				FROM view_ThongTinChuyenBay 
				WHERE MaChuyenBay = @MaChuyenBay
				AND GiaVePhoThong IS NOT NUll 
				AND GiaVeThuongGia IS NOT NULL)
		BEGIN
			RAISERROR (N'Chuyến bay này đã phát hành vé', 16, 1)
		END

	-- Kiểm tra chuyến bay có tồn tại không
	IF NOT EXISTS (SELECT * 
					FROM view_ThongTinChuyenBay 
					WHERE MaChuyenBay = @MaChuyenBay)
		BEGIN
			RAISERROR (N'Không tồn tại chuyến bay này', 16, 1)
		END

	UPDATE ChuyenBay
	SET TinhTrangChuyenBay = N'đã bán vé'
	WHERE MaChuyenBay = @MaChuyenBay

    DECLARE @i int = 1
    WHILE @i <= 40
    BEGIN
        DECLARE @j int = 1
        WHILE @j <= 4
        BEGIN
            DECLARE @HangVe nvarchar(100)
            DECLARE @GiaVe float
            DECLARE @ChoNgoi nvarchar(100) = CHAR(64 + @j) + CAST(@i AS NVARCHAR(10))
            DECLARE @MaVe int
            
			IF @i BETWEEN 1 AND 4
				BEGIN
					SET @HangVe = N'thương gia'
					SET @GiaVe = @GiaVeThuongGia
				END
            ELSE
				BEGIN
					SET @HangVe = N'phổ thông'
					SET @GiaVe = @GiaVePhoThong
				END
			
			DECLARE @Temp table (MaVe int)

			--Thêm vé máy bay
            INSERT INTO VeMayBay (ChoNgoi, HangVe, GiaVe, KhoiLuongHanhLy, TinhTrangVe, MaHoaDon, MaGoi)
            OUTPUT inserted.MaVe
            INTO @Temp (MaVe)
            VALUES (
                @ChoNgoi,
                @HangVe,
                @GiaVe,
				@KhoiLuongHanhLy,
                N'chưa bán',
                NULL,
                NULL
            )

            SELECT @MaVe = MaVe FROM @Temp;

            -- Thêm chuyến bay phát hành vé máy bay
            INSERT INTO ChuyenBay_PhatHanh_VeMayBay (MaVe, MaChuyenBay, ThoiGianPhatHanh)
            VALUES (
                @MaVe,
                @MaChuyenBay, 
                GETDATE()
            )

            SET @j = @j + 1
        END
        SET @i = @i + 1
    END 
	COMMIT TRAN TRANS_KhoiTaoVeMayBay
END TRY
BEGIN CATCH
	ROLLBACK TRAN TRANS_KhoiTaoVeMayBay
	DECLARE @ERMES NVARCHAR(100) 
	SET @ERMES = ERROR_MESSAGE()
	RAISERROR (@ERMES, 16, 1)
END CATCH
END
GO

CREATE PROCEDURE khoitao_ChuyenBay_PROC
    @MaMayBay int,
    @MaChuyenBay int
AS
BEGIN
    INSERT INTO MayBay_KhoiTao_ChuyenBay (MaChuyenBay, MaMayBay, ThoiGianKhoiTao)
    VALUES (@MaChuyenBay, @MaMayBay, GETDATE())
END
GO

--1 - Cập nhập thông tin chuyến bay

CREATE PROC them_ChuyenBay_PROC
	@MaChuyenBay int output,
	@LoaiChuyenBay nvarchar(100),
	@DiemDi nvarchar(100),
	@DiemDen nvarchar(100),
	@ThoiGianDi datetime,
	@ThoiGianDuKienDen datetime,
	@TinhTrangChuyenBay nvarchar(100),
	@ChiPhi float
AS
	BEGIN
		DECLARE @Temp table (MaChuyenBay int)
		
		INSERT INTO ChuyenBay(LoaiChuyenBay, DiemDi, DiemDen, ThoiGianDi, ThoiGianDuKienDen, TinhTrangChuyenBay, ChiPhi)
		OUTPUT inserted.MaChuyenBay INTO @Temp
		VALUES(@LoaiChuyenBay, @DiemDi, @DiemDen, @ThoiGianDi, @ThoiGianDuKienDen, @TinhTrangChuyenBay, @ChiPhi)
	
		SELECT @MaChuyenBay = MaChuyenBay
		FROM @Temp
	END
GO

CREATE PROCEDURE capnhat_ThongTinChuyenBay_PROC
    @MaChuyenBay INT,
    @TinhTrangChuyenBay NVARCHAR(255),
    @ThoiGianDi DATETIME,
    @ThoiGianDuKienDen DATETIME, 
	@GiaVePhoThong float,
	@GiaVeThuongGia float
AS
BEGIN
BEGIN TRY
	BEGIN TRAN TRANS_CapNhapThongTinChuyenBay

    UPDATE ChuyenBay
    SET TinhTrangChuyenBay = @TinhTrangChuyenBay,
        ThoiGianDi = @ThoiGianDi,
        ThoiGianDuKienDen = @ThoiGianDuKienDen
    WHERE MaChuyenBay = @MaChuyenBay

	UPDATE VeMayBay
	SET GiaVe = @GiaVePhoThong
	FROM VeMayBay
		JOIN ChuyenBay_PhatHanh_VeMayBay ON VeMayBay.MaVe = ChuyenBay_PhatHanh_VeMayBay.MaVe
	WHERE ChuyenBay_PhatHanh_VeMayBay.MaChuyenBay = @MaChuyenBay
		AND VeMayBay.HangVe = N'phổ thông'

	UPDATE VeMayBay
	SET GiaVe = @GiaVeThuongGia
	FROM VeMayBay
		JOIN ChuyenBay_PhatHanh_VeMayBay ON VeMayBay.MaVe = ChuyenBay_PhatHanh_VeMayBay.MaVe
	WHERE ChuyenBay_PhatHanh_VeMayBay.MaChuyenBay = @MaChuyenBay
		AND VeMayBay.HangVe = N'thương gia'

	COMMIT TRAN TRANS_CapNhapThongTinChuyenBay
END TRY
BEGIN CATCH
	ROLLBACK TRAN TRANS_CapNhapThongTinChuyenBay
	DECLARE @ERMES NVARCHAR(100) 
	SET @ERMES = ERROR_MESSAGE()
	RAISERROR (@ERMES, 16, 1)
END CATCH
END
GO

--2 4 5 6 7 8 - Thanh toán

CREATE TRIGGER trigger_ins_KhachHangNguoiLon
ON KhachHangNguoiLon
AFTER INSERT
AS
BEGIN
	DECLARE @MaVe int 
	SELECT @MaVe = MaVe
	FROM inserted
	
	DECLARE @TinhTrangVe nvarchar(100)
	SELECT @TinhTrangVe = TinhTrangVe
	FROM VeMayBay
	WHERE MaVe = @MaVe

	DECLARE @NgaySinh date
	SELECT @NgaySinh = NgaySinh
	FROM inserted

	IF DATEDIFF(DAY, GETDATE(), @NgaySinh) >= 5110
		BEGIN
			-- RAISEERROR (message_string, severity, state)
			RAISERROR (N'Tuổi không hợp lệ', 16, 1)
			ROLLBACK;
		END
	ELSE IF @TinhTrangVe LIKE N'đã bán'
		BEGIN
			-- RAISEERROR (message_string, severity, state)
			RAISERROR (N'Vé này đã được mua bởi khách hàng khác', 16, 1)
			ROLLBACK;
		END
	ELSE
		UPDATE VeMayBay
		SET TinhTrangVe = N'đã bán'
		WHERE MaVe = @MaVe
END
GO

CREATE TRIGGER trigger_ins_KhachHangTreEm
ON KhachHangTreEm
AFTER INSERT
AS
BEGIN
	DECLARE @MaVe int 
	SELECT @MaVe = MaVe
	FROM inserted
	
	DECLARE @TinhTrangVe nvarchar(100)
	SELECT @TinhTrangVe = TinhTrangVe
	FROM VeMayBay
	WHERE MaVe = @MaVe

	DECLARE @NgaySinh date
	SELECT @NgaySinh = NgaySinh
	FROM inserted

	IF DATEDIFF(DAY, GETDATE(), @NgaySinh) < 5110
		BEGIN
			-- RAISEERROR (message_string, severity, state)
			RAISERROR (N'Tuổi không hợp lệ', 16, 1)
			ROLLBACK;
		END
	ELSE IF @TinhTrangVe LIKE N'đã bán'
		BEGIN
			-- RAISEERROR (message_string, severity, state)
			RAISERROR (N'Vé này đã được mua bởi khách hàng khác', 16, 1)
			ROLLBACK;
		END
	ELSE
		UPDATE VeMayBay
		SET TinhTrangVe = N'đã bán'
		WHERE MaVe = @MaVe
END
GO

CREATE PROCEDURE khoitao_HoaDon_PROC
@MaHoaDon int OUTPUT,
@Thue float OUTPUT
AS
	BEGIN
		DECLARE @Temp table (MaHoaDon int, Thue float)

		INSERT INTO HoaDon(TongTien, ThoiGianThanhToan) 
		OUTPUT inserted.MaHoaDon, inserted.Thue INTO @Temp
		VALUES(0, GETDATE())

		SELECT @MaHoaDon = MaHoaDon, @Thue = Thue
		FROM @Temp
	END
GO

CREATE PROC them_ThongTinNguoiDungMuaVe_PROC @MaVe int, @MaNguoiDung int
AS
	BEGIN
		INSERT INTO NguoiDung_Mua_VeMayBay 
		VALUES(@MaVe, @MaNguoiDung, GETDATE())
	END
GO

CREATE PROCEDURE them_ThongTinKhachHangNguoiLon_PROC 
	@HoTen nvarchar(100),
	@GioiTinh nvarchar(100),
	@NgaySinh date,
	@SoDienThoai nvarchar(100),
	@Email nvarchar(100),
	@DiaChi nvarchar(100),
	@MaVe int,
	@MaGoi int,
	@MaHoaDon int,
	@MaNguoiLon int OUTPUT
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION TRANS_KhachHangNguoiLonMuaVe

	--Thêm khách hàng 
	DECLARE @Temp table (MaNguoiLon int)

	INSERT INTO KhachHangNguoiLon(HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, MaVe) 
	OUTPUT inserted.MaNguoiLon INTO @Temp
	VALUES(@HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @Email, @DiaChi,@MaVe)

	SELECT @MaNguoiLon = MaNguoiLon
	FROM @Temp

	--Cập nhật hóa đơn 
	DECLARE @GiaVe float = 0, 
		@GiaGoi float = 0
		
	SELECT @GiaVe = GiaVe
	FROM VeMayBay
	WHERE MaVe = @MaVe

	SELECT @GiaGoi = GiaTien
	FROM GoiHanhLy
	WHERE MaGoi = @MaGoi

	UPDATE HoaDon
	SET TongTien = TongTien + (@GiaVe + @GiaGoi)*(1 + Thue)
	WHERE MaHoaDon = @MaHoaDon

	UPDATE VeMayBay
	SET MaGoi = @MaGoi, MaHoaDon = @MaHoaDon
	WHERE MaVe = @MaVe

	COMMIT TRAN TRANS_KhachHangNguoiLonMuaVe
END TRY
BEGIN CATCH
	ROLLBACK TRAN TRANS_KhachHangNguoiLonMuaVe
	DECLARE @ERMES NVARCHAR(100) 
	SET @ERMES = ERROR_MESSAGE()
	RAISERROR (@ERMES, 16, 1)
END CATCH
END
GO

CREATE PROCEDURE them_ThongTinKhachHangTreEm_PROC 
	@HoTen nvarchar(100),
	@GioiTinh nvarchar(100),
	@NgaySinh date,
	@MaVe int,
	@MaGoi int,
	@MaHoaDon int,
	@MaTreEm int OUTPUT
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION TRANS_KhachHangTreEmMuaVe

	--Thêm khách hàng
	DECLARE @Temp table (MaTreEm int)

	INSERT INTO KhachHangTreEm(HoTen, GioiTinh, NgaySinh, MaVe) 
	OUTPUT inserted.MaTreEm INTO @Temp
	VALUES(@HoTen, @GioiTinh, @NgaySinh, @MaVe)

	SELECT @MaTreEm = MaTreEm
	FROM @Temp

	--Cập nhật hóa đơn 
	DECLARE @GiaVe float = 0, 
		@GiaGoi float = 0
		
	SELECT @GiaVe = GiaVe
	FROM VeMayBay
	WHERE MaVe = @MaVe

	SELECT @GiaGoi = GiaTien
	FROM GoiHanhLy
	WHERE MaGoi = @MaGoi

	UPDATE HoaDon
	SET TongTien = TongTien + (@GiaVe + @GiaGoi)*(1 + Thue)
	WHERE MaHoaDon = @MaHoaDon

	UPDATE VeMayBay
	SET MaGoi = @MaGoi, MaHoaDon = @MaHoaDon
	WHERE MaVe = @MaVe

	COMMIT TRAN TRANS_KhachHangTreEmMuaVe
END TRY
BEGIN CATCH
	ROLLBACK TRAN TRANS_KhachHangTreEmMuaVe
	DECLARE @ERMES NVARCHAR(100) 
	SET @ERMES = ERROR_MESSAGE()
	RAISERROR (@ERMES, 16, 1)
END CATCH
END
GO

CREATE PROC them_NguoiLonQuanLyTreEm_PROC @MaNguoiLon int, @MaTreEm int
AS
	BEGIN
		INSERT INTO KhachHangNguoiLon_QuanLy_KhachHangTreEm 
		VALUES(@MaNguoiLon, @MaTreEm)
	END
GO

--9 Hủy vé

CREATE TRIGGER trigger_upd_Ve
ON VeMayBay
AFTER UPDATE
AS 
BEGIN
BEGIN TRY
	DECLARE @MaVe int,
			@GiaVe float,
			@MaHoaDon int, 
			@MaGoi int,
			@TinhTrangVeTruoc nvarchar(100),
			@TinhTrangVeSau nvarchar(100)

	SELECT @MaVe = deleted.MaVe, 
			@GiaVe = deleted.GiaVe,
			@MaHoaDon = deleted.MaHoaDon, 
			@MaGoi = deleted.MaGoi,
			@TinhTrangVeTruoc = deleted.TinhTrangVe,
			@TinhTrangVeSau = inserted.TinhTrangVe
	FROM inserted, deleted

	IF @TinhTrangVeSau LIKE N'chưa bán' AND @TinhTrangVeTruoc LIKE N'đã bán'
		BEGIN
			DECLARE @MaNguoiDung int, 
					@ThoiGianDi datetime

			SELECT @MaNguoiDung = MaNguoiDung
			FROM NguoiDung_Mua_VeMayBay
			WHERE MaVe=@MaVe

			SELECT @ThoiGianDi = ChuyenBay.ThoiGianDi
			FROM ChuyenBay_PhatHanh_VeMayBay, ChuyenBay
			WHERE ChuyenBay_PhatHanh_VeMayBay.MaVe=@MaVe 
			AND ChuyenBay_PhatHanh_VeMayBay.MaChuyenBay=ChuyenBay.MaChuyenBay

			IF  DATEDIFF(day, CAST(GETDATE() AS DATE), CAST(@ThoiGianDi AS DATE)) < 4
				BEGIN
					RAISERROR (N'Thời gian hủy vé đã hết hạn!', 16, 1) 
				END
			ELSE
				BEGIN
					DECLARE @GiaTienGoiHanhLy float

					SELECT @GiaTienGoiHanhLy = GiaTien
					FROM GoiHanhLy
					WHERE MaGoi = @MaGoi

					UPDATE HoaDon
					SET TongTien = TongTien - @GiaVe - @GiaTienGoiHanhLy
					WHERE MaHoaDon = @MaHoaDon

					---them nguoi dung huy ve---
					INSERT INTO NguoiDung_Huy_VeMayBay 
					VALUES(@MaVe, @MaNguoiDung, GETDATE())
				END
		END
END TRY
BEGIN CATCH
	ROLLBACK
	DECLARE @ERMES NVARCHAR(100) 
	SET @ERMES = ERROR_MESSAGE()
	RAISERROR (@ERMES, 16, 1)
END CATCH
END
GO

CREATE PROC huy_Ve_PROC @MaVe int
AS
	BEGIN
		UPDATE VeMayBay
		SET TinhTrangVe = N'chưa bán', 
			MaGoi = null,
			MaHoaDon = null
		WHERE MaVe = @MaVe
	END
GO

/* Phân quyền  */

--Role người dùng app
CREATE ROLE NguoiDungApp

GRANT EXECUTE ON huy_Ve_PROC TO NguoiDungApp
GRANT EXECUTE ON them_ThongTinNguoiDungMuaVe_PROC TO NguoiDungApp
GRANT EXECUTE ON them_ThongTinKhachHangTreEm_PROC TO NguoiDungApp
GRANT EXECUTE ON them_ThongTinKhachHangNguoiLon_PROC TO NguoiDungApp
GRANT EXECUTE ON them_NguoiLonQuanLyTreEm_PROC TO NguoiDungApp
GRANT EXECUTE ON khoitao_HoaDon_PROC TO NguoiDungApp

DENY EXECUTE ON dangky_TaiKhoan_PROC TO NguoiDungApp
DENY EXECUTE ON them_ChuyenBay_PROC TO NguoiDungApp
DENY EXECUTE ON them_GoiHanhLy_PROC TO NguoiDungApp
DENY EXECUTE ON phathanh_VeMayBay_PROC TO NguoiDungApp
DENY EXECUTE ON khoitao_ChuyenBay_PROC TO NguoiDungApp
DENY EXECUTE ON capnhat_ThongTinChuyenBay_PROC TO NguoiDungApp

GRANT SELECT ON timkiem_LichSuGiaoDich_FUNC TO NguoiDungApp
GRANT SELECT ON timkiem_ThongTinCaNhan_FUNC TO NguoiDungApp
GRANT SELECT ON timkiem_VeMayBay_FUNC TO NguoiDungApp
GRANT SELECT ON timkiem_ChuyenBay_FUNC TO NguoiDungApp

GRANT SELECT ON lay_DeXuatChuyenBay_FUNC TO NguoiDungApp
GRANT SELECT ON lay_GoiHanhLy_FUNC TO NguoiDungApp
GRANT SELECT ON lay_DanhSachChoNgoi_FUNC TO NguoiDungApp
GRANT SELECT ON lay_TinhTrang TO NguoiDungApp
GRANT SELECT ON lay_DiemDen TO NguoiDungApp
GRANT SELECT ON lay_DiemDi TO NguoiDungApp
GRANT SELECT ON lay_MaMayBay_FUNC TO NguoiDungApp
GRANT SELECT ON lay_DoanhThuTheoThang_FUNC TO NguoiDungApp
GRANT SELECT ON lay_Nam_FUNC TO NguoiDungApp
GRANT SELECT ON tracuu_HoaDon_FUNC TO NguoiDungApp

DENY SELECT ON kiemtra_DangNhap_FUNC TO NguoiDungApp

--Data

--Người quản lý 
INSERT INTO NguoiDung (SoDienThoai, HoTen, MatKhau, Email, NumOfRole)
VALUES ('0987654321', 'Nguyen Van A', '123456', 'nguyenvana@example.com', 1)
INSERT INTO NguoiDung (SoDienThoai, HoTen, MatKhau, Email, NumOfRole)
VALUES ('0123456789', 'Tran Thi B', '123456', 'tranthib@example.com', 5)

--Gói hành lý
INSERT INTO GoiHanhLy VALUES (10, 200000)
INSERT INTO GoiHanhLy VALUES (20, 250000)
INSERT INTO GoiHanhLy VALUES (30, 300000)
GO

--Máy bay
INSERT INTO MayBay VALUES (N'Airbus 111', 'Airbus')
INSERT INTO MayBay VALUES (N'Airbus 222', 'Airbus')
INSERT INTO MayBay VALUES (N'Airbus 333', 'Airbus')

INSERT INTO MayBay VALUES (N'Airbus 444', 'Airbus')
INSERT INTO MayBay VALUES (N'Airbus 555', 'Airbus')
INSERT INTO MayBay VALUES (N'Airbus 666', 'Airbus')

INSERT INTO MayBay VALUES (N'Airbus 777', 'Airbus')
INSERT INTO MayBay VALUES (N'Airbus 888', 'Airbus')
INSERT INTO MayBay VALUES (N'Airbus 999', 'Airbus')
GO

--Chuyến bay
INSERT INTO ChuyenBay (LoaiChuyenBay, DiemDi, DiemDen, ThoiGianDi, ThoiGianDuKienDen, TinhTrangChuyenBay, ChiPhi)
VALUES
    (N'quốc tế', N'Hà Nội', N'Tokyo', '2023-12-15 12:00:00', '2023-12-15 16:30:00', N'Chưa bán vé', 1500000000),
	(N'nội địa', N'Tokyo', N'Hà Nội', '2023-12-20 15:30:00', '2023-12-20 18:00:00', N'Chưa bán vé', 600000000)
GO

--Máy bay khỏi tạo chuyến bay
INSERT INTO MayBay_KhoiTao_ChuyenBay VALUES (1, 1, GETDATE())
INSERT INTO MayBay_KhoiTao_ChuyenBay VALUES (2, 2, GETDATE())
GO

--Chuyến bay phát hành các vé máy bay
EXEC phathanh_VeMayBay_PROC 5000000, 3000000, 7, 1
EXEC phathanh_VeMayBay_PROC 3000000, 1000000, 7, 2

--Mua vé
--Tạo hóa đơn + Cập nhập vé
DECLARE @MyPrimaryKey int, @Thue float
EXEC khoitao_HoaDon_PROC @MyPrimaryKey OUTPUT, @Thue OUTPUT

--Khách hàng người lớn
DECLARE @MaNguoiLon int
EXEC them_ThongTinKhachHangNguoiLon_PROC 'Nguyen Van A', N'Nam', '1985-01-01', '1234567890', 'nguyenvana@example.com', 'Hanoi', 1, 1, 1, @MaNguoiLon
EXEC them_ThongTinKhachHangNguoiLon_PROC 'Tran Thi B', N'Nữ', '1990-03-15', '0987123456', 'tranthib@example.com', 'Ho Chi Minh City', 2, 1, 1, @MaNguoiLon
EXEC them_ThongTinKhachHangNguoiLon_PROC 'Pham Van C', N'Nam', '1988-07-10', '1111122222', 'phamvanc@example.com', 'Da Nang', 3, 1, 1, @MaNguoiLon

--Khách hàng trẻ em 
DECLARE @MaTreEm int 
EXEC them_ThongTinKhachHangTreEm_PROC 'Nguyen Van X', N'Nam', '2010-02-15', 4, 1, 1, @MaTreEm
EXEC them_ThongTinKhachHangTreEm_PROC 'Tran Thi Y', N'Nữ', '2012-04-20', 5, 1, 1, @MaTreEm

--Khách hàng người lớn quản lý trẻ em
INSERT INTO KhachHangNguoiLon_QuanLy_KhachHangTreEm (MaNguoiLon, MaTreEm)
VALUES 
	(1, 1),
	(1, 2),
	(2, 1),
	(2, 2),
	(3, 1),
	(3, 2)
GO

EXEC dbo.them_ThongTinNguoiDungMuaVe_PROC 1, 1
EXEC dbo.them_ThongTinNguoiDungMuaVe_PROC 2, 1
EXEC dbo.them_ThongTinNguoiDungMuaVe_PROC 3, 1
EXEC dbo.them_ThongTinNguoiDungMuaVe_PROC 4, 1
EXEC dbo.them_ThongTinNguoiDungMuaVe_PROC 5, 1