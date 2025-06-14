using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QuanLyKhoSach.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach.SubReport
{
    public partial class RpOrder : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        public RpOrder()
        {
            InitializeComponent();
            guna2DateTimePicker1.Value = DateTime.Today;
            guna2DateTimePicker2.Value = DateTime.Today;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Lấy ngày từ và đến (chỉ lấy phần Date để tránh phần giờ)
            DateTime fromDate = guna2DateTimePicker1.Value.Date;
            DateTime toDate = guna2DateTimePicker2.Value.Date;

            // 1. Lấy dữ liệu đơn hàng theo khoảng ngày
            var dt = GetOrderReportData(fromDate, toDate);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không có dữ liệu đơn hàng trong khoảng thời gian này!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // 2. Tạo report và gán DataTable vào
            ReportOrder cr = new ReportOrder(); // ← file .rpt bạn đã chuẩn bị (tên ReportOrder.rpt)
            cr.SetDataSource(dt);

            // Cứ quét từng section, tìm TextObject tên txtDateRange rồi gán
            foreach (Section section in cr.ReportDefinition.Sections)
            {
                foreach (ReportObject obj in section.ReportObjects)
                {
                    if (obj.Kind == ReportObjectKind.TextObject && obj.Name == "txtDateRange")
                    {
                        ((TextObject)obj).Text = $"Các đơn hàng từ ngày {fromDate:dd/MM/yyyy} đến ngày {toDate:dd/MM/yyyy}";
                    }
                }
            }
            // 3. Show lên form in (formPrint chứa CrystalReportViewer)
            formPrint frm = new formPrint();
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.ShowDialog();
        }


        private DataTable GetOrderReportData(DateTime fromDate, DateTime toDate)
        {
            // Chuẩn bị DataTable
            var dt = new DataTable();
            dt.Columns.Add("OrderId", typeof(int));
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("PaymentMethod", typeof(string));
            dt.Columns.Add("StatusName", typeof(string));
            dt.Columns.Add("OrderDate", typeof(DateTime));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("TotalPrice", typeof(decimal));

            DateTime toDateExclusive = toDate.AddDays(1);

            // Lấy danh sách đơn hàng TRỪ các đơn đã hủy và trả hàng
            var orderList = context.Orders
                .Where(o => o.OrderDate >= fromDate && o.OrderDate < toDateExclusive
                         && o.OrderStatuses.StatusName != "Đã hủy"
                         && o.OrderStatuses.StatusName != "Trả hàng")
                .Select(o => new
                {
                    o.OrderId,
                    o.CustomerName,
                    PaymentMethod = o.PaymentMethods.MethodName,
                    StatusName = o.OrderStatuses.StatusName,
                    o.OrderDate,
                    o.Phone,
                    o.TotalPrice
                })
                .ToList();

            foreach (var item in orderList)
            {
                dt.Rows.Add(
                    item.OrderId,
                    item.CustomerName,
                    item.PaymentMethod,
                    item.StatusName,
                    item.OrderDate,
                    item.Phone,
                    item.TotalPrice
                );
            }

            return dt;
        }
    }
}
