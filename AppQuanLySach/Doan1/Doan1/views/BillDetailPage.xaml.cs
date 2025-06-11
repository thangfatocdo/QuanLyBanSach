using System;
using Doan1.ViewModels;
using Microsoft.Maui.Controls;

namespace Doan1.views
{
    // Shell sẽ tự set property BillId từ query parameter "billId"
    [QueryProperty(nameof(BillId), "billId")]
    public partial class BillDetailPage : ContentPage
    {
        public BillDetailPage()
        {
            InitializeComponent();
            BindingContext = new BillDetailViewModel();
        }

        // backing field
        private string _billId;
        public string BillId
        {
            get => _billId;
            set
            {
                _billId = Uri.UnescapeDataString(value);
                // Gọi hàm async riêng để tải dữ liệu
                LoadBillDetail(_billId);
            }
        }

        // Phải dùng async void để await LoadDetailAsync
        private async void LoadBillDetail(string billId)
        {
            if (BindingContext is BillDetailViewModel vm)
            {
                await vm.LoadDetailAsync(billId);
            }
        }

        // Nếu bạn dùng nút back trong XAML với Clicked="OnBackClicked"
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
