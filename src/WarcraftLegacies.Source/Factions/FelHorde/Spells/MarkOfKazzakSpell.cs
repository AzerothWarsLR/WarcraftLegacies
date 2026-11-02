using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>Drains a target's mana over time and explodes if it runs dry while marked.</summary>
public sealed class MarkOfKazzakSpell : Spell
{
  public required LeveledAbilityField<float> ManaDrainPerSecond { get; init; }
  public required LeveledAbilityField<float> ExplosionDamage { get; init; }
  public required float Duration { get; init; }
  public required float SplashRadius { get; init; }
  public required int BuffAbilityId { get; init; }
  public required int BuffId { get; init; }
  public required string ExplosionEffectPath { get; init; }

  public MarkOfKazzakSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var drain = ManaDrainPerSecond.GetValue(level);
    var damage = ExplosionDamage.GetValue(level);
    DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, BuffAbilityId, ORDER_FAERIE_FIRE, level, target, DummyCastOriginType.Caster);
    var elapsed = 0f;
    var ticker = timer.Create();
    ticker.Start(1, true, () =>
    {
      elapsed += 1;
      if (!target.Alive || elapsed > Duration)
      {
        ticker.Dispose();
        target.RemoveAbility(BuffId);
        return;
      }

      target.Mana -= drain;
      if (target.Mana > 0)
      {
        return;
      }

      ticker.Dispose();
      target.RemoveAbility(BuffId);
      Explode(caster, target, damage);
    });
  }

  private void Explode(unit caster, unit target, float damage)
  {
    effect.Create(ExplosionEffectPath, target.X, target.Y).Dispose();
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(target.X, target.Y, SplashRadius))
    {
      if (nearby == target || !CastFilters.IsTargetEnemyAndAliveUnits(caster, nearby) ||
          nearby.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      caster.DealDamage(nearby, damage / 2, false, false, attacktype.Magic, damagetype.Magic, weapontype.WhoKnows);
    }

    caster.DealDamage(target, damage, false, false, attacktype.Magic, damagetype.Magic, weapontype.WhoKnows);
  }
}
