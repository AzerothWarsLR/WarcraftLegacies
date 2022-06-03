using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Mechanics.TwilightHammer
{
  /// <summary>
  /// Grants the caster vision of the target and increases the caster's income.
  /// </summary>
  public sealed class CorruptWorkerBuff : PassiveBuff
  {
    private effect? _effect;

    public CorruptWorkerBuff(unit caster, unit target) : base(caster, target)
    {
      Duration = float.MaxValue;
    }

    public int BonusIncome { get; init; }

    public override void OnApply()
    {
      _effect = AddSpecialEffectTarget(
        GetLocalPlayer() == CastingPlayer ? @"Abilities\Spells\Other\Silence\SilenceTarget.mdl" : "", Target,
        "oerhead");
      CastingPlayer.AddBonusIncome(BonusIncome);
      UnitShareVision(Target, CastingPlayer, true);
    }

    public override void OnDispose()
    {
      DestroyEffect(_effect);
      CastingPlayer.AddBonusIncome(-BonusIncome);
      UnitShareVision(Target, CastingPlayer, false);
    }
  }
}