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
    public partial class qlycong : Form
    {
        public qlycong()
        {
            InitializeComponent();
        }

        private void qlycong_Load(object sender, EventArgs e)
        {
            loadcong();
        }
        public void loadcong()
        {
            Public.conn = new SqlConnection(Public.connString);
            doc();
            try
            {
                var sql = new SqlDataAdapter(@"select tenCN,maCN from chiNhanh", Public.conn);
                var table = new DataTable();
                sql.Fill(table);
                donvi.DisplayMember = "tenCN";
                donvi.ValueMember = "maCN";
                donvi.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Public.maCV != "CQ")
            {
                donvi.Enabled = false;
                if (Public.maCV != null) donvi.SelectedValue = Public.maCV;
                else donvi.SelectedValue = "";
            }
        }
        private void loc()
        {
            String strsql = @"
                    SELECT nhanVien.maNV, nhanVien.tenNV, count(ChamCong.maNV) songay,datediff(day,@NgayStart,@NgayEnd) tong,format((DATEDIFF(DAY, @NgayStart, @NgayEnd)-COUNT(ChamCong.maNV)) * 100.0 / NULLIF(DATEDIFF(DAY, @NgayStart, @NgayEnd), 0),'N2')+'%' tile
                    FROM nhanVien 
                    LEFT JOIN ChamCong ON nhanVien.maNV = ChamCong.maNV where maCN = @maCN 
                    and ChamCong.NgayCham BETWEEN @NgayStart AND @NgayEnd
                    GROUP BY nhanVien.maNV, nhanVien.tenNV";
            try
            {
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maCN", donvi.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayStart", ngaystart.Value.Date);
                cmd.Parameters.AddWithValue("@NgayEnd", ngayend.Value.Date);
                var table = new DataTable();
                var sql = new SqlDataAdapter(cmd);
                foreach (DataRow row in table.Rows)
                {
                    if (row["CheckInTime"] != DBNull.Value)
                    {
                        row["CheckInTime"] = TimeSpan.Parse(row["CheckInTime"].ToString()).ToString(@"hh\:mm\:ss");
                    }
                }
                sql.Fill(table);
                dgDanhSach.DataSource = table;
                if (dgDanhSach.Columns["NgayCham"] != null) dgDanhSach.Columns["NgayCham"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (dgDanhSach.Columns["CheckInTime"] != null) dgDanhSach.Columns["CheckInTime"].DefaultCellStyle.Format = @"hh\:mm\:ss";
            }
            catch
            {
            }
        }
        private void doc()
        {
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand(@"select top 1 NgayCham from ChamCong", Public.conn);
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    ngaystart.Value = r.GetDateTime(r.GetOrdinal("NgayCham"));
                }
                r.Close();
                Public.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timma()
        {
            string strcmd = @"select count(maNV) from nhanVien where (maNV = @maNV or tenNV = @maNV) ";
            string strsql = @"SELECT nhanVien.maNV, nhanVien.tenNV, count(ChamCong.maNV) songay,datediff(day,@NgayStart,@NgayEnd) tong,format((DATEDIFF(DAY, @NgayStart, @NgayEnd)-COUNT(ChamCong.maNV)) * 100.0 / NULLIF(DATEDIFF(DAY, @NgayStart, @NgayEnd), 0),'N2')+'%' tile  FROM nhanVien 
                    LEFT JOIN ChamCong ON nhanVien.maNV = ChamCong.maNV where (nhanVien.maNV LIKE @maNV + '%' or tenNV LIKE @maNV + '%')  and maCV!='CQ' ";
            if (Public.maCV == "CQ")
            {
            }
            else
            {
                if (kiemtra(strcmd))
                {
                    if (kiemtra(strcmd += @"and maCN = @maCN "))
                    {
                        strsql += @"and maCN = @maCN ";
                    }
                }
            }
            strsql += @"and ChamCong.NgayCham BETWEEN @NgayStart AND @NgayEnd 
                        GROUP BY nhanVien.maNV, nhanVien.tenNV ";
            try
            {
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maNV", tbMaNV.Text);
                cmd.Parameters.AddWithValue("@maCN", donvi.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayStart", ngaystart.Value.Date);
                cmd.Parameters.AddWithValue("@NgayEnd", ngayend.Value.Date);
                var sql = new SqlDataAdapter(cmd);
                var table = new DataTable();
                sql.Fill(table);
                dgDanhSach.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool kiemtra(string sql)
        {
            int c;
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand(sql, Public.conn);
                cmd.Parameters.AddWithValue("@maNV", tbMaNV.Text);
                cmd.Parameters.AddWithValue("@maCN", donvi.SelectedValue);
                c = (int)cmd.ExecuteScalar();
                Public.conn.Close();
            }
            catch (Exception ex)
            {
                c = 0;
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return c > 0;
        }
        private void donvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc();
        }

        private void ngay_ValueChanged(object sender, EventArgs e)
        {
            loc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chamcong chamcong = new chamcong(this);
            chamcong.Show();
        }

        private void ngayend_ValueChanged(object sender, EventArgs e)
        {
            loc();
        }

        private void tbMaNV_TextChanged(object sender, EventArgs e)
        {
            timma();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá thông tin về số ngày công của nhân viên từ ngày " + ngaystart.Value.ToString("dd/MM/yyyy") + " đến " + ngayend.Value.ToString("dd/MM/yyyy"), "Thông báo",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Mở kết nối nếu nó đang đóng
                    if (Public.conn.State == ConnectionState.Closed)
                    {
                        Public.conn.Open();
                    }

                    var cmd = new SqlCommand("delete from ChamCong where ChamCong.NgayCham BETWEEN @NgayStart AND @NgayEnd", Public.conn);
                    cmd.Parameters.AddWithValue("@NgayStart", ngaystart.Value.Date);
                    cmd.Parameters.AddWithValue("@NgayEnd", ngayend.Value.Date);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá không thành công lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Đảm bảo kết nối được đóng sau khi thực hiện
                    if (Public.conn.State == ConnectionState.Open)
                    {
                        Public.conn.Close();
                    }
                }
            }
        }
    }
}
