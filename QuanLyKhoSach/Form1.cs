using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach
{
    
    public partial class Form1 : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private DataTable bookTable = new DataTable(); // dữ liệu toàn cục

        public Form1()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            initSach();
            initCategory();
        }
        private void initSach()
        {
            bookTable = getBookData();
            displayBooks(bookTable);
        }

        //Lấy dữ liệu từ database
        private DataTable getBookData()
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append("b.BookId AS [Mã Sách], ");
            query.Append("b.Title AS [Tên Sách], ");
            query.Append("c.CategoryName AS [Loại Sách], ");
            query.Append("a.AuthorName AS [Tác Giả], ");
            query.Append("b.Price AS [Giá Bán], ");
            query.Append("b.Description AS [Mô Tả], ");
            query.Append("p.PublisherName AS [NXB], ");
            query.Append("b.CreatedAt AS [Ngày Tạo], ");
            query.Append("b.ImageUrl AS [Hình Ảnh] ");
            query.Append("FROM Books b ");
            query.Append("JOIN Categories c ON b.CategoryId = c.CategoryId ");
            query.Append("JOIN Authors a ON b.AuthorId = a.AuthorId ");
            query.Append("JOIN Publishers p ON b.PublisherId = p.PublisherId ");

            return dataProvider.execQuery(query.ToString());
        }

        //hiển thị sách
        private void displayBooks(DataTable dt)
        {
            dgvBooks.Columns.Clear();
            dgvBooks.Rows.Clear();
            dgvBooks.AllowUserToAddRows = false;
            // Thêm cột ảnh
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Ảnh";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol.Width = 80;
            dgvBooks.Columns.Add(imgCol);

            // Thêm các cột text
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName != "Hình Ảnh")
                    dgvBooks.Columns.Add(col.ColumnName, col.ColumnName);
            }

            // Thêm từng dòng dữ liệu
            foreach (DataRow row in dt.Rows)
            {
                string imgPath = row["Hình Ảnh"].ToString();
                Image img = null;

                if (!string.IsNullOrEmpty(imgPath))
                {
                    string fullPath = Path.Combine(Application.StartupPath, imgPath);
                    if (File.Exists(fullPath))
                        img = Image.FromFile(fullPath);
                }

                List<object> cells = new List<object> { img };
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName != "Hình Ảnh")
                        cells.Add(row[col]);
                }

                dgvBooks.Rows.Add(cells.ToArray());
            }
        }
        private void txtDescription_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooks.Rows[e.RowIndex].Cells.Count > 0)
            {
                string imagePath = bookTable.Rows[e.RowIndex]["Hình Ảnh"].ToString(); // dùng bookTable

                FormPreview previewForm = new FormPreview(imagePath);
                previewForm.ShowDialog(); // popup ảnh to
            }
        }
        //xử lý loại sách
        private void initCategory()
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append("c.CategoryId AS [Mã Loại Sách], ");
            query.Append("c.CategoryName AS [Loại Sách] ");
            query.Append("FROM Categories c");

            DataTable dt = dataProvider.execQuery(query.ToString());

            dgvCategories.DataSource = dt;
            dgvCategories.AllowUserToAddRows = false;
        }


    }
}
