using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SortingVisualizer.Models.Algorithms;

public abstract partial class SortAlgorithmBase : ObservableObject
{ 
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract string TimeComplexity { get; }
    public abstract string SpaceComplexity { get; }
    
    [ObservableProperty] private bool _isSelected = false;

    public abstract Task Sort(ISortingContext context);

    protected async Task SwapAsync(ISortingContext context, int a, int b)
    {
        context.Array[a].Color = SortingBar.ReplaceColor;
        context.Array[b].Color = SortingBar.ReplaceColor;

        await Task.Delay(context.Delay);
        
        context.IncrementSwaps();
        (context.Array[a].Value, context.Array[b].Value) = (context.Array[b].Value, context.Array[a].Value);
    }

    protected async Task<int> CompareAsync(ISortingContext context, int a, int b)
    {
        context.Array[a].Color = SortingBar.CompareColor;
        context.Array[b].Color = SortingBar.CompareColor;

        await Task.Delay(context.Delay);
        
        context.IncrementCompares();
        return context.Array[a].CompareTo(context.Array[b]);
    }

    protected void PaintArraySection(ISortingContext context, int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            context.Array[i].Color = SortingBar.SortedColor;
        }
    }
}