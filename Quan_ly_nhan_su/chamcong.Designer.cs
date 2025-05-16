namespace Quan_ly_nhan_su
{
    partial class chamcong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayCham = new System.Windows.Forms.DateTimePicker();
            this.tatca = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.donvi = new System.Windows.Forms.ComboBox();
            this.dgDanhSach = new System.Windows.Forms.DataGridView();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayCham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cham = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CheckInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gui = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 56);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chấm công";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpNgayCham);
            this.panel2.Controls.Add(this.tatca);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.donvi);
            this.panel2.Location = new System.Drawing.Point(12, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 61);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thời gian:";
            // 
            // dtpNgayCham
            // 
            this.dtpNgayCham.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayCham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayCham.Location = new System.Drawing.Point(464, 14);
            this.dtpNgayCham.Name = "dtpNgayCham";
            this.dtpNgayCham.Size = new System.Drawing.Size(178, 30);
            this.dtpNgayCham.TabIndex = 4;
            this.dtpNgayCham.ValueChanged += new System.EventHandler(this.dtpNgayCham_ValueChanged);
            // 
            // tatca
            // 
            this.tatca.AutoSize = true;
            this.tatca.Location = new System.Drawing.Point(675, 18);
            this.tatca.Name = "tatca";
            this.tatca.Size = new System.Drawing.Size(134, 29);
            this.tatca.TabIndex = 3;
            this.tatca.Text = "Chọn tất cả";
            this.tatca.UseVisualStyleBackColor = true;
            this.tatca.CheckedChanged += new System.EventHandler(this.tatca_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đơn vị:";
            // 
            // donvi
            // 
            this.donvi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.donvi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.donvi.FormattingEnabled = true;
            this.donvi.Location = new System.Drawing.Point(111, 11);
            this.donvi.Name = "donvi";
            this.donvi.Size = new System.Drawing.Size(204, 33);
            this.donvi.TabIndex = 0;
            this.donvi.SelectedIndexChanged += new System.EventHandler(this.donvi_SelectedIndexChanged);
            // 
            // dgDanhSach
            // 
            this.dgDanhSach.AllowUserToAddRows = false;
            this.dgDanhSach.AllowUserToDeleteRows = false;
            this.dgDanhSach.AllowUserToResizeColumns = false;
            this.dgDanhSach.AllowUserToResizeRows = false;
            this.dgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDanhSach.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNV,
            this.tenNV,
            this.ngayCham,
            this.Cham,
            this.CheckInTime});
            this.dgDanhSach.Location = new System.Drawing.Point(12, 129);
            this.dgDanhSach.MultiSelect = false;
            this.dgDanhSach.Name = "dgDanhSach";
            this.dgDanhSach.RowHeadersWidth = 51;
            this.dgDanhSach.RowTemplate.Height = 24;
            this.dgDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDanhSach.Size = new System.Drawing.Size(812, 282);
            this.dgDanhSach.TabIndex = 2;
            // 
            // maNV
            // 
            this.maNV.DataPropertyName = "maNV";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.maNV.DefaultCellStyle = dataGridViewCellStyle6;
            this.maNV.HeaderText = "Mã nhân viên";
            this.maNV.MinimumWidth = 6;
            this.maNV.Name = "maNV";
            // 
            // tenNV
            // 
            this.tenNV.DataPropertyName = "tenNV";
            this.tenNV.HeaderText = "Tên nhân viên";
            this.tenNV.MinimumWidth = 6;
            this.tenNV.Name = "tenNV";
            // 
            // ngayCham
            // 
            this.ngayCham.DataPropertyName = "NgayCham";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ngayCham.DefaultCellStyle = dataGridViewCellStyle7;
            this.ngayCham.HeaderText = "Ngày chấm";
            this.ngayCham.MinimumWidth = 6;
            this.ngayCham.Name = "ngayCham";
            // 
            // Cham
            // 
            this.Cham.HeaderText = "Chấm";
            this.Cham.MinimumWidth = 6;
            this.Cham.Name = "Cham";
            // 
            // CheckInTime
            // 
            this.CheckInTime.DataPropertyName = "CheckInTime";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CheckInTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.CheckInTime.HeaderText = "Thời gian";
            this.CheckInTime.MinimumWidth = 6;
            this.CheckInTime.Name = "CheckInTime";
            // 
            // gui
            // 
            this.gui.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gui.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gui.Location = new System.Drawing.Point(217, 417);
            this.gui.Name = "gui";
            this.gui.Size = new System.Drawing.Size(372, 68);
            this.gui.TabIndex = 3;
            this.gui.Text = "Gửi";
            this.gui.UseVisualStyleBackColor = true;
            this.gui.Click += new System.EventHandler(this.gui_Click);
            // 
            // chamcong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 497);
            this.Controls.Add(this.gui);
            this.Controls.Add(this.dgDanhSach);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "chamcong";
            this.Text = "Chấm công";
            this.Load += new System.EventHandler(this.chamcong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgDanhSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gui;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox donvi;
        private System.Windows.Forms.CheckBox tatca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayCham;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayCham;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cham;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckInTime;
    }
}