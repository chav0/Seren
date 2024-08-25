using System.Windows.Input;
using Plugin.Maui.Audio;

namespace Seren.Scripts.ViewModels;

public class SettingsViewModel : BaseViewModel
{
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

    public SettingsViewModel(IAudioPlayer audioPlayer)
    {
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

    private void OnRateUs()
    {
        //DependencyService.Get<IAppRatingService>()?.RequestAppReview();
    }

    private void OnFeedback()
    {
        //feedback form
    }

    private void OnDeleteData()
    {
    }
}
