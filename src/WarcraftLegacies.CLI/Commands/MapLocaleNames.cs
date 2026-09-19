using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.IO.Mpq;

namespace WarcraftLegacies.CLI.Commands;

/// <summary>
/// Maps the folder names a translator is likely to use onto the MPQ locales Warcraft III matches against.
/// <para>
/// Warcraft III only loads a locale-tagged entry when the tag matches the running client, so an unrecognised
/// spelling silently produces a map that never shows the translation. Every name therefore has to be rejected
/// loudly rather than ignored.
/// </para>
/// <para>
/// Blizzard's own World Editor names the per-language folders in the scenario-folder layout after the Windows
/// locale, such as <c>esES</c> or <c>zhCN</c>, while ISO forms such as <c>es-ES</c> also map onto the same locale.
/// Both are accepted here.
/// </para>
/// </summary>
internal static class MapLocaleNames
{
  private static readonly Dictionary<string, MpqLocale> _byName = new(StringComparer.OrdinalIgnoreCase)
  {
    ["en"] = MpqLocale.English,
    ["enus"] = MpqLocale.English,
    ["en-US"] = MpqLocale.English,
    ["engb"] = MpqLocale.EnglishUK,
    ["en-GB"] = MpqLocale.EnglishUK,
    ["zh"] = MpqLocale.Chinese,
    ["zhcn"] = MpqLocale.Chinese,
    ["zh-CN"] = MpqLocale.Chinese,
    ["zhtw"] = MpqLocale.Chinese,
    ["zh-TW"] = MpqLocale.Chinese,
    ["cs"] = MpqLocale.Czech,
    ["cscz"] = MpqLocale.Czech,
    ["cs-CZ"] = MpqLocale.Czech,
    ["de"] = MpqLocale.German,
    ["dede"] = MpqLocale.German,
    ["de-DE"] = MpqLocale.German,
    ["es"] = MpqLocale.Spanish,
    ["eses"] = MpqLocale.Spanish,
    ["es-ES"] = MpqLocale.Spanish,
    ["fr"] = MpqLocale.French,
    ["frfr"] = MpqLocale.French,
    ["fr-FR"] = MpqLocale.French,
    ["it"] = MpqLocale.Italian,
    ["itit"] = MpqLocale.Italian,
    ["it-IT"] = MpqLocale.Italian,
    ["ja"] = MpqLocale.Japanese,
    ["jajp"] = MpqLocale.Japanese,
    ["ja-JP"] = MpqLocale.Japanese,
    ["ko"] = MpqLocale.Korean,
    ["kokr"] = MpqLocale.Korean,
    ["ko-KR"] = MpqLocale.Korean,
    ["pl"] = MpqLocale.Polish,
    ["plpl"] = MpqLocale.Polish,
    ["pl-PL"] = MpqLocale.Polish,
    ["pt"] = MpqLocale.Portuguese,
    ["ptbr"] = MpqLocale.Portuguese,
    ["pt-BR"] = MpqLocale.Portuguese,
    ["ru"] = MpqLocale.Russian,
    ["ruru"] = MpqLocale.Russian,
    ["ru-RU"] = MpqLocale.Russian
  };

  /// <summary>
  /// Translates a locale folder name into the MPQ locale to tag its files with.
  /// </summary>
  /// <param name="localeName">
  /// The name, such as <c>zh-TW</c>, <c>zhcn</c> or <c>zhcn.w3mod</c>. Blizzard's own campaign maps name the locale
  /// folders with a <c>.w3mod</c> suffix, so the suffix is accepted and ignored here: the folder is written under
  /// whatever name the caller passed, and this only decides the tag.
  /// </param>
  /// <exception cref="ArgumentException">The name maps to no locale Warcraft III would load.</exception>
  public static MpqLocale Parse(string localeName)
  {
    var name = localeName.EndsWith(".w3mod", StringComparison.OrdinalIgnoreCase)
      ? localeName[..^".w3mod".Length]
      : localeName;

    if (_byName.TryGetValue(name, out var locale))
    {
      return locale;
    }

    throw new ArgumentException(
      $"'{localeName}' is not a locale Warcraft III loads. Known names: " +
      string.Join(", ", _byName.Keys.OrderBy(name => name, StringComparer.Ordinal)));
  }

  /// <summary>
  /// The tag to store a locale folder's files under.
  /// <para>
  /// A folder name carries the region, and the regions of one language are different locales: a Simplified Chinese
  /// client runs Windows locale 0x0804 and a Traditional one 0x0404. The MPQ locale type this project has does not
  /// name Simplified Chinese at all, so the two regions are spelled out here rather than looked up. For every other
  /// language the folder name is enough.
  /// </para>
  /// </summary>
  /// <param name="localeName">The folder name, such as <c>zhcn.w3mod</c>.</param>
  public static MpqLocale FolderTag(string localeName)
  {
    var name = localeName.EndsWith(".w3mod", StringComparison.OrdinalIgnoreCase)
      ? localeName[..^".w3mod".Length]
      : localeName;

    return name.ToLowerInvariant() switch
    {
      "zhcn" or "zh-cn" or "zh-hans" => (MpqLocale)0x0804,
      "zhtw" or "zh-tw" or "zh-hant" => (MpqLocale)0x0404,
      _ => Parse(localeName)
    };
  }
}
