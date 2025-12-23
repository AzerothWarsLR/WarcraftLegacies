using System.Collections.Generic;
using Launcher.Paths;

namespace Launcher;

public static class MapDataPaths
{
  /// <summary>
  /// Gets the paths to all files that need to be included in a map but which can't be serialized, such as plain text
  /// files or images.
  /// </summary>
  public static IEnumerable<string> GetUnserializableFilePaths()
  {
    yield return PathConventions.MapData.Minimap;
    yield return PathConventions.MapData.GameplayConstants;
    yield return PathConventions.MapData.GameInterface;
  }
}
