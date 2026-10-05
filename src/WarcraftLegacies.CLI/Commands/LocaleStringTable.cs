using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;

namespace WarcraftLegacies.CLI.Commands;

/// <summary>
/// Moves the text that differs between a base build and a localized build into trigger strings, so both builds
/// share one set of object data and map info files and only <c>war3map.wts</c> differs per language.
/// <para>
/// Warcraft III checks that every player in a lobby has the same map by hashing files that include the object data.
/// A map that stores a translated copy of those files gives clients of that language a different hash from the host,
/// and they are kicked from the lobby or see it broken. Trigger strings are how Blizzard's own maps carry several
/// languages: the shared files hold <c>TRIGSTR_</c> references, and each client resolves them from its own
/// language's string file.
/// </para>
/// </summary>
internal static class LocaleStringTable
{
  private const string TriggerStringsFileName = "war3map.wts";

  private const string ScriptFileName = "war3map.lua";

  /// <summary>
  /// A script line that passes one string literal, such as <c>SetMapName("Warcraft Legacies")</c>.
  /// </summary>
  private static readonly Regex _singleLiteralLine = new(@"^(?<prefix>[^""]*)""(?<value>(?:[^""\\]|\\.)*)""(?<suffix>[^""]*)$");

  /// <summary>
  /// The archive files this step rewrites, keyed by the <see cref="Map"/> property that holds them.
  /// </summary>
  private static readonly (string Property, string FileName)[] _objectDataFiles =
  [
    (nameof(Map.AbilityObjectData), "war3map.w3a"),
    (nameof(Map.BuffObjectData), "war3map.w3h"),
    (nameof(Map.DestructableObjectData), "war3map.w3b"),
    (nameof(Map.DoodadObjectData), "war3map.w3d"),
    (nameof(Map.ItemObjectData), "war3map.w3t"),
    (nameof(Map.UnitObjectData), "war3map.w3u"),
    (nameof(Map.UpgradeObjectData), "war3map.w3q"),
    (nameof(Map.AbilitySkinObjectData), "war3mapSkin.w3a"),
    (nameof(Map.BuffSkinObjectData), "war3mapSkin.w3h"),
    (nameof(Map.DestructableSkinObjectData), "war3mapSkin.w3b"),
    (nameof(Map.DoodadSkinObjectData), "war3mapSkin.w3d"),
    (nameof(Map.ItemSkinObjectData), "war3mapSkin.w3t"),
    (nameof(Map.UnitSkinObjectData), "war3mapSkin.w3u"),
    (nameof(Map.UpgradeSkinObjectData), "war3mapSkin.w3q")
  ];

  /// <summary>
  /// The result of <see cref="Build"/>.
  /// </summary>
  /// <param name="SharedFiles">Files every client reads from the map root, including the base language's strings.</param>
  /// <param name="LocalizedFiles">Files stored once per locale, which is only the translated string file.</param>
  public sealed record Result(
    IReadOnlyDictionary<string, byte[]> SharedFiles,
    IReadOnlyDictionary<string, byte[]> LocalizedFiles);

  /// <summary>
  /// Builds shared object data and map info for <paramref name="basePath"/> and <paramref name="localizedPath"/>,
  /// with one string file for each language.
  /// </summary>
  public static Result Build(string basePath, string localizedPath)
  {
    var baseMap = Open(basePath);
    var localizedMap = Open(localizedPath);

    var table = new StringPairs(baseMap.TriggerStrings, localizedMap.TriggerStrings);
    var sharedFiles = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

    foreach (var (property, fileName) in _objectDataFiles)
    {
      var mapProperty = typeof(Map).GetProperty(property)!;
      var baseData = mapProperty.GetValue(baseMap);
      var localizedData = mapProperty.GetValue(localizedMap);
      if (baseData is null)
      {
        continue;
      }

      var changed = localizedData is null ? 0 : ShareObjectData(baseData, localizedData, table);
      if (changed == 0)
      {
        continue;
      }

      Console.WriteLine($"    {fileName}: {changed} translated fields moved to trigger strings");
      sharedFiles[fileName] = Serialize(writer => WriteObjectData(writer, baseData));
    }

    if (baseMap.Info is not null && localizedMap.Info is not null)
    {
      var changed = ShareMapInfo(baseMap.Info, localizedMap.Info, table);
      if (changed != 0)
      {
        Console.WriteLine($"    war3map.w3i: {changed} translated fields moved to trigger strings");
        sharedFiles["war3map.w3i"] = Serialize(writer => writer.Write(baseMap.Info));
      }
    }

    var script = ShareScript(basePath, localizedPath, table);
    if (script is not null)
    {
      sharedFiles[ScriptFileName] = script;
    }

    sharedFiles[TriggerStringsFileName] = SerializeStrings(table.Base);
    var localizedFiles = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase)
    {
      [TriggerStringsFileName] = SerializeStrings(table.Localized)
    };

    Console.WriteLine($"    war3map.wts: {table.Base.Strings.Count} strings");
    return new Result(sharedFiles, localizedFiles);
  }

  /// <summary>
  /// Returns the base build's script with every line whose string literal differs in the localized build changed to
  /// a trigger string reference, or <see langword="null"/> when the scripts are the same.
  /// </summary>
  /// <remarks>
  /// The two builds' scripts differ only in the map name and description that <c>config</c> sets for the lobby.
  /// Every player reads one script from the map root, so those calls take a reference, as the World Editor writes
  /// them, and each client resolves it from its own string file. Any other difference stops the merge, since it
  /// would mean one language's script is being shown to every player.
  /// </remarks>
  private static byte[] ShareScript(string basePath, string localizedPath, StringPairs table)
  {
    var baseScript = ReadText(basePath, ScriptFileName);
    var localizedScript = ReadText(localizedPath, ScriptFileName);
    if (baseScript is null || localizedScript is null || baseScript == localizedScript)
    {
      return null;
    }

    var baseLines = baseScript.Split('\n');
    var localizedLines = localizedScript.Split('\n');
    if (baseLines.Length != localizedLines.Length)
    {
      throw new InvalidOperationException(
        $"The localized build's {ScriptFileName} has a different number of lines from the base build's.");
    }

    var changed = 0;
    for (var i = 0; i < baseLines.Length; i++)
    {
      if (baseLines[i] == localizedLines[i])
      {
        continue;
      }

      var baseMatch = _singleLiteralLine.Match(baseLines[i]);
      var localizedMatch = _singleLiteralLine.Match(localizedLines[i]);
      if (!baseMatch.Success || !localizedMatch.Success
          || baseMatch.Groups["prefix"].Value != localizedMatch.Groups["prefix"].Value
          || baseMatch.Groups["suffix"].Value != localizedMatch.Groups["suffix"].Value)
      {
        throw new InvalidOperationException(
          $"Line {i + 1} of {ScriptFileName} differs between the builds by more than one string: {baseLines[i].Trim()}");
      }

      var reference = table.Reference(
        UnescapeLua(baseMatch.Groups["value"].Value),
        UnescapeLua(localizedMatch.Groups["value"].Value));
      baseLines[i] = $"{baseMatch.Groups["prefix"].Value}\"{reference}\"{baseMatch.Groups["suffix"].Value}";
      changed++;
    }

    Console.WriteLine($"    {ScriptFileName}: {changed} translated lines moved to trigger strings");
    return new UTF8Encoding(false).GetBytes(string.Join('\n', baseLines));
  }

  private static string UnescapeLua(string literal) => Regex.Replace(literal, @"\\(.)", match => match.Groups[1].Value switch
  {
    "n" => "\n",
    "r" => "\r",
    "t" => "\t",
    var other => other
  });

  private static string ReadText(string mapPath, string fileName)
  {
    using var archive = War3Net.IO.Mpq.MpqArchive.Open(mapPath, true);
    if (!archive.FileExists(fileName))
    {
      return null;
    }

    using var stream = archive.OpenFile(fileName);
    using var reader = new StreamReader(stream, Encoding.UTF8);
    return reader.ReadToEnd();
  }

  private static Map Open(string path)
  {
    using var stream = File.OpenRead(path);
    return Map.Open(stream);
  }

  /// <summary>
  /// Replaces every string field of <paramref name="baseData"/> whose value differs in
  /// <paramref name="localizedData"/> with a trigger string reference, and returns how many were replaced.
  /// </summary>
  /// <remarks>
  /// Only fields both builds state are shared. A field only the localized build states is left out, so a client
  /// of that language falls back to the game's own text for it, which is already in its language. A field only the
  /// base build states, or one whose value is not text, keeps the base build's value.
  /// </remarks>
  private static int ShareObjectData(object baseData, object localizedData, StringPairs table)
  {
    var localized = new Dictionary<string, ObjectDataModification>();
    foreach (var (key, modification) in EnumerateModifications(localizedData))
    {
      localized.TryAdd(key, modification);
    }

    var changed = 0;
    foreach (var (key, modification) in EnumerateModifications(baseData))
    {
      if (modification.Type != ObjectDataType.String
          || !localized.TryGetValue(key, out var translated)
          || translated.Type != ObjectDataType.String)
      {
        continue;
      }

      var baseValue = modification.ValueAsString;
      var translatedValue = translated.ValueAsString;
      if (string.Equals(baseValue, translatedValue, StringComparison.Ordinal))
      {
        continue;
      }

      modification.Value = table.Reference(baseValue, translatedValue);
      changed++;
    }

    return changed;
  }

  /// <summary>
  /// Pairs each modification of an object data file with a key that identifies the same field in another build.
  /// </summary>
  private static IEnumerable<(string Key, ObjectDataModification Modification)> EnumerateModifications(object data)
  {
    foreach (var listProperty in data.GetType().GetProperties()
               .Where(property => typeof(IList).IsAssignableFrom(property.PropertyType)))
    {
      if (listProperty.GetValue(data) is not IList objects)
      {
        continue;
      }

      foreach (var obj in objects)
      {
        var type = obj.GetType();
        var oldId = type.GetProperty("OldId")?.GetValue(obj);
        var newId = type.GetProperty("NewId")?.GetValue(obj);
        if (type.GetProperty("Modifications")?.GetValue(obj) is not IEnumerable modifications)
        {
          continue;
        }

        foreach (ObjectDataModification modification in modifications)
        {
          var modificationType = modification.GetType();
          var level = modificationType.GetProperty("Level")?.GetValue(modification)
                      ?? modificationType.GetProperty("Variation")?.GetValue(modification)
                      ?? 0;
          var pointer = modificationType.GetProperty("Pointer")?.GetValue(modification) ?? 0;
          yield return ($"{listProperty.Name}/{oldId}/{newId}/{modification.Id}/{level}/{pointer}", modification);
        }
      }
    }
  }

  /// <summary>
  /// Replaces the lobby and loading screen text of <paramref name="baseInfo"/> that differs in
  /// <paramref name="localizedInfo"/> with trigger string references, and returns how many were replaced.
  /// </summary>
  private static int ShareMapInfo(MapInfo baseInfo, MapInfo localizedInfo, StringPairs table)
  {
    var changed = 0;

    void Share(Func<string> getBase, Func<string> getLocalized, Action<string> setBase)
    {
      var baseValue = getBase();
      var translatedValue = getLocalized();
      if (baseValue is null || translatedValue is null || string.Equals(baseValue, translatedValue, StringComparison.Ordinal))
      {
        return;
      }

      setBase(table.Reference(baseValue, translatedValue));
      changed++;
    }

    Share(() => baseInfo.MapName, () => localizedInfo.MapName, value => baseInfo.MapName = value);
    Share(() => baseInfo.MapAuthor, () => localizedInfo.MapAuthor, value => baseInfo.MapAuthor = value);
    Share(() => baseInfo.MapDescription, () => localizedInfo.MapDescription, value => baseInfo.MapDescription = value);
    Share(() => baseInfo.RecommendedPlayers, () => localizedInfo.RecommendedPlayers,
      value => baseInfo.RecommendedPlayers = value);
    Share(() => baseInfo.LoadingScreenText, () => localizedInfo.LoadingScreenText,
      value => baseInfo.LoadingScreenText = value);
    Share(() => baseInfo.LoadingScreenTitle, () => localizedInfo.LoadingScreenTitle,
      value => baseInfo.LoadingScreenTitle = value);
    Share(() => baseInfo.LoadingScreenSubtitle, () => localizedInfo.LoadingScreenSubtitle,
      value => baseInfo.LoadingScreenSubtitle = value);
    Share(() => baseInfo.PrologueScreenText, () => localizedInfo.PrologueScreenText,
      value => baseInfo.PrologueScreenText = value);
    Share(() => baseInfo.PrologueScreenTitle, () => localizedInfo.PrologueScreenTitle,
      value => baseInfo.PrologueScreenTitle = value);
    Share(() => baseInfo.PrologueScreenSubtitle, () => localizedInfo.PrologueScreenSubtitle,
      value => baseInfo.PrologueScreenSubtitle = value);

    for (var i = 0; i < Math.Min(baseInfo.Players.Count, localizedInfo.Players.Count); i++)
    {
      var basePlayer = baseInfo.Players[i];
      var localizedPlayer = localizedInfo.Players[i];
      Share(() => basePlayer.Name, () => localizedPlayer.Name, value => basePlayer.Name = value);
    }

    for (var i = 0; i < Math.Min(baseInfo.Forces.Count, localizedInfo.Forces.Count); i++)
    {
      var baseForce = baseInfo.Forces[i];
      var localizedForce = localizedInfo.Forces[i];
      Share(() => baseForce.Name, () => localizedForce.Name, value => baseForce.Name = value);
    }

    return changed;
  }

  private static void WriteObjectData(BinaryWriter writer, object data)
  {
    switch (data)
    {
      case AbilityObjectData abilities:
        writer.Write(abilities);
        break;
      case BuffObjectData buffs:
        writer.Write(buffs);
        break;
      case DestructableObjectData destructables:
        writer.Write(destructables);
        break;
      case DoodadObjectData doodads:
        writer.Write(doodads);
        break;
      case ItemObjectData items:
        writer.Write(items);
        break;
      case UnitObjectData units:
        writer.Write(units);
        break;
      case UpgradeObjectData upgrades:
        writer.Write(upgrades);
        break;
      default:
        throw new InvalidOperationException($"Unknown object data type {data.GetType().Name}.");
    }
  }

  private static byte[] Serialize(Action<BinaryWriter> write)
  {
    using var stream = new MemoryStream();
    using (var writer = new BinaryWriter(stream, new UTF8Encoding(false), true))
    {
      write(writer);
    }

    return stream.ToArray();
  }

  private static byte[] SerializeStrings(TriggerStrings strings)
  {
    using var stream = new MemoryStream();
    using (var writer = new StreamWriter(stream, new UTF8Encoding(true), leaveOpen: true))
    {
      writer.WriteTriggerStrings(strings);
    }

    return stream.ToArray();
  }

  /// <summary>
  /// Two string files filled in step, so a key resolves to the same field in each language.
  /// </summary>
  private sealed class StringPairs
  {
    private readonly Dictionary<(string, string), uint> _keys = new();
    private uint _nextKey;

    public StringPairs(TriggerStrings baseStrings, TriggerStrings localizedStrings)
    {
      Base = baseStrings ?? new TriggerStrings();
      Localized = localizedStrings ?? new TriggerStrings();
      _nextKey = Base.Strings.Concat(Localized.Strings).Select(s => s.Key + 1).DefaultIfEmpty(0u).Max();
    }

    public TriggerStrings Base { get; }

    public TriggerStrings Localized { get; }

    /// <summary>
    /// Returns the reference for a pair of texts, adding it to both files the first time the pair is seen.
    /// </summary>
    public string Reference(string baseValue, string translatedValue)
    {
      if (!_keys.TryGetValue((baseValue, translatedValue), out var key))
      {
        key = _nextKey++;
        _keys[(baseValue, translatedValue)] = key;
        Base.Strings.Add(new TriggerString { Key = key, KeyPrecision = 3, Value = baseValue });
        Localized.Strings.Add(new TriggerString { Key = key, KeyPrecision = 3, Value = translatedValue });
      }

      return $"TRIGSTR_{key:D3}";
    }
  }
}
