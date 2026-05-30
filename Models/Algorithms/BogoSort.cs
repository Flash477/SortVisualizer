using System.Threading.Tasks;

namespace SortingVisualizer.Models.Algorithms;

public class BogoSort : SortAlgorithmBase
{
    public override string Name => "Болотная сортировка";

    public override string Description =>
        "Случайно перетасовывает массив до тех пор, пока элементы не выстроятся по порядку";

    public override string TimeComplexity => "n ✕ n!";
    public override string SpaceComplexity => "1";

    public override async Task Sort(ISortingContext context)
    {
        bool swapped;
        
        while (true)
        {
            swapped = false;
            for (int i = 0; i < context.Array.Count-1; i++)
            {
                if (await CompareAsync(context, i, i + 1) > 0)
                {
                    PaintArraySection(context, SortingBar.StandardColor, 0, i);
                    swapped = true;
                    break;
                }

                context.Array[i].Color = SortingBar.SortedColor;

                await Task.Delay(context.Delay, context.SortingCts);
            }

            if (!swapped)
            {
                context.Array[^1].Color = SortingBar.SortedColor;
                break;
            }

            ShuffleArray(context);
            await Task.Delay(context.Delay, context.SortingCts);
        }
    }
}