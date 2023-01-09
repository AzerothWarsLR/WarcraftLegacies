using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Theramore starts neutral and must be discovered.
  /// </summary>
  public sealed class QuestTheramore : QuestData
  {
    private const int RequiredResearch = Constants.UPGRADE_R06K_KALIMDOR_EXPEDITION_DALARAN;

    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTheramore"/> class.
    /// </summary>
    /// <param name="theramoreRect">All units in this area will be made neutral, then rescued when the quest is completed.</param>
    public QuestTheramore(Rectangle theramoreRect) : base("Theramore",
      "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanArcaneTower.blp")
    {
      AddObjective(new ObjectiveResearch(RequiredResearch, Constants.UNIT_H076_SHIPYARD_DALARAN_SHIPYARD));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = theramoreRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "A sizeable isle off the coast of Dustwallow Marsh has been colonized and dubbed Theramore, marking the first human settlement to be established on Kalimdor.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units at Theramore";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      completingFaction.ModObjectLimit(RequiredResearch, -Faction.UNLIMITED);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
        completingFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
      completingFaction.ModObjectLimit(RequiredResearch, -Faction.UNLIMITED);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(RequiredResearch, Faction.UNLIMITED);
    }
  }
}