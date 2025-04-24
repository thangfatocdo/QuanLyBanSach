using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyKhoSach
{
    public partial class FormLogin : Form
    {
        // Khởi tạo DbContext để tương tác với database bằng Entity Framework
        private BookstoreDBEntities context = new BookstoreDBEntities();

        public FormLogin()
        {
            InitializeComponent();
        }

        // Bắt sự kiện nhấn nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }
            if (txtMatkhau.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }

            try
            {
                string user = txtTenDN.Text.Trim();
                string pass = txtMatkhau.Text.Trim();

                // Tìm người dùng trong database bằng EF
                var acc = context.Users.FirstOrDefault(u => u.Username == user && u.Password == pass);
                if (acc != null)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở form chính sau khi login thành công
                    this.Hide();
                    Form1 mainForm = new Form1();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
