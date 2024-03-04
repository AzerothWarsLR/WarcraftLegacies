using System.Collections.Generic;
using System.Collections.ObjectModel;
using MacroTools.Instances;
using WCSharp.Shared.Data;


namespace MacroTools.ShoreSystem
{
  /// <summary>
  /// Responsible for recording and providing searching for all <see cref="Shore"/>s in the game.
  /// </summary>
  public static class ShoreManager
  {
    private static readonly List<Shore> AllShores = new();

    /// <summary>
    /// Registers a <see cref="Shore"/> to the <see cref="ShoreManager"/>, allowing the manager to return it in search results.
    /// </summary>
    public static void Register(Shore shore)
    {
      if (IsTerrainPathable(shore.Position.X, shore.Position.Y, PATHING_TYPE_WALKABILITY))
      {
        Logger.LogWarning($"Registered a {nameof(Shore)} at unwalkable location {shore.Position.X}, {shore.Position.Y}.");
        PingMinimap(shore.Position.X, shore.Position.Y, 10);
      }
      AllShores.Add(shore);
    }

    /// <summary>
    /// Returns all registered <see cref="Shore"/>s.
    /// </summary>
    public static ReadOnlyCollection<Shore> GetAllShores() => AllShores.AsReadOnly();
    
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
        if (i == AllShores.Count)
        {
          break;
        }

        var tempDistance = InstanceSystem.GetDistanceBetweenPointsEx(position, AllShores[i].Position);
        if (tempDistance < nearestDistance)
        {
          nearestDistance = tempDistance;
          nearestShore = AllShores[i];
        }

        i += 1;
      }

      return nearestShore;
    }
  }
}