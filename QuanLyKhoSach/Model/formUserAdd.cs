using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using static Guna.UI2.Native.WinApi;

namespace QuanLyKhoSach.Model
{
    public partial class formUserAdd : Sample
    {
        BookstoreDBEntities context = new BookstoreDBEntities();
        public formUserAdd()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }
        public int? UserId { get; set; }
        private string selectedImageFileName = null;
        //hiển thị dữ liệu form để sửa
        private void formUserAdd_Load(object sender, EventArgs e)
        {
            if (UserId != null)
            {
                var user = context.Users.Find(UserId);
                if (user != null)
                {
                    txtName.Text = user.FullName;
                    txtPass.Text = user.Password;
                    txtUsename.Text = user.Username;
                    selectedImageFileName = user.ImageUrl;
                    if (!string.IsNullOrEmpty(selectedImageFileName))
                    {
                        string path = Path.Combine(Application.StartupPath, "Images", selectedImageFileName);
                        if (File.Exists(path))
                        {
                            txtPic.Image = Image.FromFile(path);
                        }
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtUsename.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            try
            {
                if (UserId == null) // THÊM MỚI
                {
                    // Tạo đối tượng khách hàng mới
                    Users newUsers = new Users
                    {
                        Username = txtUsename.Text.Trim(),
                        FullName = txtName.Text.Trim(),
                        ImageUrl = selectedImageFileName,
                        Password = PasswordHelper.Hash(txtPass.Text.Trim()),
                    };

                    context.Users.Add(newUsers);
                }
                else // SỬA
                {
                    var existing = context.Users.Find(UserId);
                    if (existing != null)
                    {
                        existing.Username = txtUsename.Text.Trim();
                        existing.FullName = txtName.Text.Trim();
                        existing.ImageUrl = selectedImageFileName;
                        existing.Password = PasswordHelper.Hash(txtPass.Text.Trim());

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string srcPath = ofd.FileName;
            string destName = Path.GetFileName(srcPath);
            string localFolder = Path.Combine(Application.StartupPath, "Images");
            Directory.CreateDirectory(localFolder);
            string localPath = Path.Combine(localFolder, destName);

            // 1. Nếu file chưa tồn tại, copy vào. Nếu đã có hoặc đang lock, vẫn tiếp tục
            if (!File.Exists(localPath))
            {
                try
                {
                    File.Copy(srcPath, localPath);
                }
                catch (IOException)
                {
                    // file đang bị lock, bỏ qua việc copy, vẫn load từ disk nếu đã có
                }
            }

            // 2. Nếu PictureBox đã load ảnh cùng tên (lưu trong Tag), skip để không load trùng
            if (txtPic.Tag != null
                && txtPic.Tag.ToString().Equals(destName, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            // 3. Load ảnh vào PictureBox (dùng FileStream để tránh lock file lâu dài)
            try
            {
                using (var fs = new FileStream(localPath, FileMode.Open, FileAccess.Read))
                {
                    txtPic.Image = Image.FromStream(fs);
                }
                txtPic.Tag = destName; // lưu lại tên file đã load
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể load ảnh:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. (option) Gửi ảnh lên web nếu cần
            string uploadedFileName = await UploadImageToWebAsync(srcPath);
            if (!string.IsNullOrEmpty(uploadedFileName))
            {
                selectedImageFileName = uploadedFileName;
            }
        }


        private async Task<string> UploadImageToWebAsync(string filePath)
        {
            var client = new HttpClient();
            var url = "https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/upload-image";

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
        public static class PasswordHelper
        {
            public static string Hash(string raw)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(raw);
                    byte[] hash = sha.ComputeHash(bytes);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }
    }
}
