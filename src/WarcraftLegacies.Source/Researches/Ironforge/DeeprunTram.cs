using System;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using WCSharp.Shared.Data;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Researches.Ironforge
{
  /// <summary>
  /// When Deeprun Tram is researched, the two Deeprun Tram waygates at Ironforge and Stormwind Keep become active
  /// and connected to eachother.
  /// </summary>
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
        StormwindSetup.Stormwind?.SetObjectLevel(ResearchId, 1);
        IronforgeSetup.Ironforge?.SetObjectLevel(ResearchId, 1);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(DeeprunTram)}: {ex}");
      }
    }

    private static void ResearchStart()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        player.GetFaction()?.ModObjectLimit(ResearchId, -1);
      }
    }

    private static void ResearchCancel()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        player.GetFaction()?.ModObjectLimit(ResearchId, 1);
      }
    }

    /// <summary>
    /// Registers the event that allows the Deeprun Tram research to take effect.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Transfer, ResearchId);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsStarted, ResearchStart, ResearchId);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsCancelled, ResearchCancel, ResearchId);
      var greatForge = LegendIronforge.LegendGreatforge.Unit;
      var stormwindKeep = LegendStormwind.LegendStormwindkeep.Unit;
      var ironforgeLocation = new Point(GetUnitX(greatForge), GetUnitY(greatForge));
      var stormwindLocation = new Point(GetUnitX(stormwindKeep), GetUnitY(stormwindKeep));
      _tramToIronforge = preplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, stormwindLocation);
      _tramToStormwind = preplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, ironforgeLocation);
    }
  }
}