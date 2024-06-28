using MacroTools;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.Slipstream;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class LegionSpellSetup
  {
    public static void Setup()
    {
      var darkPact = new DarkPact(ABILITY_A0A0_DARK_PACT_LEGION_ARCHIMONDE);
      SpellSystem.Register(darkPact);
      
      var inspireMadness = new InspireMadness(ABILITY_A10M_INSPIRE_MADNESS_TICHONDRIUS)
      {
        Radius = 300,
        CountBase = 2,
        CountLevel = 4,
        Duration = 30,
        EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
        EffectScaleTarget = 0.5f
      };
      SpellSystem.Register(inspireMadness);
      
      var summonBurningLegion = new SummonLegionSpell(ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS,
        ABILITY_A0KZ_SPELL_IMMUNITY_LEGION_SUMMON);
      SpellSystem.Register(summonBurningLegion);
      
      var massSummonUnit = new DelayedMultiTargetRecall( ABILITY_A02T_DARK_SUMMONING_DREADLORD)
      {
        Radius = 400,
        AmountToTarget = 12,
        MinDuration = 2,
        MaxDuration = 20,
        CrossDimensionalDuration = 15,
        DistanceDivider = 1000,
        DeathPenalty = 0.5f,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massSummonUnit);

      var slipstreamOrigin1 = new Point(22951.6f, -29964.4f);
      var slipstreamOrigin2 = new Point(22610.6f, -29659.4f);
      //Northrend
      SpellSystem.Register(new SlipstreamSpellSpecificOriginAndDestination(ABILITY_A0UB_PORTAL_TO_NORTHREND_LEGION)
      {
        PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 0,
        OriginLocation = slipstreamOrigin1,
        TargetLocation = new Point(3587, 20680),
        Color = new Color(55, 50, 250, 255)
      });

      //Alterac
      SpellSystem.Register(new SlipstreamSpellSpecificOriginAndDestination(ABILITY_A0UC_PORTAL_TO_ALTERAC_LEGION)
      {
        PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 0,
        OriginLocation = slipstreamOrigin2,
        TargetLocation = new Point(11000, 6424),
        Color = new Color(155, 250, 50, 255)
      });

      var summonFelHounds = new SummonUnits(ABILITY_A12B_HOUND_COMPANION_LEGION_FELGUARD)
      {
        SummonUnitTypeId = UNIT_NFEL_FEL_STALKER_SUMMONER_WARLOCK_EYE_OF_SARGERAS,
        SummonCount = 1,
        Duration = 60,
        Radius = 50,
      };
      SpellSystem.Register(summonFelHounds);
    }
  }
}