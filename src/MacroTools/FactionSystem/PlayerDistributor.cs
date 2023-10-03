using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace MacroTools.FactionSystem
{
  /// <summary>
  /// Used to distribute player's resources to their allies.
  /// </summary>
  public static class PlayerDistributor
  {
    /// <summary>How much gold and lumber is refunded from units that get refunded when a player leaves.</summary>
    private const float RefundMultiplier = 1;

    /// <summary>How much experience is transferred from heroes that leave the game.</summary>
    private const float ExperienceTransferMultiplier = 1;
    
    /// <summary>The gold cost value of a hero.</summary>
    private const int HeroCost = 100;
    
    /// <summary>
    /// Attempts to distribute the <see cref="Faction"/>'s units, hero experience, and resources to their allies.
    /// </summary>
    public static void DistributeAll(player player)
    {
      var playerTeam = player.GetTeam();
      if (playerTeam == null)
        throw new InvalidOperationException($"Cannot distribute units and resources for {GetPlayerName(player)} because they have no team.");
      
      playerTeam.PlayersToDistribute.Enqueue(player);
      while (playerTeam.PlayersToDistribute.Count > 0 && playerTeam.ProcessingDistributeQueue)
      {
        playerTeam.ProcessingDistributeQueue = true;
        var queueValue = playerTeam.PlayersToDistribute.Dequeue();
        var eligiblePlayers = queueValue
          .GetTeam()?
          .GetAllFactions()
          .Where(x => x.ScoreStatus == ScoreStatus.Undefeated && x.Player != queueValue)
          .Select(x => x.Player)
          .ToList();
        
        if (eligiblePlayers != null && eligiblePlayers.Any() && GameTime.GetGameTime() > 60)
        {
          var resourcesToRefund = DistributeAndRefundUnits(player, eligiblePlayers);
          DistributeGoldAndLumber(player, eligiblePlayers, resourcesToRefund);
          DistributeExperience(eligiblePlayers, resourcesToRefund.Experience);
          queueValue.GetFaction()?.RemoveGoldMines();
        }
        else
        {
          queueValue.GetFaction()?.RemoveGoldMines();
          queueValue.GetFaction()?.RemoveResourcesAndUnits();
        }
      }

      playerTeam.ProcessingDistributeQueue = false;
    }
    
    private static void DistributeExperience(List<player> playersToDistributeTo, int experience)
    {
      foreach (var ally in playersToDistributeTo)
      {
        var allyHeroes = CreateGroup()
          .EnumUnitsOfPlayer(ally)
          .EmptyToList()
          .FindAll(unit => IsUnitType(unit, UNIT_TYPE_HERO));

        foreach (var hero in allyHeroes)
        {
          var expToAdd = (int)((float)experience / (playersToDistributeTo.Count - 1) / allyHeroes.Count * ExperienceTransferMultiplier);
          AddHeroXP(hero, expToAdd,true);
        }
      }
    }

    private static void DistributeGoldAndLumber(player playerToDistribute, List<player?> playersToDistributeTo, UnitRefund refund)
    {
      var goldToDistribute = refund.Gold + playerToDistribute.GetGold();
      var lumberToDistribute = refund.Gold + playerToDistribute.GetLumber();
      
      foreach (var player in playersToDistributeTo)
      {
        if (player == null) 
          continue;
        
        player.AddGold(goldToDistribute / playersToDistributeTo.Count);
        player.AddLumber(lumberToDistribute / playersToDistributeTo.Count);
      }

      playerToDistribute.SetGold(0);
      playerToDistribute.SetLumber(0);
    }

    /// <summary>
    /// Distributes some of the player's units to their allies, and refunds others.
    /// </summary>
    /// <param name="playerToDistribute">The player to distribute the units of.</param>
    /// <param name="playersToDistributeTo">Who to distribute the units to.</param>
    /// <returns>Resources to be refunded from units that the process removes.</returns>
    private static UnitRefund DistributeAndRefundUnits(player playerToDistribute, IReadOnlyList<player?> playersToDistributeTo)
    {
      var playerUnits = CreateGroup()
        .EnumUnitsOfPlayer(playerToDistribute)
        .EmptyToList();

      var refund = new UnitRefund();
      foreach (var unit in playerUnits)
      {
        var loopUnitType = UnitType.GetFromHandle(unit);
        if (IsUnitType(unit, UNIT_TYPE_SUMMONED))
        {
          unit
            .Kill()
            .Remove();
          continue;
        }

        if (IsUnitType(unit, UNIT_TYPE_HERO))
        {
          playerToDistribute.AddGold(HeroCost);
          refund.Experience += GetHeroXP(unit);
          if (LegendaryHeroManager.GetFromUnit(unit) != null)
            refund.Experience -= LegendaryHeroManager.GetFromUnit(unit)!.StartingXp;
          unit
            .DropAllItems()
            .Kill()
            .Remove();
          continue;
        }

        if (!CapitalManager.UnitIsCapital(unit) && !CapitalManager.UnitIsProtector(unit) && !ControlPointManager.Instance.UnitIsControlPoint(unit) && !loopUnitType.NeverDelete)
        {
          if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE))
          {
            refund.Gold += loopUnitType.GoldCost * RefundMultiplier;
            refund.Lumber += loopUnitType.LumberCost * RefundMultiplier;
          }
          unit
            .DropAllItems()
            .Kill()
            .Remove();
          continue;
        }

        var newOwner = playerToDistribute?.GetTeam()?.Size > 1
          ? playersToDistributeTo[GetRandomInt(0, playersToDistributeTo.Count - 1)]
          : Player(GetBJPlayerNeutralVictim());
        
        unit.SetOwner(newOwner, false);
      }
      return refund;
    }

    /// <summary>Resources to be refunded from removing units.</summary>
    private sealed class UnitRefund
    {
      /// <summary>Any gold that has been refunded.</summary>
      public float Gold { get; set; }
      
      /// <summary>Any lumber that has been refunded.</summary>
      public float Lumber { get; set; }
      
      /// <summary>Any hero experience that has been refunded.</summary>
      public int Experience { get; set; }
    }
  }
}