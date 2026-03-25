using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Legion.Spells;
using WarcraftLegacies.Source.Shared.Spells;
using WarcraftLegacies.Source.Shared.Spells.HealingWavePlus;
using WarcraftLegacies.Source.Shared.Spells.Slipstream;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Legion;

public static class LegionSpells
{
  public static void Setup()
  {
    var darkPact = new DarkPact(ABILITY_A0A0_DARK_PACT_LEGION_ARCHIMONDE);
    SpellRegistry.Register(darkPact);

    var inspireMadness = new InspireMadness(ABILITY_A10M_INSPIRE_MADNESS_TICHONDRIUS)
    {
      Radius = 300,
      CountBase = 2,
      CountLevel = 4,
      Duration = 30,
      EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
      EffectScaleTarget = 0.5f
    };
    SpellRegistry.Register(inspireMadness);

    var phantomStep = new PhantomStep(ABILITY_TPY7_PHANTOM_STEP_LEGION_ELITES)
    {
      CasterEffect = @"Abilities\Spells\Orc\MirrorImage\MirrorImageCaster.mdl",
      DummyAbilityId = ABILITY_TPY4_PHANTOM_STEP_DUMMY,
      DummyOrderId = ORDER_WAND_ILLUSION
    };
    SpellRegistry.Register(phantomStep);

    var phantomStepHero = new PhantomStep(ABILITY_TPY1_PHANTOM_STEP_LEGION_HERO)
    {
      CasterEffect = @"Abilities\Spells\Orc\MirrorImage\MirrorImageCaster.mdl",
      DummyAbilityId = ABILITY_TPY4_PHANTOM_STEP_DUMMY,
      DummyOrderId = ORDER_WAND_ILLUSION,
      IllusionCountBase = 1,
      IllusionCountPerLevel = 0,
      IllusionDurationBase = 20.0f,
      IllusionDurationPerLevel = 0.0f,
      EffectScaleBase = 1.0f,
      EffectScalePerLevel = 0.0f,
    };
    SpellRegistry.Register(phantomStepHero);

    var healingWavePlus = new HealingWavePlus(ABILITY_HWP1_ENERGY_WAVE)
    {
      DeathTriggerDuration = 20.0f,
      HealAmountBase = 100.0f,
      HealAmountLevel = 0.0f,
      MaxBounces = 3,
      BounceRadius = 500.0f,
      SecondaryWaveRadius = 500.0f,
      SecondWaveHealAmount = 100.0f,
      HealingEffect = @"",
      TargetMarkEffect = @""
    };
    SpellRegistry.Register(healingWavePlus);

    var summonBurningLegion = new SummonLegion(ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS,
      ABILITY_A0KZ_SPELL_IMMUNITY_LEGION_SUMMON);
    SpellRegistry.Register(summonBurningLegion);

    var massSummonUnit = new DelayedMultiTargetRecall(ABILITY_A02T_DARK_SUMMONING_DREADLORD)
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
    SpellRegistry.Register(massSummonUnit);

    RegisterSlipstreams();

    var summonFelHounds = new SummonUnits(ABILITY_A12B_HOUND_COMPANION_LEGION_FELGUARD)
    {
      SummonUnitTypeId = UNIT_NFEL_FEL_STALKER_SUMMONER_WARLOCK_EYE_OF_SARGERAS,
      SummonCount = 1,
      Duration = 60,
      Radius = 50,
    };
    SpellRegistry.Register(summonFelHounds);

    var summonFelHoundsDoomGuard = new SummonUnits(ABILITY_VP10_HOUND_COMPANION_LEGION_DOOMGUARD)
    {
      SummonUnitTypeId = UNIT_NFEL_FEL_STALKER_SUMMONER_WARLOCK_EYE_OF_SARGERAS,
      SummonCount = 2,
      Duration = 60,
      Radius = 50,
    };
    SpellRegistry.Register(summonFelHoundsDoomGuard);
  }

  private static void RegisterSlipstreams()
  {
    var slipstreamOrigin = new Point(22951.6f, -29964.4f);
    var slipstreamNorthrend = new SlipstreamSpellLegionTeleporter(ABILITY_A0UB_PORTAL_TO_NORTHREND_LEGION)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 10,
      ClosingDelay = 5,
      OriginLocation = slipstreamOrigin,
      TargetLocation = new Point(3587, 20680),
      Color = new Color(55, 50, 250, 255),
      CloseAbilityId = ABILITY_ZBCP_CLOSE_PORTALS_LEGION_TELEPORTERS
    };
    SpellRegistry.Register(slipstreamNorthrend);

    var slipstreamAlterac = new SlipstreamSpellLegionTeleporter(ABILITY_A0UC_PORTAL_TO_ALTERAC_LEGION)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 10,
      ClosingDelay = 45,
      OriginLocation = slipstreamOrigin,
      TargetLocation = new Point(11000, 6424),
      Color = new Color(155, 250, 50, 255),
      CloseAbilityId = ABILITY_ZBCP_CLOSE_PORTALS_LEGION_TELEPORTERS
    };
    SpellRegistry.Register(slipstreamAlterac);

    slipstreamNorthrend.RelatedSlipstreams.Add(slipstreamAlterac);
    slipstreamNorthrend.RelatedSlipstreams.Add(slipstreamNorthrend);

    slipstreamAlterac.RelatedSlipstreams.Add(slipstreamNorthrend);
    slipstreamAlterac.RelatedSlipstreams.Add(slipstreamAlterac);
  }
}
