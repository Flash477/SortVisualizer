using System.Collections.Generic;
using System.Threading.Tasks;
using SortingVisualizer.ViewModels;

namespace SortingVisualizer.Models.Algorithms;

public class BubbleSort : SortAlgorithmBase
{
    public override string Name => "Пузырьковая";

    public override async Task Sort(ISortingContext context)
    {
        for (int i = 0; i < context.Array.Count - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < context.Array.Count - i - 1; j++)
            {
                context.Array[j].Color = SortingBar.CompareColor;
                context.Array[j + 1].Color = SortingBar.CompareColor;

                if (context.Array[j].Value > context.Array[j + 1].Value)
                {
                    context.Array[j].Color = SortingBar.ReplaceColor;
                    context.Array[j + 1].Color = SortingBar.ReplaceColor;

                    await Task.Delay(context.Delay);

                    (context.Array[j].Value, context.Array[j+1].Value) = (context.Array[j+1].Value, context.Array[j].Value);
                    swapped = true;
                }

                await Task.Delay(context.Delay);

                context.Array[j].Color = SortingBar.StandardColor;
                context.Array[j+1].Color = SortingBar.StandardColor;
            }

            context.Array[context.Array.Count - i - 1].Color = SortingBar.SortedColor;

            if (!swapped)
            {
                for (int j = 0; j < context.Array.Count - i - 1; j++)
                {
                    context.Array[j].Color = SortingBar.SortedColor;
                }
                break;
            }
        }
    }
}