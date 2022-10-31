using WarcraftLegacies.MacroTools.FactionSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Mechanics.TwilightHammer
{
  /// <summary>
  /// Grants the caster vision of the target and increases the caster's income.
  /// </summary>
  public sealed class CorruptWorkerBuff : PassiveBuff
  {
    private effect? _effect;

    /// <summary>
    /// Initializes a new instance of the <see cref="CorruptWorkerBuff"/> class.
    /// </summary>
    public CorruptWorkerBuff(unit caster, unit target) : base(caster, target)
    {
      Duration = float.MaxValue;
    }

    /// <summary>
    /// The buff grants this much income to the casting player while it persists.
    /// </summary>
    public int BonusIncome { get; init; }

    /// <inheritdoc />
    public override void OnApply()
    {
      _effect = AddSpecialEffectTarget(
        GetLocalPlayer() == CastingPlayer ? @"Abilities\Spells\Other\Silence\SilenceTarget.mdl" : "", Target,
        "overhead");
      CastingPlayer.AddBonusIncome(BonusIncome);
      UnitShareVision(Target, CastingPlayer, true);
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      DestroyEffect(_effect);
      CastingPlayer.AddBonusIncome(-BonusIncome);
      UnitShareVision(Target, CastingPlayer, false);
    }
  }
}