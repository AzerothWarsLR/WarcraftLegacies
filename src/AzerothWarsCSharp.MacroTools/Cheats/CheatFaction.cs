using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatFaction
  {
    private const string COMMAND = "-faction ";
    private static string? _parameter;

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      Faction f = Faction.GetFromName(_parameter);

      Person.ByHandle(GetTriggerPlayer()).Faction = f;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to faction to " + f.Name + ".");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}