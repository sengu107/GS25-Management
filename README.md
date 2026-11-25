# HỆ THỐNG QUẢN LÝ CỬA HÀNG TIỆN LỢI GS25

Báo cáo kết thúc môn **Lập trình .NET** — ứng dụng desktop C# WinForms (.NET 10) theo kiến trúc 3 lớp, CSDL MySQL.

## 1. Giới thiệu đề tài

Ứng dụng hỗ trợ vận hành một cửa hàng tiện lợi theo mô hình GS25:

- **Hệ thống & nhân sự:** đăng nhập, phân quyền Admin / Thu ngân, quản lý tài khoản và nhân viên.
- **Kho hàng:** danh mục sản phẩm, sản phẩm, nhà cung cấp, nhập hàng và tự động cập nhật tồn kho.
- **Bán hàng & báo cáo:** bán hàng tại quầy (POS), quản lý hóa đơn, mã giảm giá, thống kê doanh thu.

| Thành phần | Lựa chọn |
|---|---|
| Ngôn ngữ / Framework | C# WinForms (.NET 10, `net10.0-windows`) |
| CSDL | MySQL 8.0 (thư viện `MySql.Data`) |
| Kiến trúc | 3 lớp: DTO – DAL – BUS – GUI |
| Truy cập dữ liệu | ADO.NET, câu lệnh SQL có tham số, `MySqlTransaction` |
| IDE | Visual Studio |

## 2. Thành viên nhóm

- **Lớp:** D19QTANM1
- **Môn:** Lập trình .NET

| STT | Họ và tên | Mã sinh viên | Phụ trách |
|---|---|---|---|
| 1 | Lê Minh Dũng | 24810320213 | Hệ thống & Nhân sự |
| 2 | Nguyễn Tự Tiến Đạt | 24810320260 | Kho hàng |
| 3 | Hoàng Kim Sang | 24810320037 | Bán hàng & Báo cáo |

## 3. Phân công công việc

### Lê Minh Dũng — Hệ thống & Nhân sự

- **M1 – Đăng nhập & phân quyền:** bảng `TaiKhoan`, mật khẩu lưu dạng băm SHA-256, ẩn menu theo vai trò (Admin / Thu ngân), kiểm tra dữ liệu nhập bằng `ErrorProvider`.
- **M2 – Quản lý tài khoản:** thêm / sửa / khóa tài khoản, đổi mật khẩu, gán quyền.
- **M3 – Quản lý nhân viên:** bảng `NhanVien`, thêm / sửa / xóa, phân ca làm việc.
- **Việc chung:** màn hình chính `frmMain` (MDI + menu gọi các form).
- **Đầu ra:** `frmLogin`, `frmTaiKhoan`, `frmNhanVien`.

### Nguyễn Tự Tiến Đạt — Kho hàng

- **M4 – Danh mục sản phẩm:** bảng `DanhMucSanPham`, thêm / sửa / xóa.
- **M5 – Sản phẩm:** bảng `SanPham`, thêm / sửa / xóa, tìm kiếm / lọc, cảnh báo tồn thấp và sắp hết hạn.
- **M6 – Nhà cung cấp & Nhập hàng:** bảng `NhaCungCap`, `PhieuNhapHang`, `ChiTietPhieuNhap`; tự động cập nhật tồn kho trong transaction.
- **Đầu ra:** `frmDanhMuc`, `frmSanPham`, `frmNhaCungCap`, `frmPhieuNhap`.

### Hoàng Kim Sang — Bán hàng & Báo cáo

- **M7 – Bán hàng (POS):** bảng `HoaDonBanHang`, `ChiTietHoaDon`; giỏ hàng, tính tổng tiền, áp dụng mã giảm giá, trừ tồn kho trong transaction (rollback nếu thiếu hàng).
- **M8 – Quản lý hóa đơn:** tra cứu / lọc theo ngày, nhân viên; xem chi tiết; hủy hóa đơn.
- **M9 – Thống kê & báo cáo:** doanh thu, sản phẩm bán chạy, biểu đồ (Chart), xuất Excel / CSV.
- **Đầu ra:** `frmPOS` (`frmBanHang`), `frmHoaDon`, `frmThongKe`.

## 4. Các file từng người đã làm

Đường dẫn tính từ thư mục `LastTermC#/LastTermC#/`.

### Lê Minh Dũng

| Lớp | File | Nội dung |
|---|---|---|
| DTO | `DTO/TaiKhoanDTO.cs` | Dữ liệu tài khoản (mã, tên đăng nhập, mật khẩu băm, vai trò, trạng thái) |
| DAL | `DAL/TaiKhoanDAL.cs` | Lấy tài khoản theo tên đăng nhập (kèm họ tên nhân viên) |
| BUS | `BUS/TaiKhoanBUS.cs` | Băm mật khẩu SHA-256, đăng nhập / đăng xuất, lưu tài khoản đang đăng nhập |
| GUI | `GUI/frmLogin.cs`, `frmLogin.Designer.cs`, `frmLogin.resx` | Form đăng nhập (`ErrorProvider`), điểm khởi động ứng dụng |
| GUI | `GUI/frmMain.HeThong.cs` | Gắn menu Hệ Thống, Nhân Sự, thanh trạng thái và phân quyền vào `frmMain` |
| CSDL | `Database/ScriptDB_HeThong_NhanSu.sql` (ở thư mục gốc) | Bảng `NhanVien`, `TaiKhoan` và dữ liệu mẫu |
| Chung | `Program.cs` | Gọi `frmLogin.ChayUngDung()` để khởi động ứng dụng |
| Chung | `README.md` (ở thư mục gốc) | Tài liệu dự án |

### Nguyễn Tự Tiến Đạt

*(Chưa có file trên repo.)*

### Hoàng Kim Sang

| Lớp | File | Nội dung |
|---|---|---|
| DTO | `DTO/HoaDonBanHangDTO.cs` | Dữ liệu hóa đơn bán hàng |
| DTO | `DTO/ChiTietHoaDonDTO.cs` | Dữ liệu chi tiết hóa đơn (thành tiền tính theo số lượng, đơn giá, giảm giá) |
| DTO | `DTO/MaGiamGiaDTO.cs`, `DTO/GiamGiaDTO.cs` | Dữ liệu mã giảm giá |
| DAL | `DAL/HoaDonBanHangDAL.cs` | Lập hóa đơn trong transaction (kiểm tra và trừ tồn kho), tra cứu, xóa hóa đơn |
| DAL | `DAL/MaGiamGiaDAL.cs` | Thêm / sửa / xóa / tra cứu mã giảm giá |
| BUS | `BUS/HoaDonBanHangBUS.cs` | Kiểm tra mã giảm giá, tính tổng tiền, tiền giảm, thành tiền |
| GUI | `GUI/frmPOS.cs`, `frmPOS.Designer.cs`, `frmPOS.resx` | Giao diện bán hàng tại quầy |
| GUI | `GUI/frmMain.cs`, `frmMain.Designer.cs`, `frmMain.resx` | Màn hình chính (MDI) và menu Bán Hàng |
| Chung | `LastTermC#.slnx`, `LastTermC#.csproj`, `App.config`, `.gitignore` | Khởi tạo solution, project và chuỗi kết nối |

## 5. Cấu trúc thư mục dự án

```
GS25-Management/
├── Database/
│   └── ScriptDB_HeThong_NhanSu.sql
├── LastTermC#/
│   ├── LastTermC#.slnx
│   └── LastTermC#/
│       ├── LastTermC#.csproj
│       ├── App.config
│       ├── Program.cs
│       ├── DTO/
│       ├── DAL/
│       ├── BUS/
│       └── GUI/
├── .gitignore
└── README.md
```

| Thư mục | Vai trò |
|---|---|
| `DTO/` | Lớp dữ liệu thuần, mỗi bảng một class (`TaiKhoanDTO`, `HoaDonBanHangDTO`...) |
| `DAL/` | Truy cập MySQL: mở kết nối, chạy SQL có tham số, transaction |
| `BUS/` | Kiểm tra dữ liệu, xử lý nghiệp vụ rồi gọi xuống DAL |
| `GUI/` | Các form WinForms thiết kế bằng Toolbox |
| `Database/` | Script tạo bảng và dữ liệu mẫu, mỗi phần một file |

Mỗi thành viên viết code trong file riêng của mình. Phần Hệ thống & Nhân sự gắn vào màn hình chính qua `GUI/frmMain.HeThong.cs` (partial class), không sửa `frmMain.cs` / `frmMain.Designer.cs`.

## 6. Hướng dẫn cài đặt & chạy

1. **Cài đặt:** Visual Studio (có workload .NET Desktop, .NET 10 SDK) và MySQL Server 8.0 (kèm MySQL Workbench).
2. **Tạo CSDL:** mở MySQL Workbench, chạy lần lượt các file trong thư mục `Database/`. Tất cả dùng chung CSDL `GS25`.
3. **Chuỗi kết nối:** mở `LastTermC#/LastTermC#/App.config`, sửa `Pwd` thành mật khẩu MySQL trên máy:
   ```xml
   <add name="GS25DB" connectionString="Server=localhost;Database=GS25;Uid=root;Pwd=your_password" providerName="MySql.Data.MySqlClient" />
   ```
   Không đưa mật khẩu thật lên GitHub.
4. **Chạy:** mở `LastTermC#/LastTermC#.slnx` bằng Visual Studio, nhấn **F5** (NuGet `MySql.Data` được tải tự động).
   Hoặc dùng dòng lệnh trong thư mục `LastTermC#/`:
   ```
   dotnet run --project LastTermC#/LastTermC#.csproj
   ```

## 7. Tài khoản demo

| Tên đăng nhập | Mật khẩu | Vai trò | Ghi chú |
|---|---|---|---|
| `admin` | `admin123` | Admin | Dùng được tất cả chức năng |
| `thungan1` | `123456` | Thu ngân | Không thấy menu Tài khoản, Nhân sự |
| `thungan2` | `123456` | Thu ngân | Tài khoản đã khóa, không đăng nhập được |

## 8. Hình ảnh các chức năng chính

*(Bổ sung ảnh chụp màn hình khi hoàn thiện từng module.)*
