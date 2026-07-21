using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.UnitTraits.SecondWind;

public sealed class SecondWindBuff : BoundBuff
{
  private const float LowHealthThresholdPercent = 40f;

  public required float HealPercentPerSecond { private get; init; }

  public SecondWindBuff(unit caster, unit target) : base(caster, target)
  {
    Interval = 1f;
    BindAura(ABILITY_TP47_SECOND_WIND_BUFF_APPLICATOR, BUFF_TP48_SECOND_WIND);
  }

  public override void OnTick()
  {
    var percent = Target.GetLifePercent() < LowHealthThresholdPercent
      ? HealPercentPerSecond * 2f
      : HealPercentPerSecond;

    Target.Life += Target.MaxLife * percent / 100f;
  }

  public override void OnDeath(bool killingBlow)
  {
    Active = false;
    base.OnDeath(killingBlow);
  }
}
