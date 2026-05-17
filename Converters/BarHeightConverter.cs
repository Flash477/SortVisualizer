using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace SortingVisualizer.Converters;

public class BarHeightConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count >= 2 && values[0] is int value && values[1] is int maxValue)
        {
            return (double) value / maxValue;
        }

        return 0.0;
    }
}