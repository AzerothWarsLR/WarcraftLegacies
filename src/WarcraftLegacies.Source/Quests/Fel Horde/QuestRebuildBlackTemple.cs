using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  /// <summary>
  /// Construct various buildings near the Black Temple to gain resources
  /// </summary>
  public class QuestRebuildBlackTemple : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildBlackTemple"/> class.
    /// </summary>
    public QuestRebuildBlackTemple(Rectangle questRect) : base("Ash and Smoke", "Rebuild Black Temple for the glory of the Illidari", "ReplaceableTextures\\CommandButtons\\BTNFelOrcAltarOfStorms.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "near the Black Temple", Constants.UNIT_O034_WATCH_TOWER_FEL_HORDE_TOWER, 4));
      AddObjective(new ObjectiveBuildInRect(questRect, "near the Black Temple", Constants.UNIT_O02W_BARRACKS_FEL_HORDE_BARRACKS));
      AddObjective(new ObjectiveBuildInRect(questRect, "near the Black Temple", Constants.UNIT_O02X_BEASTIARY_FEL_HORDE_SPECIALIST));
      AddObjective(new ObjectiveBuildInRect(questRect, "near the Black Temple", Constants.UNIT_O02Y_GREAT_HALL_FEL_HORDE_T1));
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
    protected override string CompletionPopup => "Black Temple has been rebuilt to its former glory.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain 800 Gold and 200 Lumber";

   }
 }