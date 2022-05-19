using System;
using War3Api;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class UnitExtensions
  {
    private const float HERO_DROP_DIST = 50; //The radius in which heroes spread out items when they drop them

    /// <summary>
    ///   Sets the Waygate's destination to the target point.
    ///   Blindly assumes that the unit is a Waygate.
    /// </summary>
    public static void SetWaygateDestination(this unit waygate, Point destination)
    {
      WaygateSetDestination(waygate, destination.X, destination.Y);
    }

    /// <summary>
    ///   If the unit has the given item type, returns the item slot the item is in.
    ///   Otherwise, returns 0.
    ///   This function is 1-indexed.
    /// </summary>
    public static int GetInventoryIndexOfItemType(this unit whichUnit, int itemTypeId)
    {
      var index = 0;
      while (true)
      {
        item indexItem = UnitItemInSlot(whichUnit, index);
        if (indexItem != null && GetItemTypeId(indexItem) == itemTypeId) return index + 1;

        index += 1;
        if (index >= 6) break;
      }

      return 0;
    }

    public static void SetLifePercent(this unit whichUnit, float percent)
    {
      SetUnitState(whichUnit, UNIT_STATE_LIFE,
        GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE) * MathF.Max(0, percent) * 0.01f);
    }

    public static float GetLifePercent(this unit whichUnit)
    {
      return GetUnitState(whichUnit, UNIT_STATE_LIFE) / GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE) * 100;
    }

    /// <summary>
    ///   Resurrects a dead unit.
    /// </summary>
    /// <param name="whichUnit">The unit to resurrect.</param>
    public static void Resurrect(this unit whichUnit)
    {
      if (UnitAlive(whichUnit)) throw new ArgumentException("Tried to resurrect a unit that is already alive.");

      var x = GetUnitX(whichUnit);
      var y = GetUnitY(whichUnit);
      var unitType = GetUnitTypeId(whichUnit);
      var face = GetUnitFacing(whichUnit);
      DestroyEffect(AddSpecialEffect(@"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl", x, y));
      RemoveUnit(whichUnit);
      CreateUnit(GetOwningPlayer(whichUnit), unitType, x, y, face);
    }

    public static void Damage(this unit unit, unit damager, float amount)
    {
      SetUnitState(unit, UNIT_STATE_LIFE, GetUnitState(unit, UNIT_STATE_LIFE) - amount);
    }

    public static void Heal(this unit unit, float amount)
    {
      SetUnitState(unit, UNIT_STATE_LIFE, GetUnitState(unit, UNIT_STATE_LIFE) + amount);
    }

    /// <summary>
    ///   Reveals the unit, makes it vulnerable, and transfers its ownership to the specified player.
    /// </summary>
    public static void Rescue(this unit whichUnit, player whichPlayer)
    {
      //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
      SetUnitOwner(whichUnit, GetUnitFoodUsed(whichUnit) == 10 ? Player(PLAYER_NEUTRAL_PASSIVE) : whichPlayer, true);
      ShowUnit(whichUnit, true);
      SetUnitInvulnerable(whichUnit, false);
    }

    public static int GetAverageDamage(this unit whichUnit, int weaponIndex)
    {
      float baseDamage = BlzGetUnitBaseDamage(whichUnit, weaponIndex);
      float numberOfDice = BlzGetUnitDiceNumber(whichUnit, weaponIndex);
      float sidesPerDie = BlzGetUnitDiceSides(whichUnit, weaponIndex);
      return R2I(baseDamage + (numberOfDice + sidesPerDie * numberOfDice) / 2);
    }

    /// <summary>
    ///   Gets a units physical damage reduction as a percentage. Only takes armor into account.
    /// </summary>
    public static float GetDamageReduction(this unit whichUnit)
    {
      var armor = BlzGetUnitArmor(whichUnit);
      return armor * 006 / ((1 + 006) * armor);
    }

    /// <summary>
    ///   Increases the unit's Strength, Agility, or Intelligence.
    ///   Displays a special effect depending on which attributes are increased.
    /// </summary>
    public static void AddHeroAttributes(this unit whichUnit, int str, int agi, int intelligence)
    {
      SetHeroStr(whichUnit, GetHeroStr(whichUnit, false) + str, true);
      SetHeroAgi(whichUnit, GetHeroAgi(whichUnit, false) + agi, true);
      SetHeroInt(whichUnit, GetHeroInt(whichUnit, false) + intelligence, true);

      string sfx;
      if (str > 0 && agi == 0 && intelligence == 0)
        sfx = "Abilities\\Spells\\Items\\AIsm\\AIsmTarget.mdl";
      else if (str == 0 && agi > 0 && intelligence == 0)
        sfx = "Abilities\\Spells\\Items\\AIam\\AIamTarget.mdl";
      else if (str == 0 && agi == 0 && intelligence > 0)
        sfx = "Abilities\\Spells\\Items\\AIim\\AIimTarget.mdl";
      else
        sfx = "Abilities\\Spells\\Items\\AIlm\\AIlmTarget.mdl";

      DestroyEffect(AddSpecialEffect(sfx, GetUnitX(whichUnit), GetUnitY(whichUnit)));
    }

    /// <summary>
    ///   Drops a units entire inventory on the ground.
    /// </summary>
    public static void DropAllItems(this unit u)
    {
      var unitX = GetUnitX(u);
      var unitY = GetUnitY(u);
      float ang = 0; //Radians

      for (var i = 0; i < 6; i++)
      {
        var x = unitX + HERO_DROP_DIST * Cos(ang);
        var y = unitY + HERO_DROP_DIST * Sin(ang);
        ang += 360 * Blizzard.bj_DEGTORAD / 6;
        item dropItem = UnitItemInSlot(u, i);
        if (BlzGetItemBooleanField(dropItem, ITEM_BF_DROPPED_WHEN_CARRIER_DIES) ||
            BlzGetItemBooleanField(dropItem, ITEM_BF_CAN_BE_DROPPED))
        {
          UnitRemoveItem(u, dropItem);
          SetItemPosition(dropItem, x, y);
        }
      }
    }

    /// <summary>
    ///   Transfers all of this unit's items to another unit.
    /// </summary>
    public static void TransferItems(this unit sender, unit receiver)
    {
      for (var i = 0; i < 6; i++) UnitAddItem(receiver, UnitItemInSlot(sender, i));
    }

    /// <summary>
    ///   Add an item to a unit. If the unit's inventory is full, drop it on the ground near them instead.
    /// </summary>
    public static void AddItemSafe(this unit whichUnit, item whichItem)
    {
      SetItemPosition(whichItem, GetUnitX(whichUnit), GetUnitY(whichUnit));
      UnitAddItem(whichUnit, whichItem);
    }

    public static void ScaleBaseDamage(this unit u, float scale, int weaponIndex)
    {
      BlzSetUnitBaseDamage(u, R2I(I2R(BlzGetUnitBaseDamage(u, weaponIndex)) * scale), weaponIndex);
    }

    public static void ScaleMaxHitpoints(this unit u, float scale)
    {
      var percentageHitpoints = u.GetLifePercent();
      BlzSetUnitMaxHP(u, R2I(I2R(BlzGetUnitMaxHP(u)) * scale));
      u.SetLifePercent(percentageHitpoints);
    }
  }
}