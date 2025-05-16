namespace Quan_ly_nhan_su
{
    partial class extNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(extNhanVien));
            this.ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.anh = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.ngayvaolam = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.chiNhanh = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sdt1 = new System.Windows.Forms.TextBox();
            this.sdt = new System.Windows.Forms.TextBox();
            this.loi = new System.Windows.Forms.Label();
            this.sua = new System.Windows.Forms.Button();
            this.capnhat = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.cccd = new System.Windows.Forms.TextBox();
            this.que = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.CV = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nu = new System.Windows.Forms.RadioButton();
            this.nam = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hoTen = new System.Windows.Forms.TextBox();
            this.maNV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.anh)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ngaysinh
            // 
            this.ngaysinh.CustomFormat = "dd/MM/yyyy";
            this.ngaysinh.Enabled = false;
            this.ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaysinh.Location = new System.Drawing.Point(335, 123);
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(188, 30);
            this.ngaysinh.TabIndex = 1;
            this.ngaysinh.Value = new System.DateTime(2024, 8, 12, 0, 0, 0, 0);
            // 
            // anh
            // 
            this.anh.Enabled = false;
            this.anh.Image = ((System.Drawing.Image)(resources.GetObject("anh.Image")));
            this.anh.Location = new System.Drawing.Point(641, 28);
            this.anh.Name = "anh";
            this.anh.Size = new System.Drawing.Size(217, 270);
            this.anh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.anh.TabIndex = 2;
            this.anh.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 73);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin nhân viên";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 1152);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.ngayvaolam);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.chiNhanh);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.sdt1);
            this.panel3.Controls.Add(this.sdt);
            this.panel3.Controls.Add(this.loi);
            this.panel3.Controls.Add(this.sua);
            this.panel3.Controls.Add(this.capnhat);
            this.panel3.Controls.Add(this.xoa);
            this.panel3.Controls.Add(this.cccd);
            this.panel3.Controls.Add(this.que);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.email);
            this.panel3.Controls.Add(this.CV);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.nu);
            this.panel3.Controls.Add(this.nam);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.hoTen);
            this.panel3.Controls.Add(this.maNV);
            this.panel3.Controls.Add(this.anh);
            this.panel3.Controls.Add(this.ngaysinh);
            this.panel3.Location = new System.Drawing.Point(-16, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(910, 513);
            this.panel3.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(527, 315);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 25);
            this.label13.TabIndex = 30;
            this.label13.Text = "Ngày vào làm:";
            // 
            // ngayvaolam
            // 
            this.ngayvaolam.CustomFormat = "dd/MM/yyyy";
            this.ngayvaolam.Enabled = false;
            this.ngayvaolam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayvaolam.Location = new System.Drawing.Point(670, 310);
            this.ngayvaolam.Name = "ngayvaolam";
            this.ngayvaolam.Size = new System.Drawing.Size(188, 30);
            this.ngayvaolam.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 407);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "Đơn vị công tác:";
            // 
            // chiNhanh
            // 
            this.chiNhanh.Enabled = false;
            this.chiNhanh.Location = new System.Drawing.Point(335, 402);
            this.chiNhanh.Name = "chiNhanh";
            this.chiNhanh.Size = new System.Drawing.Size(188, 30);
            this.chiNhanh.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(282, 25);
            this.label12.TabIndex = 26;
            this.label12.Text = "Số điện thoại (Người thân cận):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(236, 25);
            this.label11.TabIndex = 25;
            this.label11.Text = "Số điện thoại (nhân viên):";
            // 
            // sdt1
            // 
            this.sdt1.Enabled = false;
            this.sdt1.Location = new System.Drawing.Point(335, 268);
            this.sdt1.Name = "sdt1";
            this.sdt1.Size = new System.Drawing.Size(188, 30);
            this.sdt1.TabIndex = 24;
            this.sdt1.TextChanged += new System.EventHandler(this.sdt1_TextChanged);
            this.sdt1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sdt1_KeyDown);
            // 
            // sdt
            // 
            this.sdt.Enabled = false;
            this.sdt.Location = new System.Drawing.Point(335, 222);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(188, 30);
            this.sdt.TabIndex = 23;
            this.sdt.TextChanged += new System.EventHandler(this.sdt_TextChanged);
            this.sdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sdt_KeyDown);
            // 
            // loi
            // 
            this.loi.ForeColor = System.Drawing.Color.Red;
            this.loi.Location = new System.Drawing.Point(86, 455);
            this.loi.MaximumSize = new System.Drawing.Size(453, 100);
            this.loi.Name = "loi";
            this.loi.Size = new System.Drawing.Size(383, 58);
            this.loi.TabIndex = 22;
            this.loi.Text = "label10";
            // 
            // sua
            // 
            this.sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sua.Location = new System.Drawing.Point(475, 455);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(107, 42);
            this.sua.TabIndex = 21;
            this.sua.Text = "Sửa";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // capnhat
            // 
            this.capnhat.Enabled = false;
            this.capnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capnhat.Location = new System.Drawing.Point(610, 455);
            this.capnhat.Name = "capnhat";
            this.capnhat.Size = new System.Drawing.Size(116, 42);
            this.capnhat.TabIndex = 20;
            this.capnhat.Text = "Cập nhật";
            this.capnhat.UseVisualStyleBackColor = true;
            this.capnhat.Click += new System.EventHandler(this.capnhat_Click);
            // 
            // xoa
            // 
            this.xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.Location = new System.Drawing.Point(748, 455);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(110, 42);
            this.xoa.TabIndex = 19;
            this.xoa.Text = "Xoá";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // cccd
            // 
            this.cccd.Enabled = false;
            this.cccd.Location = new System.Drawing.Point(670, 402);
            this.cccd.Name = "cccd";
            this.cccd.Size = new System.Drawing.Size(188, 30);
            this.cccd.TabIndex = 18;
            this.cccd.TextChanged += new System.EventHandler(this.cccd_TextChanged);
            this.cccd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cccd_KeyDown);
            // 
            // que
            // 
            this.que.Enabled = false;
            this.que.Location = new System.Drawing.Point(335, 356);
            this.que.Name = "que";
            this.que.Size = new System.Drawing.Size(188, 30);
            this.que.TabIndex = 17;
            this.que.TextChanged += new System.EventHandler(this.que_TextChanged);
            this.que.KeyDown += new System.Windows.Forms.KeyEventHandler(this.que_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(529, 405);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "số CCCD:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Quê quán:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(529, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Chức vụ:";
            // 
            // email
            // 
            this.email.Enabled = false;
            this.email.Location = new System.Drawing.Point(335, 312);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(188, 30);
            this.email.TabIndex = 13;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            this.email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.email_KeyDown);
            // 
            // CV
            // 
            this.CV.Enabled = false;
            this.CV.FormattingEnabled = true;
            this.CV.Location = new System.Drawing.Point(670, 353);
            this.CV.Name = "CV";
            this.CV.Size = new System.Drawing.Size(188, 33);
            this.CV.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Giới tính:";
            // 
            // nu
            // 
            this.nu.AutoSize = true;
            this.nu.Enabled = false;
            this.nu.Location = new System.Drawing.Point(465, 174);
            this.nu.Name = "nu";
            this.nu.Size = new System.Drawing.Size(58, 29);
            this.nu.TabIndex = 9;
            this.nu.TabStop = true;
            this.nu.Text = "Nữ";
            this.nu.UseVisualStyleBackColor = true;
            // 
            // nam
            // 
            this.nam.AutoSize = true;
            this.nam.Enabled = false;
            this.nam.Location = new System.Drawing.Point(335, 174);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(74, 29);
            this.nam.TabIndex = 8;
            this.nam.TabStop = true;
            this.nam.Text = "Nam";
            this.nam.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã nhân viên:";
            // 
            // hoTen
            // 
            this.hoTen.Enabled = false;
            this.hoTen.Location = new System.Drawing.Point(335, 75);
            this.hoTen.Name = "hoTen";
            this.hoTen.Size = new System.Drawing.Size(188, 30);
            this.hoTen.TabIndex = 4;
            this.hoTen.TextChanged += new System.EventHandler(this.hoTen_TextChanged);
            this.hoTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoTen_KeyDown);
            // 
            // maNV
            // 
            this.maNV.Enabled = false;
            this.maNV.Location = new System.Drawing.Point(335, 28);
            this.maNV.Name = "maNV";
            this.maNV.Size = new System.Drawing.Size(188, 30);
            this.maNV.TabIndex = 3;
            // 
            // extNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 588);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "extNhanVien";
            this.Text = "Thông tin nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.extNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.extNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.anh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker ngaysinh;
        private System.Windows.Forms.PictureBox anh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoTen;
        private System.Windows.Forms.TextBox maNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton nu;
        private System.Windows.Forms.RadioButton nam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.ComboBox CV;
        private System.Windows.Forms.TextBox que;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cccd;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button capnhat;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Label loi;
        private System.Windows.Forms.TextBox sdt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sdt1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox chiNhanh;
        private System.Windows.Forms.DateTimePicker ngayvaolam;
        private System.Windows.Forms.Label label13;
    }
}