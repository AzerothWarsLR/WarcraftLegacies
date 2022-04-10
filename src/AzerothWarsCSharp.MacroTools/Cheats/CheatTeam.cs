using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatTeam
  {
    private const string COMMAND = "-team ";
    private static string? _parameter;


    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      Team t = Team.GetTeamByName(_parameter);
      var faction = Person.ByHandle(p).Faction;
      if (faction != null) faction.Team = t;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to team to " + t.Name + ".");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}