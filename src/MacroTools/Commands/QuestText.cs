using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that sets the player's camera to a specific height.
  /// </summary>
  public sealed class QuestText : Command
  {
    /// <inheritdoc />
    public override string CommandText => "questtext";
    
    /// <inheritdoc />
    public override bool Exact => false;
  
    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Sets your camera zoom to the specified distance.";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      var questText = parameters[0];
      if (!bool.TryParse(questText, out var questTextBool))
        return "You must specify a boolean value(true or false) as the first parameter.";
      
      PlayerData.ByHandle(commandUser).UpdatePlayerSetting("ShowQuestText", questTextBool);
      return $"Setting show quest text option to {questTextBool}.";
    }
  }
}