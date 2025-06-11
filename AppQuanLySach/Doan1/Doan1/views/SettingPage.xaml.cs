using Doan1.ViewModels;

namespace Doan1.views;

public partial class SettingPage : ContentPage
{
    public SettingPage()
    {
        InitializeComponent();
        BindingContext = new SettingViewModel();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool ok = await DisplayAlert("Xác nhận", "Bạn có chắc muốn đăng xuất?", "Đăng xuất", "Huỷ");
        if (!ok) return;

        SecureStorage.Remove("user_token");
        SecureStorage.Remove("user_name");
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}
