namespace LastTermC_.GUI
{
    partial class frmMain
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
            mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            menuStrip1 = new MenuStrip();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            pOSToolStripMenuItem = new ToolStripMenuItem();
            quảnLýHoáĐơnToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            mySqlDataAdapter1.DeleteCommand = null;
            mySqlDataAdapter1.InsertCommand = null;
            mySqlDataAdapter1.SelectCommand = null;
            mySqlDataAdapter1.UpdateCommand = null;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { bánHàngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1589, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pOSToolStripMenuItem, quảnLýHoáĐơnToolStripMenuItem });
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(92, 24);
            bánHàngToolStripMenuItem.Text = "Bán Hàng ";
            // 
            // pOSToolStripMenuItem
            // 
            pOSToolStripMenuItem.Name = "pOSToolStripMenuItem";
            pOSToolStripMenuItem.Size = new Size(224, 26);
            pOSToolStripMenuItem.Text = "POS";
            // 
            // quảnLýHoáĐơnToolStripMenuItem
            // 
            quảnLýHoáĐơnToolStripMenuItem.Name = "quảnLýHoáĐơnToolStripMenuItem";
            quảnLýHoáĐơnToolStripMenuItem.Size = new Size(224, 26);
            quảnLýHoáĐơnToolStripMenuItem.Text = "Quản Lý Hoá Đơn";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1589, 978);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "frmMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
        private ToolStripMenuItem pOSToolStripMenuItem;
        private ToolStripMenuItem quảnLýHoáĐơnToolStripMenuItem;
    }
}