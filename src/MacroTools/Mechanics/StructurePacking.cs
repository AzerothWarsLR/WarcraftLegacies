using System;
using MacroTools.Extensions;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Mechanics
{
  /// <summary>
  /// Object that contains information and methods for packable structures
  /// </summary>
  public sealed class PackableStructure
  {
    /// <summary>
    /// A "Build Tiny X" ability used to reconstruct the building.
    /// </summary>
    public int BuildAbility { get; init; }
    
    /// <summary>
    /// The structure model that appears above the Kodo's head.
    /// </summary>
    public string StructureModel { get; init; } = string.Empty;
    
    /// <summary>
    /// The structure that the Kodo can rebuild.
    /// </summary>
    public int StructureId { get; init; }
    
    /// <summary>
    /// Register a new <see cref="PackableStructure"/>.
    /// </summary>
    public static void Register(int structureId, int packedUnitId, int buildAbility, string structureModel)
    {
      var packable = new PackableStructure
      {
        BuildAbility = buildAbility,
        StructureModel = structureModel,
        StructureId = structureId
      };

      PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, () => packable.OnTrainUnitType(), structureId);
      PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, OnUnitTypeCastSpell, packedUnitId);
    }

    /// <summary>
    /// Addes the build ability and special effect to pack units
    /// </summary>
    public void PackUnitSetup(unit packedUnit)
    {
      var effect = AddSpecialEffectTarget(StructureModel, packedUnit, "overhead");
      BlzSetSpecialEffectScale(effect, (float)0.25);
      BlzSetSpecialEffectTime(effect, 100);
      UnitAddAbility(packedUnit, BuildAbility);
    }

    private void PackBuilding(unit building, unit packedUnit)
    {
      if (StructureId != GetUnitTypeId(building))
      {
        Console.WriteLine($"ERROR: there is no PackableStructure setup for building: {GetUnitName(building)}");
        return;
      }

      PackUnitSetup(packedUnit);
      RemoveUnit(building);
    }

    private void OnTrainUnitType()
    {
      PackBuilding(GetTriggerUnit(), GetTrainedUnit());
      RemoveUnit(GetTriggerUnit());
    }

    private static void OnUnitTypeCastSpell()
    {
      GetTriggerUnit().SetTimedLife(0.01f);
      CreateTrigger().RegisterUnitEvent(GetTriggerUnit(), EVENT_UNIT_DEATH).AddAction(() =>
      {
        RemoveUnit(GetTriggerUnit());
        DestroyTrigger(GetTriggeringTrigger());
      });
    }
  }
}