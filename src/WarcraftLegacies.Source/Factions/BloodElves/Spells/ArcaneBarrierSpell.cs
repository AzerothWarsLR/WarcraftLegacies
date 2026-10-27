using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Localization;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BloodElves.Spells;

/// <summary>Shields a friendly unit so the next negative spell cast on it is blocked. Each unit can only be shielded so often.</summary>
public sealed class ArcaneBarrierSpell : Spell
{
  private const float CheckInterval = 0.1f;

  private readonly Dictionary<unit, timer> _barriers = new();
  private readonly HashSet<unit> _recentlyShielded = new();

  public required int BarrierAbilityId { get; init; }
  public required int BuffAbilityId { get; init; }
  public required float Duration { get; init; }
  public required float ShieldCooldown { get; init; }
  public required string ShieldEffectPath { get; init; }
  public required string ShieldAttachmentPoint { get; init; }

  public ArcaneBarrierSpell(int id) : base(id)
  {
  }

  public override void OnStartCast(unit caster, unit target, Point targetPoint)
  {
    if (!_recentlyShielded.Contains(target))
    {
      return;
    }

    caster.SetPausedEx(true);
    caster.IssueOrder("stop");
    caster.SetPausedEx(false);
    caster.Owner.DisplayError(Loc.Get("That unit was shielded too recently."));
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (_recentlyShielded.Contains(target))
    {
      return;
    }

    StartShieldCooldown(target);
    target.AddAbility(BarrierAbilityId);
    target.AddAbility(BuffAbilityId);
    var shield = effect.Create(ShieldEffectPath, target, ShieldAttachmentPoint);
    var elapsed = 0f;
    var check = timer.Create();
    _barriers[target] = check;
    check.Start(CheckInterval, true, () =>
    {
      elapsed += CheckInterval;
      if (target.Alive && elapsed < Duration && target.GetAbilityCooldownRemaining(BarrierAbilityId) <= 0)
      {
        return;
      }

      target.RemoveAbility(BarrierAbilityId);
      target.RemoveAbility(BuffAbilityId);
      shield.Dispose();
      _barriers.Remove(target);
      check.Dispose();
    });
  }

  private void StartShieldCooldown(unit target)
  {
    _recentlyShielded.Add(target);
    var cooldown = timer.Create();
    cooldown.Start(ShieldCooldown, false, () =>
    {
      _recentlyShielded.Remove(target);
      cooldown.Dispose();
    });
  }
}
