using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.FelHorde.Spells;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>Spells and unit traits used by the Mag'har.</summary>
public static class MagharSpells
{
  /// <summary>Registers the Mag'har's spells and unit traits.</summary>
  public static void Setup()
  {
    SpellRegistry.Register(new MoltenHammerSpell(ABILITY_A1CN_MOLTEN_BOLT_MAGHAR_MAIM)
    {
      Radius = 175,
      Duration = 4,
      DamagePerSecond = 20,
      FireEffectPath = @"Environment\SmallBuildingFire\SmallBuildingFire2.mdl"
    });

    SpellRegistry.Register(new ShatteringBlowSpell(ABILITY_A1CO_SHATTERING_SHOT_MAGHAR_MAIM)
    {
      Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 50 },
      ArmorAbilityId = ABILITY_A1CP_SHATTERING_SHOT_ARMOR_MAGHAR_MAIM_DUMMY,
      HitEffectPath = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    });

    var forgeFury = new ForgeFury
    {
      AbilityTypeId = ABILITY_A1CR_FORGE_FURY_MAGHAR_MAIM,
      ActiveBuffId = BUFF_B110_FORGE_FURY,
      SplashRadius = 200,
      SplashDamage = new LeveledAbilityField<float> { Base = 10, PerLevel = 15 },
      BurnDamagePerSecond = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
      BurnDuration = 3,
      BurnBuffApplicatorId = ABILITY_A1CS_FORGE_FIRE_MAGHAR_MAIM_BUFF,
      BurnBuffId = BUFF_B10Z_FORGE_FIRE,
      SplashEffectPath = @"Abilities\Spells\Other\Incinerate\FireLordDeathExplode.mdl"
    };
    UnitTypeTraitRegistry.Register(forgeFury, UNIT_O20S_SON_OF_BLACKHAND_MAGHAR);
    SpellRegistry.Register(new ForgeFurySpell(ABILITY_A1CR_FORGE_FURY_MAGHAR_MAIM)
    {
      Trait = forgeFury,
      Duration = 30
    });

    SpellRegistry.Register(new CallOfTheAncestorsSpell(ABILITY_A1CU_CALL_OF_THE_ANCESTORS_MAGHAR_SPIRITCALLER)
    {
      Radius = 600,
      MaximumUnits = 1,
      LifeFraction = 0.5f,
      ReviveEffectPath = @"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl"
    });

    RegisterTotems();
    RegisterBaneOfDemons();
  }

  private static void RegisterBaneOfDemons()
  {
    var bane = new BaneOfDemons
    {
      RequiredResearch = UPGRADE_R11M_QUEST_COMPLETED_GUL_DAN_S_LEGACY_MAGHAR,
      DamageBonus = 0.1f
    };
    UnitTypeTraitRegistry.Register(bane, new[]
    {
      UNIT_O200_PEON_MAGHAR_WORKER, UNIT_O201_GRUNT_MAGHAR, UNIT_O202_RAIDER_MAGHAR,
      UNIT_O203_SHAMAN_MAGHAR, UNIT_O204_SPIRITCALLER_MAGHAR, UNIT_O205_BONEBREAKER_MAGHAR, UNIT_O206_CROSSBOWMAN_MAGHAR,
      UNIT_O207_DEMOLISHER_MAGHAR, UNIT_O208_SPIRIT_WOLF_MAGHAR, UNIT_O209_RED_DRAKE_MAGHAR, UNIT_O20A_EXECUTIONER_MAGHAR_ELITE,
      UNIT_O20B_ELDER_SHAMAN_MAGHAR, UNIT_O20Q_CHIEFTAIN_OF_THE_MAG_HAR_MAGHAR, UNIT_O20R_CHIEFTAIN_OF_THE_MAG_HAR_MAGHAR,
      UNIT_O20S_SON_OF_BLACKHAND_MAGHAR
    });
  }

  private static void RegisterTotems()
  {
    var bond = new TotemicBond
    {
      Radius = 600,
      MaximumBonds = 4,
      BonusPerBond = 0.15f,
      AuraAbilityByTotemType = new Dictionary<int, int>
      {
        { UNIT_O20V_HEALING_STREAM_TOTEM_MAGHAR, ABILITY_A1D1_HEALING_STREAM_MAGHAR_HEALING_STREAM_TOTEM },
        { UNIT_O20W_EARTHBIND_TOTEM_MAGHAR, ABILITY_A1D2_EARTHBIND_MAGHAR_EARTHBIND_TOTEM }
      },
      DamageTotemTypes = new HashSet<int> { UNIT_O20U_SEARING_TOTEM_MAGHAR },
      ExtraBondsResearchId = UPGRADE_R11P_QUEST_COMPLETED_THE_THRONE_OF_THE_ELEMENTS_MAGHAR,
      ExtraBonds = 2
    };

    SpellRegistry.Register(new TotemSpell(ABILITY_A1CX_SEARING_TOTEM_MAGHAR_ELDER_SHAMAN)
    {
      TotemTypeId = UNIT_O20U_SEARING_TOTEM_MAGHAR,
      Duration = 45,
      Bond = bond
    });

    SpellRegistry.Register(new TotemSpell(ABILITY_A1CY_HEALING_STREAM_TOTEM_MAGHAR_ELDER_SHAMAN)
    {
      TotemTypeId = UNIT_O20V_HEALING_STREAM_TOTEM_MAGHAR,
      Duration = 45,
      Bond = bond
    });

    SpellRegistry.Register(new TotemSpell(ABILITY_A1CZ_EARTHBIND_TOTEM_MAGHAR_ELDER_SHAMAN)
    {
      TotemTypeId = UNIT_O20W_EARTHBIND_TOTEM_MAGHAR,
      Duration = 45,
      Bond = bond
    });
  }
}
