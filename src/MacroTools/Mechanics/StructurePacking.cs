using System;
using MacroTools.Extensions;
using WCSharp.Events;


namespace MacroTools.Mechanics
{
  /// <summary>
  /// Object that contains information and methods for packable structures
  /// </summary>
  public sealed class PackableStructure
  {
    private int _buildAbility;
    private string _structureModel = string.Empty;
    private int _structureId;
    private int _packedUnitId;
    
    /// <summary>
    /// Register a new <see cref="PackableStructure"/>.
    /// </summary>
    public static void Register(int structureId, int packedUnitId, int buildAbility, string structureModel)
    {
      var packable = new PackableStructure
      {
        _buildAbility = buildAbility,
        _structureModel = structureModel,
        _structureId = structureId,
        _packedUnitId = packedUnitId
      };

      PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, () => packable.OnTrainUnitType(), structureId);
      PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, OnUnitTypeCastSpell, packedUnitId);
    }

    /// <summary>
    /// Addes the build ability and special effect to pack units
    /// </summary>
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
      if (GetTrainedUnit().GetTypeId() != _packedUnitId)
        return;
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