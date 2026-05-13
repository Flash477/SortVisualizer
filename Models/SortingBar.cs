using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SortingVisualizer.Models;

public partial class SortingBar : ObservableObject
{
    [ObservableProperty] private int _value;
    [ObservableProperty] private ISolidColorBrush _color;

    public SortingBar(int value)
    {
        Value = value;
        Color = Brushes.Aquamarine;
    }
}