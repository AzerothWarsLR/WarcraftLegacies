using System;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Mechanics
{
  /// <summary>
  /// System to allow structures to convert themselves into units. Those units can then use an ability to rebuild the building.
  /// </summary>
  public sealed class StructurePacking
  {
    /// <summary>
    /// Object that contains information and methods for packable structures
    /// </summary>
    public sealed class PackableStructure
    {
      public int PackedUnitId;
      public int BuildAbility;
      public string StructureModel = string.Empty;
      public int StructureId;

      /// <summary>
      /// Method for creating new packable structure entries
      /// </summary>
      /// <param name="structureId"></param>
      /// <param name="packedUnitId"></param>
      /// <param name="buildAbility"></param>
      /// <param name="structureModel"></param>
      public static void Register(int structureId, int packedUnitId, int buildAbility, string structureModel)
      {
        var packable = new PackableStructure
        {
          PackedUnitId = packedUnitId,
          BuildAbility = buildAbility,
          StructureModel = structureModel,
          StructureId = structureId
        };

        PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, () => packable.OnTrainUnitType(),structureId);
          
        PlayerUnitEvents.Register(UnitTypeEvent.SpellEndCast, () => packable.OnUnitTypeCastSpell(),packedUnitId);
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
        if (GetUnitTypeId(GetTrainedUnit()) != PackedUnitId) return;
        PackBuilding(GetTriggerUnit(),GetTrainedUnit());
        RemoveUnit(GetTriggerUnit());
      }
      
      private void OnUnitTypeCastSpell()
      {
        if (GetUnitTypeId(GetTriggerUnit()) != PackedUnitId) return;
        KillUnit(GetTriggerUnit());
        RemoveUnit(GetTriggerUnit());
      }
    }
  }
}