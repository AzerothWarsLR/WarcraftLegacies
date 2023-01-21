using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatLumber : Command
  {
    /// <inheritdoc />
    public override string CommandText => "lumber";

    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      string parameter = null;
      player p = GetTriggerPlayer();

      parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));
      SetPlayerState(p, PLAYER_STATE_RESOURCE_LUMBER, S2I(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Set to " + parameter + " lumber.");
    }
  }
}