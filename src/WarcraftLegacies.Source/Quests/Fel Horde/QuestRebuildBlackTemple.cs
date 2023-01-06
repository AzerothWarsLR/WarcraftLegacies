using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WCSharp.Shared.Data;
using MacroTools.ControlPointSystem;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public class QuestRebuildBlackTemple : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuilBlackTemple"/> class.
    /// </summary>
    public QuestRebuildBlackTemple(Rectangle questRect) : base("Ash and Smoke", "Rebuild Black Temple for the glory of the Illidari", "ReplaceableTextures\\CommandButtons\\BTNFelOrcAltarOfStorms.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Black Temple", Constants.UNIT_O034_WATCH_TOWER_FEL_HORDE_TOWER, 4));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Black Temple", Constants.UNIT_O02W_BARRACKS_FEL_HORDE_BARRACKS));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Black Temple", Constants.UNIT_O02X_BEASTIARY_FEL_HORDE_SPECIALIST));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Black Temple", Constants.UNIT_O02Y_GREAT_HALL_FEL_HORDE_T1));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
      {
        whichFaction.Player.AddGold(800);
        whichFaction.Player.AddLumber(200);
      }
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "Black Temple has been rebuild to it's former glory.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain 800 Gold and 200 Lumber";

   }
 }