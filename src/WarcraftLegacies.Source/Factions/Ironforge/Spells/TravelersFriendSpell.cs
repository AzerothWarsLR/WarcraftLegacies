using System.Collections.Generic;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>The caster latches onto a friendly unit and follows it, giving that unit True Sight.</summary>
public sealed class TravelersFriendSpell : Spell
{
  private const float FollowInterval = 0.05f;

  private readonly Dictionary<unit, Latch> _latches = new();

  public required int DetachAbilityId { get; init; }
  public required int TrueSightAbilityId { get; init; }

  public TravelersFriendSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (_latches.ContainsKey(caster) || target == caster || target.IsUnitType(unittype.Structure))
    {
      return;
    }

    var latch = new Latch
    {
      Host = target,
      AddedTrueSight = target.GetAbilityLevel(TrueSightAbilityId) == 0,
      Timer = timer.Create()
    };
    _latches[caster] = latch;
    if (latch.AddedTrueSight)
    {
      target.AddAbility(TrueSightAbilityId);
    }

    SetUnitPathing(caster, false);
    caster.HideAbility(Id, true);
    caster.AddAbility(DetachAbilityId);
    latch.Timer.Start(FollowInterval, true, () =>
    {
      if (!caster.Alive || !target.Alive)
      {
        Detach(caster);
        return;
      }

      caster.X = target.X;
      caster.Y = target.Y;
    });
  }

  /// <summary>Lets go of whatever unit the caster is attached to.</summary>
  public void Detach(unit caster)
  {
    if (!_latches.TryGetValue(caster, out var latch))
    {
      return;
    }

    _latches.Remove(caster);
    latch.Timer.Dispose();
    if (latch.AddedTrueSight)
    {
      latch.Host.RemoveAbility(TrueSightAbilityId);
    }

    SetUnitPathing(caster, true);
    caster.RemoveAbility(DetachAbilityId);
    caster.HideAbility(Id, false);
  }

  private sealed class Latch
  {
    public required unit Host { get; init; }
    public required bool AddedTrueSight { get; init; }
    public required timer Timer { get; init; }
  }
}

/// <summary>Ends <see cref="TravelersFriendSpell"/> for the caster.</summary>
public sealed class TravelersFriendDetachSpell : Spell
{
  public required TravelersFriendSpell TravelersFriend { get; init; }

  public TravelersFriendDetachSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint) => TravelersFriend.Detach(caster);
}
