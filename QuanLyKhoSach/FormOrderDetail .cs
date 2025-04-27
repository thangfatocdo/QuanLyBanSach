using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach
{
    public partial class FormOrderDetail : Form
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        private int orderId;

        public FormOrderDetail(int _orderId)
        {
            InitializeComponent();
            orderId = _orderId;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            dgvOrderItems.Columns.Clear();
            dgvOrderItems.Rows.Clear();
            dgvOrderItems.AllowUserToAddRows = false;

            dgvOrderItems.Columns.Add("Title", "Tên Sách");
            dgvOrderItems.Columns.Add("BookPrice", "Giá Bán");
            dgvOrderItems.Columns.Add("Quantity", "Số Lượng");

            var orderItems = context.OrderItems
                .Include("Books")
                .Where(oi => oi.OrderId == orderId)
                .ToList();

            foreach (var item in orderItems)
            {
                dgvOrderItems.Rows.Add(
                    item.Books?.Title,
                    item.BookPrice,
                    item.BookQuantity
                );
            }
        }
    }
}
