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
                if (await CompareAsync(context, j, j + 1) > 0)
                {
                    await SwapAsync(context, j, j + 1);
                    swapped = true;
                }
                
                context.Array[j].Color = SortingBar.StandardColor;
                context.Array[j + 1].Color = SortingBar.StandardColor;

                await Task.Delay(context.Delay); 
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