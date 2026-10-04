using System.Collections.Generic;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.UnitTraits;

public sealed class LethalStrike : UnitTrait, IAppliesEffectOnDamage
{
  private readonly Dictionary<unit, unit> _lastTargets = new();

  private readonly Dictionary<unit, int> _hitCounts = new();

  public int HitsRequired { get; init; } = 4;

  public float BonusDamage { get; init; } = 40;

  public string EffectPath { get; init; } = @"Abilities\Spells\Other\Stampede\StampedeMissileDeath.mdl";

  public void OnDealsDamage()
  {
    if (!@event.IsAttack)
    {
      return;
    }

    var attacker = @event.DamageSource;
    if (IsUnitIllusion(attacker))
    {
      return;
    }

    var target = @event.Unit;

    var hits = 1;
    if (_lastTargets.TryGetValue(attacker, out var lastTarget) && lastTarget == target)
    {
      hits = _hitCounts[attacker] + 1;
    }

    if (hits < HitsRequired)
    {
      _lastTargets[attacker] = target;
      _hitCounts[attacker] = hits;
      return;
    }

    _lastTargets.Remove(attacker);
    _hitCounts.Remove(attacker);
    @event.Damage += BonusDamage;
    effect.Create(EffectPath, target, "chest").Dispose();
    ShowBonusText(target, R2I(@event.Damage));
  }

  private static void ShowBonusText(unit target, int damage)
  {
    var text = CreateTextTag();
    SetTextTagText(text, $"{damage}!", 0.024f);
    SetTextTagPosUnit(text, target, 0);
    SetTextTagColor(text, 255, 0, 0, 255);
    SetTextTagVelocity(text, 0, 0.04f);
    SetTextTagPermanent(text, false);
    SetTextTagLifespan(text, 2);
    SetTextTagFadepoint(text, 1);
  }
}
