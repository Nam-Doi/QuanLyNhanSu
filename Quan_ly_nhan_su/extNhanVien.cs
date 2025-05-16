using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class extNhanVien : Form
    {
        private nhanVien formnv;
        public extNhanVien(nhanVien nv)
        {
            InitializeComponent();
            this.formnv = nv;
        }
        
        bool bttsua = false, close = false,pict = true, pict1 = true, checks = true, checks1 = true, checkcc = true, checke = true;
        string macv,id,tencv,tennv;
        private void extNhanVien_Load(object sender, EventArgs e)
        {
            id = Public.id;
            if (Public.maCV != "CQ")
            {
                if(Public.maCV !="QL")
                {
                    xoa.Enabled = false;
                }
            }
            close = false;
            try
            {
                loi.Text = "";
                Public.conn.Open();
                var cmd = new SqlCommand(@"select maNV,tenNV,sdt,sdt1,ngaysinh,gioitinh,email,tenCN,que,cccd,url,ngayVaoLam,tenCV from nhanVien nv left join chiNhanh cn on nv.maCN = cn.maCN left join chucVu cv on cv.maCV = nv.maCV where id = @id", Public.conn);
                cmd.Parameters.AddWithValue("@id", id);
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    maNV.Text = r["maNV"].ToString();
                    hoTen.Text = r["tenNV"].ToString();
                    tennv = r["tenNV"].ToString();
                    this.Text = r["tenNV"].ToString();
                    ngaysinh.Value = r.GetDateTime(r.GetOrdinal("ngaysinh"));
                    sdt.Text = r["sdt"].ToString();
                    sdt1.Text = r["sdt1"].ToString();
                    if (r["gioitinh"].ToString().Trim() == "Nam") nam.Checked = true;
                    else nu.Checked = true;
                    email.Text = r["email"].ToString();
                    cccd.Text = r["cccd"].ToString();
                    que.Text = r["que"].ToString();
                    chiNhanh.Text = r["tenCN"].ToString();
                    tencv = r["tenCV"].ToString().Trim();
                    anh.Image = new Bitmap(r["url"].ToString());
                    ngayvaolam.Value = r.GetDateTime(r.GetOrdinal("ngayVaoLam"));
                }
                r.Close();
                var cmd1 = new SqlCommand(@"SELECT tenCV,nv.maCV FROM chucVu cv inner join nhanVien nv on cv.maCV = nv.maCV where id = @id", Public.conn);
                cmd1.Parameters.AddWithValue("@id", id);
                var cn = new SqlDataAdapter(cmd1);
                var table = new DataTable();
                cn.Fill(table);
                CV.DisplayMember = "tenCV";
                CV.ValueMember = "maCV";
                CV.DataSource = table;
                macv = (string)CV.SelectedValue;
                Public.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công "+ex.Message,"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            bttsua = false;
            khoa(false);
        }

        double n = 0;
        string gt;
        private void extNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
            if (hoTen.Text == "" || sdt.Text == "" || sdt1.Text == "" || email.Text == "" || cccd.Text == "" || pict == false || que.Text == "")
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
                    if (hoTen.Text != "") sdt.Focus();
                    checks = false;
                }
                if (sdt1.Text == "")
                {
                    if (sdt.Text == "") loi.Text += ", ";
                    loi.Text += "Số điện thoại (người thân cận)";
                    sdt1.BackColor = Color.Red;
                    if (hoTen.Text != "" && sdt.Text != "") sdt1.Focus();
                    checks1 = false;
                }
                if (email.Text == "")
                {
                    if (sdt1.Text == "") loi.Text += ", ";
                    loi.Text += "Email";
                    email.BackColor = Color.Red;
                    if (hoTen.Text != "" && sdt.Text != "" && sdt1.Text != "") email.Focus();
                    checke = false;
                }
                if (que.Text == "")
                {
                    if (email.Text == "") loi.Text += ", ";
                    loi.Text += "Quê quán";
                    que.BackColor = Color.Red;
                    if (hoTen.Text != "" && sdt.Text != "" && sdt1.Text != "" && email.Text != "" && CV.Text != "") que.Focus();
                }
                if (cccd.Text == "")
                {
                    if (que.Text == "") loi.Text += ", ";
                    loi.Text += "Số CCCD";
                    cccd.BackColor = Color.Red;
                    if (hoTen.Text != "" && sdt.Text != "" && sdt1.Text != "" && email.Text != "" && que.Text != "" && CV.Text != "") cccd.Focus();
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
                if (checks == false || checks1 == false || checke == false || checkcc == false || pict1 == false)
                {
                    loi.Text = "Bạn nhập sai hoặc đã tồn tại ";
                    if (checks == false)
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
                        if (checks == true) sdt1.Focus();
                    }
                    if (checke == false)
                    {
                        if (checks1 == false || checks == false) loi.Text += ", ";
                        loi.Text += "Email";
                        email.BackColor = Color.Red;
                        if (checks == true && checks1 == true) email.Focus();
                    }
                    if (checkcc == false)
                    {
                        if (checke == false || checks1 == false || checks == false) loi.Text += ", ";
                        loi.Text += "Số CCCD";
                        cccd.BackColor = Color.Red;
                        if (checks == true && checks1 == true && checke == true) cccd.Focus();
                    }
                    if (pict1 == false)
                    {
                        if (checkcc == false || checke == false || checks1 == false || checks == false) loi.Text += ", ";
                        loi.Text += "Ảnh chân dung";
                    }
                }
                else
                {
                    loi.Text = "";
                    if (Public.maCV != "CQ")
                    {
                        if (CV.SelectedValue.ToString().Trim() == "QL" && Public.idnv!=id) MessageBox.Show("Bạn không đủ đặc quyền để đổi chức vụ quản lý!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            cnhat(sender,e);
                        }
                    }
                    else
                    {
                        cnhat(sender,e);
                    }
                    
                }
            }
        }
        private void cnhat(object sender,EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thông tin trên là đúng?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nam.Checked == true) gt = "Nam";
                else if (nu.Checked == true) gt = "Nữ";
                try
                {
                    Public.conn.Open();
                    var cmd = new SqlCommand(@"update nhanVien set 
                            maNV = @maNV, tenNV = @tenNV, sdt = @sdt, sdt1 = @sdt1, email = @email, maCV = @maCV , que = @que, cccd = @cccd, gioitinh = @gioitinh, ngaysinh = @ngaysinh where id = @id", Public.conn);
                    cmd.Parameters.AddWithValue("@tenNV", hoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdt", sdt.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdt1", sdt1.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@maCV", CV.SelectedValue.ToString().Trim());
                    cmd.Parameters.AddWithValue("@que", que.Text.Trim());
                    cmd.Parameters.AddWithValue("@cccd", cccd.Text.Trim());
                    cmd.Parameters.AddWithValue("@gioitinh", gt.Trim());
                    cmd.Parameters.AddWithValue("@maNV", CV.SelectedValue.ToString().Trim() + id);
                    cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh.Value);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    var cmd1 = new SqlCommand(@"update taikhoan set maCV = @maCV where id = @id", Public.conn);
                    cmd1.Parameters.AddWithValue("@maCV", CV.SelectedValue.ToString().Trim());
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();
                    Public.conn.Close();
                    MessageBox.Show("Đã cập nhật thông tin nhân viên thành công", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Public.id = id;
                    extNhanVien_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên không thành công lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void hoTen_TextChanged(object sender, EventArgs e)
        {
            hoTen.BackColor = Color.White;
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

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                que.Focus();
            }
        }
        private void khoa(bool a)
        {
            CV.Enabled = a;
            hoTen.Enabled = a;
            ngaysinh.Enabled = a;
            nam.Enabled = a;
            nu.Enabled = a;
            sdt.Enabled = a;
            sdt1.Enabled = a;
            email.Enabled = a;
            que.Enabled = a;
            cccd.Enabled = a;
            capnhat.Enabled = a;
        }
        private void sua_Click(object sender, EventArgs e)
        {
            if(Public.maCV == "CQ")
            {
                khoa(true);

            }
            else if (Public.maCV == "QL")
            {
                if(CV.SelectedValue.ToString().Trim() != "QL"||Public.idnv == id)
                {
                    khoa(true);
                }
                else MessageBox.Show("Bạn không thể sửa thông tin của quản lý khác!","Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sdt.Enabled = true;
                sdt1.Enabled = true;
                email.Enabled = true;
                cccd.Enabled = true;
                capnhat.Enabled = true;
            }
            bttsua= true;
            close = true;
            try
            {
                var cn = new SqlDataAdapter(@"SELECT tenCV,maCV FROM chucVu where maCV != 'CQ'", Public.conn);
                var table = new DataTable();
                cn.Fill(table);
                CV.DisplayMember = "tenCV";
                CV.ValueMember = "maCV";
                CV.DataSource = table;
                CV.SelectedValue = macv;
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Tải dữ liệu không thành công "+ex.Message,"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if(Public.maCV == "CQ")
            {
                xoanv(sender,e);
            } 
            else if(Public.maCV == "QL")
            {
                if(CV.SelectedValue.ToString().Trim() != "QL"||Public.idnv==id)
                {
                    xoanv(sender, e);
                }
                else
                {
                    MessageBox.Show("Bạn không thể xoá một người quản lý khác!","Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void xoanv(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá nhân viên này", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Public.conn.Open();
                    var url = new SqlCommand(@"select url from nhanVien where id = '" + id + "'", Public.conn);
                    var u = url.ExecuteReader();
                    if (u.Read())
                    {
                        close = false;
                        anh.Image.Dispose();
                        this.Close();
                        File.Delete(u["url"].ToString());
                    }
                    u.Close();
                    var cmd = new SqlCommand(@"delete from nhanVien where id = @id", Public.conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    var cmd1 = new SqlCommand(@"delete from taikhoan where id = @id", Public.conn);
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();
                    var cmd2 = new SqlCommand("insert into lsNhanVien(nbxt,nxt,ngay,maCN,trangthai) values (@nbxt,@nxt,@ngay,@maCN,'0')",Public.conn);
                    cmd2.Parameters.AddWithValue("@nbxt",tencv+" "+tennv);
                    cmd2.Parameters.AddWithValue("@nxt",Public.cv);
                    cmd2.Parameters.AddWithValue("@ngay",DateTime.Today);
                    cmd2.Parameters.AddWithValue("@maCN",Public.maCN);
                    cmd2.ExecuteNonQuery();
                    Public.conn.Close();
                    MessageBox.Show("Đã xoá nhân viên thành công", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá nhân viên không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            formnv.LoadNV();
        }
        private void capnhat_Click(object sender, EventArgs e)
        {
            if(bttsua == true) check(sender, e);
            formnv.LoadNV();
        }

        private void que_TextChanged(object sender, EventArgs e)
        {
            que.BackColor = Color.White;
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
            }
        }
        private bool kiemtra(string cot, string bang, string dk)
        {
            int c;
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand($"select count([{cot}]) from [{bang}] where [{cot}] = @dk and id != @id", Public.conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@dk", dk);
                c = (int)cmd.ExecuteScalar();
                Public.conn.Close();
            }
            catch
            {
                c = 0;
            }
            return c > 0;
        }
        private void sdt_TextChanged(object sender, EventArgs e)
        {
            sdt.BackColor = Color.White;
            sdt.Focus();
            if (double.TryParse(this.sdt.Text, out n))
                if (n > 0)
                    if (n.ToString().Length < 10 || n.ToString().Length > 10) checks = false;
                    else
                    {
                        if (kiemtra("sdt", "nhanVien", sdt.Text) || kiemtra("sdt", "tuyenDung", sdt.Text)) checks = false;
                        else checks = true;
                    }
                else checks = false;
            else checks = false;
        }
        private void sdt1_TextChanged(object sender, EventArgs e)
        {
            sdt1.BackColor = Color.White;
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
            email.Focus();
            if (!IsValidEmail(email.Text)) checke = false;
            else
            {
                if (kiemtra("email", "nhanVien", email.Text) || kiemtra("email", "tuyenDung", email.Text)) checke = false;
                else checke = true;
            }
        }

        private void cccd_TextChanged(object sender, EventArgs e)
        {
            cccd.BackColor = Color.White;
            cccd.Focus();
            if (double.TryParse(this.cccd.Text, out n))
                if (n > 0)
                    if (n.ToString().Length < 12 || n.ToString().Length > 12) checkcc = false;
                    else
                    {
                        if (kiemtra("cccd", "nhanVien", cccd.Text) || kiemtra("cccd", "tuyenDung", cccd.Text)) checkcc = false;
                        else checkcc = true;
                    }
                else checkcc = false;
            else checkcc = false;
        }
    }
}
