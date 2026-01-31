using System;
using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Legends;
using MacroTools.Systems;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions;

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
    var oldLevel = whichUnit.HeroLevel;
    if (newLevel > oldLevel)
    {
      SetHeroLevel(whichUnit, newLevel, showEyeCandy);
    }
    else if (newLevel < oldLevel)
    {
      whichUnit.RemoveHeroLevels(oldLevel - newLevel);
    }
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
    whichUnit.IsUnitType(unittype.Hero) ? whichUnit.HeroLevel : whichUnit.Level;

  /// <summary>
  /// Causes the unit to die after the specified duration, like a summoned unit.
  /// </summary>
  /// <param name="whichUnit">The unit to affect.</param>
  /// <param name="duration">How long the unit should last.</param>
  /// <param name="buffId">This buff's name is placed on the unit's timed life progress bar.</param>
  public static void SetTimedLife(this unit whichUnit, float duration, int buffId = 0)
  {
    if (duration < 1)
    {
      whichUnit.CancelTimedLife();
    }

    whichUnit.ApplyTimedLife(buffId, duration);
  }

  /// <summary>
  /// Gets the units proper name. If it doesn't have one, get their unit name instead.
  /// </summary>
  public static string GetProperName(this unit whichUnit) =>
    whichUnit.IsUnitType(unittype.Hero) ? whichUnit.HeroName : whichUnit.Name;

  /// <summary>
  /// Returns the position of the unit.
  /// </summary>
  public static Point GetPosition(this unit unit) => new(unit.X, unit.Y);

  /// <summary>
  ///   Sets the Waygate's destination to the target point.
  ///   Blindly assumes that the unit is a Waygate.
  /// </summary>
  public static void SetWaygateDestination(this unit waygate, Point destination)
  {
    waygate.WaygateActive = true;
    waygate.SetWaygateDestination(destination.X, destination.Y);
  }

  /// <summary>
  /// Sets the units hit points to a specified percentage value.
  /// </summary>
  public static void SetLifePercent(this unit whichUnit, float percent)
  {
    whichUnit.Life = whichUnit.MaxLife * MathEx.Max(0, percent) * 0.01f;
  }

  /// <summary>
  /// Returns the percentage hit points the unit has remaining.
  /// </summary>
  public static float GetLifePercent(this unit whichUnit) => whichUnit.Life /
    whichUnit.MaxLife * 100;

  /// <summary>
  ///   Resurrects the specified unit.
  /// </summary>
  public static void Resurrect(this unit whichUnit)
  {
    if (whichUnit.Alive)
    {
      throw new ArgumentException("Tried to resurrect a unit that is already alive.");
    }

    var x = whichUnit.X;
    var y = whichUnit.Y;
    var unitType = whichUnit.UnitType;
    var face = whichUnit.Facing;
    effect.Create(@"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl", x, y).Dispose();
    whichUnit.Dispose();
    unit.Create(whichUnit.Owner, unitType, x, y, face);
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
    damager.DealDamage(unit, amount, attack, ranged, attackType ?? attacktype.Normal, damageType ?? damagetype.Magic, weaponType ?? weapontype.WhoKnows);
  }

  /// <summary>
  ///   Reveals the unit, makes it vulnerable, and transfers its ownership to the specified player.
  /// </summary>
  public static void Rescue(this unit whichUnit, player whichPlayer)
  {
    //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
    var whichPlayer1 = whichUnit.FoodUsed == 10 ? player.NeutralPassive : whichPlayer;
    whichUnit.SetOwner(whichPlayer1);
    whichUnit.IsVisible = true;
    whichUnit.SetPausedEx(false);

    var asCapital = CapitalManager.GetFromUnit(whichUnit);
    if (asCapital == null || asCapital.ProtectorCount == 0)
    {
      whichUnit.IsInvulnerable = false;
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
    var armor = whichUnit.Armor;
    return armor * 006 / ((1 + 006) * armor);
  }

  /// <summary>
  ///   Increases the unit's Strength, Agility, or Intelligence.
  ///   Displays a special effect depending on which attributes are increased.
  /// </summary>
  public static void AddHeroAttributes(this unit whichUnit, int str, int agi, int intelligence)
  {
    whichUnit.Strength = whichUnit.BaseStrength + str;
    whichUnit.Agility = whichUnit.BaseAgility + agi;
    whichUnit.Intelligence = whichUnit.BaseIntelligence + intelligence;

    string sfx;
    if (str > 0 && agi == 0 && intelligence == 0)
    {
      sfx = "Abilities\\Spells\\Items\\AIsm\\AIsmTarget.mdl";
    }
    else if (str == 0 && agi > 0 && intelligence == 0)
    {
      sfx = "Abilities\\Spells\\Items\\AIam\\AIamTarget.mdl";
    }
    else if (str == 0 && agi == 0 && intelligence > 0)
    {
      sfx = "Abilities\\Spells\\Items\\AIim\\AIimTarget.mdl";
    }
    else
    {
      sfx = "Abilities\\Spells\\Items\\AIlm\\AIlmTarget.mdl";
    }

    effect.Create(sfx, whichUnit.X, whichUnit.Y).Dispose();
  }

  /// <summary>
  ///   Drops a units entire inventory on the ground.
  /// </summary>
  public static void DropAllItems(this unit whichUnit)
  {
    if (whichUnit.IsUnitType(unittype.Summoned))
    {
      throw new InvalidOperationException($"Tried to call {nameof(DropAllItems)} on a summoned hero.");
    }

    var unitX = whichUnit.X;
    var unitY = whichUnit.Y;
    float angInRadians = 0;

    for (var i = 0; i < 6; i++)
    {
      var x = unitX + HeroDropDist * Cos(angInRadians);
      var y = unitY + HeroDropDist * Sin(angInRadians);
      angInRadians += 360 * MathEx.DegToRad / 6;
      var itemToDrop = whichUnit.ItemAtOrDefault(i);
      if (!itemToDrop.IsDroppable)
      {
        itemToDrop.IsDroppable = true;
      }

      whichUnit.RemoveItem(itemToDrop);
      itemToDrop.SetPositionSafe(new Point(x, y));
    }
  }

  /// <summary>
  ///   Transfers all of this unit's items to another unit.
  /// </summary>
  public static void TransferItems(this unit sender, unit receiver)
  {
    for (var i = 0; i < 6; i++)
    {
      receiver.AddItem(sender.ItemAtOrDefault(i));
    }
  }

  /// <summary>
  ///   Add an item to a unit. If the unit's inventory is full, drop it on the ground near them instead.
  /// </summary>
  public static void AddItemSafe(this unit whichUnit, item whichItem)
  {
    whichItem.SetPosition(whichUnit.X, whichUnit.Y);
    whichUnit.AddItem(whichItem);
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
    whichUnit.MaxLife = R2I(I2R(whichUnit.MaxLife) * multiplier);
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
    whichUnit.MaxMana = R2I(I2R(whichUnit.MaxMana) * multiplier);
    whichUnit.SetManaPercent(percentageHitpoints);
  }

  /// <summary>
  /// Gets the percentage of mana that a unit has remaining.
  /// </summary>
  public static float GetManaPercent(this unit whichUnit) => whichUnit.Mana /
    whichUnit.MaxMana * 100;

  /// <summary>
  /// Sets the percentage of mana a unit has remaining.
  /// </summary>
  public static void SetManaPercent(this unit whichUnit, float percent)
  {
    whichUnit.Mana = whichUnit.MaxMana * MathEx.Max(0, percent) * 0.01f;
  }

  /// <summary>
  /// Returns the unit's active rally point.
  /// </summary>
  public static Point GetRallyPoint(this unit whichUnit)
  {
    var rallyLocation = whichUnit.RallyPoint;
    var rallyPoint = new Point(rallyLocation.X, rallyLocation.Y);
    rallyLocation.Dispose();
    return rallyPoint;
  }

  /// <summary>
  /// Causes the specified unit to become capturable,
  /// such that it changes ownership to the attacker when reduced below 0 hit points.
  /// </summary>
  public static void MakeCapturable(this unit whichUnit)
  {
    var damageTrigger = trigger.Create();
    damageTrigger.RegisterUnitEvent(whichUnit, unitevent.Damaged);
    damageTrigger.AddAction(() =>
    {
      if (!(@event.Damage + 1 >= whichUnit.Life))
      {
        return;
      }

      whichUnit.SetOwner(@event.DamageSource.Owner);
      @event.Damage = 0;
      whichUnit.Life = whichUnit.MaxLife;
    });
  }

  /// <summary>
  /// Starts an ability's cooldown.
  /// </summary>
  /// <param name="whichUnit">The unit to start the cooldown for.</param>
  /// <param name="abilCode">The ability to start the cooldown for.</param>
  /// <param name="cooldown">How long the cooldown should be. Defaults to the full cooldown of the ability.</param>
  public static void StartAbilityCooldown(this unit whichUnit, int abilCode, float? cooldown = null)
  {
    whichUnit.EndAbilityCooldown(abilCode);
    cooldown ??= whichUnit.GetAbilityCooldown(abilCode, 0);
    whichUnit.SetAbilityCooldownRemaining(abilCode, cooldown.Value);
  }

  /// <summary>
  /// Turns the unit to face a particular position.
  /// </summary>
  public static void FacePosition(this unit whichUnit, Point targetPoint)
  {
    var facing = WCSharp.Shared.Util.AngleBetweenPoints(whichUnit.X, whichUnit.Y, targetPoint.X, targetPoint.Y);
    whichUnit.Facing = facing;
  }

  /// <summary>
  /// Returns true if the unit is a hero, has Resistant Skin, or is a creep with a level of 6 or higher.
  /// </summary>
  public static bool IsResistant(this unit whichUnit)
  {
    return whichUnit.IsUnitType(unittype.Resistant) || whichUnit.IsUnitType(unittype.Hero) ||
           (whichUnit.Owner == player.NeutralAggressive && whichUnit.GetLevel() >= 6);
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
      {
        whichUnit.RemoveAbility(abilityid);
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

    while (true)
    {
      var ability = whichUnit.GetAbilityByIndex(index);

      if (ability is null)
      {
        break;
      }

      abilities.Add(ability);
      index++;
    }

    return abilities;
  }

  /// <summary>Safely removes the unit by dropping its items, killing it, then removing it.
  /// </summary>
  public static void SafelyRemove(this unit whichUnit)
  {
    if (whichUnit.IsUnitType(unittype.Hero))
    {
      whichUnit.DropAllItems();
    }

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

  /// <summary>
  /// Returns true if the unit can be selected, i.e. it does not have Locust.
  /// </summary>
  public static bool IsSelectable(this unit whichUnit) => whichUnit.GetAbilityLevel(FourCC("Aloc")) == 0;

  /// <summary>
  /// Returns true if the unit is classifed as a boat unit, i.e. has movement type 16.
  /// </summary>
  public static bool IsUnitBoat(this unit whichUnit)
  {
    var movementType = whichUnit.MoveType;
    return movementType == WCSharp.Api.Enums.MoveTypes.Float;
  }
}
