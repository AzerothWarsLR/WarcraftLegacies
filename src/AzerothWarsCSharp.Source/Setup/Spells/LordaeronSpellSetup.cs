using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.Source.Spells;

namespace AzerothWarsCSharp.Source.Setup.Spells
{
  public static class LordaeronSpellSetup
  {
    public static void Setup()
    {
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