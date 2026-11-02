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
  public required int ArmorAbilityId { get; init; }
  public required LeveledAbilityField<int> MaximumStacks { get; init; }
  public required float StackDuration { get; init; }
  public required int MaximumArmorLevel { get; init; }

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

    var maximum = MaximumStacks.GetValue(level);
    if (stacks < maximum)
    {
      stacks++;
    }

    _stacks[hardened] = stacks;
    if (hardened.GetAbilityLevel(ArmorAbilityId) != stacks)
    {
      AuraLevel.SetLevel(hardened, ArmorAbilityId, stacks, MaximumArmorLevel);
    }
    if (!_expiries.TryGetValue(hardened, out var expiry))
    {
      expiry = timer.Create();
      _expiries[hardened] = expiry;
    }

    expiry.Start(StackDuration, false, () =>
    {
      _stacks[hardened] = 0;
      hardened.RemoveAbility(ArmorAbilityId);
    });
  }
}
