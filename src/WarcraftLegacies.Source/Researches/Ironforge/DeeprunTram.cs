using MacroTools;
using MacroTools.Extensions;
using MacroTools.ResearchSystems;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches.Ironforge
{
  /// <summary>
  /// When Deeprun Tram is researched, the two Deeprun Tram waygates at Ironforge and Stormwind Keep become active
  /// and connected to eachother.
  /// </summary>
  public sealed class DeeprunTram : Research
  {
    private const int ResearchId = Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE;
    private static unit? _tramToIronforge;
    private static unit? _tramToStormwind;
    private static bool _researched;

    /// <inheritdoc />
    public DeeprunTram(int researchTypeId, int goldCost, int lumberCost, PreplacedUnitSystem preplacedUnitSystem) : base(researchTypeId, goldCost, lumberCost)
    {
      var ironforgeLocation = new Point(9761, -5723);
      var stormwindLocation = new Point(11126, -9970);
      _tramToIronforge = preplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, stormwindLocation);
      _tramToStormwind = preplacedUnitSystem.GetUnit(Constants.UNIT_N03B_DEEPRUN_TRAM, ironforgeLocation);
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      if (_researched)
      {
        Refund(researchingPlayer, false);
        return;
      }
      
      var recipient = IronforgeSetup.Ironforge?.Player ?? StormwindSetup.Stormwind?.Player;
      if (recipient == null)
      {
        _tramToIronforge?.Kill();
        _tramToStormwind?.Kill();
        return;
      }
      
      _tramToIronforge?
        .SetOwner(recipient)
        .SetWaygateDestination(Regions.Ironforge.Center)
        .SetInvulnerable(false);

      _tramToStormwind?
        .SetOwner(recipient)
        .SetWaygateDestination(Regions.Stormwind.Center)
        .SetInvulnerable(false);
      
      StormwindSetup.Stormwind?.SetObjectLevel(ResearchId, 1);
      IronforgeSetup.Ironforge?.SetObjectLevel(ResearchId, 1);
      _researched = true;
    }

    /// <inheritdoc />
    public override void OnRegister()
    {
      PlayerUnitEvents.Register(UnitEvent.Dies, () => { _tramToStormwind?.Kill(); }, _tramToIronforge);
      PlayerUnitEvents.Register(UnitEvent.Dies, () => { _tramToIronforge?.Kill(); }, _tramToStormwind);
    }
  }
}