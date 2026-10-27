using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>Strikes a target, knocking it away from the caster and then stunning it.</summary>
public sealed class PsychicBlowSpell : Spell
{
  private const float Interval = 0.03f;

  public required LeveledAbilityField<float> Damage { get; init; }
  public required float KnockbackDistance { get; init; }
  public required float KnockbackDuration { get; init; }
  public required int StunAbilityId { get; init; }
  public required string ImpactEffectPath { get; init; }

  public PsychicBlowSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    effect.Create(ImpactEffectPath, target, "chest").Dispose();
    caster.DealDamage(target, Damage.GetValue(level), false, false, attacktype.Normal, damagetype.Magic,
      weapontype.WhoKnows);
    if (!target.Alive)
    {
      return;
    }

    var dx = target.X - caster.X;
    var dy = target.Y - caster.Y;
    var distance = SquareRoot(dx * dx + dy * dy);
    if (distance < 1)
    {
      dx = Cos(caster.Facing * MathEx.DegToRad);
      dy = Sin(caster.Facing * MathEx.DegToRad);
      distance = 1;
    }

    var step = KnockbackDistance / KnockbackDuration * Interval;
    var stepX = dx / distance * step;
    var stepY = dy / distance * step;
    var elapsed = 0f;
    var knockback = timer.Create();
    knockback.Start(Interval, true, () =>
    {
      elapsed += Interval;
      var newX = target.X + stepX;
      var newY = target.Y + stepY;
      var blocked = pathingtype.Walkability.GetPathable(newX, newY);
      if (!blocked)
      {
        target.X = newX;
        target.Y = newY;
      }

      if (!blocked && elapsed < KnockbackDuration && target.Alive)
      {
        return;
      }

      knockback.Dispose();
      if (target.Alive)
      {
        DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, level, target,
          DummyCastOriginType.Target);
      }
    });
  }
}
