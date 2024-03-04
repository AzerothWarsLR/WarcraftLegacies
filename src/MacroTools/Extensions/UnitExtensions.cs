using System;
using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.LegendSystem;
using MacroTools.Libraries;
using WCSharp.Shared.Data;

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
      var oldLevel = whichUnit.Level;
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
    /// Removes trees in a radius around a unit
    /// </summary>
    public static void RemoveDestructablesInRadius(this unit whichUnit, float radius)
    {
      EnumDestructablesInCircle(radius, new Point(whichUnit.GetPosition().X,whichUnit.GetPosition().Y),
        () =>
        {
          RemoveDestructable(GetEnumDestructable());
        });
    }

    /// <summary>
    /// Sets the unit's unit level (NOT their hero level).
    /// </summary>
    public static void SetUnitLevel(this unit whichUnit, int level) =>
      BlzSetUnitIntegerField(whichUnit, UNIT_IF_LEVEL, level);

    /// <summary>
    /// Gets the unit's unit level if it's a unit, or hero level if it's a hero.
    /// </summary>
    public static int GetLevel(this unit whichUnit) =>
      IsUnitType(whichUnit, UNIT_TYPE_HERO) ? GetHeroLevel(whichUnit) : GetUnitLevel(whichUnit);

    /// <summary>
    /// Gets the units proper name. If it doesn't have one, get their unit name instead.
    /// </summary>
    public static string GetProperName(this unit whichUnit) =>
      IsUnitType(whichUnit, UNIT_TYPE_HERO) ? GetHeroProperName(whichUnit) : GetUnitName(whichUnit);

    /// <summary>
    /// Orders a unit to perform a specified order at a specified <see cref="Point"/>.
    /// </summary>
    [Obsolete("Use the version that takes an integer order ID instead.")]
    public static unit IssueOrderOld(this unit unit, string order, Point target)
    {
      IssuePointOrder(unit, order, target.X, target.Y);
      return unit;
    }
    
    /// <summary>
    /// Orders a unit to perform a specified order at a specified <see cref="Point"/>.
    /// </summary>
    public static void IssueOrderOld(this unit unit, int orderId, Point target)
    {
      IssuePointOrderById(unit, orderId, target.X, target.Y);
    }

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
    /// Sets the units hit points to a specified percentage value.
    /// </summary>
    public static unit SetLifePercent(this unit whichUnit, float percent)
    {
      SetUnitState(whichUnit, UNIT_STATE_LIFE,
        GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE) * MathEx.Max(0, percent) * 0.01f);
      return whichUnit;
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
      if (UnitAlive(whichUnit)) 
        throw new ArgumentException("Tried to resurrect a unit that is already alive.");

      var x = GetUnitX(whichUnit);
      var y = GetUnitY(whichUnit);
      var unitType = GetUnitTypeId(whichUnit);
      var face = GetUnitFacing(whichUnit);
      DestroyEffect(AddSpecialEffect(@"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl", x, y));
      RemoveUnit(whichUnit);
      CreateUnit(whichUnit.Owner, unitType, x, y, face);
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
    ///   Reveals the unit, makes it vulnerable, and transfers its ownership to the specified player.
    /// </summary>
    public static void Rescue(this unit whichUnit, player whichPlayer)
    {
      //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
      whichUnit.SetOwner(GetUnitFoodUsed(whichUnit) == 10 ? Player(PLAYER_NEUTRAL_PASSIVE) : whichPlayer);
      whichUnit.IsVisible = true;
      whichUnit.SetPausedEx(false);

      var asCapital = CapitalManager.GetFromUnit(whichUnit);
      if (asCapital == null || asCapital.ProtectorCount == 0)
        whichUnit.IsInvulnerable = true;
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
    ///   Increases the unit's Strength, Agility, or Intelligence.
    ///   Displays a special effect depending on which attributes are increased.
    /// </summary>
    public static unit AddHeroAttributes(this unit whichUnit, int str, int agi, int intelligence)
    {
      SetHeroStr(whichUnit, GetHeroStr(whichUnit, false) + str, true);
      SetHeroAgi(whichUnit, GetHeroAgi(whichUnit, false) + agi, true);
      SetHeroInt(whichUnit, GetHeroInt(whichUnit, false) + intelligence, true);

      string sfx;
      if (str > 0 && agi == 0 && intelligence == 0)
        sfx = @"Abilities\Spells\Items\AIsm\AIsmTarget.mdl";
      else if (str == 0 && agi > 0 && intelligence == 0)
        sfx = @"Abilities\Spells\Items\AIam\AIamTarget.mdl";
      else if (str == 0 && agi == 0 && intelligence > 0)
        sfx = @"Abilities\Spells\Items\AIim\AIimTarget.mdl";
      else
        sfx = @"Abilities\Spells\Items\AIlm\AIlmTarget.mdl";

      DestroyEffect(AddSpecialEffect(sfx, GetUnitX(whichUnit), GetUnitY(whichUnit)));
      return whichUnit;
    }

    /// <summary>
    ///   Drops a units entire inventory on the ground.
    /// </summary>
    public static unit DropAllItems(this unit whichUnit)
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
        if (!itemToDrop.IsDroppable) 
          itemToDrop.IsDroppable = true;

        whichUnit.RemoveItem(itemToDrop);
        itemToDrop.SetPositionSafe(new Point(x, y));
      }

      return whichUnit;
    }

    /// <summary>
    ///   Transfers all of this unit's items to another unit.
    /// </summary>
    public static void TransferItems(this unit sender, unit receiver)
    {
      for (var i = 0; i < 6; i++) 
        UnitAddItem(receiver, UnitItemInSlot(sender, i));
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
    public static unit MultiplyBaseDamage(this unit whichUnit, float multiplier, int weaponIndex)
    {
      BlzSetUnitBaseDamage(whichUnit, R2I(I2R(BlzGetUnitBaseDamage(whichUnit, weaponIndex)) * multiplier), weaponIndex);
      return whichUnit;
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
    public static unit SetManaPercent(this unit whichUnit, float percent)
    {
      SetUnitState(whichUnit, UNIT_STATE_MANA,
        GetUnitState(whichUnit, UNIT_STATE_MAX_MANA) * MathEx.Max(0, percent) * 0.01f);
      return whichUnit;
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
    /// Causes the specified unit to become capturable,
    /// such that it changes ownership to the attacker when reduced below 0 hit points.
    /// </summary>
    public static void MakeCapturable(this unit whichUnit)
    {
      CreateTrigger()
        .RegisterUnitEvent(whichUnit, EVENT_UNIT_DAMAGED)
        .AddAction(() =>
        {
          if (!(GetEventDamage() + 1 >= GetUnitState(whichUnit, UNIT_STATE_LIFE))) 
            return;
          
          SetUnitOwner(whichUnit, GetOwningPlayer(GetEventDamageSource()), true);
          BlzSetEventDamage(0);
          SetUnitState(whichUnit, UNIT_STATE_LIFE, GetUnitState(whichUnit, UNIT_STATE_MAX_LIFE));
        });
    }

    /// <summary>
    /// Activates an ability's full cooldown for a unit.
    /// </summary>
    public static void StartUnitAbilityCooldownFull(this unit whichUnit, int abilCode)
    {
      var fullCooldown = BlzGetUnitAbilityCooldown(whichUnit, abilCode, 0);
      BlzStartUnitAbilityCooldown(whichUnit, abilCode, fullCooldown);
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
      return whichUnit.IsUnitType(UNIT_TYPE_RESISTANT) || whichUnit.IsUnitType(UNIT_TYPE_HERO) ||
             (whichUnit.Owner == Player(PLAYER_NEUTRAL_AGGRESSIVE) && whichUnit.GetLevel() >= 6);
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
        var abilityid = ability.Id;
        if (!ignoredAbilityId.Contains(abilityid))
          whichUnit.RemoveAbility(abilityid);
      }
    }
    
    /// <summary>
    /// Gets all the abilities for a unit.
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
      if (whichUnit.IsUnitType(UNIT_TYPE_HERO))
        whichUnit.DropAllItems();

      whichUnit.Kill();
      whichUnit.Dispose();
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
  }
}