using System;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Mechanics
{
  /// <summary>
  /// System to allow structures to convert themselves into units. Those units can then use an ability to rebuild the building.
  /// </summary>
  public class StructurePacking
  {
    /// <summary>
    /// Object that contains information and methods for packable structures
    /// </summary>
    public class PackableStructure
    {
      private static readonly Dictionary<int, PackableStructure> PackableStructureById = new();
      private int _packedUnitId;
      private int _buildAbility;
      private string? _structureModel;

      /// <summary>
      /// Method for creating new packable structure entries
      /// </summary>
      /// <param name="structureId"></param>
      /// <param name="packedUnitId"></param>
      /// <param name="buildAbility"></param>
      /// <param name="structureModel"></param>
      public static void Create(int structureId, int packedUnitId, int buildAbility, string? structureModel)
      {
        var packable = new PackableStructure
        {
          _packedUnitId = packedUnitId,
          _buildAbility = buildAbility,
          _structureModel = structureModel
        };
        PackableStructureById[structureId] = packable;
        
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, GetPackableStructureById(structureId).OnTrainUnitType,structureId);
          
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeSpellEndCast, GetPackableStructureById(structureId).OnUnitTypeCastSpell,packedUnitId);
      }
      
      /// <summary>
      /// Use a structure id to retrieve a <see cref="PackableStructure" /> object from the Dictionary
      /// </summary>
      /// <param name="structureId"></param>
      /// <returns></returns>
      public static PackableStructure? GetPackableStructureById(int structureId) =>
        PackableStructureById.TryGetValue(structureId, out var packableStructure) ? packableStructure : null;

      /// <summary>
      /// Addes the build ability and special effect to pack units
      /// </summary>
      /// <param name="packedUnit"></param>
      public void PackUnitSetup(unit packedUnit)
      {
        var effect = AddSpecialEffectTarget(_structureModel, packedUnit, "overhead");
        BlzSetSpecialEffectScale(effect, (float)0.25);
        BlzSetSpecialEffectTime(effect, 100);
        UnitAddAbility(packedUnit, _buildAbility);
      }

      private static void PackBuilding(unit building, unit packedUnit)
      {
        if (!PackableStructureById.ContainsKey(GetUnitTypeId(building)))
        {
          Console.WriteLine($"ERROR: there is no PackableStructure setup for building: {GetUnitName(building)}");
          return;
        }
        PackableStructureById[GetUnitTypeId(building)].PackUnitSetup(packedUnit);
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