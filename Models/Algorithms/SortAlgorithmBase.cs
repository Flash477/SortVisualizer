using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SortingVisualizer.Models.Algorithms;

public abstract partial class SortAlgorithmBase : ObservableObject
{ 
    public abstract string Name { get; }
    [ObservableProperty] private bool _isSelected = false;

    public abstract Task Sort(ISortingContext context);

    protected async Task SwapAsync(ISortingContext context, int a, int b)
    {
        context.Array[a].Color = SortingBar.ReplaceColor;
        context.Array[b].Color = SortingBar.ReplaceColor;

        await Task.Delay(context.Delay);

        (context.Array[a].Value, context.Array[b].Value) = (context.Array[b].Value, context.Array[a].Value);
    }

    protected async Task<int> CompareAsync(ISortingContext context, int a, int b)
    {
        context.Array[a].Color = SortingBar.CompareColor;
        context.Array[b].Color = SortingBar.CompareColor;

        await Task.Delay(context.Delay);
        
        return context.Array[a].CompareTo(context.Array[b]);
    }
}