using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Sentinels.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits.Vengeance;

namespace WarcraftLegacies.Source.Factions.Sentinels;

public static class SentinelsTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new DefensiveOrbs(ABILITY_A10A_GLAIVE_STORM_ICON_NAISHA)
    {
      OrbitRadius = 350,
      OrbitalPeriod = 4,
      OrbEffectPath = @"war3mapImported\ArcaneGlaive_2.mdx",
      Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 25 },
      CollisionRadius = new LeveledAbilityField<float> { Base = 150, PerLevel = 0 },
      OrbDuration = 20,
      AbilityWhitelist = new List<int>
      {
        ABILITY_A0FC_BARBED_NET_NAISHA,
        ABILITY_A0MG_QUICK_KNIVES_NAISHA,
      }
    }, UNIT_E025_LIEUTENANT_OF_THE_WATCHERS_SENTINELS);

    UnitTypeTraitRegistry.Register(new VengeanceTrait(ABILITY_A017_TAKE_VENGEANCE_SENTINELS_MAIEV)
    {
      AlternateFormId = UNIT_ESPV_AVATAR_OF_VENGEANCE_SENTINELS_MAIEV,
      HitsReviveThreshold = 9,
      HealBase = 900,
      HealLevel = 300,
      BonusDamageBase = 20,
      BonusDamageLevel = 20,
      Duration = 20,
      ReviveEffect = "Heal Blue.mdx"
    }, UNIT_EWRD_LEADER_OF_THE_WATCHERS_SENTINELS);

    UnitTypeTraitRegistry.Register(new SpiritOfVengeanceTrait
    {
      AbilityId = ABILITY_A15W_SPIRIT_OF_VENGEANCE_SENTINELS_WARDEN,
      ChancePercent = 15,
      SpiritModelPath = @"units\nightelf\SpiritOfVengeance\SpiritOfVengeance.mdl",
      SpiritScale = 0.75f,
      SpiritDistance = 90,
      StrikeDelay = 0.4f,
      FadeDuration = 0.5f
    }, UNIT_H045_WARDEN_SENTINELS_ELITE);
  }
}
