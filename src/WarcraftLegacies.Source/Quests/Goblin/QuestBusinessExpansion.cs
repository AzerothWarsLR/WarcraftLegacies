using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  /// <summary>
  /// The Goblins can acquire Kezan.
  /// </summary>
  public sealed class QuestBusinessExpansion : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBusinessExpansion"/>.
    /// </summary>
    public QuestBusinessExpansion() : base("Business Expansion",
      "Trade Prince Gallywix will need a great amount of wealth to join the Goblin Empire; he needs to expand his business all over the world quickly.",
      @"ReplaceableTextures\CommandButtons\BTNGoblinPrince.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N05C_GADGETZAN, 4));
      AddObjective(new ObjectiveControlLevel(UNIT_N0A6_RATCHET, 4));
      AddObjective(new ObjectiveControlLevel(UNIT_N09D_AUBERDINE, 4));
      AddObjective(new ObjectiveControlLevel(UNIT_N05U_FEATHERMOON, 4));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_R07G_QUEST_COMPLETED_BUSINESS_EXPANSION;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "Our trade empire has grown large enough to earn the attention of the Trade Princes of Kezan. Their investments are already flowing in and we can deploy traders all over the world.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(UNIT_O04S_TRADER_GOBLIN)}s and {GetObjectName(UNIT_NZEP_TRADING_ZEPPELIN_WARSONG)}s from the {GetObjectName(UNIT_O04M_KEZAN_TRADING_CENTER_GOBLIN_SPECIAL)}";
  }
}