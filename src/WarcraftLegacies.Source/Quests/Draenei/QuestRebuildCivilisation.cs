using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// 
  /// </summary>
  public class QuestRebuildCivilisation : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildCivilisation"/> class.
    /// </summary>
    public QuestRebuildCivilisation(Rectangle questRect) : base("The Way Forward", "Establish a base around the Exodar in order to secure it.", "")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "on Azuremyst Isle", Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI, 4));
      AddObjective(new ObjectiveBuildInRect(questRect, "on Azuremyst Isle", Constants.UNIT_O058_ALTAR_OF_LIGHT_DRAENEI));
      AddObjective(new ObjectiveBuildInRect(questRect, "on Azuremyst Isle", Constants.UNIT_O056_ARCANE_WELL_DRAENEI, 10));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_O051_DIVINE_CITADEL_DRAENEI, Constants.UNIT_O02P_CRYSTAL_HALL_DRAENEI));

      ResearchId = Constants.UPGRADE_R082_QUEST_COMPLETED_THE_WAY_FORWARD;// Change this to current quest;
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