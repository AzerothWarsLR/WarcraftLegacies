using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Shared;

/// <summary>The undead's mark on the Capital Palace once they take it: the city's buildings become their own, and its fountains lie in ruins.</summary>
public static class CapitalPalaceRuins
{
  private const float FountainScale = 0.8f;
  private const float FountainYaw = 2.39f;
  private const float FountainSearchRadius = 150;
  private const float TowerClearRadius = 128;
  private const string RuinedFountainPath = @"Doodads\Cityscape\Props\FountainRuined\FountainRuined.mdl";

  private static readonly Rectangle _palaceGrounds = new(7900, 7500, 10300, 9800);
  private static readonly Point[] _fountains = { new(8444, 7892), new(9724, 7905) };
  private static bool _fountainsRuined;

  /// <summary>Turns the city buildings around the palace into <paramref name="farmTypeId"/> for <paramref name="owner"/>, and ruins the fountains.</summary>
  public static void Claim(player owner, int farmTypeId)
  {
    RuinFountains();
    foreach (var building in GlobalGroup.EnumUnitsInRect(_palaceGrounds))
    {
      if (building.Alive && building.IsUnitType(unittype.Structure) && IsCityBuilding(building.UnitType))
      {
        PathBase.ReplaceUnit(building, owner, farmTypeId, building.X, building.Y);
      }
    }
  }

  /// <summary>Removes the old tower on a spot outright, so a dying tower can't push the new one out of place.</summary>
  public static void ClearTowerSpot(float x, float y)
  {
    foreach (var structure in GlobalGroup.EnumUnitsInRange(x, y, TowerClearRadius))
    {
      if (structure.IsUnitType(unittype.Structure) && structure.IsRemovable())
      {
        structure.Dispose();
      }
    }
  }

  private static void RuinFountains()
  {
    if (_fountainsRuined)
    {
      return;
    }

    _fountainsRuined = true;
    foreach (var fountain in _fountains)
    {
      SetDoodadAnimation(fountain.X, fountain.Y, FountainSearchRadius, FourCC("YOfn"), true, "hide", false);
      var ruin = effect.Create(RuinedFountainPath, fountain.X, fountain.Y);
      BlzSetSpecialEffectScale(ruin, FountainScale);
      BlzSetSpecialEffectYaw(ruin, FountainYaw);
    }
  }

  private static bool IsCityBuilding(int unitTypeId)
  {
    foreach (var suffix in "0123456789abcdef")
    {
      if (unitTypeId == FourCC("ncb" + suffix))
      {
        return true;
      }
    }

    return false;
  }
}
