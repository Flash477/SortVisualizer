using System.Threading.Tasks;

namespace SortingVisualizer.Models.Algorithms;

public class BubbleSort : SortAlgorithmBase
{
    public override string Name => "Пузырьковая сортировка";
    public override string Description => "Сравнивает пары соседних элементов, поднимая самые большие к концу массива";
    public override string TimeComplexity => "n²";
    public override string SpaceComplexity => "1";

    public override async Task Sort(ISortingContext context)
    {
        for (int i = 0; i < context.Array.Count - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < context.Array.Count - i - 1; j++)
            {
                if (await CompareAsync(context, j, j + 1) > 0)
                {
                    await SwapAsync(context, j, j + 1);
                    swapped = true;
                }
                
                context.Array[j].Color = SortingBar.StandardColor;
                context.Array[j + 1].Color = SortingBar.StandardColor;

                await Task.Delay(context.Delay, context.SortingCts); 
            }

            context.Array[context.Array.Count - i - 1].Color = SortingBar.SortedColor;

            if (!swapped)
            {
                PaintArraySection(context, SortingBar.SortedColor, 0, context.Array.Count - i - 1);
                break;
            }
        }
    }
}