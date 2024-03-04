using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Shared.Data;


namespace MacroTools.Libraries
{
  /// <summary>
  /// Provides a useful set of methods for interacting with the Warcraft 3 engine.
  /// </summary>
  public static class GeneralHelpers
  {
    private static readonly group TempGroup = CreateGroup();
    private static readonly rect TempRect = Rect(0, 0, 0, 0);

    private static Point? _enumDestructableCenter;
    private static float _enumDestructableRadius;

    private static bool EnumDestructablesInCircleFilter()
    {
      return MathEx.GetDistanceBetweenPoints(
        new Point(GetDestructableX(GetFilterDestructable()), GetDestructableY(GetFilterDestructable())),
        _enumDestructableCenter!) <= _enumDestructableRadius;
    }

    /// <summary>
    /// Creates and returns a rectangle with the given radius at its widest point.
    /// </summary>
    public static Rectangle GetRectFromCircle(Point center, float radius) => 
      new(center.X - radius, center.Y - radius, center.X + radius, center.Y + radius);

    /// <summary>
    /// Performs an action on all destructables in a circle.
    /// </summary>
    public static void EnumDestructablesInCircle(float radius, Point center, Action actionFunc)
    {
      if (radius < 0) 
        return;
      _enumDestructableCenter = center;
      _enumDestructableRadius = radius;
      var circleAsRectangle = GetRectFromCircle(center, radius);
      EnumDestructablesInRect(circleAsRectangle.Rect, Condition(EnumDestructablesInCircleFilter), actionFunc);
    }

    /// <summary>
    /// Creates blight in a circular radius.
    /// </summary>
    public static void SetBlightRadius(player whichPlayer, Point position, float radius, bool addBlight)
    {
      var location = Location(position.X, position.Y);
      SetBlightLoc(whichPlayer, location, radius, addBlight);
      RemoveLocation(location);
    }

    /// <summary>
    /// Converts an integer ID into an ID string.
    /// <para>E.g. converts the integer representation of "hfoo" back into "hfoo".</para>
    /// </summary>
    public static string DebugIdInteger2IdString(int value)
    {
      const string charMap =
        ".................................!.#$%&'()*+,-./0123456789:;<=>.@ABCDEFGHIJKLMNOPQRSTUVWXYZ[.]^_`abcdefghijklmnopqrstuvwxyz{|}~.................................................................................................................................";
      var result = "";
      var remainingValue = value;

      for (var i = 0; i < 5; i++)
      {
        var charValue = MathEx.ModuloInteger(remainingValue, 256);
        remainingValue /= 256;
        result = SubString(charMap, charValue, charValue + 1) + result;
      }

      return result;
    }

    /// <summary>
    /// Kills all neutral hostile units in an circular radius.
    /// </summary>
    public static void KillNeutralHostileUnitsInRadius(float x, float y, float radius)
    {
      GroupEnumUnitsInRange(TempGroup, x, y, radius, null);
      while (true)
      {
        var u = FirstOfGroup(TempGroup);
        if (u == null) break;

        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !IsUnitType(u, UNIT_TYPE_SAPPER) &&
            !IsUnitType(u, UNIT_TYPE_STRUCTURE))
          KillUnit(u);

        GroupRemoveUnit(TempGroup, u);
      }
    }

    /// <summary>
    /// Creates a structure at a location, killing any existing structures there to make room.
    /// </summary>
    public static unit CreateStructureForced(player whichPlayer, int unitId, float x, float y, float face, float size)
    {
      SetRect(TempRect, x - size / 2, y - size / 2, x + size / 2, y + size / 2);
      GroupEnumUnitsInRect(TempGroup, TempRect, null);
      while (true)
      {
        var u = FirstOfGroup(TempGroup);
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

    /// <summary>
    /// Creates several units of the same type at the same location.
    /// </summary>
    /// <returns>The units that were created.</returns>
    public static IEnumerable<unit> CreateUnits(player whichPlayer, int unitId, float x, float y, float face, int count)
    {
      var createdUnits = new List<unit>();
      var i = 0;
      while (true)
      {
        if (i == count) break;
        createdUnits.Add(CreateUnit(whichPlayer, unitId, x, y, face));
        i += 1;
      }

      return createdUnits;
    }

    public static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }
    
    /// @CSharpLua.Template = "BlzGetAbilityId({0})"
    public static extern int BlzGetAbilityId(ability whichAbility);
  }
}