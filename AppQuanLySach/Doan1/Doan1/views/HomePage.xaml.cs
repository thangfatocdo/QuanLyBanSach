using Doan1.ViewModels;
using static Doan1.ViewModels.DashboardViewModel;

namespace Doan1.views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        BindingContext = new ViewModels.DashboardViewModel();
    }

    public void OnTabClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && BindingContext is DashboardViewModel vm)
        {
            // 1. Đổi màu cho cả ba nút
            foreach (var child in ((HorizontalStackLayout)btn.Parent).Children.OfType<Button>())
            {
                bool isSelected = child == btn;
                child.BackgroundColor = isSelected ? Color.FromArgb("#D9F1FF") : Colors.Transparent;
                child.TextColor = isSelected ? Color.FromArgb("#007AFF") : Colors.Gray;
            }

            // 2. Cập nhật ViewModel
            if (Enum.TryParse(btn.CommandParameter?.ToString(), out DashboardViewModel.TimeRange range))
                vm.SelectedTimeRange = range;
        }
    }

}