using System;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatFaction
  {
    private const string COMMAND = "-faction ";
    private static string? _parameter;

    private static void Actions()
    {
      try
      {
        if (!TestSafety.CheatCondition())
          return;

        string enteredString = GetEventPlayerChatString();
        player p = GetTriggerPlayer();
        _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

        if (!FactionManager.FactionWithNameExists(_parameter))
          throw new Exception($"There is no registered {nameof(Faction)} with the name {_parameter}.");

        Faction f = FactionManager.GetFromName(_parameter);

        PlayerData.ByHandle(GetTriggerPlayer()).Faction = f;
        DisplayTextToPlayer(p, 0, 0, $"|cffD27575CHEAT:|r Attempted to change faction to {f.Name}.");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}