using System.Windows.Input;
using Seren.Scripts.Models;
using Seren.Scripts.Repositories;
using Seren.Scripts.Utils;

namespace Seren.Scripts.ViewModels;

public class SelfHelpViewModel : BaseViewModel
{
    private List<PanicQuestion> _panicQuestions;
    private int _currentQuestionIndex;
    private int _progress; 
    
    public ICommand YesCommand { get; }
    public ICommand NoCommand { get; }
    public float Progress => _progress > 20 ? 1f : _progress < 0 ? 0 : _progress / 20f;
    public string Header => _panicQuestions != null 
        ? _panicQuestions[_currentQuestionIndex].LocalizationKey.Localize() 
        : "...";
    
    public SelfHelpViewModel(IPanicQuestionaryRepository panicQuestionaryRepository)
    {
        InitializeQuestionary(panicQuestionaryRepository);

        YesCommand = new Command(SayYes);
        NoCommand = new Command(SayNo);
    }

    private async void InitializeQuestionary(IPanicQuestionaryRepository panicQuestionaryRepository)
    {
        var panicQuestions = await panicQuestionaryRepository.GetAllAsync();
        _panicQuestions = panicQuestions.OrderBy(q => Guid.NewGuid()).ToList();
        _currentQuestionIndex = 0;
        _progress = 10; 
    }

    private void SayYes()
    {
        if (_panicQuestions == null)
            return;
        
        var panicQuestion = _panicQuestions[_currentQuestionIndex++];
        _progress += panicQuestion.YesAnswer;
    }

    private void SayNo()
    {
        if (_panicQuestions == null)
            return;

        var panicQuestion = _panicQuestions[_currentQuestionIndex++];
        _progress += panicQuestion.NoAnswer;
    }
}