namespace LastTermC_.GUI
{
    partial class frmPOS
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
            tabControl1 = new TabControl();
            tpBanHang = new TabPage();
            tpHoaDon = new TabPage();
            lblthongtinmagiamgia = new Label();
            btnMaGiamGia = new Button();
            groupBox1 = new GroupBox();
            txtNhapMaGiamGia = new TextBox();
            baoloi = new ErrorProvider(components);
            btnXoaSP = new Button();
            btnThemSP = new Button();
            btnso9 = new Button();
            btnso8 = new Button();
            btnso7 = new Button();
            btnso6 = new Button();
            btnso5 = new Button();
            btnso4 = new Button();
            btnso3 = new Button();
            btnso2 = new Button();
            btnso1 = new Button();
            btnso0 = new Button();
            lblDSSPTHD = new Label();
            lblDSSP = new Label();
            btnTimKiem = new Button();
            txtTimKiemSP = new TextBox();
            btnTheNganHang = new Button();
            btnThanhToan = new Button();
            lblTimkiemSP = new Label();
            btnTienMat = new Button();
            dtvSanPhamtrongHoaDon = new DataGridView();
            grbThanhToan = new GroupBox();
            btnQRcode = new Button();
            dtvSanPhamtrongKhoHang = new DataGridView();
            groupBox2 = new GroupBox();
            rtbNoiDungHoaDon = new RichTextBox();
            btnInHoaDon = new Button();
            btnXoaHoaDonHoanSP = new Button();
            tabControl1.SuspendLayout();
            tpBanHang.SuspendLayout();
            tpHoaDon.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)baoloi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtvSanPhamtrongHoaDon).BeginInit();
            grbThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtvSanPhamtrongKhoHang).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpBanHang);
            tabControl1.Controls.Add(tpHoaDon);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1530, 939);
            tabControl1.TabIndex = 0;
            // 
            // tpBanHang
            // 
            tpBanHang.Controls.Add(groupBox1);
            tpBanHang.Controls.Add(btnXoaSP);
            tpBanHang.Controls.Add(btnThemSP);
            tpBanHang.Controls.Add(btnso9);
            tpBanHang.Controls.Add(btnso8);
            tpBanHang.Controls.Add(btnso7);
            tpBanHang.Controls.Add(btnso6);
            tpBanHang.Controls.Add(btnso5);
            tpBanHang.Controls.Add(btnso4);
            tpBanHang.Controls.Add(btnso3);
            tpBanHang.Controls.Add(btnso2);
            tpBanHang.Controls.Add(btnso1);
            tpBanHang.Controls.Add(btnso0);
            tpBanHang.Controls.Add(lblDSSPTHD);
            tpBanHang.Controls.Add(lblDSSP);
            tpBanHang.Controls.Add(btnTimKiem);
            tpBanHang.Controls.Add(txtTimKiemSP);
            tpBanHang.Controls.Add(lblTimkiemSP);
            tpBanHang.Controls.Add(dtvSanPhamtrongHoaDon);
            tpBanHang.Controls.Add(grbThanhToan);
            tpBanHang.Controls.Add(dtvSanPhamtrongKhoHang);
            tpBanHang.Location = new Point(4, 29);
            tpBanHang.Name = "tpBanHang";
            tpBanHang.Padding = new Padding(3);
            tpBanHang.Size = new Size(1522, 906);
            tpBanHang.TabIndex = 0;
            tpBanHang.Text = "BÁN HÀNG";
            tpBanHang.UseVisualStyleBackColor = true;
            // 
            // tpHoaDon
            // 
            tpHoaDon.Controls.Add(rtbNoiDungHoaDon);
            tpHoaDon.Controls.Add(groupBox2);
            tpHoaDon.Location = new Point(4, 29);
            tpHoaDon.Name = "tpHoaDon";
            tpHoaDon.Padding = new Padding(3);
            tpHoaDon.Size = new Size(1522, 906);
            tpHoaDon.TabIndex = 1;
            tpHoaDon.Text = "HOÁ ĐƠN";
            tpHoaDon.UseVisualStyleBackColor = true;
            // 
            // lblthongtinmagiamgia
            // 
            lblthongtinmagiamgia.AutoSize = true;
            lblthongtinmagiamgia.Location = new Point(18, 82);
            lblthongtinmagiamgia.Name = "lblthongtinmagiamgia";
            lblthongtinmagiamgia.Size = new Size(185, 20);
            lblthongtinmagiamgia.TabIndex = 24;
            lblthongtinmagiamgia.Text = "Thông Tin Mã Giảm Giá:  ...";
            // 
            // btnMaGiamGia
            // 
            btnMaGiamGia.BackColor = Color.Chartreuse;
            btnMaGiamGia.Location = new Point(389, 26);
            btnMaGiamGia.Name = "btnMaGiamGia";
            btnMaGiamGia.Size = new Size(162, 39);
            btnMaGiamGia.TabIndex = 2;
            btnMaGiamGia.Text = "Nhập Mã Giảm Giá";
            btnMaGiamGia.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblthongtinmagiamgia);
            groupBox1.Controls.Add(txtNhapMaGiamGia);
            groupBox1.Controls.Add(btnMaGiamGia);
            groupBox1.Location = new Point(947, 569);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(557, 125);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mã Giảm Giá";
            // 
            // txtNhapMaGiamGia
            // 
            txtNhapMaGiamGia.Location = new Point(94, 32);
            txtNhapMaGiamGia.Name = "txtNhapMaGiamGia";
            txtNhapMaGiamGia.Size = new Size(289, 27);
            txtNhapMaGiamGia.TabIndex = 23;
            // 
            // baoloi
            // 
            baoloi.ContainerControl = this;
            // 
            // btnXoaSP
            // 
            btnXoaSP.Font = new Font("Segoe UI", 10F);
            btnXoaSP.Location = new Point(1366, 247);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(148, 78);
            btnXoaSP.TabIndex = 43;
            btnXoaSP.Text = "Xoá Sản Phẩm";
            btnXoaSP.UseVisualStyleBackColor = true;
            // 
            // btnThemSP
            // 
            btnThemSP.Font = new Font("Segoe UI", 10F);
            btnThemSP.Location = new Point(1366, 129);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(148, 78);
            btnThemSP.TabIndex = 42;
            btnThemSP.Text = "Thêm sản phẩm";
            btnThemSP.UseVisualStyleBackColor = true;
            // 
            // btnso9
            // 
            btnso9.Font = new Font("Segoe UI", 20F);
            btnso9.Location = new Point(1231, 363);
            btnso9.Name = "btnso9";
            btnso9.Size = new Size(94, 78);
            btnso9.TabIndex = 41;
            btnso9.Text = "9";
            btnso9.UseVisualStyleBackColor = true;
            // 
            // btnso8
            // 
            btnso8.Font = new Font("Segoe UI", 20F);
            btnso8.Location = new Point(1110, 363);
            btnso8.Name = "btnso8";
            btnso8.Size = new Size(94, 78);
            btnso8.TabIndex = 40;
            btnso8.Text = "8";
            btnso8.UseVisualStyleBackColor = true;
            // 
            // btnso7
            // 
            btnso7.Font = new Font("Segoe UI", 20F);
            btnso7.Location = new Point(990, 363);
            btnso7.Name = "btnso7";
            btnso7.Size = new Size(94, 78);
            btnso7.TabIndex = 39;
            btnso7.Text = "7";
            btnso7.UseVisualStyleBackColor = true;
            // 
            // btnso6
            // 
            btnso6.Font = new Font("Segoe UI", 20F);
            btnso6.Location = new Point(1231, 247);
            btnso6.Name = "btnso6";
            btnso6.Size = new Size(94, 78);
            btnso6.TabIndex = 38;
            btnso6.Text = "6";
            btnso6.UseVisualStyleBackColor = true;
            // 
            // btnso5
            // 
            btnso5.Font = new Font("Segoe UI", 20F);
            btnso5.Location = new Point(1110, 247);
            btnso5.Name = "btnso5";
            btnso5.Size = new Size(94, 78);
            btnso5.TabIndex = 37;
            btnso5.Text = "5";
            btnso5.UseVisualStyleBackColor = true;
            // 
            // btnso4
            // 
            btnso4.Font = new Font("Segoe UI", 20F);
            btnso4.Location = new Point(990, 247);
            btnso4.Name = "btnso4";
            btnso4.Size = new Size(94, 78);
            btnso4.TabIndex = 36;
            btnso4.Text = "4";
            btnso4.UseVisualStyleBackColor = true;
            // 
            // btnso3
            // 
            btnso3.Font = new Font("Segoe UI", 20F);
            btnso3.Location = new Point(1231, 129);
            btnso3.Name = "btnso3";
            btnso3.Size = new Size(94, 78);
            btnso3.TabIndex = 35;
            btnso3.Text = "3";
            btnso3.UseVisualStyleBackColor = true;
            // 
            // btnso2
            // 
            btnso2.Font = new Font("Segoe UI", 20F);
            btnso2.Location = new Point(1110, 129);
            btnso2.Name = "btnso2";
            btnso2.Size = new Size(94, 78);
            btnso2.TabIndex = 34;
            btnso2.Text = "2";
            btnso2.UseVisualStyleBackColor = true;
            // 
            // btnso1
            // 
            btnso1.Font = new Font("Segoe UI", 20F);
            btnso1.Location = new Point(990, 129);
            btnso1.Name = "btnso1";
            btnso1.Size = new Size(94, 78);
            btnso1.TabIndex = 33;
            btnso1.Text = "1";
            btnso1.UseVisualStyleBackColor = true;
            // 
            // btnso0
            // 
            btnso0.Font = new Font("Segoe UI", 20F);
            btnso0.Location = new Point(1110, 472);
            btnso0.Name = "btnso0";
            btnso0.Size = new Size(94, 78);
            btnso0.TabIndex = 32;
            btnso0.Text = "0";
            btnso0.UseVisualStyleBackColor = true;
            // 
            // lblDSSPTHD
            // 
            lblDSSPTHD.AutoSize = true;
            lblDSSPTHD.Location = new Point(492, 14);
            lblDSSPTHD.Name = "lblDSSPTHD";
            lblDSSPTHD.Size = new Size(254, 20);
            lblDSSPTHD.TabIndex = 31;
            lblDSSPTHD.Text = "Danh Sách Sản Phẩm Trong Hoá Đơn";
            // 
            // lblDSSP
            // 
            lblDSSP.AutoSize = true;
            lblDSSP.Location = new Point(63, 14);
            lblDSSP.Name = "lblDSSP";
            lblDSSP.Size = new Size(148, 20);
            lblDSSP.TabIndex = 30;
            lblDSSP.Text = "Danh Sách Sản Phẩm";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(1400, 39);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 29;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemSP
            // 
            txtTimKiemSP.Location = new Point(1104, 41);
            txtTimKiemSP.Name = "txtTimKiemSP";
            txtTimKiemSP.Size = new Size(289, 27);
            txtTimKiemSP.TabIndex = 27;
            // 
            // btnTheNganHang
            // 
            btnTheNganHang.BackColor = Color.Chartreuse;
            btnTheNganHang.Location = new Point(58, 26);
            btnTheNganHang.Name = "btnTheNganHang";
            btnTheNganHang.Size = new Size(146, 39);
            btnTheNganHang.TabIndex = 2;
            btnTheNganHang.Text = "Thẻ Ngân Hàng";
            btnTheNganHang.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.LightYellow;
            btnThanhToan.Location = new Point(391, 26);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(146, 80);
            btnThanhToan.TabIndex = 1;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // lblTimkiemSP
            // 
            lblTimkiemSP.AutoSize = true;
            lblTimkiemSP.Location = new Point(957, 44);
            lblTimkiemSP.Name = "lblTimkiemSP";
            lblTimkiemSP.Size = new Size(141, 20);
            lblTimkiemSP.TabIndex = 26;
            lblTimkiemSP.Text = "Tìm Kiếm Sản Phẩm";
            // 
            // btnTienMat
            // 
            btnTienMat.BackColor = Color.Chartreuse;
            btnTienMat.Location = new Point(58, 73);
            btnTienMat.Name = "btnTienMat";
            btnTienMat.Size = new Size(146, 39);
            btnTienMat.TabIndex = 4;
            btnTienMat.Text = "Tiền Mặt";
            btnTienMat.UseVisualStyleBackColor = false;
            // 
            // dtvSanPhamtrongHoaDon
            // 
            dtvSanPhamtrongHoaDon.BackgroundColor = SystemColors.ButtonHighlight;
            dtvSanPhamtrongHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtvSanPhamtrongHoaDon.Location = new Point(285, 44);
            dtvSanPhamtrongHoaDon.Name = "dtvSanPhamtrongHoaDon";
            dtvSanPhamtrongHoaDon.RowHeadersWidth = 51;
            dtvSanPhamtrongHoaDon.Size = new Size(641, 722);
            dtvSanPhamtrongHoaDon.TabIndex = 24;
            // 
            // grbThanhToan
            // 
            grbThanhToan.Controls.Add(btnTienMat);
            grbThanhToan.Controls.Add(btnQRcode);
            grbThanhToan.Controls.Add(btnTheNganHang);
            grbThanhToan.Controls.Add(btnThanhToan);
            grbThanhToan.Location = new Point(947, 700);
            grbThanhToan.Name = "grbThanhToan";
            grbThanhToan.Size = new Size(557, 125);
            grbThanhToan.TabIndex = 23;
            grbThanhToan.TabStop = false;
            grbThanhToan.Text = "Thanh Toán";
            // 
            // btnQRcode
            // 
            btnQRcode.BackColor = Color.Chartreuse;
            btnQRcode.Location = new Point(210, 26);
            btnQRcode.Name = "btnQRcode";
            btnQRcode.Size = new Size(146, 39);
            btnQRcode.TabIndex = 3;
            btnQRcode.Text = "QR";
            btnQRcode.UseVisualStyleBackColor = false;
            // 
            // dtvSanPhamtrongKhoHang
            // 
            dtvSanPhamtrongKhoHang.BackgroundColor = SystemColors.ButtonHighlight;
            dtvSanPhamtrongKhoHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtvSanPhamtrongKhoHang.Location = new Point(8, 44);
            dtvSanPhamtrongKhoHang.Name = "dtvSanPhamtrongKhoHang";
            dtvSanPhamtrongKhoHang.RowHeadersWidth = 51;
            dtvSanPhamtrongKhoHang.Size = new Size(271, 722);
            dtvSanPhamtrongKhoHang.TabIndex = 22;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXoaHoaDonHoanSP);
            groupBox2.Controls.Add(btnInHoaDon);
            groupBox2.Location = new Point(20, 16);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(291, 158);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hoá Đơn";
            // 
            // rtbNoiDungHoaDon
            // 
            rtbNoiDungHoaDon.Location = new Point(355, 16);
            rtbNoiDungHoaDon.Name = "rtbNoiDungHoaDon";
            rtbNoiDungHoaDon.Size = new Size(1086, 815);
            rtbNoiDungHoaDon.TabIndex = 1;
            rtbNoiDungHoaDon.Text = "";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.BackColor = Color.Gold;
            btnInHoaDon.Location = new Point(24, 40);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(250, 29);
            btnInHoaDon.TabIndex = 0;
            btnInHoaDon.Text = "In Hoá Đơn";
            btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnXoaHoaDonHoanSP
            // 
            btnXoaHoaDonHoanSP.BackColor = Color.Gold;
            btnXoaHoaDonHoanSP.Location = new Point(24, 75);
            btnXoaHoaDonHoanSP.Name = "btnXoaHoaDonHoanSP";
            btnXoaHoaDonHoanSP.Size = new Size(250, 29);
            btnXoaHoaDonHoanSP.TabIndex = 1;
            btnXoaHoaDonHoanSP.Text = "Xoá Hoá Đơn - Hoàn Sản Phẩm";
            btnXoaHoaDonHoanSP.UseVisualStyleBackColor = false;
            // 
            // frmPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1530, 939);
            Controls.Add(tabControl1);
            Name = "frmPOS";
            Text = "POS BÁN HÀNG";
            tabControl1.ResumeLayout(false);
            tpBanHang.ResumeLayout(false);
            tpBanHang.PerformLayout();
            tpHoaDon.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)baoloi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtvSanPhamtrongHoaDon).EndInit();
            grbThanhToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtvSanPhamtrongKhoHang).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpBanHang;
        private GroupBox groupBox1;
        private Label lblthongtinmagiamgia;
        private TextBox txtNhapMaGiamGia;
        private Button btnMaGiamGia;
        private Button btnXoaSP;
        private Button btnThemSP;
        private Button btnso9;
        private Button btnso8;
        private Button btnso7;
        private Button btnso6;
        private Button btnso5;
        private Button btnso4;
        private Button btnso3;
        private Button btnso2;
        private Button btnso1;
        private Button btnso0;
        private Label lblDSSPTHD;
        private Label lblDSSP;
        private Button btnTimKiem;
        private TextBox txtTimKiemSP;
        private Label lblTimkiemSP;
        private DataGridView dtvSanPhamtrongHoaDon;
        private GroupBox grbThanhToan;
        private Button btnTienMat;
        private Button btnQRcode;
        private Button btnTheNganHang;
        private Button btnThanhToan;
        private DataGridView dtvSanPhamtrongKhoHang;
        private TabPage tpHoaDon;
        private GroupBox groupBox2;
        private ErrorProvider baoloi;
        private RichTextBox rtbNoiDungHoaDon;
        private Button btnXoaHoaDonHoanSP;
        private Button btnInHoaDon;
    }
}