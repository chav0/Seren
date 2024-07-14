using CommunityToolkit.Mvvm.ComponentModel;

namespace Seren.Scripts.ViewModels;

public abstract class BaseViewModel : ObservableObject
{
    public BaseViewModel() => OnPropertyChanged();
}