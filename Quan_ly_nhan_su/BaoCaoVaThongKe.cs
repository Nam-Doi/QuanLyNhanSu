using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace Quan_ly_nhan_su
{
    public partial class BaoCaoVaThongKe : Form
    {
        public BaoCaoVaThongKe()
        {
            InitializeComponent();
        }
       
       
        void LayNguon()
        {
            Public.LayNguonDataGridView(dgDanhSach, "Select   tenNV, tenCV, email, que, NgayBatDau, NgayKetThuc, ThoiHan, tenCN, DiaChi From nhanVien inner join ChiNhanh on ChiNhanh.maCN=nhanVien.maCN inner join ChucVu on nhanVien.maCV=ChucVu.maCV inner join HopDong on nhanVien.maNV=HopDong.maNV inner join BaoHiem on nhanVien.maNV=BaoHiem.maNV");
        }
        
        private void BaoCaoVaThongKe_Load(object sender, EventArgs e)
        {
            LayNguon();
   
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Branches Report"); 
              for (int i = 0; i < dataGridView.Columns.Count; i++)
                { 
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText; 
                }
               for (int i = 0; i < dataGridView.Rows.Count; i++)
                { 
                    for (int j = 0; j < dataGridView.Columns.Count; j++) 
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                    }
                } 
                SaveFileDialog saveFileDialog = new SaveFileDialog 
                { 
                    Filter = "Excel Files|*.xlsx;*.xls", Title = "Save an Excel File" }; 
                if (saveFileDialog.ShowDialog() == DialogResult.OK) 
                { 
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Data exported successfully.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            }
        private void ImportFromExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Files|*.xlsx;*.xls", Title = "Select an Excel File" }; if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName; DataTable dt = new DataTable(); try
                {
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        foreach (IXLRow row in worksheet.Rows())
                        {
                            if (firstRow)
                            { 
                                foreach (IXLCell cell in row.Cells()) 
                                { 
                                    dt.Columns.Add(cell.Value.ToString()); 
                                } firstRow = false; 
                            } 
                            else 
                            { 
                                dt.Rows.Add(); 
                                int i = 0; 
                                foreach (IXLCell cell in row.Cells())
                                { 
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString(); i++;
                                } 
                            } 
                        } 
                        dgDanhSach.DataSource = dt; 
                    } 
                } 
                catch (Exception ex) 
                {
                    MessageBox.Show($"Error reading the Excel file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
                            }
        private void dgDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void cmdExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgDanhSach);
        }

        private void cmdImportFromExcel_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
        }

        private void dgDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
