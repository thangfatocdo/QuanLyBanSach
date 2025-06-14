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
    public partial class formPublisherView : Sample
    {
        private BookstoreDBEntities context = new BookstoreDBEntities();
        public formPublisherView()
        {
            InitializeComponent();
        }
        private void formPublisherView_Load(object sender, EventArgs e)
        {
            LoadPublisher();
        }
        private void LoadPublisher(string keyword = "")
        {
            dgvPublisher.Rows.Clear();
            dgvPublisher.AllowUserToAddRows = false;

            // Lấy dữ liệu từ Entity Framework

            var PublisherList = context.Publishers.AsNoTracking() // chỉ lấy dữ liệu ra để đọc, không theo dõi nữa
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                PublisherList = PublisherList.Where(c =>
                    c.PublisherId.ToString().Contains(keyword) ||
                    c.PublisherName.ToLower().Contains(keyword));
            }
            // Đổ dữ liệu
            int index = 1;
            foreach (var c in PublisherList)
            {
                dgvPublisher.Rows.Add(index++, c.PublisherId, c.PublisherName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formPublisherAdd frm = new formPublisherAdd();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPublisher();
            }
        }

        private void dgvPublisher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPublisher.CurrentCell.OwningColumn.Name == "dvgEdit")
            {
                formPublisherAdd frm = new formPublisherAdd();
                // Gán dữ liệu từ dòng đang chọn vào form
                frm.txtName.Text = dgvPublisher.CurrentRow.Cells["dgvName"].Value?.ToString();
                // Truyền id để biết đang sửa ai
                frm.PublisherID = Convert.ToInt32(dgvPublisher.CurrentRow.Cells["dgvid"].Value);
                frm.ShowDialog();
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadPublisher(txtSearch.Text);
        }
    }
}
