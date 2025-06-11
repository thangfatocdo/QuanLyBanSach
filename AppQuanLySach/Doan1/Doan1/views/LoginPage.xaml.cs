using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Doan1.views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = txtUsername.Text?.Trim();
        string password = txtPassword.Text?.Trim();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin", "OK");
            return;
        }

        try
        {
            using var client = new HttpClient();
            var url = "https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/login";

            var data = new
            {
                username = username,
                password = password
            };

            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                // Ví dụ server trả về tên người dùng, bạn có thể xử lý như sau
                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LoginResult>(responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                await SecureStorage.SetAsync("user_token", result.userId.ToString());
                await SecureStorage.SetAsync("user_fullname", result.fullName ?? "User");
                await SecureStorage.SetAsync("user_imageurl", result.imageUrl ?? "");
                // Chuyển sang trang chính
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Thất bại", "Sai thông tin đăng nhập", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Lỗi", ex.Message, "OK");
        }
    }

    public class LoginResult
    {
        public int userId { get; set; }
        public string fullName { get; set; }
        public string imageUrl { get; set; } // thêm dòng này
    }
}
