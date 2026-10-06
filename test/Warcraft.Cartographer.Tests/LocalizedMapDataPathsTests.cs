using System.IO;
using Warcraft.Cartographer.Paths;

namespace Warcraft.Cartographer.Tests;

/// <summary>
/// Tests that a locale behaves as a sparse overlay over the base map data.
/// </summary>
public sealed class LocalizedMapDataPathsTests : IDisposable
{
  private readonly string _root = Path.Combine(Path.GetTempPath(), "cartographer-locale-" + Guid.NewGuid().ToString("N"));

  public LocalizedMapDataPathsTests()
  {
    Directory.CreateDirectory(Path.Combine(_root, "UnitData"));
    Directory.CreateDirectory(Path.Combine(_root, "UnitData.zhCN"));
    File.WriteAllText(Path.Combine(_root, "UnitData", "E002.json"), "base");
    File.WriteAllText(Path.Combine(_root, "UnitData", "E00A.json"), "base");
    File.WriteAllText(Path.Combine(_root, "UnitData.zhCN", "E002.json"), "translated");
  }

  public void Dispose()
  {
    if (Directory.Exists(_root))
    {
      Directory.Delete(_root, true);
    }
  }

  private MapDataPathOptions Options(string? locale) => new()
  {
    RootPath = _root,
    Locale = locale,
    AbilityDataPath = Path.Combine(_root, "AbilityData"),
    BuffDataPath = Path.Combine(_root, "BuffData"),
    DestructableDataPath = Path.Combine(_root, "DestructableData"),
    DoodadDataPath = Path.Combine(_root, "DoodadData"),
    DoodadsPath = Path.Combine(_root, "Doodads"),
    ImportsPath = Path.Combine(_root, "Imports"),
    ItemDataPath = Path.Combine(_root, "ItemData"),
    RegionsPath = Path.Combine(_root, "Regions"),
    SoundsPath = Path.Combine(_root, "Sounds"),
    UnitDataPath = Path.Combine(_root, "UnitData"),
    UnitsPath = Path.Combine(_root, "Units"),
    UpgradeDataPath = Path.Combine(_root, "UpgradeData"),
    EnvironmentPath = Path.Combine(_root, "Environment.json"),
    InfoPath = Path.Combine(_root, "Info.json"),
    PathingMapPath = Path.Combine(_root, "PathingMap.json"),
    PreviewIconsPath = Path.Combine(_root, "PreviewIcons.json"),
    ShadowMapPath = Path.Combine(_root, "ShadowMap.json"),
    MinimapPath = Path.Combine(_root, "war3mapMap.blp"),
    GameplayConstantsPath = Path.Combine(_root, "war3mapMisc.txt"),
    GameInterfacePath = Path.Combine(_root, "war3mapSkin.txt")
  };

  [Fact]
  public void WithoutALocaleEveryBaseFileIsUsed()
  {
    var options = Options(null);
    var files = options.EnumerateLocalizedFiles(options.UnitDataPath).ToList();

    Assert.False(options.IsLocalized);
    Assert.Equal(2, files.Count);
    Assert.All(files, file => Assert.Equal("base", File.ReadAllText(file)));
  }

  [Fact]
  public void WithALocaleAnOverlayFileReplacesItsBaseCounterpart()
  {
    var options = Options("zhCN");
    var files = options.EnumerateLocalizedFiles(options.UnitDataPath).ToList();

    Assert.True(options.IsLocalized);
    Assert.Equal(2, files.Count);

    var translated = files.Single(file => Path.GetFileName(file) == "E002.json");
    var fallback = files.Single(file => Path.GetFileName(file) == "E00A.json");

    Assert.Equal("translated", File.ReadAllText(translated));
    Assert.Equal("base", File.ReadAllText(fallback));
  }

  [Fact]
  public void WithALocaleButNoOverlayDirectoryEverythingFallsBack()
  {
    var options = Options("deDE");
    var files = options.EnumerateLocalizedFiles(options.UnitDataPath).ToList();

    Assert.Equal(2, files.Count);
    Assert.All(files, file => Assert.Equal("base", File.ReadAllText(file)));
  }

  [Fact]
  public void EffectiveDirectoryPrefersTheOverlayWhenItExists()
  {
    var options = Options("zhCN");

    Assert.Equal(Path.Combine(_root, "UnitData.zhCN"), options.GetEffectiveDirectory(options.UnitDataPath));
    Assert.Equal(Path.Combine(_root, "Regions"), options.GetEffectiveDirectory(options.RegionsPath));
  }

  [Fact]
  public void StandaloneRootFilesResolveIntoTheLocaleSubdirectory()
  {
    var options = Options("zhCN");
    var baseFile = Path.Combine(_root, "war3mapSkin.txt");
    var localizedFile = Path.Combine(_root, "zhCN", "war3mapSkin.txt");

    Assert.Equal(localizedFile, options.GetLocalizedRootFilePath(baseFile));
    Assert.Equal(baseFile, options.GetEffectiveRootFilePath(baseFile));

    Directory.CreateDirectory(Path.Combine(_root, "zhCN"));
    File.WriteAllText(localizedFile, "translated");

    Assert.Equal(localizedFile, options.GetEffectiveRootFilePath(baseFile));
    Assert.Equal(baseFile, Options(null).GetLocalizedRootFilePath(baseFile));
  }
}
