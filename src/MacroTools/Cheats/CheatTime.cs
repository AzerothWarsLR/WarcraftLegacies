using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatTime : Command
  {
    /// <inheritdoc />
    public override string CommandText => "time";

    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      SetFloatGameState(GAME_STATE_TIME_OF_DAY, S2R(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Time of day to " + parameter + ".");
    }
  }
}