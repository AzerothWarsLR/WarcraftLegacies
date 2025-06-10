using MacroTools.Data;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.HealingWavePlus;
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

      var phantomStep = new PhantomStep(ABILITY_TPY7_PHANTOM_STEP_LEGION_ELITES)
      {
        CasterEffect = @"Abilities\Spells\Orc\MirrorImage\MirrorImageCaster.mdl",
        DummyAbilityId = ABILITY_TPY4_PHANTOM_STEP_DUMMY, 
        DummyOrderId = ORDER_WAND_ILLUSION
      };

      SpellSystem.Register(phantomStep);

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

      SpellSystem.Register(phantomStepHero);
      
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
      SpellSystem.Register(healingWavePlus);


      
      
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

      RegisterSlipstreams();

      var summonFelHounds = new SummonUnits(ABILITY_A12B_HOUND_COMPANION_LEGION_FELGUARD)
      {
        SummonUnitTypeId = UNIT_NFEL_FEL_STALKER_SUMMONER_WARLOCK_EYE_OF_SARGERAS,
        SummonCount = 1,
        Duration = 60,
        Radius = 50,
      };
      SpellSystem.Register(summonFelHounds);

      var summonFelHoundsDoomGuard = new SummonUnits(ABILITY_VP10_HOUND_COMPANION_LEGION_DOOMGUARD)
      {
        SummonUnitTypeId = UNIT_NFEL_FEL_STALKER_SUMMONER_WARLOCK_EYE_OF_SARGERAS,
        SummonCount = 2,
        Duration = 60,
        Radius = 50,
      };
      SpellSystem.Register(summonFelHoundsDoomGuard);

      var dreadlordHeroes = new[]
      {
        UNIT_UMAL_THE_CUNNING_LEGION,
        UNIT_UTIC_THE_DARKENER_LEGION,
        UNIT_U00L_ENVOY_OF_ARCHIMONDE_LEGION
      };

      PassiveAbilityManager.Register(new RestoreHealthFromEachTargetDamaged(dreadlordHeroes, ABILITY_VP02_VAMPIRIC_SIPHON_LEGION_DREADLORDS)
      {
        HealthPerTarget = new LeveledAbilityField<int>
        {
          Base = -5,
          PerLevel = 10
        },
        HealthPerLevel = 1,
        Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      });

      var elites = new[]
     {
        UNIT_U007_DREADLORD_LEGION_ELITE,
        UNIT_N04O_DOOM_LORD_LEGION };

      PassiveAbilityManager.Register(new RestoreHealthFromEachTargetDamaged(elites, ABILITY_VP08_VAMPIRIC_SIPHON_LEGION_ELITES)
      {
        HealthPerTarget = new LeveledAbilityField<int>
        {
          Base = -5,
          PerLevel = 10
        },
        HealthPerLevel = 1,
        Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      });
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
      SpellSystem.Register(slipstreamNorthrend);

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
      SpellSystem.Register(slipstreamAlterac);

      slipstreamNorthrend.RelatedSlipstreams.Add(slipstreamAlterac);
      slipstreamNorthrend.RelatedSlipstreams.Add(slipstreamNorthrend);
      
      slipstreamAlterac.RelatedSlipstreams.Add(slipstreamNorthrend);
      slipstreamAlterac.RelatedSlipstreams.Add(slipstreamAlterac);
    }
  }
}