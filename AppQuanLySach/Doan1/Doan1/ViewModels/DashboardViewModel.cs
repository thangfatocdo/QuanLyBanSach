using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using SkiaSharp;

namespace Doan1.ViewModels;

public partial class DashboardViewModel : ObservableObject
{

    [ObservableProperty]
    private Chart revenueChart;


    public DashboardViewModel()
    {
        RevenueChart = new BarChart
        {
            Entries = new[]
            {
                new ChartEntry(100) { Label = "T2", ValueLabel = "100", Color = SKColor.Parse("#3498db") },
                new ChartEntry(80) { Label = "T3", ValueLabel = "80", Color = SKColor.Parse("#3498db") },
                new ChartEntry(120) { Label = "T4", ValueLabel = "120", Color = SKColor.Parse("#3498db") },
                new ChartEntry(90) { Label = "T5", ValueLabel = "90", Color = SKColor.Parse("#3498db") },
                new ChartEntry(110) { Label = "T6", ValueLabel = "110", Color = SKColor.Parse("#3498db") },
                new ChartEntry(70) { Label = "T7", ValueLabel = "70", Color = SKColor.Parse("#3498db") },
                new ChartEntry(50) { Label = "CN", ValueLabel = "50", Color = SKColor.Parse("#3498db") },
            },
            LabelTextSize = 28,
            ValueLabelOrientation = Orientation.Vertical,
            LabelOrientation = Orientation.Horizontal
        };
    }
}