using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.ExactJustice;

/// <summary>
/// Renders the affected unit invulnerable.
/// </summary>
public sealed class ExactJusticeBuff : PassiveBuff
{
  private trigger? _noDamageTrigger;

  /// <summary>
  /// Initializes a new instance of the <see cref="ExactJusticeBuff"/> class.
  /// </summary>
  /// <param name="caster"><inheritdoc /></param>
  /// <param name="target"><inheritdoc /></param>
  public ExactJusticeBuff(unit caster, unit target) : base(caster, target)
  {
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _noDamageTrigger = trigger.Create();
    _noDamageTrigger.RegisterUnitEvent(Target, unitevent.Damaged);
    _noDamageTrigger.AddAction(() => @event.Damage = 0);
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    _noDamageTrigger.Dispose();
  }

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    Stacks++;
    return StackResult.Stack;
  }
}
