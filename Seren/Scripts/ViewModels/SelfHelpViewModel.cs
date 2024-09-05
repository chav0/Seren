using System.Windows.Input;
using Seren.Scripts.Models;
using Seren.Scripts.Repositories;
using Seren.Scripts.Utils;

namespace Seren.Scripts.ViewModels;

public class SelfHelpViewModel : BaseViewModel
{
    private int _currentQuestionIndex;
    private int _progress; 
    
    public List<PanicQuestion> PanicQuestions { get; private set; }
    public ICommand YesCommand { get; }
    public ICommand NoCommand { get; }
    public float Progress => _progress > 20 ? 1f : _progress < 0 ? 0 : _progress / 20f;
    public string Header => PanicQuestions != null && PanicQuestions.Count > _currentQuestionIndex
        ? PanicQuestions[_currentQuestionIndex].LocalizationKey.Localize() 
        : "...";

    public Color BarColor =>
        (Color)
        (_progress <= 5 ? Application.Current.Resources["Green3"] : 
            _progress <= 10 ? Application.Current.Resources["Yellow2"] :
            _progress <= 15 ? Application.Current.Resources["Yellow3"] : 
            Application.Current.Resources["Red3"]);

    public int CurrentQuestionIndex
    {
        get => _currentQuestionIndex;
        set
        {
            _currentQuestionIndex = value;
            
            OnPropertyChanged();
            OnPropertyChanged(nameof(Progress));
            OnPropertyChanged(nameof(Header));
            OnPropertyChanged(nameof(BarColor));
        }
    }

    public SelfHelpViewModel(IRepository<PanicQuestion> panicQuestionaryRepository)
    {
        InitializeQuestionary(panicQuestionaryRepository);

        YesCommand = new Command(SayYes);
        NoCommand = new Command(SayNo);
    }

    private async void InitializeQuestionary(IRepository<PanicQuestion> panicQuestionaryRepository)
    {
        var panicQuestions = await panicQuestionaryRepository.GetAllAsync();
        PanicQuestions = panicQuestions.OrderBy(q => Guid.NewGuid()).ToList();
        _progress = 10; 
        CurrentQuestionIndex = 0;
    }

    private void SayYes()
    {
        if (PanicQuestions == null || PanicQuestions.Count <= CurrentQuestionIndex)
            return;
        
        var panicQuestion = PanicQuestions[CurrentQuestionIndex];
        _progress += panicQuestion.YesAnswer;
        CurrentQuestionIndex++;
    }

    private void SayNo()
    {
        if (PanicQuestions == null || PanicQuestions.Count <= CurrentQuestionIndex)
            return;

        var panicQuestion = PanicQuestions[CurrentQuestionIndex];
        _progress += panicQuestion.NoAnswer;
        CurrentQuestionIndex++;
    }
}