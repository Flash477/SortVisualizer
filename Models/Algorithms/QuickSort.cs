using System.Threading.Tasks;

namespace SortingVisualizer.Models.Algorithms;

public class QuickSort : SortAlgorithmBase
{
    public override string Name => "Быстрая сортировка";

    public override string Description =>
        "Делит массив на две части, больше и меньше опорного элемента, а затем рекурсивно сортирует каждую из них";

    public override string TimeComplexity => "n log₂(n)";
    public override string SpaceComplexity => "n";

    public override async Task Sort(ISortingContext context)
    {
        await QuickSortRecursive(context, 0, context.Array.Count - 1);
    }

    private async Task QuickSortRecursive(ISortingContext context, int left, int right)
    {
        if (left >= right)
        {
            if (left == right)
            {
                context.Array[left].Color = SortingBar.SortedColor;
            }
            return;
        }
        
        int pivot = await Partition(context, left, right);
    
        await QuickSortRecursive(context, left, pivot);
        await QuickSortRecursive(context, pivot + 1, right);
    }

    private async Task<int> Partition(ISortingContext context, int left, int right)
    {
        int l = left;
        int r = right;
        int pivotIndex = left + (right - left) / 2;

        while (true)
        {
            context.IncrementCompares();
            while (await CompareAsync(context, l, pivotIndex) < 0)
            {
                context.Array[l].Color = SortingBar.StandardColor;
                l++;
            }
            context.Array[l].Color = SortingBar.StandardColor;
            
            context.IncrementCompares();
            while (await CompareAsync(context, r, pivotIndex) > 0)
            {
                context.Array[r].Color = SortingBar.StandardColor;
                r--;
            }
            context.Array[r].Color = SortingBar.StandardColor;

            if (l >= r)
            {
                context.Array[pivotIndex].Color = SortingBar.StandardColor;
                return r;
            }

            await SwapAsync(context, l, r);
            if (pivotIndex == l)
            {
                pivotIndex = r;
            } else if (pivotIndex == r)
            {
                pivotIndex = l;
            }
            context.Array[l].Color = SortingBar.StandardColor;
            context.Array[r].Color = SortingBar.StandardColor;
            l++;
            r--;
        }
    }
}