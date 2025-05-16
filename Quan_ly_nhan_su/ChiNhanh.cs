using Quan_ly_nhan_su;
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
    public partial class frmChiNhanh : Form
    {
      
        bool ktDangXuat = false;
        bool ktThem;
        SqlConnection conn;
        SqlDataAdapter daNV ;
        DataTable  dtNV;
        string macu;
        string maCN="";
        string sql;
        DataGridViewCellMouseEventArgs vt;
        public frmChiNhanh()
        {
            InitializeComponent();
        }
        void LayNguon()
        {
            
                Public.LayNguonDataGridView(dgDanhSach, "Select maCN,tenCN,DiaChi From ChiNhanh ");
             
        }
        
        void CustomizeDataGridView()
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
                void laynguoncboCN()
            {
                DataTable dt = Public.LayNguon("Select * From ChiNhanh");
                dgDanhSach.DataSource = dt;
                cbomaCN.DataSource = dt;
                cbomaCN.DisplayMember = "tenCN";
                cbomaCN.ValueMember = "maCN";
            }
            void LayNguonNV()
            {
                if (maCN == "")
                {
                    Public.LayNguonDataGridView(dgNV, "Select maNV, tenNV, gioiTinh, maCN, que From nhanVien");
                }
                else
                {
                    sql= "Select * From nhanVien where maCN = N'" + maCN + "'";
                    daNV = new SqlDataAdapter(sql, conn);
                    dtNV=new DataTable();
                    daNV.Fill(dtNV);
                    dgNV.DataSource = dtNV;
                }
            }
            void KhoaMo(bool b)
            {
                dgDanhSach.Enabled = b;dgNV.Enabled = b;
                cbomaCN.Enabled = b;
                txttencn.Enabled = !b; txtmacn.Enabled = !b;
                txtDiaDiem.Enabled = !b;
                cmdthemchinhanh.Enabled = b; cmdsuachinhanh.Enabled = b;
            cmdxoachinhanh.Enabled = b; cmdtoanbo.Enabled = b;
            cmdGhi.Enabled = !b; cmdKhong.Enabled = !b;
        }



        private void frmChiNhanh_Load(object sender, EventArgs e)
        {
            conn = Public.KetNoi();
            KhoaMo(true);
            laynguoncboCN();
            LayNguon();
            CustomizeDataGridView();

            maCN = "";
            LayNguonNV();
        }
        private void frmChiNhanh_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (ktDangXuat == false)
            {
                if (MessageBox.Show("Bạn có muốn kết thúc không?", "Thông Báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            }

        }
        void XoaTrang()
        {
            txtmacn.Text = ""; txttencn.Text = "";
            txtDiaDiem.Text = "";
        }
        private void cmdthemchinhanh_Click(object sender, EventArgs e)
        {
            
           
            ktThem = true;
            KhoaMo(false);
            XoaTrang();
            txtmacn.Focus();
        }


        private void cmdsuachinhanh_Click(object sender, EventArgs e)
        {
            if (txtmacn.Text == "") return;
            ktThem = false;
            macu = txtmacn.Text;
            KhoaMo(false);
            txtmacn.Focus();
        }

        private void cmdxoachinhanh_Click(object sender, EventArgs e)
        {
            if (dgDanhSach.RowCount > 0 && dgDanhSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgDanhSach.SelectedRows[0];
                string maCN = row.Cells[0].Value.ToString();
                if (MessageBox.Show("Bạn có muốn xóa chi nhánh đang chọn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Public.sql = "DELETE FROM ChiNhanh WHERE maCN = @maCN";
                    SqlParameter[] parameters = { new SqlParameter("@maCN", maCN) };
                    if (Public.ThucHienSQL(Public.sql, parameters))
                    {
                        MessageBox.Show("Bạn thực hiện xóa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrang();
                        LayNguon();
                    }
                }
            }
            else { MessageBox.Show("Please select a branch to delete.", "Delete Branch", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        

       
        

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtmacn.Text == ""||txttencn.Text == ""||txtDiaDiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin  .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmacn.Focus();
                return;
            }
              
           
            if (Public.ktTrungMa("maCN", "ChiNhanh", ktThem, txtmacn.Text, macu) == true)
            {
                MessageBox.Show("Bạn nhập mã chi nhánh  trùng với mã chi nhánh  đã tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmacn.Focus();
                return;
            }
            if ((MessageBox.Show("Bạn có muốn cập nhật chi nhanh không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                SqlParameter[] parameters; 
                if (ktThem) 
                { 
                    Public.sql = "INSERT INTO ChiNhanh (maCN, tenCN, DiaChi) VALUES (@maCN, @tenCN, @DiaChi)";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@maCN", txtmacn.Text),
                        new SqlParameter("@tenCN", txttencn.Text), 
                        new SqlParameter("@DiaChi", txtDiaDiem.Text)
                     
                    }; 
                } 
                else 
                { 
                    Public.sql = "UPDATE ChiNhanh SET maCN = @maCN, tenCN = @tenCN, DiaChi = @DiaCHi WHERE maCN = @OldmaCN";
                    parameters = new SqlParameter[]
                    { 
                        new SqlParameter("@maCN", txtmacn.Text), 
                        new SqlParameter("@tenCN", txttencn.Text), 
                        new SqlParameter("@DiaChi", txtDiaDiem.Text),                 
                        new SqlParameter("@OldmaCN", macu)
                    }; 
                }
                if (Public.ThucHienSQL(Public.sql, parameters))
                {
                    MessageBox.Show("Bạn cập nhật chi nhánh  thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmdKhong_Click(object sender, EventArgs e)
        {
            try
            {
                XoaTrang();
                KhoaMo(true);
                dgDanhSach_CellMouseClick(sender, vt);
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }

        private void txtMaql_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttencn_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDanhSach.RowCount > 0)
            {
                vt = e;
                if (e == null) return;
                DataGridViewRow row = dgDanhSach.Rows[e.RowIndex];
                
                if (row.Cells.Count >= 0)
                {
                    txtmacn.Text = row.Cells[0].Value.ToString().Trim();
                    txttencn.Text = row.Cells[1].Value.ToString();
                    txtDiaDiem.Text = row.Cells[2].Value.ToString();                 
                }
                else
                {
                    MessageBox.Show("Hàng đã chọn không chứa đủ dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdtoanbo_Click(object sender, EventArgs e)
        {
            maCN = "";
            LayNguonNV();
        }

        private void dgNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbomaCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maCN=cbomaCN.SelectedValue.ToString();
                LayNguonNV() ;
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }

        private void cbomaCN_MouseClick(object sender, MouseEventArgs e)
        {

        }

        

        private void dgNV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgNV_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {

            
        }
    }
}
