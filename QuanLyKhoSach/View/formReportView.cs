using QuanLyKhoSach.Report;
using QuanLyKhoSach.SubReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach.View
{
    public partial class formReportView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        public formReportView()
        {
            InitializeComponent();
        }
        public void AddControls(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu tồn kho
            var dt = GetStockReportData();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu tồn kho để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Tạo report và gán data
            ReportStock cr = new ReportStock(); // file .rpt bạn đã thiết kế
            cr.SetDataSource(dt);

            // 3. Tạo form in và hiển thị
            formPrint frm = new formPrint();
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.ShowDialog();
        }


        private DataTable GetStockReportData()
        {
            var dt = new DataTable();
            dt.Columns.Add("BookId", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("TotalImport", typeof(int));
            dt.Columns.Add("TotalExport", typeof(int));
            dt.Columns.Add("CurrentStock", typeof(int));

            var stockData = context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    TotalImport = context.InventoryDetail
                                         .Where(d => d.BookId == b.BookId && d.Type == "Import")
                                         .Sum(d => (int?)d.Quantity) ?? 0,
                    TotalExport = context.InventoryDetail
                                         .Where(d => d.BookId == b.BookId && d.Type == "Export")
                                         .Sum(d => (int?)d.Quantity) ?? 0
                })
                .ToList();

            foreach (var item in stockData)
            {
                int currentStock = item.TotalImport - item.TotalExport;
                dt.Rows.Add(item.BookId, item.Title, item.TotalImport, item.TotalExport, currentStock);
            }

            return dt;
        }

        private void formReportView_Load(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            AddControls(new RpOrder());
        }
    }

}
