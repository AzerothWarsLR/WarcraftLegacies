using System.Collections.Generic;

namespace MacroTools.Localization.Translations;

internal interface ITranslation
{
  /// <summary>
  /// The language code this translation targets.
  /// </summary>
  string Language { get; }

  /// <summary>
  /// The English source strings mapped to their translated text for this language.
  /// </summary>
  IReadOnlyDictionary<string, string> Entries { get; }

  /// <summary>
  /// The <see cref="BlzGetLocale"/> values that should map to this translation's <see cref="Language"/> when
  /// detecting the game client's system language.
  /// </summary>
  IReadOnlyList<string> SystemLocales { get; }
}
