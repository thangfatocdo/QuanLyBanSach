using CrystalDecisions.CrystalReports.Engine;
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

            // 1. Tính tồn kho tất cả sách 1 lần duy nhất
            var stockDict = context.Books
                .Select(b => new
                {
                    b.BookId,
                    TotalImport = context.InventoryDetail
                        .Where(d => d.BookId == b.BookId && d.Type == "Import")
                        .Sum(d => (int?)d.Quantity) ?? 0,
                    TotalExport = context.InventoryDetail
                        .Where(d => d.BookId == b.BookId && d.Type == "Export")
                        .Sum(d => (int?)d.Quantity) ?? 0
                })
                .ToList()
                .ToDictionary(
                    x => x.BookId,
                    x => x.TotalImport - x.TotalExport
                );

            // 2. Load danh sách sách
            var bookList = context.Books
                .Include("Categories")
                .Include("Publishers")
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                bookList = bookList.Where(b =>
                    b.BookId.ToString().Contains(keyword) ||
                    b.Title.ToLower().Contains(keyword) ||
                    b.Categories.CategoryName.ToLower().Contains(keyword) ||
                    b.AuthorName.ToLower().Contains(keyword) ||
                    b.Publishers.PublisherName.ToLower().Contains(keyword));
            }

            int index = 1;
            foreach (var b in bookList.ToList())
            {
                int stock = stockDict.ContainsKey(b.BookId) ? stockDict[b.BookId] : 0;
                string stockText = stock <= 0 ? "Đã hết" : stock.ToString();
                int rowIndex = dgvBook.Rows.Add(
                    index++,
                    b.BookId,
                    b.Title,
                    b.Categories?.CategoryName,
                    b.AuthorName,
                    b.Publishers?.PublisherName,
                    b.Price.ToString("#,##0"),                    
                    stockText,
                    b.IsVisible ? "" : "ẨN"
                );

                if (stock <= 0)
                {
                    dgvBook.Rows[rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formBookAdd());
            LoadBooks();
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
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text);

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
