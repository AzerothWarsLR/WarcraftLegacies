using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.PreplacedWidgets;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Hides the preplaced units and doodads in Orgrimmar until later events reveal them.
/// </summary>
public static class OrgrimmarSetup
{
  private static readonly int[] _unitTypesToHide =
  {
    UNIT_O01B_ORGRIMMAR_WARSONG,
    UNIT_H00L_HORIZONTAL_WOODEN_GATE_GATE_OPEN,
    UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG
  };

  // Maps the unit type that, once built anywhere in Orgrimmar, reveals a specific props sub-region.
  private static readonly (int UnitTypeId, Rectangle Region)[] _doodadRevealTriggers =
  {
    (UNIT_O076_ALTAR_OF_STORMS_ORCISH_HORDE, Regions.Orgrimmar_Props_1),
    (UNIT_O07H_WAR_MILL_ORCISH_HORDE_RESEARCH, Regions.Orgrimmar_Props_2),
    (UNIT_O075_WAR_CAMP_ORCISH_HORDE, Regions.Orgrimmar_Props_3)
  };

  private static readonly HashSet<int> _allowedProps = new()
  {
    FourCC("D013"), // Needle
    FourCC("BPca"), // Cactus
    FourCC("BObo"), // Bones
    FourCC("D06R"), // 1 - Barrens Tree Yellow
    FourCC("D06N"), // 1 - Barrens Canopy Tree
    FourCC("D06M"), // 1 - Ashenvale Canopy Tree
    FourCC("D06U"), // 1 - Fall Tree
    FourCC("BRrk"), // Rocks (Barrens)
    FourCC("BRsp"), // Rock Spires Small (Barrens)
    FourCC("BRrs"), // Rock Spires (Barrens)
    FourCC("BRfs"), // Fissure (Barrens)
    FourCC("LRrk"), // Rocks (Lordaeron)
    FourCC("ZPsh"), // Shrub
    FourCC("ZPru"), // Cattail (SunkenRuins)
    FourCC("D01I"), // Bones Large
    FourCC("LWw0"), // Waterfall
    FourCC("D04M"), // Darkness
    FourCC("D02O"), // Cave
    FourCC("ASpr")  // Pier
  };

  public static void Setup()
  {
    HideUnits();
    HideDoodads();
    RegisterDoodadRevealTriggers();
  }

  /// <summary>
  /// Reveals the units in Orgrimmar.
  /// </summary>
  public static void RevealUnits()
  {
    foreach (var typeId in _unitTypesToHide)
    {
      foreach (var unit in AllPreplacedWidgets.Units.GetAll(typeId).Where(u => Regions.Orgrimmar.Contains(u.GetPosition())))
      {
        unit.IsPaused = false;
        unit.IsVisible = true;
      }
    }
  }

  /// <summary>
  /// Reveals every prop in the given sub-region of Orgrimmar.
  /// </summary>
  public static void RevealDoodads(Rectangle whichRegion)
  {
    whichRegion.Rect.EnumerateDestructables(null, () =>
    {
      GetEnumDestructable().SetVisibility(true);
    });
  }

  private static void HideUnits()
  {
    foreach (var typeId in _unitTypesToHide)
    {
      foreach (var unit in AllPreplacedWidgets.Units.GetAll(typeId).Where(u => Regions.Orgrimmar.Contains(u.GetPosition())))
      {
        unit.IsPaused = true;
        unit.IsVisible = false;
      }
    }
  }

  private static void HideDoodads()
  {
    Regions.Orgrimmar.Rect.EnumerateDestructables(null, () =>
    {
      var prop = GetEnumDestructable();
      if (!_allowedProps.Contains(prop.Type))
      {
        prop.SetVisibility(false);
      }
    });
  }

  private static void RegisterDoodadRevealTriggers()
  {
    foreach (var (unitTypeId, region) in _doodadRevealTriggers)
    {
      Action? actionWithUnregister = null;
      actionWithUnregister = () =>
      {
        if (Regions.Orgrimmar.Contains(@event.Unit.GetPosition()))
        {
          RevealDoodads(region);
          PlayerUnitEvents.Unregister(UnitTypeEvent.FinishesBeingConstructed, actionWithUnregister, unitTypeId);
        }
      };
      PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingConstructed, actionWithUnregister, unitTypeId);
    }
  }
}
