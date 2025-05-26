using QuanLyKhoSach.Model;
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
    public partial class formOrderView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();

        public formOrderView()
        {
            InitializeComponent();
            var statuses = context.OrderStatuses.ToList();
            statuses.Insert(0, new OrderStatuses { StatusId = 0, StatusName = "Tất cả" });

            cbOrderStatus.DataSource = statuses;
            cbOrderStatus.DisplayMember = "StatusName";
            cbOrderStatus.ValueMember = "StatusId";
            cbOrderStatus.SelectedIndex = 0;
        }

        private void formOderView_Load(object sender, EventArgs e)
        {
            LoadOrders();   
        }
        private void LoadOrders(string keyword = "")
        {
            dgvOrder.Rows.Clear();
            dgvOrder.AllowUserToAddRows = false;

            // Lấy danh sách có Include quan hệ
            var OrderList = context.Orders
                .Include("PaymentMethods")
                .Include("OrderStatuses") //muốn dùng .Include(b => b.XYZ) thì thêm using System.Data.Entity;
                .AsNoTracking() // chỉ lấy dữ liệu ra để đọc, không theo dõi nữa
                .AsQueryable();

            //lọc theo keyword
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                OrderList = OrderList.Where(b =>
                    b.OrderId.ToString().Contains(keyword) ||
                    b.CustomerName.ToLower().Contains(keyword));
            }

            // Lọc theo trạng thái
            if (cbOrderStatus.SelectedValue != null && int.TryParse(cbOrderStatus.SelectedValue.ToString(), out int selectedStatusId))
            {
                if (selectedStatusId != 0)
                {
                    OrderList = OrderList.Where(o => o.StatusId == selectedStatusId);
                }
            }


            //đổ dữ liệu
            int index = 1;
            foreach (var b in OrderList.ToList())
            {
                dgvOrder.Rows.Add(
                    index++,
                    b.OrderId,
                    b.CustomerName,
                    b.OrderDate,
                    b.PaymentMethods.MethodName,
                    b.Phone,
                    b.OrderStatuses.StatusName,
                    b.TotalPrice.ToString("#,##0")
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formOrderAdd());
            LoadOrders();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrders(txtSearch.Text);
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrder.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formOrderAdd frm = new formOrderAdd();
                frm.OrderId = Convert.ToInt32(dgvOrder.CurrentRow.Cells["dgvid"].Value);
                frm.ShowDialog();
                LoadOrders(); // gọi lại hàm load danh sách đơn hàng
            }
            else if (dgvOrder.CurrentCell.OwningColumn.Name == "dgvDetail")
            {
                int orderId = Convert.ToInt32(dgvOrder.CurrentRow.Cells["dgvid"].Value);


                var detailList = context.OrderItems
                    .Where(o => o.OrderId == orderId)
                    .ToList();

                int index = 1;
                foreach (var item in detailList)
                {
                    var book = context.Books.Find(item.BookId);
                    string title = book?.Title ?? "(Không tìm thấy)";
                    int qty = item.BookQuantity ?? 0;
                    decimal price = item.BookPrice ?? 0;
                    decimal total = qty * price;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbOderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders(txtSearch.Text);
        }
    }
}
