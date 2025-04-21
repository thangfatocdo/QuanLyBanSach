using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections.Generic;

namespace QuanLyKhoSach
{
    public partial class Form1 : Form
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        private List<Book> bookList = new List<Book>(); // lưu danh sách sách dùng toàn cục

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            LoadBooks();
            LoadCategories();
        }

        // Load danh sách sách từ EF + hiển thị thumbnail
        private void LoadBooks()
        {
            dgvBooks.Columns.Clear();
            dgvBooks.Rows.Clear();
            dgvBooks.AllowUserToAddRows = false;

            // Lấy danh sách sách có Include quan hệ
            bookList = context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();

            // Thêm cột hình ảnh
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Ảnh";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol.Width = 80;
            dgvBooks.Columns.Add(imgCol);

            // Các cột khác
            dgvBooks.Columns.Add("BookId", "Mã Sách");
            dgvBooks.Columns.Add("Title", "Tên Sách");
            dgvBooks.Columns.Add("Category", "Loại Sách");
            dgvBooks.Columns.Add("Author", "Tác Giả");
            dgvBooks.Columns.Add("Publisher", "NXB");
            dgvBooks.Columns.Add("Price", "Giá Bán");
            dgvBooks.Columns.Add("Description", "Mô Tả");
            dgvBooks.Columns.Add("CreatedAt", "Ngày Tạo");
            dgvBooks.Columns.Add("ImageUrl", "Hình Ảnh"); // ẩn

            dgvBooks.Columns["ImageUrl"].Visible = false;

            // Thêm dòng
            foreach (var b in bookList)
            {
                Image img = null;
                if (!string.IsNullOrEmpty(b.ImageUrl))
                {
                    string fullPath = Path.Combine(Application.StartupPath, b.ImageUrl);
                    if (File.Exists(fullPath))
                        img = Image.FromFile(fullPath);
                }

                dgvBooks.Rows.Add(
                    img,
                    b.BookId,
                    b.Title,
                    b.Category?.CategoryName,
                    b.Author?.AuthorName,
                    b.Publisher?.PublisherName,
                    b.Price,
                    b.Description,
                    b.CreatedAt.HasValue ? b.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                    b.ImageUrl
                );
            }
        }

        // 🔹 Click đúp để xem ảnh to
        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < bookList.Count)
            {
                string imagePath = dgvBooks.Rows[e.RowIndex].Cells["ImageUrl"].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    FormPreview previewForm = new FormPreview(imagePath);
                    previewForm.ShowDialog();
                }
            }
        }

        // Load loại sách qua EF
        private void LoadCategories()
        {
            dgvCategories.Columns.Clear();
            dgvCategories.Rows.Clear();
            dgvCategories.AllowUserToAddRows = false;

            dgvCategories.Columns.Add("CategoryId", "Mã Loại Sách");
            dgvCategories.Columns.Add("CategoryName", "Loại Sách");

            // Lấy dữ liệu từ Entity Framework
            var categories = context.Categories.ToList();

            // Thêm từng dòng
            foreach (var c in categories)
            {
                dgvCategories.Rows.Add(c.CategoryId, c.CategoryName);
            }
        }

    }
}
