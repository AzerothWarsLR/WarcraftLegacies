using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Buffs
{
  public sealed class CorruptBuildingBuff : PassiveBuff
  {
    public CorruptBuildingBuff(unit caster, unit target) : base(caster, target)
    {
      EffectString = @"Units\Undead\PlagueCloud\PlagueCloudtarget.mdl";
      EffectAttachmentPoint = "overhead";
    }

    public int BonusIncome { get; init; }

    public override void OnApply()
    {
      CastingPlayer.AddBonusIncome(BonusIncome);
    }

    public override void OnDispose()
    {
      CastingPlayer.AddBonusIncome(-BonusIncome);
    }
  }
}