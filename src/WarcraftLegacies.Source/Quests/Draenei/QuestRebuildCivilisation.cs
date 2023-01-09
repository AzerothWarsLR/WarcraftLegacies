using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Build various structures inside <see cref="Regions.AzuremystAmbient"/>
  /// </summary>
  public class QuestRebuildCivilisation : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildCivilisation"/> class.
    /// </summary>
    public QuestRebuildCivilisation(Rectangle questRect) : base("The Way Forward", "Establish a base around the Exodar in order to secure it.", "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "on Azuremyst Isle", Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, 4));
      AddObjective(new ObjectiveBuildInRect(questRect, "on Azuremyst Isle", Constants.UNIT_O058_ALTAR_OF_LIGHT_DRAENEI_ALTAR));
      AddObjective(new ObjectiveBuildInRect(questRect, "on Azuremyst Isle", Constants.UNIT_O056_ARCANE_WELL_DRAENEI_FARM, 10));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02Z_AZUREMYST_ISLE_15GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R082_QUEST_COMPLETED_THE_WAY_FORWARD;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
      {
        whichFaction.Player.AddGold(500);
        whichFaction.Player.AddLumber(200);
      }
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "The Exodar is secure and Maraad joins the Draenai.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain 500 Gold, 200 Lumber and Maraad is now trainable at the altar.";

   }
 }