using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Factions.Stormwind.Powers;

/// <summary>Adds to its holder's income while it is active.</summary>
public sealed class ThandolSpanTolls : Power
{
  private readonly int _income;
  private player? _holder;
  private bool _paying;

  public ThandolSpanTolls(int income)
  {
    _income = income;
    SetActive(false);
  }

  /// <summary>Starts or stops the tolls; greyed out in the Powers menu while stopped.</summary>
  public void SetActive(bool active)
  {
    IsActive = active;
    var text = Loc.Format(
      "Caravans crossing the Thandol Span add {gold} gold to your income. Requires completing Masters of the Span, and only active while you hold both Arathi Highlands and Dun Modr.",
      ("{gold}", _income.ToString()));
    Description = active ? text : "|cff808080" + text + "|r";
    RefreshIncome();
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    _holder = whichPlayer;
    RefreshIncome();
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    if (_paying)
    {
      whichPlayer.GetPlayerData().BonusIncome -= _income;
      _paying = false;
    }

    _holder = null;
  }

  private void RefreshIncome()
  {
    if (_holder == null)
    {
      return;
    }

    var shouldPay = IsActive;
    if (shouldPay == _paying)
    {
      return;
    }

    _paying = shouldPay;
    _holder.GetPlayerData().BonusIncome += shouldPay ? _income : -_income;
  }
}
