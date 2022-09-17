using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Researches.Lordaeron
{
  /// <summary>
  /// When Veteran Footman is researched, the researching player loses the ability to train Footmen,
  /// and gains the ability to train Veteran Footmen.
  /// </summary>
  public static class VeteranFootmen
  {
    private static void Research()
    {
      if (LordaeronSetup.Lordaeron == null) return;
      LordaeronSetup.Lordaeron.ModObjectLimit(Constants.UNIT_HFOO_FOOTMAN_LORDAERON, -Faction.UNLIMITED);
      LordaeronSetup.Lordaeron.ModObjectLimit(Constants.UNIT_H029_VETERAN_FOOTMAN_LORDAERON, Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON);
    }
  }
}