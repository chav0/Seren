using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Seren.Scripts.ViewModels;

public class TimerViewModel : BaseViewModel, INotifyPropertyChanged, IDisposable
{
    private TimeSpan _remainingTime;
    private IDispatcherTimer _timer;
    private DateTime _endTime;
    private bool _isRunning;

    public TimerViewModel(TimeSpan initialTimer)
    {
        _remainingTime = initialTimer;

        InitTimer();
        ToggleCommand = new Command(ToggleTimer);
    }

    public string RemainingTimeText => $"{RemainingTime.Minutes:D2}:{RemainingTime.Seconds:D2}";
    
    public TimeSpan RemainingTime
    {
        get => _remainingTime;
        private set
        {
            if (_remainingTime != value)
            {
                _remainingTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RemainingTimeText));
            }
        }
    }

    public bool IsRunning
    {
        get => _isRunning;
        set
        {
            if (_isRunning != value)
            {
                _isRunning = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToggleButtonText));
            }
        }
    }

    public string ToggleButtonText => IsRunning ? "Stop" : "Start";

    public ICommand ToggleCommand { get; }

    private void ToggleTimer()
    {
        if (IsRunning)
        {
            StopTimer();
        }
        else
        {
            StartTimer();
        }
    }

    private void InitTimer()
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(0.01f);
        _timer.Tick += TimerTick;

        StartTimer();
    }

    private void StartTimer()
    {
        _endTime = DateTime.Now + RemainingTime;
        _timer.Start();
        IsRunning = true;
    }

    private void StopTimer()
    {
        _timer?.Stop();
        IsRunning = false;
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        var remaining = _endTime - DateTime.Now;
        if (remaining <= TimeSpan.Zero)
        {
            RemainingTime = TimeSpan.Zero;
            StopTimer();
        }
        else
        {
            RemainingTime = remaining;
        }
    }
    
    public void Dispose()
    {
        StopTimer();
        _timer.Tick -= TimerTick;
        _timer = null;
    }
}