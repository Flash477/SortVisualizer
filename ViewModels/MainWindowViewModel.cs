namespace SortingVisualizer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public SortingViewModel SortingViewModel { get; }= new SortingViewModel();
}