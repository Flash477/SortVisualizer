using System.Threading.Tasks;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using SortingVisualizer.ViewModels;

namespace SortingVisualizer.Models.Algorithms;

public partial class BubbleSort : SortAlgorithmBase
{
    public override string Name => "Пузырьковая";

    public override async Task Sort(SortingViewModel vm)
    {
        for (int i = 0; i < vm.ArraySize - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < vm.ArraySize - i - 1; j++)
            {
                if (vm.Array[j].Value > vm.Array[j + 1].Value)
                {
                    await Task.Delay(vm.Delay);

                    (vm.Array[j].Value, vm.Array[j+1].Value) = (vm.Array[j+1].Value, vm.Array[j].Value);
                    swapped = true;
                }
                await Task.Delay(vm.Delay);
            }
            if (!swapped) break;
        }
    }
}