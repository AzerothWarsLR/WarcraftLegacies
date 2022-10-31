using System;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.PassiveAbilities;
using WarcraftLegacies.MacroTools.PassiveAbilitySystem;
using WarcraftLegacies.MacroTools.Spells;
using WarcraftLegacies.MacroTools.SpellSystem;
using static War3Api.Common;

namespace WarcraftLegacies.TestSource.Setup
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

        var massSimulacrum = new MassSimulacrum(FourCC("AHfs"))
        {
          Radius = 150,
          CountBase = 2,
          CountLevel = 4,
          Duration = 60,
          Effect = @"war3mapImported\Soul Discharge Blue.mdx",
          EffectScale = 1.1f,
          EffectTarget = @"Abilities\Spells\Items\AIil\AIilTarget.mdl",
          EffectScaleTarget = 1.0f,
          HealthBonusBase = -0.5f,
          HealthBonusLevel = 0.2f,
          DamageBonusBase = -0.5f,
          DamageBonusLevel = 0.2f
        };
        SpellSystem.Register(massSimulacrum);

        var executeFootman = new Execute(FourCC("hfoo"));
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

        var resurrectionAura = new ResurrectionAura(FourCC("Huth"));
        PassiveAbilityManager.Register(resurrectionAura);

        var summonLegion = new SummonLegionSpell(FourCC("AHdr"), FourCC("ACm2"));
        SpellSystem.Register(summonLegion);

        var taxScoutTower = new ProvidesIncome(FourCC("hwtw"), 17);
        PassiveAbilityManager.Register(taxScoutTower);

        var taxGuardTower = new ProvidesIncome(FourCC("hgtw"), 20);
        PassiveAbilityManager.Register(taxGuardTower);
        
        ParentChildResearchSystem.Register(FourCC("Rhde"), FourCC("Rhan"));
        
        var electricStrike = new ElectricStrike(FourCC("AHbz"))
        {
          StunId = FourCC("ANsb"),
          PurgeId = FourCC("Aprg"),
          PurgeOrder = "purge",
          StunOrder = "thunderbolt",
          Radius = 200.00F,
          Effect = "Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl"
        };
        SpellSystem.Register(electricStrike);
        
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to initialize {nameof(SpellSetup)}: {ex}");
      }
    }
  }
}