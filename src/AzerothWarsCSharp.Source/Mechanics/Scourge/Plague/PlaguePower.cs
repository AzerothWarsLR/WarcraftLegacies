using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge.Plague
{
  /// <summary>
  ///   Grants the <see cref="Power" /> holder several Plague Cauldrons that periodically spawn undead units.
  /// </summary>
  public sealed class PlaguePower : Power
  {
    private static readonly PeriodicDisposableTrigger<DarkConversionPeriodicAction> DarkConversionPeriodicTrigger =
      new(1.0f);

    /// <summary>
    /// A list of all players that have this <see cref="Power"/>.
    /// </summary>
    private readonly List<player> _holders = new();
    
    private readonly List<int> _cityBuildings = new()
    {
      FourCC("ncb0"),
      FourCC("ncb1"),
      FourCC("ncb2"),
      FourCC("ncb3"),
      FourCC("ncb4"),
      FourCC("ncb5"),
      FourCC("ncb6"),
      FourCC("ncb7"),
      FourCC("ncb8"),
      FourCC("ncb9"),
      FourCC("ncba"),
      FourCC("ncbb"),
      FourCC("ncbc"),
      FourCC("ncbd"),
      FourCC("ncbb"),
      FourCC("ncbe"),
      FourCC("ncbf")
    };

    private readonly List<int> _villagerUnitTypeIds = new()
    {
      FourCC("nvlw"),
      FourCC("nvl2"),
      FourCC("nvil"),
      FourCC("nvlk"),
      FourCC("nvk2")
    };

    /// <summary>
    /// Causes <see cref="Power" /> holder to periodically convert villagers on the map into Zombies.
    /// </summary>
    public PlaguePower()
    {
      IconName = "PlagueBarrel";
      Name = "Plague of Undeath";
      Description = "All villagers on the map are periodically transformed into Zombies.";
    }

    private void SpawnPeasants()
    {
      var triggerUnit = GetTriggerUnit();
      var x = GetUnitX(triggerUnit);
      var y = GetUnitY(triggerUnit);

      for (var i = 0; i < 2; i++)
        CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),
          _villagerUnitTypeIds[GetRandomInt(0, _villagerUnitTypeIds.Count - 1)], x, y, 0);
    }

    public override void OnAdd(player whichPlayer)
    {
      if (_holders.Count == 0)
      {
        foreach (var unitTypeId in _cityBuildings)
          PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, SpawnPeasants, unitTypeId);
      }
      _holders.Add(whichPlayer);
      DarkConversionPeriodicTrigger.Add(new DarkConversionPeriodicAction(_holders, _villagerUnitTypeIds));
    }

    public override void OnRemove(player whichPlayer)
    {
      _holders.Remove(whichPlayer);
      if (_holders.Count == 0)
      {
        PlayerUnitEvents.Unregister(PlayerUnitEvent.UnitTypeDies, SpawnPeasants);
        foreach (var periodicAction in DarkConversionPeriodicTrigger.Actions) 
          periodicAction.Active = false;
      }
    }
  }
}