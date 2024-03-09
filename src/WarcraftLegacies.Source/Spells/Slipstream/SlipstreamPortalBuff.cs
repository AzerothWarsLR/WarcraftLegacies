using System;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;


namespace WarcraftLegacies.Source.Spells.Slipstream
{
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
      if (_state != SlipstreamPortalState.Unopened) return;
      _state = SlipstreamPortalState.Opening;
      _progressBar = AddSpecialEffect(@"war3mapImported\Progressbar10sec.mdx", Target.GetPosition().X, Target.GetPosition().Y)
      _progressBar.SetTimeScale(10f / delay);
      _progressBar.SetColor(Caster.Owner);
      _progressBar.SetHeight(450);
      float speed = 9.3f * (1 / delay);
      SetUnitTimeScale(Target, speed);
      Target.SetAnimation("birth");
      CreateTimer().Start(delay, false, () =>
      {
        if (_state == SlipstreamPortalState.Opening)
        {
          _state = SlipstreamPortalState.Stable;
          SetUnitTimeScale(Target, 1);
          Target.SetAnimation("stand");
          Target.WaygateActive = true;
          _progressBar.Dispose();
        }

        DestroyTimer(GetExpiredTimer());
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

      if (_state != SlipstreamPortalState.Stable) return;

      _state = SlipstreamPortalState.Closing;
      float speed = 0.65f * (1 / delay);
      SetUnitTimeScale(Target, speed);
      Target.SetAnimation("death");
      CreateTimer().Start(delay, false, () =>
      {
        CloseInstantly();
        DestroyTimer(GetExpiredTimer());
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
      effect tempQualifier = _progressBar;
      if (tempQualifier != null)
      {
        tempQualifier.Dispose();
      }
    }

    private void CloseInstantly()
    {
      _state = SlipstreamPortalState.Closed;
      SetUnitTimeScale(Target, 1);
      Target.Kill();
      Target.Dispose();
      var closeEffect = AddSpecialEffect(@"Abilities\Spells\Human\Feedback\SpellBreakerAttack.mdl", GetUnitX(Target),
        GetUnitY(Target));
      closeEffect.SetTimeScale(6);
      EffectSystem.Add(closeEffect, (float)0.03125);
      Active = false;
    }
  }
}