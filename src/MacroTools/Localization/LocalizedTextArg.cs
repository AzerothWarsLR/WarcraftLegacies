namespace MacroTools.Localization;

/// <summary>
/// A token/value pair for <see cref="LocalizedText.Create"/>.
/// </summary>
public sealed class LocalizedTextArg
{
  internal string Token { get; }
  internal LocalizedText Value { get; }

  private LocalizedTextArg(string token, LocalizedText value)
  {
    Token = token;
    Value = value;
  }

  /// <summary>
  /// Creates a <see cref="LocalizedTextArg"/> that substitutes <paramref name="token"/> with
  /// <paramref name="value"/>'s resolved text.
  /// </summary>
  /// <param name="token">The placeholder to replace within a <see cref="LocalizedText"/> template.</param>
  /// <param name="value">The <see cref="LocalizedText"/> whose resolved value replaces <paramref name="token"/>.</param>
  public static LocalizedTextArg Create(string token, LocalizedText value) => new(token, value);
}
