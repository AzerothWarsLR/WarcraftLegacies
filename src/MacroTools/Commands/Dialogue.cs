using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that sets the player's camera to a specific height.
  /// </summary>
  public sealed class Dialouge : Command
  {
    /// <inheritdoc />
    public override string CommandText => "dialogue";
    
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
      var dialogue = parameters[0];
      if (!bool.TryParse(dialogue, out var dialogueBool))
        return "You must specify a boolean value(true or false) as the first parameter.";
      
      PlayerData.ByHandle(commandUser).UpdatePlayerSetting("PlayDialogue", dialogueBool);
      return $"Setting play dialogue option to {dialogueBool}.";
    }
  }
}