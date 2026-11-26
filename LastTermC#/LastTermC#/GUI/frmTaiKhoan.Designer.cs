namespace LastTermC_.GUI
{
    partial class frmTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpThongTin = new GroupBox();
            lblMaTK = new Label();
            txtMaTK = new TextBox();
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblGhiChuMatKhau = new Label();
            lblVaiTro = new Label();
            cboVaiTro = new ComboBox();
            lblNhanVien = new Label();
            cboNhanVien = new ComboBox();
            chkHoatDong = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            dgvTaiKhoan = new DataGridView();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaTK);
            grpThongTin.Controls.Add(txtMaTK);
            grpThongTin.Controls.Add(lblTenDangNhap);
            grpThongTin.Controls.Add(txtTenDangNhap);
            grpThongTin.Controls.Add(lblMatKhau);
            grpThongTin.Controls.Add(txtMatKhau);
            grpThongTin.Controls.Add(lblGhiChuMatKhau);
            grpThongTin.Controls.Add(lblVaiTro);
            grpThongTin.Controls.Add(cboVaiTro);
            grpThongTin.Controls.Add(lblNhanVien);
            grpThongTin.Controls.Add(cboNhanVien);
            grpThongTin.Controls.Add(chkHoatDong);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(906, 185);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin tài khoản";
            //
            // lblMaTK
            //
            lblMaTK.AutoSize = true;
            lblMaTK.Location = new Point(18, 35);
            lblMaTK.Name = "lblMaTK";
            lblMaTK.Size = new Size(97, 20);
            lblMaTK.TabIndex = 0;
            lblMaTK.Text = "Mã tài khoản";
            //
            // txtMaTK
            //
            txtMaTK.Location = new Point(140, 32);
            txtMaTK.Name = "txtMaTK";
            txtMaTK.ReadOnly = true;
            txtMaTK.Size = new Size(120, 27);
            txtMaTK.TabIndex = 1;
            txtMaTK.TabStop = false;
            //
            // lblTenDangNhap
            //
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(18, 70);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(107, 20);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Tên đăng nhập";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new Point(140, 67);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(220, 27);
            txtTenDangNhap.TabIndex = 3;
            //
            // lblMatKhau
            //
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(18, 105);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(70, 20);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new Point(140, 102);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(220, 27);
            txtMatKhau.TabIndex = 5;
            txtMatKhau.UseSystemPasswordChar = true;
            //
            // lblGhiChuMatKhau
            //
            lblGhiChuMatKhau.AutoSize = true;
            lblGhiChuMatKhau.ForeColor = SystemColors.GrayText;
            lblGhiChuMatKhau.Location = new Point(140, 132);
            lblGhiChuMatKhau.Name = "lblGhiChuMatKhau";
            lblGhiChuMatKhau.Size = new Size(228, 20);
            lblGhiChuMatKhau.TabIndex = 6;
            lblGhiChuMatKhau.Text = "Khi sửa: để trống nếu không đổi";
            //
            // lblVaiTro
            //
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(420, 35);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(53, 20);
            lblVaiTro.TabIndex = 7;
            lblVaiTro.Text = "Vai trò";
            //
            // cboVaiTro
            //
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(520, 31);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(160, 28);
            cboVaiTro.TabIndex = 8;
            //
            // lblNhanVien
            //
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(420, 70);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(75, 20);
            lblNhanVien.TabIndex = 9;
            lblNhanVien.Text = "Nhân viên";
            //
            // cboNhanVien
            //
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(520, 66);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(300, 28);
            cboNhanVien.TabIndex = 10;
            //
            // chkHoatDong
            //
            chkHoatDong.AutoSize = true;
            chkHoatDong.Checked = true;
            chkHoatDong.CheckState = CheckState.Checked;
            chkHoatDong.Location = new Point(520, 104);
            chkHoatDong.Name = "chkHoatDong";
            chkHoatDong.Size = new Size(135, 24);
            chkHoatDong.TabIndex = 11;
            chkHoatDong.Text = "Đang hoạt động";
            chkHoatDong.UseVisualStyleBackColor = true;
            //
            // btnThem
            //
            btnThem.Location = new Point(420, 140);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 33);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(530, 140);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 33);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(640, 140);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 33);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(750, 140);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 33);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // lblTimKiem
            //
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(12, 213);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(70, 20);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "Tìm kiếm";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(90, 210);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã, tên đăng nhập hoặc tên nhân viên";
            txtTimKiem.Size = new Size(320, 27);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            //
            // dgvTaiKhoan
            //
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = Color.White;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.DataSource = bindingSource1;
            dgvTaiKhoan.Location = new Point(12, 248);
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersVisible = false;
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.Size = new Size(906, 320);
            dgvTaiKhoan.TabIndex = 3;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // frmTaiKhoan
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 580);
            Controls.Add(dgvTaiKhoan);
            Controls.Add(txtTimKiem);
            Controls.Add(lblTimKiem);
            Controls.Add(grpThongTin);
            Name = "frmTaiKhoan";
            Text = "Quản lý tài khoản";
            Load += frmTaiKhoan_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaTK;
        private TextBox txtMaTK;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblGhiChuMatKhau;
        private Label lblVaiTro;
        private ComboBox cboVaiTro;
        private Label lblNhanVien;
        private ComboBox cboNhanVien;
        private CheckBox chkHoatDong;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private DataGridView dgvTaiKhoan;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
    }
}
