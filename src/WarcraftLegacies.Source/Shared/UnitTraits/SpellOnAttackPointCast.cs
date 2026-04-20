using MacroTools.DummyCasters;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WarcraftLegacies.Source.Shared.Buffs;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Shared.UnitTraits;

/// <summary>
/// When the unit deals damage, it casts a point-targeted dummy spell
/// in the direction of the attack target.
/// </summary>
public sealed class SpellOnAttackPointCast : UnitTrait, IAppliesEffectOnDamage
{
  private readonly int _abilityTypeId;

  public int DummyAbilityId { get; init; }
  public int DummyOrderId { get; init; }
  public float ProcChance { get; init; }
  public float Cooldown { get; init; }
  public int RequiredResearch { get; init; }
  public float CastDistance { get; init; } = 600;

  public SpellOnAttackPointCast(int abilityTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }

  public void OnDealsDamage()
  {
    if (!@event.IsAttack)
    {
      return;
    }

    var caster = @event.DamageSource;
    var target = @event.Unit;

    if (caster.GetAbilityLevel(_abilityTypeId) == 0)
    {
      return;
    }

    if (RequiredResearch != 0 &&
        caster.Owner.GetTechResearched(RequiredResearch, false) == 0)
    {
      return;
    }

    if (Cooldown > 0)
    {
      foreach (var buff in BuffSystem.GetBuffsOnUnit(target))
      {
        if (buff is UnitTypeTraitOnCooldownBuff cooldownBuff && cooldownBuff.Trait == this)
        {
          return;
        }
      }
    }

    if (GetRandomReal(0, 1) >= ProcChance)
    {
      return;
    }

    DoSpellPoint(caster, target);

    if (Cooldown > 0)
    {
      BuffSystem.Add(new UnitTypeTraitOnCooldownBuff(caster, target) { Trait = this, Duration = Cooldown });
    }
  }

  private void DoSpellPoint(unit caster, unit target)
  {
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, target.X, target.Y);
    var x = MathEx.GetPolarOffsetX(caster.X, CastDistance, angle);
    var y = MathEx.GetPolarOffsetY(caster.Y, CastDistance, angle);

    var point = new Point(x, y);

    DummyCasterManager.GetGlobalDummyCaster().CastPoint(
      caster.Owner,
      DummyAbilityId,
      DummyOrderId,
      caster.GetAbilityLevel(_abilityTypeId),
      point);
  }
}
