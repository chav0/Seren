using CommunityToolkit.Mvvm.ComponentModel;

namespace Seren.Scripts.Services;

public class LocalizationService : ObservableObject, ILocalizationService
{
    public IReadOnlyList<string> SupportedLanguageIds { get; }
    public string CurrentLanguageId { get; }

    public bool TryLocalize(string key, out string text)
    {
        throw new NotImplementedException();
    }

    public void SetLanguage(string language)
    {
        throw new NotImplementedException();
    }
}