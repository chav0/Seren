using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.Maui.Audio;

namespace Seren.Scripts.ViewModels;

public class PlayerViewModel : BaseViewModel, IDisposable
{
    private IAudioPlayer _player;
    private IDispatcherTimer _timer;
    private bool _isRunning;

    public PlayerViewModel(IAudioManager audioManager, string soundPath)
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(0.05f);
        _timer.Tick += TimerTick;
        
        InitializeBackgroundMusic(audioManager, soundPath);
        ToggleCommand = new Command(ToggleTimer);
    }
    
    private async void InitializeBackgroundMusic(IAudioManager audioManager, string soundPath)
    {
        _player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(soundPath));
        Start();
    }

    public string RemainingTimeText => $"{RemainingTime.Minutes:D2}:{RemainingTime.Seconds:D2}";
    
    public TimeSpan RemainingTime => TimeSpan.FromSeconds(_player.Duration - _player.CurrentPosition);
    public float CurrentProgress => (float) (_player.CurrentPosition / _player.Duration);
    
    public bool IsRunning
    {
        get => _isRunning;
        set
        {
            if (_isRunning != value)
            {
                _isRunning = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotRunning));
            }
        }
    }

    public bool IsNotRunning => !IsRunning;

    public ICommand ToggleCommand { get; }
    
    private void ToggleTimer()
    {
        if (_player.IsPlaying)
            Stop();
        else
            Start();
    }

    private void Start()
    {
        _player.Play();
        _timer.Start();

        IsRunning = true;
    }

    private void Stop()
    {
        _player.Pause();
        _timer.Stop();

        IsRunning = false;
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        if (RemainingTime < TimeSpan.Zero && IsRunning)
            Stop();
        else
        {
            OnPropertyChanged();
            OnPropertyChanged(nameof(RemainingTimeText));
        }
    }
    
    public void Dispose()
    {
        Stop();
        _player.Dispose();
    }
}