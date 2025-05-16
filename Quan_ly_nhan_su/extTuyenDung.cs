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
    public partial class extTuyenDung : Form
    {
        private tuyenDung formtd;
        public extTuyenDung(tuyenDung td)
        {
            InitializeComponent();
            this.formtd = td;
        }

        bool close = false;
        string idc,macn;

        private void them_Click(object sender, EventArgs e)
        {
            if (Public.maCV != "CQ")
            {
                if (macv == "QL") MessageBox.Show("Bạn không đủ quyền hạn để phê duyệt quản lý!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    themtd(sender, e);
                }
            }
            else
            {
                themtd(sender, e);
            }
        }
       private void themtd(object sender, EventArgs e)
        {
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand(
                    @"insert into nhanVien(maNV,tenNV,sdt,sdt1,ngaysinh,gioitinh,email,que,cccd,url,id,maCV,ngayVaoLam,maCN) 
                    select maNV,tenNV,sdt,sdt1,ngaysinh,gioitinh,email,que,cccd,url,id,maCV,@ngayVaoLam,@maCN from tuyenDung where id = @id"
                    , Public.conn);
                cmd.Parameters.AddWithValue("@ngayVaoLam", DateTime.Today);
                cmd.Parameters.AddWithValue("@id",idc);
                cmd.Parameters.AddWithValue("@maCN", Public.maCN);
                cmd.ExecuteNonQuery();
                var dele = new SqlCommand(@"delete from tuyenDung where id = @id", Public.conn);
                dele.Parameters.AddWithValue("@id", idc);
                dele.ExecuteNonQuery();
                var cmd1 = new SqlCommand(@"insert into taikhoan(tenDN,MatKhau,id,maCV)
                                            select ltrim(rtrim(maNV)),ltrim(rtrim(maNV)),id,maCV from nhanVien where id = @id", Public.conn);
                cmd1.Parameters.AddWithValue("@id",idc);
                cmd1.ExecuteNonQuery();
                var cmd2 = new SqlCommand(@"insert into lsNhanVien(nbxt,nxt,ngay,maCN,trangthai)
                                            values(@nbxt,@nxt,@ngay,@maCN,'1')", Public.conn);
                cmd2.Parameters.AddWithValue("@nbxt", CV.Text.ToString().Trim()+" "+hoTen.Text.ToString().Trim() );
                cmd2.Parameters.AddWithValue("@nxt", Public.cv);
                cmd2.Parameters.AddWithValue("@ngay", DateTime.Today);
                cmd2.Parameters.AddWithValue("@maCN", macn);
                cmd2.ExecuteNonQuery();
                Public.conn.Close();
                this.Close();
                MessageBox.Show("Đã thêm nhân viên thành công mã nhân viên của bạn là " + macv + idc, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            formtd.LoadTD();
        }
        private void xoa_Click(object sender, EventArgs e)
        {
            if (Public.maCV != "CQ")
            {
                if (macv == "QL") MessageBox.Show("Bạn không đủ quyền hạn để phê duyệt quản lý!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    xoanv(sender, e);
                }
            }
            else
            {
                xoanv(sender,e);
            }
        }
        private void xoanv(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá nhân viên này?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Public.conn.Open();
                    var url = new SqlCommand(@"select url from tuyenDung where id = @id", Public.conn);
                    url.Parameters.AddWithValue("@id", idc);
                    var u = url.ExecuteReader();
                    if (u.Read())
                    {
                        close = false;
                        anh.Image.Dispose();
                        this.Close();
                        File.Delete(u["url"].ToString());
                    }
                    u.Close();
                    var cmd = new SqlCommand("delete from tuyenDung " +
                        "where id = '" + idc + "'", Public.conn);
                    cmd.ExecuteNonQuery();
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
            formtd.LoadTD();
        }
        string macv;
        private void extTuyenDung_Load(object sender, EventArgs e)
        {
            idc = Public.id;
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand("select nguoiTuyen,tenNV,sdt,sdt1,ngaysinh,gioitinh,email,que,cccd,url,tenCV,td.maCV,maCN from tuyenDung td inner join chucVu cv on td.maCV = cv.maCV where id = @id", Public.conn);
                cmd.Parameters.AddWithValue("@id", idc);
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    ngTuyen.Text = r["nguoiTuyen"].ToString();
                    hoTen.Text = r["tenNV"].ToString();
                    this.Text = r["tenNV"].ToString();
                    ngaysinh.Value = r.GetDateTime(r.GetOrdinal("ngaysinh"));
                    sdt.Text = r["sdt"].ToString();
                    sdt1.Text = r["sdt1"].ToString();
                    if (r["gioitinh"].ToString().Trim() == "Nam") nam.Checked = true;
                    else nu.Checked = true;
                    email.Text = r["email"].ToString();
                    cccd.Text = r["cccd"].ToString();
                    que.Text = r["que"].ToString();
                    CV.Text = r["tenCV"].ToString();
                    macv = r["maCV"].ToString().Trim();
                    macn = r["maCN"].ToString().Trim();
                    anh.Image = new Bitmap(r["url"].ToString());
                }
                r.Close();
                Public.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: "+ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            idc = Public.id;
        }

        private void extTuyenDung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == true)
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
    }

}
