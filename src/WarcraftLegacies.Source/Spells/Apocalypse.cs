﻿using MacroTools;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using WCSharp.Missiles;
using static War3Api.Common;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Creates a line of projectiles behind the caster and sends them forward. The projectiles deal instant damage and
  /// apply a dummy spell.
  /// </summary>
  public sealed class Apocalypse : Spell
  {
    /// <summary>How far the spell travels.</summary>
    public float Range { get; init; }
    
    /// <summary>All projectiles are spaced out in a line this wide.</summary>
    public float Width { get; init; }
    
    /// <summary>How far the projectiles travel.</summary>
    public float ProjectileVelocity { get; init; }
    
    /// <summary>The radius in which the projectiles deal damage.</summary>
    public float ProjectileRadius { get; init; }
    
    /// <summary>How many projectiles to spawn.</summary>
    public int ProjectileCount { get; init; }

    /// <summary>How much instant damage the projectiles deal.</summary>
    public LeveledAbilityField<int> Damage { get; init; } = new();

    /// <summary>What the projectile looks like.</summary>
    public string ProjectileModel { get; init; } = "";
    
    /// <summary>The size of the projectile.</summary>
    public float ProjectileScale { get; init; }

    /// <summary>The visual effect that appears when a unit is struck.</summary>
    public string EffectOnHitModel { get; init; } = "";

    /// <summary>The size of <see cref="EffectOnHitModel"/>.</summary>
    public float EffectOnHitScale { get; init; }

    /// <summary>The effect that appears where each projectile is spawned.</summary>
    public string EffectOnProjectileSpawn { get; init; } = "";

    /// <summary>The size of <see cref="EffectOnProjectileSpawn"/>.</summary>
    public float EffectOnProjectileSpawnScale { get; init; }
    
    /// <summary>This ability is cast on all units struck.</summary>
    public int DummyAbilityId { get; init; }

    /// <summary>The order ID for <see cref="DummyAbilityId"/>.</summary>
    public int DummyAbilityOrderId { get; init; }

    /// <inheritdoc />
    public Apocalypse(int id) : base(id)
    {
      
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var middle = (ProjectileCount - 1) / 2;
      var casterFacing = caster.GetFacing();
      var casterX = GetUnitX(caster);
      var casterY = GetUnitY(caster);
      var level = GetAbilityLevel(caster);
      for (var i = 0; i < ProjectileCount; i++)
      {
        var projectileJourney = GetProjectileJourneyData(i, middle, casterFacing, casterX, casterY);
        AddSpecialEffect(EffectOnProjectileSpawn, projectileJourney.Origin.X, projectileJourney.Origin.Y)
          .SetScale(EffectOnProjectileSpawnScale)
          .SetLifespan();
        
        var missile = new ApocalypseProjectile(caster.OwningPlayer(), projectileJourney.Origin.X,
          projectileJourney.Origin.Y, projectileJourney.Destination.X, projectileJourney.Destination.Y)
        {
          CollisionRadius = ProjectileRadius,
          EffectString = ProjectileModel,
          EffectScale = ProjectileScale,
          Active = true,
          Caster = caster,
          CasterLaunchZ = 50f,
          TargetImpactZ = 50f,
          Speed = ProjectileVelocity,
          Damage = Damage.Base + Damage.PerLevel * level,
          EffectOnHitModel = EffectOnHitModel,
          EffectOnHitScale = EffectOnHitScale,
          EffectOnProjectileDespawnModel = EffectOnProjectileSpawn,
          EffectOnProjectileDespawnScale = EffectOnProjectileSpawnScale,
          DummyAbilityId = DummyAbilityId,
          DummyAbilityOrderId = DummyAbilityOrderId,
          DummyAbilityLevel = 1
        };
        MissileSystem.Add(missile);
      }
    }

    private ProjectileJourneyData GetProjectileJourneyData(int projectileIndex, int middleProjectileIndex, float casterFacing,
      float casterX, float casterY)
    {
      float offsetAngle = 0;
      float offsetDistance = 0;
      if (projectileIndex < middleProjectileIndex)
      {
        offsetAngle = casterFacing - 90 - 15 * (middleProjectileIndex - projectileIndex);
        offsetDistance = (middleProjectileIndex - projectileIndex) * (Width / ProjectileCount);
      }
      else if (projectileIndex > middleProjectileIndex)
      {
        offsetAngle = casterFacing + 90 + 15 * (projectileIndex - middleProjectileIndex);
        offsetDistance = (projectileIndex - middleProjectileIndex) * (Width / ProjectileCount);
      }

      var projectileOrigin = new Point(MathEx.GetPolarOffsetX(casterX, offsetDistance, offsetAngle),
        MathEx.GetPolarOffsetY(casterY, offsetDistance, offsetAngle));
      
      var projectileDestination = new Point(MathEx.GetPolarOffsetX(casterX, Range, offsetAngle),
        MathEx.GetPolarOffsetY(casterY, Range, offsetAngle));
      
      return new ProjectileJourneyData
      {
        Origin = projectileOrigin,
        Destination = projectileDestination
      };
    }

    private readonly struct ProjectileJourneyData
    {
      public Point Origin { get; init; }
      
      public Point Destination { get; init; }
    }
  }
}