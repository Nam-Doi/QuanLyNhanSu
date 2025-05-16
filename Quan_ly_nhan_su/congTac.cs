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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Quan_ly_nhan_su
{
    public partial class congTac : Form
    {
        public congTac()
        {
            InitializeComponent();
        }
        bool close = false;
        private void congTac_Load(object sender, EventArgs e)
        {
            Public.conn = new SqlConnection(Public.connString);
            close = false;
            donvi.Enabled = false;
            capnhat.Enabled = false;
            try
            {
                var cn = new SqlDataAdapter(@"SELECT tenCN,maCN FROM chiNhanh", Public.conn);
                var ta = new DataTable();
                cn.Fill(ta);
                ta.Rows.InsertAt(ta.NewRow(), 0);
                ta.Rows.InsertAt(ta.NewRow(), 1);
                ta.Rows[0]["maCN"] = "*";
                ta.Rows[0]["tenCN"] = "Tất cả";
                ta.Rows[1]["maCN"] = "NULL";
                ta.Rows[1]["tenCN"] = "Chưa công tác";
                locdonvi.DisplayMember = "tenCN";
                locdonvi.ValueMember = "maCN";
                locdonvi.DataSource = ta;
                var ta1 = new DataTable();
                cn.Fill(ta1);
                ta1.Rows.InsertAt(ta1.NewRow(), 0);
                ta1.Rows[0]["maCN"] = "NULL";
                ta1.Rows[0]["tenCN"] = "Chưa công tác";
                donvi.DisplayMember = "tenCN";
                donvi.ValueMember = "maCN";
                donvi.DataSource = ta1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void locdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strsql = @"SELECT maNV,tenNV,convert(varchar(10), ngaysinh, 103) ngaysinh,gioitinh,tenCV,tenCN,ISNULL(nv.maCN,N'NULL') maCN FROM nhanVien nv left join chiNhanh cn on nv.maCN = cn.maCN left join chucVu cv on nv.maCV = cv.maCV ";
            if (dataGridView1.Rows.Count > 0)
                if (dataGridView1.CurrentRow != null && !dataGridView1.CurrentRow.IsNewRow)
                {

                    donvi.SelectedValue = dataGridView1.CurrentRow.Cells["maCN"].Value.ToString();
                    sua.Enabled = true;
                }
                else sua.Enabled = false;
            if (locdonvi.SelectedValue.ToString() == "*")
            {

            }
            else if (locdonvi.SelectedValue.ToString() == "NULL")
            {
                strsql += @"where cn.tenCN is null";
            }
            else
            {
                strsql += @"where nv.maCN = @maCN";
            }
            try
            {
                var cmd = new SqlCommand(strsql,Public.conn);
                cmd.Parameters.AddWithValue("@maCN",locdonvi.SelectedValue.ToString());
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            donvi.Enabled = false;
            capnhat.Enabled = false;
            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "") sua.Enabled = false;
            else sua.Enabled = true;
            donvi.SelectedValue = dataGridView1.CurrentRow.Cells["maCN"].Value.ToString();
        }

        private void sua_Click(object sender, EventArgs e)
        {
            donvi.Enabled = true;
            capnhat.Enabled = true;
            close = true;
        }

        private void congTac_FormClosing(object sender, FormClosingEventArgs e)
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

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (sua.Enabled == true) 
            {
                try
                {
                    if (dataGridView1.CurrentRow.Cells["maCN"].Value.ToString() == "NULL")
                    {
                        Public.conn.Open();
                        var sql = new SqlCommand(@"insert into nhanVien(maCN) values (@maCN) where maNV = '" + dataGridView1.CurrentRow.Cells["maNV"].Value.ToString() + "'", Public.conn);
                        sql.Parameters.AddWithValue("@maCN", donvi.SelectedValue.ToString());
                        sql.ExecuteNonQuery();
                        Public.conn.Close();
                        MessageBox.Show("Cập nhật đơn vị công tác thành công", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if(donvi.SelectedValue.ToString() != "NULL")
                        {
                            Public.conn.Open();
                            var sql = new SqlCommand(@"update nhanVien set maCN = @maCN where maNV = '" + dataGridView1.CurrentRow.Cells["maNV"].Value.ToString() + "'", Public.conn);
                            sql.Parameters.AddWithValue("@maCN", donvi.SelectedValue.ToString());
                            sql.ExecuteNonQuery();
                            Public.conn.Close();
                        }
                        else
                        {
                            Public.conn.Open();
                            var sql = new SqlCommand(@"update nhanVien set maCN = NULL where maNV = '" + dataGridView1.CurrentRow.Cells["maNV"].Value.ToString() + "'", Public.conn);
                            sql.ExecuteNonQuery();
                            Public.conn.Close();
                        }
                        MessageBox.Show("Cập nhật đơn vị công tác thành công", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    congTac_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật đơn vị công tác không thành công lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void timma()
        {
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand(@"select count(maNV) from nhanVien where maNV = '" + txtmaNV.Text + "'or tenNV = N'"+txtmaNV.Text+"'", Public.conn);
                int c = (int)cmd.ExecuteScalar();
                if (c > 0)
                {
                    var sql = new SqlDataAdapter(@"SELECT maNV,tenNV,convert(varchar(10), ngaysinh, 103) ngaysinh,gioitinh,tenCV,tenCN,nv.maCN FROM nhanVien nv left join chiNhanh cn on nv.maCN = cn.maCN inner join chucVu cv on nv.maCV = cv.maCV where maNV = '" + txtmaNV.Text.ToString() + "' or tenNV = N'"+txtmaNV.Text.ToString()+"'", Public.conn);
                    var table = new DataTable();
                    sql.Fill(table);
                    dataGridView1.DataSource = table;

                }
                else MessageBox.Show("Không tìm thấy mã nhân viên " + txtmaNV.Text, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Public.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tim_Click(object sender, EventArgs e)
        {
            timma();
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

        private void txtmaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                timma();
            }
        }

        private void txtmaNV_TextChanged(object sender, EventArgs e)
        {
            locdonvi_SelectedIndexChanged(sender, e);
        }
    }
}
