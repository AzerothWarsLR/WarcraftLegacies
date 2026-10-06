using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WarcraftLegacies.Shared;

/// <summary>
/// Supplies the text a build writes into map data - unit role labels, tooltip section headers and build-bar
/// verbs. Those strings become part of the object data, so they cannot go through
/// <c>MacroTools.Localization.Loc</c>, which only runs inside the map.
/// <para>
/// The translations are data, not code: they live beside the rest of a locale's map data in
/// <c>mapdata/&lt;map&gt;/&lt;locale&gt;/buildtext.json</c> and are loaded with <see cref="Load"/>. A build with no
/// locale set returns every string unchanged, so the English map data is untouched.
/// </para>
/// </summary>
public static class BuildText
{
  /// <summary>
  /// The file a locale keeps its build-time strings in, relative to the locale's map data directory.
  /// </summary>
  public const string FileName = "buildtext.json";

  private static IReadOnlyDictionary<string, string> _entries =
    new Dictionary<string, string>(StringComparer.Ordinal);

  /// <summary>
  /// The locale the build is writing for, or <see langword="null"/> to leave build text in English.
  /// </summary>
  public static string? Locale { get; private set; }

  /// <summary>
  /// Loads the build-time strings for a locale. Reads
  /// <c>&lt;mapDataDirectory&gt;/&lt;locale&gt;/buildtext.json</c> when it exists and clears any previously loaded
  /// strings otherwise, so a build never inherits another locale's text.
  /// </summary>
  /// <param name="mapDataDirectory">The directory holding this map's map data.</param>
  /// <param name="locale">The locale to write for, such as <c>zhCN</c>, or <see langword="null"/> for English.</param>
  public static void Load(string mapDataDirectory, string? locale)
  {
    Locale = string.IsNullOrEmpty(locale) ? null : locale;

    if (Locale is null)
    {
      _entries = new Dictionary<string, string>(StringComparer.Ordinal);
      return;
    }

    var path = Path.Combine(mapDataDirectory, Locale, FileName);
    _entries = File.Exists(path)
      ? System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path))
        ?? new Dictionary<string, string>(StringComparer.Ordinal)
      : new Dictionary<string, string>(StringComparer.Ordinal);
  }

  /// <summary>
  /// Translates a string the build writes into map data, leaving it unchanged when no locale is loaded or the
  /// string has no translation.
  /// </summary>
  /// <param name="english">The English source string.</param>
  public static string Translate(string english) =>
    _entries.TryGetValue(english, out var translated) ? translated : english;

  /// <summary>
  /// Builds a string from a translated template whose placeholders are substituted afterwards, so that a value
  /// which is already localized is never fed back through <see cref="Translate"/> as if it were an English key.
  /// <para>
  /// A template writes its placeholders in braces, and <c>{n}</c> is swapped for whichever repeated placeholder
  /// <see cref="string.Format(string, object)"/> expects. Templates therefore keep every brace they mean
  /// literally out of the text, because <see cref="string.Format(string, object)"/> reads one as a placeholder
  /// of its own.
  /// </para>
  /// </summary>
  /// <param name="template">The template, using the placeholder <c>{name}</c>, e.g. <c>"Summon {name}"</c>.</param>
  /// <param name="value">The localized value to substitute. English callers pass it through unchanged.</param>
  public static string Format(string template, string value) =>
    string.Format(Normalize(Translate(template)), value);

  /// <summary>
  /// Builds a string from a translated template with several placeholders substituted afterwards, pairing each
  /// token with a value.
  /// </summary>
  /// <param name="template">The template, using a <c>{token}</c> placeholder for each entry in
  /// <paramref name="args"/>.</param>
  /// <param name="args">The token/value pairs to substitute.</param>
  public static string Format(string template, params (string Token, string Value)[] args)
  {
    var text = Normalize(Translate(template));
    foreach (var (token, value) in args)
    {
      text = text.Replace("{" + token + "}", value);
    }

    return text;
  }

  /// <summary>
  /// Rewrites a template's named placeholders into the positional ones <see cref="string.Format(string, object)"/>
  /// understands, doubling every brace that is not part of one.
  /// </summary>
  private static string Normalize(string template)
  {
    var builder = new StringBuilder(template.Length + 8);
    for (var i = 0; i < template.Length; i++)
    {
      if (template[i] == '{')
      {
        var close = template.IndexOf('}', i + 1);
        if (close > i + 1 && template.Substring(i + 1, close - i - 1).All(char.IsLetter))
        {
          builder.Append("{0}");
          i = close;
          continue;
        }

        builder.Append("{{");
        continue;
      }

      if (template[i] == '}')
      {
        builder.Append("}}");
        continue;
      }

      builder.Append(template[i]);
    }

    return builder.ToString();
  }
}
