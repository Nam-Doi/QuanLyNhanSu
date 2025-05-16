using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_ly_nhan_su
{
    public partial class xetDuyet : Form
    {
        private tuyenDung formtd;
        public xetDuyet(tuyenDung td)
        {
            InitializeComponent();
            this.formtd = td;
        }
        bool close = true, pict = false, pict1 = false, checks = false, checks1 = false, checkcc = false, checke = false;
        double n = 0;
        string b, c, gt;
        private void themNV_Load(object sender, EventArgs e)
        {
            var cv = new SqlDataAdapter(@"select tenCV,maCV from chucVu where maCV != 'CQ'",Public.conn);
            var table = new DataTable();
            cv.Fill(table);
            CV.DisplayMember = "tenCV";
            CV.ValueMember = "maCV";
            CV.DataSource = table;
            hoTen.Text = "";
            sdt.Text = "";
            sdt1.Text = "";
            email.Text = "";
            que.Text = "";
            cccd.Text = "";
            pict = false;
            loi.Text = "";
            nam.Checked = true;
            ngaysinh.Value = DateTime.Now.Date;
            hoTen.Focus();
            close = false;
        }

        private void themNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close == true)
            {
                if (MessageBox.Show("Nếu thoát khỏi đây mọi hành động sẽ không được lưu lại", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Biểu thức chính quy để kiểm tra định dạng email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
         private void check(object sender, EventArgs e)
         {
            if (hoTen.Text == "" || sdt.Text == "" || sdt1.Text == "" || email.Text == "" || cccd.Text == "" || pict == false||que.Text=="")
            {
                loi.Text = "Không được bỏ trống ";
                if (hoTen.Text == "")
                {
                    loi.Text += "Họ tên";
                    hoTen.BackColor = Color.Red;
                    hoTen.Focus();
                }
                if (sdt.Text == "")
                {
                    if (hoTen.Text == "") loi.Text += ", ";
                    loi.Text += "Số điện thoại (nhân viên)";
                    sdt.BackColor = Color.Red;
                    if(hoTen.Text != "")sdt.Focus();
                    checks = false;
                }
                if (sdt1.Text == "")
                {
                    if (sdt.Text == "") loi.Text += ", ";
                    loi.Text += "Số điện thoại (người thân cận)";
                    sdt1.BackColor = Color.Red;
                    if (hoTen.Text != ""&&sdt.Text != "") sdt1.Focus();
                    checks1 = false;
                }
                if (email.Text == "")
                {
                    if (sdt1.Text == "") loi.Text += ", ";
                    loi.Text += "Email";
                    email.BackColor = Color.Red;
                    if(hoTen.Text!=""&&sdt.Text!=""&&sdt1.Text!="") email.Focus();
                    checke = false;
                }
                if(que.Text == "")
                {
                    if(email.Text == "") loi.Text += ", ";
                    loi.Text += "Quê quán";
                    que.BackColor = Color.Red;
                    if(hoTen.Text != "" && sdt.Text != "" && sdt1.Text != "" && email.Text != ""&&CV.Text!="") que.Focus();   
                }
                if (cccd.Text == "")
                {
                    if (que.Text == "") loi.Text += ", ";
                    loi.Text += "Số CCCD";
                    cccd.BackColor = Color.Red;
                    if (hoTen.Text != "" && sdt.Text != "" && sdt1.Text != ""&&email.Text!=""&&que.Text!=""&&CV.Text!="") cccd.Focus();
                    checkcc = false;
                }
                if (pict == false)
                {
                    if (cccd.Text == "") loi.Text += ", ";
                    loi.Text += " Ảnh chân dung";
                }
                loi.Text += "!";
            }
            else
            {
                if (checks == false || checks1 == false || checke == false||checkcc == false||pict1 == false)
                {
                    loi.Text = "Bạn nhập sai hoặc đã tồn tại ";
                    if(checks == false)
                    {
                        loi.Text += "Số điện thoại (nhân viên)";
                        sdt.BackColor = Color.Red;
                        sdt.Focus();
                    }
                    if (checks1 == false)
                    {
                        if (checks == false) loi.Text += ", ";
                        loi.Text += "Số điện thoại (người thân cận)";
                        sdt1.BackColor = Color.Red;
                        if(checks == true) sdt1.Focus();
                    }
                    if (checke == false)
                    {
                        if (checks1 == false||checks == false) loi.Text+= ", ";  
                        loi.Text += "Email";
                        email.BackColor = Color.Red;
                        if(checks == true && checks1 == true) email.Focus();
                    }
                    if (checkcc == false)
                    {
                        if (checke == false|| checks1 == false || checks == false) loi.Text += ", ";
                        loi.Text += "Số CCCD";
                        cccd.BackColor = Color.Red;
                        if (checks == true && checks1 == true && checke == true) cccd.Focus();
                    }
                    if (pict1 == false)
                    {
                        if (checkcc == false|| checke == false || checks1 == false || checks == false) loi.Text += ", ";
                        loi.Text += "Ảnh chân dung";
                    }
                }
                else
                {
                    loi.Text = "";
                    if (MessageBox.Show("Xác nhận thông tin trên là đúng?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (nam.Checked == true) gt = "Nam";
                        else if (nu.Checked == true) gt = "Nữ";
                        try
                        {
                            string id;
                            do
                            {
                                Random r = new Random();
                                id = r.Next(1, 9999).ToString();
                                while (id.Length < 4) id = "0" + id;
                            } while (kiemtra("id","nhanVien",id)|| kiemtra("id", "tuyenDung", id));
                            File.Copy(b, c);
                            Public.conn.Open();
                            var cmd = new SqlCommand(@"insert into tuyenDung(maNV,tenNV,sdt,sdt1,ngaysinh,gioitinh,email,maCV,que,cccd,url,id,nguoiTuyen,maCN) 
                            values (@maNV,@tenNV,@sdt,@sdt1,@ngaysinh,@gioitinh,@email,@maCV,@que,@cccd,@url,@id,@nguoiTuyen,@maCN)", Public.conn);
                            cmd.Parameters.AddWithValue("@tenNV", hoTen.Text.Trim());
                            cmd.Parameters.AddWithValue("@sdt", sdt.Text.Trim());
                            cmd.Parameters.AddWithValue("@sdt1", sdt1.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                            cmd.Parameters.AddWithValue("@maCV", CV.SelectedValue.ToString().Trim());
                            cmd.Parameters.AddWithValue("@que", que.Text.Trim());
                            cmd.Parameters.AddWithValue("@cccd", cccd.Text);
                            cmd.Parameters.AddWithValue("@maNV", CV.SelectedValue.ToString().Trim()+id.ToString().Trim());
                            cmd.Parameters.AddWithValue("@url", c.Trim());
                            cmd.Parameters.AddWithValue("@gioitinh", gt.Trim());
                            cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh.Value);
                            cmd.Parameters.AddWithValue("@nguoiTuyen", Public.cv);
                            cmd.Parameters.AddWithValue("@maCN", Public.maCN);
                            cmd.Parameters.AddWithValue("@id", id.ToString().Trim());
                            cmd.ExecuteNonQuery();
                            Public.conn.Close();
                            MessageBox.Show("Đã gửi yêu cầu thành công ","Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            themNV_Load(sender, e);
                            anh.Image = new Bitmap(Application.StartupPath.ToString() + @"\picture\default\01.png");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm nhân viên không thành công hãy thử lại lỗi: "+ex.Message,"Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void bttThem_Click(object sender, EventArgs e)
        {
            check(sender, e);
            formtd.LoadTD();
        }
        private bool kiemtra(string cot,string bang,string dk)
        {
            int c;
            Public.conn.Open();
            var cmd = new SqlCommand($"select count([{cot}]) from [{bang}] where [{cot}] = @dk", Public.conn);
            cmd.Parameters.AddWithValue("@dk", dk);
            c = (int)cmd.ExecuteScalar();
            Public.conn.Close();
            return c > 0;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(pic.FileName) == ".png" || Path.GetExtension(pic.FileName) == ".jpg")
                {
                    anh.Image = new Bitmap(pic.FileName);
                    string a = Application.StartupPath + @"\picture\";
                    b = pic.FileName;
                    c = a + Path.GetFileName(b);
                    pict = true;
                    close = true;
                    try
                    {
                        if (kiemtra("url", "nhanVien", c.ToString().Trim())|| kiemtra("url", "tuyenDung", c.ToString().Trim())) pict1 = false;
                        else pict1 = true;
                    }       
                    catch
                    {
                        pict1 = false;
                    }
                }
                else
                {
                    MessageBox.Show("File ảnh không hợp lệ","Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pict = false;
                    pict1 = false;
                }
            }
        }
        private void hoTen_TextChanged(object sender, EventArgs e)
        {
            hoTen.BackColor = Color.White;
            close = true;
            hoTen.Focus();
        }

        private void hoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                e.SuppressKeyPress = true;
                sdt.Focus();
            }
        }

        private void sdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {    
                e.SuppressKeyPress = true;
                sdt1.Focus();
            }
        }

        private void sdt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                e.SuppressKeyPress = true;
                email.Focus();
            }
        }

        private void ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            close = true;
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                que.Focus();
            }
        }

        private void que_TextChanged(object sender, EventArgs e)
        {
            que.BackColor = Color.White;
            close = true;
            que.Focus();
        }

        private void que_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cccd.Focus();
            }
        }

        private void cccd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                check(sender, e);
                formtd.LoadTD();
            }
        }
        private void sdt_TextChanged(object sender, EventArgs e)
        {
            sdt.BackColor = Color.White;
            close = true;
            sdt.Focus();
            if (double.TryParse(this.sdt.Text, out n))
                if (n > 0)
                    if (n.ToString().Length < 10 || n.ToString().Length > 10) checks = false;
                    else 
                    {
                        try
                        {
                            if (kiemtra("sdt","nhanVien",sdt.Text) || kiemtra("sdt", "tuyenDung", sdt.Text)) checks = false;
                            else checks = true;
                        }
                        catch
                        {
                            checks = false;
                        }
                    }
                else checks = false;
            else checks = false;
        }
        private void sdt1_TextChanged(object sender, EventArgs e)
        {
            sdt1.BackColor = Color.White;
            close = true;
            sdt1.Focus();
            if (double.TryParse(this.sdt1.Text, out n))
                if (n > 0)
                    if (n.ToString().Length < 10 || n.ToString().Length > 10) checks1 = false;
                    else 
                    { 
                        checks1 = true; 
                    }
                else checks1 = false;
            else checks1 = false;
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            email.BackColor = Color.White;
            close = true;
            email.Focus();
            if (!IsValidEmail(email.Text)) checke = false;
            else 
            {
                try
                {
                    if (kiemtra("email", "nhanVien", email.Text) || kiemtra("email", "tuyenDung", email.Text)) checke = false;
                    else checke = true;
                }
                catch
                {
                    checke = false;
                }
            }
        }


        private void cccd_TextChanged(object sender, EventArgs e)
        {
            cccd.BackColor = Color.White;
            close = true;
            cccd.Focus();
            if (double.TryParse(this.cccd.Text, out n))
                if (n > 0)
                    if (n.ToString().Length < 12 || n.ToString().Length > 12) checkcc = false;
                    else 
                    {
                        try
                        {
                            if (kiemtra("cccd", "nhanVien", cccd.Text) || kiemtra("cccd", "tuyenDung", cccd.Text)) checkcc = false;
                            else checkcc = true;
                        }
                        catch
                        {
                            checkcc = false;
                        }
                    }
                else checkcc = false;
            else checkcc = false;
        }
    }
}
