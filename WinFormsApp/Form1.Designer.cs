namespace WinFormsApp
{
    partial class FDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBTenDangNhap = new System.Windows.Forms.TextBox();
            this.tBMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.rbNguoiChu = new System.Windows.Forms.RadioButton();
            this.rbNguoiThue = new System.Windows.Forms.RadioButton();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.lbLoiTDN = new System.Windows.Forms.Label();
            this.lbLoiMK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label1.Location = new System.Drawing.Point(64, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(402, 57);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Quản Lý Phòng Trọ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(40, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(48, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // tBTenDangNhap
            // 
            this.tBTenDangNhap.Location = new System.Drawing.Point(232, 152);
            this.tBTenDangNhap.Name = "tBTenDangNhap";
            this.tBTenDangNhap.Size = new System.Drawing.Size(240, 27);
            this.tBTenDangNhap.TabIndex = 3;
            // 
            // tBMatKhau
            // 
            this.tBMatKhau.Location = new System.Drawing.Point(232, 224);
            this.tBMatKhau.Name = "tBMatKhau";
            this.tBMatKhau.Size = new System.Drawing.Size(240, 27);
            this.tBMatKhau.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDangNhap.Location = new System.Drawing.Point(344, 336);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(128, 32);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // rbNguoiChu
            // 
            this.rbNguoiChu.AutoSize = true;
            this.rbNguoiChu.Location = new System.Drawing.Point(368, 288);
            this.rbNguoiChu.Name = "rbNguoiChu";
            this.rbNguoiChu.Size = new System.Drawing.Size(101, 24);
            this.rbNguoiChu.TabIndex = 6;
            this.rbNguoiChu.Text = "Người Chủ";
            this.rbNguoiChu.UseVisualStyleBackColor = true;
            // 
            // rbNguoiThue
            // 
            this.rbNguoiThue.AutoSize = true;
            this.rbNguoiThue.Checked = true;
            this.rbNguoiThue.Location = new System.Drawing.Point(232, 288);
            this.rbNguoiThue.Name = "rbNguoiThue";
            this.rbNguoiThue.Size = new System.Drawing.Size(108, 24);
            this.rbNguoiThue.TabIndex = 7;
            this.rbNguoiThue.TabStop = true;
            this.rbNguoiThue.Text = "Người Thuê";
            this.rbNguoiThue.UseVisualStyleBackColor = true;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDangKy.Location = new System.Drawing.Point(56, 336);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(128, 32);
            this.btnDangKy.TabIndex = 8;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            // 
            // lbLoiTDN
            // 
            this.lbLoiTDN.AutoSize = true;
            this.lbLoiTDN.ForeColor = System.Drawing.Color.Crimson;
            this.lbLoiTDN.Location = new System.Drawing.Point(232, 184);
            this.lbLoiTDN.Name = "lbLoiTDN";
            this.lbLoiTDN.Size = new System.Drawing.Size(25, 20);
            this.lbLoiTDN.TabIndex = 9;
            this.lbLoiTDN.Text = "    ";
            // 
            // lbLoiMK
            // 
            this.lbLoiMK.AutoSize = true;
            this.lbLoiMK.ForeColor = System.Drawing.Color.Crimson;
            this.lbLoiMK.Location = new System.Drawing.Point(232, 256);
            this.lbLoiMK.Name = "lbLoiMK";
            this.lbLoiMK.Size = new System.Drawing.Size(25, 20);
            this.lbLoiMK.TabIndex = 10;
            this.lbLoiMK.Text = "    ";
            // 
            // FDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 406);
            this.Controls.Add(this.lbLoiMK);
            this.Controls.Add(this.lbLoiTDN);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.rbNguoiThue);
            this.Controls.Add(this.rbNguoiChu);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.tBMatKhau);
            this.Controls.Add(this.tBTenDangNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Label1;
        private Label label2;
        private Label label3;
        private TextBox tBTenDangNhap;
        private TextBox tBMatKhau;
        private Button btnDangNhap;
        private RadioButton rbNguoiChu;
        private RadioButton rbNguoiThue;
        private Button btnDangKy;
        private Label lbLoiTDN;
        private Label lbLoiMK;
    }
}