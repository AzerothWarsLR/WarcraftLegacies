using System;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Shared.Powers;

/// <summary>Makes a player's units deal more damage to some enemies, and can add a flat amount of income.</summary>
public sealed class EmpoweredAgainst : Power
{
  private readonly Func<player, bool> _isTarget;
  private readonly float _bonus;
  private readonly int _income;
  private readonly string _descriptionTemplate = "";

  /// <param name="isTarget">Whether units owned by a player take the extra damage.</param>
  /// <param name="bonus">The damage bonus as a fraction.</param>
  public EmpoweredAgainst(Func<player, bool> isTarget, float bonus)
  {
    _isTarget = isTarget;
    _bonus = bonus;
  }

  /// <summary>Gold added to the holder's income each turn.</summary>
  public int Income
  {
    get => _income;
    init
    {
      _income = value;
      RefreshDescription();
    }
  }

  /// <summary>
  /// The power's description; {bonus} is replaced with the damage bonus as a percentage and {income} with the income.
  /// </summary>
  public required string DescriptionTemplate
  {
    init
    {
      _descriptionTemplate = value;
      RefreshDescription();
    }
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    whichPlayer.GetPlayerData().BonusIncome += Income;
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    whichPlayer.GetPlayerData().BonusIncome -= Income;
  }

  private void RefreshDescription() =>
    Description = Loc.Format(_descriptionTemplate,
      ("{bonus}", ((int)(_bonus * 100 + 0.5f)).ToString()),
      ("{income}", _income.ToString()));

  private void OnDealingDamage()
  {
    if (_isTarget(@event.Unit.Owner))
    {
      @event.Damage *= 1 + _bonus;
    }
  }
}
