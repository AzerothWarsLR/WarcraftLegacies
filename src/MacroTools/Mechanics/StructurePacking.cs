using System;
using System.Collections.Generic;
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
      public int _packedUnitId;
      public int _buildAbility;
      public string _structureModel = string.Empty;
      public int _structureId;

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
          _packedUnitId = packedUnitId,
          _buildAbility = buildAbility,
          _structureModel = structureModel,
          _structureId = structureId
        };

        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, () => packable.OnTrainUnitType(),structureId);
          
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeSpellEndCast, () => packable.OnUnitTypeCastSpell(),packedUnitId);
      }

      /// <summary>
      /// Addes the build ability and special effect to pack units
      /// </summary>
      /// <param name="packedUnit"></param>
      /// <param name="packable"></param>
      public void PackUnitSetup(unit packedUnit)
      {
        var effect = AddSpecialEffectTarget(_structureModel, packedUnit, "overhead");
        BlzSetSpecialEffectScale(effect, (float)0.25);
        BlzSetSpecialEffectTime(effect, 100);
        UnitAddAbility(packedUnit, _buildAbility);
      }

      private void PackBuilding(unit building, unit packedUnit)
      {
        if (_structureId != GetUnitTypeId(building))
        {
          Console.WriteLine($"ERROR: there is no PackableStructure setup for building: {GetUnitName(building)}");
          return;
        }
        PackUnitSetup(packedUnit);
        RemoveUnit(building);
      }

      private void OnTrainUnitType()
      {
        if (GetUnitTypeId(GetTrainedUnit()) != _packedUnitId) return;
        PackBuilding(GetTriggerUnit(),GetTrainedUnit());
        RemoveUnit(GetTriggerUnit());
      }
      
      private void OnUnitTypeCastSpell()
      {
        if (GetUnitTypeId(GetTriggerUnit()) != _packedUnitId) return;
        KillUnit(GetTriggerUnit());
        RemoveUnit(GetTriggerUnit());
      }
    }
  }
}