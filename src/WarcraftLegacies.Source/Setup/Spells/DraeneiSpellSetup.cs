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
      SpellSystem.Register(new WaygateOpen(Constants.ABILITY_A0N8_OPEN_EXODAR)
      {
        InteriorWaygateUnitTypeId = Constants.UNIT_H03V_ENTRANCE_PORTAL,
        ExteriorWaygateUnitTypeId = Constants.UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
        GetExteriorWaygatePosition = () => new Point(GetUnitX(GetTriggerUnit()) - 200, GetUnitY(GetTriggerUnit()) - 200),
        GetInteriorWaygatePosition = () => Regions.Exodar_South_Interior.Center
      });

      SpellSystem.Register(new SlipstreamSpell(Constants.ABILITY_A00D_SLIPSTREAM_STORMWIND_KHADGAR)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 10,
        Color = new Color(40, 255, 40, 255)
      });

      SpellSystem.Register(new SlipstreamSpell(Constants.ABILITY_A00D_SLIPSTREAM_STORMWIND_KHADGAR)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 10,
        Color = new Color(40, 255, 40, 255)
      });

      SpellSystem.Register(new SlipstreamSpell(Constants.ABILITY_A00D_SLIPSTREAM_STORMWIND_KHADGAR)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 10,
        Color = new Color(40, 255, 40, 255)
      });
    }
  }
}