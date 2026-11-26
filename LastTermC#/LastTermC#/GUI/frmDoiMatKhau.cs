using System;
using System.Windows.Forms;
using GS25Management.BUS;

namespace LastTermC_.GUI
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool an = !chkHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = an;
            txtMatKhauMoi.UseSystemPasswordChar = an;
            txtXacNhan.UseSystemPasswordChar = an;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (TaiKhoanBUS.DoiMatKhau(txtMatKhauCu.Text, txtMatKhauMoi.Text, txtXacNhan.Text, out string loi))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                return;
            }

            // gan loi vao dung o nhap
            Control o = loi.StartsWith("Mật khẩu cũ") ? txtMatKhauCu
                      : loi.Contains("xác nhận") ? txtXacNhan
                      : txtMatKhauMoi;
            errorProvider1.SetError(o, loi);
            o.Focus();
            if (loi.StartsWith("Không kết nối")) MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
