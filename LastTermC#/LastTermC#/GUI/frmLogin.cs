using System;
using System.Windows.Forms;
using GS25Management.BUS;
using GS25Management.DTO;

namespace LastTermC_.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Diem khoi dong: dang nhap -> frmMain; dang xuat thi quay lai man hinh dang nhap
        public static void ChayUngDung()
        {
            while (true)
            {
                using (frmLogin login = new frmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }

                frmMain main = new frmMain();
                Application.Run(main);
                if (!main.DaDangXuat) return;
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            // kiem tra input tren form truoc khi goi BUS
            if (txtTenDangNhap.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            TaiKhoanDTO? tk = TaiKhoanBUS.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text, out string loi);
            if (tk == null)
            {
                errorProvider1.SetError(txtMatKhau, loi);
                MessageBox.Show(loi, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.SelectAll();
                txtMatKhau.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
