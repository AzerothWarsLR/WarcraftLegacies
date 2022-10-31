using WarcraftLegacies.MacroTools.Spells;
using WarcraftLegacies.MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class LordaeronSpellSetup
  {
    public static void Setup()
    {
      var consecration = new Stomp(Constants.ABILITY_A0WE_CONSECRATION_LORDAERON_UTHER)
      {
        Radius = 225,
        DamageBase = 0,
        DamageLevel = 60,
        DurationBase = 1,
        StunAbilityId = Constants.ABILITY_S00H_THUNDER_CLAP_DUMMY,
        StunOrderString = "cripple",
        SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
      };
      SpellSystem.Register(consecration);
      
      var solarJudgement = new SolarJudgementSpell(Constants.ABILITY_A01F_SOLAR_JUDGEMENT_LORDAERON_ARTHAS)
      {
        DamageBase = 20,
        DamageLevel = 20,
        Duration = 14,
        Period = 0.25f,
        HealMultiplier = 1.5f,
        UndeadDamageMultiplier = 1.1f,
        Radius = 250,
        BoltRadius = 125,
        EffectPath = "Shining Flare.mdx",
        EffectHealPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      };
      SpellSystem.Register(solarJudgement);
      
      SpellSystem.Register(new WeaponEmpowerment(Constants.ABILITY_A0JZ_WEAPON_EMPOWERMENT_PURPLE_ALEXANDROS_SPELL));
    }
  }
}