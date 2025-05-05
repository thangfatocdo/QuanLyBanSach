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
    public partial class formOderView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();

        public formOderView()
        {
            InitializeComponent();
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
                .Include("Customers")
                .Include("PaymentMethods")
                .Include("OrderStatuses") //muốn dùng .Include(b => b.XYZ) thì thêm using System.Data.Entity;
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                OrderList = OrderList.Where(b =>
                    b.Customers.FullName.ToLower().Contains(keyword));
            }
            //đổ dữ liệu
            int index = 1;
            foreach (var b in OrderList.ToList())
            {
                dgvOrder.Rows.Add(
                    index++,
                    b.OrderId,
                    b.Customers.FullName,
                    b.OrderDate,
                    b.PaymentMethods.MethodName,
                    b.ReceiveDate,
                    b.OrderStatuses.StatusName,
                    b.TotalPrice
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formOrderAdd());
        }
    }
}
