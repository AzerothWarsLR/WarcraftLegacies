using MacroTools.Data;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells.Slipstream;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Illidari <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class IllidariSpellSetup
  {
    /// <summary>
    /// Sets up all Illidari <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
    /// </summary>
    public static void Setup()
    {
      
      SpellSystem.Register(new SlipstreamSpellSpecificDestination(ABILITY_A07D_PORTAL_TO_BLACK_TEMPLE_ILLIDAN)
      {
        PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 15,
        TargetLocation = new Point(5030, -30000),
        Color = new Color(255, 255, 250, 255)
      });
    }
  }
}