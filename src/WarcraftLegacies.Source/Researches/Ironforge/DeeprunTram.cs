using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;
using MacroTools.Systems;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Researches.Ironforge
{
  /// <summary>
  /// When Deeprun Tram is researched, the two Deeprun Tram waygates at Ironforge and Stormwind Keep become active
  /// and connected to eachother.
  /// </summary>
  public sealed class DeeprunTram : Research
  {
    private readonly Faction _ironforge;
    private readonly Faction _stormwind;
    private const int ResearchId = UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE;
    private static unit? _tramToIronforge;
    private static unit? _tramToStormwind;
    private static bool _researched;

    /// <inheritdoc />
    public DeeprunTram(Faction ironforge, Faction stormwind, int researchTypeId, int goldCost,
      PreplacedUnitSystem preplacedUnitSystem) : base(researchTypeId, goldCost)
    {
      _ironforge = ironforge;
      _stormwind = stormwind;
      var ironforgeLocation = new Point(9761, -5723);
      var stormwindLocation = new Point(11126, -9970);
      _tramToIronforge = preplacedUnitSystem.GetUnit(UNIT_N03B_DEEPRUN_TRAM, stormwindLocation);
      _tramToStormwind = preplacedUnitSystem.GetUnit(UNIT_N03B_DEEPRUN_TRAM, ironforgeLocation);
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      if (_researched)
      {
        Refund(researchingPlayer, false);
        return;
      }
      
      var recipient = _ironforge.Player ?? _stormwind.Player;
      if (recipient == null)
      {
        KillUnit(_tramToIronforge);
        KillUnit(_tramToStormwind);
        return;
      }
      
      SetUnitOwner(_tramToIronforge, recipient, true);
      WaygateSetDestination(_tramToIronforge, Regions.Ironforge.Center.X, Regions.Ironforge.Center.Y);
      WaygateActivate(_tramToIronforge, true);
      
      SetUnitOwner(_tramToStormwind, recipient, true);
      WaygateSetDestination(_tramToStormwind, Regions.Stormwind.Center.X, Regions.Stormwind.Center.Y);
      WaygateActivate(_tramToStormwind, true);
      
      _stormwind.SetObjectLevel(ResearchId, 1);
      _ironforge.SetObjectLevel(ResearchId, 1);
      _researched = true;
    }

    /// <inheritdoc />
    public override void OnRegister()
    {
      PlayerUnitEvents.Register(UnitEvent.Dies, () => { KillUnit(_tramToStormwind); }, _tramToIronforge);
      PlayerUnitEvents.Register(UnitEvent.Dies, () => { KillUnit(_tramToIronforge); }, _tramToStormwind);
    }
  }
}