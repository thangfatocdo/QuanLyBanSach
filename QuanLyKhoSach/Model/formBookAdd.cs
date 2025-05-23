﻿using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach.Model
{
    public partial class formBookAdd : Sample
    {
        BookstoreDBEntities context = new BookstoreDBEntities();

        public formBookAdd()
        {
            InitializeComponent();
        }

        public int? BookId { get; set; }
        private string selectedImageFileName = null;

        private void formBookAdd_Load(object sender, EventArgs e)
        {
            LoadComboBox();

            if (BookId != null)
            {
                var book = context.Books.Find(BookId);
                if (book != null)
                {
                    txtName.Text = book.Title;
                    txtPrice.Text = book.Price.ToString();
                    txtDesc.Text = book.Description;

                    cbCatetegory.SelectedValue = book.CategoryId;
                    cbAuthor.SelectedValue = book.AuthorId;
                    cbNXB.SelectedValue = book.PublisherId;

                    selectedImageFileName = book.ImageUrl;

                    if (!string.IsNullOrEmpty(selectedImageFileName))
                    {
                        string path = Path.Combine(Application.StartupPath, "Images", selectedImageFileName);
                        if (File.Exists(path))
                        {
                            picBox.Image = Image.FromFile(path);
                        }
                    }
                }
            }
        }
        // load dữ liệu vào combobox
        private void LoadComboBox()
        {
            cbCatetegory.DataSource = context.Categories.ToList();
            cbCatetegory.DisplayMember = "CategoryName";
            cbCatetegory.ValueMember = "CategoryId";

            cbAuthor.DataSource = context.Authors.ToList();
            cbAuthor.DisplayMember = "AuthorName";
            cbAuthor.ValueMember = "AuthorId";

            cbNXB.DataSource = context.Publishers.ToList();
            cbNXB.DisplayMember = "PublisherName";
            cbNXB.ValueMember = "PublisherId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (cbAuthor.SelectedValue == null || cbCatetegory.SelectedValue == null || cbNXB.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đủ Thể loại, Tác giả, NXB!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (BookId == null) // THÊM MỚI
                {
                    Books newBook = new Books
                    {
                        Title = txtName.Text.Trim(),
                        Price = decimal.Parse(txtPrice.Text),
                        Description = txtDesc.Text.Trim(),
                        CategoryId = (int)cbCatetegory.SelectedValue,
                        AuthorId = (int)cbAuthor.SelectedValue,
                        PublisherId = (int)cbNXB.SelectedValue,
                        ImageUrl = selectedImageFileName
                    };

                    context.Books.Add(newBook);
                }
                else // SỬA
                {
                    var existing = context.Books.Find(BookId);
                    if (existing != null)
                    {
                        existing.Title = txtName.Text.Trim();
                        existing.Price = decimal.Parse(txtPrice.Text);
                        existing.Description = txtDesc.Text.Trim();
                        existing.CategoryId = (int)cbCatetegory.SelectedValue;
                        existing.AuthorId = (int)cbAuthor.SelectedValue;
                        existing.PublisherId = (int)cbNXB.SelectedValue;
                        existing.ImageUrl = selectedImageFileName;
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

        //add hình từ máy
        private async void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(ofd.FileName);
                string localFolder = Path.Combine(Application.StartupPath, "Images");
                Directory.CreateDirectory(localFolder);
                string localPath = Path.Combine(localFolder, fileName);
                File.Copy(ofd.FileName, localPath, true);

                // Load hình lên PictureBox
                picBox.Image = Image.FromFile(localPath);

                // Gửi ảnh lên Web
                string uploadedFileName = await UploadImageToWebAsync(ofd.FileName);

                if (!string.IsNullOrEmpty(uploadedFileName))
                {
                    selectedImageFileName = uploadedFileName;
                }
            }
        }

        private async Task<string> UploadImageToWebAsync(string filePath)
        {
            var client = new HttpClient();
            var url = "https://localhost:7254/api/upload-image";

            try
            {
                using (var form = new MultipartFormDataContent())
                {
                    var fileBytes = File.ReadAllBytes(filePath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(fileContent, "file", Path.GetFileName(filePath));

                    var response = await client.PostAsync(url, form);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);
                        return (string)result.fileName;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Gửi ảnh lên Web thất bại! Server trả về: " + response.StatusCode,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return null;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // lỗi kết nối, 404, DNS fail, timeout…
                MessageBox.Show(
                    "Không thể kết nối đến server. Vui lòng thử lại sau.",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return null;
            }
            catch (Exception ex)
            {
                // bất kỳ lỗi nào khác
                MessageBox.Show(
                    "Đã xảy ra lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }
    }
}
