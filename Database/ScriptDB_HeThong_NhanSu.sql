/* =========================================================
   GS25 - Phần Hệ thống & Nhân sự (Lê Minh Dũng)
   Bảng: NhanVien, TaiKhoan
   Chạy trên cùng CSDL GS25 với các phần khác (App.config: Database=GS25)
   Chỉ xóa / tạo lại 2 bảng của phần này, không đụng bảng của thành viên khác.
   ========================================================= */
CREATE DATABASE IF NOT EXISTS GS25 CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE GS25;

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS TaiKhoan;
DROP TABLE IF EXISTS NhanVien;
SET FOREIGN_KEY_CHECKS = 1;

/* ===== M3: NHÂN VIÊN ===== */
CREATE TABLE NhanVien (
    MaNV            VARCHAR(10)     PRIMARY KEY,
    HoTen           VARCHAR(100)    NOT NULL,
    GioiTinh        VARCHAR(5)      NULL,
    NgaySinh        DATE            NULL,
    SoDienThoai     VARCHAR(15)     NULL,
    DiaChi          VARCHAR(200)    NULL,
    ChucVu          VARCHAR(50)     NULL,
    CaLamViec       VARCHAR(20)     NULL,
    NgayVaoLam      DATE            NOT NULL DEFAULT (CURRENT_DATE),
    TrangThai       TINYINT(1)      NOT NULL DEFAULT 1
);

/* ===== M1-2: TÀI KHOẢN ===== */
CREATE TABLE TaiKhoan (
    MaTK            VARCHAR(10)     PRIMARY KEY,
    TenDangNhap     VARCHAR(50)     NOT NULL UNIQUE,
    MatKhauHash     VARCHAR(256)    NOT NULL,       -- SHA-256 (hex)
    VaiTro          VARCHAR(20)     NOT NULL,       -- 'Admin' / 'ThuNgan'
    MaNV            VARCHAR(10)     NULL,
    TrangThai       TINYINT(1)      NOT NULL DEFAULT 1,
    NgayTao         DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

/* ===== DỮ LIỆU MẪU ===== */
INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, SoDienThoai, DiaChi, ChucVu, CaLamViec) VALUES
('NV001', 'Lê Minh Dũng', 'Nam', '2004-05-12', '0912345678', 'Hai Bà Trưng, Hà Nội', 'Quản lý', 'Hành chính'),
('NV002', 'Trần Thị Bích', 'Nữ', '2003-09-20', '0987654321', 'Đống Đa, Hà Nội', 'Thu ngân', 'Ca sáng'),
('NV003', 'Phạm Quốc Huy', 'Nam', '2002-11-02', '0905111222', 'Cầu Giấy, Hà Nội', 'Thu ngân', 'Ca chiều'),
('NV004', 'Nguyễn Thu Hà', 'Nữ', '2005-03-15', '0934555666', 'Thanh Xuân, Hà Nội', 'Nhân viên kho', 'Ca tối');

-- Mật khẩu lưu dạng SHA-256: admin / admin123, thungan1 / 123456, thungan2 / 123456 (đã khóa)
INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhauHash, VaiTro, MaNV, TrangThai) VALUES
('TK001', 'admin',    SHA2('admin123', 256), 'Admin',   'NV001', 1),
('TK002', 'thungan1', SHA2('123456', 256),   'ThuNgan', 'NV002', 1),
('TK003', 'thungan2', SHA2('123456', 256),   'ThuNgan', 'NV003', 0);
