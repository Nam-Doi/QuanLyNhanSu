using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class frmHopDong : Form
    {
        bool ktThem;
        String macu, dk = "";
        DataGridViewCellMouseEventArgs vt, vtTim;
        public frmHopDong()
        {
            InitializeComponent();
        }
        string macv;
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            KhoaMo(true);
            LayNguon();
            LayNguonCombo();
        }
        public void KhoaMo(bool b)
        {
            btnChon.Enabled = !b;
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnCapNhat.Enabled = !b;
            txtMaHD.Enabled =! b;
            cboLoaiHD.Enabled =! b;
            dtpHan.Enabled = !b;
            dtpNgayKy.Enabled = !b;

        }
        void LayNguon()
        {
            Public.sql = @"SELECT nhanVien.maNV, nhanVien.tenNV, HopDong.MaHD, LoaiHopDong.TenLoaiHD, convert(nvarchar(10),HopDong.NgayBatDau,103) NgayBatDau, convert(nvarchar(10),HopDong.NgayKetThuc,103) NgayKetThuc, LoaiHopDong.MaLoaiHD, nhanVien.maCV " + "FROM HopDong JOIN LoaiHopDong ON HopDong.MaLoaiHD = LoaiHopDong.MaLoaiHD JOIN nhanVien ON HopDong.maNV = nhanVien.maNV ";
            if (Public.maCV != "CQ") Public.sql += @"where nhanVien.maCN = '" + Public.maCN + "'";
            if (dk != "")
                Public.sql = Public.sql + " Where HopDong.MaHD Like '%" + dk + "%' or nhanVien.maNV Like '%" + dk + "%'";
            Public.sql = Public.sql + " Order By MaHD ";
            Public.GanNguonDataGridView(dgDanhSach, Public.sql);
        }
        void LayNguonCombo()
        {
            Public.GanNguonComboBox(cboLoaiHD, "TenLoaiHD", "MaLoaiHD", "Select MaLoaiHD,TenLoaiHD From LoaiHopDong");
        }
        void LayNguonNhanVien()
        {
            Public.sql = @"SELECT nhanVien.maNV, nhanVien.tenNV,maCV " +
              "From nhanVien LEFT JOIN HopDong ON nhanVien.maNV = HopDong.maNV WHERE HopDong.maNV IS NULL ";
            if (Public.maCV != "CQ") Public.sql += @"and nhanVien.maCN = '" + Public.maCN + "'";
            Public.LayNguonDataGridView(dgNhanVien, Public.sql);
        }
        void TaoSoHD()
        {
            long num = 1;
            string SoHD = "";


            string sql = "SELECT TOP 1 MaHD FROM HopDong ORDER BY MaHD DESC";
            DataTable dt = Public.LayNguon(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                string lastSoHD = dt.Rows[0][0].ToString();
                string numberPart = lastSoHD.Substring(2);

                if (long.TryParse(numberPart, out num))
                {
                    num++;
                }
            }
            SoHD = "HD" + num.ToString("D4");
            txtMaHD.Text = SoHD;
        }
        void XoaTrang()
        {
            txtMaHD.Text = "";txtMaNV.Text = "";
            txtTenNV.Text = "";
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
                    KhoaMo(true);
                    vt = e;
                    DataGridViewRow row = dgDanhSach.Rows[e.RowIndex];
                    txtMaNV.Text = row.Cells[0].Value.ToString();
                    txtTenNV.Text = row.Cells[1].Value.ToString();
                    txtMaHD.Text = row.Cells[2].Value.ToString();
                    chkBatDau.Checked = false; dtpNgayKy.Value = DateTime.Now;
                    chkKetThuc.Checked = false;dtpHan.Value  = DateTime.Now;
                    if (row.Cells[4].Value != null)
                    {
                        if (row.Cells[4].Value.ToString() != "")
                        {
                            chkBatDau.Checked = true;
                            dtpNgayKy.Value = DateTime.ParseExact(row.Cells[4].Value.ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    if (row.Cells[5].Value != null)
                    {
                        if (row.Cells[5].Value.ToString() != "")
                        {
                            chkKetThuc.Checked = true;
                            dtpHan.Value = DateTime.ParseExact(row.Cells[5].Value.ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }

                    macv = row.Cells[7].Value?.ToString().Trim();
                    macu = txtMaHD.Text;
                    cboLoaiHD.SelectedValue = row.Cells[6].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát sinh:" + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LayNguonNhanVien();
            KhoaMo(false);
            ktThem = true;
            chkBatDau.Checked = true;
            chkKetThuc.Checked = true;
            dtpNgayKy.Value = DateTime.Now;
            dtpHan.Value = DateTime.Today.AddYears(1);
            XoaTrang();
            TaoSoHD();
        }
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                HienThiCanhBao("Bạn chưa nhập mã hợp đồng.", txtMaHD);
                return false;
            }

            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                HienThiCanhBao("Bạn chưa nhập mã nhân viên.", txtMaNV);
                return false;
            }

            if (cboLoaiHD.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn loại hợp đồng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Public.ktTrungMa("MaHD", "HopDong", ktThem, txtMaHD.Text, macu))
            {
                HienThiCanhBao("Bạn nhập mã đào tạo trùng với mã hợp đồng đã tồn tại.", txtMaHD);
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
            return MessageBox.Show("Bạn có muốn cập nhật hợp đồng không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void CapNhatHopDong()
        {
            Public.sql = ktThem
                ? "Insert Into HopDong(MaHD, NgayBatDau, NgayKetThuc, MaLoaiHD, maNV) Values(@ma, @bd, @kt, @lhd, @nv)"
                : "Update HopDong Set MaHD=@ma, NgayBatDau=@bd, NgayKetThuc=@kt, MaLoaiHD=@lhd, MaNV=@nv Where MaHD=@macu";

            using (SqlConnection conn = Public.KetNoi())
            {
                using (SqlCommand cmd = new SqlCommand(Public.sql, conn))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtMaHD.Text;
                    cmd.Parameters.Add("@nv", SqlDbType.NChar).Value = txtMaNV.Text;
                    cmd.Parameters.Add("@bd", SqlDbType.Date).Value = chkBatDau.Checked ? (object)dtpNgayKy.Value : DBNull.Value;
                    cmd.Parameters.Add("@kt", SqlDbType.Date).Value = chkKetThuc.Checked ? (object)dtpHan.Value : DBNull.Value;
                    cmd.Parameters.Add("@lhd", SqlDbType.NVarChar).Value = cboLoaiHD.SelectedValue;
                    if (!ktThem) cmd.Parameters.Add("@macu", SqlDbType.NVarChar).Value = macu;

                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Bạn cập nhật hợp đồng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiGiaoDien();
        }

        private void LamMoiGiaoDien()
        {
            XoaTrang();
            KhoaMo(true);
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {


            try
            {
                if (!KiemTraDuLieu()) return;

                if (Public.maCV == "CQ")
                {
                    if (XacNhanCapNhat())
                    {
                        CapNhatHopDong();
                    }
                }
                else
                {
                    if (macv.ToString() == "QL")
                    {
                        MessageBox.Show("Bạn không thể chỉnh sửa hợp đồng của quản lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (XacNhanCapNhat())
                    {
                        CapNhatHopDong();
                    }
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
            if (dgNhanVien.RowCount <= 0) return;
            if (e == null) return;
            if (e.RowIndex >= 0)
                vtTim = e;
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dk = txtTim.Text;
                LayNguon();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (!btnCapNhat.Enabled) return;
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
                txtTenNV.Text = selectedRow.Cells[1].Value?.ToString();
                macv = selectedRow.Cells[2].Value?.ToString().Trim();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "") return;
            ktThem = false;
            macu = txtMaHD.Text;
            KhoaMo(false);
            txtMaHD.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Public.maCV == "CQ")
            {
                xoahd();
            }
            else
            {
                if (macv != "QL") xoahd();
                else
                {
                    MessageBox.Show("Bạn không đủ quyền hạn để xoá hợp đồng quản lý!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private void xoahd()
        {
            if (txtMaHD.Text == "") return;
            macu = txtMaHD.Text;
            if (MessageBox.Show("Bạn có muốn xóa hợp đồng đang chọn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Public.sql = "Delete From HopDong Where MaHD=@MaHD";
                SqlParameter[] parameters = { new SqlParameter("@MaHD", macu) };
                if (Public.ThucHienSQL(Public.sql, parameters))
                {
                    MessageBox.Show("Bạn thực hiện xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaTrang();
                    LayNguon();
                    LayNguonNhanVien();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
