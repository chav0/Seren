using System.Globalization;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Seren.Scripts.Services;

public class LocalizationService : ObservableObject, ILocalizationService
{
    private const string LocalizationsJsonPath = "localizations.json";
    
    private Dictionary<string, Dictionary<string, string>> _localizations;
    private string _currentLanguageId;
    
    public IEnumerable<string> SupportedLanguageIds => _localizations.Keys.ToList();
    
    public string CurrentLanguageId
    {
        get => _currentLanguageId;
        private set
        {
            if (_currentLanguageId == value) 
                return;
            
            _currentLanguageId = value;
            OnPropertyChanged();
        }
    }
    
    public async Task InitializeAsync()
    {
        await LoadLocalizations();
        
        var currentUiCulture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        CurrentLanguageId = SupportedLanguageIds.Contains(currentUiCulture) 
            ? currentUiCulture 
            : "en";
    }

    private async Task LoadLocalizations()
    {
        var json = await File.ReadAllTextAsync(LocalizationsJsonPath);
        _localizations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
    }

    public bool TryLocalize(string key, out string text)
    {
        if (_localizations.TryGetValue(CurrentLanguageId, out var translations) &&
            translations.TryGetValue(key, out text))
        {
            return true;
        }

        text = key; 
        return false;
    }

    public void SetLanguage(string language)
    {
        if (SupportedLanguageIds.Contains(language))
        {
            CurrentLanguageId = language;
        }
    }
}