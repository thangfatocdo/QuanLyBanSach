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
    public partial class formBookView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();

        public formBookView()
        {
            InitializeComponent();
        }

        private void formBookView_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }
        private void LoadBooks(string keyword = "")
        {
            dgvBook.Rows.Clear();
            dgvBook.AllowUserToAddRows = false;

            // Lấy danh sách có Include quan hệ
            var bookList = context.Books
                .Include("Categories")
                .Include("Authors")
                .Include("Publishers") //muốn dùng .Include(b => b.XYZ) thì thêm using System.Data.Entity;
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                bookList = bookList.Where(b =>
                    b.Title.ToLower().Contains(keyword) ||
                    b.Categories.CategoryName.ToLower().Contains(keyword) ||
                    b.Authors.AuthorName.ToLower().Contains(keyword) ||
                    b.Publishers.PublisherName.ToLower().Contains(keyword));
            }

            int index = 1;
            foreach (var b in bookList.ToList())
            {
                dgvBook.Rows.Add(
                    index++,
                    b.BookId,
                    b.Title,
                    b.Categories?.CategoryName,
                    b.Authors?.AuthorName,
                    b.Publishers?.PublisherName,
                    b.Price
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formBookAdd());
        }
        //nút edit
        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBook.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formBookAdd frm = new formBookAdd();
                //gán Id để biết đang sửa cái nào
                frm.BookId = Convert.ToInt32(dgvBook.CurrentRow.Cells["dgvid"].Value);
                frm.ShowDialog();
                LoadBooks();
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text);

        }
    }
}
