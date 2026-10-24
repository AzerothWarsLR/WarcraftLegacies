using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Throws a powder keg that explodes when it takes damage, or after a few seconds.</summary>
public sealed class PowderKegSpell : Spell
{
  private const float CheckInterval = 0.1f;

  public required int KegTypeId { get; init; }
  public required float FuseDuration { get; init; }
  public required float Radius { get; init; }
  public required LeveledAbilityField<float> Damage { get; init; }
  public required int StunAbilityId { get; init; }
  public required string ExplosionEffectPath { get; init; }

  public PowderKegSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var damage = Damage.GetValue(GetAbilityLevel(caster));
    var keg = unit.Create(player.NeutralPassive, KegTypeId, targetPoint.X, targetPoint.Y, caster.Facing);
    var elapsed = 0f;
    var fuse = timer.Create();
    fuse.Start(CheckInterval, true, () =>
    {
      elapsed += CheckInterval;
      if (keg.Alive && keg.Life >= keg.MaxLife && elapsed < FuseDuration)
      {
        return;
      }

      fuse.Dispose();
      Explode(caster, keg, damage);
    });
  }

  private void Explode(unit caster, unit keg, float damage)
  {
    var x = keg.X;
    var y = keg.Y;
    keg.Dispose();
    effect.Create(ExplosionEffectPath, x, y).Dispose();
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, Radius))
    {
      if (nearby.UnitType == DummyCasterManager.UnitTypeId || !CastFilters.IsTargetEnemyAndAliveUnits(caster, nearby))
      {
        continue;
      }

      caster.DealDamage(nearby, damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.WhoKnows);
      if (nearby.Alive)
      {
        DummyCasterManager.GetGlobalDummyCaster()
          .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, nearby, DummyCastOriginType.Target);
      }
    }
  }
}
