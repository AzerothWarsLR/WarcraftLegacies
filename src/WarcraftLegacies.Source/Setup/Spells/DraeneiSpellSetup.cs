using MacroTools.Spells;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Draenei <see cref="Spell"/>s.
  /// </summary>
  public static class DraeneiSpellSetup
  {
    /// <summary>
    /// Sets up all Draenei <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new WaygateOpen(Constants.ABILITY_A0N8_OPEN_EXODAR)
      {
        InteriorWaygateUnitTypeId = Constants.UNIT_H03V_ENTRANCE_PORTAL,
        ExteriorWaygateUnitTypeId = Constants.UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
        GetInteriorWaygatePosition = () => Regions.Exodar_South_Interior.Center
      });
  //    SpellSystem.Register(new WaygateOpen(Constants.ABILITY_A0N8_OPEN_EXODAR)
  //    {
  //      InteriorWaygateUnitTypeId = Constants.UNIT_H03V_ENTRANCE_PORTAL,
  //      ExteriorWaygateUnitTypeId = Constants.UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
  //      GetExteriorWaygatePosition = () => new Point(GetUnitX(GetTriggerUnit()) + 100, GetUnitY(GetTriggerUnit()) - 100),
  //      GetInteriorWaygatePosition = () => Regions.Exodar_North_Interior.Center
  //    });
    }
  }
}