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
    public partial class chamcong : Form
    {
        private qlycong ql;
        public chamcong(qlycong qlycong)
        {
            InitializeComponent();
            this.ql = qlycong;
        }

        private void chamcong_Load(object sender, EventArgs e)
        {
            dtpNgayCham.Value = DateTime.Today;
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
        private void load()
        {
                String strsql = @"
                                SELECT nhanVien.maNV, nhanVien.tenNV, 
                                ISNULL(ChamCong.NgayCham, NULL) AS NgayCham,
                                ISNULL(ChamCong.CheckInTime, NULL) AS CheckInTime
                                FROM nhanVien
                                LEFT JOIN ChamCong 
                                ON nhanVien.maNV = ChamCong.maNV 
                                AND ChamCong.NgayCham = @NgayCham
                                WHERE maCN = @maCN";

                try
                {
                    var cmd = new SqlCommand(strsql, Public.conn);
                    if(donvi.SelectedValue!=null) cmd.Parameters.AddWithValue("@maCN", donvi.SelectedValue.ToString().Trim());
                    cmd.Parameters.AddWithValue("@NgayCham", dtpNgayCham.Value.Date);

                    var table = new DataTable();
                    var sql = new SqlDataAdapter(cmd);
                    if (donvi.SelectedValue != null) sql.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        if (row["CheckInTime"] != DBNull.Value)
                        {
                            row["CheckInTime"] = TimeSpan.Parse(row["CheckInTime"].ToString()).ToString(@"hh\:mm\:ss");
                        }
                    }

                    dgDanhSach.DataSource = table;

                    // Định dạng các cột nếu cần
                    if (dgDanhSach.Columns["NgayCham"] != null)
                        dgDanhSach.Columns["NgayCham"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (dgDanhSach.Columns["CheckInTime"] != null)
                        dgDanhSach.Columns["CheckInTime"].DefaultCellStyle.Format = @"hh\:mm\:ss";

                    // Cập nhật trạng thái checkbox
                    foreach (DataGridViewRow row in dgDanhSach.Rows)
                    {
                        if (row.Cells["NgayCham"].Value != DBNull.Value && row.Cells["NgayCham"].Value != null)
                        {
                            row.Cells["Cham"].Value = true; // Tick nếu đã chấm công
                        }
                        else
                        {
                            row.Cells["Cham"].Value = false; // Không tick nếu chưa chấm công
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tải dữ liệu không thành công lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void donvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            load();
        }

        private void tatca_CheckedChanged(object sender, EventArgs e)
        {
            if (tatca.Checked)
            {
                foreach (DataGridViewRow row in dgDanhSach.Rows)
                {
                    // Đảm bảo không thay đổi giá trị của các dòng mới (chưa được gắn dữ liệu)
                    if (row.Cells["Cham"] != null)
                    {
                        // Đánh dấu tất cả các CheckBox là true (tick)
                        row.Cells["Cham"].Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgDanhSach.Rows)
                {
                    // Đảm bảo không thay đổi giá trị của các dòng mới (chưa được gắn dữ liệu)
                    if (row.Cells["Cham"] != null)
                    {
                        // Đánh dấu tất cả các CheckBox là true (tick)
                        row.Cells["Cham"].Value = false;
                    }
                }
            }
        }

        private void gui_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Public.connString))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgDanhSach.Rows)
                {
                    // Kiểm tra giá trị trước khi xử lý
                    if (row.Cells["maNV"].Value == null)
                    {
                        continue; // Bỏ qua dòng nếu dữ liệu không hợp lệ
                    }

                    // Lấy giá trị từ DataGridView
                    string maNV = row.Cells["maNV"].Value.ToString().Trim();
                    bool isChecked = Convert.ToBoolean(row.Cells["Cham"].Value);
                    string queryInsert = "";
                    DateTime ngayCham = DateTime.Now.Date;
                    TimeSpan checkInTime = DateTime.Now.TimeOfDay;

                    // Kiểm tra dữ liệu trong bảng
                    string queryCheck = "SELECT COUNT(*) FROM ChamCong WHERE maNV = @ma AND NgayCham = @Date";
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@ma", maNV);
                        cmdCheck.Parameters.AddWithValue("@Date", ngayCham);
                        int count = (int)cmdCheck.ExecuteScalar();

                        if (row.Cells["Cham"].Value != null && row.Cells["Cham"].Value != DBNull.Value) 
                        {
                            if (isChecked)
                            {
                                // Nếu được tick, cập nhật hoặc thêm mới
                                queryInsert = count > 0
                                    ? "UPDATE ChamCong SET NgayCham = @Date, CheckInTime = @CheckInTime WHERE maNV = @ma AND NgayCham = @Date"
                                    : "INSERT INTO ChamCong (maNV, NgayCham, CheckInTime) VALUES (@ma, @Date, @CheckInTime)";

                                // Cập nhật DataGridView
                                row.Cells["NgayCham"].Value = ngayCham;
                                row.Cells["CheckInTime"].Value = checkInTime.ToString(@"hh\:mm\:ss");
                            }
                            else
                            {
                                row.Cells["CheckInTime"].Value = DBNull.Value;
                                row.Cells["NgayCham"].Value = DBNull.Value;
                                if (count > 0)
                                {
                                    queryInsert = "DELETE FROM ChamCong WHERE maNV = @ma AND NgayCham = @Date";
                                }
                            }
                        }
                        else
                        {
                            row.Cells["CheckInTime"].Value = DBNull.Value;
                            row.Cells["NgayCham"].Value = DBNull.Value;
                            if (count > 0)
                            {
                                queryInsert = "DELETE FROM ChamCong WHERE maNV = @ma AND NgayCham = @Date";
                            }
                        }
                    }

                    // Thực thi lệnh SQL nếu có
                    if (!string.IsNullOrWhiteSpace(queryInsert))
                    {
                        using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@ma", maNV);
                            cmdInsert.Parameters.AddWithValue("@Date", ngayCham);
                            if (isChecked)
                            {
                                cmdInsert.Parameters.AddWithValue("@CheckInTime", checkInTime.ToString(@"hh\:mm\:ss"));
                            }

                            try
                            {
                                cmdInsert.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi thực thi SQL: {ex.Message}");
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Dữ liệu đã được cập nhật thành công!");
            ql.loadcong();
        }

        private void dtpNgayCham_ValueChanged(object sender, EventArgs e)
        {
            load();
            if (dtpNgayCham.Value == DateTime.Today) 
            {
                gui.Enabled = true;
            }
            else
            {
                gui.Enabled = false;
            }
        }
    }
}
