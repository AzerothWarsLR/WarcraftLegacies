using MacroTools.Extensions;
using MacroTools.SpellSystem;

using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

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

    public int Duration { get; init; }
    
    /// <inheritdoc />
    public RendSoul(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var targetMaximumHitPoints = target.MaxLife;
      var healthGained = targetMaximumHitPoints * HitPointsPerTargetMaximumHitPoints;
      var manaGained = targetMaximumHitPoints * ManaPointsPerTargetMaximumHitPoints;

      AddSpecialEffect(EffectCaster, GetUnitX(caster), GetUnitY(caster)).SetLifespan();
      AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target)).SetLifespan();

      var targetPosition = target.GetPosition();
      target.Kill();
      
      caster.Heal(healthGained);
      caster.Mana += manaGained;

      var summonedUnit = CreateUnit(caster.Owner, UnitTypeSummoned, targetPosition.X, targetPosition.Y, caster.Facing);
      summonedUnit.ApplyTimedLife(0, Duration);
      summonedUnit.AddType(UNIT_TYPE_SUMMONED);
    }
  }
}