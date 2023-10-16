using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestAlteracBase : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestAlteracBase"/> class
    /// </summary>
    public QuestAlteracBase(Rectangle rescueRect, Capital caerDarrow) : base("Ruins of Alterac",
      "The orcs that occupied Alterac have maintained a secret demon gate, the Legion will make good use of it",
      @"ReplaceableTextures\CommandButtons\BTNDemonCrypt.blp")
    {
      AddObjective(new ObjectiveControlCapital(caerDarrow, false));

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      Required = true;
      ResearchId = Constants.UPGRADE_R01Q_QUEST_COMPLETED_RUINS_OF_ALTERAC;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain control of a small base in Alterac. Enables the alterac portal to be used from the Argus teleporter";

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Legion will reveal their plot in Alterac, unlocking demon-gathering portals";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}