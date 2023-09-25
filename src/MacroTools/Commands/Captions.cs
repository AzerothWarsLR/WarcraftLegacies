using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that sets the player's camera to a specific height.
  /// </summary>
  public sealed class Captions : Command
  {
    /// <inheritdoc />
    public override string CommandText => "captions";
    
    /// <inheritdoc />
    public override bool Exact => false;
  
    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Toggles the display of captions.";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      var captions = parameters[0];
      if (!bool.TryParse(captions, out var captionsBool))
        return "You must specify a boolean value(true or false) as the first parameter.";
      
      PlayerData.ByHandle(commandUser).UpdatePlayerSetting("ShowCaptions", captionsBool);
      return $"Setting show captions option to {captionsBool}.";
    }
  }
}