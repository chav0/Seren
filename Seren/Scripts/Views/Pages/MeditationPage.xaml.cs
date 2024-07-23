using System.ComponentModel;
using Plugin.Maui.Audio;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public partial class MeditationPage
{
    private PlayerViewModel _playerViewModel;

    public MeditationPage(MeditationViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        InitializePlayer(); 
    }

    private void InitializePlayer()
    {
        _playerViewModel = new PlayerViewModel(App.Services.GetRequiredService<IAudioManager>(), BindingContext.Meditation.AudioUrl);
        _playerViewModel.PropertyChanged += OnTimerTicked; 
        
        Player.Content = new PlayerView(_playerViewModel);
    }
    
    private void OnTimerTicked(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        ProgressBar.Progress = _playerViewModel.CurrentProgress * 100f;
        ProgressText.Text = _playerViewModel.RemainingTimeText; 
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        DisposeTimerViewModel();
    }

    private void DisposeTimerViewModel()
    {
        _playerViewModel.PropertyChanged -= OnTimerTicked;
        _playerViewModel.Dispose();
    }
}