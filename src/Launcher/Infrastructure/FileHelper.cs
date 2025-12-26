#nullable enable

using System.Collections.Generic;
using System.IO;
using Launcher.DataTransferObjects;
using War3Net.Build.Widget;

namespace Launcher.Infrastructure;

/// <summary>
/// Provides helper methods for serializing values to JSON and writing them to the file system,
/// with optional type mapping support.
/// </summary>
public static class FileHelper
{
  /// <summary>
  /// Serializes the specified value to JSON and writes it to the specified file path.
  /// </summary>
  /// <param name="path">The destination file path.</param>
  /// <param name="value">The value to serialize.</param>
  /// <param name="createDestination">
  /// <see langword="true"/> to create the destination directory if it does not exist.
  /// </param>
  public static void SerializeAndWrite<T>(string path, T value, bool createDestination = true)
    where T : class
  {
    SerializeAndWrite(path, JsonHelper.Serialize(value), createDestination);
  }

  /// <summary>
  /// Serializes the specified widgets into multiple JSON files,
  /// grouped into position-based chunks, and writes them to the specified directory.
  /// </summary>
  /// <typeparam name="T">The source type, derived from <see cref="WidgetData"/>.</typeparam>
  /// <param name="widgets">The widgets to map and serialize.</param>
  /// <param name="path">The destination directory for the generated chunk files.</param>
  public static void SerializeAndWriteInChunks<T>(IEnumerable<T> widgets, string path)
    where T : WidgetData
  {
    foreach (var ((x, y), widgetsInChunk) in new ChunkedWidgetSet<T>(widgets))
    {
      SerializeAndWrite(Path.Combine(path, $"{x}_{y}.json"), widgetsInChunk);
    }
  }

  private static void SerializeAndWrite(string path, string contents, bool createDestination)
  {
    if (createDestination)
    {
      var directory = Path.GetDirectoryName(path);
      if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
      {
        Directory.CreateDirectory(directory);
      }
    }

    File.WriteAllText(path, contents);
  }
}
