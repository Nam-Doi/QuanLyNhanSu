using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Quan_ly_nhan_su
{
    public partial class frmdangnhap : Form
    {
        string sql;bool dangnhap = false;
        public frmdangnhap()
        {
            InitializeComponent();
        }
        //Dùng để lưu tài khoản mật khẩu
        private void frmdangnhap_Load(object sender, EventArgs e)
        {
            txttendn.Text = Properties.Settings.Default.manv;
            txtmatkhau.Text = Properties.Settings.Default.matkhau;
            chkluu.Checked = Properties.Settings.Default.saveus;
        }
        private void cmdket_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Dùng để hiện hoặc ẩn mật khẩu
        private void chkhien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhien.Checked == false)
            {
                txtmatkhau.PasswordChar = '*';
            }
            else txtmatkhau.PasswordChar = '\0';
        }
        //khi nhấn enter sẽ kích hoạt chỉ thị
        private void txttendn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím nhấn là Enter
            {
                e.SuppressKeyPress = true; // Ngăn tiếng beep
                txtmatkhau.Focus();
            }
        }
        //khi nhấn enter sẽ chưc hoạt chỉ thị
        private void txtmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím nhấn là Enter
            {
                cmddang.PerformClick(); // Kích hoạt Button
                e.Handled = true; // Ngăn hành động mặc định (nếu cần)
                e.SuppressKeyPress = true; // Ngăn tiếng beep
            }
        }
        private void cmddang_Click(object sender, EventArgs e)
        {
            string tendangnhap = txttendn.Text.Trim();// Trim: dùng để xóa khoản trống
            string matkhau = txtmatkhau.Text.Trim(); 
            //Lấy dữ liệu trong bảng SQL sever
            sql = @"Select tk.id,tk.maCV,TenDN,MatKhau,nv.maCN,tenCN from taikhoan tk right join nhanVien nv on tk.id = nv.id left join chiNhanh cn on nv.maCN = cn.maCN WHERE TenDN= '" + tendangnhap + "' and MatKhau = '" + matkhau + "'";
            DataTable daTaiKhoan = Public.LayNguon(sql);
            //Bắt đâu kiểm tra đăng nhập
            if (daTaiKhoan.Rows.Count > 0)
            {
                Public.idnv = daTaiKhoan.Rows[0]["id"].ToString().Trim();
                Public.maCV= daTaiKhoan.Rows[0]["maCV"].ToString().Trim();
                Public.maCN = daTaiKhoan.Rows[0]["maCN"].ToString().Trim();
                Public.tenCN = daTaiKhoan.Rows[0]["tenCN"].ToString().Trim();
                Public.TenDangNhap = daTaiKhoan.Rows[0]["TenDN"].ToString().Trim();
                Public.MatKhau = daTaiKhoan.Rows[0]["MatKhau"].ToString().Trim();
                if (chkluu.Checked == true)
                {
                    Properties.Settings.Default.manv = Public.TenDangNhap;
                    Properties.Settings.Default.matkhau = Public.MatKhau;
                    Properties.Settings.Default.saveus = true;
                }
                else
                {
                    Properties.Settings.Default.manv = "";
                    Properties.Settings.Default.matkhau = "";
                    Properties.Settings.Default.saveus = false;
                }
                Properties.Settings.Default.Save();
                trangChu giaodien = new trangChu();
                this.Hide();
                dangnhap = true;
                giaodien.Show();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai tên đăng nhập hoặc mật khẩu.", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttendn.Focus();
            } 
                
        }
        //Dùng để tắt chương trình
        private void frmdangnhap_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (dangnhap == false)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    dangnhap = false;
                    e.Cancel = true;
                }
            }
        }
    }
}
