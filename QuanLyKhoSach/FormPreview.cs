using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyKhoSach
{
    public partial class FormPreview : Form
    {
        public FormPreview(string imagePath)
        {
            InitializeComponent();
            Init(imagePath);
        }

        private void Init(string imagePath)
        {
            this.Text = "Xem ảnh sách";
            this.Size = new Size(600, 800);
            PictureBox pic = new PictureBox();
            pic.Dock = DockStyle.Fill;
            pic.SizeMode = PictureBoxSizeMode.Zoom;

            // Load ảnh nếu tồn tại
            string fullPath = Path.Combine(Application.StartupPath, imagePath);
            if (File.Exists(fullPath))
            {
                pic.Image = Image.FromFile(fullPath);
            }
            else
            {
                pic.Image = null;
                MessageBox.Show("Không tìm thấy ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Controls.Add(pic);
        }
    }
}
