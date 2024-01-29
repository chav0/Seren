using System.ComponentModel;

namespace Seren.Scripts.Services;

public interface ILocalizationService : INotifyPropertyChanged
{
    IEnumerable<string> SupportedLanguageIds { get; }
    
    string CurrentLanguageId { get; }
    
    bool TryLocalize(string key, out string text);
    
    void SetLanguage(string language);
}