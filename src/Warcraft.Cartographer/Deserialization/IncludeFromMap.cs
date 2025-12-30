using War3Net.Build;

namespace Warcraft.Cartographer.Deserialization;

/// <summary>
/// Flags indicating which files and folders should be retained in a W3X map conversion.
/// </summary>
[Flags]
public enum IncludeFromMap
{
  Sounds = 1 << 0,
  Environment = 1 << 1,
  PathingMap = 1 << 2,
  PreviewIcons = 1 << 3,
  Regions = 1 << 4,
  ShadowMap = 1 << 5,
  Minimap = 1 << 6,
  Imports = 1 << 7,
  Info = 1 << 8,

  AbilityData = 1 << 9,
  BuffData = 1 << 10,
  DestructableData = 1 << 11,
  DoodadData = 1 << 12,
  ItemData = 1 << 13,
  UnitData = 1 << 14,
  UpgradeData = 1 << 15,

  GameplayConstants = 1 << 16,
  GameInterface = 1 << 17,
  Script = 1 << 18,

  Doodads = 1 << 19,
  Units = 1 << 20,

  TriggerStrings = 1 << 21,

  ObjectData =
    AbilityData |
    BuffData |
    DestructableData |
    DoodadData |
    ItemData |
    UnitData |
    UpgradeData |
    TriggerStrings,

  Terrain =
    Environment |
    PathingMap |
    PreviewIcons |
    ShadowMap |
    Doodads,

  All =
    Sounds |
    Terrain |
    Regions |
    ShadowMap |
    Minimap |
    Imports |
    Info |
    ObjectData |
    GameplayConstants |
    GameInterface |
    Script |
    Units
}

public static class IncludeFromMapExtensions
{
  /// <summary>
  /// Converts <see cref="IncludeFromMap"/> flags to War3Net-based <see cref="MapFiles"/> flags, which can be used
  /// to determine which files are incorporated from a W3X to a new <see cref="Map"/>.
  /// <remarks>Not all <see cref="IncludeFromMap"/> flags have a corresponding <see cref="MapFiles"/> flag.</remarks>
  /// </summary>
  public static MapFiles ToWar3NetMapFiles(this IncludeFromMap include)
  {
    MapFiles result = 0;

    if (include.HasFlag(IncludeFromMap.Sounds))
    {
      result |= MapFiles.Sounds;
    }

    if (include.HasFlag(IncludeFromMap.Environment))
    {
      result |= MapFiles.Environment;
    }

    if (include.HasFlag(IncludeFromMap.PathingMap))
    {
      result |= MapFiles.PathingMap;
    }

    if (include.HasFlag(IncludeFromMap.PreviewIcons))
    {
      result |= MapFiles.PreviewIcons;
    }

    if (include.HasFlag(IncludeFromMap.Regions))
    {
      result |= MapFiles.Regions;
    }

    if (include.HasFlag(IncludeFromMap.ShadowMap))
    {
      result |= MapFiles.ShadowMap;
    }

    if (include.HasFlag(IncludeFromMap.Imports))
    {
      result |= MapFiles.ImportedFiles;
    }

    if (include.HasFlag(IncludeFromMap.Info))
    {
      result |= MapFiles.Info;
    }

    if (include.HasFlag(IncludeFromMap.AbilityData))
    {
      result |= MapFiles.AbilityObjectData;
    }

    if (include.HasFlag(IncludeFromMap.BuffData))
    {
      result |= MapFiles.BuffObjectData;
    }

    if (include.HasFlag(IncludeFromMap.DestructableData))
    {
      result |= MapFiles.DestructableObjectData;
    }

    if (include.HasFlag(IncludeFromMap.DoodadData))
    {
      result |= MapFiles.DoodadObjectData;
    }

    if (include.HasFlag(IncludeFromMap.ItemData))
    {
      result |= MapFiles.ItemObjectData;
    }

    if (include.HasFlag(IncludeFromMap.UnitData))
    {
      result |= MapFiles.UnitObjectData;
    }

    if (include.HasFlag(IncludeFromMap.UpgradeData))
    {
      result |= MapFiles.UpgradeObjectData;
    }

    if (include.HasFlag(IncludeFromMap.Script))
    {
      result |= MapFiles.Script;
    }

    if (include.HasFlag(IncludeFromMap.Doodads))
    {
      result |= MapFiles.Doodads;
    }

    if (include.HasFlag(IncludeFromMap.Units))
    {
      result |= MapFiles.Units;
    }

    if (include.HasFlag(IncludeFromMap.TriggerStrings))
    {
      result |= MapFiles.TriggerStrings;
    }

    return result;
  }
}
