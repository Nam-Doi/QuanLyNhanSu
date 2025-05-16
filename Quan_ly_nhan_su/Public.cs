using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    internal class Public
    {
        public static string sql,id,idnv,TenDangNhap,MatKhau,maCN = null,tenCN;
        public static string connString = @"Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(connString);
        public static string maCV,cv;
        public static void chucvu()
        {
            if (maCV == "CQ")
            {
                cv = "Chủ quán";
            }
            else if (maCV == "QL")
            {
                cv = "Quản lý "+tenCN;
            }
            else if (maCV == "BB")
            {
                cv = "Bồi bàn "+tenCN;
            }
            else if (maCV == "PC")
            {
                cv = "Pha chế "+tenCN;
            }
        }
        public static SqlConnection KetNoi()
        {
            conn = new SqlConnection(connString);
            try
            {
                conn.Open(); // Mở kết nối tại đây
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return conn;
        }
        public static DataTable LayNguon(string sql)
        {
            try
            {
                using (SqlConnection conn = KetNoi())
                {
                    if (conn == null) return null;

                    // Tạo DataAdapter và DataTable
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();

                    // Điền dữ liệu vào DataTable
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void LayNguonDataGridView(DataGridView dgDanhSach, string sql)
        {
            try
            {
                // Lấy dữ liệu
                DataTable dt = LayNguon(sql);

                // Kiểm tra nếu không có dữ liệu
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Gán nguồn dữ liệu vào DataGridView
                dgDanhSach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu vào DataGridView: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool ThucHienSQL(string sql, SqlParameter[] parameters)
        {

            try
            {
                using (SqlConnection conn = KetNoi()) // Tự động đóng kết nối sau khi xong
                {
                    if (conn == null) return false;

                    // Tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Kiểm tra trạng thái kết nối
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        if (parameters != null) { cmd.Parameters.AddRange(parameters); }
                        // Thực thi câu lệnh
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi SQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool ktTrungMa(string FieldName, string Table, bool ktThem,
string ValueNew, string ValueOld)
        {
            if (ktThem == true)
                sql = "Select " + FieldName + " From " + Table + " Where " +
FieldName + " = '" + ValueNew + "'";
            else
                sql = "Select " + FieldName + " From " + Table + " Where " +
FieldName + " = '" + ValueNew + "' and " + FieldName + " <> '" + ValueOld + "'";
            DataTable dt = LayNguon(sql);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ThucHienSQL(string sql)
        {
            throw new NotImplementedException();
        }
        public static void GanNguonDataGridView(DataGridView dgName, string sql)
        {
            dgName.DataSource = LayNguon(sql);
        }
        public static void GanNguonComboBox(ComboBox cboName, string DisplayField, string KeyField, string sql)
        {
            cboName.DataSource = LayNguon(sql);
            cboName.DisplayMember = DisplayField;
            cboName.ValueMember = KeyField;
        }
    }

}

