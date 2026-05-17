using System.Collections.ObjectModel;
using System.Threading;

namespace SortingVisualizer.Models;

public interface ISortingContext
{
    public ObservableCollection<SortingBar> Array { get; set; }
    public int Delay { get; }
    public CancellationToken SortingCts { get; }
    public bool IsSortAvailable { get; }

    public void IncrementSwaps();
    public void IncrementCompares();
}