using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// Manually sets the executing player's preferred language for translated game text, overriding
/// auto-detection. Registered under multiple <see cref="CommandText"/> values (eg. "language", "idioma").
/// </summary>
public sealed class Language : Command
{
  private readonly string _commandText;

  /// <summary>Initializes a new instance of the <see cref="Language"/> class.</summary>
  public Language(string commandText) => _commandText = commandText;

  /// <inheritdoc />
  public override string CommandText => _commandText;

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description =>
    "Sets your language ('en'/'english' or 'es'/'espanol'/'spanish').";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var input = parameters[0].ToLowerInvariant();
    var languageCode = input switch
    {
      "en" or "english" or "ingles" or "inglés" => "en",
      "es" or "spanish" or "espanol" or "español" => "es",
      // The language a translation declares, which is `zh` rather than a locale name, because one translation
      // covers both Chinese locales. Without this arm a player who asks for Chinese is told the choice is invalid
      // while the help text they were reading offers it.
      "zh" or "cn" or "zhcn" or "zh-cn" or "chinese" or "中文" or "简体中文" => "zh",
      _ => null
    };

    if (languageCode is null)
    {
      return "Invalid parameter. Please use 'en'/'english' or 'es'/'espanol'.";
    }

    commandUser.GetPlayerData().UpdatePlayerSetting("Language", languageCode);
    return languageCode switch
    {
      // The reply is written in the language just chosen, so it is resolved against that one rather than the
      // player's previous language: `CommandManager` looks the returned sentence up before showing it.
      "es" => "Idioma cambiado a español.",
      "zh" => "Language changed to Chinese.",
      _ => "Language changed to English."
    };
  }
}
