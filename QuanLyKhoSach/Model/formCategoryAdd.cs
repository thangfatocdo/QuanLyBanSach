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
    public partial class formCategoryAdd : Sample
    {
        BookstoreDBEntities context = new BookstoreDBEntities();
        public formCategoryAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formCategoryAdd_Load(object sender, EventArgs e)
        {

        }
        public int? CategoryId { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                if (CategoryId == null) // THÊM MỚI
                {
                    // Tạo đối tượng khách hàng mới
                    Categories newCategory = new Categories
                    {
                        CategoryName = txtName.Text.Trim()
                    };

                    context.Categories.Add(newCategory);
                }
                else // SỬA
                {
                    var existing = context.Categories.Find(CategoryId);
                    if (existing != null)
                    {
                        existing.CategoryName = txtName.Text.Trim();
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
