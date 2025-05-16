namespace Quan_ly_nhan_su  
{
    partial class frmChiNhanh
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
            this.cmdxoachinhanh = new System.Windows.Forms.Button();
            this.cmdsuachinhanh = new System.Windows.Forms.Button();
            this.cmdthemchinhanh = new System.Windows.Forms.Button();
            this.txtmacn = new System.Windows.Forms.TextBox();
            this.txttencn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDanhSach = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdGhi = new System.Windows.Forms.Button();
            this.cmdKhong = new System.Windows.Forms.Button();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdtoanbo = new System.Windows.Forms.Button();
            this.cbomaCN = new System.Windows.Forms.ComboBox();
            this.dgNV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdxoachinhanh
            // 
            this.cmdxoachinhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdxoachinhanh.Location = new System.Drawing.Point(426, 151);
            this.cmdxoachinhanh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdxoachinhanh.Name = "cmdxoachinhanh";
            this.cmdxoachinhanh.Size = new System.Drawing.Size(124, 62);
            this.cmdxoachinhanh.TabIndex = 1;
            this.cmdxoachinhanh.Text = "Xóa chi nhánh";
            this.cmdxoachinhanh.UseVisualStyleBackColor = true;
            this.cmdxoachinhanh.Click += new System.EventHandler(this.cmdxoachinhanh_Click);
            // 
            // cmdsuachinhanh
            // 
            this.cmdsuachinhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdsuachinhanh.Location = new System.Drawing.Point(245, 223);
            this.cmdsuachinhanh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdsuachinhanh.Name = "cmdsuachinhanh";
            this.cmdsuachinhanh.Size = new System.Drawing.Size(158, 62);
            this.cmdsuachinhanh.TabIndex = 2;
            this.cmdsuachinhanh.Text = "Sửa chi nhánh";
            this.cmdsuachinhanh.UseVisualStyleBackColor = true;
            this.cmdsuachinhanh.Click += new System.EventHandler(this.cmdsuachinhanh_Click);
            // 
            // cmdthemchinhanh
            // 
            this.cmdthemchinhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdthemchinhanh.Location = new System.Drawing.Point(245, 151);
            this.cmdthemchinhanh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdthemchinhanh.Name = "cmdthemchinhanh";
            this.cmdthemchinhanh.Size = new System.Drawing.Size(158, 62);
            this.cmdthemchinhanh.TabIndex = 3;
            this.cmdthemchinhanh.Text = "Thêm chi nhánh";
            this.cmdthemchinhanh.UseVisualStyleBackColor = true;
            this.cmdthemchinhanh.Click += new System.EventHandler(this.cmdthemchinhanh_Click);
            // 
            // txtmacn
            // 
            this.txtmacn.Location = new System.Drawing.Point(245, 31);
            this.txtmacn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtmacn.Name = "txtmacn";
            this.txtmacn.Size = new System.Drawing.Size(305, 30);
            this.txtmacn.TabIndex = 5;
            // 
            // txttencn
            // 
            this.txttencn.Location = new System.Drawing.Point(245, 71);
            this.txttencn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txttencn.Name = "txttencn";
            this.txttencn.Size = new System.Drawing.Size(305, 30);
            this.txttencn.TabIndex = 6;
            this.txttencn.TextChanged += new System.EventHandler(this.txttencn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(40, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên chi nhánh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(40, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã chi nhánh";
            // 
            // dgDanhSach
            // 
            this.dgDanhSach.AllowUserToAddRows = false;
            this.dgDanhSach.AllowUserToDeleteRows = false;
            this.dgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDanhSach.BackgroundColor = System.Drawing.Color.White;
            this.dgDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgDanhSach.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgDanhSach.Location = new System.Drawing.Point(611, 115);
            this.dgDanhSach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgDanhSach.Name = "dgDanhSach";
            this.dgDanhSach.ReadOnly = true;
            this.dgDanhSach.RowHeadersWidth = 51;
            this.dgDanhSach.RowTemplate.Height = 24;
            this.dgDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDanhSach.Size = new System.Drawing.Size(568, 279);
            this.dgDanhSach.TabIndex = 12;
            this.dgDanhSach.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDanhSach_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "maCN";
            this.Column1.FillWeight = 80.21391F;
            this.Column1.HeaderText = "Mã chi nhánh";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tenCN";
            this.Column2.FillWeight = 104.0722F;
            this.Column2.HeaderText = "Tên chi nhánh";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DiaChi";
            this.Column3.FillWeight = 115.7139F;
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // cmdGhi
            // 
            this.cmdGhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdGhi.Location = new System.Drawing.Point(426, 223);
            this.cmdGhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(124, 62);
            this.cmdGhi.TabIndex = 14;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.UseVisualStyleBackColor = true;
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdKhong
            // 
            this.cmdKhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdKhong.Location = new System.Drawing.Point(18, 197);
            this.cmdKhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdKhong.Name = "cmdKhong";
            this.cmdKhong.Size = new System.Drawing.Size(181, 55);
            this.cmdKhong.TabIndex = 15;
            this.cmdKhong.Text = "Kết thúc";
            this.cmdKhong.UseVisualStyleBackColor = true;
            this.cmdKhong.Click += new System.EventHandler(this.cmdKhong_Click);
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(245, 111);
            this.txtDiaDiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(305, 30);
            this.txtDiaDiem.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(40, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Địa Điểm";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(608, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(571, 38);
            this.label5.TabIndex = 20;
            this.label5.Text = "QUẢN LÝ THÔNG TIN CHI NHÁNH";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdtoanbo
            // 
            this.cmdtoanbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdtoanbo.Location = new System.Drawing.Point(422, 17);
            this.cmdtoanbo.Margin = new System.Windows.Forms.Padding(4);
            this.cmdtoanbo.Name = "cmdtoanbo";
            this.cmdtoanbo.Size = new System.Drawing.Size(163, 41);
            this.cmdtoanbo.TabIndex = 24;
            this.cmdtoanbo.Text = "Toàn bộ";
            this.cmdtoanbo.UseVisualStyleBackColor = true;
            this.cmdtoanbo.Click += new System.EventHandler(this.cmdtoanbo_Click);
            // 
            // cbomaCN
            // 
            this.cbomaCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbomaCN.FormattingEnabled = true;
            this.cbomaCN.Location = new System.Drawing.Point(110, 22);
            this.cbomaCN.Margin = new System.Windows.Forms.Padding(4);
            this.cbomaCN.Name = "cbomaCN";
            this.cbomaCN.Size = new System.Drawing.Size(304, 33);
            this.cbomaCN.TabIndex = 25;
            this.cbomaCN.SelectedIndexChanged += new System.EventHandler(this.cbomaCN_SelectedIndexChanged);
            // 
            // dgNV
            // 
            this.dgNV.AllowUserToAddRows = false;
            this.dgNV.AllowUserToDeleteRows = false;
            this.dgNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNV.BackgroundColor = System.Drawing.Color.White;
            this.dgNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNV.Location = new System.Drawing.Point(19, 207);
            this.dgNV.Margin = new System.Windows.Forms.Padding(4);
            this.dgNV.Name = "dgNV";
            this.dgNV.ReadOnly = true;
            this.dgNV.RowHeadersWidth = 51;
            this.dgNV.RowTemplate.Height = 24;
            this.dgNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNV.Size = new System.Drawing.Size(589, 498);
            this.dgNV.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(108, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 38);
            this.label6.TabIndex = 27;
            this.label6.Text = "Danh sách nhân viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(16, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 25);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tìm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 98);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbomaCN);
            this.panel2.Controls.Add(this.cmdtoanbo);
            this.panel2.Location = new System.Drawing.Point(15, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 85);
            this.panel2.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtmacn);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txttencn);
            this.panel3.Controls.Add(this.cmdGhi);
            this.panel3.Controls.Add(this.cmdKhong);
            this.panel3.Controls.Add(this.txtDiaDiem);
            this.panel3.Controls.Add(this.cmdxoachinhanh);
            this.panel3.Controls.Add(this.cmdsuachinhanh);
            this.panel3.Controls.Add(this.cmdthemchinhanh);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(615, 402);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(565, 303);
            this.panel3.TabIndex = 31;
            // 
            // frmChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1192, 713);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgNV);
            this.Controls.Add(this.dgDanhSach);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChiNhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin chi nhánh";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChiNhanh_FormClosing);
            this.Load += new System.EventHandler(this.frmChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdxoachinhanh;
        private System.Windows.Forms.Button cmdsuachinhanh;
        private System.Windows.Forms.Button cmdthemchinhanh;
        private System.Windows.Forms.TextBox txtmacn;
        private System.Windows.Forms.TextBox txttencn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgDanhSach;
        private System.Windows.Forms.Button cmdGhi;
        private System.Windows.Forms.Button cmdKhong;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdtoanbo;
        private System.Windows.Forms.ComboBox cbomaCN;
        private System.Windows.Forms.DataGridView dgNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}