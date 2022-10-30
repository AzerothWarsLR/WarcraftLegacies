using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;

namespace AzerothWarsCSharp.Source.Setup.Spells
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
    }
  }
}