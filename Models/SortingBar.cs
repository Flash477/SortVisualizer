using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SortingVisualizer.Models;

public partial class SortingBar : ObservableObject
{
    public static readonly IBrush StandardColor = Brushes.Aquamarine;
    public static readonly IBrush SortedColor = Brushes.LightGreen;
    public static readonly IBrush CompareColor = Brushes.LightCoral;
    public static readonly IBrush ReplaceColor = Brushes.MediumSlateBlue;
    
    [ObservableProperty] private int _value;
    [ObservableProperty] private IBrush _color;
    
    public SortingBar(int value)
    {
        Value = value;
        Color = StandardColor;
    }
}