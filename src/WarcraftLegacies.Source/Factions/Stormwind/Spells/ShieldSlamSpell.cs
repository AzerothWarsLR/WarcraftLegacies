using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Rushes at a target and strikes it for damage that grows with the caster's armor, stunning it.</summary>
public sealed class ShieldSlamSpell : Spell
{
  private const float Interval = 0.03f;

  public required LeveledAbilityField<float> Damage { get; init; }
  public required float DamagePerArmor { get; init; }
  public required float RushSpeed { get; init; }
  public required float StrikeDistance { get; init; }
  public required int StunAbilityId { get; init; }
  public required string HitEffectPath { get; init; }

  public ShieldSlamSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    caster.SetPausedEx(true);
    SetUnitPathing(caster, false);
    var rush = timer.Create();
    var elapsed = 0f;
    rush.Start(Interval, true, () =>
    {
      elapsed += Interval;
      var distance = MathEx.GetDistanceBetweenPoints(new Point(caster.X, caster.Y), new Point(target.X, target.Y));
      if (distance > StrikeDistance && elapsed < 1 && caster.Alive && target.Alive)
      {
        var step = RushSpeed * Interval;
        if (step > distance - StrikeDistance)
        {
          step = distance - StrikeDistance;
        }

        caster.X += (target.X - caster.X) / distance * step;
        caster.Y += (target.Y - caster.Y) / distance * step;
        return;
      }

      rush.Dispose();
      SetUnitPathing(caster, true);
      caster.SetPausedEx(false);
      if (caster.Alive && target.Alive)
      {
        Slam(caster, target, level);
      }
    });
  }

  private void Slam(unit caster, unit target, int level)
  {
    var damage = Damage.GetValue(level) + DamagePerArmor * BlzGetUnitArmor(caster);
    caster.SetAnimation("attack");
    effect.Create(HitEffectPath, target, "chest").Dispose();
    caster.DealDamage(target, damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.MetalHeavyBash);
    if (target.Alive)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, level, target, DummyCastOriginType.Target);
    }
  }
}
