using System;
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
    private static unit? _tramToIronforge;
    private static unit? _tramToStormwind;
    
    private static void Transfer()
    {
      try
      {
        var recipient = IronforgeSetup.Ironforge?.Player ?? StormwindSetup.Stormwind?.Player;
        if (recipient == null)
        {
          KillUnit(_tramToIronforge);
          KillUnit(_tramToStormwind);
          return;
        }

        SetUnitOwner(_tramToIronforge, recipient, true);
        _tramToIronforge?.SetWaygateDestination(Regions.Ironforge.Center);
        SetUnitInvulnerable(_tramToIronforge, false);

        SetUnitOwner(_tramToStormwind, recipient, true);
        _tramToStormwind?.SetWaygateDestination(Regions.Stormwind.Center);
        SetUnitInvulnerable(_tramToStormwind, false);

        _tramToIronforge = null;
        _tramToStormwind = null;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(DeeprunTram)}: {ex}");
      }
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
      var greatForge = LegendIronforge.LegendGreatforge.Unit;
      var stormwindKeep = LegendStormwind.LegendStormwindkeep.Unit;
      var ironforgeLocation = new Point(GetUnitX(greatForge), GetUnitY(greatForge));
      var stormwindLocation = new Point(GetUnitX(stormwindKeep), GetUnitY(stormwindKeep));
      _tramToIronforge = PreplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, stormwindLocation);
      _tramToStormwind = PreplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, ironforgeLocation);
    }
  }
}