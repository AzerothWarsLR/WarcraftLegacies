using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Localization.Translations;
using MacroTools.Save;

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
  /// Gets the local player's currently selected language, falling back to <see cref="GetSystemLanguage"/> when the
  /// player has not chosen one.
  /// <para>
  /// The two ways this can have no answer to give are graded rather than collapsed into English, because they mean
  /// different things. <b>There is no local player</b> - outside the game, or in a test - and there is nothing to
  /// ask, so <c>"en"</c> is returned and the caller stays quiet. <b>There is a local player, but their settings have
  /// not been read yet</b>: reading <c>PlayerData.PlayerSettings</c> before the save loads does not throw, it quietly
  /// hands back a fresh default whose <c>Language</c> is <see langword="null"/>, and treating that as English is what
  /// left everything drawn in the first seconds of a game - the faction choice buttons, the game mode announcement,
  /// discovered quests, the turn timer - in English while text drawn a little later came out translated. The client's
  /// own locale is the right answer there, and it is available from the first frame.
  /// </para>
  /// <para>
  /// <see cref="SaveManager.LocalPlayerSettingsReady"/> tells the two apart: it is set only for the local player, and
  /// only once their settings are in <see cref="SaveManager.SavesByPlayer"/>. An exception is not a usable signal -
  /// the same code path raises one in both cases, and the fabricated-default case raises nothing at all.
  /// </para>
  /// </summary>
  public static string GetLanguage()
  {
    try
    {
      if (player.LocalPlayer == null)
      {
        return "en";
      }

      if (!SaveManager.LocalPlayerSettingsReady)
      {
        return GetSystemLanguage();
      }

      return player.LocalPlayer.GetPlayerData().PlayerSettings.Language ?? GetSystemLanguage();
    }
    catch (Exception)
    {
      // Nothing about the local player can be read at all - outside the game, or the engine refused the call. There
      // is no client locale to fall back on either, so stay in English rather than guessing.
      return "en";
    }
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
