namespace LastTermC_.GUI
{
    partial class frmNhanVien
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
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblGioiTinh = new Label();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblChucVu = new Label();
            cboChucVu = new ComboBox();
            lblCaLamViec = new Label();
            cboCaLamViec = new ComboBox();
            lblNgayVaoLam = new Label();
            dtpNgayVaoLam = new DateTimePicker();
            chkDangLam = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            lblLocCa = new Label();
            cboLocCa = new ComboBox();
            lblSoNhanVien = new Label();
            dgvNhanVien = new DataGridView();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaNV);
            grpThongTin.Controls.Add(txtMaNV);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblGioiTinh);
            grpThongTin.Controls.Add(radNam);
            grpThongTin.Controls.Add(radNu);
            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(lblSoDienThoai);
            grpThongTin.Controls.Add(txtSoDienThoai);
            grpThongTin.Controls.Add(lblDiaChi);
            grpThongTin.Controls.Add(txtDiaChi);
            grpThongTin.Controls.Add(lblChucVu);
            grpThongTin.Controls.Add(cboChucVu);
            grpThongTin.Controls.Add(lblCaLamViec);
            grpThongTin.Controls.Add(cboCaLamViec);
            grpThongTin.Controls.Add(lblNgayVaoLam);
            grpThongTin.Controls.Add(dtpNgayVaoLam);
            grpThongTin.Controls.Add(chkDangLam);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1006, 215);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin nhân viên";
            //
            // lblMaNV
            //
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(18, 35);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(98, 20);
            lblMaNV.TabIndex = 0;
            lblMaNV.Text = "Mã nhân viên";
            //
            // txtMaNV
            //
            txtMaNV.Location = new Point(140, 32);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(120, 27);
            txtMaNV.TabIndex = 1;
            txtMaNV.TabStop = false;
            //
            // lblHoTen
            //
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(18, 70);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(140, 67);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(270, 27);
            txtHoTen.TabIndex = 3;
            //
            // lblGioiTinh
            //
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(18, 105);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(66, 20);
            lblGioiTinh.TabIndex = 4;
            lblGioiTinh.Text = "Giới tính";
            //
            // radNam
            //
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(140, 103);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 24);
            radNam.TabIndex = 5;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            //
            // radNu
            //
            radNu.AutoSize = true;
            radNu.Location = new Point(220, 103);
            radNu.Name = "radNu";
            radNu.Size = new Size(50, 24);
            radNu.TabIndex = 6;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            //
            // lblNgaySinh
            //
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(18, 140);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(74, 20);
            lblNgaySinh.TabIndex = 7;
            lblNgaySinh.Text = "Ngày sinh";
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(140, 137);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(170, 27);
            dtpNgaySinh.TabIndex = 8;
            //
            // lblSoDienThoai
            //
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(18, 175);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(97, 20);
            lblSoDienThoai.TabIndex = 9;
            lblSoDienThoai.Text = "Số điện thoại";
            //
            // txtSoDienThoai
            //
            txtSoDienThoai.Location = new Point(140, 172);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(170, 27);
            txtSoDienThoai.TabIndex = 10;
            //
            // lblDiaChi
            //
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(470, 35);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(55, 20);
            lblDiaChi.TabIndex = 11;
            lblDiaChi.Text = "Địa chỉ";
            //
            // txtDiaChi
            //
            txtDiaChi.Location = new Point(590, 32);
            txtDiaChi.MaxLength = 200;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(390, 27);
            txtDiaChi.TabIndex = 12;
            //
            // lblChucVu
            //
            lblChucVu.AutoSize = true;
            lblChucVu.Location = new Point(470, 70);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(62, 20);
            lblChucVu.TabIndex = 13;
            lblChucVu.Text = "Chức vụ";
            //
            // cboChucVu
            //
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(590, 66);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(200, 28);
            cboChucVu.TabIndex = 14;
            //
            // lblCaLamViec
            //
            lblCaLamViec.AutoSize = true;
            lblCaLamViec.Location = new Point(470, 105);
            lblCaLamViec.Name = "lblCaLamViec";
            lblCaLamViec.Size = new Size(87, 20);
            lblCaLamViec.TabIndex = 15;
            lblCaLamViec.Text = "Ca làm việc";
            //
            // cboCaLamViec
            //
            cboCaLamViec.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaLamViec.FormattingEnabled = true;
            cboCaLamViec.Location = new Point(590, 101);
            cboCaLamViec.Name = "cboCaLamViec";
            cboCaLamViec.Size = new Size(200, 28);
            cboCaLamViec.TabIndex = 16;
            //
            // lblNgayVaoLam
            //
            lblNgayVaoLam.AutoSize = true;
            lblNgayVaoLam.Location = new Point(470, 140);
            lblNgayVaoLam.Name = "lblNgayVaoLam";
            lblNgayVaoLam.Size = new Size(100, 20);
            lblNgayVaoLam.TabIndex = 17;
            lblNgayVaoLam.Text = "Ngày vào làm";
            //
            // dtpNgayVaoLam
            //
            dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            dtpNgayVaoLam.Format = DateTimePickerFormat.Custom;
            dtpNgayVaoLam.Location = new Point(590, 137);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(170, 27);
            dtpNgayVaoLam.TabIndex = 18;
            //
            // chkDangLam
            //
            chkDangLam.AutoSize = true;
            chkDangLam.Checked = true;
            chkDangLam.CheckState = CheckState.Checked;
            chkDangLam.Location = new Point(590, 174);
            chkDangLam.Name = "chkDangLam";
            chkDangLam.Size = new Size(131, 24);
            chkDangLam.TabIndex = 19;
            chkDangLam.Text = "Đang làm việc";
            chkDangLam.UseVisualStyleBackColor = true;
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 238);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 33);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(122, 238);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 33);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(232, 238);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 33);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(342, 238);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 33);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // lblTimKiem
            //
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(12, 289);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(70, 20);
            lblTimKiem.TabIndex = 5;
            lblTimKiem.Text = "Tìm kiếm";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(90, 286);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã, họ tên hoặc số điện thoại";
            txtTimKiem.Size = new Size(300, 27);
            txtTimKiem.TabIndex = 6;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            //
            // lblLocCa
            //
            lblLocCa.AutoSize = true;
            lblLocCa.Location = new Point(420, 289);
            lblLocCa.Name = "lblLocCa";
            lblLocCa.Size = new Size(89, 20);
            lblLocCa.TabIndex = 7;
            lblLocCa.Text = "Lọc theo ca";
            //
            // cboLocCa
            //
            cboLocCa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocCa.FormattingEnabled = true;
            cboLocCa.Location = new Point(515, 285);
            cboLocCa.Name = "cboLocCa";
            cboLocCa.Size = new Size(170, 28);
            cboLocCa.TabIndex = 8;
            cboLocCa.SelectedIndexChanged += cboLocCa_SelectedIndexChanged;
            //
            // lblSoNhanVien
            //
            lblSoNhanVien.AutoSize = true;
            lblSoNhanVien.Location = new Point(710, 289);
            lblSoNhanVien.Name = "lblSoNhanVien";
            lblSoNhanVien.Size = new Size(0, 20);
            lblSoNhanVien.TabIndex = 9;
            //
            // dgvNhanVien
            //
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.DataSource = bindingSource1;
            dgvNhanVien.Location = new Point(12, 324);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(1006, 300);
            dgvNhanVien.TabIndex = 10;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // frmNhanVien
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 636);
            Controls.Add(dgvNhanVien);
            Controls.Add(lblSoNhanVien);
            Controls.Add(cboLocCa);
            Controls.Add(lblLocCa);
            Controls.Add(txtTimKiem);
            Controls.Add(lblTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpThongTin);
            Name = "frmNhanVien";
            Text = "Quản lý nhân viên";
            Load += frmNhanVien_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private Label lblCaLamViec;
        private ComboBox cboCaLamViec;
        private Label lblNgayVaoLam;
        private DateTimePicker dtpNgayVaoLam;
        private CheckBox chkDangLam;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblLocCa;
        private ComboBox cboLocCa;
        private Label lblSoNhanVien;
        private DataGridView dgvNhanVien;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
    }
}
