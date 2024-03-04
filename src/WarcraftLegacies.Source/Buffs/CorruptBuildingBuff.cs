using MacroTools.Extensions;
using WCSharp.Buffs;


namespace WarcraftLegacies.Source.Buffs
{
  public sealed class CorruptBuildingBuff : PassiveBuff
  {
    private readonly int _bonusGoldIncome;
    private readonly int _bonusHealth;
    private readonly int _bonusLumberIncome;

    public CorruptBuildingBuff(unit caster, unit target, int bonusGoldIncome, int bonusLumberIncome, int bonusHealth) : base(caster, target)
    {
      _bonusGoldIncome = bonusGoldIncome;
      _bonusLumberIncome = bonusLumberIncome;
      _bonusHealth = bonusHealth;
      EffectString = @"Units\Undead\PlagueCloud\PlagueCloudtarget.mdl";
      EffectAttachmentPoint = "overhead";
    }
    
    /// <inheritdoc/>
    public override void OnApply()
    {
      CastingPlayer.AddBonusIncome(_bonusGoldIncome);
      CastingPlayer.AddLumberIncome(_bonusLumberIncome);
      BlzSetUnitMaxHP(Target, BlzGetUnitMaxHP(Target) + _bonusHealth);
    }

    /// <inheritdoc/>
    public override void OnDispose()
    {
      CastingPlayer.AddBonusIncome(-_bonusGoldIncome);
      CastingPlayer.AddLumberIncome(-_bonusLumberIncome);
      BlzSetUnitMaxHP(Target, BlzGetUnitMaxHP(Target) - _bonusHealth);
    }
  }
}