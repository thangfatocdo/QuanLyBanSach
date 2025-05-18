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
    public partial class formUserAdd : Sample
    {
        BookstoreDBEntities context = new BookstoreDBEntities();
        public formUserAdd()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }
        public int? UserId { get; set; }

        //hiển thị dữ liệu form để sửa
        private void formUserAdd_Load(object sender, EventArgs e)
        {
            if (UserId != null)
            {
                var user = context.Users.Find(UserId);
                if (user != null)
                {
                    txtName.Text = user.FullName;
                    txtPass.Text = user.Password;
                    txtUsename.Text = user.Username;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtUsename.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
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
                if (UserId == null) // THÊM MỚI
                {
                    // Tạo đối tượng khách hàng mới
                    Users newUsers = new Users
                    {
                        Username = txtUsename.Text.Trim(),
                        FullName = txtName.Text.Trim(),

                        Password = txtPass.Text.Trim(),
                    };

                    context.Users.Add(newUsers);
                }
                else // SỬA
                {
                    var existing = context.Users.Find(UserId);
                    if (existing != null)
                    {
                        existing.Username = txtUsename.Text.Trim();    
                        existing.FullName = txtName.Text.Trim();

                        existing.Password = txtPass.Text.Trim();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
