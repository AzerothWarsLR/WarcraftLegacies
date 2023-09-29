using MacroTools.QuestSystem;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Bring any hero to the Echo Isles to unlock the base.
  /// </summary>
  public sealed class QuestRagetotem : QuestData
  {
    private readonly LegendaryHero _cairne;

    /// <inheritdoc />
    public QuestRagetotem(LegendaryHero cairne) : base("Ragetotem Tribe Challenge",
      "Reknown for their warriors, the Ragetotem Tribe has issued a challenge to Cairne. If he was to overcome it, they would join the Bloodhoof.",
      @"ReplaceableTextures/CommandButtons/BTNPigHead.blp")
    {
      _cairne = cairne;
      AddObjective(new ObjectiveLegendLevel(cairne, 8));
      ResearchId = Constants.UPGRADE_R0AB_QUEST_COMPLETED_RAGETOTEM_TRIBE_CHALLENGE;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Impressed by Cairne's prowess, the Ragetotem tribe has joined the Bloodhoof!";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(Constants.UNIT_O06T_TAUREN_GLADIATOR_FROSTWOLF)}s from the {GetObjectName(Constants.UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF_SPECIALIST)}";

  }
}