using MacroTools;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>Kills nearby enemy units to grant the caster Strength for a limited time.</summary>
  public sealed class Reap : Spell
  {
    /// <summary>Number of units slain by the ability.</summary>
    public LeveledAbilityField<int> UnitsSlain { get; init; } = new();

    /// <summary>Strength gained per unit slain.</summary>
    public LeveledAbilityField<int> StrengthPerUnit { get; init; } = new();

    /// <summary>How far away units can be slain.</summary>
    public LeveledAbilityField<float> Radius { get; init; } = new();

    /// <summary>An effect that briefly appears at each enemy slain.</summary>
    public string KillEffect { get; init; } = string.Empty;

    /// <summary>An effect that gets applied to the caster while they are buffed.</summary>
    public string BuffEffect { get; init; } = string.Empty;
    
    /// <inheritdoc />
    public Reap(int id) : base(id)
    {
    }
  }
}