using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.ObjectiveSystem;
using MacroTools.QuestSystem;


namespace WarcraftLegacies.Source.Objectives
{
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
      Description = $"Place a valid power source in the {GetUnitName(dimensionalGenerator)}";
      var trigger = CreateTrigger();
      trigger.RegisterUnitEvent(dimensionalGenerator, EVENT_UNIT_PICKUP_ITEM);
      trigger.AddAction(() =>
        {
          if (validItemTypeIds.Contains(GetItemTypeId(GetManipulatedItem())))
          {
            UsedPowerSource = GetManipulatedItem();
            Progress = QuestProgress.Complete;
          }
            
          else
            GetManipulatedItem().SetPosition(GetTriggerUnit().GetPosition());
        });
    }
  }
}