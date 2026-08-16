using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MacroTools.Localization;

/// <summary>
/// A template string with optional placeholder substitutions, resolved into localized text on demand.
/// </summary>
public sealed class LocalizedText
{
  private readonly string _template;
  private readonly LocalizedTextArg[] _args;
  private readonly string _prefix;
  private readonly string _suffix;

  private LocalizedText(string template, LocalizedTextArg[] args, string prefix = "", string suffix = "")
  {
    _template = template;
    _args = args;
    _prefix = prefix;
    _suffix = suffix;
  }

  /// <summary>
  /// Creates a <see cref="LocalizedText"/> from a template with placeholders to substitute.
  /// </summary>
  /// <param name="template">The English source template, containing zero or more placeholders.</param>
  /// <param name="args">The <see cref="LocalizedTextArg"/>s whose tokens are substituted into <paramref name="template"/>.</param>
  public static LocalizedText Create(string template, params LocalizedTextArg[] args) => new(template, args);

  /// <summary>
  /// Implicitly converts a plain string into a <see cref="LocalizedText"/> with no substitutions.
  /// </summary>
  /// <param name="template">The English source template to convert.</param>
  public static implicit operator LocalizedText(string template) => new(template, Array.Empty<LocalizedTextArg>());

  /// <summary>
  /// Returns a copy with a literal, untranslated <paramref name="prefix"/> prepended after resolution.
  /// </summary>
  /// <param name="prefix">The literal text to prepend to the resolved value.</param>
  public LocalizedText WithPrefix(string prefix) => new(_template, _args, prefix, _suffix);

  /// <summary>
  /// Returns a copy with a literal, untranslated <paramref name="suffix"/> appended after resolution.
  /// </summary>
  /// <param name="suffix">The literal text to append to the resolved value.</param>
  public LocalizedText WithSuffix(string suffix) => new(_template, _args, _prefix, suffix);

  /// <summary>
  /// Resolves this text against the local player's current language.
  /// </summary>
  public override string ToString() => ToString(Loc.GetLanguage());

  /// <summary>
  /// Resolves this text against a specified <paramref name="language"/>.
  /// </summary>
  /// <param name="language">The language to resolve against, or <see langword="null"/> to skip translation.</param>
  public string ToString(string? language)
  {
    var template = Loc.Get(_template, language);

    switch (_args.Length)
    {
      case 0:
        return Wrap(template);
      case 1:
        return Wrap(template.Replace(_args[0].Token, _args[0].Value.ToString(language)));
      default:
        // Builds into a separate buffer instead of repeated Replace calls, so a resolved value can't accidentally
        // re-match another arg's token.
        var result = new StringBuilder(_prefix, _prefix.Length + template.Length + _suffix.Length);

        var pos = 0;
        while (pos < template.Length)
        {
          if (!TryFindFirstToken(template, pos, out var index, out var arg))
          {
            result.Append(template, pos, template.Length - pos);
            break;
          }

          result.Append(template, pos, index - pos);
          result.Append(arg.Value.ToString(language));
          pos = index + arg.Token.Length;
        }

        result.Append(_suffix);
        return result.ToString();
    }
  }

  private string Wrap(string value)
  {
    return _prefix.Length == 0 && _suffix.Length == 0
      ? value
      : $"{_prefix}{value}{_suffix}";
  }

  private bool TryFindFirstToken(string template, int pos, out int index, [MaybeNullWhen(false)] out LocalizedTextArg arg)
  {
    index = -1;
    arg = null;

    foreach (var candidate in _args)
    {
      // ReSharper disable once StringIndexOfIsCultureSpecific.2
      // Cannot use (string, int, StringComparison). CSharp.lua transpiles it positionally into a shim whose
      // 4th parameter is count, not comparisonType, so the search gets truncated instead
      var candidateIndex = template.IndexOf(candidate.Token, pos);
      if (candidateIndex == -1)
      {
        continue;
      }

      if (arg != null && candidateIndex >= index)
      {
        continue;
      }

      index = candidateIndex;
      arg = candidate;
    }

    return arg != null;
  }
}
