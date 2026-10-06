using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using War3Net.Build;
using War3Net.IO.Mpq;

namespace WarcraftLegacies.CLI.Commands;

/// <summary>
/// Reports which language each file of a built map is stored for, so a multi-language build can be audited.
/// <para>
/// Reading a file back per locale is the only reliable test: MPQ stores entries with open addressing, so a name
/// whose preferred hash slot is taken lands somewhere else. Deriving an entry's slot from its name therefore
/// reports the wrong locale, and the hash table itself is the authority.
/// </para>
/// </summary>
internal static class LocaleAuditCommand
{

  public static int Run(string mapPath, IReadOnlyList<string> files)
  {
    mapPath = Path.GetFullPath(mapPath);
    if (!File.Exists(mapPath))
    {
      Console.Error.WriteLine($"Map not found: {mapPath}");
      return 1;
    }

    using var mapStream = File.OpenRead(mapPath);
    var map = Map.Open(mapStream);
    Console.WriteLine($"{Path.GetFileName(mapPath)}  ({new FileInfo(mapPath).Length:N0} bytes)");
    Console.WriteLine($"  map name: {map.Info?.MapName}");

    using var archive = MpqArchive.Open(mapPath, true);
    var names = ReadListFile(archive).ToList();
    Console.WriteLine($"  files: {names.Count}");

    // The hash table is the only place that records an entry's locale. Deriving it from the file name is wrong,
    // because MPQ stores entries with open addressing: a name whose preferred slot is taken lands elsewhere, so
    // the slot computed from the name belongs to a different entry.
    var hashes = archive.EnumerateHashes().ToList();
    Console.WriteLine();
    Console.WriteLine("  hash entries per locale:");
    foreach (var group in hashes.GroupBy(h => h.Locale).OrderBy(g => (int)g.Key))
    {
      Console.WriteLine($"    {(int)group.Key,-6} {group.Key,-10} {group.Count(),6}");
    }

    var localizedCount = hashes.Count(h => h.Locale != MpqLocale.Neutral);
    Console.WriteLine();
    Console.WriteLine($"  localized hash entries: {localizedCount}");

    if (files.Count == 0)
    {
      return 0;
    }

    // For the named files, show what each language would load, which is what a player actually sees.
    Console.WriteLine();
    Console.WriteLine("  content per language:");
    foreach (var name in files)
    {
      if (!names.Contains(name, StringComparer.OrdinalIgnoreCase))
      {
        Console.WriteLine($"    {name}: not present");
        continue;
      }

      Console.WriteLine($"    {name}");
      foreach (var locale in new[] { MpqLocale.Neutral, MpqLocale.Chinese, MpqLocale.English })
      {
        try
        {
          using var entry = archive.OpenFile(name, locale, false);
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

          var cjk = 0;
          foreach (var b in data)
          {
            if (b >= 0x80)
            {
              cjk++;
            }
          }

          Console.WriteLine($"      {locale,-10} {data.Length,12:N0} bytes   non-ASCII bytes: {cjk,8:N0}");
        }
        catch (FileNotFoundException)
        {
          Console.WriteLine($"      {locale,-10} (not stored for this locale)");
        }
      }
    }

    return 0;
  }

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
}
