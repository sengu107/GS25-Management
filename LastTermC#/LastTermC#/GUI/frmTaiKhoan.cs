using System;
using System.Data;
using System.Windows.Forms;
using GS25Management.BUS;
using GS25Management.DTO;

namespace LastTermC_.GUI
{
    public partial class frmTaiKhoan : Form
    {
        private string maChon = "";     // ma tai khoan dang chon tren luoi ("" = chua chon)

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.AddRange(TaiKhoanBUS.DanhSachVaiTro);
            try
            {
                TaiNhanVien();
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamMoi();
        }

        // ComboBox nhan vien: "(Khong gan)" + danh sach "NV001 - Ho ten"
        private void TaiNhanVien()
        {
            DataTable dt = NhanVienBUS.TraCuu("");
            dt.Columns.Add("HienThi", typeof(string));
            foreach (DataRow r in dt.Rows) r["HienThi"] = r["MaNV"] + " - " + r["HoTen"];
            DataRow trong = dt.NewRow();
            trong["MaNV"] = "";
            trong["HoTen"] = "";
            trong["HienThi"] = "(Không gán nhân viên)";
            dt.Rows.InsertAt(trong, 0);

            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = dt;
        }

        private void TaiDuLieu()
        {
            bindingSource1.DataSource = TaiKhoanBUS.TraCuu(txtTimKiem.Text.Trim());
            Cot("MaTK", "Mã TK", 60);
            Cot("TenDangNhap", "Tên đăng nhập", 100);
            Cot("VaiTro", "Vai trò", 70);
            Cot("MaNV", "Mã NV", 60);
            Cot("HoTen", "Nhân viên", 140);
            Cot("TrangThai", "Hoạt động", 60);
            Cot("NgayTao", "Ngày tạo", 100).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private DataGridViewColumn Cot(string ten, string tieuDe, float doRong)
        {
            DataGridViewColumn c = dgvTaiKhoan.Columns[ten]!;
            c.HeaderText = tieuDe;
            c.FillWeight = doRong;
            return c;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView r = (DataRowView)bindingSource1[e.RowIndex]!;
            maChon = r["MaTK"].ToString()!;
            txtMaTK.Text = maChon;
            txtTenDangNhap.Text = r["TenDangNhap"].ToString();
            txtMatKhau.Clear();
            cboVaiTro.SelectedItem = r["VaiTro"].ToString();
            cboNhanVien.SelectedValue = r["MaNV"] == DBNull.Value ? "" : r["MaNV"].ToString()!;
            chkHoatDong.Checked = Convert.ToBoolean(r["TrangThai"]);
            errorProvider1.Clear();
        }

        private TaiKhoanDTO DocForm()
        {
            string maNV = cboNhanVien.SelectedValue?.ToString() ?? "";
            return new TaiKhoanDTO
            {
                MaTK = maChon,
                TenDangNhap = txtTenDangNhap.Text,
                VaiTro = cboVaiTro.SelectedItem?.ToString() ?? "",
                MaNV = maNV == "" ? null : maNV,
                TrangThai = chkHoatDong.Checked
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = DocForm();
            bool ok = TaiKhoanBUS.Them(tk, txtMatKhau.Text, out string loi);
            KetQua(ok, loi, "Đã thêm tài khoản " + tk.MaTK + " - " + tk.TenDangNhap + ".");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maChon == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa trên danh sách.", "Thông báo");
                return;
            }
            bool ok = TaiKhoanBUS.CapNhat(DocForm(), txtMatKhau.Text, out string loi);
            KetQua(ok, loi, "Đã cập nhật tài khoản " + maChon + ".");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maChon != "" && MessageBox.Show("Xóa tài khoản \"" + txtTenDangNhap.Text + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            string ma = maChon;
            bool ok = TaiKhoanBUS.Xoa(ma, out string loi);
            KetQua(ok, loi, "Đã xóa tài khoản " + ma + ".");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            maChon = "";
            txtMaTK.Text = "(tự sinh)";
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedItem = "ThuNgan";
            if (cboNhanVien.Items.Count > 0) cboNhanVien.SelectedIndex = 0;
            chkHoatDong.Checked = true;
            errorProvider1.Clear();
            txtTenDangNhap.Focus();
        }

        // Thanh cong: nap lai luoi; loi nhap lieu: hien ErrorProvider dung o; loi khac: MessageBox
        private void KetQua(bool ok, string loi, string thongBao)
        {
            errorProvider1.Clear();
            if (ok)
            {
                TaiDuLieu();
                LamMoi();
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Control? o = loi.StartsWith("Tên đăng nhập") ? txtTenDangNhap
                       : loi.StartsWith("Mật khẩu") ? txtMatKhau
                       : loi.Contains("vai trò") ? cboVaiTro
                       : null;
            if (o != null)
            {
                errorProvider1.SetError(o, loi);
                o.Focus();
            }
            else
            {
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
