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
    public partial class formImportAdd : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        // Khi sửa, bạn có thể truyền ImportId vào
        public int? ImportId { get; set; }
        public formImportAdd()
        {
            InitializeComponent();
        }
        private void formImportAdd_Load(object sender, EventArgs e)
        {
            // 1. Load sách lên ComboBox
            cbBookName.DataSource = context.Books.ToList();
            cbBookName.DisplayMember = "Title";
            cbBookName.ValueMember = "BookId";

            // 2. Mặc định chọn ngày hiện tại
            guna2DateTimePicker1.Value = DateTime.Now;

            // 3. Nếu là sửa thì load lại header và detail
            if (ImportId != null)
            {
                // a) Load lại thông tin phiếu nhập (nếu có Note/TextBox)
                var imp = context.InventoryImport.Find(ImportId);
                if (imp != null)
                {
                    guna2DateTimePicker1.Value = imp.ImportDate ?? DateTime.Now;
                    // nếu bạn có TextBox txtNote, thì gán vào đây:
                    // txtNote.Text = imp.Note;
                }

                // b) Load lại các dòng detail
                var details = context.InventoryDetail
                                     .Where(d => d.ImportId == ImportId)
                                     .ToList();

                int sr = 1;
                foreach (var d in details)
                {
                    // Lấy tiêu đề sách để hiển thị
                    var book = context.Books.Find(d.BookId);
                    string title = book?.Title ?? "";

                    // Thêm dòng vào grid: SR, Title, Quantity
                    int idx = dgvImportDetail.Rows.Add(
                        sr++,       // STT
                        title,      // Tên sách
                        d.Quantity  // Số lượng
                    );

                    // Lưu BookId vào Tag để khi Save có thể lấy
                    dgvImportDetail.Rows[idx].Tag = d.BookId;
                }
            }
        }
        // 3. Thêm sách vào grid
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbBookName.SelectedValue == null) return;

            int bookId = (int)cbBookName.SelectedValue;
            string title = cbBookName.Text;
            int qty = (int)quantity.Value;

            // Thêm 1 dòng mới và lấy chỉ số của nó
            int idx = dgvImportDetail.Rows.Add(
                dgvImportDetail.Rows.Count + 1, // SR
                title,                           // Tên sách
                qty                              // Số lượng
            );

            // Lưu BookId vào Tag của dòng đó
            dgvImportDetail.Rows[idx].Tag = bookId;
        }
        // 4. Xóa dòng đang chọn
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvImportDetail.CurrentCell == null) return;
            int row = dgvImportDetail.CurrentCell.RowIndex;
            dgvImportDetail.Rows.RemoveAt(row);

            // đánh lại STT
            for (int i = 0; i < dgvImportDetail.Rows.Count; i++)
                dgvImportDetail.Rows[i].Cells["dgvSr"].Value = i + 1;
        }
        private void dgvImportDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // 5. Lưu import + detail
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvImportDetail.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào để nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InventoryImport imp;
                if (ImportId == null)
                {
                    // THÊM MỚI
                    imp = new InventoryImport
                    {
                        UserId = formMain.CurrentUserId,
                        ImportDate = guna2DateTimePicker1.Value,
                        Note = null   // hoặc txtNote.Text nếu có
                    };
                    context.InventoryImport.Add(imp);
                    context.SaveChanges(); // để imp.ImportId được sinh
                }
                else
                {
                    // SỬA
                    imp = context.InventoryImport.Find(ImportId.Value);
                    if (imp == null)
                    {
                        MessageBox.Show("Phiếu nhập không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật các trường header
                    imp.ImportDate = guna2DateTimePicker1.Value;
                    imp.Note = null; // hoặc txtNote.Text

                    // Xóa detail cũ
                    var oldDetails = context.InventoryDetail
                                            .Where(d => d.ImportId == ImportId.Value)
                                            .ToList();
                    if (oldDetails.Any())
                    {
                        context.InventoryDetail.RemoveRange(oldDetails);
                        context.SaveChanges();
                    }
                }

                // TẠO detail mới từ grid
                foreach (DataGridViewRow row in dgvImportDetail.Rows)
                {
                    int bookId = (int)row.Tag;  // bạn đã lưu BookId vào Row.Tag
                    int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);

                    var detail = new InventoryDetail
                    {
                        ImportId = imp.ImportId,
                        BookId = bookId,
                        Quantity = quantity,
                        Type = "Import"
                    };
                    context.InventoryDetail.Add(detail);
                }

                context.SaveChanges();
                MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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