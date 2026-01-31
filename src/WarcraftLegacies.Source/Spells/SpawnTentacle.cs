using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

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

    var tentacle = unit.Create(caster.Owner, UnitTypeId, targetPoint.X, targetPoint.Y, caster.Facing);
    tentacle.SetTimedLife(Duration.Base + Duration.PerLevel * level);
    tentacle.AttackBaseDamage1 = AttackDamageBase.Base + AttackDamageBase.PerLevel * level;
    tentacle.MaxLife = HitPoints.Base + HitPoints.PerLevel * level;
    tentacle.SetLifePercent(100);
    tentacle.SetAnimation("birth");
    tentacle.QueueAnimation("stand");
    tentacle.AddType(unittype.Summoned);
  }
}
