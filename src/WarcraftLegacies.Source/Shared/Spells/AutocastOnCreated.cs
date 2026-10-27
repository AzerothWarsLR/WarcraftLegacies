using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Shared.Spells;

/// <summary>Switches on the unit's autocast ability as soon as it is created.</summary>
public sealed class AutocastOnCreated : UnitTrait, IEffectOnCreated
{
  private readonly int _orderId;

  public AutocastOnCreated(int orderId)
  {
    _orderId = orderId;
  }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    var delay = timer.Create();
    delay.Start(0, false, () =>
    {
      createdUnit.IssueOrder(_orderId);
      delay.Dispose();
    });
  }
}
