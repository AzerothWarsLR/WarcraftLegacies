using MacroTools;
using MacroTools.SpellSystem;

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
    public string DummyAbilityOrderId { get; init; } = "";

    /// <inheritdoc />
    public Apocalypse(int id) : base(id)
    {
    }
  }
}