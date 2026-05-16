using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SortingVisualizer.ViewModels;

namespace SortingVisualizer.Models.Algorithms;

public abstract partial class SortAlgorithmBase : ObservableObject
{ 
    public abstract string Name { get; }
    [ObservableProperty] private bool _isSelected = false;

    public abstract Task Sort(ISortingContext context);
}