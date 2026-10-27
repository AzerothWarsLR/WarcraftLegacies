using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.BloodElves.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.BloodElves;

public static class BloodElvesSpells
{
  public static void Setup()
  {
    var arcaneHunger = new ArcaneHunger
    {
      AbilityTypeId = ABILITY_A196_ARCANE_HUNGER_BLOODELVES_SUNBLADE_MAGISTER,
      FedAbilityTypeId = ABILITY_A197_ARCANE_HUNGER_BLOODELVES_SUNBLADE_MAGISTER_BUFF,
      Radius = 800,
      ManaRestored = 15,
      DamageBonusPerStack = 0.15f,
      Duration = 8,
      EffectPath = @"Abilities\Spells\Undead\ReplenishMana\SpiritTouchTarget.mdl",
      SpherePath = @"Units\Human\HeroBloodElf\BloodElfBall.mdl"
    };
    arcaneHunger.Register();
    UnitTypeTraitRegistry.Register(new AttachedEffect
    {
      EffectPath = @"war3mapImported\Providence Aura Red.mdl",
      AttachmentPoint = "origin"
    }, UNIT_H0DH_SUNBLADE_MAGISTER_BLOODELVES);

    SpellRegistry.Register(new FireSpearSpell(ABILITY_A193_FIRE_SPEAR_BLOODELVES_SUNBLADE_MAGISTER)
    {
      Damage = 75,
      MaximumDamage = 900,
      Range = 900,
      Width = 100,
      Speed = 1100,
      TrailSpacing = 150,
      TrailRadius = 125,
      TrailDamagePerSecond = 15,
      TrailDuration = 5,
      SpearPath = @"war3mapImported\Fire Spear.mdl",
      HitEffectPath = @"Abilities\Weapons\FireBallMissile\FireBallMissile.mdl",
      TrailEffectPath = @"Environment\SmallBuildingFire\SmallBuildingFire2.mdl",
      BurnEffectPath = @"Abilities\Spells\Other\ImmolationRed\ImmolationRedDamage.mdl",
      Hunger = arcaneHunger
    });

    SpellRegistry.Register(new ArcaneBarrierSpell(ABILITY_A194_ARCANE_BARRIER_BLOODELVES_SUNBLADE_MAGISTER)
    {
      BarrierAbilityId = ABILITY_A195_ARCANE_BARRIER_BLOODELVES_SUNBLADE_MAGISTER_FUNCTIONAL,
      BuffAbilityId = ABILITY_A198_ARCANE_BARRIER_BLOODELVES_SUNBLADE_MAGISTER_BUFF,
      Duration = 20,
      ShieldCooldown = 30,
      ShieldEffectPath = @"war3mapImported\RuneShell.mdl",
      ShieldAttachmentPoint = "overhead"
    });
  }
}
