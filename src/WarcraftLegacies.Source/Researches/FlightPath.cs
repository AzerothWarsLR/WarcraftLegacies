using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;

using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Researches
{
  /// <summary>
  /// When flight path is researched, the two flight path waygates at Orgrimmar and Thunder Bluff become active
  /// and connected to eachother.
  /// </summary>
  public sealed class FlightPath : Research
  {
    private readonly Faction _warsong;
    private readonly Faction _frostwolf;
    private const int ResearchId = Constants.UPGRADE_R09N_FLIGHT_PATH_WARSONG;
    private static unit? _flightToOrgrimmar;
    private static unit? _flightToThunderBluff;
    private static bool _researched;

    /// <inheritdoc />
    public FlightPath(Faction warsong, Faction frostwolf, int researchTypeId, int goldCost, int lumberCost, PreplacedUnitSystem preplacedUnitSystem) : base(researchTypeId, goldCost, lumberCost)
    {
      _warsong = warsong;
      _frostwolf = frostwolf;
      var orgrimmarLocation = new Point(-9704, -858);
      var thunderbluffLocation = new Point(-14445, -4042);
      _flightToOrgrimmar = preplacedUnitSystem.GetUnit(Constants.UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, thunderbluffLocation);
      _flightToThunderBluff = preplacedUnitSystem.GetUnit(Constants.UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, orgrimmarLocation);
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      if (_researched)
      {
        Refund(researchingPlayer, false);
        return;
      }
      
      var recipient = _warsong.Player ?? _frostwolf.Player;
      if (recipient == null)
      {
        _flightToOrgrimmar?.Kill();
        _flightToThunderBluff?.Kill();
        return;
      }

      _flightToOrgrimmar.SetOwner(recipient);
      _flightToOrgrimmar.WaygateActive = true;
      _flightToOrgrimmar.WaygateDestinationX = Regions.OrgrimmarFlight.Center.X;
      _flightToOrgrimmar.WaygateDestinationY = Regions.OrgrimmarFlight.Center.Y;
      _flightToOrgrimmar.IsInvulnerable = true;

      _flightToThunderBluff.SetOwner(recipient);
      _flightToThunderBluff.WaygateActive = true;
      _flightToThunderBluff.WaygateDestinationX = Regions.ThunderbluffFlight.Center.X;
      _flightToThunderBluff.WaygateDestinationY = Regions.ThunderbluffFlight.Center.Y;
      _flightToThunderBluff.IsInvulnerable = true;

      _frostwolf.SetObjectLevel(ResearchId, 1);
      _warsong.SetObjectLevel(ResearchId, 1);
      _researched = true;
    }

    /// <inheritdoc />
    public override void OnRegister()
    {
      PlayerUnitEvents.Register(UnitEvent.Dies, () => { _flightToThunderBluff?.Kill(); }, _flightToOrgrimmar);
      PlayerUnitEvents.Register(UnitEvent.Dies, () => { _flightToOrgrimmar?.Kill(); }, _flightToThunderBluff);
    }
  }
}