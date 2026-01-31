using MacroTools.FactionSystem;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Researches;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches;

/// <summary>
/// When flight path is researched, the two flight path waygates at Orgrimmar and Thunder Bluff become active
/// and connected to each other.
/// </summary>
public sealed class FlightPath : Research
{
  private readonly Faction _frostwolf;
  private const int ResearchId = UPGRADE_R09N_FLIGHT_PATH_WARSONG;
  private static unit? _flightToOrgrimmar;
  private static unit? _flightToThunderBluff;
  private static bool _researched;

  /// <inheritdoc />
  public FlightPath(Faction frostwolf, int researchTypeId, int goldCost)
    : base(researchTypeId, goldCost)
  {
    _frostwolf = frostwolf;
    _flightToOrgrimmar = PreplacedWidgets.Units.GetClosest(
      UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, -14445, -4042);
    _flightToThunderBluff = PreplacedWidgets.Units.GetClosest(
      UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, -9704, -858);
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    if (_researched)
    {
      return;
    }

    var recipient = _frostwolf.Player;
    if (recipient == null)
    {
      if (_flightToOrgrimmar != null)
      {
        _flightToOrgrimmar.Kill();
      }

      if (_flightToThunderBluff != null)
      {
        _flightToThunderBluff.Kill();
      }

      return;
    }

    if (_flightToOrgrimmar != null)
    {
      _flightToOrgrimmar.SetOwner(recipient);
      _flightToOrgrimmar.SetWaygateDestination(Regions.OrgrimmarFlight.Center.X, Regions.ThunderbluffFlight.Center.Y);
      _flightToOrgrimmar.IsInvulnerable = false;
    }

    if (_flightToThunderBluff != null)
    {
      _flightToThunderBluff.SetOwner(recipient);
      _flightToThunderBluff.SetWaygateDestination(Regions.ThunderbluffFlight.Center.X, Regions.ThunderbluffFlight.Center.Y);
      _flightToThunderBluff.IsInvulnerable = false;
    }

    _frostwolf.SetObjectLevel(ResearchId, 1);
    _researched = true;
  }

  /// <inheritdoc />
  public override void OnRegister()
  {
    PlayerUnitEvents.Register(UnitEvent.Dies,
      () => { if (_flightToThunderBluff != null) { _flightToThunderBluff.Kill(); } },
      _flightToOrgrimmar);

    PlayerUnitEvents.Register(UnitEvent.Dies,
      () => { if (_flightToOrgrimmar != null) { _flightToOrgrimmar.Kill(); } },
      _flightToThunderBluff);
  }
}
