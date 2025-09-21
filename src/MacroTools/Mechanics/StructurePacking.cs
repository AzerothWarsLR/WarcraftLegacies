using System;
using MacroTools.Extensions;
using WCSharp.Events;

namespace MacroTools.Mechanics;

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
    effect effect = effect.Create(_structureModel, packedUnit, "overhead");
    effect.Scale = (float)0.25;
    effect.SetTime(100);
    packedUnit.AddAbility(_buildAbility);
  }

  private void PackBuilding(unit building, unit packedUnit)
  {
    if (_structureId != building.UnitType)
    {
      Console.WriteLine($"ERROR: there is no PackableStructure setup for building: {building.Name}");
      return;
    }

    PackUnitSetup(packedUnit);
    building.Dispose();
  }

  private void OnTrainUnitType()
  {
    if (@event.TrainedUnit.UnitType != _packedUnitId)
    {
      return;
    }

    PackBuilding(@event.Unit, @event.TrainedUnit);
    @event.Unit.Dispose();
  }

  private static void OnUnitTypeCastSpell()
  {
    @event.Unit.SetTimedLife(0.01f);
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(@event.Unit, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      @event.Unit.Dispose();
      @event.Trigger.Dispose();
    });
  }
}
