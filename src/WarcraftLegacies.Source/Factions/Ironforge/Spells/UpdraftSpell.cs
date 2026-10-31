using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Beats up a gust that knocks nearby ground enemies back and slows their attacks, hurting those slammed into walls or buildings.</summary>
public sealed class UpdraftSpell : Spell
{
  public required float Radius { get; init; }
  public required float KnockbackDistance { get; init; }
  public required float KnockbackDuration { get; init; }
  public required float WallDamage { get; init; }
  public required string WallEffectPath { get; init; }
  public required int SlowAbilityId { get; init; }
  public required string CastEffectPath { get; init; }
  public required float CastEffectDuration { get; init; }

  public UpdraftSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    EffectSystem.Add(effect.Create(CastEffectPath, caster.X, caster.Y), CastEffectDuration);
    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    foreach (var victim in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAliveAndGroundUnits(caster, victim) ||
          victim.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      Knockback.Push(victim, caster.X, caster.Y, KnockbackDistance, KnockbackDuration, () =>
      {
        effect.Create(WallEffectPath, victim.X, victim.Y).Dispose();
        caster.DealDamage(victim, WallDamage, false, false, attacktype.Normal, damagetype.Normal, weapontype.WhoKnows);
      });
      dummyCaster.CastUnit(caster, SlowAbilityId, ORDER_SLOW, 1, victim, DummyCastOriginType.Target);
    }
  }
}
