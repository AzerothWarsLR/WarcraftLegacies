using System;
using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// A <see cref="Command"/> that sets the player's camera to a specific height.
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
  public override string Description => "Sets your camera zoom to the specified distance.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var cameraHeight = parameters[0];
    if (!int.TryParse(cameraHeight, out var cameraHeightInt))
    {
      return "You must specify a number as the first parameter.";
    }

    cameraHeightInt = Math.Clamp(cameraHeightInt, 700, 2701);
    PlayerData.ByHandle(commandUser).UpdatePlayerSetting("CamDistance", cameraHeightInt);
    return $"Setting camera height to {cameraHeightInt}.";
  }
}
