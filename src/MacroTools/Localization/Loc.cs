using System;
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
    new SpanishTranslation(),
    new ChineseTranslation()
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
    if (language != null && _translationsByLanguage.TryGetValue(language, out var entries))
    {
      if (entries.TryGetValue(english, out var translated))
      {
        return translated;
      }

      // The map's source states some strings inside a verbatim literal, where a line break is a real one, and the
      // table may spell the same string with the characters backslash-n. The lookup is retried with the two forms of
      // a break reconciled, so such a string resolves rather than reading in English.
      var normalised = NormaliseBreaks(english);
      if (normalised != english && entries.TryGetValue(normalised, out translated))
      {
        return translated;
      }

      var withEscapes = english.Replace("\r\n", "\\r\\n").Replace("\n", "\\n").Replace("\r", "\\r");
      if (withEscapes != english && entries.TryGetValue(withEscapes, out translated))
      {
        return translated;
      }
    }

    return english;
  }

  /// <summary>
  /// Gets the local player's currently selected language, falling back to <see cref="GetSystemLanguage"/> if no
  /// language has been explicitly selected. Returns <c>"en"</c> when there is no local player to ask, which is the
  /// case outside the game.
  /// </summary>
  public static string GetLanguage()
  {
    try
    {
      return player.LocalPlayer.GetPlayerData().PlayerSettings.Language ?? GetSystemLanguage();
    }
    catch (Exception)
    {
      return "en";
    }
  }

  /// <summary>
  /// Gets the language inferred from the game client's locale, defaulting to <c>"en"</c> if the client reports no
  /// locale or the locale has no matching translation.
  /// <para>
  /// The reported locale is matched loosely, on its language subtag: the same Simplified Chinese install may
  /// report <c>zhCN</c>, <c>zh-Hans</c> or <c>zh_CN</c>, and demanding an exact match silently leaves the map in
  /// English.
  /// </para>
  /// </summary>
  public static string GetSystemLanguage()
  {
    string? locale;
    try
    {
      locale = BlzGetLocale();
    }
    catch (Exception)
    {
      return "en";
    }

    if (locale == null)
    {
      return "en";
    }

    foreach (var translation in _translations)
    {
      foreach (var systemLocale in translation.SystemLocales)
      {
        if (MatchesLocale(locale, systemLocale))
        {
          return translation.Language;
        }
      }
    }

    return "en";
  }

  /// <summary>
  /// Whether a locale the game client reports is the same language as one a translation declares.
  /// </summary>
  /// <param name="reported">The locale from <c>BlzGetLocale</c>, such as <c>zh-Hans</c>.</param>
  /// <param name="declared">The locale a translation declares, such as <c>zhCN</c>.</param>
  private static bool MatchesLocale(string? reported, string declared)
  {
    if (reported is null)
    {
      return false;
    }

    return string.Equals(reported, declared, StringComparison.OrdinalIgnoreCase)
           || string.Equals(LanguageSubtag(reported), LanguageSubtag(declared), StringComparison.OrdinalIgnoreCase);
  }

  /// <summary>
  /// Reduces a locale to its language subtag, so <c>zhCN</c>, <c>zh-Hans</c> and <c>zh_CN</c> all become
  /// <c>zh</c>.
  /// <para>
  /// Built with <see cref="string.Substring(int, int)"/> rather than a range expression: CSharp.lua transpiles a
  /// range into a <c>System.Range</c> call that does not exist at runtime, which fails as soon as the map runs.
  /// </para>
  /// </summary>
  private static string LanguageSubtag(string locale)
  {
    var end = locale.Length;
    for (var i = 0; i < locale.Length; i++)
    {
      if (locale[i] is '-' or '_')
      {
        end = i;
        break;
      }
    }

    var subtag = locale.Substring(0, end);

    // A locale written without a separator, such as "zhCN" or "enUS", keeps its language in the first two
    // letters.
    return subtag.Length > 2 && subtag.Length % 2 == 0
      ? subtag.Substring(0, 2)
      : subtag;
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

  /// <summary>
  /// Reduces a string's line breaks to one form, so an entry written with a real break and one written with the
  /// characters that spell it are recognised as the same string.
  /// </summary>
  private static string NormaliseBreaks(string value)
  {
    return value.Replace("\r\n", "\n").Replace("\r", "\n");
  }
}
