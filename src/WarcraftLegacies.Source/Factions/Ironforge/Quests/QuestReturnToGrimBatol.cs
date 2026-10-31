using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Take the lands around Grim Batol to raise stronger gryphons in its old aeries.</summary>
public sealed class QuestReturnToGrimBatol : QuestData
{
  public QuestReturnToGrimBatol() : base("Return to Grim Batol",
    "Grim Batol was the Wildhammer's home until the Dark Iron cursed it. Retake the mountain and its highlands, and its old aeries will raise gryphons once more.",
    @"ReplaceableTextures\CommandButtons\BTNWildhammerGryphon.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N03X_GRIM_BATOL));
    AddObjective(new ObjectiveControlPoint(UNIT_N04V_NORTHERN_HIGHLANDS));
    AddObjective(new ObjectiveControlPoint(UNIT_N09F_SOUTHERN_HIGHLANDS));
    ResearchId = UPGRADE_R118_GRIM_BATOL_AERIES_WILDHAMMER;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Wildhammer have returned to Grim Batol, and gryphons nest in its peaks again.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "{rider}s, {gryphon}s, {soarer}s and {guardian}s gain 100 hit points",
    ("{rider}", GetObjectName(UNIT_H0FL_GRYPHON_RIDER_WILDHAMMER)),
    ("{gryphon}", GetObjectName(UNIT_H0F6_GRYPHON_WILDHAMMER)),
    ("{soarer}", GetObjectName(UNIT_H0F7_SOARER_WILDHAMMER)),
    ("{guardian}", GetObjectName(UNIT_H0F5_CLOUD_GUARDIAN_WILDHAMMER_ELITE)));

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
