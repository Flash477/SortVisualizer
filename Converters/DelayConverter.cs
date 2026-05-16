using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace SortingVisualizer.Converters;

public class DelayConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count >= 1 && values[0] is int delay)
        {
            return new TimeSpan(0, 0, 0, 0, delay/2);
        }

        return new TimeSpan(0);
    }
}