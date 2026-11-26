namespace LastTermC_.GUI
{
    partial class frmDoiMatKhau
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
            lblMatKhauCu = new Label();
            txtMatKhauCu = new TextBox();
            lblMatKhauMoi = new Label();
            txtMatKhauMoi = new TextBox();
            lblXacNhan = new Label();
            txtXacNhan = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnLuu = new Button();
            btnHuy = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // lblMatKhauCu
            //
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Location = new Point(30, 30);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(91, 20);
            lblMatKhauCu.TabIndex = 0;
            lblMatKhauCu.Text = "Mật khẩu cũ";
            //
            // txtMatKhauCu
            //
            txtMatKhauCu.Location = new Point(190, 27);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(230, 27);
            txtMatKhauCu.TabIndex = 1;
            txtMatKhauCu.UseSystemPasswordChar = true;
            //
            // lblMatKhauMoi
            //
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Location = new Point(30, 72);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(101, 20);
            lblMatKhauMoi.TabIndex = 2;
            lblMatKhauMoi.Text = "Mật khẩu mới";
            //
            // txtMatKhauMoi
            //
            txtMatKhauMoi.Location = new Point(190, 69);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(230, 27);
            txtMatKhauMoi.TabIndex = 3;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            //
            // lblXacNhan
            //
            lblXacNhan.AutoSize = true;
            lblXacNhan.Location = new Point(30, 114);
            lblXacNhan.Name = "lblXacNhan";
            lblXacNhan.Size = new Size(151, 20);
            lblXacNhan.TabIndex = 4;
            lblXacNhan.Text = "Nhập lại mật khẩu mới";
            //
            // txtXacNhan
            //
            txtXacNhan.Location = new Point(190, 111);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.Size = new Size(230, 27);
            txtXacNhan.TabIndex = 5;
            txtXacNhan.UseSystemPasswordChar = true;
            //
            // chkHienMatKhau
            //
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(190, 148);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(129, 24);
            chkHienMatKhau.TabIndex = 6;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            //
            // btnLuu
            //
            btnLuu.Location = new Point(190, 188);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(110, 38);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            //
            // btnHuy
            //
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(310, 188);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(110, 38);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // frmDoiMatKhau
            //
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(462, 250);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(chkHienMatKhau);
            Controls.Add(txtXacNhan);
            Controls.Add(lblXacNhan);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lblMatKhauCu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMatKhauCu;
        private TextBox txtMatKhauCu;
        private Label lblMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Label lblXacNhan;
        private TextBox txtXacNhan;
        private CheckBox chkHienMatKhau;
        private Button btnLuu;
        private Button btnHuy;
        private ErrorProvider errorProvider1;
    }
}
