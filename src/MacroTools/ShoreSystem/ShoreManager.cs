using System.Collections.Generic;
using MacroTools.Instances;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ShoreSystem
{
  /// <summary>
  /// Responsible for recording and providing searching for all <see cref="Shore"/>s in the game.
  /// </summary>
  public static class ShoreManager
  {
    private static readonly List<Shore> ShoresByIndex = new();
    
    private static int Count => ShoresByIndex.Count;
    
    /// <summary>
    /// Registers a <see cref="Shore"/> to the <see cref="ShoreManager"/>, allowing the manager to return it in search results.
    /// </summary>
    public static void Register(Shore shore)
    {
      if (IsTerrainPathable(shore.Position.X, shore.Position.Y, PATHING_TYPE_WALKABILITY))
      {
        Logger.LogWarning($"Registered a {nameof(Shore)} at unwalkable location {shore.Position.X}, {shore.Position.Y}.");
        PingMinimap(shore.Position.X, shore.Position.Y, 120);
      }
      ShoresByIndex.Add(shore);
    }

    /// <summary>
    /// Returns the <see cref="Shore"/> closest to the given <see cref="Point"/>.
    /// </summary>
    public static Shore? GetNearestShore(Point position)
    {
      var i = 0;
      Shore? nearestShore = null;
      float nearestDistance = 1000000;
      while (true)
      {
        if (i == Count)
        {
          break;
        }

        var tempDistance = InstanceSystem.GetDistanceBetweenPointsEx(position, ShoresByIndex[i].Position);
        if (tempDistance < nearestDistance)
        {
          nearestDistance = tempDistance;
          nearestShore = ShoresByIndex[i];
        }

        i += 1;
      }

      return nearestShore;
    }
  }
}