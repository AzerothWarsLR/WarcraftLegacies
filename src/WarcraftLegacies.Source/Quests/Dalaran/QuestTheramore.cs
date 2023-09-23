using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  /// <summary>
  /// Theramore starts neutral and must be discovered.
  /// </summary>
  public sealed class QuestTheramore : QuestData
  {

    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTheramore"/> class.
    /// </summary>
    /// <param name="dalaran"></param>
    /// <param name="theramoreRect">All units in this area will be made neutral, then rescued when the quest is completed.</param>
    public QuestTheramore(Capital dalaran, Rectangle theramoreRect) : base("Theramore",
      "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.",
      @"ReplaceableTextures\CommandButtons\BTNHumanArcaneTower.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R0A7, Constants.UNIT_H002_THE_VIOLET_CITADEL_DALARAN_OTHER));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = theramoreRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "With the once mighty city of Dalaran at the brink of destruction, Jaina leads her people East";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units at Theramore, teleport all your units that are in Dalaran to Theramore. Dalaran becomes hostile.";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
        completingFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
    }
  }
}