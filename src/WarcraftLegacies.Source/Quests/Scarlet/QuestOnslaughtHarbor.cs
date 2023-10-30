using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  
  /// <summary>
  /// Recapture Capital and rebuild it to empower all your heroes.
  /// </summary>
  public sealed class QuestOnslaughtHarbor : QuestData
  {
    private readonly Capital _crimsonCathedral;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestOnslaughtHarbor"/> class.
    /// </summary>
    public QuestOnslaughtHarbor(QuestData newhearthglen, Capital crimsonCathedral) : base(
      "Onslaught Harbor",
      "TODO Flavor: Abbendis has gone too far in her quest for vengeance, but the success of the Crusade has emboldened her with divine power, blinding her to the truth",
      @"ReplaceableTextures/CommandButtons/BTNSpell_Holy_SurgeOfLight.blp")
    {
      _crimsonCathedral = crimsonCathedral;
      AddObjective(new ObjectiveQuestComplete(newhearthglen));
      AddObjective(new ObjectiveControlPoint(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00F_SHOLAZAR_BASIN)));
      ResearchId = Constants.UPGRADE_R04H_QUEST_COMPLETED_ONSLAUGHT_HARBOR;
      crimsonCathedral.Unit.SetInvulnerable(true);
      crimsonCathedral.Unit.Show(false);
    }

    /// <inheritdoc/>>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        SetUnitOwner(_crimsonCathedral.Unit, completingFaction.Player, true);
        _crimsonCathedral.Unit.SetInvulnerable(false);
        _crimsonCathedral.Unit.Show(true);
      }
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "TODO right flavor";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Brigitte Abbendis gains the Divine Intervention ability. The Crimson Cathedral is gained in the Sholazar Bassin";
  }
}