using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class frmDaoTao : Form
    {
        bool ktThem;
        string macu, dk = "";
        DataGridViewCellMouseEventArgs vt,vtTim;
        public frmDaoTao()
        {
            InitializeComponent();
        }
        public void khoaMo(bool b)
        {
            btnThem.Enabled = b; btnKetThuc.Enabled = b;
            btnXoa.Enabled = b;
            txtMaDT.ReadOnly = b;btnGhi.Enabled = !b; 
            btnSua.Enabled = b;btnChon.Enabled = !b;cboLoaiDT.Enabled = !b;cboTrangThai.Enabled = !b;
            chkBatDau.Enabled = !b;dtpBatDau.Enabled= !b;
            chkKetThuc.Enabled= !b;dtpKetThuc.Enabled = !b;

        }
        void LayNguon()
        {
            Public.sql = "SELECT DaoTao.MaDaoTao, nhanVien.maNV, nhanVien.tenNV, " +
             "convert(nvarchar(10), DaoTao.NgayBD, 103) NgayBD, " +
             "convert(nvarchar(10), DaoTao.NgayKT, 103) NgayKT, " +
             "TrangThai.TenTT, loaiDT.TenLDT, DaoTao.maTT, LoaiDT.MaLDT " +
             "FROM DaoTao " +
             "JOIN nhanVien ON DaoTao.maNV = nhanVien.maNV " +
             "JOIN TrangThai ON DaoTao.maTT = TrangThai.maTT " +
             "JOIN LoaiDT ON DaoTao.MaLDT = LoaiDT.MaLDT ";

            if (Public.maCV != "CQ")
            {
                Public.sql += "WHERE nhanVien.maCN = '" + Public.maCN + "'";
                if(Public.maCV != "QL")
                {
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }

            if (dk != "")
            {
                Public.sql = Public.sql + " Where MaDaoTao Like '%" + dk + "%' or nhanVien.maNV Like '%" + dk + "%' ";
                if(Public.maCV != "CQ")
                {
                    Public.sql += @"nhanVien.maCN = '" + Public.maCN + "'";
                }
            }
            Public.sql = Public.sql + " Order By MaDaoTao ";
            Public.GanNguonDataGridView(dgDanhSach, Public.sql);
            Public.LayNguonDataGridView(dgDanhSach, Public.sql);
        }
        void LayNguonNhanVien()
        {
            Public.sql = "SELECT nhanVien.maNV, nhanVien.tenNV " +
               "From nhanVien LEFT JOIN DaoTao ON nhanVien.maNV = DaoTao.maNV WHERE DaoTao.maNV IS NULL ";
            if (Public.maCV != "CQ") Public.sql += "and nhanVien.maCN = '" + Public.maCN + "'";
            Public.LayNguonDataGridView(dgNhanVien, Public.sql);
        }
        void LayNguonComBo()
        {
            Public.GanNguonComboBox(cboLoaiDT, "TenLDT", "MaLDT", "Select MaLDT,TenLDT From LoaiDT");
            Public.GanNguonComboBox(cboTrangThai, "TenTT", "maTT", "Select maTT,TenTT From TrangThai");
        }
        void TaomaDT()
        {
            long num = 1; // Giá trị mặc định nếu bảng rỗng
            string maDT = ""; // Mã đào tạo mới

            // Câu lệnh SQL để lấy mã đào tạo lớn nhất (theo thứ tự giảm dần)
            string sql = "SELECT TOP 1 MaDaoTao FROM DaoTao ORDER BY MaDaoTao DESC";

            // Lấy dữ liệu từ cơ sở dữ liệu
            DataTable dt = Public.LayNguon(sql);  // Sử dụng hàm Public.LayNguon để lấy dữ liệu từ SQL Server

            if (dt != null && dt.Rows.Count > 0)  // Nếu có dữ liệu
            {
                string lastMaDT = dt.Rows[0][0].ToString(); // Lấy mã đào tạo cuối cùng
                string numberPart = lastMaDT.Substring(2);  // Bỏ "DT" và lấy phần số (ví dụ: "DT001" -> "001")

                if (long.TryParse(numberPart, out num))  // Chuyển phần số thành kiểu long
                {
                    num++;
                }
            }
            maDT = "DT" + num.ToString("D7");
            txtMaDT.Text = maDT;
        }




        private void frmDaoTao_Load(object sender, EventArgs e)
        {
            khoaMo(true);
            LayNguon();
            LayNguonComBo();
        }
        void XoaTrang()
        {
            txtMaDT.Text = ""; txtMaNV.Text = ""; txtHoTen.Text = "";
        }

        private void dgDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                macu = "";
                if (e == null) return;
                if (dgDanhSach.RowCount <= 0) return;
                if (e.RowIndex >= 0)
                {
                    if(Public.maCV=="CQ"||Public.maCV=="QL")khoaMo(true);
                    vt = e;
                    DataGridViewRow row = dgDanhSach.Rows[e.RowIndex];
                    txtMaDT.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtHoTen.Text = row.Cells[2].Value.ToString();
                    chkBatDau.Checked = false; dtpBatDau.Value = DateTime.Now;
                    if (row.Cells[3].Value != null)
                    {
                        if (row.Cells[3].Value.ToString() != "")
                        {
                            chkBatDau.Checked = true;
                            dtpBatDau.Value = DateTime.ParseExact(row.Cells[3].Value.ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    chkKetThuc.Checked = false; dtpKetThuc.Value = DateTime.Now;
                    if (row.Cells[4].Value != null)
                    {
                        if (row.Cells[4].Value.ToString() != "")
                        {
                            chkKetThuc.Checked = true;
                            dtpKetThuc.Value = DateTime.ParseExact(row.Cells[4].Value.ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    macu = txtMaDT.Text;
                    cboTrangThai.SelectedValue = row.Cells[7].Value.ToString();
                    cboLoaiDT.SelectedValue = row.Cells[8].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát sinh:" + ex.Message, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LayNguonNhanVien();
            khoaMo(false);
            ktThem = true;
            chkBatDau.Checked = true;
            dtpBatDau.Value = DateTime.Now;
            chkKetThuc.Checked = true;
            dtpKetThuc.Value = DateTime.Today.AddMonths(1);
            XoaTrang();
            TaomaDT();
        }
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrEmpty(txtMaDT.Text))
            {
                HienThiCanhBao("Bạn chưa nhập mã đào tạo.", txtMaDT);
                return false;
            }

            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                HienThiCanhBao("Bạn chưa nhập mã nhân viên.", txtMaNV);
                return false;
            }

            if (cboTrangThai.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboLoaiDT.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn loại đào tạo.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Public.ktTrungMa("MaDaoTao", "DaoTao", ktThem, txtMaDT.Text, macu))
            {
                HienThiCanhBao("Bạn nhập mã đào tạo trùng với mã đào tạo đã tồn tại.", txtMaDT);
                return false;
            }

            return true;
        }

        private void HienThiCanhBao(string thongBao, Control control)
        {
            MessageBox.Show(thongBao, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private bool XacNhanCapNhat()
        {
            return MessageBox.Show("Bạn có muốn cập nhật nhân viên không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void CapNhatDaoTao()
        {
            Public.sql = ktThem
                ? "Insert Into DaoTao(MaDaoTao, maNV, NgayBD, NgayKT, maTT, MaLDT) Values(@ma, @nv, @bd, @kt, @tt, @ldt)"
                : "Update DaoTao Set MaDaoTao=@ma, maNV=@nv, NgayBD=@bd, NgayKT=@kt, maTT=@tt, MaLDT=@ldt Where MaDaoTao=@macu";

            using (SqlConnection conn = Public.KetNoi())
            {
                using (SqlCommand cmd = new SqlCommand(Public.sql, conn))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtMaDT.Text;
                    cmd.Parameters.Add("@nv", SqlDbType.NChar).Value = txtMaNV.Text;
                    cmd.Parameters.Add("@bd", SqlDbType.Date).Value = chkBatDau.Checked ? (object)dtpBatDau.Value : DBNull.Value;
                    cmd.Parameters.Add("@kt", SqlDbType.Date).Value = chkKetThuc.Checked ? (object)dtpKetThuc.Value : DBNull.Value;
                    cmd.Parameters.Add("@tt", SqlDbType.NVarChar).Value = cboTrangThai.SelectedValue;
                    cmd.Parameters.Add("@ldt", SqlDbType.NVarChar).Value = cboLoaiDT.SelectedValue;

                    if (!ktThem) cmd.Parameters.Add("@macu", SqlDbType.NVarChar).Value = macu;

                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Bạn cập nhật nhân viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiGiaoDien();
        }

        private void LamMoiGiaoDien()
        {
            XoaTrang();
            khoaMo(true);
            LayNguon();

            try
            {
                dgDanhSach_CellMouseClick(null, vt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraDuLieu()) return;

                if (Public.maCV == "QL" && (string)cboLoaiDT.SelectedValue == "1")
                {
                    MessageBox.Show("Bạn không đủ quyền hạn để đào tạo quản lý!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (XacNhanCapNhat())
                {
                    CapNhatDaoTao();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

        private void dgNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgNhanVien.RowCount<=0) return;
            if(e==null)return;
            if (e.RowIndex >= 0)
                vtTim = e;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDT.Text == "") return;
            ktThem=false;
            macu=txtMaDT.Text;
            khoaMo(false);
            txtMaDT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDT.Text == "") return;
            macu = txtMaDT.Text;
            if (Public.maCV == "QL")
            {
                if (dgDanhSach.SelectedRows[0].Cells[8].Value.ToString().Trim() == "1")
                {
                    MessageBox.Show("Bạn không đủ quyền hạn xoá đào tạo quản lý!","Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa nhân viên đang chọn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Public.sql = "Delete From DaoTao Where MaDaoTao=@MaDaoTao";
                        SqlParameter[] parameters = { new SqlParameter("@MaDaoTao", macu) };
                        if (Public.ThucHienSQL(Public.sql, parameters))
                        {
                            MessageBox.Show("Bạn thực hiện xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                            LayNguon();
                            LayNguonNhanVien();
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa nhân viên đang chọn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Public.sql = "Delete From DaoTao Where MaDaoTao=@MaDaoTao";
                    SqlParameter[] parameters = { new SqlParameter("@MaDaoTao", macu) };
                    if (Public.ThucHienSQL(Public.sql, parameters))
                    {
                        MessageBox.Show("Bạn thực hiện xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrang();
                        LayNguon();
                        LayNguonNhanVien();
                    }
                }
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dk = txtTimKiem.Text;
                LayNguon();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChon_Click(object sender, EventArgs e)
        {

            if (!btnGhi.Enabled) return;
            if (dgNhanVien.SelectedRows.Count == 0)
            {
                // Nếu không có hàng nào được chọn, chọn hàng đầu tiên
                if (dgNhanVien.Rows.Count > 0)
                {
                    dgNhanVien.ClearSelection();
                    dgNhanVien.Rows[0].Selected = true;
                }
                else
                {
                    // Nếu DataGridView không có hàng nào, hiển thị thông báo
                    MessageBox.Show("Không có nhân viên nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // Lấy hàng được chọn (sau khi đảm bảo đã có hàng được chọn)
                DataGridViewRow selectedRow = dgNhanVien.SelectedRows[0];

                // Gán giá trị từ các ô của hàng được chọn vào các TextBox tương ứng
                txtMaNV.Text = selectedRow.Cells[0].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value?.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
