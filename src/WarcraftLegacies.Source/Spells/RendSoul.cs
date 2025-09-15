using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Effects;
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

    public int Duration { get; init; }
    
    /// <inheritdoc />
    public RendSoul(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var targetMaximumHitPoints = BlzGetUnitMaxHP(target);
      var healthGained = targetMaximumHitPoints * HitPointsPerTargetMaximumHitPoints;
      var manaGained = targetMaximumHitPoints * ManaPointsPerTargetMaximumHitPoints;

      EffectSystem.Add(AddSpecialEffect(EffectCaster, GetUnitX(caster), GetUnitY(caster)));
      EffectSystem.Add(AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target)));

      var targetPosition = target.GetPosition();
      KillUnit(target);

      caster.Heal(healthGained);
      caster.RestoreMana(manaGained);

      var summonedUnit = CreateUnit(GetOwningPlayer(caster), UnitTypeSummoned, targetPosition.X, targetPosition.Y, GetUnitFacing(caster));
      summonedUnit.SetTimedLife(Duration);
      UnitAddType(summonedUnit, UNIT_TYPE_SUMMONED);
    }
  }
}