using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Cheats
{
  public static class CheatFaction{
    private const string COMMAND = "-faction ";
    private static string? _parameter;
    
    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      Faction f;
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      f = Faction.GetFromName(_parameter);

      Person.ById(pId).Faction = f;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to faction to " + f.Name + ".");
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);
    }

  }
}
