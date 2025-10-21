using System.Collections.Generic;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.IceBlock;

public sealed class IceBlockBuff : BoundBuff
{
  private effect? _effect;

  public required List<unit> Targets { get; init; }

  public required string IceBlockEffectPath { get; init; }

  public required string DissipateEffectPath { get; init; }

  /// <inheritdoc />
  public IceBlockBuff(unit caster, unit target) : base(caster, target)
  {
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _effect = effect.Create(IceBlockEffectPath, Target.X, Target.Y);
    foreach (var target in Targets)
    {
      target.SetPausedEx(true);
      target.IsInvulnerable = true;
      target.SetTimeScale(0);
    }
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (_effect != null)
    {
      _effect.SetPosition(10000, 10000, 0);
      _effect.Dispose();
    }

    effect.Create(DissipateEffectPath, Target.X, Target.Y).Dispose();
    foreach (var target in Targets)
    {
      target.SetPausedEx(false);
      target.IsInvulnerable = false;
      target.SetTimeScale(1);
    }

    if (Target != null)
    {
      Target.Dispose();
    }
  }
}
