using System.IO;
using Warcraft.Cartographer.Deserialization;

namespace Warcraft.Cartographer.Paths;

public sealed class MapDataPathOptions
{
  public required string RootPath { get; init; }

  /// <summary>
  /// The locale to build the map for, or <see langword="null"/> to build from the base map data untouched.
  /// <para>
  /// A locale is a sparse overlay on top of the base data: for every data directory, files in
  /// <c>&lt;directory&gt;.&lt;locale&gt;</c> take precedence over the base directory, and any file the overlay does
  /// not contain falls back to the base file. A translation therefore only ships the files it actually changes -
  /// typically just the text-bearing object data - instead of duplicating models, regions or doodads.
  /// </para>
  /// </summary>
  public string? Locale { get; init; }

  /// <summary>
  /// Whether a locale overlay is active.
  /// </summary>
  public bool IsLocalized => !string.IsNullOrEmpty(Locale);

  /// <summary>
  /// Gets the overlay directory for a base directory, e.g. <c>mapdata/WarcraftLegacies/UnitData.zhCN</c>.
  /// </summary>
  /// <param name="baseDirectory">The base directory the overlay applies to.</param>
  public string GetLocalizedDirectory(string baseDirectory) =>
    IsLocalized ? $"{baseDirectory}.{Locale}" : baseDirectory;

  /// <summary>
  /// Gets the overlay path for a standalone file that lives directly in the map data root, e.g.
  /// <c>mapdata/WarcraftLegacies/zhCN/war3mapSkin.txt</c>.
  /// </summary>
  /// <param name="baseFilePath">The base file the overlay may replace.</param>
  public string GetLocalizedRootFilePath(string baseFilePath)
  {
    if (!IsLocalized)
    {
      return baseFilePath;
    }

    var fileName = Path.GetFileName(baseFilePath);
    return Path.Combine(RootPath, Locale!, fileName);
  }

  /// <summary>
  /// Resolves a standalone file to the one a build should read, preferring the locale overlay when it exists.
  /// </summary>
  /// <param name="baseFilePath">The base file.</param>
  public string GetEffectiveRootFilePath(string baseFilePath)
  {
    var localizedPath = GetLocalizedRootFilePath(baseFilePath);
    return File.Exists(localizedPath) ? localizedPath : baseFilePath;
  }

  /// <summary>
  /// Enumerates the files a build should read for a base directory. Every distinct file is returned exactly once,
  /// with any file the locale overlay provides replacing its base counterpart.
  /// </summary>
  /// <param name="baseDirectory">The base directory to enumerate.</param>
  /// <param name="searchPattern">The file search pattern, such as <c>*.json</c>.</param>
  /// <param name="searchOption">Whether to include subdirectories.</param>
  public IEnumerable<string> EnumerateLocalizedFiles(
    string baseDirectory,
    string searchPattern = "*",
    SearchOption searchOption = SearchOption.TopDirectoryOnly)
  {
    var overlayDirectory = GetLocalizedDirectory(baseDirectory);
    var hasOverlay = IsLocalized && Directory.Exists(overlayDirectory);

    if (!hasOverlay)
    {
      return Directory.Exists(baseDirectory)
        ? Directory.EnumerateFiles(baseDirectory, searchPattern, searchOption)
        : [];
    }

    var overlayFiles = Directory.EnumerateFiles(overlayDirectory, searchPattern, searchOption).ToList();
    var overridden = overlayFiles
      .Select(file => Path.GetRelativePath(overlayDirectory, file))
      .ToHashSet();

    if (!Directory.Exists(baseDirectory))
    {
      return overlayFiles;
    }

    var fallbackFiles = Directory
      .EnumerateFiles(baseDirectory, searchPattern, searchOption)
      .Where(file => !overridden.Contains(Path.GetRelativePath(baseDirectory, file)));

    return overlayFiles.Concat(fallbackFiles);
  }

  /// <summary>
  /// Enumerates the object data files a build should read, pairing each with the overlay file that refines it.
  /// <para>
  /// An overlay file only has to list the object records it changes, and within a record only the fields it
  /// changes, so a translation ships as a sparse diff instead of a full copy of every file. Fields the overlay
  /// does not mention fall back to the base file, and fields it adds are kept even when the base file has none -
  /// which is what lets a translation localise a name the base map data inherits from the game itself.
  /// </para>
  /// </summary>
  /// <param name="baseDirectory">The base object data directory, such as <c>UnitData</c>.</param>
  public IEnumerable<LocalizedObjectFile> EnumerateLocalizedObjectFiles(string baseDirectory)
  {
    var overlayDirectory = GetLocalizedDirectory(baseDirectory);
    var hasOverlay = IsLocalized && Directory.Exists(overlayDirectory);
    var hasBase = Directory.Exists(baseDirectory);

    if (!hasBase && !hasOverlay)
    {
      return [];
    }

    if (!hasBase)
    {
      return Directory.EnumerateFiles(overlayDirectory, "*.json")
        .OrderBy(file => file, StringComparer.Ordinal)
        .Select(file => new LocalizedObjectFile { Name = Path.GetFileName(file), OverlayPath = file });
    }

    var overlayByName = hasOverlay
      ? Directory.EnumerateFiles(overlayDirectory, "*.json", SearchOption.TopDirectoryOnly)
        .ToDictionary(file => Path.GetFileName(file), file => file, StringComparer.OrdinalIgnoreCase)
      : [];

    var pairs = Directory.EnumerateFiles(baseDirectory, "*.json", SearchOption.TopDirectoryOnly)
      .OrderBy(file => file, StringComparer.Ordinal)
      .Select(file =>
      {
        var name = Path.GetFileName(file);
        return new LocalizedObjectFile
        {
          Name = name,
          BasePath = file,
          OverlayPath = overlayByName.TryGetValue(name, out var overlay) ? overlay : null
        };
      })
      .ToList();

    var baseNames = pairs.Select(pair => pair.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
    pairs.AddRange(overlayByName
      .Where(entry => !baseNames.Contains(entry.Key))
      .OrderBy(entry => entry.Key, StringComparer.Ordinal)
      .Select(entry => new LocalizedObjectFile { Name = entry.Key, OverlayPath = entry.Value }));

    return pairs;
  }

  /// <summary>
  /// Resolves a data directory to the one a build should read, preferring the locale overlay when it has content.
  /// </summary>
  /// <param name="baseDirectory">The base data directory.</param>
  public string GetEffectiveDirectory(string baseDirectory)
  {
    if (!IsLocalized)
    {
      return baseDirectory;
    }

    var overlayDirectory = GetLocalizedDirectory(baseDirectory);
    return Directory.Exists(overlayDirectory) ? overlayDirectory : baseDirectory;
  }

  public required string AbilityDataPath { get; init; }

  public required string BuffDataPath { get; init; }

  public required string DestructableDataPath { get; init; }

  public required string DoodadDataPath { get; init; }

  public required string DoodadsPath { get; init; }

  public required string ImportsPath { get; init; }

  public required string ItemDataPath { get; init; }

  public required string RegionsPath { get; init; }

  public required string SoundsPath { get; init; }

  public required string UnitDataPath { get; init; }

  public required string UnitsPath { get; init; }

  public required string UpgradeDataPath { get; init; }

  public required string EnvironmentPath { get; init; }

  public required string InfoPath { get; init; }

  public required string PathingMapPath { get; init; }

  public required string PreviewIconsPath { get; init; }

  public required string ShadowMapPath { get; init; }

  public required string MinimapPath { get; init; }

  public required string GameplayConstantsPath { get; init; }

  public required string GameInterfacePath { get; init; }

  /// <summary>
  /// Returns all map file paths that match any of the flags specified in <see cref="IncludeFromMap"/>.
  /// </summary>
  public IEnumerable<string> GetPathsFromIncludedFiles(IncludeFromMap include)
  {
    if (include.HasFlag(IncludeFromMap.All))
    {
      yield return RootPath;
      yield break;
    }

    foreach (var flag in Enum.GetValues<IncludeFromMap>())
    {
      if (flag == IncludeFromMap.All || !include.HasFlag(flag))
      {
        continue;
      }

      var path = flag switch
      {
        IncludeFromMap.Sounds => SoundsPath,
        IncludeFromMap.Environment => EnvironmentPath,
        IncludeFromMap.PathingMap => PathingMapPath,
        IncludeFromMap.PreviewIcons => PreviewIconsPath,
        IncludeFromMap.ShadowMap => ShadowMapPath,
        IncludeFromMap.Minimap => MinimapPath,
        IncludeFromMap.Regions => RegionsPath,
        IncludeFromMap.Imports => ImportsPath,
        IncludeFromMap.Info => InfoPath,
        IncludeFromMap.GameplayConstants => GameplayConstantsPath,
        IncludeFromMap.GameInterface => GameInterfacePath,

        IncludeFromMap.AbilityData => AbilityDataPath,
        IncludeFromMap.BuffData => BuffDataPath,
        IncludeFromMap.DestructableData => DestructableDataPath,
        IncludeFromMap.DoodadData => DoodadDataPath,
        IncludeFromMap.ItemData => ItemDataPath,
        IncludeFromMap.UnitData => UnitDataPath,
        IncludeFromMap.UpgradeData => UpgradeDataPath,

        IncludeFromMap.Doodads => DoodadsPath,
        IncludeFromMap.Units => UnitsPath,

        _ => null
      };

      if (path is not null)
      {
        yield return path;
      }
    }
  }
}
