using MacroTools;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class Apocalypse : Spell
  {
    /// <summary>How far the spell travels.</summary>
    public float Range { get; init; }
    
    /// <summary>All projectiles are spaced out in a line this wide.</summary>
    public float Width { get; init; }
    
    public float ProjectileVelocity { get; init; }
    
    public float ProjectileRadius { get; init; }
    
    public int ProjectileCount { get; init; }

    public LeveledAbilityField<int> Damage { get; init; } = new();

    public string ProjectileModel { get; init; } = "";
    
    public float ProjectileScale { get; init; }

    public string EffectOnHitModel { get; init; } = "";

    public float EffectOnHitScale { get; init; }

    public string EffectOnProjectileSpawn { get; init; } = "";

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