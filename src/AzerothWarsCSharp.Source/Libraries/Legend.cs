using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzerothWarsCSharp.Common.Constants;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Libraries
{
  public class LegendDiesEventArgs : EventArgs
  {
    public Legend DyingLegend;
  }

  public class LegendPreDiesEventArgs : EventArgs
  {
    public Legend DyingLegend;
  }

  public class LegendChangesOwnerEventArgs : EventArgs
  {
    public Legend LegendChangingOwner;
  }

  /// <summary>
  /// A Legend is a wrapper for unique heroes. A Legend can continue to exist even if the unit it describes does not. 
  /// A Legend might have other units it relies on to survive. If so, when it dies, it gets removed if those units are not under control.
  /// There is a dummy ability to represent this.
  /// </summary>
  /// 
  public class Legend
  {
    private static readonly int DUMMY_DIESWITHOUT = FourCC("LEgn");
    private static readonly int DUMMY_PERMADIES = FourCC("LEgo");
    private static readonly Dictionary<unit,Legend> _byUnitHandle = new();

    private unit _unit;
    private int _unitType;
    private bool _alwaysPermaDies = false;
    private group _diesWithout = null;
    private playercolor _playerColor = null;

    /// <summary>
    /// Retrieve a Legend by the unit handle it is being represented by.
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static Legend ByUnitHandle(unit handle)
    {
      return _byUnitHandle[handle];
    }

    /// <summary>
    /// The unit currently representing this Legend.
    /// Can be changed during runtime.
    /// </summary>
    public unit Unit
    {
      get
      {
        if (GetOwningPlayer(_unit) == null)
        {
          return null;
        }
        return _unit;
      }
      set
      {
        if (_unit != null)
        {
          UnitUtils.UnitDropAllItems(_unit);
          RemoveUnit(_unit);
        }
        _unit = value;
        if (value != null)
        {
          UnitType = GetUnitTypeId(value);
          //Reassert color
          if (_playerColor != null)
          {
            SetUnitColor(_unit, _playerColor);
          }
          else
          {
            SetUnitColor(_unit, GetPlayerColor(GetOwningPlayer(_unit)));
          }
          //Set XP to starting XP
          if (GetHeroXP(_unit) < StartingXP)
          {
            SetHeroXP(_unit, StartingXP, true);
          }
        }
        RefreshDummy();
      }
    }

    /// <summary>
    /// Can be used to predetermine the type of unit that a Legend will be when spawned,
    /// or to change the Legend's unit type while already spawned.
    /// </summary>
    public int UnitType
    {
      get
      {
        return _unitType;
      }
      set
      {
        if (_unit != null)
        {
          var oldX = GetUnitX(_unit);
          var oldY = GetUnitY(_unit);
          var newUnit = CreateUnit(OwningPlayer, value, oldX, oldY, GetUnitFacing(_unit));
          SetUnitState(newUnit, UNIT_STATE_LIFE, GetUnitState(_unit, UNIT_STATE_LIFE));
          SetUnitState(newUnit, UNIT_STATE_MANA, GetUnitState(_unit, UNIT_STATE_MANA));
          SetHeroXP(newUnit, GetHeroXP(_unit), false);
          UnitUtils.UnitTransferItems(_unit, newUnit);
          RemoveUnit(_unit);
          _unit = newUnit;
          SetUnitPosition(_unit, oldX, oldY);
        }
        _unitType = value;
      }
    }

    /// <summary>
    /// The name of the Legend displayed in event messages.
    /// </summary>
    public string Name
    {
      get
      {
        if (IsUnitType(_unit, UNIT_TYPE_HERO))
        {
          return GetHeroProperName(_unit);
        }
        if (_unitType != 0)
        {
          return GetObjectName(_unitType);
        }
        if (_unit != null)
        {
          return GetUnitName(_unit);
        }
        return null;
      }
    }

    /// <summary>
    /// Custom unit color refreshed every time the Legend is spawned.
    /// </summary>
    public playercolor PlayerColor
    {
      get
      {
        return _playerColor;
      }
      private set
      {
        if (_unit != null)
        {
          SetUnitColor(_unit, value);
        }
        _playerColor = value;
      }
    }

    /// <summary>
    /// The experience the Legend is spawned with. Must be set manually.
    /// </summary>
    public int StartingXP { get; set; }

    /// <summary>
    /// Legends with this set are removed when they die and cannot be revived.
    /// </summary>
    public bool AlwaysPermaDies
    {
      get
      {
        return _alwaysPermaDies;
      }
      set
      {
        _alwaysPermaDies = value;
        RefreshDummy();
      }
    }

    /// <summary>
    /// The visual effect that appears when this Legend permanently dies.
    /// </summary>
    public effect DeathSfx { get; set; }

    /// <summary>
    /// The popup text that appears when this Legend permanently dies.
    /// </summary>
    public string DeathMessage { get; set; }

    /// <summary>
    /// Capturable Legends change owner to the units that reduce their hitpoints to 0 instead of dying.
    /// </summary>
    public bool Capturable { get; set; }

    /// <summary>
    /// If a Legend is a Hivemind, it defeats its entire team when it permanently dies.
    /// </summary>
    public bool Hivemind { get; set; }

    /// <summary>
    /// The player that owns this Legend.
    /// </summary>
    public player OwningPlayer
    {
      get
      {
        return GetOwningPlayer(_unit);
      }
    }

    /// <summary>
    /// Stops this Legend from being dependent on other uits to live.
    /// </summary>
    public void ClearUnitDependencies()
    {
      DestroyGroup(_diesWithout);
      RefreshDummy();
    }

    /// <summary>
    /// If a Legend has any dependencies, it permanently dies when it dies when none of those dependencies are under control.
    /// </summary>
    /// <param name="dependency"></param>
    public void AddUnitDependency(unit dependency)
    {
      if (_diesWithout == null)
      {
        _diesWithout = CreateGroup();
      }
      GroupAddUnit(_diesWithout, dependency);
      RefreshDummy();
    }

    /// <summary>
    /// Instantiates the Legend somewhere in the game world as a unit.
    /// </summary>
    public void Spawn(player owner, float x, float y, float facing = 0)
    {
      if (_unit == null)
      {
        _unit = CreateUnit(owner, _unitType, x, y, facing);
      }
      else if (!UnitAlive(_unit))
      {
        ReviveHero(_unit, x, y, false);
      }
      else
      {
        SetUnitX(_unit, x);
        SetUnitY(_unit, y);
        SetUnitFacing(_unit, facing);
      }
      if (GetOwningPlayer(_unit) != owner)
      {
        SetUnitOwner(_unit, owner, true);
      }
      RefreshDummy();
    }

    /// <summary>
    /// Updates the Legend ability icon on the unit which tells the user how this unit can permanently die.
    /// </summary>
    private void RefreshDummy()
    {
      var tooltip = "";
      if (_alwaysPermaDies)
      {
        UnitAddAbility(_unit, DUMMY_PERMADIES);
      }
      else
      {
        UnitRemoveAbility(_unit, DUMMY_PERMADIES);
        if (_diesWithout != null)
        {
          var tempGroup = CreateGroup();
          tooltip += "When this unit dies, it will be unrevivable unless any of the following capitals are under your control:\n";
          BlzGroupAddGroupFast(_diesWithout, tempGroup);
          do {
            var firstOfGroup = FirstOfGroup(tempGroup);
            tooltip += " - " + GetUnitName(firstOfGroup) + "|n";
            GroupRemoveUnit(tempGroup, firstOfGroup);
          } while (BlzGroupGetSize(tempGroup) > 0);
          tooltip += "\nUsing this ability pings each of these capitals on the minimap.";
          UnitAddAbility(_unit, DUMMY_DIESWITHOUT);
          BlzSetAbilityStringLevelField(BlzGetUnitAbility(_unit, DUMMY_DIESWITHOUT), ABILITY_SLF_TOOLTIP_NORMAL_EXTENDED, 0, tooltip);
          DestroyGroup(tempGroup);
        }
        else
        {
          UnitRemoveAbility(_unit, DUMMY_DIESWITHOUT);
        }
      }
    }

    /// <summary>
    /// Removes the unit representing this Legend from the game.
    /// </summary>
    private void PermanentlyKill() {
      throw new NotImplementedException();
    }
  }
}