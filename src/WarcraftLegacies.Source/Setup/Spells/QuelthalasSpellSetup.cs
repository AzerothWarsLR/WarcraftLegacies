using MacroTools.Spells;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class QuelthalasSpellSetup
  {
    public static void Setup()
    {
      var summonGraniteGolems = new SummonUnits(Constants.ABILITY_A0EP_SUMMON_GRANITE_GOLEMS_QUEL_THALAS_SUNWELL)
      {
        SummonUnitTypeId = Constants.UNIT_NGGR_GRANITE_GOLEM_QUEL_THALAS,
        SummonCount = 4,
        Duration = 60,
        Radius = 400,
        AngleOffset = 45,
        Effect = @"war3mapImported\Earth NovaTarget.mdx"
      };
      SpellSystem.Register(summonGraniteGolems);

      var resurgentFlameStrike = new ResurgentSpell(Constants.ABILITY_A04H_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS,
        Constants.ABILITY_A0F9_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS_DUMMY, "flamestrike")
      {
        Duration = 14,
        Interval = 7
      };
      SpellSystem.Register(resurgentFlameStrike);
      
      var massBanish = new MassAnySpell(Constants.ABILITY_A0FD_MASS_BANISH_QUEL_THALAS_KAEL_THAS)
      {
        DummyAbilityId = Constants.ABILITY_A0FE_MASS_BANISH_QUEL_THALAS_KAEL_THAS_DUMMY_CASTER,
        DummyAbilityOrderString = "banish",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massBanish);
      
      var siphoningRitual = new SiphoningRitualSpell(Constants.ABILITY_A0FA_SIPHONING_RITUAL_QUEL_THALAS_KAEL_THAS)
      {
        CountBase = 7,
        LifeDrainedPerSecondBase = 10,
        LifeDrainedPerSecondLevel = 10,
        ManaDrainedPerSecondBase = 5,
        ManaDrainedPerSecondLevel = 5,
        Range = 500,
        Radius = 225,
        Interval = 0.1f
      };
      SpellSystem.Register(siphoningRitual);
    }
  }
}