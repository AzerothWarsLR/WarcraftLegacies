using System;
using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// A <see cref="Command"/> that sets the player's camera to a specific height or preset.
/// </summary>
public sealed class Cam : Command
{
  /// <inheritdoc />
  public override string CommandText => "cam";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description =>
    "Sets your camera zoom to a specified distance (number between 700–2701 or presets like 'near', 'medium', 'far').";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var input = parameters[0].ToLowerInvariant();

    int? parsedHeight = input switch
    {
      "near" => 1000,
      "medium" => 1700,
      "far" => 2400,
      _ => int.TryParse(input, out var h) ? Math.Clamp(h, 700, 2701) : null
    };

    if (parsedHeight is null)
    {
      return "Invalid parameter. Please use a number between 700 and 2701, or one of the presets: 'near', 'medium', 'far'.";
    }

    PlayerData.ByHandle(commandUser).UpdatePlayerSetting("CamDistance", parsedHeight.Value);
    return $"Setting camera height to {parsedHeight.Value}.";
  }
}
