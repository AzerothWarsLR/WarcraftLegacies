using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.Factions.Ironforge.UnitTraits.SecondWind;

public sealed class SecondWindBuff : BoundBuff
{
  private const float LowHealthThresholdPercent = 40f;

  public required float HealPercentPerSecond { private get; init; }
  public string HealingEffect { private get; init; }
  public float HealingEffectScale { private get; init; } = 1f;

  public SecondWindBuff(unit caster, unit target) : base(caster, target)
  {
    Interval = 1f;
    BindAura(ABILITY_TP47_SECOND_WIND_BUFF_APPLICATOR, BUFF_TP48_SECOND_WIND);
  }

  public override void OnTick()
  {
    if (Target.Life >= Target.MaxLife)
    {
      Active = false;
      return;
    }

    var percent = Target.GetLifePercent() < LowHealthThresholdPercent
      ? HealPercentPerSecond * 2f
      : HealPercentPerSecond;

    Target.Life += Target.MaxLife * percent / 100f;

    if (!string.IsNullOrEmpty(HealingEffect))
    {
      effect effect = effect.Create(HealingEffect, Target, "origin");
      effect.Scale = HealingEffectScale;
      EffectSystem.Add(effect, 1);
    }
  }
  public override void OnDeath(bool killingBlow)
  {
    Active = false;
    base.OnDeath(killingBlow);
  }
}
