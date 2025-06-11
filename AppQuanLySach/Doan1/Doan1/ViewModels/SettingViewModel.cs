using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Doan1.ViewModels;

public partial class SettingViewModel : ObservableObject
{
    [ObservableProperty]
    private string fullName = "User";   // giá trị mặc định
    [ObservableProperty]
    private string imageUrl;
    public SettingViewModel()
    {
        _ = LoadUserAsync();
        // … (các phần OrderItems, SaveCommand… giữ nguyên)
    }

    private async Task LoadUserAsync()
    {
        var name = await SecureStorage.GetAsync("user_fullname");
        var avatar = await SecureStorage.GetAsync("user_imageurl");

        if (!string.IsNullOrWhiteSpace(name))
            FullName = name;

        ImageUrl = string.IsNullOrWhiteSpace(avatar)
                   ? "default_avatar.png"
                   : (avatar.StartsWith("http") ? avatar
                      : $"https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/Images/{avatar}");
    }
}