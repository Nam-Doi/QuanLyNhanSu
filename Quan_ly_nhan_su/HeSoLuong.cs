using DocumentFormat.OpenXml.Drawing;
using Quan_ly_nhan_su;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class cbochucvu : Form
    {
        SqlConnection conn;
        SqlDataAdapter daNV,daHSL;
        DataTable dtNV,dtHSL;
        String sql;
        String maCV = "";
        String maNV = "";
        bool ktDangXuat = false;
        bool ktThem;
        string macu;
        DataGridViewCellMouseEventArgs vt;
        public cbochucvu()
        {
            InitializeComponent();
        }
        void LayNguon()
        {
            if (maNV == "") return;
            sql = "Select maNV,maHSL,HeSoLuong,bienDongLuong,convert(nvarchar(10),ngayBienDong,103) ngayBienDong FROM HeSoLuong where maNV = N'" + maNV + "' ";
            if (Public.maCV != "CQ") sql += "and maCN = '" + Public.maCN + "'";
            daHSL = new SqlDataAdapter(sql, conn);
            dtHSL = new DataTable();
            daHSL.Fill(dtHSL);

            dgDanhSach.DataSource = dtHSL;
        }

        void CustomizeDataGridViewa()
        {
            dgNV.AutoGenerateColumns = false;
            dgNV.Columns.Clear();

            DataGridViewTextBoxColumn maNVColumn = new DataGridViewTextBoxColumn();
            maNVColumn.DataPropertyName = "maNV"; maNVColumn.HeaderText = "Mã nhân viên ";
            maNVColumn.Width = 100;
            dgNV.Columns.Add(maNVColumn);

            DataGridViewTextBoxColumn tenNVColumn = new DataGridViewTextBoxColumn();
            tenNVColumn.DataPropertyName = "tenNV"; tenNVColumn.HeaderText = "Tên tên nhân viên ";
            tenNVColumn.Width = 150;
            dgNV.Columns.Add(tenNVColumn);

            DataGridViewTextBoxColumn gioiTinhColumn = new DataGridViewTextBoxColumn();
            gioiTinhColumn.DataPropertyName = "gioiTinh";
            gioiTinhColumn.HeaderText = "Giới Tính";
            gioiTinhColumn.Width = 80;
            dgNV.Columns.Add(gioiTinhColumn);

            DataGridViewTextBoxColumn maCNColumn = new DataGridViewTextBoxColumn();
            maCNColumn.DataPropertyName = "maCN";
            maCNColumn.HeaderText = "Mã chi nhánh ";
            maCNColumn.Width = 100;
            dgNV.Columns.Add(maCNColumn);
            DataGridViewTextBoxColumn queColumn = new DataGridViewTextBoxColumn();
            queColumn.DataPropertyName = "que";
            queColumn.HeaderText = "Quê";
            queColumn.Width = 150;
            dgNV.Columns.Add(queColumn);


        }
        

        private void frmLuong_Load(object sender, EventArgs e)
        {
            conn = Public.KetNoi();
            khoa(false);
            KhoaMo(true);
            LayNguonCV();           
            CustomizeDataGridViewa();         

            maCV = "";
            LayNguonNV();

            LayNguon();
        }
        void LayNguonCV()
        {
            DataTable dt = Public.LayNguon("Select * From ChucVu where maCV != 'CQ'");
            dgNV.DataSource = dt;
            cbomaCV.DataSource = dt;
            cbomaCV.DisplayMember = "tenCV";
            cbomaCV.ValueMember = "maCV";

        }
       
        void LayNguonNV()
        {
            if (maCV == "")
            {
                string strsql = "Select maNV, tenNV, gioiTinh, maCN, que,maCV From nhanVien ";
                if (Public.maCV != "CQ") strsql += "where maCN = '" + Public.maCN + "'";
                Public.LayNguonDataGridView(dgNV, strsql);
            }
            else
            {
                sql = "Select  maNV, tenNV, gioiTinh, maCN, que, maCV From nhanVien where maCV = N'" + maCV + "' ";
                if (Public.maCV != "CQ") sql += "and maCN = '" + Public.maCN + "'";
                daNV = new SqlDataAdapter(sql, conn);
                dtNV = new DataTable();
                daNV.Fill(dtNV);

                dgNV.DataSource = dtNV;
            }
        }
        void khoa(bool c)
        {
            txtmaNV.Enabled = c;txttenNV.Enabled = c;

        }
        void KhoaMo(bool b)
        {
            dgDanhSach.Enabled = b; dgNV.Enabled = b;
            cbomaCV.Enabled = b;
            txtNBD.Enabled = !b; txtBDL.ReadOnly = b;
            txtMaHSL.ReadOnly = b; txtHSL.ReadOnly = b;
            cmdThem.Enabled = b; cmdXoa.Enabled = b;
            cmdGhi.Enabled = !b; cmdKetThuc.Enabled = !b; cmdtb.Enabled = b;
        }

        private void frmLuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ktDangXuat == false)
            {
                if (MessageBox.Show("Bạn có muốn kết thúc không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            }
        }
        private void frmLuong_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ktDangXuat == false) this.Close();
        }
        void XoaTrang()
        {
            txtMaHSL.Text = "";
            txtHSL.Text = "";
            txtBDL.Text = "";
            txtNBD.Text = "";
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (txtmaNV.Text == "" )
            {
                MessageBox.Show("Bạn chưa chọn nhân viên .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHSL.Focus();
                return;
            }
            ktThem = true;
            KhoaMo(false);
            XoaTrang();
            txtMaHSL.Focus();
        }



        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (dgDanhSach.RowCount > 0 && dgDanhSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgDanhSach.SelectedRows[0];
                string maHSL = row.Cells[1].Value.ToString();
                if (MessageBox.Show("Bạn có muốn xóa hệ số lương  đang chọn không  ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Public.sql = "DELETE FROM HeSoLuong WHERE maHSL = @maHSL";
                    SqlParameter[] parameters = { new SqlParameter("@maHSL", maHSL) };
                    if (Public.ThucHienSQL(Public.sql, parameters))
                    {
                        MessageBox.Show("Bạn thực hiện xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrang();
                        LayNguon();
                    }
                }
            }
        }
       


        private void cmdGhi_Click(object sender, EventArgs e)
        {

            
            if (txtMaHSL.Text == "" || txtHSL.Text == "" || txtBDL.Text == "" || txtNBD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHSL.Focus();
                return;
            }

            if (Public.ktTrungMa("maHSL", "HeSoLuong", ktThem, txtMaHSL.Text, macu))
            {
                MessageBox.Show("Bạn nhập mã hệ số lương  đã tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHSL.Focus(); return;
            }
            if (MessageBox.Show("Bạn có muốn cập nhật hệ số lương  không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlParameter[] parameters;
                DateTime dateValue;
                if (!DateTime.TryParseExact(txtNBD.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
                { 
                    MessageBox.Show("Chuỗi ngày không hợp lệ, hãy kiểm tra lại định dạng ngày (dd/MM/yyyy).", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ktThem)
                {
                    Public.sql = "INSERT INTO HeSoLuong  ( maNV, maHSL, HeSoLuong, bienDongLuong, ngayBienDong ) VALUES ( @maNV, @maHSL, @HeSoLuong, @bienDongLuong, @ngayBienDong )";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@maNV", txtmaNV.Text),
                        new SqlParameter("@maHSL", txtMaHSL.Text),
                        new SqlParameter("@HeSoLuong", txtHSL.Text),
                        new SqlParameter("@bienDongLuong", txtBDL.Text),
                        new SqlParameter("@ngayBienDong", dateValue)

                    };
                }
                else
                {
                    Public.sql = "UPDATE HeSoLuong  SET maNV=@maNV, maHSL = @maHSL, HeSoLuong = @HeSoLuong, bienDongLuong = @bienDongLuong, ngayBienDong = @ngayBienDong WHERE maHSL = @maHSL";
                    parameters = new SqlParameter[]
                    {
                      new SqlParameter("@maNV", txtmaNV.Text),
                      new SqlParameter("@maHSL", txtMaHSL.Text),
                      new SqlParameter("@HeSoLuong", txtHSL.Text),
                      new SqlParameter("@bienDongLuong", txtBDL.Text),
                      new SqlParameter("@ngayBienDong", dateValue),
                      new SqlParameter("@OldmaHSL", macu)
                    };
                }
                if (Public.ThucHienSQL(Public.sql, parameters))
                {
                    MessageBox.Show(" cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaTrang();
                    KhoaMo(true);
                    LayNguon();
                    try
                    {
                        dgDanhSach_CellMouseClick(sender, vt);
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            try
            {
                XoaTrang();
                KhoaMo(true);
                dgDanhSach_CellMouseClick(sender, vt);
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }

       

        private void cbomaCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maCV = cbomaCV.SelectedValue.ToString();
                LayNguonNV();
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }

        private void cmdtb_Click(object sender, EventArgs e)
        {
            maCV = "";
            LayNguonNV();
        }
        private void dgNV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            maNV = "";
            try
            {
                if (dgNV.RowCount > 0)
                {

                    if (e == null) return;
                    DataGridViewRow row = dgNV.Rows[e.RowIndex];

                    if (row.Cells.Count >= 0)
                    {
                        txtmaNV.Text = row.Cells[0].Value.ToString();
                        txttenNV.Text = row.Cells[1].Value.ToString();
                        maNV = txtmaNV.Text;
                        LayNguon();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

        }

       

        private void txtmaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNBD_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (dgDanhSach.RowCount > 0)
                {
                    vt = e;
                    if (e == null) return;
                    DataGridViewRow row = dgDanhSach.Rows[e.RowIndex];

                    if (row.Cells.Count >= 0)
                    {
                        txtMaHSL.Text = row.Cells[1].Value.ToString();
                        txtHSL.Text = row.Cells[2].Value.ToString();
                        txtBDL.Text = row.Cells[3].Value.ToString();
                        DateTime ngayBienDong; 
                        if (DateTime.TryParse(row.Cells[4].Value.ToString(), out ngayBienDong)) 
                        { 
                            txtNBD.Text = ngayBienDong.ToString("dd/MM/yyyy"); 
                        }
                        else 
                        { 
                            MessageBox.Show("Định dạng ngày bị lỗi.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        }

                        macu = txtMaHSL.Text;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); 
            }
        }
           

        
        

        private void dgNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}

