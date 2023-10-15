using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestCultoftheDamned : QuestData
  {

    public QuestCultoftheDamned() : base("The Cult of the Damned",
      "To prepare the destruction of the Lordaeron kingdom, a secret cult will be formed.",
      @"ReplaceableTextures\CommandButtons\BTNBaronRivendare.blp")
    {
      AddObjective(new ObjectiveTime(420));
      ResearchId = Constants.UPGRADE_R01H_QUEST_COMPLETED_CULT_OF_THE_DAMNED;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the Cult of the Damned established, the Scourge can plan their invasion of Lordaeron. The powerful Baron Rivendare has also joined the Cult to serve the Lich King.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Gain vision over Lordaeron until you unleash the Plague, the Plague of Undeath research becomes available in the {GetObjectName(Constants.UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN)}, and {GetObjectName(Constants.UNIT_U00A_SCOURGE_COMMANDER_SCOURGE)} becomes trainable at the {GetObjectName(Constants.UNIT_UAOD_ALTAR_OF_DARKNESS)}";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      
    }
  }
}