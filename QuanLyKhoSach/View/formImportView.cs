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
    public partial class formImportView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        public formImportView()
        {
            InitializeComponent();
        }

        private void formImportView_Load(object sender, EventArgs e)
        {
            LoadImports();
        }
        private void LoadImports(string keyword = "")
        {
            dgvImport.Rows.Clear();
            dgvImport.AllowUserToAddRows = false;

            // Lấy danh sách có Include quan hệ
            var ImmportList = context.InventoryImport
                .Include("Users") //muốn dùng .Include(b => b.XYZ) thì thêm using System.Data.Entity;
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                ImmportList = ImmportList.Where(b =>
                    b.Users.FullName.ToLower().Contains(keyword));
            }
            //đổ dữ liệu
            int index = 1;
            foreach (var b in ImmportList.ToList())
            {
                dgvImport.Rows.Add(
                    index++,
                    b.ImportId,
                    b.Users.FullName,
                    b.ImportDate,
                    b.Note
                );
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            formMain.BlurBackground(new formImportAdd());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadImports(txtSearch.Text);
        }

        private void dgvImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImport.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formImportAdd frm = new formImportAdd();
                //gán Id để biết đang sửa cái nào
                frm.ImportId = Convert.ToInt32(dgvImport.CurrentRow.Cells["dgvid"].Value);
                frm.ShowDialog();
                LoadImports();
            }
            else if (dgvImport.CurrentCell.OwningColumn.Name == "dgvDetail")
            {
                // Lấy ImportId đang chọn
                int importId = Convert.ToInt32(dgvImport.CurrentRow.Cells["dgvid"].Value);

                // Clear dữ liệu cũ
                dgvImportDetail.Rows.Clear();
                dgvImportDetail.AllowUserToAddRows = false;

                // Lấy danh sách chi tiết nhập
                var detailList = context.InventoryDetail
                    .Where(d => d.ImportId == importId)
                    .ToList();

                int index = 1;
                foreach (var d in detailList)
                {
                    var book = context.Books.Find(d.BookId);
                    string title = book?.Title ?? "(Không tìm thấy)";
                    dgvImportDetail.Rows.Add(index++, title, d.Quantity);
                }
            }
        }

        private void dgvImportDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
