namespace Warcraft.Cartographer.Paths;

/// <summary>
/// One object data file a build reads, together with the locale overlay that refines it.
/// </summary>
public sealed class LocalizedObjectFile
{
  /// <summary>The file name, which identifies the object record.</summary>
  public required string Name { get; init; }

  /// <summary>
  /// The base file, or <see langword="null"/> when the locale overlay introduces a record the base data does not
  /// carry at all.
  /// </summary>
  public string? BasePath { get; init; }

  /// <summary>
  /// The overlay file, or <see langword="null"/> when the locale does not touch this record.
  /// </summary>
  public string? OverlayPath { get; init; }

  /// <summary>The file a build reads when no locale is active.</summary>
  public string EffectivePath => OverlayPath ?? BasePath
    ?? throw new InvalidOperationException($"'{Name}' has neither a base nor an overlay file.");
}
