using System;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Casts Death Coil on all targets in the area. When upgraded, also heals the caster.
/// </summary>
public sealed class MassDeathCoil : Spell
{
  public int DummyAbilityId { get; init; }

  public int DummyAbilityOrderId { get; init; }

  public float Radius { get; init; }

  public int CasterHealPerTargetUpgraded { get; init; }

  /// <summary>A caster matching this condition is considered to have the upgraded version of the spell.</summary>
  public Func<unit, bool> UpgradeCondition { get; init; } = _ => false;

  public MassDeathCoil(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var dummyTargets = GlobalGroup
      .EnumUnitsInRange(targetPoint, Radius)
      .FindAll(unit => CastFilters.IsTargetOrganicAndAlive(caster, unit));

    if (UpgradeCondition(caster))
    {
      effect.Create(@"Abilities\Spells\Human\Heal\HealTarget.mdl", caster, "origin").Dispose();
      foreach (var unused in dummyTargets)
      {
        caster.Life += CasterHealPerTargetUpgraded;
      }
    }

    var dummyCaster = DummyCasterManager.GetAbilitySpecificDummyCaster(DummyAbilityId, DummyAbilityOrderId);
    dummyCaster.CastOnTargets(caster, GetAbilityLevel(caster), dummyTargets, DummyCastOriginType.Caster);
  }
}
