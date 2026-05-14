using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SortingVisualizer.Models;
using SortingVisualizer.Models.Algorithms;

namespace SortingVisualizer.ViewModels;

public partial class SortingViewModel : ObservableObject
{
    public List<SortAlgorithmBase> SortAlgorithms { get; } = [new BubbleSort(), new BubbleSort()];
    private readonly Random _random = new Random();
    
    [ObservableProperty] private List<SortingBar> _array;
    [ObservableProperty] private SortAlgorithmBase? _selectedAlgorithm = null!;
    [ObservableProperty] private bool _isSortAvailable = true;
    [ObservableProperty] private int _delay = 1;
    
    public SortingViewModel()
    {
        SelectAlgorithm(SortAlgorithms[0]);
        Array = GenerateRandomArray(20);
    }

    private List<SortingBar> GenerateRandomArray(int size)
    {
        List<SortingBar> newArray = new List<SortingBar>();
        
        for (int i = 0; i < size; i++)
        {
            newArray.Add(new SortingBar(_random.Next(1, 300)));
        }

        return newArray;
    }
    
    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private void ShakeArray()
    {
        List<SortingBar> shakedArray = new List<SortingBar>(Array);
        
        for (int i = 0; i < shakedArray.Count; i++)
        {
            int j = _random.Next(shakedArray.Count - 1);
            (shakedArray[i].Value, shakedArray[j].Value) = (shakedArray[j].Value, shakedArray[i].Value);
        }

        Array = shakedArray;
    }

    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private async Task StartSorting()
    {
        IsSortAvailable = false;
        await SelectedAlgorithm.Sort(this);
        IsSortAvailable = true;
    }

    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private void SelectAlgorithm(SortAlgorithmBase sortAlgorithm)
    {
        if (SelectedAlgorithm != sortAlgorithm)
        {
            if (SelectedAlgorithm != null)
            {
                SelectedAlgorithm.IsSelected = false;
            }
            
            SelectedAlgorithm = sortAlgorithm;
            SelectedAlgorithm.IsSelected = true;
        }
    }
}