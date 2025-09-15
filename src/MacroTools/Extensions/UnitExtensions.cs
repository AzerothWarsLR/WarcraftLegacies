using System;
using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.LegendSystem;
using MacroTools.Libraries;
using MacroTools.Systems;
using WCSharp.Shared.Data;
using static MacroTools.Libraries.GeneralHelpers;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a series of useful extensions to the unit class.
  /// </summary>
  public static class UnitExtensions
  {
    private const float HeroDropDist = 50; //The radius in which heroes spread out items when they drop them

    /// <summary>
    /// Sets the unit's level to a particular value.
    /// </summary>
    public static void SetLevel(this unit whichUnit, int newLevel, bool showEyeCandy = true)
    {
      var oldLevel = GetHeroLevel(whichUnit);
      if (newLevel > oldLevel)
        SetHeroLevel(whichUnit, newLevel, showEyeCandy);
      else if (newLevel < oldLevel)
        UnitStripHeroLevel(whichUnit, oldLevel - newLevel);
    }

    /// <summary>
    /// Determines whether or not the unit's attack can be seen in the UI window.
    /// </summary>
    public static void ShowAttackUi(this unit whichUnit, bool show, int weaponSlot = 0) => 
      BlzSetUnitWeaponBooleanField(whichUnit, UNIT_WEAPON_BF_ATTACK_SHOW_UI, weaponSlot, show);

    /// <summary>
    /// Gets the unit's unit level if it's a unit, or hero level if it's a hero.
    /// </summary>
    public static int GetLevel(this unit whichUnit) =>
      IsUnitType(whichUnit, UNIT_TYPE_HERO) ? GetHeroLevel(whichUnit) : GetUnitLevel(whichUnit);

    /// <summary>
    /// Causes the unit to die after the specified duration, like a summoned unit.
    /// </summary>
    /// <param name="whichUnit">The unit to affect.</param>
    /// <param name="duration">How long the unit should last.</param>
    /// <param name="buffId">This buff's name is placed on the unit's timed life progress bar.</param>
    /// <returns></returns>
    public static void SetTimedLife(this unit whichUnit, float duration, int buffId = 0)
    {
      if (duration < 1)
        BlzUnitCancelTimedLife(whichUnit);

      UnitApplyTimedLife(whichUnit, buffId, duration);
    }

    /// <summary>
    /// Gets the units proper name. If it doesn't have one, get their unit name instead.
    /// </summary>
    public static string GetProperName(this unit whichUnit) =>
      IsUnitType(whichUnit, UNIT_TYPE_HERO) ? GetHeroProperName(whichUnit) : GetUnitName(whichUnit);

    /// <summary>
    /// Pings the unit on the minimap.
    /// </summary>
    /// <param name="whichUnit">The unit to ping.</param>
    /// <param name="duration">How long the ping should last.</param>
    public static void Ping(this unit whichUnit, float duration) =>
      PingMinimap(GetUnitX(whichUnit), GetUnitY(whichUnit), duration);

    /// <summary>
    /// Orders a unit to perform a specified order at a specified <see cref="Point"/>.
    /// </summary>
    [Obsolete("Use the version that takes an integer order ID instead.")]
    public static void IssueOrder(this unit unit, string order, Point target) => 
      IssuePointOrder(unit, order, target.X, target.Y);

    /// <summary>
    /// Orders a unit to perform a specified order at a specified <see cref="Point"/>.
    /// </summary>
    public static void IssueOrder(this unit unit, int orderId, Point target) => 
      IssuePointOrderById(unit, orderId, target.X, target.Y);

    /// <summary>
    /// Moves the unit to a specified <see cref="Point"/>.
    /// </summary>
    public static void SetPosition(this unit unit, Point where, bool considerPathability = false)
    {
      if (!considerPathability)
      {
        SetUnitX(unit, where.X);
        SetUnitY(unit, where.Y);
      }
      else
        SetUnitPosition(unit, where.X, where.Y);
    }

    /// <summary>
    /// Returns the position of the unit.
    /// </summary>
    public static Point GetPosition(this unit unit) => new(GetUnitX(unit), GetUnitY(unit));

    /// <summary>
    /// Returns the current owner of the specified unit.
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
    public static float GetLifePercent(this unit whichUnit) => GetUnitState(whichUnit, UNIT_STATE_LIFE) /
      GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE) * 100;

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
      GetUnitState(whichUnit, UNIT_STATE_MANA) + amount);

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
      player whichPlayer1 = GetUnitFoodUsed(whichUnit) == 10 ? Player(PLAYER_NEUTRAL_PASSIVE) : whichPlayer;
      SetUnitOwner(whichUnit, whichPlayer1, true);
      ShowUnit(whichUnit, true);
      BlzPauseUnitEx(whichUnit, false);

      var asCapital = CapitalManager.GetFromUnit(whichUnit);
      if (asCapital == null || asCapital.ProtectorCount == 0)
      {
        SetUnitInvulnerable(whichUnit, false);
      }
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
    /// Adds an amount of experience to the hero.
    /// </summary>
    public static void AddExperience(this unit whichUnit, int amount)
    {
      AddHeroXP(whichUnit, amount, true);
    }

    /// <summary>
    ///   Drops a units entire inventory on the ground.
    /// </summary>
    public static void DropAllItems(this unit whichUnit)
    {
      if (IsUnitType(whichUnit, UNIT_TYPE_SUMMONED))
        throw new InvalidOperationException($"Tried to call {nameof(DropAllItems)} on a summoned hero.");

      var unitX = GetUnitX(whichUnit);
      var unitY = GetUnitY(whichUnit);
      float angInRadians = 0;

      for (var i = 0; i < 6; i++)
      {
        var x = unitX + HeroDropDist * Cos(angInRadians);
        var y = unitY + HeroDropDist * Sin(angInRadians);
        angInRadians += 360 * MathEx.DegToRad / 6;
        var itemToDrop = UnitItemInSlot(whichUnit, i);
        if (!BlzGetItemBooleanField(itemToDrop, ITEM_BF_CAN_BE_DROPPED))
          SetItemDroppable(itemToDrop, true);

        UnitRemoveItem(whichUnit, itemToDrop);
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
    public static void MultiplyBaseDamage(this unit whichUnit, float multiplier, int weaponIndex) =>
      BlzSetUnitBaseDamage(whichUnit, R2I(I2R(BlzGetUnitBaseDamage(whichUnit, weaponIndex)) * multiplier), weaponIndex);

    /// <summary>
    /// Multiplies the specified unit's attack cooldown by the specified amount.
    /// </summary>
    /// <param name="whichUnit">The unit to affect.</param>
    /// <param name="multiplier">The amount to multiply attack speed by.</param>
    /// <param name="weaponIndex">Which weapon to change; can be 1 or 2.</param>
    public static void MultiplyAttackCooldown(this unit whichUnit, float multiplier, int weaponIndex) =>
      BlzSetUnitAttackCooldown(whichUnit, BlzGetUnitAttackCooldown(whichUnit, weaponIndex) * multiplier, weaponIndex);

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

    /// <summary>
    /// Multiplities the specified unit's mana by the specified amount.
    /// </summary>
    /// <param name="whichUnit">The unit to affect.</param>
    /// <param name="multiplier">The amount to multiply hit points by.</param>
    public static void MultiplyMaxMana(this unit whichUnit, float multiplier)
    {
      var percentageHitpoints = whichUnit.GetManaPercent();
      BlzSetUnitMaxMana(whichUnit, R2I(I2R(BlzGetUnitMaxMana(whichUnit)) * multiplier));
      whichUnit.SetManaPercent(percentageHitpoints);
    }

    /// <summary>
    /// Gets the percentage of mana that a unit has remaining.
    /// </summary>
    public static float GetManaPercent(this unit whichUnit) => GetUnitState(whichUnit, UNIT_STATE_MANA) /
      GetUnitState(whichUnit, UNIT_STATE_MAX_MANA) * 100;

    /// <summary>
    /// Sets the percentage of mana a unit has remaining.
    /// </summary>
    public static void SetManaPercent(this unit whichUnit, float percent)
    {
      SetUnitState(whichUnit, UNIT_STATE_MANA,
        GetUnitState(whichUnit, UNIT_STATE_MAX_MANA) * MathEx.Max(0, percent) * 0.01f);
    }

    /// <summary>
    /// Returns the unit's active rally point.
    /// </summary>
    public static Point GetRallyPoint(this unit whichUnit)
    {
      var rallyLocation = GetUnitRallyPoint(whichUnit);
      var rallyPoint = new Point(GetLocationX(rallyLocation), GetLocationY(rallyLocation));
      return rallyPoint;
    }

    /// <summary>
    /// Adds an ability to the unit.
    /// </summary>
    public static void AddAbility(this unit whichUnit, int abilityTypeId)
    {
      UnitAddAbility(whichUnit, abilityTypeId);
      UnitMakeAbilityPermanent(whichUnit, true, abilityTypeId);
    }

    /// <summary>
    /// Causes the specified unit to become capturable,
    /// such that it changes ownership to the attacker when reduced below 0 hit points.
    /// </summary>
    public static void MakeCapturable(this unit whichUnit)
    {
      var damageTrigger = CreateTrigger();
      TriggerRegisterUnitEvent(damageTrigger, whichUnit, EVENT_UNIT_DAMAGED);
      TriggerAddAction(damageTrigger, () =>
      {
        if (!(GetEventDamage() + 1 >= GetUnitState(whichUnit, UNIT_STATE_LIFE))) return;
        SetUnitOwner(whichUnit, GetOwningPlayer(GetEventDamageSource()), true);
        BlzSetEventDamage(0);
        SetUnitState(whichUnit, UNIT_STATE_LIFE, GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE));
      });
    }
    
    /// <summary>
    /// Starts an ability's cooldown.
    /// </summary>
    /// <param name="whichUnit">The unit to start the cooldown for.</param>
    /// <param name="abilCode">The ability to start the cooldown for.</param>
    /// <param name="cooldown">How long the cooldown should be. Defaults to the full cooldown of the ability.</param>
    /// <returns></returns>
    public static void StartAbilityCooldown(this unit whichUnit, int abilCode, float? cooldown = null)
    {
      BlzEndUnitAbilityCooldown(whichUnit, abilCode);
      cooldown ??= BlzGetUnitAbilityCooldown(whichUnit, abilCode, 0);
      BlzStartUnitAbilityCooldown(whichUnit, abilCode, cooldown.Value);
    }

    /// <summary>
    /// Turns the unit to face a particular position.
    /// </summary>
    public static void FacePosition(this unit whichUnit, Point targetPoint)
    {
      var unitPosition = whichUnit.GetPosition();
      var facing = WCSharp.Shared.Util.AngleBetweenPoints(unitPosition.X, unitPosition.Y, targetPoint.X, targetPoint.Y);
      BlzSetUnitFacingEx(whichUnit, facing);
    }

    /// <summary>
    /// Returns true if the unit is a hero, has Resistant Skin, or is a creep with a level of 6 or higher.
    /// </summary>
    public static bool IsResistant(this unit whichUnit)
    {
      return IsUnitType(whichUnit, UNIT_TYPE_RESISTANT) || IsUnitType(whichUnit, UNIT_TYPE_HERO) ||
             (whichUnit.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) && whichUnit.GetLevel() >= 6);
    }

    /// <summary>
    /// Removes All abilities not in the ignore list from a unit
    /// </summary>
    /// <param name="whichUnit">The unit to remove abilities from</param>
    /// <param name="ignoredAbilityId">List of ability Ids to not be removed. </param>
    /// <returns>A List of abilityids for a given unit.</returns>
    public static void RemoveAllAbilities(this unit whichUnit, List<int> ignoredAbilityId)
    {
      var abilities = GetUnitAbilities(whichUnit);

      foreach (var ability in abilities)
      {
        var abilityid = BlzGetAbilityId(ability);
        if (!ignoredAbilityId.Contains(abilityid))
        {
          UnitRemoveAbility(whichUnit, abilityid);
        }
      }
    }
    
    /// <summary>
    /// Gets all the abilities for a unit
    /// </summary>
    /// <param name="whichUnit">The unit to get the abilities of.</param>
    /// <returns>A List of ability objects for a given unit.</returns>
    public static List<ability> GetUnitAbilities(this unit whichUnit)
    {
      var abilities = new List<ability>();
      var index = 0;

      while(true)
      {
        var ability = BlzGetUnitAbilityByIndex(whichUnit, index);

        if (ability is null)
          break;
        
        abilities.Add(ability);
        index++;
      }

      return abilities;
    }

    /// <summary>Safely removes the unit by dropping its items, killing it, then removing it.
    /// </summary>
    public static void SafelyRemove(this unit whichUnit)
    {
      if (IsUnitType(whichUnit, UNIT_TYPE_HERO))
        whichUnit.DropAllItems();

      KillUnit(whichUnit);
      RemoveUnit(whichUnit);
    }

    /// <summary>
    /// Whether or not the unit can be safely removed.
    /// <para>Control Points, Capitals, and Gates are some examples of units that should not be removed.</para>
    /// </summary>
    public static bool IsRemovable(this unit whichUnit)
    {
      var unitType = UnitType.GetFromHandle(whichUnit);
      return !CapitalManager.UnitIsCapital(whichUnit) && !CapitalManager.UnitIsProtector(whichUnit) &&
             !ControlPointManager.Instance.UnitIsControlPoint(whichUnit) && !unitType.NeverDelete;
    }

    /// <summary>
    /// Returns true if the unit can be selected, i.e. it does not have Locust.
    /// </summary>
    public static bool IsSelectable(this unit whichUnit) => GetUnitAbilityLevel(whichUnit, FourCC("Aloc")) == 0;

    /// <summary>
    /// Returns true if the unit is classifed as a boat unit, i.e. has movement type 16.
    /// </summary>
    public static bool IsUnitBoat(this unit whichUnit)
    {
      var movementType = BlzGetUnitIntegerField(whichUnit, UNIT_IF_MOVE_TYPE);
      return movementType == 16;
    }
  }
}