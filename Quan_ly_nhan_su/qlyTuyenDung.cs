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
    public partial class tuyenDung : Form
    {
        private trangChu tc;
        public tuyenDung(trangChu trangChu)
        {
            InitializeComponent();
            this.tc = trangChu;
        }


        private void themNV_Click(object sender, EventArgs e)
        {
            xetDuyet themNV = new xetDuyet(this);  
            themNV.Show();
        }

        private void nhanVien_Load(object sender, EventArgs e)
        {
            LoadTD();
        }
        public void LoadTD()
        {
            tc.loadtrangchu();
            Public.conn = new SqlConnection(Public.connString);
            try
            {
                var cn = new SqlDataAdapter(@"SELECT tenCV,maCV FROM chucVu where maCV != 'CQ'", Public.conn);
                var ta = new DataTable();
                cn.Fill(ta);
                ta.Rows.InsertAt(ta.NewRow(), 0);
                ta.Rows[0]["maCV"] = "*";
                ta.Rows[0]["tenCV"] = "Tất cả";
                locchucvu.DisplayMember = "tenCV";
                locchucvu.ValueMember = "maCV";
                locchucvu.DataSource = ta;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: "+ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strsql = @"SELECT id,tenNV,convert(varchar(10), ngaysinh, 103) ngaysinh,gioitinh,que,cv.tenCV,nguoiTuyen from chucVu cv inner join tuyenDung td on td.maCV = cv.maCV "; ;
            try
            {
                if (Public.maCV != "CQ")
                {
                    if (locchucvu.SelectedValue.ToString() == "*")
                    {
                        strsql += @"where maCN = @maCN";

                    }
                    else
                    {
                        strsql += @"where td.maCV = @maCV and maCN = @maCN";
                    }
                }
                else
                {
                    if (locchucvu.SelectedValue.ToString() == "*")
                    {
                    }
                    else
                    {
                        strsql += @"where td.maCV = @maCV";
                    }
                }
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maCN",Public.maCN);
                cmd.Parameters.AddWithValue("maCV",locchucvu.SelectedValue.ToString());
                var sql = new SqlDataAdapter(cmd);
                var table = new DataTable();
                sql.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch(Exception ex) 
            { 
                MessageBox.Show("Tải dữ liệu không thành công lỗi: "+ex.Message,"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timten()
        {
            string strsql = @"SELECT id,tenNV,convert(varchar(10), ngaysinh, 103) ngaysinh,gioitinh,que,tenCV,nguoiTuyen 
                    FROM tuyenDung nv inner join chucVu cv on nv.maCV = cv.maCV 
                    where tenNV = @tenNV ";
            string strcmd = @"select count(tenNV) from tuyenDung where tenNV = @tenNV ";
            if (Public.maCV != "CQ")
            {
                if (kiemtra(strcmd))
                {
                    if (kiemtra(strcmd += @"and maCN = @maCN"))
                    {
                        strsql += @"and maCN = @maCN";

                    }
                    else
                    {
                        MessageBox.Show("Nhân viên này không thuộc đơn vị bạn công tác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên tên " + tbtenNV.Text.ToString().Trim(), "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (kiemtra(strcmd))
                {
                }
                else MessageBox.Show("Không tìm thấy nhân viên tên " + tbtenNV.Text.ToString().Trim(), "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maCN", Public.maCN);
                cmd.Parameters.AddWithValue("@tenNV", tbtenNV.Text);
                var sql = new SqlDataAdapter(cmd);
                var table = new DataTable();
                sql.Fill(table);
                dataGridView1.DataSource = table;
                Public.conn.Close();
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
                cmd.Parameters.AddWithValue("@tenNV", tbtenNV.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@maCN", Public.maCN);
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
        private void bttTim_Click(object sender, EventArgs e)
        {
            timten();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Public.id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (Public.maCV == "CQ" || Public.maCV == "QL")
                {
                    extTuyenDung ex = new extTuyenDung(this);
                    if (Public.id != "") ex.Show();
                }
                else MessageBox.Show("Bạn không đủ quyền hạn để truy cập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString("STT",
                    dataGridView1.DefaultCellStyle.Font,   // Font chữ
                    brush,                                // Màu chữ
                    dataGridView1.RowHeadersDefaultCellStyle.Padding.Left + 5, // Tọa độ X (canh lề)
                    dataGridView1.ColumnHeadersHeight / 4); // Tọa độ Y (đặt giữa chiều cao tiêu đề)
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                    dataGridView1.DefaultCellStyle.Font,
                    brush,
                    e.RowBounds.Location.X + 15,
                    e.RowBounds.Location.Y + 4);
            }
        }

        private void tbtenNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                timten();
            }
        }

        private void tbtenNV_TextChanged(object sender, EventArgs e)
        {
            tbChiNhanh_SelectedIndexChanged(sender, e);
        }
    }
}
