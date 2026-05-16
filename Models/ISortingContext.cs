using System.Collections.Generic;

namespace SortingVisualizer.Models;

public interface ISortingContext
{
    public IList<SortingBar> Array { get; }
    public int Delay { get; }
}