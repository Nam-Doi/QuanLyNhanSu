using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Quan_ly_nhan_su;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_su
{
    public partial class trangChu : Form
    {
        public trangChu()
        {
            InitializeComponent();
        }
        bool dangxuat = false;
        private void tuyểnDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tuyenDung q = new tuyenDung(this);
            q.Show();
        }

        private void trangChu_Load(object sender, EventArgs e)
        {
            loadtrangchu();
        }
        public void loadtrangchu()
        {
            Public.chucvu();
            Public.conn = new SqlConnection(Public.connString);
            cbb();
            doc();
            girdview(@"
SELECT 
    N'Chưa có chi nhánh' AS tenCN,
    COALESCE(SUM(maNV), 0) AS maNV,
    COALESCE(SUM(id), 0) AS id,
    COALESCE(SUM(trangthaithem), 0) AS trangthaithem,
    COALESCE(SUM(trangthaixoa), 0) AS trangthaixoa
FROM (
    SELECT 
        COUNT(DISTINCT nv.maNV) AS maNV,
        0 AS id, 
        0 AS trangthaithem, 
        0 AS trangthaixoa
    FROM nhanVien nv
    LEFT JOIN ChiNhanh cn ON nv.maCN = cn.maCN
    WHERE cn.tenCN IS NULL and nv.maCV != 'CQ'

    UNION ALL

    SELECT 
        0 AS maNV,
        COUNT(DISTINCT td.id) AS id, 
        0 AS trangthaithem, 
        0 AS trangthaixoa
    FROM tuyenDung td
    LEFT JOIN ChiNhanh cn ON td.maCN = cn.maCN
    WHERE cn.tenCN IS NULL

    UNION ALL

    SELECT 
        0 AS maNV,
        0 AS id,
        SUM(CASE WHEN ls.trangthai = '1' THEN 1 ELSE 0 END) AS trangthaithem,
        SUM(CASE WHEN ls.trangthai = '0' THEN 1 ELSE 0 END) AS trangthaixoa
    FROM lsNhanVien ls 
    LEFT JOIN ChiNhanh cn ON ls.maCN = cn.maCN
    WHERE cn.tenCN IS NULL
) AS temp

UNION ALL

SELECT 
    COALESCE(temp.tenCN, N'Chưa có chi nhánh') AS tenCN,
    COALESCE(SUM(temp.maNV), 0) AS maNV, 
    COALESCE(SUM(temp.id), 0) AS id, 
    COALESCE(SUM(temp.trangthaithem), 0) AS trangthaithem,
    COALESCE(SUM(temp.trangthaixoa), 0) AS trangthaixoa
FROM (
    SELECT 
        cn.tenCN,
        COUNT(DISTINCT nv.maNV) AS maNV,
        0 AS id,
        0 AS trangthaithem,
        0 AS trangthaixoa
    FROM nhanVien nv
    JOIN ChiNhanh cn ON nv.maCN = cn.maCN
    where nv.maCV != 'CQ'
    GROUP BY cn.tenCN

    UNION ALL

    SELECT 
        cn.tenCN,
        0 AS maNV,
        COUNT(DISTINCT td.id) AS id,
        0 AS trangthaithem,
        0 AS trangthaixoa
    FROM tuyenDung td
    JOIN ChiNhanh cn ON td.maCN = cn.maCN
    GROUP BY cn.tenCN

    UNION ALL

    SELECT 
        cn.tenCN,
        0 AS maNV,
        0 AS id,
        SUM(CASE WHEN ls.trangthai = '1' THEN 1 ELSE 0 END) AS trangthaithem,
        SUM(CASE WHEN ls.trangthai = '0' THEN 1 ELSE 0 END) AS trangthaixoa
    FROM lsNhanVien ls 
    JOIN ChiNhanh cn ON ls.maCN = cn.maCN
    GROUP BY cn.tenCN
) AS temp
GROUP BY temp.tenCN

UNION ALL

SELECT 
    N'Tổng' AS tenCN,
    COALESCE(SUM(maNV), 0) AS maNV, 
    COALESCE(SUM(id), 0) AS id, 
    COALESCE(SUM(trangthaithem), 0) AS trangthaithem,
    COALESCE(SUM(trangthaixoa), 0) AS trangthaixoa
FROM (
    SELECT 
        COUNT(DISTINCT nv.maNV) AS maNV,
        0 AS id,
        0 AS trangthaithem,
        0 AS trangthaixoa
    FROM nhanVien nv
    where nv.maCV != 'CQ'

    UNION ALL

    SELECT 
        0 AS maNV,
        COUNT(DISTINCT td.id) AS id,
        0 AS trangthaithem,
        0 AS trangthaixoa
    FROM tuyenDung td
    UNION ALL

    SELECT 
        0 AS maNV,
        0 AS id,
        SUM(CASE WHEN ls.trangthai = '1' THEN 1 ELSE 0 END) AS trangthaithem,
        SUM(CASE WHEN ls.trangthai = '0' THEN 1 ELSE 0 END) AS trangthaixoa
    FROM lsNhanVien ls
) AS temp;
", tong);
            if (Public.maCV != "CQ")
            {
                locdonvi.Enabled = false;
                locdonvi.SelectedValue = Public.maCN;
                reset.Enabled = false;
                quảnLýĐịaĐiểmLàmViệcNhânViênToolStripMenuItem.Visible = false;
                chiNhánhToolStripMenuItem.Visible = false;
                if (Public.maCV != "QL")
                {
                    quảnLýHợpĐồngToolStripMenuItem.Visible = false;
                    quảnLýBảoHiểmToolStripMenuItem.Visible = false;
                    báoCáoVàThốngKêToolStripMenuItem.Visible = false;
                    lươngToolStripMenuItem.Visible = false;

                }
            }
        }
        private void quảnLýTuyểnDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanVien nhanVien = new nhanVien(this);
            nhanVien.Show();
        }

        private void quảnLýĐịaĐiểmLàmViệcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            congTac congTac = new congTac();
            congTac.Show();
        }

        private void quảnLýChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiNhanh frmChiNhanh = new frmChiNhanh();
            frmChiNhanh.Show(); 
        }

        private void quảnLýBảoHiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHiem frmBaoHiem = new frmBaoHiem();  
            frmBaoHiem.Show();
        }

        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDong frmHopDong = new frmHopDong();   
            frmHopDong.Show();
        }

        private void quảnLýĐàoTạoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDaoTao frmDaoTao = new frmDaoTao();  
            frmDaoTao.Show();
        }

        private void báoCáoVàThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoVaThongKe baoCaoVaThongKe = new BaoCaoVaThongKe();
            baoCaoVaThongKe.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdangnhap frmdangnhap = new frmdangnhap();
            dangxuat = true;
            this.Close();
            frmdangnhap.Show();
        }

        private void trangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dangxuat ==  false)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Environment.Exit(0);
                }
                else e.Cancel = true;
            }
        }

        private void hệSốLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbochucvu cbochucvu = new cbochucvu();
            cbochucvu.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmquanly frmquanly = new frmquanly();
            frmquanly.Show();
        }
        private void girdview(string strsql, DataGridView d)
        {
            try
            {
                var cmd = new SqlCommand(strsql, Public.conn);
                cmd.Parameters.AddWithValue("@maCN", locdonvi.SelectedValue.ToString().Trim());
                var table = new DataTable();
                var sql = new SqlDataAdapter(cmd);
                sql.Fill(table);
                d.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu đơn vị không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cbb()
        {
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
                ta.Rows[1]["tenCN"] = "Không có đơn vị";
                locdonvi.DisplayMember = "tenCN";
                locdonvi.ValueMember = "maCN";
                locdonvi.DataSource = ta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu đơn vị không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void xoa(string strcmd,object sender,EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá tất cả dữ liệu về lịch sử nhân viên?","Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    Public.conn.Open();
                    var cmd = new SqlCommand(strcmd, Public.conn);
                    cmd.ExecuteNonQuery();
                    Public.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tải dữ liệu đơn vị không thành công lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                trangChu_Load(sender, e);
            }
        }
        private void doc()
        {
            try
            {
                Public.conn.Open();
                var cmd = new SqlCommand(@"select top 1 ngay from lsNhanVien", Public.conn);
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    ngayb.Value = r.GetDateTime(r.GetOrdinal("ngay"));
                }
                r.Close();
                Public.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu đơn vị không thành công lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void locdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strsql = @"select nxt,nbxt,cn.tenCN,convert(nvarchar(10),ngay,103) ngay from lsNhanVien ls left join chiNhanh cn on ls.maCN = cn.maCN ";
            if ((string)locdonvi.SelectedValue == "*")
            {
                girdview(strsql + @"where trangthai='1'", nvthem);
                girdview(strsql + @"where trangthai='0'", nvxoa);
            }
            else if ((string)locdonvi.SelectedValue == "NULL")
            {
                girdview(strsql + @"where trangthai='1' and cn.tenCN is null", nvthem);
                girdview(strsql + @"where trangthai='0' and cn.tenCN is null", nvxoa);
            }
            else
            {
                girdview(strsql + @"where trangthai='1' and ls.maCN = @maCN", nvthem);
                girdview(strsql + @"where trangthai='0' and ls.maCN = @maCN", nvxoa);
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            xoa("delete from lsNhanVien",sender,e);
            loadtrangchu();
        }

        private void quảnLýCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlycong qlycong = new qlycong();
            qlycong.Show();
        }
    }
}
