using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Researches;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Researches;

public sealed class FlightPath : Research
{
  private readonly Faction _orcishHorde;
  private readonly Faction _taurenTribes;
  private const int ResearchId = UPGRADE_R09N_FLIGHT_PATH_ORCISH_HORDE_TAUREN_TRIBES;
  private static unit? _flightToOrgrimmar;
  private static unit? _flightToThunderBluff;
  private static bool _researched;

  public FlightPath(Faction orcishHorde, Faction taurenTribes, int researchTypeId, int goldCost, int lumberCost = 0)
    : base(researchTypeId, goldCost, lumberCost)
  {
    _orcishHorde = orcishHorde;
    _taurenTribes = taurenTribes;
    _flightToOrgrimmar = AllPreplacedWidgets.Units.GetClosest(UNIT_N06Z_FLIGHT_PATH_ORCISH_HORDE, -14445, -4042);
    _flightToThunderBluff = AllPreplacedWidgets.Units.GetClosest(UNIT_N06Z_FLIGHT_PATH_ORCISH_HORDE, -9704, -858);
  }

  public override void OnResearch(player researchingPlayer)
  {
    if (_researched)
    {
      Refund(researchingPlayer, false);
      return;
    }

    var recipient = _orcishHorde.Player ?? _taurenTribes.Player;
    if (recipient == null)
    {
      _flightToOrgrimmar.Kill();
      _flightToThunderBluff.Kill();
      return;
    }

    _flightToOrgrimmar.SetOwner(recipient);
    _flightToOrgrimmar.SetWaygateDestination(Regions.OrgrimmarFlight.Center.X, Regions.OrgrimmarFlight.Center.Y);
    _flightToOrgrimmar.WaygateActive = true;
    _flightToOrgrimmar.IsInvulnerable = false;

    _flightToThunderBluff.SetOwner(recipient);
    _flightToThunderBluff.SetWaygateDestination(Regions.ThunderbluffFlight.Center.X, Regions.ThunderbluffFlight.Center.Y);
    _flightToThunderBluff.WaygateActive = true;
    _flightToThunderBluff.IsInvulnerable = false;

    _orcishHorde.SetObjectLevel(ResearchId, 1);
    _taurenTribes.SetObjectLevel(ResearchId, 1);
    _researched = true;
  }

  public override void OnRegister()
  {
    PlayerUnitEvents.Register(UnitEvent.Dies, () => { _flightToThunderBluff.Kill(); }, _flightToOrgrimmar);
    PlayerUnitEvents.Register(UnitEvent.Dies, () => { _flightToOrgrimmar.Kill(); }, _flightToThunderBluff);
  }
}
