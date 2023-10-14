using MacroTools.SpellSystem;
using static War3Api.Common;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Kill the target unit to restore hit points and mana based on its maximum hit points, and create a summoned unit at
  /// its position.
  /// </summary>
  public sealed class RendSoul : Spell
  {
    public float HitPointsPerTargetMaximumHitPoints { get; init; }
    
    public float ManaPointsPerTargetMaximumHitPoints { get; init; }
    
    public int UnitTypeSummoned { get; init; }

    public string EffectTarget { get; init; } = "";

    public string EffectCaster { get; init; } = "";
    
    /// <inheritdoc />
    public RendSoul(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      
    }
  }
}