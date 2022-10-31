using System;
using System.Diagnostics;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Libraries
{
  public static class GeneralHelpers
  {
    private static readonly group TempGroup = CreateGroup();
    private static readonly rect TempRect = Rect(0, 0, 0, 0);
    private static readonly unit PosUnit;

    private static Point? _enumDestructableCenter;
    private static float _enumDestructableRadius;

    static GeneralHelpers()
    {
      PosUnit = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), FourCC("u00X"), 0, 0, 0);
    }

    public static void CameraSetEarthquakeNoise(float magnitude)
    {
      var richter = magnitude;
      if (richter > 5)
      {
        richter = 5;
      }

      if (richter < 2)
      {
        richter = 2;
      }

      CameraSetTargetNoiseEx(magnitude * 2.0f, magnitude * Pow(10, richter), true);
    }

    private static bool EnumDestructablesInCircleFilter()
    {
      Debug.Assert(_enumDestructableCenter != null, nameof(_enumDestructableCenter) + " != null");
      return MathEx.GetDistanceBetweenPoints(
        new Point(GetDestructableX(GetFilterDestructable()), GetDestructableY(GetFilterDestructable())),
        _enumDestructableCenter) <= _enumDestructableRadius;
    }

    public static Rectangle GetRectFromCircle(Point center, float radius)
    {
      return new Rectangle(center.X - radius, center.Y - radius, center.X + radius, center.Y + radius);
    }

    public static void EnumDestructablesInCircle(float radius, Point center, Action actionFunc)
    {
      if (radius >= 0)
      {
        _enumDestructableCenter = center;
        _enumDestructableRadius = radius;
        var r = GetRectFromCircle(center, radius);
        EnumDestructablesInRect(r.Rect, Condition(EnumDestructablesInCircleFilter), actionFunc);
      }
    }

    public static void SetBlightRadius(player whichPlayer, Point position, float radius, bool addBlight)
    {
      var location = Location(position.X, position.Y);
      SetBlightLoc(whichPlayer, location, radius, addBlight);
      RemoveLocation(location);
    }

    public static string DebugIdInteger2IdString(int value)
    {
      const string charMap =
        ".................................!.#$%&'()*+,-./0123456789:;<=>.@ABCDEFGHIJKLMNOPQRSTUVWXYZ[.]^_`abcdefghijklmnopqrstuvwxyz{|}~.................................................................................................................................";
      string result = "";
      var remainingValue = value;

      for (var i = 0; i < 5; i++)
      {
        var charValue = MathEx.ModuloInteger(remainingValue, 256);
        remainingValue /= 256;
        result = SubString(charMap, charValue, charValue + 1) + result;
      }

      return result;
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
          GetOwningPlayer(u).AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, GetUnitGoldCost(GetUnitTypeId(u)));
          GetOwningPlayer(u).AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, GetUnitWoodCost(GetUnitTypeId(u)));
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

    public static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    public static float GetPositionZ(float x, float y)
    {
      SetUnitX(PosUnit, x);
      SetUnitY(PosUnit, y);
      return BlzGetUnitZ(PosUnit);
    }
  }
}