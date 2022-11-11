using MacroTools.Spells;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all KulTiras <see cref="Spell"/>s.
  /// </summary>
  public static class KulTirasSpellSetup
  {
    /// <summary>
    /// Sets up all KulTiras <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new WaygateOpen(Constants.ABILITY_A0LM_OPEN_SHIP)
      {
        InteriorWaygateUnitTypeId = Constants.UNIT_H03V_ENTRANCE_PORTAL,
        ExteriorWaygateUnitTypeId = Constants.UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
        GetExteriorWaygatePosition = () => new Point(GetSpellTargetX(), GetSpellTargetY()),
        GetInteriorWaygatePosition = () => Regions.ShipInside.Center
      });
    }
  }
}