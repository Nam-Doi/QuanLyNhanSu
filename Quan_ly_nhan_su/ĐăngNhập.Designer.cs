namespace Quan_ly_nhan_su
{
    partial class frmdangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdangnhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttendn = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.chkhien = new System.Windows.Forms.CheckBox();
            this.chkluu = new System.Windows.Forms.CheckBox();
            this.cmddang = new System.Windows.Forms.Button();
            this.cmdket = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txttendn
            // 
            resources.ApplyResources(this.txttendn, "txttendn");
            this.txttendn.Name = "txttendn";
            this.txttendn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttendn_KeyDown);
            // 
            // txtmatkhau
            // 
            resources.ApplyResources(this.txtmatkhau, "txtmatkhau");
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmatkhau_KeyDown);
            // 
            // chkhien
            // 
            resources.ApplyResources(this.chkhien, "chkhien");
            this.chkhien.Name = "chkhien";
            this.chkhien.UseVisualStyleBackColor = true;
            this.chkhien.CheckedChanged += new System.EventHandler(this.chkhien_CheckedChanged);
            // 
            // chkluu
            // 
            resources.ApplyResources(this.chkluu, "chkluu");
            this.chkluu.Name = "chkluu";
            this.chkluu.UseVisualStyleBackColor = true;
            // 
            // cmddang
            // 
            resources.ApplyResources(this.cmddang, "cmddang");
            this.cmddang.Name = "cmddang";
            this.cmddang.UseVisualStyleBackColor = true;
            this.cmddang.Click += new System.EventHandler(this.cmddang_Click);
            // 
            // cmdket
            // 
            resources.ApplyResources(this.cmdket, "cmdket");
            this.cmdket.Name = "cmdket";
            this.cmdket.UseVisualStyleBackColor = true;
            this.cmdket.Click += new System.EventHandler(this.cmdket_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdket);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmddang);
            this.panel1.Controls.Add(this.txttendn);
            this.panel1.Controls.Add(this.chkluu);
            this.panel1.Controls.Add(this.txtmatkhau);
            this.panel1.Controls.Add(this.chkhien);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // frmdangnhap
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmdangnhap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmdangnhap_FormClosing_1);
            this.Load += new System.EventHandler(this.frmdangnhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttendn;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.CheckBox chkhien;
        private System.Windows.Forms.CheckBox chkluu;
        private System.Windows.Forms.Button cmddang;
        private System.Windows.Forms.Button cmdket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

