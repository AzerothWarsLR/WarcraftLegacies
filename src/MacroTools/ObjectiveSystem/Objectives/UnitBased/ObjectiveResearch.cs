using System;
using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  public sealed class ObjectiveResearch : Objective
  {
    public ObjectiveResearch(int researchId, int structureId)
    {
      Description = $"Research {GetObjectName(researchId)} from the {GetObjectName(structureId)}";
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, OnAnyResearch, researchId);
    }

    private void OnAnyResearch()
    {
      try
      {
        if (EligibleFactions.Contains(GetOwningPlayer(GetTriggerUnit())) is true)
          Progress = QuestProgress.Complete;
      }
      catch (Exception ex)
      {
        Logger.LogError(ex.ToString());
      }
    }
  }
}