using System.Collections.ObjectModel;

namespace SortingVisualizer.Models;

public interface ISortingContext
{
    public ObservableCollection<SortingBar> Array { get; }
    public int Delay { get; }
}