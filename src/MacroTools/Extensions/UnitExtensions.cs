using System;
using MacroTools.Libraries;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a series of useful extensions to the unit class.
  /// </summary>
  public static class UnitExtensions
  {
    private const float HeroDropDist = 50; //The radius in which heroes spread out items when they drop them

    /// <summary>
    /// Drops the item on the ground.
    /// </summary>
    public static unit DropItem(this unit whichUnit, item whichItem)
    {
      UnitRemoveItem(whichUnit, whichItem);
      return whichUnit;
    }
    
    /// <summary>
    /// Determines whether or not the unit exists in the game world.
    /// </summary>
    public static unit Show(this unit whichUnit, bool show)
    {
      ShowUnit(whichUnit, show);
      return whichUnit;
    }
    
    /// <summary>
    /// Kill the unit instantly.
    /// </summary>
    public static unit Kill(this unit whichUnit)
    {
      KillUnit(whichUnit);
      return whichUnit;
    }

    /// <summary>
    /// Pings the unit on the minimap.
    /// </summary>
    /// <param name="whichUnit">The unit to ping.</param>
    /// <param name="duration">How long the ping should last.</param>
    public static void Ping(this unit whichUnit, float duration) =>
      PingMinimap(GetUnitX(whichUnit), GetUnitY(whichUnit), duration);

    /// <summary>
    /// If true, prevents the unit from moving or taking actions.
    /// </summary>
    public static void Pause(this unit unit, bool value)
    {
      PauseUnit(unit, value);
    }
    
    /// <summary>
    /// If true, the unit cannot be targeted by attacks or hostile abilities and cannot be damaged.
    /// </summary>
    public static void SetInvulnerable(this unit unit, bool value)
    {
      SetUnitInvulnerable(unit, value);
    }
    
    /// <summary>
    /// Removes the unit from the game permanently.
    /// </summary>
    public static void Remove(this unit unit)
    {
      RemoveUnit(unit);
    }
    
    /// <summary>
    /// Orders a unit to perform a specified order at a specified <see cref="Point"/>.
    /// </summary>
    public static void IssueOrder(this unit unit, string order, Point target)
    {
      IssuePointOrder(unit, order, target.X, target.Y);
    }

    /// <summary>
    /// Moves the unit to a specified <see cref="Point"/>.
    /// </summary>
    public static void SetPosition(this unit unit, Point where)
    {
      SetUnitPosition(unit, where.X, where.Y);
    }

    /// <summary>
    /// Returns the position of the unit.
    /// </summary>
    public static Point GetPosition(this unit unit)
    {
      return new Point(GetUnitX(unit), GetUnitY(unit));
    }

    /// <summary>
    /// Changess the unit's owner to the specified player.
    /// </summary>
    public static void SetOwner(this unit unit, player whichPlayer)
    {
      SetUnitOwner(unit, whichPlayer, true);
    }
    
    /// <summary>
    /// Returns the current owner of the specified unit/
    /// </summary>
    public static player OwningPlayer(this unit unit)
    {
      return GetOwningPlayer(unit);
    }

    /// <summary>
    ///   Sets the Waygate's destination to the target point.
    ///   Blindly assumes that the unit is a Waygate.
    /// </summary>
    public static void SetWaygateDestination(this unit waygate, Point destination)
    {
      WaygateActivate(waygate, true);
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

    /// <summary>
    /// Sets the units hit points to a specified percentage value.
    /// </summary>
    public static void SetLifePercent(this unit whichUnit, float percent)
    {
      SetUnitState(whichUnit, UNIT_STATE_LIFE,
        GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE) * MathEx.Max(0, percent) * 0.01f);
    }

    /// <summary>
    /// Returns the percentage hit points the unit has remaining.
    /// </summary>
    public static float GetLifePercent(this unit whichUnit)
    {
      return GetUnitState(whichUnit, UNIT_STATE_LIFE) / GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE) * 100;
    }

    /// <summary>
    ///   Resurrects the specified unit.
    /// </summary>
    public static void Resurrect(this unit whichUnit)
    {
      if (UnitAlive(whichUnit)) throw new ArgumentException("Tried to resurrect a unit that is already alive.");

      var x = GetUnitX(whichUnit);
      var y = GetUnitY(whichUnit);
      var unitType = GetUnitTypeId(whichUnit);
      var face = GetUnitFacing(whichUnit);
      DestroyEffect(AddSpecialEffect(@"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl", x, y));
      RemoveUnit(whichUnit);
      CreateUnit(OwningPlayer(whichUnit), unitType, x, y, face);
    }

    /// <summary>
    /// Damages the specified unit by the specified amount.
    /// </summary>
    /// <param name="unit">The unit to damage.</param>
    /// <param name="damager">The unit dealing the damage.</param>
    /// <param name="amount">The amount of damage to deal.</param>
    /// <param name="attack">Whether or not the damage instance is an attack.</param>
    /// <param name="ranged">Whether or not the damage instance is considered ranged.</param>
    /// <param name="attackType">The attack type to use.</param>
    /// <param name="damageType">The damage type to use.</param>
    /// <param name="weaponType">The weapon type to use.</param>
    public static void TakeDamage(this unit unit, unit damager, float amount, bool attack = false, bool ranged = true,
      attacktype? attackType = null, damagetype? damageType = null, weapontype? weaponType = null)
    {
      UnitDamageTarget(damager, unit, amount, attack, ranged, attackType ?? ATTACK_TYPE_NORMAL,
        damageType ?? DAMAGE_TYPE_MAGIC, weaponType ?? WEAPON_TYPE_WHOKNOWS);
    }

    /// <summary>
    /// Restore mana to the unit.
    /// </summary>
    /// <param name="whichUnit">The unit to restore mana to.</param>
    /// <param name="amount">How much mana to restore.</param>
    public static void RestoreMana(this unit whichUnit, float amount) => SetUnitState(whichUnit, UNIT_STATE_MANA,
      whichUnit.GetMana() + amount);

    /// <summary>
    /// Returns the current mana value of the unit.
    /// </summary>
    public static float GetMana(this unit whichUnit) => GetUnitState(whichUnit, UNIT_STATE_MANA);

    /// <summary>
    /// Heals the specified unit by the specified amount.
    /// </summary>
    /// <param name="unit">The unit to heal.</param>
    /// <param name="amount">The amount of damage to heal.</param>
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

    /// <summary>
    /// The amount of damage the unit deals on average when it uses its basic attack.
    /// </summary>
    /// <param name="whichUnit">The unit to get the average damage for.</param>
    /// <param name="weaponIndex">Which weapon to return information about; can be 1 or 2.</param>
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
    public static void DropAllItems(this unit whichUnit)
    {
      var unitX = GetUnitX(whichUnit);
      var unitY = GetUnitY(whichUnit);
      float angInRadians = 0;

      for (var i = 0; i < 6; i++)
      {
        var x = unitX + HeroDropDist * Cos(angInRadians);
        var y = unitY + HeroDropDist * Sin(angInRadians);
        angInRadians += 360 * MathEx.DegToRad / 6;
        var itemToDrop = UnitItemInSlot(whichUnit, i);
        if (!BlzGetItemBooleanField(itemToDrop, ITEM_BF_DROPPED_WHEN_CARRIER_DIES) &&
            !BlzGetItemBooleanField(itemToDrop, ITEM_BF_CAN_BE_DROPPED)) continue;
        whichUnit.DropItem(itemToDrop);
        itemToDrop.SetPositionSafe(new Point(x, y));
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

    /// <summary>
    /// Multiplities the specified unit's attack damage by the specified amount.
    /// </summary>
    /// <param name="whichUnit">The unit to affect.</param>
    /// <param name="multiplier">The amount to multiply attack damage by.</param>
    /// <param name="weaponIndex">Which weapon to return information about; can be 1 or 2.</param>
    public static void MultiplyBaseDamage(this unit whichUnit, float multiplier, int weaponIndex)
    {
      BlzSetUnitBaseDamage(whichUnit, R2I(I2R(BlzGetUnitBaseDamage(whichUnit, weaponIndex)) * multiplier), weaponIndex);
    }

    /// <summary>
    /// Multiplities the specified unit's hit points by the specified amount.
    /// </summary>
    /// <param name="whichUnit">The unit to affect.</param>
    /// <param name="multiplier">The amount to multiply hit points by.</param>
    public static void MultiplyMaxHitpoints(this unit whichUnit, float multiplier)
    {
      var percentageHitpoints = whichUnit.GetLifePercent();
      BlzSetUnitMaxHP(whichUnit, R2I(I2R(BlzGetUnitMaxHP(whichUnit)) * multiplier));
      whichUnit.SetLifePercent(percentageHitpoints);
    }
  }
}