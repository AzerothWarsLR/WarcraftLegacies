using MacroTools.CommandSystem;
using MacroTools.Libraries;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatUncontrol : Command
  {
    /// <inheritdoc />
    public override string CommandText => "uncontrol";

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
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (parameter == "all")
      {
        var i = 0;
        while (true)
        {
          if (i > Environment.MAX_PLAYERS) break;

          SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
          SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
          i += 1;
        }

        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Revoked control of all players.");
      }
      else
      {
        SetPlayerAlliance(Player(S2I(parameter)), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
        SetPlayerAlliance(Player(S2I(parameter)), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
        DisplayTextToPlayer(p, 0, 0,
          "|cffD27575CHEAT:|r Revoked control of player " + GetPlayerName(Player(S2I(parameter))) + ".");
      }
    }
  }
}