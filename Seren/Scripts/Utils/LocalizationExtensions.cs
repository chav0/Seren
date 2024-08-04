using Seren.Resources.Strings;

namespace Seren.Scripts.Utils;

public static class LocalizationExtensions
{
    public static string Localize(this string localizationKey)
    {
        return Localizations.ResourceManager.GetString(localizationKey);
    }
}