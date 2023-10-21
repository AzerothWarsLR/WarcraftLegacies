using System.Collections.Generic;
using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class ScarletSpellSetup
  {
    public static void Setup()
    { 
      PassiveAbilityManager.Register(new NoTargetSpellOnCast(Constants.UNIT_H08H_HIGH_INQUISITOR_SCARLET, Constants.ABILITY_A02T_HEALING_FRENZY_ICON_SALLY)
      {
        DummyAbilityId = Constants.ABILITY_A00E_HEALING_FRENZY_SALLY_DUMMY,
        DummyOrderId = OrderId("fanofknives"),
        ProcChance = 1.0f,
        AbilityWhitelist = new List<int>
        {
          Constants.ABILITY_ANHW_HEALING_WAVE_PINK_VOL_JIN,
          Constants.ABILITY_A0BV_SWIFT_HOLY_LIGHT_SALLY,
          Constants.ABILITY_A078_SPIRITUAL_GUIDANCE_SALLY,
          Constants.ABILITY_A0DK_DISPEL_MAGIC_SALLY,
        }
      });

      var crusaderShout = new Stomp(Constants.ABILITY_A0KB_CRUSADER_S_SHOUT_SAIDEN)
      {
        Radius = 600,
        DamageBase = 00,
        DamageLevel = 00,
        DurationBase = 2,
        DurationLevel = 1,
        StunAbilityId = Constants.ABILITY_A0KD_SOUL_BURN_SAIDEN_DUMMY,
        StunOrderString = "soulburn",
        SpecialEffect = @"war3mapImported\RoarCasterScarlet.mdx"
      };
      SpellSystem.Register(crusaderShout);

    }
  }
}