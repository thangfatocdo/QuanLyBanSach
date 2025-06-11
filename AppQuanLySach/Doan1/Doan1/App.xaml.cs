using Doan1.views;
using Microsoft.Extensions.Logging;
using OneSignalSDK.DotNet;

namespace Doan1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set splash page đầu tiên
            MainPage = new views.SplashPage();

            // Khởi động app sau delay
            _ = LoadAppAsync();
            OneSignal.Initialize("983fb972-1c5f-4bbd-8911-1bdd6c79c396");
            OneSignal.Notifications.RequestPermissionAsync(fallbackToSettings: true);
        }

        private async Task LoadAppAsync()
        {
            // 1. Giữ Splash 2 giây
            await Task.Delay(2000);

            // 2. Kiểm tra xem đã có token hay chưa
            string savedToken = null;
            try
            {
                savedToken = await SecureStorage.GetAsync("user_token");
            }
            catch
            {
                // Nếu SecureStorage gặp lỗi (ví dụ thiết bị không hỗ trợ),
                // bạn có thể fallback sang Preferences:
                // savedToken = Preferences.Get("user_token", string.Empty);
            }

            // 3. Nếu đã tồn tại token (không rỗng), vào thẳng AppShell
            if (!string.IsNullOrEmpty(savedToken))
            {
                MainPage = new AppShell();
            }
            else
            {
                // 4. Chưa login hoặc token rỗng → mở LoginPage
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }

}
