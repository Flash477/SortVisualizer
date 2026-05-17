using System.Threading.Tasks;

namespace SortingVisualizer.Models.Algorithms;

public class OddEventSort : SortAlgorithmBase
{
    public override string Name => "Сортировка \"чёт-нечёт\"";
    public override string Description =>
        "Упорядочивает элементы попарно сравнивая соседние элементы на четных и нечетных позициях внутри 1 цикла\n" +
        "Рекомендуется большой размер массива и короткая задержка для лучшей визуализации";
    public override string TimeComplexity => "O(n²)";
    public override string SpaceComplexity => "O(1)";
    public override async Task Sort(ISortingContext context)
    {
        bool sorted;
        while (true)
        {
            sorted = true;
            
            for (int j = 0; j < context.Array.Count-1; j+=2)
            {
                if (await CompareAsync(context, j, j + 1) > 0)
                {
                    sorted = false;
                    await SwapAsync(context, j, j + 1);
                }

                context.Array[j].Color = SortingBar.StandardColor;
                context.Array[j+1].Color = SortingBar.StandardColor;
            }
            
            for (int j = 1; j < context.Array.Count-1; j+=2)
            {
                if (await CompareAsync(context, j, j + 1) > 0)
                {
                    sorted = false;
                    await SwapAsync(context, j, j + 1);
                }
                
                context.Array[j].Color = SortingBar.StandardColor;
                context.Array[j+1].Color = SortingBar.StandardColor;
            }

            if (sorted)
            {
                PaintArraySection(context, SortingBar.SortedColor, 0, context.Array.Count-1);
                break;
            }
        }
    }
}