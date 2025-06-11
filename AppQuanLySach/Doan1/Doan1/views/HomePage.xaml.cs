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

    }

    public void DropdownButton_Clicked(object sender, EventArgs e)
    {
        DayPicker.Focus();
    }
}