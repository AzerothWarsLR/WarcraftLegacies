using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.QuestOutcomes
{
  /// <summary>
  /// Grants a player a research. The research is expected to unlock training of a particular unit.
  /// </summary>
  public class QuestOutcomeUnlockUnitType : QuestOutcome
  {
    private readonly int _researchId;
    
    public QuestOutcomeUnlockUnitType(int unitTypeId, IEnumerable<int> trainingBuildingTypeIds, int researchId)
    {
      var trainingBuildingTypeNames = new List<string>();
      foreach (var id in trainingBuildingTypeIds)
      {
        trainingBuildingTypeNames.Add(GetObjectName(id));
      }
      Description = $"Learn to train {GetObjectName(unitTypeId)} from {string.Join(", ", trainingBuildingTypeNames)}";
      _researchId = researchId;
    }

    public override void Fire()
    {
      if (ParentFaction != null) SetPlayerTechResearched(ParentFaction.Player, _researchId, 1);
    }
  }
}