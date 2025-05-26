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
                    order.StatusId = context.OrderStatuses.FirstOrDefault(s => s.StatusName == "Đang giao")?.StatusId;
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

    }
}
