using System.Text.Json;
using FluentAssertions;

namespace WarcraftLegacies.Map.Tests;

/// <summary>
/// A locale overlay overrides text, and nothing else.
/// <para>
/// A field outside <see cref="TextFields"/> holds a key or a statistic - a sound set, a model path, an id list, hit
/// points, a mana cost. Overriding one gives players of that language different numbers from everyone else, and
/// conflicts with every later change to the data. Text that already reads the same as the base is just as unwanted:
/// it overrides nothing and gets in the way.
/// </para>
/// </summary>
public sealed class LocaleOverlayTests
{
  private static readonly HashSet<string> TextFields = new(StringComparer.Ordinal)
  {
    "unam", "upro", "unsf", "utip", "utub", "utpr", "uawt", "ides", "iub1", "iico",
    "anam", "ansf", "aub1", "atp1", "arut", "aret", "aut1", "auu1",
    "gnam", "gnsf", "gub1", "gtp1",
    "fnam", "fnsf", "ftip", "fube",
    "bnam", "bsuf",
  };

  private static readonly string[] OverlaidKinds =
  {
    "UnitData", "AbilityData", "UpgradeData", "ItemData", "BuffData", "DestructableData",
  };

  [Fact]
  public void OverlayOverridesTextOnly()
  {
    var offenders = new List<string>();

    foreach (var overlay in Overlays())
    {
      foreach (var modification in Modifications(overlay.OverlayPath))
      {
        if (!TextFields.Contains(modification.Field))
        {
          offenders.Add($"{overlay.Name}: {modification.Field}");
        }
      }
    }

    offenders.Should().BeEmpty("a locale overlay overrides text; {0} value(s) are a key or a statistic",
      offenders.Count);
  }

  [Fact]
  public void OverlayOverridesOnlyTextThatDiffers()
  {
    var offenders = new List<string>();

    foreach (var overlay in Overlays())
    {
      var baseValues = Modifications(overlay.BasePath)
        .ToDictionary(modification => (modification.Field, modification.Level), modification => modification.Value);
      if (baseValues.Values.Any(ContainsChinese))
      {
        // The base records of a localised build tree have already been shipped Chinese.
        continue;
      }

      foreach (var modification in Modifications(overlay.OverlayPath))
      {
        if (baseValues.TryGetValue((modification.Field, modification.Level), out var english) &&
            english == modification.Value)
        {
          offenders.Add($"{overlay.Name}: {modification.Field} level {modification.Level}");
        }
      }
    }

    offenders.Should().BeEmpty("text that reads the same as the base overrides nothing; {0} value(s) repeat it",
      offenders.Count);
  }

  private static IEnumerable<(string Name, string OverlayPath, string BasePath)> Overlays()
  {
    var mapData = Path.Combine(RepositoryRoot(), "mapdata", "WarcraftLegacies");

    foreach (var kind in OverlaidKinds)
    {
      var overlayDirectory = Path.Combine(mapData, kind + ".zhCN");
      if (!Directory.Exists(overlayDirectory))
      {
        continue;
      }

      foreach (var overlayPath in Directory.EnumerateFiles(overlayDirectory, "*.json"))
      {
        yield return (Path.GetFileName(overlayPath), overlayPath,
          Path.Combine(mapData, kind, Path.GetFileName(overlayPath)));
      }
    }
  }

  private static IEnumerable<(string Field, int? Level, string Value)> Modifications(string path)
  {
    if (!File.Exists(path))
    {
      yield break;
    }

    using var document = JsonDocument.Parse(File.ReadAllText(path));
    if (!document.RootElement.TryGetProperty("Modifications", out var modifications))
    {
      yield break;
    }

    foreach (var modification in modifications.EnumerateArray())
    {
      if (!modification.TryGetProperty("Id", out var id) ||
          !modification.TryGetProperty("Value", out var value) ||
          value.ValueKind != JsonValueKind.String)
      {
        continue;
      }

      var level = modification.TryGetProperty("Level", out var levelElement) &&
                  levelElement.ValueKind == JsonValueKind.Number
        ? levelElement.GetInt32()
        : (int?)null;

      yield return (id.GetString() ?? "", level, value.GetString() ?? "");
    }
  }

  private static bool ContainsChinese(string text)
  {
    return text.Any(character => character is >= '\u4e00' and <= '\u9fff');
  }

  private static string RepositoryRoot()
  {
    var directory = new DirectoryInfo(AppContext.BaseDirectory);
    while (directory != null)
    {
      if (Directory.Exists(Path.Combine(directory.FullName, "mapdata", "WarcraftLegacies")))
      {
        return directory.FullName;
      }

      directory = directory.Parent;
    }

    throw new InvalidOperationException($"Could not find the repository above {AppContext.BaseDirectory}.");
  }
}
