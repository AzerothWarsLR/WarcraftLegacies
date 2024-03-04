using System;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;


namespace TestMap.Source.Setup
{
  public static class SpellSetup
  {
    public static void Setup()
    {
      try
      {
        var summonGraniteGolems = new SummonUnits(FourCC("AHhb"))
        {
          SummonUnitTypeId = FourCC("nggr"),
          SummonCount = 4,
          Duration = 60,
          Radius = 400,
          AngleOffset = 45,
          Effect = @"war3mapImported\Earth NovaTarget.mdx"
        };
        SpellSystem.Register(summonGraniteGolems);

        var executeFootman = new Execute(FourCC("hfoo"))
        {
          DamageMultNonResistant = 5,
          DamageMultResistant = 2.5f,
          DamageMultStructure = 1
        };
        PassiveAbilityManager.Register(executeFootman);

        var animalCompanion = new AnimalCompanion(FourCC("hfoo"), FourCC("nqb1"))
        {
          Duration = 12
        };
        PassiveAbilityManager.Register(animalCompanion);

        var hideousAppendages = new HideousAppendages(FourCC("Huth"))
        {
          TentacleUnitTypeId = FourCC("nfgt")
        };
        PassiveAbilityManager.Register(hideousAppendages);

        var spellResistanceAura = new SpellResistanceAura(FourCC("Huth"));
        PassiveAbilityManager.Register(spellResistanceAura);

        var resurrectionAura = new ResurrectionAura(FourCC("h05F"));
        PassiveAbilityManager.Register(resurrectionAura);

        var taxScoutTower = new ProvidesIncome(FourCC("hwtw"), 17);
        PassiveAbilityManager.Register(taxScoutTower);

        var taxGuardTower = new ProvidesIncome(FourCC("hgtw"), 20);
        PassiveAbilityManager.Register(taxGuardTower);

        var warglaivesOfAzzinoth = new WarglaivesOfAzzinoth(FourCC("Edem"), FourCC("AEev"))
        {
          Radius = 150,
          DamageBase = 5,
          DamageLevel = 15,
          DamageMultiplierAgainstDemons = 50f,
          Effect = @"Abilities\Spells\Human\Invisibility\InvisibilityTarget.mdl",
          EffectScale = 2,
          DamageType = DAMAGE_TYPE_MAGIC
        };
        PassiveAbilityManager.Register(warglaivesOfAzzinoth);

        var stormBoltOnAttack = new SpellOnAttack(FourCC("Udea"), FourCC("AUau"))
        {
          DummyAbilityId = FourCC("ANsb"),
          DummyOrderId = OrderId("thunderbolt"),
          ProcChance = 1
        };
        PassiveAbilityManager.Register(stormBoltOnAttack);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to initialize {nameof(SpellSetup)}: {ex}");
      }
    }
  }
}