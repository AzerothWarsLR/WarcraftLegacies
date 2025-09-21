using System;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.Spells.Slipstream;

/// <summary>
/// A temporary two-way portal.
/// </summary>
public sealed class SlipstreamPortalBuff : PassiveBuff
{
  private SlipstreamPortalState _state = SlipstreamPortalState.Unopened;
  private effect? _progressBar;

  /// <summary>
  /// A function that tells the <see cref="SlipstreamPortalBuff"/> how to refund its cost to its caster if necessary.
  /// </summary>
  public Action<unit>? RefundFunc { get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="SlipstreamPortalBuff"/> class.
  /// </summary>
  /// <param name="caster"><inheritdoc /></param>
  /// <param name="target"><inheritdoc /></param>
  public SlipstreamPortalBuff(unit caster, unit target) : base(caster, target)
  {
    Duration = float.MaxValue;
  }

  /// <summary>
  /// Opens the portal after a delay.
  /// </summary>
  public void Open(float delay)
  {
    if (_state != SlipstreamPortalState.Unopened)
    {
      return;
    }

    _state = SlipstreamPortalState.Opening;
    _progressBar = effect.Create(@"war3mapImported\Progressbar10sec.mdx", Target.GetPosition().X, Target.GetPosition().Y);
    _progressBar.SetTimeScale(10f / delay);
    _progressBar.SetColor(Caster.Owner);
    _progressBar.SetHeight(450);
    Target.SetTimeScale(9.3f * (1 / delay));
    Target.SetAnimation("birth");
    timer.Create().Start(delay, false, () =>
    {
      if (_state == SlipstreamPortalState.Opening)
      {
        _state = SlipstreamPortalState.Stable;
        Target.SetTimeScale(1);
        Target.SetAnimation("stand");
        Target.WaygateActive = true;
        _progressBar.Dispose();
      }

      @event.ExpiredTimer.Dispose();
    });
  }

  /// <summary>
  /// Closes the portal after a delay.
  /// <para>If the portal is still opening, it closes instantly instead.</para>
  /// </summary>
  public void Close(float delay)
  {
    if (_state == SlipstreamPortalState.Opening)
    {
      RefundFunc?.Invoke(Caster);
      CloseInstantly();
      return;
    }

    if (_state != SlipstreamPortalState.Stable)
    {
      return;
    }

    _state = SlipstreamPortalState.Closing;
    Target.SetTimeScale(0.65f * (1 / delay));
    Target.SetAnimation("death");
    timer.Create().Start(delay, false, () =>
    {
      CloseInstantly();
      @event.ExpiredTimer.Dispose();
    });
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    Target.WaygateActive = false;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (_progressBar != null)
    {
      _progressBar.Dispose();
    }
  }

  private void CloseInstantly()
  {
    _state = SlipstreamPortalState.Closed;
    Target.SetTimeScale(1);
    Target.Kill();
    Target.Dispose();
    effect effect = effect.Create(@"Abilities\Spells\Human\Feedback\SpellBreakerAttack.mdl", Target.X, Target.Y);
    effect.Scale = 6;
    EffectSystem.Add(effect);
    Active = false;
  }
}
