using MacroTools.Factions;
using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Lightnings;

namespace WarcraftLegacies.Source.Powers;

public sealed class KiljaedensCunning : Power
{
  private readonly float _hpPercentageHitpoints;

  public KiljaedensCunning(float hpPercentageHitpoints)
  {
    _hpPercentageHitpoints = hpPercentageHitpoints;
    Name = "Kil'jaeden's Cunning";
    IconName = "Kiljaedin";
    Description = $"Your units' Magic attacks and spell damage execute enemy units with less than {hpPercentageHitpoints}% hit points.";
  }

  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, whichPlayer.Id);
  }

  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, whichPlayer.Id);
  }

  private void OnDamage()
  {
    var attackTypeDealt = @event.AttackType;
    if (attackTypeDealt != attacktype.Magic && attackTypeDealt != attacktype.Normal)
    {
      return;
    }

    var target = @event.DamageTarget;
    if ((target.Life - @event.Damage) / target.MaxLife * 100 > _hpPercentageHitpoints)
    {
      return;
    }

    @event.Damage = @event.Unit.Life + 1;
    @event.DamageType = damagetype.Universal;

    LightningSystem.Add(new Lightning("AFOD", @event.DamageSource, target)
    {
      Duration = 1f,
      FadeDuration = 0.25f
    });
  }
}
