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
    public partial class nhanVien : Form
    {
        private trangChu tc;
        public nhanVien(trangChu trangChu)
        {
            InitializeComponent();
            this.tc = trangChu;
        }
        private void nhanVien_Load(object sender, EventArgs e)
        {
            LoadNV();
        }
        public void LoadNV()
        {
            tc.loadtrangchu();
            Public.conn = new SqlConnection(Public.connString);
            try
            {
                var cn = new SqlDataAdapter(@"SELECT tenCN,maCN FROM chiNhanh", Public.conn);
                var ta = new DataTable();
                cn.Fill(ta);
                ta.Rows.InsertAt(ta.NewRow(), 0);
                ta.Rows[0]["maCN"] = "*";
                ta.Rows[0]["tenCN"] = "Tất cả";
                ta.Rows.InsertAt(ta.NewRow(), 1);
                ta.Rows[1]["maCN"] = "NULL";
                ta.Rows[1]["tenCN"] = "Chưa có đơn vị";
                locdonvi.DisplayMember = "tenCN";
                locdonvi.ValueMember = "maCN";
                locdonvi.DataSource = ta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu đơn vị không thành công lỗi: "+ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(Public.maCV != "CQ")
            {
                locdonvi.Enabled = false;
                locdonvi.SelectedValue = Public.maCN;
            }
            try
            {
                var cn1 = new SqlDataAdapter(@"SELECT tenCV,maCV FROM chucVu where maCV != 'CQ'", Public.conn);
                var ta1 = new DataTable();
                cn1.Fill(ta1);
                ta1.Rows.InsertAt(ta1.NewRow(), 0);
                ta1.Rows[0]["maCV"] = "*";
                ta1.Rows[0]["tenCV"] = "Tất cả";
                locchucvu.DisplayMember = "tenCV";
                locchucvu.ValueMember = "maCV";
                locchucvu.DataSource = ta1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu chức vụ không thành công lỗi: " + ex.Message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc();
        }
        private void loc()
        {
            string strsql = @"SELECT id,maNV,tenNV,convert(varchar(10), ngaysinh, 103) ngaysinh,gioitinh,tenCV,tenCN,sdt FROM nhanVien nv left join chiNhanh cn on nv.maCN = cn.maCN left join chucVu cv on nv.maCV = cv.maCV where nv.maCV != 'CQ' ";
            if ((string)locdonvi.SelectedValue == "*")
            {
                if((string)locchucvu.SelectedValue == "*")
                {

                }
                else if ((string)locchucvu.SelectedValue != "*")
                {
                    strsql += @"and nv.maCV = @maCV";
                }
            }
            else if((string)locdonvi.SelectedValue == "NULL")
            {
                if ((string)locchucvu.SelectedValue == "*")
                {
                    strsql += @"and cn.tenCN is null";
                }
                else
                {
                    strsql += @"and cn.tenCN is null and nv.maCV = @maCV";
                }
            }
            else
            {
                if((string)locchucvu.SelectedValue == "*")
                {
                    strsql += @"and nv.maCN = @maCN";
                }
                else
                {
                    strsql += @"and nv.maCN = @maCN and nv.maCV = @maCV";
                }
            }
            try
            {
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maCN",locdonvi.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@maCV",locchucvu.SelectedValue ?? DBNull.Value);
                var table = new DataTable();
                var sql = new SqlDataAdapter(cmd);
                sql.Fill(table);
                dataGridView1.DataSource = table;
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
            string strsql = @"SELECT id,maNV,tenNV,convert(varchar(10), ngaysinh, 103) ngaysinh,gioitinh,tenCV,tenCN,sdt FROM nhanVien nv left join chiNhanh cn on nv.maCN = cn.maCN left join chucVu cv on nv.maCV = cv.maCV where (maNV = @maNV or tenNV = @maNV)  and nv.maCV!='CQ' ";
            if (Public.maCV == "CQ")
            {
                if (kiemtra(strcmd))
                {
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên hoặc tên nhân viên " + tbMaNV.Text, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (kiemtra(strcmd))
                {
                    if (kiemtra(strcmd += @"and maCN = @maCN"))
                    {
                        strsql += @"and nv.maCN = @maCN";
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
                    MessageBox.Show("Không tìm thấy mã nhân viên hoặc tên nhân viên " + tbMaNV.Text, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            try
            {
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maNV", tbMaNV.Text);
                cmd.Parameters.AddWithValue("@maCN", Public.maCN);
                var sql = new SqlDataAdapter(cmd);
                var table = new DataTable();
                sql.Fill(table);
                dataGridView1.DataSource = table;
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
                cmd.Parameters.AddWithValue("@maNV", tbMaNV.Text );
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
            timma();
        }

        private void locchucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Public.id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (Public.maCV != "CQ")
                {
                    if (Public.maCV != "QL")
                    {
                        if (Public.id == Public.idnv)
                        {
                            extNhanVien ex = new extNhanVien(this);
                            if (Public.id != "") ex.Show();
                        }
                        else
                        {
                            MessageBox.Show("Bạn không được phép xem hồ sơ người khác!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        extNhanVien ex = new extNhanVien(this);
                        if (Public.id != "") ex.Show();
                    }
                }
                else
                {
                    extNhanVien ex = new extNhanVien(this);
                    if (Public.id != "") ex.Show();
                }
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

        private void tbMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                timma();
            }
        }

        private void tbMaNV_TextChanged(object sender, EventArgs e)
        {
            loc();
        }
    }
}
