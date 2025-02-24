﻿using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.ExactJustice;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class LordaeronSpellSetup
  {
    public static void Setup()
    {
      var consecration = new Stomp(ABILITY_A0WE_CONSECRATION_LORDAERON_UTHER)
      {
        Radius = 350,
        DamageBase = 20,
        DamageLevel = 50,
        DurationBase = 1,
        StunAbilityId = ABILITY_S00H_THUNDER_CLAP_DUMMY,
        StunOrderId = OrderId("cripple"),
        SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
      };
      SpellSystem.Register(consecration);

      var solarJudgement = new SolarJudgementSpell(ABILITY_A01F_SOLAR_JUDGEMENT_LORDAERON_ARTHAS)
      {
        DamageBase = 0,
        DamageLevel = 25,
        Duration = 10,
        Period = 0.25f,
        HealMultiplier = 1.5f,
        UndeadDamageMultiplier = 1.1f,
        Radius = 250,
        BoltRadius = 125,
        EffectPath = "Shining Flare.mdx",
        EffectHealPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      };
      SpellSystem.Register(solarJudgement);

      var exactJustice = new ExactJusticeSpell(ABILITY_A097_EXACT_JUSTICE_PURPLE_UTHER)
      {
        DamageBase = 0,
        DamageLevel = 200,
        Radius = 400,
        EffectSettings = new ExactJusticeEffectSettings
        {
          SparklePath = "war3mapImported\\Consecrate.mdx",
          SparkleScale = 2.3f,
          RingPath = "war3mapImported\\Point Target.mdx",
          RingScale = 5.5f,
          ProgressBarPath = "war3mapImported\\Progressbar.mdx",
          ProgressBarScale = 1.5f,
          ProgressBarHeight = 225f,
          ExplodePath = "war3mapImported\\Divine Edict.mdx",
          ExplodeScale = 2,
          AlphaRing = 255f,
          AlphaFade = 0.5f
        }
      };
      SpellSystem.Register(exactJustice);

      var willoftheAshbringer = new NoTargetSpellOnAttack(UNIT_H01J_THE_ASHBRINGER_LORDAERON,
        ABILITY_A122_WILL_OF_THE_ASHBRINGER_MOGRAINE)
      {
        DummyAbilityId = ABILITY_A0KA_RESURRECTION_DUMMY_MOGRAINE,
        DummyOrderId = OrderId("resurrection"),
        ProcChance = 0.2f
      };
      PassiveAbilityManager.Register(willoftheAshbringer);


      var universalCleave = new UniversalCleave(UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON,
    ABILITY_A01N_UNIVERSAL_CLEAVE_GENERIC)
      {
        Radius = 150,
      };
      PassiveAbilityManager.Register(universalCleave);




    }
  }
}