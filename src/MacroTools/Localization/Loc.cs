using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Localization.Translations;

namespace MacroTools.Localization;

/// <summary>
/// Looks up and formats localized text against the local player's current language or a specified one.
/// </summary>
public static class Loc
{
  private static readonly IReadOnlyList<ITranslation> _translations = new ITranslation[]
  {
    new SpanishTranslation()
  };

  private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> _translationsByLanguage =
    _translations.ToDictionary(translation => translation.Language, translation => translation.Entries);

  /// <summary>
  /// Gets the translation of <paramref name="english"/> for the local player's current language.
  /// </summary>
  /// <param name="english">The English source string to translate.</param>
  public static string Get(string english)
  {
    return Get(english, GetLanguage());
  }

  /// <summary>
  /// Gets the translation of <paramref name="english"/> for the specified language, or <paramref name="english"/>
  /// itself if no translation is found or <paramref name="language"/> is <see langword="null"/>.
  /// </summary>
  /// <param name="english">The English source string to translate.</param>
  /// <param name="language">The language to translate into, or <see langword="null"/> to skip translation.</param>
  public static string Get(string english, string? language)
  {
    if (language != null
        && _translationsByLanguage.TryGetValue(language, out var entries)
        && entries.TryGetValue(english, out var translated))
    {
      return translated;
    }

    return english;
  }

  /// <summary>
  /// Gets the local player's currently selected language, falling back to <see cref="GetSystemLanguage"/> if no
  /// language has been explicitly selected.
  /// </summary>
  public static string GetLanguage()
  {
    return player.LocalPlayer.GetPlayerData().PlayerSettings.Language ?? GetSystemLanguage();
  }

  /// <summary>
  /// Gets the language inferred from the game client's locale, defaulting to <c>"en"</c> if the locale has no
  /// matching translation.
  /// </summary>
  public static string GetSystemLanguage()
  {
    var locale = BlzGetLocale();
    foreach (var translation in _translations)
    {
      if (translation.SystemLocales.Contains(locale))
      {
        return translation.Language;
      }
    }

    return "en";
  }

  /// <summary>
  /// Gets the translation of <paramref name="english"/> for the local player's current language, substituting each
  /// of <paramref name="args"/>'s tokens with its translated value.
  /// </summary>
  /// <param name="english">The English source template to translate.</param>
  /// <param name="args">The token/value pairs to substitute into the translated template.</param>
  public static string Format(string english, params (string Token, string Value)[] args)
  {
    return Format(english, GetLanguage(), args);
  }

  /// <summary>
  /// Gets the translation of <paramref name="english"/> for the specified language, substituting each of
  /// <paramref name="args"/>'s tokens with its translated value.
  /// </summary>
  /// <param name="english">The English source template to translate.</param>
  /// <param name="language">The language to translate into, or <see langword="null"/> to skip translation.</param>
  /// <param name="args">The token/value pairs to substitute into the translated template.</param>
  public static string Format(string english, string? language, params (string Token, string Value)[] args)
  {
    var template = Get(english, language);
    foreach (var (token, value) in args)
    {
      template = template.Replace(token, Get(value, language));
    }

    return template;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  internal static void SetTranslations(IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> translationsByLanguage)
  {
    _translationsByLanguage = translationsByLanguage;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  internal static void ResetTranslations()
  {
    _translationsByLanguage = _translations.ToDictionary(translation => translation.Language, translation => translation.Entries);
  }
}
