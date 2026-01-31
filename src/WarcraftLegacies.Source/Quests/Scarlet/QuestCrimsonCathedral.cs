using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Quests.Scarlet;

public sealed class QuestCrimsonCathedral : QuestData
{
  private readonly Capital _crimsonCathedral;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestCrimsonCathedral"/> class.
  /// </summary>
  public QuestCrimsonCathedral(QuestData newhearthglen, Capital crimsonCathedral) : base(
    "The Crimson Cathedral",
    "The Crusade's architects have drawn up plans for an ornate cathedral, to be erected in the frozen wastes of Northrend. It shall be a beacon in the dark.",
    "ReplaceableTextures/CommandButtons/BTNSpell_Holy_SurgeOfLight.blp")
  {
    _crimsonCathedral = crimsonCathedral;
    AddObjective(new ObjectiveQuestComplete(newhearthglen));
    AddObjective(new ObjectiveControlPoint(UNIT_N00F_SHOLAZAR_BASIN));
    ResearchId = UPGRADE_R04H_QUEST_COMPLETED_THE_CRIMSON_CATHEDRAL;
    if (crimsonCathedral.Unit != null)
    {
      crimsonCathedral.Unit.IsInvulnerable = true;
      crimsonCathedral.Unit.IsVisible = false;
    }
  }

  /// <inheritdoc/>>
  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player != null)
    {
      _crimsonCathedral.Unit?.Rescue(completingFaction.Player);
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Crimson Cathedral has been established in Northrend. Seeing first-hand that the Light can reach even the darkest places of the world, what few shreds of doubt lingering in Brigitte Abbendis' soul evaporate.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Brigitte Abbendis gains the Divine Intervention ability, and you gain control of the Crimson Cathedral in Sholazar Bassin";
}
