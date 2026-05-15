using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SortingVisualizer.Models;
using SortingVisualizer.Models.Algorithms;

namespace SortingVisualizer.ViewModels;

public partial class SortingViewModel : ObservableObject
{
    public List<SortAlgorithmBase> SortAlgorithms { get; } = [new BubbleSort(), new BubbleSort()];
    private readonly Random _random = new();
    
    [ObservableProperty] private ObservableCollection<SortingBar> _array;
    [ObservableProperty] private SortAlgorithmBase? _selectedAlgorithm;
    [ObservableProperty] private int _arraySize = 20;
    [ObservableProperty] private int _delay = 10;
    [ObservableProperty] private string _startStopButtonText = "Старт";
    
    [NotifyCanExecuteChangedFor(nameof(StartStopSortingCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShakeArrayCommand))]
    [NotifyCanExecuteChangedFor(nameof(SetReversedArrayCommand))]
    [NotifyCanExecuteChangedFor(nameof(SetCraterArrayCommand))]
    [NotifyCanExecuteChangedFor(nameof(SetPyramidArrayCommand))]
    [NotifyCanExecuteChangedFor(nameof(SelectAlgorithmCommand))]
    [ObservableProperty] private bool _isSortAvailable = true;
    
    public SortingViewModel()
    {
        SelectAlgorithm(SortAlgorithms[0]);
        Array = GenerateSortedArray();
        ShakeArray();
    }

    partial void OnIsSortAvailableChanged(bool value)
    {
        StartStopButtonText = value ? "Старт" : "Стоп";
    }
    
    partial void OnArraySizeChanged(int value)
    {
        Array = GenerateSortedArray();
        ShakeArray();
    }

    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private void SetCraterArray()
    {
        Array = GenerateCraterArray();
    }
    
    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private void SetReversedArray()
    {
        Array = GenerateReversedArray();
    }
    
    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private void SetPyramidArray()
    {
        Array = GeneratePyramidArray();
    }
    
    private ObservableCollection<SortingBar> GenerateCraterArray()
    {
        /*Лучше заполнять массив через два указателя, вместо использования Insert для коллекции, ибо в таком случае
         приходится проходиться по массиву каждый раз при вставке, n превращается в n^2*/
        SortingBar[] newArray = new SortingBar[ArraySize]; 
        
        int left = 0, right = ArraySize - 1; 

        for (int i = ArraySize; i >= 1; i--)
        {
            if (i % 2 == 0)
            {
                newArray[left] = new SortingBar(i);
                left++;
            }
            else
            {
                newArray[right] = new SortingBar(i);;
                right--;
            }
        }

        return new ObservableCollection<SortingBar>(newArray);
    }
    
    private ObservableCollection<SortingBar> GeneratePyramidArray()
    {
        //То же, что для GenerateCraterArray()
        SortingBar[] newArray = new SortingBar[ArraySize];
        int left = 0, right = ArraySize - 1;

        for (int i = 1; i <= ArraySize; i++)
        {
            if (i % 2 == 0)
            {
                newArray[left] = new SortingBar(i);
                left++;
            }
            else
            {
                newArray[right] = new SortingBar(i);;
                right--;
            }
        }

        return new ObservableCollection<SortingBar>(newArray);
    }
    
    private ObservableCollection<SortingBar> GenerateReversedArray()
    {
        ObservableCollection<SortingBar> newArray = new ObservableCollection<SortingBar>();
        
        for (int i = ArraySize; i >= 1; i--)
        {
            newArray.Add(new SortingBar(i));
        }

        return newArray;
    }

    private ObservableCollection<SortingBar> GenerateSortedArray()
    {
        ObservableCollection<SortingBar> newArray = new ObservableCollection<SortingBar>();
        
        for (int i = 1; i <= ArraySize; i++)
        {
            newArray.Add(new SortingBar(i));
        }

        return newArray;
    }
    
    [RelayCommand(CanExecute = nameof(IsSortAvailable))]
    private void ShakeArray()
    {
        ObservableCollection<SortingBar> shakedArray = new ObservableCollection<SortingBar>(Array);
        
        for (int i = 0; i < shakedArray.Count; i++)
        {
            int j = _random.Next(shakedArray.Count);
            (shakedArray[i].Value, shakedArray[j].Value) = (shakedArray[j].Value, shakedArray[i].Value);
        }

        Array = shakedArray;
    }

    [RelayCommand]
    private async Task StartStopSorting()
    {
        IsSortAvailable = false;
        await SelectedAlgorithm!.Sort(this);
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