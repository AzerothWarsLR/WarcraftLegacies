using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.TwilightHammer
{
  public sealed class CorruptWorkerBuff : PassiveBuff
  {
    public CorruptWorkerBuff(unit caster, unit target) : base(caster, target)
    {
      Duration = float.MaxValue;
    }

    public int BonusIncome { get; init; }

    public override void OnApply()
    {
      CastingPlayer.AddBonusIncome(BonusIncome);
      UnitShareVision(Target, CastingPlayer, true);
    }

    public override void OnDispose()
    {
      CastingPlayer.AddBonusIncome(-BonusIncome);
      UnitShareVision(Target, CastingPlayer, false);
    }
  }
}