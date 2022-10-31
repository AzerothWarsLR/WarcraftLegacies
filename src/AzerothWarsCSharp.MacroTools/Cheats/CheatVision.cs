using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatVision
  {
    private const string COMMAND = "-vision ";
    private static readonly Dictionary<player, fogmodifier> Fogs = new();

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

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
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}