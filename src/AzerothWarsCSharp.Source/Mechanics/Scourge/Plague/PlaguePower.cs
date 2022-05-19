using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge.Plague
{
  /// <summary>
  /// Grants the <see cref="Power"/> holder several Plague Cauldrons that periodically spawn undead units.
  /// </summary>
  public sealed class PlaguePower : Power
  {
    private readonly List<Rectangle> _plagueRects;
    private readonly int _plagueCauldronUnitTypeId;
    private readonly List<PlagueCauldronSummonParameter> _plagueCauldronSummonParameters;
    private readonly List<int> _cityBuildings = new()
    {
      FourCC("ncb0"),
      FourCC("ncb1"),
      FourCC("ncb2")
    };
    private readonly List<int> _villagerUnitTypeIds = new()
    {
      FourCC("nvlw"),
      FourCC("nvl2"),
      FourCC("nvil"),
      FourCC("nvlk"),
      FourCC("nvk2")
    };
    private readonly List<unit> _plagueCauldrons = new();
    private static readonly PeriodicDisposableTrigger<DarkConversionPeriodicAction> DarkConversionPeriodicTrigger = new(1.0f);

    public PlaguePower(List<Rectangle> plagueRects, int plagueCauldronUnitTypeId, List<PlagueCauldronSummonParameter> plagueCauldronSummonParameters)
    {
      _plagueRects = plagueRects;
      _plagueCauldronUnitTypeId = plagueCauldronUnitTypeId;
      _plagueCauldronSummonParameters = plagueCauldronSummonParameters;
      IconName = "DiseaseCloud";
      Name = "Plague of Undeath";
      Description = $"You gain {_plagueRects.Count} Plague Cauldrons which periodically spawn Zombies near them, and neutral villagers on the map are transformed into Zombies.";
    }
    
    private void CreatePlagueCauldrons(player whichPlayer)
    {
      foreach (var plagueRect in _plagueRects)
      {
        var position = plagueRect.GetRandomPoint();
        var plagueCauldron = CreateUnit(whichPlayer, _plagueCauldronUnitTypeId, position.X, position.Y, 0);
        _plagueCauldrons.Add(plagueCauldron);
        var plagueCauldronBuff = new PlagueCauldronBuff(plagueCauldron, plagueCauldron)
        {
          ZombieUnitTypeId = Constants.UNIT_NZOM_ZOMBIE_SCOURGE
        };
        BuffSystem.Add(plagueCauldronBuff);
        foreach (var parameter in _plagueCauldronSummonParameters)
        {
          GeneralHelpers.CreateUnits(parameter.FactionOverride?.Player ?? whichPlayer, parameter.SummonUnitTypeId, position.X, position.Y, 0, parameter.SummonCount);
        }
      }
    }

    private void SpawnPeasants()
    {
      var triggerUnit = GetTriggerUnit();
      var x = GetUnitX(triggerUnit);
      var y = GetUnitY(triggerUnit);
      foreach (var unitTypeId in _villagerUnitTypeIds)
      {
        CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), unitTypeId, x, y, 0);
      }
    }

    public override void OnAdd(player whichPlayer)
    {
      CreatePlagueCauldrons(whichPlayer);
      foreach (var unitTypeId in _cityBuildings)
      {
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, SpawnPeasants, unitTypeId);
      }

      DarkConversionPeriodicTrigger.Add(new DarkConversionPeriodicAction(whichPlayer, _villagerUnitTypeIds));
    }

    public override void OnRemove(player whichPlayer)
    {
      foreach (var unit in _plagueCauldrons)
      {
        KillUnit(unit);
        RemoveUnit(unit);
      }
      PlayerUnitEvents.Unregister(PlayerUnitEvent.UnitTypeDies, SpawnPeasants);
      foreach (var periodicAction in DarkConversionPeriodicTrigger.Actions)
      {
        periodicAction.Active = false;
      }
    }
  }
}