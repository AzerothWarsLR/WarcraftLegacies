using static War3Api.Common;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools;
using WCSharp.Shared.Data;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Researches.Ironforge
{
  public static class DeeprunTram
  {
    private const int ResearchId = Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE;
    
    private static void Transfer()
    {
      var greatForge = LegendIronforge.LegendGreatforge.Unit;
      var ironForgeLocation = new Point(GetUnitX(greatForge), GetUnitY(greatForge));
      var keep = LegendStormwind.LegendStormwindkeep.Unit;
      var stormwindLocation = new Point(GetUnitX(keep), GetUnitY(keep));
      var tramToIronforge = PreplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, stormwindLocation);
      var tramToStormwind = PreplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, ironForgeLocation);
      var recipient = IronforgeSetup.Ironforge?.Player ?? StormwindSetup.Stormwind?.Player;
      if (recipient == null)
      {
        KillUnit(tramToIronforge);
        KillUnit(tramToStormwind);
        return;
      }

      SetUnitOwner(tramToIronforge, recipient, true);
      WaygateActivate(tramToIronforge, true);
      tramToIronforge.SetWaygateDestination(Regions.Stormwind.Center);
      SetUnitInvulnerable(tramToIronforge, false);

      SetUnitOwner(tramToStormwind, recipient, true);
      WaygateActivate(tramToStormwind, true);
      tramToStormwind.SetWaygateDestination(Regions.Ironforge.Center);
      SetUnitInvulnerable(tramToStormwind, false);
    }

    private static void ResearchStart()
    {
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        player.GetFaction()?.ModObjectLimit(ResearchId, -1);
      }
    }

    private static void ResearchCancel()
    {
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        player.GetFaction()?.ModObjectLimit(ResearchId, 1);
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Transfer, ResearchId);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsStarted, ResearchStart, ResearchId);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsCancelled, ResearchCancel, ResearchId);
    }
  }
}