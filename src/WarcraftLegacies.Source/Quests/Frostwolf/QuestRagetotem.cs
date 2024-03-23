using MacroTools.QuestSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Level up cairne to unlock the Ragetribe
  /// </summary>
  public sealed class QuestRagetotem : QuestData
  {
    private readonly LegendaryHero _cairne;

    /// <inheritdoc />
    public QuestRagetotem(LegendaryHero cairne) : base("Ragetotem Tribe",
      "The Ragetotem Tribe are renowned for their martial prowess. An older, mightier Cairne might convince them to join the Bloodhoof.",
      @"ReplaceableTextures\CommandButtons\BTNGreatTaurenThieftain.blp")
    {
      _cairne = cairne;
      AddObjective(new ObjectiveLegendLevel(cairne, 8));
      ResearchId = UPGRADE_R0AB_QUEST_COMPLETED_RAGETOTEM_TRIBE;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "Tales of Cairne's strength and wisdom reverberate throughout Kalimdor. As strength is drawn to strength, the Ragetotem are drawn to the Bloodhoof.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(UNIT_O06T_TAUREN_GLADIATOR_FROSTWOLF)}s from the {GetObjectName(UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF_SIEGE)}";

  }
}