using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// A <see cref="Command"/> that turns dialogue sound on or off.
/// </summary>
public sealed class Dialogue : Command
{
  /// <inheritdoc />
  public override string CommandText => "dialogue";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description => "Turns dialogue sound on or off (accepts 'true', 'false', 'on', 'off').";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var input = parameters[0].ToLowerInvariant();
    bool? parsed = input switch
    {
      "true" or "on" => true,
      "false" or "off" => false,
      _ => null
    };

    if (parsed is null)
    {
      return "Invalid parameter. Please use 'true', 'false', 'on', or 'off'.";
    }

    PlayerData.ByHandle(commandUser).UpdatePlayerSetting("PlayDialogue", parsed.Value);
    return $"Setting play dialogue option to {parsed.Value}.";
  }
}
