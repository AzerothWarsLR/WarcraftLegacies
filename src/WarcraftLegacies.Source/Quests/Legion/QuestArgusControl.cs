using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestArgusControl : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestArgusControl() : base("Argus Incursion",
      "The planet of Argus is not fully under the control of the Legion. Bring it under control!",
      "ReplaceableTextures\\CommandButtons\\BTNMastersLodge.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0BF"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0BH"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0BG"))));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R055_QUEST_COMPLETED_ARGUS_INCURSION;
      Required = true;
      _rescueUnits.Add(LegendLegion.LegionNexusAlterac.Unit);
      _rescueUnits.Add(LegendLegion.LegionNexusNorthrend.Unit);
    }

    protected override string RewardDescription => "Enable to research Astral Walk and build a shop";
    protected override string CompletionPopup => "Enable to research Astral Walk and build a shop";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}