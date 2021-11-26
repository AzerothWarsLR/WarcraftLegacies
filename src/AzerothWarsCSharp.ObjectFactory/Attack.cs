using System.Collections.Generic;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.ObjectFactory
{
  /// <summary>
  /// Represents an attack on a Warcraft 3 unit. Units have between 0 and 2 attacks.
  /// </summary>
  public class Attack
  {
    public float AnimationBackswingPoint { get; set; }
    public float AnimationDamagePoint { get; set; }
    public int AreaOfEffectFullDamage { get; set; }
    public int AreaOfEffectMediumDamage { get; set; }
    public int AreaOfEffectSmallDamage { get; set; }
    public IEnumerable<Target> AreaOfEffectTargets { get; set; }
    public AttackType AttackType { get; set; }
    public float CooldownTime { get; set; }
    public int DamageBase { get; set; }
    public float DamageFactorMedium { get; set; }
    public float DamageFactorSmall { get; set; }
    public float DamageLossFactor { get; set; }
    public int DamageNumberOfDice { get; set; }
    public int DamageSidesPerDie { get; set; }
    public float DamageSpillDistance { get; set; }
    public float DamageSpillRadius { get; set; }
    public int DamageUpgradeAmount { get; set; }
    public int MaximumNumberOfTargets { get; set; }
    public float ProjectileArc { get; set; }
    public string ProjectileArt { get; set; }
    public bool ProjectileHomingEnabled { get; set; }
    public int ProjectileSpeed { get; set; }
    public int Range { get; set; }
    public float RangeMotionBuffer { get; set; }
    public IEnumerable<Target> TargetsAllowed { get; set; }
    public CombatSound Sound { get; set; }
    public WeaponType ProjectileType { get; set; }
  }
}