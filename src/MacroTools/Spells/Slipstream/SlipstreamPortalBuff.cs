using MacroTools.Extensions;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Spells.Slipstream
{
  /// <summary>
  /// A temporary two-way portal.
  /// </summary>
  public sealed class SlipstreamPortalBuff : PassiveBuff
  {
    private SlipstreamPortalState _state = SlipstreamPortalState.Unopened;

    /// <summary>
    /// Initializes a new instance of the <see cref="SlipstreamPortalBuff"/> class.
    /// </summary>
    /// <param name="caster"><inheritdoc /></param>
    /// <param name="target"><inheritdoc /></param>
    public SlipstreamPortalBuff(unit caster, unit target) : base(caster, target)
    {
    }

    /// <summary>
    /// Opens the portal after a delay.
    /// </summary>
    public void Open(float delay)
    {
      if (_state != SlipstreamPortalState.Unopened) return;
      _state = SlipstreamPortalState.Opening;
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
    }
  }
}