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

    public DarkConversionPeriodicAction(player player)
    {
      _player = player;
    }
    
    public void Action()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(Player(PLAYER_NEUTRAL_PASSIVE)).EmptyToList())
      {
        var darkConversionBuff = new DarkConversionBuff(_player, unit)
        {
          TransformUnitTypeId = Constants.UNIT_NZOM_ZOMBIE_SCOURGE,
          Duration = 6,
          TransformEffect = @"Abilities\Spells\Demon\DarkConversion\ZombifyTarget.mdl",
          DiseaseCloudAbilityId = Constants.ABILITY_AAP1_DISEASE_CLOUD_RED_ABOMINATION_ZOMBIE
        };
        BuffSystem.Add(darkConversionBuff);
      }
    }

    public void Dispose()
    {
      
    }

    public bool Active { get; set; }
  }
}