using System;
using MacroTools.Extensions;
using WCSharp.Buffs;
using static War3Api.Common;

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
        .SetTimeScale(10f / delay)
        .SetColor(Caster.OwningPlayer())
        .SetHeight(450);
      Target
        .SetAnimationSpeed(9.3f * (1 / delay))
        .SetAnimation("birth");
      CreateTimer().Start(delay, false, () =>
      {
        if (_state == SlipstreamPortalState.Opening)
        {
          _state = SlipstreamPortalState.Stable;
          Target
            .SetAnimationSpeed(1)
            .SetAnimation("stand")
            .SetWaygateActive(true);
          _progressBar.Destroy();
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
      Target
        .SetAnimationSpeed(0.65f * (1 / delay))
        .SetAnimation("death");
      CreateTimer().Start(delay, false, () =>
      {
        CloseInstantly();
        DestroyTimer(GetExpiredTimer());
      });
    }

    /// <inheritdoc />
    public override void OnApply()
    {
      Target.SetWaygateActive(false);
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      _progressBar?.Destroy();
    }

    private void CloseInstantly()
    {
      _state = SlipstreamPortalState.Closed;
      Target
        .SetAnimationSpeed(1)
        .Kill()
        .Remove();
      AddSpecialEffect(@"Abilities\Spells\Human\Feedback\SpellBreakerAttack.mdl", GetUnitX(Target), GetUnitY(Target))
        .SetScale(6)
        .SetLifespan();
      Active = false;
    }
  }
}