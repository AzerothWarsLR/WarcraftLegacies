using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Researches;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Ironforge;

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
  public DeeprunTram(Faction ironforge, Faction stormwind, int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
  {
    _ironforge = ironforge;
    _stormwind = stormwind;
    _tramToIronforge = AllPreplacedWidgets.Units.GetClosest(UNIT_N03B_DEEPRUN_TRAM, 11126, -9970);
    _tramToStormwind = AllPreplacedWidgets.Units.GetClosest(UNIT_N03B_DEEPRUN_TRAM, 9761, -5723);
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
      _tramToIronforge.Kill();
      _tramToStormwind.Kill();
      return;
    }

    _tramToIronforge.SetOwner(recipient);
    _tramToIronforge.SetWaygateDestination(Regions.Ironforge.Center.X, Regions.Ironforge.Center.Y);
    _tramToIronforge.WaygateActive = true;

    _tramToStormwind.SetOwner(recipient);
    _tramToStormwind.SetWaygateDestination(Regions.Stormwind.Center.X, Regions.Stormwind.Center.Y);
    _tramToStormwind.WaygateActive = true;

    _stormwind.SetObjectLevel(ResearchId, 1);
    _ironforge.SetObjectLevel(ResearchId, 1);
    _researched = true;
  }

  /// <inheritdoc />
  public override void OnRegister()
  {
    PlayerUnitEvents.Register(UnitEvent.Dies, () => { _tramToStormwind.Kill(); }, _tramToIronforge);
    PlayerUnitEvents.Register(UnitEvent.Dies, () => { _tramToIronforge.Kill(); }, _tramToStormwind);
  }
}
