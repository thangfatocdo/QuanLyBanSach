using CommunityToolkit.Mvvm.ComponentModel;
using Doan1.Models;
using Microcharts;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace Doan1.ViewModels;

public partial class DashboardViewModel : ObservableObject
{

    [ObservableProperty]
    private Chart revenueChart;
    [ObservableProperty] private int totalOrderCount;
    [ObservableProperty] private int uncompletedOrderCount;
    [ObservableProperty]
    private DateTime selectedDate = DateTime.Today;
    [ObservableProperty]
    private ObservableCollection<TopBookDto> topBooks = new();
    private bool _isRefreshing;
    public ICommand RefreshCommand { get; }
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set { _isRefreshing = value; OnPropertyChanged(); }
    }
    partial void OnSelectedDateChanged(DateTime value)
    {
        _ = LoadOrderSummaryForDateAsync(value);
    }
    public enum TimeRange
    {
        Week,
        Month,
        Year
    }

    [ObservableProperty]
    private TimeRange selectedTimeRange = TimeRange.Week;

    partial void OnSelectedTimeRangeChanged(TimeRange value)
    {
        _ = LoadRevenueChartAsync();
    }

    public DashboardViewModel()
    {
        _ = LoadRevenueChartAsync();
        _ = LoadOrderSummaryForDateAsync(SelectedDate);
        _ = LoadTopBooksAsync();
        RefreshCommand = new Command(async () =>
        {
            IsRefreshing = true;
            await LoadOrderSummaryForDateAsync(SelectedDate);
            await LoadTopBooksAsync(); // refresh luôn top sách
            IsRefreshing = false;
        });

    }
    private async Task LoadOrderSummaryForDateAsync(DateTime selectedDate)
    {
        try
        {
            var httpClient = new HttpClient();
            string apiUrl = "https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/orders";

            var response = await httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
                return;

            var json = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<MobileOrder>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Lọc đơn trong ngày đã chọn
            var dayOrders = orders.Where(o => o.OrderDate?.Date == selectedDate.Date).ToList();

            TotalOrderCount = dayOrders.Count;
            UncompletedOrderCount = dayOrders.Count(o => o.StatusName != "Hoàn thành" && o.StatusName != "Đã giao");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Lỗi", ex.Message, "OK");
        }
    }
    private async Task LoadTopBooksAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            string apiUrl = "https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/orders";

            var response = await httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
                return;

            var json = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<MobileOrder>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            int offset = ((int)DateTime.Today.DayOfWeek - 1 + 7) % 7;
            var startOfWeek = DateTime.Today.AddDays(-offset);
            var weekOrders = orders
                .Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Date >= startOfWeek)
                .ToList();

            var top = weekOrders
                .SelectMany(o => o.Items)
                .GroupBy(i => new { i.BookId, i.Title, i.ImageUrl })
                .Select(g => new TopBookDto
                {
                    Title = g.Key.Title,
                    ImageUrl = $"https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/Images/{g.Key.ImageUrl}",
                    TotalSold = g.Sum(x => x.BookQuantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(10)
                .ToList();

            TopBooks = new ObservableCollection<TopBookDto>(top);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Lỗi Top Sách", ex.Message, "OK");
        }
    }

    private async Task LoadRevenueChartAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            string apiUrl = "https://nhasachhaidang-evdte2g5b7ejbzfv.canadacentral-01.azurewebsites.net/api/appmobile/orders";

            var response = await httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
                return;

            var json = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<MobileOrder>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            DateTime startDate;
            int rangeLength;
            List<(DateTime Start, DateTime End, string Label, int Revenue)> revenueData;

            switch (SelectedTimeRange)
            {
                case TimeRange.Month:
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    rangeLength = 4; // 4 tuần trong tháng

                    revenueData = Enumerable.Range(0, 4).Select(i =>
                    {
                        var weekStart = startDate.AddDays(i * 7);
                        var weekEnd = weekStart.AddDays(6);
                        return (Start: weekStart, End: weekEnd, Label: $"Tuần {i + 1}", Revenue: 0);
                    }).ToList();
                    break;

                case TimeRange.Year:
                    startDate = new DateTime(DateTime.Today.Year, 1, 1);
                    rangeLength = 12;

                    revenueData = Enumerable.Range(0, 12).Select(i =>
                    {
                        var monthStart = new DateTime(startDate.Year, i + 1, 1);
                        var monthEnd = monthStart.AddMonths(1).AddDays(-1);
                        return (Start: monthStart, End: monthEnd, Label: $"T{i + 1}", Revenue: 0);
                    }).ToList();
                    break;

                default: // Week
                    int offset = (int)DateTime.Today.DayOfWeek - 1;
                    if (offset < 0) offset = 6; // Chủ nhật
                    startDate = DateTime.Today.AddDays(-offset);
                    rangeLength = 7;

                    revenueData = Enumerable.Range(0, 7).Select(i =>
                    {
                        var day = startDate.AddDays(i);
                        return (Start: day, End: day, Label: day.ToString("ddd"), Revenue: 0);
                    }).ToList();
                    break;
            }

            foreach (var order in orders.Where(o => o.OrderDate.HasValue))
            {
                var date = order.OrderDate.Value.Date;
                for (int i = 0; i < revenueData.Count; i++)
                {
                    if (date >= revenueData[i].Start && date <= revenueData[i].End)
                    {
                        revenueData[i] = (revenueData[i].Start, revenueData[i].End, revenueData[i].Label, revenueData[i].Revenue + (int)order.TotalPrice);
                        break;
                    }
                }
            }

            var entries = revenueData.Select(d => new ChartEntry(d.Revenue)
            {
                Label = d.Label,
                ValueLabel = d.Revenue.ToString("N0"),
                Color = SKColor.Parse("#3498db")
            }).ToArray();

            RevenueChart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 28,
                ValueLabelOrientation = Orientation.Vertical,
                LabelOrientation = Orientation.Horizontal
            };
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Lỗi", ex.Message, "OK");
        }
    }


}
public class TopBookDto
{
    public string Title { get; set; }
    public string ImageUrl { get; set; } // đường dẫn ảnh tuyệt đối
    public int TotalSold { get; set; }
}
