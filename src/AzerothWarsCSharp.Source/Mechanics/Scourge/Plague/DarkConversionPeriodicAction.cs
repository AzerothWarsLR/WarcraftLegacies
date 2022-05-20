using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Buffs;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge.Plague
{
  public sealed class DarkConversionPeriodicAction : IPeriodicDisposableAction
  {
    private readonly player _player;
    private readonly List<int> _validTargets;

    public DarkConversionPeriodicAction(player player, List<int> validTargets)
    {
      _player = player;
      _validTargets = validTargets;
    }
    
    public void Action()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(Player(PLAYER_NEUTRAL_PASSIVE)).EmptyToList())
      {
        if (UnitAlive(unit) && !BlzIsUnitInvulnerable(unit))
        {
          foreach (var unitTypeId in _validTargets)
          {
            if (GetUnitTypeId(unit) == unitTypeId)
            {
              var darkConversionBuff = new DarkConversionBuff(_player, unit)
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