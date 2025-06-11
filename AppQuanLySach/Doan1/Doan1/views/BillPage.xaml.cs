namespace Doan1.views;

public partial class BillPage : ContentPage
{
    public BillPage()
    {
        InitializeComponent();

        BindingContext = new ViewModels.BillViewModel();
    }
}