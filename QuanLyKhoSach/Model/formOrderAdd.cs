using CrystalDecisions.CrystalReports.Engine;
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

namespace QuanLyKhoSach.Model
{
    public partial class formOrderAdd : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        private List<Guna.UI2.WinForms.Guna2CustomCheckBox> statusCheckboxes;

        public int? OrderId { get; set; }
        public formOrderAdd()
        {
            InitializeComponent();
            statusCheckboxes = new List<Guna.UI2.WinForms.Guna2CustomCheckBox>
{
    choduyet, daduyet, danggiao, dagiao, dahuy, trahang
};

            // Gán sự kiện chung cho tất cả
            foreach (var cb in statusCheckboxes)
            {
                cb.CheckedChanged += StatusCheckbox_CheckedChanged;
            }

        }
        private void formOrderAdd_Load(object sender, EventArgs e)
        {
            guna2DateTimeCreate.Value = DateTime.Now;
            guna2DateTimeRecive.Value = DateTime.Now;


            if (OrderId != null)
            {
                var order = context.Orders.Include("OrderItems").Include("OrderItems.Books").FirstOrDefault(o => o.OrderId == OrderId);
                if (order != null)
                {
                    // Gán các textbox và date
                    txtOderID.Text = order.OrderId.ToString();
                    txtCustomerName.Text = order.CustomerName;
                    txtPhone.Text = order.Phone;
                    txtAddress.Text = order.Address;
                    txtPayment.Text = order.PaymentMethods?.MethodName ?? "";

                    if (order.OrderDate.HasValue)
                    {
                        guna2DateTimeCreate.Value = order.OrderDate.Value;
                    }
                    if (order.ReceiveDate.HasValue)
                    {
                        guna2DateTimeRecive.Value = order.ReceiveDate.Value;
                    }

                    // Gán trạng thái
                    string status = order.OrderStatuses?.StatusName ?? "";
                    choduyet.Checked = status == "Chờ duyệt";
                    daduyet.Checked = status == "Đã duyệt";
                    danggiao.Checked = status == "Đang giao";
                    dagiao.Checked = status == "Đã giao";
                    trahang.Checked = status == "Trả hàng";
                    dahuy.Checked = status == "Đã hủy";

                    // Load chi tiết đơn hàng
                    int sr = 1;
                    foreach (var item in order.OrderItems)
                    {
                        string title = item.Books?.Title ?? "";
                        decimal price = item.BookPrice ?? 0;
                        int quantity = item.BookQuantity ?? 0;
                        decimal total = price * quantity;

                        int idx = dgvOrderDetail.Rows.Add(sr++, title, quantity, price.ToString("N0"), total.ToString("N0"));
                        dgvOrderDetail.Rows[idx].Tag = item.OrderItem_Id;
                    }
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOderID.Text))
            {
                MessageBox.Show("Không tìm thấy mã đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int orderId = int.Parse(txtOderID.Text);
                var order = context.Orders.Find(orderId);
                if (order == null)
                {
                    MessageBox.Show("Đơn hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gán trạng thái dựa vào checkbox
                if (choduyet.Checked)
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Chờ duyệt")?.StatusId;
                else if (daduyet.Checked)
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Đã duyệt")?.StatusId;
                else if (danggiao.Checked)
                {
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Đang giao")?.StatusId;
                    // ⚠ Kiểm tra nếu đơn này chưa từng xuất kho trước đó
                    bool hasExported = context.InventoryExport.Any(o => o.OrderId == order.OrderId);
                    if (!hasExported)
                    {
                        // 1. Tạo phiếu xuất
                        var export = new InventoryExport
                        {
                            OrderId = order.OrderId,
                            UserId = formMain.CurrentUserId, // bạn đã có biến CurrentUserId rồi
                            Export_Date = DateTime.Now
                        };
                        context.InventoryExport.Add(export);
                        context.SaveChanges(); // để lấy Iep_Id

                        // 2. Lặp qua các món trong đơn hàng và tạo InventoryDetail kiểu Export
                        var orderItems = context.OrderItems.Where(oi => oi.OrderId == order.OrderId).ToList();
                        foreach (var item in orderItems)
                        {
                            var detail = new InventoryDetail
                            {
                                Iep_Id = export.Iep_Id,
                                BookId = item.BookId ?? 0,
                                Quantity = item.BookQuantity ?? 0,
                                Type = "Export"
                            };
                            context.InventoryDetail.Add(detail);
                        }

                        context.SaveChanges(); // Lưu luôn detail
                        MessageBox.Show("Đơn hàng đang giao – hệ thống đã tự động xuất kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (dagiao.Checked)
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Đã giao")?.StatusId;
                else if (trahang.Checked)
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Trả hàng")?.StatusId;
                else if (dahuy.Checked)
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Đã hủy")?.StatusId;
                else
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Cập nhật lại thông tin liên hệ nếu có sửa
                order.CustomerName = txtCustomerName.Text.Trim();
                order.Phone = txtPhone.Text.Trim();
                order.Address = txtAddress.Text.Trim();
                context.SaveChanges();
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StatusCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var selected = sender as Guna.UI2.WinForms.Guna2CustomCheckBox;
            if (selected.Checked)
            {
                foreach (var cb in statusCheckboxes)
                {
                    if (cb != selected)
                        cb.Checked = false;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 1. Phải có OrderId hợp lệ
            if (!int.TryParse(txtOderID.Text, out int orderId))
            {
                MessageBox.Show("Chưa có mã đơn hoặc mã không hợp lệ để in hóa đơn!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Khởi tạo report (ReportInvoice là .rpt bạn thiết kế để in hoá đơn)
            var dt = GetInvoiceData(orderId);        // DataTable từ code
            var cr = new ReportReceipt();
            cr.SetDataSource(dt);                    // Push DataTable vào
            using (var frm = new formPrint())
            {
                frm.crystalReportViewer1.ReportSource = cr;
                frm.crystalReportViewer1.Refresh();
                frm.ShowDialog();
            }
        }
        private DataTable GetInvoiceData(int orderId)
        {
            var dt = new DataTable();
            dt.Columns.Add("OrderId", typeof(int));
            dt.Columns.Add("OrderDate", typeof(DateTime));
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("PaymentMethod", typeof(string));
            dt.Columns.Add("BookTitle", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("LineTotal", typeof(decimal));

            // Lấy đơn hàng kèm items
            var order = context.Orders
                .Include("PaymentMethods")
                .Include("OrderItems")
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
                return dt;

            foreach (var item in order.OrderItems)
            {
                var book = context.Books.Find(item.BookId);
                string title = book?.Title ?? "(Không tìm thấy)";
                int qty = item.BookQuantity ?? 0;
                decimal price = item.BookPrice ?? 0m;

                dt.Rows.Add(
                    order.OrderId,
                    order.OrderDate ?? DateTime.MinValue,
                    order.CustomerName,
                    order.Phone,
                    order.Address,
                    order.PaymentMethods?.MethodName ?? "",
                    title,
                    qty,
                    price,
                    qty * price
                );
            }

            return dt;
        }

    }
}
