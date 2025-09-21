using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.ObjectiveSystem;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Objectives;

/// <summary>
/// Acquire one of several items and put them inside the Dimensional Generator.
/// </summary>
public sealed class ObjectivePowerSource : Objective
{
  /// <summary>
  /// The power source that was used to complete the <see cref="Objective"/>.
  /// </summary>
  public item? UsedPowerSource { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectivePowerSource"/> class.
  /// </summary>
  public ObjectivePowerSource(unit dimensionalGenerator, IEnumerable<int> validItemTypeIds)
  {
    Description = $"Place a valid power source in the {dimensionalGenerator.Name}";
    var pickupTrigger = trigger.Create();
    pickupTrigger.RegisterUnitEvent(dimensionalGenerator, unitevent.PickupItem);
    pickupTrigger.AddAction(() =>
    {
      if (validItemTypeIds.Contains(@event.ManipulatedItem.TypeId))
      {
        UsedPowerSource = @event.ManipulatedItem;
        Progress = QuestProgress.Complete;
      }

      else
      {
        @event.ManipulatedItem.SetPosition(@event.Unit.GetPosition());
      }
    });
  }
}
