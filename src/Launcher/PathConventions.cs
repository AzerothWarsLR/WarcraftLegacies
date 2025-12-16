using System.IO;

namespace Launcher;

public static class PathConventions
{
  public const string MapsPath = "maps";

  public const string MapDataPath = "mapdata";

  public static string BackupsPath => Path.Combine(MapsPath, "backups");

  public const string ArtifactsPath = "artifacts";

  public const string SrcPath = "src";

  public static string PublishedPath => Path.Combine(MapsPath, "published");

  public const string SourceProjectSuffix = ".Source";
}
