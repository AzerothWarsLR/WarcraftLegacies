using MacroTools.ResearchSystems;
using MacroTools.Spells;
using MacroTools.Spells.Slipstream;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class FrostwolfSpellSetup
  {
    public static void Setup()
    {
      var devour = new Devour(Constants.ABILITY_ADEV_DEVOUR_PINK_KODO_BEAST)
      {
        PercentageOfMaxHealth = 0.5f
      };
      SpellSystem.Register(devour);
      
      var warStompCairne = new Stomp(Constants.ABILITY_A0WM_WAR_STOMP_CAIRNE_MANNOROTH)
      {
        Radius = 300,
        DamageBase = 20,
        DamageLevel = 30,
        DurationBase = 0,
        DurationLevel = 1,
        StunAbilityId = Constants.ABILITY_A0WN_STUN_UNIT_DUMMY,
        StunOrderString = "thunderbolt",
        SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl"
      };
      SpellSystem.Register(warStompCairne);
      
      ParentChildResearchSystem.Register(Constants.UPGRADE_RHME_PYRITE_FORGED_WEAPONRY_UNIVERSAL_UPGRADE,
        Constants.UPGRADE_R06C_KABOOM_LEVEL_UP);

      SpellSystem.Register(new SlipstreamSpellSpecificLocation(0)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 10,
        TargetLocation = new Point(-3169, -29714)
      });
    }
  }
}