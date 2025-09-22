using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.PassiveAbilities.Incubate;

/// <summary>
/// Causes the egg to hatch into a unit when it dies.
/// </summary>
public sealed class MatureEggBuff : PassiveBuff
{
  /// <summary>The unit type ID of the unit that gets hatched.</summary>
  public required int HatchedUnitTypeId { get; init; }

  /// <inheritdoc />
  public MatureEggBuff(unit caster) : base(caster, caster)
  {
    Duration = float.MaxValue;
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    Target.Name = "Mature Egg";
    Target.SetVertexColor(255, 255, 255, 255);
    Target.AddAbility(ABILITY_ZBBS_HATCH_INCUBATE);

    effect effect = effect.Create(@"Abilities\Spells\Items\AIem\AIemTarget.mdl", Target.X, Target.Y);
    effect.SetColor(0, 255, 0);
    effect.Scale = 0.5f;
    EffectSystem.Add(effect);
  }

  /// <inheritdoc />
  public override void OnDeath(bool killingBlow)
  {
    var rallyPoint = Target.GetRallyPoint();
    if (rallyPoint.X == 0 && rallyPoint.Y == 0)
    {
      rallyPoint = Target.GetPosition();
    }

    unit.Create(Target.Owner, HatchedUnitTypeId, Target.X, Target.Y, 270)
      .IssueOrder(ORDER_ATTACK, rallyPoint.X, rallyPoint.Y);
  }
}
