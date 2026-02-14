using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Quests;

public sealed class QuestSharedVision : QuestData
{
  /// <inheritdoc />
  public QuestSharedVision() : base("Battle for Azeroth",
    "Beyond our local conflicts lies a larger war for the fate of Azeroth itself. It will reach us eventually, whether we wish it or not.",
    @"ReplaceableTextures\CommandButtons\BTNFarSight.blp")
  {
    AddObjective(new ObjectiveTurn(14));
    IsFactionQuest = false;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Every player shares vision with their extended allies";

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "A global conflict for control of Azeroth is brewing. The great powers set their sights on distant shores as allies, new and old alike, seek to bolster their own.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => FactionManager.SharedVisionMode = TeamSharedVisionMode.All;
}
