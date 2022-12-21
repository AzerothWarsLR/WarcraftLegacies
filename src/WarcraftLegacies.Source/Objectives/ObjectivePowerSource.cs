using System.Collections.Generic;
using System.Linq;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Objectives
{
  /// <summary>
  /// Acquire one of several Artifacts and put them inside the Dimensional Generator.
  /// </summary>
  public sealed class ObjectivePowerSource : Objective
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectivePowerSource"/> class.
    /// </summary>
    public ObjectivePowerSource(unit dimensionalGenerator, IEnumerable<Artifact> powerSources)
    {
      Description = $"Place a valid power source in the {GetUnitName(dimensionalGenerator)}";
      CreateTrigger()
        .RegisterUnitEvent(dimensionalGenerator, EVENT_UNIT_PICKUP_ITEM)
        .AddAction(() =>
        {
          var manipulatedArtifact = ArtifactManager.GetFromTypeId(GetItemTypeId(GetManipulatedItem()));
          if (manipulatedArtifact != null && powerSources.Contains(manipulatedArtifact))
            Progress = QuestProgress.Complete;
          else
            GetManipulatedItem().SetPosition(GetTriggerUnit().GetPosition());
        });
    }
  }
}