using ImageMagick;
using Newtonsoft.Json;
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
using static Guna.UI2.Native.WinApi;

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


        // 1. Khi form load, nếu đang sửa sách thì load luôn ảnh từ DB
        private void formBookAdd_Load(object sender, EventArgs e)
        {
            LoadComboBox();  // phần cũ của bạn

            // nếu BookId != null => load ảnh
            if (BookId != null)
            {
                var book = context.Books.Find(BookId);
                if (book != null)
                {
                    txtName.Text = book.Title;
                    txtPrice.Text = book.Price.ToString("#,##0");
                    txtDesc.Text = book.Description;
                    txtAuthor.Text = book.AuthorName;
                    cbCatetegory.SelectedValue = book.CategoryId;
                    cbNXB.SelectedValue = book.PublisherId;
                    Hide.Checked = !book.IsVisible;
                }
            }
            if (BookId != null)
                LoadPictures((int)BookId);
        }


        // 2. Hàm load ảnh vào dgvPicture
        private void LoadPictures(int bookId)
        {
            dgvPicture.Rows.Clear();
            dgvPicture.AllowUserToAddRows = false;
            // (tùy chọn) sửa lại chiều cao row cho vừa thumbnail
            dgvPicture.RowTemplate.Height = 100;
            // Lấy danh sách ảnh từ DB
            var pics = context.BookImages
                              .Where(pi => pi.BookId == bookId)
                              .ToList();

            foreach (var pic in pics)
            {
                // build path đến folder Images
                string path = Path.Combine(Application.StartupPath, "Images", pic.ImageUrl);
                Image img = null;
                if (File.Exists(path))
                    img = LoadImageToDgv(path);       // load ảnh

                // thêm 1 dòng mới, chỉ có cột dgvImg
                int rowIndex = dgvPicture.Rows.Add();
                dgvPicture.Rows[rowIndex].Cells["dgvImg"].Value = img;

                // lưu tạm ImageId vào Tag để dùng khi xóa (nếu cần)
                dgvPicture.Rows[rowIndex].Tag = pic.ImageId;
            }
        }


        // load dữ liệu vào combobox
        private void LoadComboBox()
        {
            cbCatetegory.DataSource = context.Categories.ToList();
            cbCatetegory.DisplayMember = "CategoryName";
            cbCatetegory.ValueMember = "CategoryId";
            cbNXB.DataSource = context.Publishers.ToList();
            cbNXB.DisplayMember = "PublisherName";
            cbNXB.ValueMember = "PublisherId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //add/ sửa sách + quản lý ảnh
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate dữ liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập giá!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (
             cbCatetegory.SelectedValue == null
             || cbNXB.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đủ Thể loại, Tác giả, NXB!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Thêm mới hoặc Sửa (header sách)
                Books bookEntity;

                if (BookId == null) // THÊM MỚI
                {
                    bookEntity = new Books
                    {
                        Title = txtName.Text.Trim(),
                        Price = decimal.Parse(txtPrice.Text),
                        Description = txtDesc.Text.Trim(),
                        CategoryId = (int)cbCatetegory.SelectedValue,
                        AuthorName = txtAuthor.Text.Trim(),
                        PublisherId = (int)cbNXB.SelectedValue,
                        // Nếu bạn vẫn muốn lưu cover cũ ở cột ImageUrl, gán selectedImageFileName
                        ImageUrl = selectedImageFileName,
                        IsVisible = !Hide.Checked // nếu check "ẩn" thì Visible = false
                    };
                    context.Books.Add(bookEntity);
                }
                else // SỬA
                {
                    bookEntity = context.Books.Find(BookId.Value);
                    if (bookEntity == null)
                    {
                        MessageBox.Show("Không tìm thấy sách để sửa!", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật các thông tin cơ bản
                    bookEntity.Title = txtName.Text.Trim();
                    bookEntity.Price = decimal.Parse(txtPrice.Text);
                    bookEntity.Description = txtDesc.Text.Trim();
                    bookEntity.CategoryId = (int)cbCatetegory.SelectedValue;
                    bookEntity.AuthorName = txtAuthor.Text.Trim();
                    bookEntity.PublisherId = (int)cbNXB.SelectedValue;
                    bookEntity.ImageUrl = selectedImageFileName;
                    bookEntity.IsVisible = !Hide.Checked;

                }

                // 3. Lưu để có BookId nếu là thêm mới
                context.SaveChanges();


                // 4. Xử lý ảnh chi tiết (BookImages)
                // 4.0. Lấy toàn bộ ảnh cũ (nếu có) của cuốn sách này từ DB
                var existingPics = context.BookImages
                                          .Where(pi => pi.BookId == bookEntity.BookId)
                                          .ToList();

                // 4.1. Tập hợp những ImageId (int) hiện có trên DataGridView (tag=int)
                var keepIds = dgvPicture.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Tag is int)
                    .Select(r => (int)r.Tag)
                    .ToList();

                // 4.2. Những ảnh cũ mà người dùng đã gỡ khỏi grid, nghĩa là
                //      “các record BookImages có ImageId không nằm trong keepIds”
                var toDelete = existingPics
                    .Where(pi => !keepIds.Contains(pi.ImageId))
                    .ToList();

                if (toDelete.Any())
                {
                    // Xóa record khỏi EF
                    context.BookImages.RemoveRange(toDelete);
                }

                // 4.3. Thêm những ảnh mới (tag là string: filename do server cấp hoặc local)
                foreach (DataGridViewRow row in dgvPicture.Rows)
                {
                    if (row.Tag is string newFileName)
                    {
                        // Tạo đối tượng mới và add vào EF
                        context.BookImages.Add(new BookImages
                        {
                            BookId = bookEntity.BookId,
                            ImageUrl = newFileName
                        });
                    }
                }

                // 5. Lưu lại các thay đổi về ảnh
                context.SaveChanges();

                // 6. Kết thúc: thông báo thành công và đóng form
                MessageBox.Show("Lưu thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nếu parent cần biết form đóng với kết quả OK:
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //thêm ảnh vào dgv
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png; *.webp)|*.jpg;*.jpeg;*.png;*.webp",
                Multiselect = true
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                dgvPicture.RowTemplate.Height = 100;
                string localFolder = Path.Combine(Application.StartupPath, "Images");
                Directory.CreateDirectory(localFolder);

                foreach (var src in ofd.FileNames)
                {
                    string destName = Path.GetFileName(src);
                    string localPath = Path.Combine(localFolder, destName);
                    // 2. Nếu file chưa tồn tại trên disk, copy vào.
                    //    Nếu đã có (hoặc đang bị lock), ta không copy nhưng KHÔNG NGẮT LUỒNG
                    if (!File.Exists(localPath))
                    {
                        try
                        {
                            File.Copy(src, localPath);
                        }
                        catch (IOException)
                        {
                            // Nếu bị lock, không copy được, ta vẫn tiếp tục để load ảnh ở bước sau (nếu file trên disk đã có).
                            // Nếu muốn, có thể log thêm để debug.
                        }
                    }

                    // 3. Kiểm tra xem trong dgvPicture hiện tại đã có bản ghi với destName này chưa.
                    //    (Ta lưu destName vào Tag của row nên có thể dùng để compare)
                    bool daTonTaiTrongDGV = false;
                    foreach (DataGridViewRow row in dgvPicture.Rows)
                    {
                        if (row.Tag != null && row.Tag.ToString().Equals(destName, StringComparison.OrdinalIgnoreCase))
                        {
                            daTonTaiTrongDGV = true;
                            break;
                        }
                    }
                    if (daTonTaiTrongDGV)
                    {
                        // Nếu đã tồn tại ảnh cùng tên trong DGV, skip tiếp để không add 2 lần cho cùng 1 cuốn
                        continue;
                    }

                    //  Upload lên web để lấy fileName do server trả về 
                    string uploadedFileName = await UploadImageToWebAsync(localPath);
                    // uploadedFileName có thể là null nếu upload fail

                    // Load thumbnail vào DataGridView
                    Image thumbnail = LoadImageToDgv(localPath);
                    if (thumbnail == null)
                        continue;

                    int rowIndex = dgvPicture.Rows.Add();
                    dgvPicture.Rows[rowIndex].Cells["dgvImg"].Value = thumbnail;

                    // Lưu tag để phân biệt:
                    // Nếu upload thành công, lưu tên file trên server (uploadedFileName);
                    // còn không, lưu tên file local (destName) để về sau có thể xử lý.
                    if (!string.IsNullOrEmpty(uploadedFileName))
                        dgvPicture.Rows[rowIndex].Tag = uploadedFileName; // tên file do server cấp
                    else
                        dgvPicture.Rows[rowIndex].Tag = destName;        // fallback: file local
                }
            }
        }


        // Tải ảnh lên web
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
                // Lỗi kết nối, DNS fail, timeout…
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
                // Bất kỳ lỗi nào khác
                MessageBox.Show(
                    "Đã xảy ra lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

        //Load ảnh có định đạng webp
        private Image LoadImageToDgv(string path)
        {
            try
            {
                string ext = Path.GetExtension(path).ToLower();

                if (ext == ".webp")
                {
                    // Dùng Magick.NET để decode WebP thành Bitmap
                    using (var image = new MagickImage(path))
                    using (var ms = new MemoryStream())
                    {
                        image.Format = MagickFormat.Bmp;  // chuyển sang BMP để GDI+ hiểu
                        image.Write(ms);
                        ms.Position = 0;
                        return new Bitmap(ms);
                    }
                }
                else
                {
                    // Định dạng jpg/png bình thường: load qua FileStream để tránh lock file
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, show thông báo và trả về null (không crash)
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message,
                                "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void dgvPicture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu user click vào nút Xóa (cột dgvDel)
            if (dgvPicture.Columns[e.ColumnIndex].Name == "dgvDel" && e.RowIndex >= 0)
            {
                // Lấy row được click
                var row = dgvPicture.Rows[e.RowIndex];

                // Tag có thể là int (imageId) hoặc string (fileName mới)
                if (row.Tag is int imageId)
                {
                    // --- 1. Xóa record BookImages khỏi DB
                    var picEntity = context.BookImages.Find(imageId);
                    if (picEntity != null)
                    {
                        context.BookImages.Remove(picEntity);
                        context.SaveChanges();
                    }
                    // Sau khi xóa DB xong, ta tiếp tục remove row khỏi dgv
                    dgvPicture.Rows.RemoveAt(e.RowIndex);
                }
                else if (row.Tag is string newFileName)
                {
                    // --- 2. Ảnh mới chưa lưu DB → chỉ việc remove row khỏi dgv
                    dgvPicture.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    // Trường hợp Tag = null hoặc kiểu khác, ta vẫn remove row
                    dgvPicture.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
