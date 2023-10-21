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
      "The orcs that occupied Alterac have maintained a secret demon gate, the Legion will make good use of it. This will enable the legion to propagate grim shrines around Lordaeron.",
      @"ReplaceableTextures\CommandButtons\BTNDemonCrypt.blp")
    {
      AddObjective(new ObjectiveControlCapital(caerDarrow, false));

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      Required = true;
      ResearchId = Constants.UPGRADE_R01L_QUEST_COMPLETED_RUINS_OF_ALTERAC;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => $"Gain control of a small base in Alterac, learn to generate a portal to Alterac using the Argus Teleporter, and gain a {GetObjectName(Constants.UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL)} in each of the following Scourge bases: Deathknell, Stratholme Coast, and Scholomance.";

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Legion unveils their plot, a secret base of operation in the Alterac Mountains. Their cult also assisting the Scourge to destroy Lordaeron.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
      CreateUnit(completingFaction.Player, Constants.UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL, 11138, 12802, 0);
      CreateUnit(completingFaction.Player, Constants.UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL, 4860, 9277, 0);
      CreateUnit(completingFaction.Player, Constants.UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL, 14725, 7356, 0);
    }
  }
}