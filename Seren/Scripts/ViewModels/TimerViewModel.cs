using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Seren.Scripts.ViewModels;

public class TimerViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly TimeSpan _initialTimer;
    private TimeSpan _remainingTime;
    private IDispatcherTimer _timer;
    private DateTime _endTime;
    private bool _isRunning;

    public TimerViewModel(TimeSpan initialTimer)
    {
        _initialTimer = initialTimer;
        _remainingTime = initialTimer; 
        
        ToggleCommand = new Command(ToggleTimer);
    }

    public string RemainingTimeText => RemainingTime.ToString();

    public TimeSpan RemainingTime
    {
        get => _remainingTime;
        set
        {
            if (_remainingTime != value)
            {
                _remainingTime = value;
                OnPropertyChanged();
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

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

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

    private void StartTimer()
    {
        _endTime = DateTime.Now + _initialTimer; // например, 1 минута
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += TimerTick;
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
}