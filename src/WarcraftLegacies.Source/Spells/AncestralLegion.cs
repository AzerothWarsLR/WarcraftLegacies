using MacroTools;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// When a of a given type unit dies, the caster remembers it, and can later summon copies of all of the units that died.
  /// </summary>
  public sealed class AncestralLegion : Spell
  {
    /// <summary>How long summoned units survive.</summary>
    public float Duration { get; init; }

    /// <summary>Summoned units have their hit points increased by this percentage.</summary>
    public LeveledAbilityField<float> HealthBonus { get; init; } = new();
    
    /// <summary>Summoned units have their damage increased by this percentage.</summary>
    public LeveledAbilityField<float> DamageBonus { get; init; } = new();
    
    /// <summary>The maximum number of Tauren that can be summoned.</summary>
    public LeveledAbilityField<int> SummonCap { get; init; } = new();

    /// <summary>The chance for a unit to be remembered on death.</summary>
    public float RememberChance { get; init; }

    /// <summary>Only units of this unit type ID will be remembered.</summary>
    public int RememberableUnitTypeId { get; init; }

    /// <summary>The effect to show when the spell is cast.</summary>
    public string SummonEffect { get; init; } = "";

    /// <summary>Summoned units will create this effect when they die.</summary>
    public string DeathEffect { get; init; } = "";
    
    /// <inheritdoc />
    public AncestralLegion(int id) : base(id)
    {
    }
  }
}