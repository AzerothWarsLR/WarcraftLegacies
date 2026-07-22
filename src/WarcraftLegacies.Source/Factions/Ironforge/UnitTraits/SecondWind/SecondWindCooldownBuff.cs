using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.UnitTraits.SecondWind;

public sealed class SecondWindCooldownBuff : PassiveBuff
{
  public required float HealPercentPerSecond { private get; init; }

  public SecondWindCooldownBuff(unit target) : base(target, target)
  {
  }

  public override void OnExpire()
  {
    BuffSystem.Add(new SecondWindBuff(Target, Target)
    {
      Active = true,
      Duration = float.MaxValue,
      IsBeneficial = true,
      HealPercentPerSecond = HealPercentPerSecond
    });
  }

  public override void OnDeath(bool killingBlow)
  {
    Active = false;
    base.OnDeath(killingBlow);
  }
}
