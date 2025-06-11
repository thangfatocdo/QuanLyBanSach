using Doan1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace Doan1.ViewModels;

public class BillDetailViewModel : INotifyPropertyChanged
{
    private string _billId;
    private DateTime _date;
    private int _amount;
    private string _selectedStatus;
    private string _customerName;
    private string _phone;
    private string _address;
    private string _paymentMethod;
    private ObservableCollection<OrderItemDto> _items;

    public string BillId
    {
        get => _billId;
        set { _billId = value; OnPropertyChanged(); }
    }

    public DateTime Date
    {
        get => _date;
        set { _date = value; OnPropertyChanged(); }
    }

    public int Amount
    {
        get => _amount;
        set { _amount = value; OnPropertyChanged(); }
    }

    public string SelectedStatus
    {
        get => _selectedStatus;
        set { _selectedStatus = value; OnPropertyChanged(); }
    }

    public string CustomerName
    {
        get => _customerName;
        set { _customerName = value; OnPropertyChanged(); }
    }

    public string Phone
    {
        get => _phone;
        set { _phone = value; OnPropertyChanged(); }
    }

    public string Address
    {
        get => _address;
        set { _address = value; OnPropertyChanged(); }
    }
    public string PaymentMethod
    {
        get => _paymentMethod;
        set { _paymentMethod = value; OnPropertyChanged(); }
    }

    public ObservableCollection<OrderItemDto> Items
    {
        get => _items;
        set { _items = value; OnPropertyChanged(); }
    }

    public ICommand SaveCommand { get; }

    public BillDetailViewModel()
    {
        Items = new ObservableCollection<OrderItemDto>();
        SaveCommand = new Command(async () => await SaveAsync());
        Items = new ObservableCollection<OrderItemDto>();
    }

    private async Task SaveAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            var url = $"https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/orders/{BillId}/status";

            var body = new
            {
                NewStatus = SelectedStatus
            };

            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Thành công", "Đã cập nhật trạng thái", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync();
                await Shell.Current.DisplayAlert("Lỗi", $"Cập nhật thất bại\n{err}", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Lỗi", ex.Message, "OK");
        }
    }
    public async Task LoadDetailAsync(string billId)
    {
        var httpClient = new HttpClient();
        var url = $"https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/orders/{billId}";
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var detail = JsonSerializer.Deserialize<OrderDetailDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (detail != null)
            {
                BillId = detail.OrderId.ToString();
                Date = detail.OrderDate;
                Amount = (int)detail.TotalPrice;
                SelectedStatus = detail.StatusName;
                CustomerName = detail.CustomerName;
                Phone = detail.Phone;
                Address = detail.Address;
                PaymentMethod = detail.MethodName;
                Items = new ObservableCollection<OrderItemDto>(detail.Items);
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Lỗi", "Không lấy được chi tiết đơn", "OK");
        }
    }
    public ObservableCollection<string> StatusList { get; } = new ObservableCollection<string>
    {
        "Chờ duyệt",
        "Đã duyệt",
        "Đang giao",
        "Đã giao",
        "Đã hủy",
        "Trả hàng"
    };

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string StatusName { get; set; }
        public string CustomerName { get; set; }
        public string MethodName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public string Title { get; set; }
        public decimal BookPrice { get; set; }
        public int BookQuantity { get; set; }
        public int LineTotal => (int)(BookPrice * BookQuantity);
    }
}
