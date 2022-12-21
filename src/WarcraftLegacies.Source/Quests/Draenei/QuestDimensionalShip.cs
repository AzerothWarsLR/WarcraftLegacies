using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// 
  /// </summary>
  public class QuestDimensionalShip : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestDimensionalShip"/> class.
    /// </summary>
    public QuestDimensionalShip(Rectangle questRect, PreplacedUnitSystem preplacedUnitSystem) : base("The Dimensional Ship", "The broken Exodar could be rebuild, unlocking a powerful asset for the Draenei.", "")
    {
      Required = true;  
      AddObjective(new ObjectiveBuildInRect(questRect, "inside the Exodar", Constants.UNIT_O056_ARCANE_WELL_DRAENEI, 10));
      AddObjective(new ObjectiveControlLevel(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0BL_EXODAR_REGALIS_25GOLD_MIN), 20));
      AddObjective(new ObjectiveUnitReachesFullHealth(preplacedUnitSystem.GetUnit(Constants.UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI)));

      ResearchId = Constants.UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP;
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