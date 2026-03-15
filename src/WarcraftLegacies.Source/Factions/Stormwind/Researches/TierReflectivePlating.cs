using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Researches;

public static class TierReflectivePlating
{
  private static void Research()
  {
    var triggerPlayer = @event.Player;
    var triggerPlayerData = triggerPlayer.GetPlayerData();
    triggerPlayerData.Faction?.ModObjectLimit(UNIT_H04C_VANGUARD_STORMWIND, Faction.Unlimited);
    triggerPlayerData.Faction?.ModObjectLimit(UNIT_H02O_BLADESMAN_STORMWIND, -Faction.Unlimited);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2);
  }
}
