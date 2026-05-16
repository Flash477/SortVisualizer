using System.Collections.ObjectModel;
using System.Threading;

namespace SortingVisualizer.Models;

public interface ISortingContext
{
    public ObservableCollection<SortingBar> Array { get; }
    public int Delay { get; }
    public CancellationToken SortingCts { get; }

    public void IncrementSwaps();
    public void IncrementCompares();
}