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
    public partial class formCustomerView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        public formCustomerView()
        {
            InitializeComponent();
        }

        private void formCustomerView_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        //Load danh sách kết hợp tìm kiếm
        private void LoadCustomers(string keyword = "")
        {
            dgvCustomer.Rows.Clear();
            dgvCustomer.AllowUserToAddRows = false;
            // Lấy dữ liệu từ Entity Framework
            var customerList = context.Customers.AsQueryable();
            // Lọc danh sách theo từ khóa
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                customerList = customerList.Where(c =>
                    c.FullName.ToLower().Contains(keyword) ||
                    c.Phone.ToLower().Contains(keyword) ||
                    c.Address.ToLower().Contains(keyword) ||
                    c.Email.ToLower().Contains(keyword));
            }

            // Đổ dữ liệu
            int index = 1;
            foreach (var c in customerList)
            {
                dgvCustomer.Rows.Add(index++, c.CustomerId, c.FullName, c.Phone, c.Address, c.Email,c.Password);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formCustomerAdd());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text);
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formCustomerAdd frm = new formCustomerAdd();
                //Truyền id để biết đang sửa ai
                frm.CustomerId = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["dgvid"].Value);
                frm.ShowDialog();
                LoadCustomers();
            }
        }
    }
}
