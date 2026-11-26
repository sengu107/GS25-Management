using System;
using System.Data;
using System.Windows.Forms;
using GS25Management.BUS;
using GS25Management.DTO;

namespace LastTermC_.GUI
{
    public partial class frmNhanVien : Form
    {
        private string maChon = "";     // ma nhan vien dang chon tren luoi ("" = chua chon)

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            cboChucVu.Items.AddRange(NhanVienBUS.DanhSachChucVu);
            cboCaLamViec.Items.AddRange(NhanVienBUS.DanhSachCa);
            cboLocCa.Items.Add("Tất cả");
            cboLocCa.Items.AddRange(NhanVienBUS.DanhSachCa);
            cboLocCa.SelectedIndex = 0;
            TaiDuLieu();
            LamMoi();
        }

        private void TaiDuLieu()
        {
            try
            {
                bindingSource1.DataSource = NhanVienBUS.TraCuu(txtTimKiem.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cot("MaNV", "Mã NV", 55);
            Cot("HoTen", "Họ tên", 140);
            Cot("GioiTinh", "Giới tính", 55);
            Cot("NgaySinh", "Ngày sinh", 80).DefaultCellStyle.Format = "dd/MM/yyyy";
            Cot("SoDienThoai", "Điện thoại", 85);
            Cot("DiaChi", "Địa chỉ", 140);
            Cot("ChucVu", "Chức vụ", 85);
            Cot("CaLamViec", "Ca làm việc", 80);
            Cot("NgayVaoLam", "Ngày vào làm", 85).DefaultCellStyle.Format = "dd/MM/yyyy";
            Cot("TrangThai", "Đang làm", 60);
            LocTheoCa();
        }

        private DataGridViewColumn Cot(string ten, string tieuDe, float doRong)
        {
            DataGridViewColumn c = dgvNhanVien.Columns[ten]!;
            c.HeaderText = tieuDe;
            c.FillWeight = doRong;
            return c;
        }

        // Phan ca: loc danh sach theo ca lam viec bang BindingSource.Filter
        private void LocTheoCa()
        {
            bindingSource1.Filter = cboLocCa.SelectedIndex <= 0 ? "" : "CaLamViec = '" + cboLocCa.SelectedItem + "'";
            lblSoNhanVien.Text = bindingSource1.Count + " nhân viên";
        }

        private void cboLocCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindingSource1.DataSource != null) LocTheoCa();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView r = (DataRowView)bindingSource1[e.RowIndex]!;
            maChon = r["MaNV"].ToString()!;
            txtMaNV.Text = maChon;
            txtHoTen.Text = r["HoTen"].ToString();
            radNu.Checked = r["GioiTinh"].ToString() == "Nữ";
            radNam.Checked = !radNu.Checked;
            dtpNgaySinh.Checked = r["NgaySinh"] != DBNull.Value;
            if (dtpNgaySinh.Checked) dtpNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            txtSoDienThoai.Text = r["SoDienThoai"].ToString();
            txtDiaChi.Text = r["DiaChi"].ToString();
            cboChucVu.SelectedItem = r["ChucVu"].ToString();
            cboCaLamViec.SelectedItem = r["CaLamViec"].ToString();
            dtpNgayVaoLam.Value = Convert.ToDateTime(r["NgayVaoLam"]);
            chkDangLam.Checked = Convert.ToBoolean(r["TrangThai"]);
            errorProvider1.Clear();
        }

        private NhanVienDTO DocForm()
        {
            return new NhanVienDTO
            {
                MaNV = maChon,
                HoTen = txtHoTen.Text,
                GioiTinh = radNu.Checked ? "Nữ" : "Nam",
                NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
                SoDienThoai = txtSoDienThoai.Text,
                DiaChi = txtDiaChi.Text,
                ChucVu = cboChucVu.SelectedItem?.ToString(),
                CaLamViec = cboCaLamViec.SelectedItem?.ToString(),
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                TrangThai = chkDangLam.Checked
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = DocForm();
            bool ok = NhanVienBUS.Them(nv, out string loi);
            KetQua(ok, loi, "Đã thêm nhân viên " + nv.MaNV + " - " + nv.HoTen + ".");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool ok = NhanVienBUS.CapNhat(DocForm(), out string loi);
            KetQua(ok, loi, "Đã cập nhật nhân viên " + maChon + ".");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maChon != "" && MessageBox.Show("Xóa nhân viên \"" + txtHoTen.Text + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            string ma = maChon;
            bool ok = NhanVienBUS.Xoa(ma, out string loi);
            KetQua(ok, loi, "Đã xóa nhân viên " + ma + ".");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            maChon = "";
            txtMaNV.Text = "(tự sinh)";
            txtHoTen.Clear();
            radNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            dtpNgaySinh.Checked = true;
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            cboChucVu.SelectedItem = "Thu ngân";
            cboCaLamViec.SelectedItem = "Ca sáng";
            dtpNgayVaoLam.Value = DateTime.Today;
            chkDangLam.Checked = true;
            errorProvider1.Clear();
            txtHoTen.Focus();
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

            Control? o = loi.StartsWith("Họ tên") ? txtHoTen
                       : loi.StartsWith("Số điện thoại") ? txtSoDienThoai
                       : loi.StartsWith("Ngày sinh") ? dtpNgaySinh
                       : loi.StartsWith("Ngày vào làm") ? dtpNgayVaoLam
                       : loi.Contains("chức vụ") ? cboChucVu
                       : loi.Contains("ca làm việc") ? cboCaLamViec
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
