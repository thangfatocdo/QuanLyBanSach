using Doan1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

namespace Doan1.ViewModels;

public class BillViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Bill> _bills;
    private string _totalAmount;
    private int _billCount;
    private DateTime _selectedDate;
    private bool _isRefreshing;
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set { _isRefreshing = value; OnPropertyChanged(); }
    }

    public ObservableCollection<Bill> Bills
    {
        get => _bills;
        set
        {
            _bills = value;
            OnPropertyChanged();
            UpdateTotals();
        }
    }

    public string TotalAmount
    {
        get => _totalAmount;
        set { _totalAmount = value; OnPropertyChanged(); }
    }

    public int BillCount
    {
        get => _billCount;
        set { _billCount = value; OnPropertyChanged(); }
    }
    public ICommand RefreshCommand { get; }
    // Chỉ giữ lại command duy nhất để mở trang chi tiết
    public ICommand ShowDetailCommand { get; }
    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set { _isLoading = value; OnPropertyChanged(); }
    }
    public BillViewModel()
    {
        Bills = new ObservableCollection<Bill>();
        SelectedDate = DateTime.Today;
        // Khởi tạo command xem chi tiết
        ShowDetailCommand = new Command<string>(async (billId) =>
        {
            await Shell.Current.GoToAsync($"BillDetailPage?billId={billId}");
        });

        RefreshCommand = new Command(async () =>
        {
            IsRefreshing = true;
            await LoadBillsAsync();
            IsRefreshing = false;
        });

        // Tải dữ liệu lên
        _ = LoadBillsAsync();
    }

    private async Task LoadBillsAsync()
    {
        try
        {
            IsLoading = true;
            var httpClient = new HttpClient();
            string apiUrl = "https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/orders";

            var response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                // Giả sử API trả về kiểu MobileOrder
                var mobileOrders = JsonSerializer.Deserialize<List<MobileOrder>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                var selectedDateOnly = SelectedDate.Date;
                // Chuyển đổi sang Bill (sử dụng OrderId làm BillId)
                var bills = mobileOrders.Where(o => o.OrderDate.Value.Date == selectedDateOnly)
                    .Select(o => new Bill
                    {
                        BillId = o.OrderId.ToString(),
                        Date = (DateTime)o.OrderDate,         // Giả sử API trả về OrderDate
                        Amount = (int)o.TotalPrice,
                        CustomerName = o.CustomerName, // Nếu bạn muốn hiển thị, có thể bind thêm
                        StatusName = o.StatusName
                    })
                    .OrderByDescending(b => b.Date)
                    .ToList();

                Bills = new ObservableCollection<Bill>(bills);
            }
            else
            {
                await Shell.Current.DisplayAlert("Lỗi", "Không tải được dữ liệu từ server", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Lỗi", ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void UpdateTotals()
    {
        // Chỉ tính tổng tiền của đơn KHÔNG bị hủy
        var validBills = Bills.Where(b => b.StatusName != "Đã hủy");
        TotalAmount = validBills.Sum(b => b.Amount).ToString("N0");
        BillCount = validBills.Count();
    }
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                OnPropertyChanged();
                _ = LoadBillsAsync(); // Tự động reload đơn theo ngày mới
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


}