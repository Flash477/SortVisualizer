using System.Threading.Tasks;
using SortingVisualizer.ViewModels;

namespace SortingVisualizer.Models.Algorithms;

public class BubbleSort : SortAlgorithmBase
{
    public override string Name => "Пузырьковая";

    public override async Task Sort(SortingViewModel vm)
    {
        for (int i = 0; i < vm.ArraySize - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < vm.ArraySize - i - 1; j++)
            {
                vm.Array[j].Color = SortingBar.CompareColor;
                vm.Array[j + 1].Color = SortingBar.CompareColor;

                if (vm.Array[j].Value > vm.Array[j + 1].Value)
                {
                    vm.Array[j].Color = SortingBar.ReplaceColor;
                    vm.Array[j + 1].Color = SortingBar.ReplaceColor;

                    await Task.Delay(vm.Delay);

                    (vm.Array[j].Value, vm.Array[j+1].Value) = (vm.Array[j+1].Value, vm.Array[j].Value);
                    swapped = true;
                }

                await Task.Delay(vm.Delay);

                vm.Array[j].Color = SortingBar.StandardColor;
                vm.Array[j+1].Color = SortingBar.StandardColor;
            }

            vm.Array[vm.ArraySize - i - 1].Color = SortingBar.SortedColor;

            if (!swapped)
            {
                for (int j = 0; j < vm.ArraySize - i - 1; j++)
                {
                    vm.Array[j].Color = SortingBar.SortedColor;
                }
                break;
            }
        }
    }
}