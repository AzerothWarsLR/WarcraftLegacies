﻿using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  /// <summary>
  /// Warsong kills the Druids and Grom is finally happy.
  /// </summary>
  public sealed class QuestWarsongKillCthun : QuestData
  {
    private const int GoldReward = 1000;

    /// <inheritdoc/>
    public override string RewardFlavour => "With C'Thun defeated, the Old God's dark influence dissipates, strengthening Grom Hellscream and rallying the Warsong Clan for future battles.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Gain {GoldReward} 1000 gold and you can now train Foreman Glibbs from the {GetObjectName(UNIT_O020_ALTAR_OF_CONQUERORS_WARSONG_ALTAR)}";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWarsongKillCthun"/> class.
    /// </summary>
    public QuestWarsongKillCthun(Legend cthun) : base("Whispers of the Old One",
      "The ancient Old God C'Thun stirs beneath Kalimdor, corrupting the world above. Strike down this colossus to safeguard the Horde's future.",
      @"ReplaceableTextures\CommandButtons\BTNSilithidColossus.blp")
    {
      AddObjective(new ObjectiveKillUnit(cthun.Unit));
      ResearchId = UPGRADE_R08M_QUEST_COMPLETED_WHISPERS_OF_THE_OLD_ONE;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction) => whichFaction.Player?.AddGold(GoldReward);
    
  }
}