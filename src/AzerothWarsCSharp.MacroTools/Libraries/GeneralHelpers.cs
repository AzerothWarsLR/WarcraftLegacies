using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.MacroTools.Libraries
{
  public static class GeneralHelpers
  {
    private static readonly group TempGroup = CreateGroup();
    private static readonly rect TempRect = Rect(0, 0, 0, 0);

    public static Rectangle GetPlayableMapArea()
    {
      return new Rectangle(Rect(GetCameraBoundMinX() - GetCameraMargin(CAMERA_MARGIN_LEFT),
        GetCameraBoundMinY() - GetCameraMargin(CAMERA_MARGIN_BOTTOM),
        GetCameraBoundMaxX() + GetCameraMargin(CAMERA_MARGIN_RIGHT),
        GetCameraBoundMaxY() + GetCameraMargin(CAMERA_MARGIN_TOP)));
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

    public static IEnumerable<player> GetAllPlayers()
    {
      for (var i = 0; i < Environment.MAX_PLAYERS; i++) yield return Player(i);
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
  }
}