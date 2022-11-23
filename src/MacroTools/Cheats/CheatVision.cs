using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatVision
  {
    private const string Command = "-vision ";
    private static readonly Dictionary<player, fogmodifier> Fogs = new();

    private static void Actions()
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (parameter == "on")
      {
        var newFog = CreateFogModifierRect(p, FOG_OF_WAR_VISIBLE, WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, true, false);
        FogModifierStart(newFog);
        Fogs.Add(p, newFog);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map revealed.");
      }
      else if (parameter == "off")
      {
        DestroyFogModifier(Fogs[p]);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map unrevealed.");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}