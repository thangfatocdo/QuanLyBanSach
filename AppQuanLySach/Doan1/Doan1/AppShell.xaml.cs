namespace Doan1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // Đăng ký route cho trang BillDetailPage
        Routing.RegisterRoute("BillDetailPage", typeof(views.BillDetailPage));
    }
}