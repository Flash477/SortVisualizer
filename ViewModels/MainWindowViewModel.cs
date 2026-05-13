namespace SortingVisualizer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public SortingViewModel SortingViewModel { get; }= new SortingViewModel();
}