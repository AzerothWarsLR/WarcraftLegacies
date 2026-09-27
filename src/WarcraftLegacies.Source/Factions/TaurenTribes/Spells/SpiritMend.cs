using System.Collections.Generic;
using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Lightnings;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class SpiritMend : Spell
{
  public required LeveledAbilityField<float> Healing { get; init; }

  public required int MaximumBounces { get; init; }

  public required float HealingReductionPerBounce { get; init; }

  public required float BounceRadius { get; init; }

  public required int ShieldAbilityId { get; init; }

  public string HealEffect { get; init; } = @"Abilities\Spells\Orc\HealingWave\HealingWaveTarget.mdl";

  public SpiritMend(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    Bounce(caster, caster, target, Healing.GetValue(level), MaximumBounces, level, new List<unit>());
  }

  private void Bounce(unit caster, unit origin, unit target, float amount, int bouncesRemaining, int level,
    List<unit> healed)
  {
    healed.Add(target);
    LightningSystem.Add(new Lightning("HWPB", origin, target)
    {
      Duration = 0.5f,
      FadeDuration = 0.25f
    });

    target.Life += amount;
    effect.Create(HealEffect, target, "origin").Dispose();
    DummyCasterManager.GetGlobalDummyCaster()
      .CastUnit(caster, ShieldAbilityId, ORDER_INNER_FIRE, level, target, DummyCastOriginType.Target);

    if (bouncesRemaining == 0)
    {
      return;
    }

    var nextTarget = GlobalGroup
      .EnumUnitsInRange(target.X, target.Y, BounceRadius)
      .Where(x => !healed.Contains(x) && IsValidTarget(caster, x) && x.Life < x.MaxLife)
      .MinBy(x => x.Life / x.MaxLife);

    if (nextTarget == null)
    {
      return;
    }

    PeriodicEvents.AddPeriodicEvent(() =>
    {
      Bounce(caster, target, nextTarget, amount * (1 - HealingReductionPerBounce), bouncesRemaining - 1, level,
        healed);
      return false;
    }, 0.2f);
  }

  private static bool IsValidTarget(unit caster, unit target) =>
    target.IsAllyTo(caster.Owner) &&
    target.Alive &&
    !target.IsUnitType(unittype.Structure) &&
    !target.IsUnitType(unittype.Mechanical);
}
