using System;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SortingVisualizer.Models;

public partial class SortingBar : ObservableObject, IComparable<SortingBar>
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

    public int CompareTo(SortingBar? other)
    {
        return other is null ? 1 : Value.CompareTo(other.Value);
    }
}