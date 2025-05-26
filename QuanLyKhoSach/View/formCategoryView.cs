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
    public partial class formCategoryView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        public formCategoryView()
        {
            InitializeComponent();
        }

        private void formCategoryView_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void LoadCategory(string keyword = "")
        {
            dgvCategory.Rows.Clear();
            dgvCategory.AllowUserToAddRows = false;

            // Lấy dữ liệu từ Entity Framework

            var CategoryList = context.Categories.AsNoTracking() // chỉ lấy dữ liệu ra để đọc, không theo dõi nữa
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                CategoryList = CategoryList.Where(c =>
                    c.CategoryId.ToString().Contains(keyword) ||
                    c.CategoryName.ToLower().Contains(keyword));
            }
            // Đổ dữ liệu
            int index = 1;
            foreach (var c in CategoryList)
            {
                dgvCategory.Rows.Add(index++, c.CategoryId, c.CategoryName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formCategoryAdd frm = new formCategoryAdd();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCategory();
            }
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formCategoryAdd frm = new formCategoryAdd();
                // Gán dữ liệu từ dòng đang chọn vào form
                frm.txtName.Text = dgvCategory.CurrentRow.Cells["dgvName"].Value?.ToString();
                // Truyền id để biết đang sửa ai
                frm.CategoryId = Convert.ToInt32(dgvCategory.CurrentRow.Cells["dgvid"].Value);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategory(); // Chỉ load lại nếu có thay đổi
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCategory(txtSearch.Text);
        }
    }
}