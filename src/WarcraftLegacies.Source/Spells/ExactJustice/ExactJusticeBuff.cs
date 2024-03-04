using MacroTools.Extensions;
using WCSharp.Buffs;


namespace WarcraftLegacies.Source.Spells.ExactJustice
{
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
      _noDamageTrigger = CreateTrigger()
        .RegisterUnitEvent(Target, EVENT_UNIT_DAMAGED)
        .AddAction(() => BlzSetEventDamage(0));
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      DestroyTrigger(_noDamageTrigger);
    }
    
    /// <inheritdoc />
    public override StackResult OnStack(Buff newStack)
    {
      Stacks++;
      return StackResult.Stack;
    }
  }
}