#nullable enable

namespace Launcher.Services;

public sealed class AdvancedMapBuilderOptions
{
  /// <summary>
  /// What to call the resulting map file.
  /// </summary>
  public required string MapName { get; init; }

  public required MapOutputType OutputType { get; init; }

  public required string RootPath { get; init; }

  public string? Warcraft3ExecutablePath { get; init; }

  public string? Version { get; init; }

  public int TestingPlayerSlot { get; init; }
}
