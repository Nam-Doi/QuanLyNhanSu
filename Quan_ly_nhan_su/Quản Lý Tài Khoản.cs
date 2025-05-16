using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class frmquanly : Form
    {
        string macu;//Lưu mã tài khoản hiện tại
        bool ktthem;// kiểm tra thêm
        DataGridViewCellMouseEventArgs vt;//Lưu vị trí ô được chọn
        string f0 = "taikhoan", f1 = "TenDN", f2 = "MatKhau";
        public frmquanly()
        {
            InitializeComponent();
        }
        private void frmquanly_Load(object sender, EventArgs e)
        {
            laynguon();
            khoamo(true);
        }
        //Lấy nguồn từ SQL
        private void laynguon()
        {
            string sql= @"Select tk.TenDN,tk.MatKhau,nv.maNV,nv.tenNV,cv.tenCV
                From taikhoan tk
                inner JOIN nhanVien nv ON tk.id = nv.id
                left JOIN chucvu cv ON nv.maCV = cv.maCV ";
            if (Public.maCV != "CQ")
            {
                if (Public.maCV == "QL")
                {
                    sql += @"where nv.maCN = '" + Public.maCN + "'";
                }else
                {
                    sql += @"where nv.maCN = '" + Public.maCN + "'and tk.id = '"+Public.idnv+"'";
                }
            }
            else
            {
            }
            Public.LayNguonDataGridView(dgdanhsach,sql);
        }
        public void khoamo(bool b)
        {
            dgdanhsach.Enabled = b;
            txtmanv.ReadOnly = !b; txttendangnhap.Enabled = !b;txtmk.Enabled = !b;
            cmdsua.Enabled = b; cmdthoat.Enabled = b;
            cmdghi.Enabled = !b; cmdkhong.Enabled = !b;
        }
        public void xoatrang()
        {
            txtmanv.Text = ""; txttendangnhap.Text = ""; txtmk.Text = "";
            cbotennv.Text = ""; cbocv.Text = "";
        }
        //thưc hiện lệnh sửa tài khoản
        private void cmdsua_Click(object sender, EventArgs e)
        {
            if (txttendangnhap.Text == "") return;
            ktthem = false;
            macu = txttendangnhap.Text;
            khoamo(false);
        }
        //Hiện dữ liệu từ SQL vào bảng DataGridView
        private void dgdanhsach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgdanhsach.RowCount <= 0) return;
            if (e == null) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgdanhsach.Rows[e.RowIndex];
                txttendangnhap.Text = row.Cells[0].Value.ToString();
                txtmk.Text = row.Cells[1].Value.ToString();
                txtmanv.Text = row.Cells[2].Value. ToString();
                cbotennv.Text = row.Cells[3].Value.ToString();   
                cbocv.Text = row.Cells[4].Value.ToString();
            }
        }
        // Thực thi xóa ghi để cập nhật
        private void cmdghi_Click(object sender, EventArgs e)
        {
            //Cảnh báo khi để trống tài khoản
            if (txttendangnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttendangnhap.Focus();
                return;
            }
            //cảnh báo khi để trống mật khẩu
            if (txtmk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmk.Focus();
                return;
            }
            // Kiểm tra trùng mã 
            if (!ktthem && Public.ktTrungMa(f1, f0, ktthem, txttendangnhap.Text, macu))
            { 
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttendangnhap.Focus();
                return;
             }
            if ((MessageBox.Show("Bạn có muốn cập nhật tài khoản không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Public.sql = "UPDATE " + f0 + " SET " + f1 + " = @TenDN, " + f2 + " = @MatKhau WHERE " + f1 + " = @OldTenDN";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@TenDN", txttendangnhap.Text),
                new SqlParameter("@MatKhau", txtmk.Text),
                new SqlParameter("@OldTenDN", macu)
                };
                if (Public.ThucHienSQL(Public.sql,parameters) == true)
                {
                    MessageBox.Show("Bạn cập nhật tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmquanly_Load(sender,e);
                    try
                    {
                        dgdanhsach_CellMouseClick(sender, vt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " +ex.Message.ToString());
                    }
                }
            }
        }

        private void xemmk_CheckedChanged(object sender, EventArgs e)
        {
            if (xemmk.Checked == true) txtmk.PasswordChar = '\0';
            else txtmk.PasswordChar = '*';
        }

        //Thực hiện xóa phần đang ghi
        private void cmdkhong_Click(object sender, EventArgs e)
        {
            try
            {
                xoatrang();
                khoamo(true);
                dgdanhsach_CellMouseClick(sender, vt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString());
            }
        }
        //thực hiện thoát chương trình về giao diện
        private void cmdthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất chương trình không?", "Thông Báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
