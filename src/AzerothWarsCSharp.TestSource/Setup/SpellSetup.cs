using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.MacroTools.UnitEffects;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
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
        SpellSystem.Register(executeFootman);

        var animalCompanion = new AnimalCompanion(FourCC("hfoo"), FourCC("nqb1"))
        {
          Duration = 12
        };
        SpellSystem.Register(animalCompanion);

        var hideousAppendages = new HideousAppendages(FourCC("Huth"))
        {
          TentacleUnitTypeId = FourCC("nfgt")
        };
        SpellSystem.Register(hideousAppendages);

        var spellResistanceAura = new SpellResistanceAura(FourCC("Huth"));
        SpellSystem.Register(spellResistanceAura);

        var resurrectionAura = new ResurrectionAura(FourCC("Huth"));
        SpellSystem.Register(resurrectionAura);

        var summonLegion = new SummonLegionSpell(FourCC("AHdr"), FourCC("ACm2"));
        SpellSystem.Register(summonLegion);

        var taxScoutTower = new ProvidesIncome(FourCC("hwtw"), 17);
        SpellSystem.Register(taxScoutTower);

        var taxGuardTower = new ProvidesIncome(FourCC("hgtw"), 20);
        SpellSystem.Register(taxGuardTower);
        
        ParentChildResearchSystem.Register(FourCC("Rhde"), FourCC("Rhan"));
        
        var electricStrike = new ElectricStrike(FourCC("AHbz"))
        {
          STUN_ID = FourCC("ANsb"),
          PURGE_ID = FourCC("Aprg"),
          PURGE_ORDER = "purge",
          STUN_ORDER = "thunderbolt"
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