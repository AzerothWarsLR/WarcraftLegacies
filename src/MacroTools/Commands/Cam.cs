using System;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that sets the player's camera to a specific height or preset.
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
    public override string Description => "Sets your camera zoom to a specified distance (numeric or preset: 'near', 'medium', 'far').";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      var input = parameters[0].ToLowerInvariant();

      // Preset mappings
      int? parsedHeight = input switch
      {
        "near" => 1000,
        "medium" => 1700,
        "far" => 2400,
        _ => int.TryParse(input, out var h) ? Math.Clamp(h, 700, 2701) : null
      };

      if (parsedHeight is null)
        return "Invalid parameter. Use a number between 700–2701 or presets like 'near', 'medium', or 'far'.";

      PlayerData.ByHandle(commandUser).UpdatePlayerSetting("CamDistance", parsedHeight.Value);
      return $"Setting camera height to {parsedHeight.Value}.";
    }
  }
}