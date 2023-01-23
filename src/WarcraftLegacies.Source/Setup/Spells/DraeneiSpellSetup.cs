using MacroTools;
using MacroTools.Spells;
using MacroTools.Spells.Slipstream;
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
      SpellSystem.Register(new WaygateOpen(Constants.ABILITY_A0N8_OPEN_EXODAR_EXODAR)
      {
        InteriorWaygateUnitTypeId = Constants.UNIT_H03V_ENTRANCE_PORTAL,
        ExteriorWaygateUnitTypeId = Constants.UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
        GetExteriorWaygatePosition = () => new Point(GetUnitX(GetTriggerUnit()) - 200, GetUnitY(GetTriggerUnit()) - 200),
        GetInteriorWaygatePosition = () => Regions.Exodar_South_Interior.Center
      });

      //Azuremyst
      SpellSystem.Register(new SlipstreamSpellSpecificLocation(Constants.ABILITY_A0P9_DIMENSIONAL_JUMP_TO_AZUREMYST_DRAENEI_AZUREMYST)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 10,
        TargetLocation = new Point(-20940, 10412),
        Color = new Color(155, 250, 50, 255)
      });

      //Argus
      SpellSystem.Register(new SlipstreamSpellSpecificLocation(Constants.ABILITY_A0RB_DIMENSIONAL_JUMP_TO_ARGUS_DRAENEI_ARGUS)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 10,
        TargetLocation = new Point(22573, -26856),
        Color = new Color(255, 50, 50, 255)
      });

      //Outland
      SpellSystem.Register(new SlipstreamSpellSpecificLocation(Constants.ABILITY_A0SR_DIMENSIONAL_JUMP_TO_TEMPEST_KEEP_DRAENEI_TEMPEST_KEEP)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 10,
        TargetLocation = new Point(2649, -22845),
        Color = new Color(55, 50, 250, 255)
      });
    }
  }
}