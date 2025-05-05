using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach.Model
{
    public partial class formCustomerAdd : Sample
    {
        BookstoreDBEntities context = new BookstoreDBEntities();
        public formCustomerAdd()
        {
            InitializeComponent();
        }

        private void formCustomerAdd_Load(object sender, EventArgs e)
        {
            //hiển thị dữ liệu form để sửa
            if (CustomerId != null)
            {
                var customer = context.Customers.Find(CustomerId);
                if (customer != null)
                {
                    txtName.Text = customer.FullName;
                    txtPhone.Text = customer.Phone;
                    txtEmail.Text = customer.Email;
                    txtPass.Text = customer.Password;
                    txtAddress.Text = customer.Address;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int? CustomerId { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            try
            {
                if (CustomerId == null) // THÊM MỚI
                {
                    // Tạo đối tượng khách hàng mới
                    Customers newCustomer = new Customers
                    {
                        FullName = txtName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Password = txtPass.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };

                    context.Customers.Add(newCustomer);
                }
                else // SỬA
                {
                    var existing = context.Customers.Find(CustomerId);
                    if (existing != null)
                    {
                        existing.FullName = txtName.Text.Trim();
                        existing.Email = txtEmail.Text.Trim();
                        existing.Phone = txtPhone.Text.Trim();
                        existing.Password = txtPass.Text.Trim();
                        existing.Address = txtAddress.Text.Trim();
                    }
                }
                    context.SaveChanges();

                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
