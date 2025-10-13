using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using MacroTools.Systems;
using MacroTools.Utils;

namespace MacroTools.FactionSystem;

/// <summary>
/// Used to distribute player's resources to their allies.
/// </summary>
public static class PlayerDistributor
{
  /// <summary>How much gold is refunded from units that get refunded when a player leaves.</summary>
  private const float RefundMultiplier = 1;

  /// <summary>The gold cost value of a hero.</summary>
  public const int HeroCost = 100;

  /// <summary>
  /// Attempts to distribute the <see cref="Faction"/>'s units, hero experience, and resources to their allies.
  /// </summary>
  public static void DistributePlayer(player player)
  {
    var eligiblePlayers = GetPlayersEligibleForReceivingDistribution(player);
    if (eligiblePlayers.Count != 0)
    {
      var resourcesToRefund = DistributeAndRefundUnits(player, eligiblePlayers);
      DistributeGold(player, eligiblePlayers, resourcesToRefund);
      DistributeExperience(eligiblePlayers, resourcesToRefund.Experience);
    }
    else
    {
      player.RemoveAllUnits();
      player.Gold = 0;
    }
  }

  private static List<player> GetPlayersEligibleForReceivingDistribution(player playerBeingDistributed)
  {
    var eligiblePlayers = new List<player>();

    var team = playerBeingDistributed.GetTeam();
    if (team == null)
    {
      return eligiblePlayers;
    }

    foreach (var faction in team
               .GetAllFactions()
               .Where(x => x.ScoreStatus == ScoreStatus.Undefeated && x.Player != playerBeingDistributed))
    {
      var factionPlayer = faction.Player;
      if (factionPlayer != null)
      {
        eligiblePlayers.Add(factionPlayer);
      }
    }

    return eligiblePlayers;
  }

  private static void DistributeExperience(List<player> playersToDistributeTo, int experience)
  {
    var experiencePerPlayer = experience / playersToDistributeTo.Count;
    foreach (var ally in playersToDistributeTo)
    {
      var allyHeroes = GlobalGroup
        .EnumUnitsOfPlayer(ally)
        .FindAll(unit => unit.IsUnitType(unittype.Hero));

      foreach (var hero in allyHeroes)
      {
        var expToAdd = (int)((float)experiencePerPlayer / allyHeroes.Count);
        AddHeroXP(hero, expToAdd, true);
      }
    }
  }

  private static void DistributeGold(player playerToDistribute, List<player> playersToDistributeTo, UnitsRefund refund)
  {
    var goldToDistribute = refund.Gold + playerToDistribute.Gold;

    foreach (var player in playersToDistributeTo)
    {
      player.GetPlayerData().AddFractionalGold(goldToDistribute / playersToDistributeTo.Count);
    }

    playerToDistribute.Gold = 0;
  }

  /// <summary>
  /// Distributes some of the player's units to their allies, and refunds others.
  /// </summary>
  /// <param name="playerToDistribute">The player to distribute the units of.</param>
  /// <param name="playersToDistributeTo">Who to distribute the units to.</param>
  /// <returns>Resources to be refunded from units that the process removes.</returns>
  private static UnitsRefund DistributeAndRefundUnits(player playerToDistribute, IReadOnlyList<player> playersToDistributeTo)
  {
    var playerUnits = GlobalGroup
      .EnumUnitsOfPlayer(playerToDistribute);

    var refund = new UnitsRefund();
    foreach (var unit in playerUnits)
    {
      var loopUnitType = UnitType.GetFromHandle(unit);
      if (unit.IsUnitType(unittype.Summoned))
      {
        unit.SafelyRemove();
        continue;
      }

      if (unit.IsUnitType(unittype.Hero))
      {
        refund.Gold += HeroCost;
        refund.Experience += unit.Experience;
        if (LegendaryHeroManager.GetFromUnit(unit) != null)
        {
          refund.Experience -= LegendaryHeroManager.GetFromUnit(unit)!.StartingXp;
        }

        unit.SafelyRemove();
        continue;
      }

      if (unit.IsRemovable())
      {
        if (!unit.IsUnitType(unittype.Structure))
        {
          refund.Gold += loopUnitType.GoldCost * RefundMultiplier;
        }

        unit.DropAllItems();
        unit.Kill();
        unit.Dispose();
        continue;
      }

      var newOwner = playerToDistribute.GetTeam()?.Size > 1
        ? playersToDistributeTo[GetRandomInt(0, playersToDistributeTo.Count - 1)]
        : player.NeutralVictim;

      unit.SetOwner(newOwner);
    }
    return refund;
  }

  /// <summary>Resources to be refunded from removing units.</summary>
  private sealed class UnitsRefund
  {
    /// <summary>Any gold that has been refunded.</summary>
    public float Gold { get; set; }

    /// <summary>Any hero experience that has been refunded.</summary>
    public int Experience { get; set; }
  }
}
