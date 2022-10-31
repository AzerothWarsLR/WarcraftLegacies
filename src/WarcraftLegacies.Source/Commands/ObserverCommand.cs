using WarcraftLegacies.MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Commands
{
  public static class ObserverCommand
  {
    private const string COMMAND = "-obs";

    private static void Actions()
    {
      var triggerPlayer = GetTriggerPlayer();
      triggerPlayer.GetFaction().ScoreStatus = ScoreStatus.Defeated;
      FogModifierStart(
        CreateFogModifierRect(GetTriggerPlayer(), FOG_OF_WAR_VISIBLE, WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, false, false));
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, true);
      TriggerAddAction(trig, Actions);
    }
  }
}