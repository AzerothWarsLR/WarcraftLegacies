using System.Collections.Generic;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.Libraries
{
  public static class GeneralHelpers
  {
    private const float HERO_DROP_DIST = 50; //The radius in which heroes spread out items when they drop them
    private static readonly force _destForce = CreateForce();
    private static readonly group TempGroup = CreateGroup();
    private static readonly rect TempRect = Rect(0, 0, 0, 0);

    public static string DebugIdInteger2IdString(int value)
    {
      const string charMap =
        ".................................!.#$%&'()*+,-./0123456789:;<=>.@ABCDEFGHIJKLMNOPQRSTUVWXYZ[.]^_`abcdefghijklmnopqrstuvwxyz{|}~.................................................................................................................................";
      string result = "";
      var remainingValue = value;

      for (var i = 0; i < 5; i++)
      {
        var charValue = ModuloInteger(remainingValue, 256);
        remainingValue /= 256;
        result = SubString(charMap, charValue, charValue + 1) + result;
      }

      return result;
    }

    public static IEnumerable<player> GetAllPlayers()
    {
      for (var i = 0; i < bj_MAX_PLAYERS; i++) yield return Player(i);
    }

    public static int GetUnitAverageDamage(unit whichUnit, int weaponIndex)
    {
      float baseDamage = BlzGetUnitBaseDamage(whichUnit, weaponIndex);
      float numberOfDice = BlzGetUnitDiceNumber(whichUnit, weaponIndex);
      float sidesPerDie = BlzGetUnitDiceSides(whichUnit, weaponIndex);
      return R2I(baseDamage + (numberOfDice + sidesPerDie * numberOfDice) / 2);
    }

    /// <summary>
    ///   Gets a units physical damage reduction as a percentage. Only takes armor into account.
    /// </summary>
    public static float GetUnitDamageReduction(unit whichUnit)
    {
      var armor = BlzGetUnitArmor(whichUnit);
      return armor * 006 / ((1 + 006) * armor);
    }

    public static void KillNeutralHostileUnitsInRadius(float x, float y, float radius)
    {
      GroupEnumUnitsInRange(TempGroup, x, y, radius, null);
      while (true)
      {
        unit u = FirstOfGroup(TempGroup);
        if (u == null) break;

        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !IsUnitType(u, UNIT_TYPE_SAPPER) &&
            !IsUnitType(u, UNIT_TYPE_STRUCTURE))
          KillUnit(u);

        GroupRemoveUnit(TempGroup, u);
      }
    }

    public static unit CreateStructureForced(player whichPlayer, int unitId, float x, float y, float face, float size)
    {
      SetRect(TempRect, x - size / 2, y - size / 2, x + size / 2, y + size / 2);
      GroupEnumUnitsInRect(TempGroup, TempRect, null);
      while (true)
      {
        unit u = FirstOfGroup(TempGroup);
        if (u == null) break;

        if (IsUnitType(u, UNIT_TYPE_STRUCTURE))
        {
          AdjustPlayerStateBJ(GetUnitGoldCost(GetUnitTypeId(u)), GetOwningPlayer(u), PLAYER_STATE_RESOURCE_GOLD);
          AdjustPlayerStateBJ(GetUnitWoodCost(GetUnitTypeId(u)), GetOwningPlayer(u), PLAYER_STATE_RESOURCE_LUMBER);
          KillUnit(u);
        }

        GroupRemoveUnit(TempGroup, u);
      }

      return CreateUnit(whichPlayer, unitId, x, y, face);
    }

    public static void PlayDialogue(player whichPlayer, sound whichSound, string speakerName, string caption)
    {
      if (GetLocalPlayer() == whichPlayer)
      {
        StartSound(whichSound);
        DisplayTimedTextToPlayer(whichPlayer, 0, 0, GetSoundDuration(whichSound) / 1000,
          "\n|cffffcc00" + speakerName + ":|r " + caption);
      }
    }

    public static void CreateUnits(player whichPlayer, int unitId, float x, float y, float face, int count)
    {
      var i = 0;
      while (true)
      {
        if (i == count) break;

        CreateUnit(whichPlayer, unitId, x, y, face);
        i += 1;
      }
    }

    public static float GetRectRandomY(rect whichRect)
    {
      return GetRandomReal(GetRectMinY(whichRect), GetRectMaxY(whichRect));
    }

    public static float GetRectRandomX(rect whichRect)
    {
      return GetRandomReal(GetRectMinX(whichRect), GetRectMaxX(whichRect));
    }

    private static void ForceAddForceEnum()
    {
      ForceAddPlayer(_destForce, GetEnumPlayer());
    }

    public static void AddHeroAttributes(unit whichUnit, int str, int agi, int intelligence)
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
    ///   Reveals the unit, makes it vulnerable, and transfers its ownership to the specified player.
    /// </summary>
    public static void UnitRescue(unit whichUnit, player whichPlayer)
    {
      //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
      SetUnitOwner(whichUnit, GetUnitFoodUsed(whichUnit) == 10 ? Player(PLAYER_NEUTRAL_PASSIVE) : whichPlayer, true);
      ShowUnit(whichUnit, true);
      SetUnitInvulnerable(whichUnit, false);
    }

    /// <summary>
    ///   Drops a units entire inventory on the ground.
    /// </summary>
    public static void UnitDropAllItems(unit u)
    {
      var unitX = GetUnitX(u);
      var unitY = GetUnitY(u);
      float ang = 0; //Radians

      for (var i = 0; i < 6; i++)
      {
        var x = unitX + HERO_DROP_DIST * Cos(ang);
        var y = unitY + HERO_DROP_DIST * Sin(ang);
        ang += 360 * bj_DEGTORAD / 6;
        item dropItem = UnitItemInSlot(u, i);
        if (BlzGetItemBooleanField(dropItem, ITEM_BF_DROPPED_WHEN_CARRIER_DIES) ||
            BlzGetItemBooleanField(dropItem, ITEM_BF_CAN_BE_DROPPED))
        {
          UnitRemoveItem(u, dropItem);
          SetItemPosition(dropItem, x, y);
        }
      }
    }

    public static void UnitTransferItems(unit sender, unit receiver)
    {
      for (var i = 0; i < 6; i++) UnitAddItem(receiver, UnitItemInSlot(sender, i));
    }

    /// <summary>
    ///   Add an item to a unit. If the unit's inventory is full, drop it on the ground near them instead.
    /// </summary>
    public static void UnitAddItemSafe(unit whichUnit, item whichItem)
    {
      SetItemPosition(whichItem, GetUnitX(whichUnit), GetUnitY(whichUnit));
      UnitAddItem(whichUnit, whichItem);
    }

    public static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    public static void ScaleUnitBaseDamage(unit u, float scale, int weaponIndex)
    {
      BlzSetUnitBaseDamage(u, R2I(I2R(BlzGetUnitBaseDamage(u, weaponIndex)) * scale), weaponIndex);
    }

    public static void ScaleUnitMaxHitpoints(unit u, float scale)
    {
      var percentageHitpoints = GetUnitLifePercent(u);
      BlzSetUnitMaxHP(u, R2I(I2R(BlzGetUnitMaxHP(u)) * scale));
      SetUnitLifePercentBJ(u, percentageHitpoints);
    }
  }
}