using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Researches.Lordaeron
{
  /// <summary>
  /// When Veteran Footman is researched, the researching player loses the ability to train Footmen, and gains the ability to train Veteran Footmen.
  /// </summary>
  public class VeteranFootmen
  {
    private static void Research()
    {
      LordaeronSetup.Lordaeron.ModObjectLimit(FourCC("hfoo"), -Faction.UNLIMITED); //Footman
      LordaeronSetup.Lordaeron.ModObjectLimit(FourCC("h029"), Faction.UNLIMITED); //Veteran Footman
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON);
    }
  }
}