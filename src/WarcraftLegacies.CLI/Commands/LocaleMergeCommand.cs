using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.IO.Mpq;

namespace WarcraftLegacies.CLI.Commands;

/// <summary>
/// Merges a second language into a built map, so one map file serves several languages.
/// <para>
/// Every entry of the base map is kept as a neutral entry. Each file whose bytes differ in the localized map is
/// stored again under the same name, tagged with the locale, so Warcraft III loads the tagged copy for players
/// whose client runs that language and the neutral copy for everyone else.
/// </para>
/// <para>
/// The archive is written through <see cref="MpqArchiveBuilder"/> rather than <c>MapBuilder</c>, because
/// <c>MapBuilder</c> re-serializes the map files it parsed and would overwrite a tagged copy of one of them.
/// </para>
/// </summary>
internal static class LocaleMergeCommand
{
  /// <summary>
  /// The folder Blizzard's World Editor puts per-language file copies in when a map is saved as a scenario folder.
  /// </summary>
  private const string LocaleFolderName = "_Locales";

  /// <param name="basePath">Map supplying the neutral (English) text.</param>
  /// <param name="localizedPath">Map built with <c>--locale</c>, supplying the translated files.</param>
  /// <param name="outputPath">Merged map to write.</param>
  /// <param name="localeName">
  /// The locale to tag the translated files with, such as <c>zh-CN</c>, or a comma-separated list of them, such as
  /// <c>zhcn.w3mod,zhtw.w3mod</c>.
  /// <para>
  /// A list is what makes a released map readable by both regions of one language: each name gets its own folder
  /// holding the same translated files, so a Traditional client is served the Simplified text rather than being
  /// left with a translated script and an English object database. Merging the second region in a second run
  /// instead would store the first region's folder again with no tag, because a run copies every entry of its base
  /// map through as a neutral one - and the hash table this library exposes does not say which tag an entry had.
  /// </para>
  /// </param>
  /// <param name="useLocaleFolder">
  /// Whether to store translated files under <c>_Locales/&lt;locale&gt;/</c>, the layout Blizzard's own World Editor
  /// produces, rather than under their plain names.
  /// <para>
  /// Measured on Reforged: only this layout reaches the player. An entry stored under its plain name with a locale
  /// tag is not honoured inside a map archive - the game reads the untagged copy - so the map comes out with an
  /// English object database and whichever files were kept untagged at the root, which is a map that reads half in
  /// each language. The tag layout is kept because the option is harmless and the behaviour may differ by version,
  /// but <c>--locale-folder</c> is what a released map should be built with.
  /// </para>
  /// </param>
  /// <param name="unlocalized">
  /// Files to take from the localized map but store at their plain archive path with no locale tag.
  /// <para>
  /// Warcraft III reads its own script from the map root rather than through the language folder, so `war3map.lua`
  /// belongs here: tagging it leaves the script out, and the localization table falls through to the English source
  /// strings it is keyed by for every other language.
  /// </para>
  /// <para>
  /// The interface skin and the misc file are not in this group. Keeping them untagged is how a released map ends
  /// up showing one language's menus to every player: `war3mapSkin.txt` holds labels such as "Quit Mission", and an
  /// untagged copy of the translated file shows the translation to an English client as well. Tagged, each client
  /// reads its own.
  /// </para>
  /// </param>
  public static int Run(string basePath, string localizedPath, string outputPath, string localeName,
    bool useLocaleFolder = false, IReadOnlyCollection<string>? unlocalized = null)
  {
    basePath = Path.GetFullPath(basePath);
    localizedPath = Path.GetFullPath(localizedPath);
    outputPath = Path.GetFullPath(outputPath);

    if (!File.Exists(basePath))
    {
      Console.Error.WriteLine($"Base map not found: {basePath}");
      return 1;
    }

    if (!File.Exists(localizedPath))
    {
      Console.Error.WriteLine($"Localized map not found: {localizedPath}");
      return 1;
    }

    var localeNames = localeName
      .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    if (localeNames.Length == 0)
    {
      Console.Error.WriteLine("No locale given.");
      return 1;
    }

    var folder = useLocaleFolder ? LocaleFolderName : null;
    var plain = unlocalized is null
      ? new HashSet<string>(StringComparer.OrdinalIgnoreCase)
      : new HashSet<string>(unlocalized, StringComparer.OrdinalIgnoreCase);

    var baseEntries = ReadAll(basePath);
    var localizedEntries = ReadAll(localizedPath);

    // Only the text differs between a base build and a localized build, so anything else that differs is a
    // surprise worth reporting rather than tagging blindly.
    var targets = localizedEntries
      .Where(kv => !baseEntries.TryGetValue(kv.Key, out var baseline) || !baseline.SequenceEqual(kv.Value))
      .Select(kv => kv.Key)
      .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
      .ToList();

    var keptPlain = targets.Where(plain.Contains).ToList();
    targets = targets.Where(name => !plain.Contains(name)).ToList();

    Console.WriteLine($"Merging {string.Join(", ", localeNames)} into the map.");
    Console.WriteLine(folder is null
      ? "  layout: plain names, locale recorded on each entry"
      : $"  layout: {folder}/<locale>/ (World Editor scenario-folder layout)");
    if (folder is null)
    {
      Console.WriteLine(
        "  WARNING: Warcraft III does not honour a locale tag on a map's own entries, so this layout produces a " +
        "map whose object data stays in the base language. Pass --locale-folder for a map that reaches players.");
    }
    if (keptPlain.Count != 0)
    {
      Console.WriteLine($"  kept at the map root, untagged: {string.Join(", ", keptPlain)}");
    }

    Console.WriteLine($"  files differing from the base build: {targets.Count}");
    foreach (var target in targets)
    {
      Console.WriteLine($"    {target}");
    }

    War3Net.Build.Info.MapInfo mapInfo;
    using (var infoStream = File.OpenRead(basePath))
    {
      mapInfo = Map.Open(infoStream).Info
                ?? throw new InvalidOperationException($"Base map '{basePath}' has no map info.");
    }

    var builder = new MpqArchiveBuilder();
    // The builder writes during Save, so every stream handed to it must outlive this method body.
    var keepAlive = new List<MemoryStream>();

    using (var baseArchive = MpqArchive.Open(basePath, true))
    {
      foreach (var name in ReadListFile(baseArchive))
      {
        // A file that is kept at the map root untagged is written once, from the localized map, below.
        if (keptPlain.Contains(name, StringComparer.OrdinalIgnoreCase))
        {
          continue;
        }

        var stream = new MemoryStream(ReadEntry(baseArchive, name));
        keepAlive.Add(stream);
        builder.AddFile(MpqFile.New(stream, name, MpqLocale.Neutral, false));
      }
    }

    using (var localizedArchive = MpqArchive.Open(localizedPath, true))
    {
      foreach (var name in keptPlain)
      {
        if (!localizedArchive.FileExists(name))
        {
          Console.WriteLine($"  !! localized map has no '{name}', skipped");
          continue;
        }

        var stream = new MemoryStream(ReadEntry(localizedArchive, name));
        keepAlive.Add(stream);
        builder.AddFile(MpqFile.New(stream, name, MpqLocale.Neutral, false));
      }

      foreach (var name in targets)
      {
        var data = ReadEntry(localizedArchive, name);
        foreach (var locale in localeNames)
        {
          var stream = new MemoryStream(data);
          keepAlive.Add(stream);
          // Two layouts are possible and only one may be the one Warcraft III looks for, so the caller chooses:
          // the plain name with the locale on the entry, or Blizzard's _Locales/<locale>/ folder.
          var archiveName = folder is null ? name : $"{folder}/{locale}/{name}";
          // In the folder layout the folder name is what tells one region of a language from another, and the
          // entry's tag has to agree with it: a Simplified Chinese client runs a different locale from a
          // Traditional one, which is the one this library's locale type does not name.
          var entryTag = folder is null ? MapLocaleNames.Parse(locale) : MapLocaleNames.FolderTag(locale);
          builder.AddFile(MpqFile.New(stream, archiveName, entryTag, false));
        }
      }
    }

    Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
    builder.SaveMapWithPreArchiveData(outputPath, new MpqArchiveCreateOptions
    {
      BlockSize = 3,
      AttributesCreateMode = MpqFileCreateMode.Overwrite,
      ListFileCreateMode = MpqFileCreateMode.Overwrite
    }, mapInfo);

    Console.WriteLine($"Wrote a map carrying {string.Join(", ", localeNames)} to {outputPath}.");
    return 0;
  }

  /// <summary>
  /// Reads the names in an archive's own listfile, which is what Warcraft III indexes entries by.
  /// </summary>
  private static IEnumerable<string> ReadListFile(MpqArchive archive)
  {
    if (!archive.FileExists("(listfile)"))
    {
      yield break;
    }

    using var stream = archive.OpenFile("(listfile)");
    using var reader = new StreamReader(stream);
    foreach (var line in reader.ReadToEnd().Split('\n'))
    {
      var name = line.Trim();
      if (name.Length > 0)
      {
        yield return name;
      }
    }
  }

  private static byte[] ReadEntry(MpqArchive archive, string name)
  {
    using var entry = archive.OpenFile(name, null, false);
    var data = new byte[entry.Length];
    var read = 0;
    while (read < data.Length)
    {
      var count = entry.Read(data, read, data.Length - read);
      if (count <= 0)
      {
        break;
      }

      read += count;
    }

    return data;
  }

  private static Dictionary<string, byte[]> ReadAll(string path)
  {
    using var archive = MpqArchive.Open(path, true);
    var result = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
    foreach (var name in ReadListFile(archive))
    {
      try
      {
        result[name] = ReadEntry(archive, name);
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine($"  could not read '{name}': {ex.Message}");
      }
    }

    return result;
  }
}
