using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestCultoftheDamned : QuestData
  {

    public QuestCultoftheDamned() : base("The Cult of the Damned",
      "The Kingdom of Lordaeron must be eliminated to pave the way for the Legion's arrival.",
      @"ReplaceableTextures\CommandButtons\BTNBaronRivendare.blp")
    {
      AddObjective(new ObjectiveTime(460));
      ResearchId = Constants.UPGRADE_R01H_QUEST_COMPLETED_CULT_OF_THE_DAMNED;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the Cult of the Damned established, the Scourge can plan their invasion of Lordaeron. The powerful Baron Rivendare has also joined the Cult to serve the Lich King.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Complete vision of Lordaeron until the plague, the plague of undeath research is available and Baron Rivendare is trainable at the altar of darkness";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      
    }
  }
}