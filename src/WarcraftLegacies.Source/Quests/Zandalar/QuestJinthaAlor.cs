using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Zandalar;

/// <summary>
/// Capture <see cref="LegendNeutral.Jinthaalor"/> to unlock a new unit
/// </summary>
public sealed class QuestJinthaAlor : QuestData
{
  private const int JinthaalorResearch = UPGRADE_R02N_QUEST_COMPLETED_THE_ANCIENT_EGG_WARSONG;
  private const int BearRiderId = UNIT_O02K_NALORAKK_S_RIDER_ZANDALAR;
  private const int TrollShrineId = UNIT_O04X_LOA_SHRINE_ZANDALARI_SIEGE;
  private readonly int _goldReward = 50;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestJinthaAlor"/> class
  /// </summary>
  public QuestJinthaAlor(AllLegendSetup legendSetup) : base("The Ancient Egg",
    "The Vilebranch trolls of Jintha'Alor are controlled by their fear of the Soulflayer's egg, hidden within their shrine. Smash it to gain their loyalty.",
    @"ReplaceableTextures\CommandButtons\BTNForestTrollShadowPriest.blp")
  {
    AddObjective(new ObjectiveControlCapital(legendSetup.Neutral.Jinthaalor, false));
    AddObjective(new ObjectiveTime(900));
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Jintha'Alor has fallen. The Vilebranch trolls lend their might to the Zandalari";

  /// <inheritdoc/>>
  protected override string RewardDescription =>
    $"Control of Jintha'Alor, {_goldReward} gold tribute and the ability to train {GetObjectName(BearRiderId)}s from the {GetObjectName(TrollShrineId)}";
  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player != null)
    {
      SetPlayerTechResearched(completingFaction.Player, JinthaalorResearch, 1);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, _goldReward);
    }
  }
  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(JinthaalorResearch, Faction.Unlimited);
  }
}
