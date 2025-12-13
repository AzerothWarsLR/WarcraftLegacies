using System.IO;

namespace Launcher;

public static class PathConventions
{
  public const string Maps = "maps";

  public const string MapData = "mapdata";

  public static string Backups => Path.Combine(Maps, "backups");

  public const string Artifacts = "artifacts";

  public const string Src = "src";

  public static string Published => Path.Combine(Maps, "published");
}
