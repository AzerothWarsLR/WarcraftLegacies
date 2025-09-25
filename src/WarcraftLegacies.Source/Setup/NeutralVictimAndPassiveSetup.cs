using MacroTools.Extensions;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Setup;

public static class NeutralVictimAndPassiveSetup
{
  public static void Setup()
  {
    Regions.HideUnitBottomLeft.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    foreach (var player in Util.EnumeratePlayers())
    {
      player.SetAlliance(player.Create(27), alliancetype.Passive, true);
      player.SetAlliance(player.Create(27), alliancetype.SharedVision, false);
      player.SetAlliance(player.Create(26), alliancetype.Passive, true);
      player.SetAlliance(player.Create(26), alliancetype.SharedVision, false);
    }
  }
}
