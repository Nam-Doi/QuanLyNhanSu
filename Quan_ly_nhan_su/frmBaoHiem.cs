using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class frmBaoHiem : Form
    {
        bool ktThem;
        String macu, dk=""; 
        DataGridViewCellMouseEventArgs vt, vtTim;
        public frmBaoHiem()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBaoHiem_Load(object sender, EventArgs e)
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
            txtSoBH.Enabled = !b;
            cboLoaiBH.Enabled = !b;
            dtpNgayCap.Enabled = !b;
            txtThoiHan.Enabled = !b;

        }
        void LayNguon()
        {
            if(Public.maCV=="CQ") Public.sql = "SELECT nhanVien.maNV, nhanVien.tenNV, BaoHiem.MaBH, LoaiBH.TenBH, BaoHiem.ThoiHan, convert(nvarchar(10),BaoHiem.NgayCap,103) NgayCap, LoaiBH.MaLBH " + "FROM BaoHiem JOIN LoaiBH ON BaoHiem.MaLBH = LoaiBH.MaLBH JOIN nhanVien ON BaoHiem.maNV = nhanVien.maNV ";
            else Public.sql = "SELECT nhanVien.maNV, nhanVien.tenNV, BaoHiem.MaBH, LoaiBH.TenBH, BaoHiem.ThoiHan, convert(nvarchar(10),BaoHiem.NgayCap,103) NgayCap, LoaiBH.MaLBH " + "FROM BaoHiem JOIN LoaiBH ON BaoHiem.MaLBH = LoaiBH.MaLBH JOIN nhanVien ON BaoHiem.maNV = nhanVien.maNV and nhanVien.maCN = '"+Public.maCN+"'";
            if (dk != "")
                Public.sql = Public.sql + " Where MaBH Like '%" + dk + "%' or nhanVien.maNV Like '%" + dk + "%'";
            Public.sql = Public.sql + " Order By MaBH ";
            Public.GanNguonDataGridView(dgDanhSach, Public.sql);
            Public.LayNguonDataGridView(dgDanhSach, Public.sql);
        }
        void LayNguonNhanVien()
        {
            if (Public.maCV == "CQ")
            {
                Public.sql = "SELECT nhanVien.maNV, nhanVien.tenNV " +
               "From nhanVien LEFT JOIN BaoHiem ON nhanVien.maNV = BaoHiem.maNV WHERE BaoHiem.maNV IS NULL ";
            }
            else
            {
                Public.sql = "SELECT nhanVien.maNV, nhanVien.tenNV " +
               "From nhanVien LEFT JOIN BaoHiem ON nhanVien.maNV = BaoHiem.maNV WHERE BaoHiem.maNV IS NULL and nhanVien.maCN = '"+Public.maCN+"'";
            }
            Public.LayNguonDataGridView(dgNhanVien, Public.sql);
        }
        void LayNguonCombo()
        {
            Public.GanNguonComboBox(cboLoaiBH, "TenBH", "MaLBH", "Select MaLBH, TenBH From LoaiBH");
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
                    txtHoTen.Text = row.Cells[1].Value.ToString();
                    txtSoBH.Text = row.Cells[2].Value.ToString();
                    txtThoiHan.Text = row.Cells[4].Value.ToString();
                    chkNgayCap.Checked = false; dtpNgayCap.Value = DateTime.Now;
                    if (row.Cells[5].Value != null)
                    {
                        if (row.Cells[5].Value.ToString() != "")
                        {
                            chkNgayCap.Checked = true;
                            dtpNgayCap.Value = DateTime.ParseExact(row.Cells[5].Value.ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    
                    macu = txtSoBH.Text;
                    cboLoaiBH.SelectedValue = row.Cells[6].Value.ToString();

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
            chkNgayCap.Checked = true;
            dtpNgayCap.Value = DateTime.Now;
            XoaTrang();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Focus();
                    return;
                }
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập họ tên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }
                if (txtSoBH.Text == "")
                {
                    MessageBox.Show("Ban chua nhap số bảo hiểm","Thong bao",MessageBoxButtons.
                        OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboLoaiBH.SelectedValue == null)
                {
                    MessageBox.Show("Bạn chưa chọn loại bảo hiểm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtThoiHan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thời hạn bảo hiểm","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ;
                }
                if (Public.ktTrungMa("MaBH", "BaoHiem", ktThem, txtSoBH.Text, macu) == true)
                {
                    MessageBox.Show("Bạn nhập mã bảo hiểm trùng với mã đào tạo đã tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoBH.Focus();
                    return;
                }
                if ((MessageBox.Show("Bạn có muốn cập bảo hiểm của nhân viên không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (ktThem == true)
                        Public.sql = "Insert Into BaoHiem(MaBH, NgayCap, maNV, MaLBH, ThoiHan) Values(@ma, @nc, @nv, @lbh, @th)";
                    else
                        Public.sql = "Update BaoHiem Set MaBH=@ma, NgayCap=@nc, maNV=@nv, ThoiHan=@th, MaLBH=@lbh Where MaBH=@macu";

                    SqlConnection conn = Public.KetNoi();
                    SqlCommand cmd = new SqlCommand(Public.sql, conn);
                    cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtSoBH.Text;
                    cmd.Parameters.Add("@nv", SqlDbType.NChar).Value = txtMaNV.Text;
                    cmd.Parameters.Add("@th", SqlDbType.NVarChar).Value = txtThoiHan.Text;
                    if (chkNgayCap.Checked == true)
                        cmd.Parameters.Add("@nc", SqlDbType.Date).Value = dtpNgayCap.Value;
                    else
                        cmd.Parameters.Add("@nc", SqlDbType.Date).Value = DBNull.Value;
                    
                    //thay the th hoac loai bh
                    cmd.Parameters.Add("@lbh", SqlDbType.NVarChar).Value =cboLoaiBH.SelectedValue;
                    if (ktThem == false) cmd.Parameters.Add("@macu", SqlDbType.NVarChar).Value = macu;

                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn cập nhật bảo hiểm thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    XoaTrang();
                    KhoaMo(true);
                    LayNguon();
                    try
                    {
                        dgDanhSach_CellMouseClick(sender, vt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThoiHan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoBH.Text == "") return;
            ktThem = false;
            macu = txtSoBH.Text;
            KhoaMo(false);
            txtSoBH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSoBH.Text == "") return;
            macu = txtSoBH.Text;
            if (MessageBox.Show("Bạn có muốn xoá bảo hiểm đang chọn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Public.sql = "Delete From BaoHiem Where MaBH=@MaBH";
                    SqlParameter[] parameters = { new SqlParameter("@MaBH", macu) };
                    if (Public.ThucHienSQL(Public.sql, parameters))
                    {
                        MessageBox.Show("Bạn thực hiện xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrang();
                        LayNguon();
                        LayNguonNhanVien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá không thành công lỗi: "+ex.Message,"Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                txtHoTen.Text = selectedRow.Cells[1].Value?.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgNhanVien.RowCount<=0) return;
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

        private void dtpNgayCap_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void XoaTrang()
        {
            txtMaNV.Text = "";txtSoBH.Text = "";
            txtHoTen.Text = "";
            txtThoiHan.Text = "";

        }
    }
}
