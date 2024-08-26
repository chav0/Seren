using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using Plugin.Maui.Audio;

namespace Seren.Scripts.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    private readonly IPopupService _popupService;
    private readonly IAudioPlayer _audioPlayer;
    
    private bool _isSoundEnabled = true;
    public bool IsSoundEnabled
    {
        get => _isSoundEnabled;
        set
        {
            if (SetProperty(ref _isSoundEnabled, value))
            {
                OnSoundSettingsChanged();
            }
        }
    }
    
    public ICommand SoundSettingsCommand { get; }
    public ICommand BuyCoffeeCommand { get; }
    public ICommand RateUsCommand { get; }
    public ICommand FeedbackCommand { get; }
    public ICommand DeleteDataCommand { get; }

    public SettingsViewModel(IPopupService popupService, IAudioPlayer audioPlayer)
    {
        _popupService = popupService;
        _audioPlayer = audioPlayer;
        
        SoundSettingsCommand = new Command(OnSoundSettings);
        BuyCoffeeCommand = new Command(OnBuyCoffee);
        RateUsCommand = new Command(OnRateUs);
        FeedbackCommand = new Command(OnFeedback);
        DeleteDataCommand = new Command(OnDeleteData);
    }

    private void OnSoundSettings() => IsSoundEnabled = !IsSoundEnabled;
    
    private void OnSoundSettingsChanged()
    {
        if (!_isSoundEnabled)
            _audioPlayer.Pause();
        else 
            _audioPlayer.Play();
    }

    private void OnBuyCoffee() => Browser.OpenAsync("https://www.buymeacoffee.com/alinulken", BrowserLaunchMode.SystemPreferred);

    private void OnRateUs() => _popupService.ShowPopup<ErrorPopupViewModel>();

    private void OnFeedback() => _popupService.ShowPopup<ErrorPopupViewModel>();

    private void OnDeleteData() => _popupService.ShowPopup<DeleteDataViewModel>();
}
