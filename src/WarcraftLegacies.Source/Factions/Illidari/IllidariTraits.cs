using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Illidari.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Illidari;

public static class IllidariTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new DamageMultiplierOnAttack(ABILITY_A0YV_CRIPPLING_STRIKE_AKAMA)
    {
      BaseUnitMultiplier = 1.4f,
      LevelUnitMultiplier = 0.25f,
      BaseHeroMultiplier = 1.2f,
      LevelHeroMultiplier = 0.15f,
      OnlyAttackDamage = true
    }, UNIT_NAKA_ELDER_SAGE_ILLIDARI);

    UnitTypeTraitRegistry.Register(new Kingslayer
    {
      RequiredResearch = UPGRADE_YBPH_KINGSLAYER_ILLIDARI,
      DamageBonus = 0.6f
    }, UNIT_NDRN_DEATHSWORN_ILLIDARI);

    ItemTypeTraitRegistry.Register(new WarglaivesOfAzzinoth
    {
      Radius = 150,
      DamageBase = 35,
      DamageLevel = 0,
      DamageMultiplierAgainstDemons = 1.2f,
      Effect = @"war3mapImported\Culling Cleave.mdx",
      EffectScale = 1.2f,
      DamageType = damagetype.Magic
    }, ITEM_I0WG_WARGLAIVES_OF_AZZINOTH);
  }
}
