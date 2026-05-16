using System.Threading.Tasks;

namespace SortingVisualizer.Models.Algorithms;

public class ShakerSort : SortAlgorithmBase
{
    public override string Name => "Шейкерная сортировка";

    public override string Description =>
        "Проходит массив в обе стороны, двигая наименьшие элементы в начало, а наибольшие в конец";
    public override string TimeComplexity => "O(n²)";
    public override string SpaceComplexity => "O(1)";
    
    public override async Task Sort(ISortingContext context)
    {
        int left = 0;
        int right = context.Array.Count-1;
        bool swapped;
        
        while (left < right)
        {
            swapped = false;
            
            for (int i = left; i < right; i++)
            {
                if (await CompareAsync(context, i, i + 1) > 0)
                {
                    await SwapAsync(context, i, i + 1);
                    swapped = true;
                }
                
                context.Array[i].Color = SortingBar.StandardColor;
                context.Array[i + 1].Color = SortingBar.StandardColor;

                await Task.Delay(context.Delay, context.SortingCts); 
            }
            
            context.Array[right].Color = SortingBar.SortedColor;
            
            if (!swapped)
            {
                PaintArraySection(context, SortingBar.SortedColor, left, right);
                break;
            }
            
            right--;
            swapped = false;
            
            for (int i = right; i > left; i--)
            {
                if (await CompareAsync(context, i, i - 1) < 0)
                {
                    await SwapAsync(context, i, i - 1);
                    swapped = true;
                }
                
                context.Array[i].Color = SortingBar.StandardColor;
                context.Array[i - 1].Color = SortingBar.StandardColor;

                await Task.Delay(context.Delay, context.SortingCts); 
            }
            
            context.Array[left].Color = SortingBar.SortedColor;
            
            if (!swapped)
            {
                PaintArraySection(context, SortingBar.SortedColor, left, right);
                break;
            }
            
            left++;
        }
    }
}