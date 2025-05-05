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
    public partial class formUserView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();

        public formUserView()
        {
            InitializeComponent();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUser.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formUserAdd frm = new formUserAdd();
                // Truyền id để biết đang sửa ai
                frm.UserId = Convert.ToInt32(dgvUser.CurrentRow.Cells["dgvid"].Value);

                frm.ShowDialog();
                LoadUsers(); // Load lại danh sách sau khi sửa
            }
        }

        private void formUserView_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        //Load danh sách kết hợp tìm kiếy
        private void LoadUsers(string keyword = "")
        {
            ;
            dgvUser.Rows.Clear();
            dgvUser.AllowUserToAddRows = false;

            // Lấy dữ liệu từ Entity Framework
            var userList = context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                userList = userList.Where(c =>
                    c.FullName.ToLower().Contains(keyword) ||
                    c.Username.ToLower().Contains(keyword));
            }
            // Đổ dữ liệu
            int index = 1;
            foreach (var u in userList)
            {
                dgvUser.Rows.Add(index++, u.UserId, u.Username, u.FullName, u.Password);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formUserAdd());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text);
        }
    }
}
