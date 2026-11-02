using System.Collections.Generic;
using MacroTools.Spells;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Each attack a unit with this ability takes gives it a stack of armor for a few seconds, refreshed by every new attack.</summary>
public sealed class BattleHardened
{
  private readonly Dictionary<unit, int> _stacks = new();
  private readonly Dictionary<unit, timer> _expiries = new();

  public required int AbilityTypeId { get; init; }
  public required int BuffAbilityId { get; init; }
  public required LeveledAbilityField<int> MaximumStacks { get; init; }
  public required float StackDuration { get; init; }

  /// <summary>Starts listening for attacks.</summary>
  public void Register() => PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, OnAnyUnitDamaged);

  private void OnAnyUnitDamaged()
  {
    if (!@event.IsAttack)
    {
      return;
    }

    var hardened = @event.Unit;
    var level = hardened.GetAbilityLevel(AbilityTypeId);
    if (level == 0)
    {
      return;
    }

    var stacks = 0;
    if (_stacks.TryGetValue(hardened, out var previous))
    {
      stacks = previous;
    }

    if (stacks < MaximumStacks.GetValue(level))
    {
      SetStacks(hardened, stacks + 1);
    }

    if (!_expiries.TryGetValue(hardened, out var expiry))
    {
      expiry = timer.Create();
      _expiries[hardened] = expiry;
    }

    expiry.Start(StackDuration, false, () => SetStacks(hardened, 0));
  }

  private void SetStacks(unit hardened, int stacks)
  {
    var current = 0;
    if (_stacks.TryGetValue(hardened, out var previous))
    {
      current = previous;
    }

    BlzSetUnitArmor(hardened, BlzGetUnitArmor(hardened) + stacks - current);
    _stacks[hardened] = stacks;
    if (stacks == 0)
    {
      hardened.RemoveAbility(BuffAbilityId);
      return;
    }

    if (hardened.GetAbilityLevel(BuffAbilityId) == 0)
    {
      hardened.AddAbility(BuffAbilityId);
    }

    hardened.SetAbilityLevel(BuffAbilityId, stacks);
  }
}
