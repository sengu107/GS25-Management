using System;
using System.Windows.Forms;
using GS25Management.BUS;
using GS25Management.DTO;

namespace LastTermC_.GUI
{
    // Phan cua Le Minh Dung (He thong & Nhan su) gan vao frmMain.
    // Tach rieng file partial de khong sua frmMain.cs / frmMain.Designer.cs cua thanh vien khac.
    public partial class frmMain
    {
        // true khi nguoi dung bam "Dang xuat" -> quay lai man hinh dang nhap
        public bool DaDangXuat { get; private set; }

        private ToolStripMenuItem mnuTaiKhoan = null!;
        private ToolStripMenuItem mnuNhanSu = null!;
        private ToolStripSeparator sepHeThong = null!;
        private ToolStripStatusLabel lblNguoiDung = null!;

        protected override void OnLoad(EventArgs e)
        {
            TaoMenuHeThong();
            PhanQuyen();
            base.OnLoad(e);
        }

        private void TaoMenuHeThong()
        {
            Text = "Hệ thống quản lý cửa hàng tiện lợi GS25";
            WindowState = FormWindowState.Maximized;

            mnuTaiKhoan = new ToolStripMenuItem("Quản Lý Tài Khoản", null, mnuTaiKhoan_Click);
            sepHeThong = new ToolStripSeparator();
            ToolStripMenuItem mnuHeThong = new ToolStripMenuItem("Hệ Thống");
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuTaiKhoan,
                sepHeThong,
                new ToolStripMenuItem("Đăng Xuất", null, mnuDangXuat_Click),
                new ToolStripMenuItem("Thoát", null, (s, e) => Close())
            });

            mnuNhanSu = new ToolStripMenuItem("Nhân Sự");
            mnuNhanSu.DropDownItems.Add(new ToolStripMenuItem("Quản Lý Nhân Viên", null, mnuNhanVien_Click));

            // dat 2 menu cua minh truoc menu "Ban Hang"
            menuStrip1.Items.Insert(0, mnuHeThong);
            menuStrip1.Items.Insert(1, mnuNhanSu);

            // menu POS da co san tren frmMain -> mo frmPOS trong MDI
            pOSToolStripMenuItem.Click += (s, e) => MoForm<frmPOS>();

            lblNguoiDung = new ToolStripStatusLabel();
            StatusStrip status = new StatusStrip();
            status.Items.Add(lblNguoiDung);
            Controls.Add(status);
        }

        // Phan quyen: thu ngan khong duoc quan ly tai khoan va nhan su
        private void PhanQuyen()
        {
            TaiKhoanDTO? tk = TaiKhoanBUS.TaiKhoanHienTai;
            if (tk == null) return;

            lblNguoiDung.Text = "Người dùng: " + (tk.HoTen ?? tk.TenDangNhap) + "   |   Vai trò: " +
                                (tk.LaAdmin ? "Quản trị (Admin)" : "Thu ngân");
            mnuTaiKhoan.Visible = tk.LaAdmin;
            sepHeThong.Visible = tk.LaAdmin;
            mnuNhanSu.Visible = tk.LaAdmin;
        }

        // Mo form con trong MDI, neu da mo thi dua len truoc
        private void MoForm<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    f.Activate();
                    return;
                }
            }
            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTaiKhoan_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý tài khoản sẽ có ở Mục 2.", "Thông báo");
        }

        private void mnuNhanVien_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý nhân viên sẽ có ở Mục 3.", "Thông báo");
        }

        private void mnuDangXuat_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            TaiKhoanBUS.DangXuat();
            DaDangXuat = true;
            Close();
        }
    }
}
