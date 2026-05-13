using System.Threading.Tasks;
using SortingVisualizer.ViewModels;

namespace SortingVisualizer.Models.Algorithms;

public abstract class SortAlgorithmBase
{ 
    public abstract string Name { get; }

    public abstract Task Sort(SortingViewModel vm);
}