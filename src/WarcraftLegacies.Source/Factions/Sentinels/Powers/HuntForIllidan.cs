using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Sentinels.Powers;

/// <summary>Strengthens all of a player's units, and makes them deal even more damage to Illidan's team.</summary>
public sealed class HuntForIllidan : Power
{
  private readonly Faction _quarry;
  private readonly float _bonus;
  private readonly float _reduction;
  private readonly float _quarryBonus;

  /// <param name="quarry">The faction whose team takes the extra damage.</param>
  /// <param name="bonus">The damage bonus for all units, and the health bonus the damage reduction is worth, as a fraction.</param>
  /// <param name="quarryBonus">The extra damage bonus against the quarry's team, as a fraction.</param>
  public HuntForIllidan(Faction quarry, float bonus, float quarryBonus)
  {
    _quarry = quarry;
    _bonus = bonus;
    _reduction = 1 - 1 / (1 + bonus);
    _quarryBonus = quarryBonus;
    Name = "The Hunt for Illidan";
    IconName = "FanOfKnives";
    Description = Loc.Format("Maiev and her Wardens will not rest until the Betrayer is caged once more. Your units deal {bonus}% more damage and take {reduction}% less damage, and deal a further {quarry}% more damage to {quarryName} and their allies.",
      ("{bonus}", ToPercent(_bonus)),
      ("{reduction}", ToPercent(_reduction)),
      ("{quarry}", ToPercent(_quarryBonus)),
      ("{quarryName}", quarry.Name));
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakingDamage, OnTakingDamage, whichPlayer.Id);
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakingDamage, OnTakingDamage, whichPlayer.Id);
  }

  private static string ToPercent(float fraction) => ((int)(fraction * 100 + 0.5f)).ToString();

  private static bool IsAffected(unit whichUnit) => !whichUnit.IsUnitType(unittype.Structure);

  private bool IsQuarry(player whichPlayer)
  {
    var quarryPlayer = _quarry.Player;
    if (quarryPlayer == null)
    {
      return false;
    }

    var quarryTeam = quarryPlayer.GetPlayerData().Team;
    return quarryTeam != null && whichPlayer.GetPlayerData().Team == quarryTeam;
  }

  private void OnDealingDamage()
  {
    var source = @event.DamageSource;
    if (source == null || !IsAffected(source))
    {
      return;
    }

    var damage = @event.Damage * (1 + _bonus);
    if (IsQuarry(@event.Unit.Owner))
    {
      damage *= 1 + _quarryBonus;
    }

    @event.Damage = damage;
  }

  private void OnTakingDamage()
  {
    if (IsAffected(@event.Unit))
    {
      @event.Damage *= 1 - _reduction;
    }
  }
}
