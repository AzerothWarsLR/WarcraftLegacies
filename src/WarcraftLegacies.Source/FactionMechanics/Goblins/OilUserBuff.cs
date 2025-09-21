using MacroTools.Powers;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.FactionMechanics.Goblins;

/// <summary>
/// Units with this buff use oil instead of mana.
/// </summary>
public sealed class OilUserBuff : PassiveBuff
{
  private readonly OilPower _oilPower;
  private trigger? _castTrigger;

  /// <summary>
  /// Construct an <see cref="OilUserBuff"/>.
  /// </summary>
  /// <param name="target">The unit with the buff.</param>
  /// <param name="oilPower">The power providing oil to the unit with the buff.</param>
  public OilUserBuff(unit target, OilPower oilPower) : base(target, target)
  {
    _oilPower = oilPower;
    _oilPower.AmountChanged += OnOilAmountChanged;
    Duration = float.MaxValue;
  }

  private void OnOilAmountChanged(object? sender, OilPower oilPower)
  {
    Target.Mana = _oilPower.Amount;
  }

  private void OnCast()
  {
    var triggerUnit = @event.Unit;
    var triggerSpell = @event.SpellAbilityId;
    var manaCost =
      triggerUnit.GetAbilityManaCost(triggerSpell, triggerUnit.GetAbilityLevel(triggerSpell) - 1);
    _oilPower.Amount -= manaCost;
    Target.Mana = _oilPower.Amount;
  }

  public override void OnApply()
  {
    _castTrigger = trigger.Create();
    _castTrigger.RegisterUnitEvent(Target, unitevent.SpellEffect);
    _castTrigger.AddAction(OnCast);
    Target.Mana = _oilPower.Amount;
  }

  public override void OnDispose()
  {
    _castTrigger.Dispose();
    _oilPower.AmountChanged -= OnOilAmountChanged;
  }
}
