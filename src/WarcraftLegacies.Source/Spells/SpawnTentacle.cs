using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Spawns a tentacle at the target location.
  /// </summary>
  public sealed class SpawnTentacle : Spell
  {
    public required LeveledAbilityField<int> HitPoints { get; init; }
    
    public required LeveledAbilityField<int> AttackDamageBase { get; init; }
    
    public required int UnitTypeId { get; init; }
    
    public required LeveledAbilityField<float> Duration { get; init; }
    
    /// <inheritdoc />
    public SpawnTentacle(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var level = GetAbilityLevel(caster);
      
      CreateUnit(caster.OwningPlayer(), UnitTypeId, targetPoint.X, targetPoint.Y, caster.GetFacing())
        .SetTimedLife(Duration.Base + Duration.PerLevel * level)
        .SetDamageBase(AttackDamageBase.Base + AttackDamageBase.PerLevel * level)
        .SetMaximumHitpoints(HitPoints.Base + HitPoints.PerLevel * level)
        .SetLifePercent(100)
        .SetAnimation("birth")
        .QueueAnimation("stand")
        .AddType(UNIT_TYPE_SUMMONED);
    }
  }
}