using System.Collections.Generic;
using MacroTools.Buffs;
using MacroTools.FactionSystem;
using MacroTools.Wrappers;
using WCSharp.Buffs;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Scourge.Plague
{
  public sealed class DarkConversionPeriodicAction : IPeriodicDisposableAction
  {
    private readonly List<player> _players;
    private readonly List<int> _validTargets;

    public DarkConversionPeriodicAction(List<player> players, List<int> validTargets)
    {
      _players = players;
      _validTargets = validTargets;
    }
    
    public void Action()
    {
      player? zombiePlayer = null;
      foreach (var player in _players)
      {
        var faction = player.GetFaction();
        if (faction != null && faction.ScoreStatus == ScoreStatus.Undefeated)
        {
          zombiePlayer = player;
          break;
        }
      }

      if (zombiePlayer == null)
      {
        return;
      }
      
      foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(Player(PLAYER_NEUTRAL_PASSIVE)).EmptyToList())
      {
        if (UnitAlive(unit) && !BlzIsUnitInvulnerable(unit))
        {
          foreach (var unitTypeId in _validTargets)
          {
            if (GetUnitTypeId(unit) == unitTypeId)
            {
              var darkConversionBuff = new DarkConversionBuff(zombiePlayer, unit)
              {
                TransformUnitTypeId = Constants.UNIT_NZOM_ZOMBIE_SCOURGE,
                Duration = GetRandomReal(4, 8),
                TransformEffect = @"Abilities\Spells\Demon\DarkConversion\ZombifyTarget.mdl",
                DiseaseCloudAbilityId = Constants.ABILITY_AAP1_DISEASE_CLOUD_RED_ABOMINATION_ZOMBIE
              };
              BuffSystem.Add(darkConversionBuff, StackBehaviour.Stack);
            }
          }
        }
      }
    }

    public void Dispose()
    {
      
    }

    public bool Active { get; set; }
  }
}