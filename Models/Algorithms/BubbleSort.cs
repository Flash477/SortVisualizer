using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SortingVisualizer.ViewModels;

namespace SortingVisualizer.Models.Algorithms;

public partial class BubbleSort : SortAlgorithmBase
{
    public override string Name => "Пузырьковая";

    public override async Task Sort(SortingViewModel vm)
    {
        for (int i = 0; i < vm.Array.Count; i++)
        {
            bool replaced = false;
            for (int j = i; j < vm.Array.Count; j++)
            {
                if (vm.Array[i].Value > vm.Array[j].Value)
                {
                    (vm.Array[i].Value, vm.Array[j].Value) = (vm.Array[j].Value, vm.Array[i].Value);
                    replaced = true;
                    await Task.Delay(vm.Delay);
                }
                await Task.Delay(vm.Delay);
            }

            if (!replaced)
            {
                return;
            }
        }
    }
}