using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Zandalar
{
  /// <summary>
  /// Capture <see cref="LegendNeutral.Jinthaalor"/> to unlock a new unit
  /// </summary>
  public sealed class QuestJinthaAlor : QuestData
  {
    private static readonly int JinthaalorResearch = Constants.UPGRADE_R02N_QUEST_COMPLETED_THE_ANCIENT_EGG_WARSONG;
    private static readonly int BearRiderId = Constants.UNIT_O02K_BEAR_RIDER_WARSONG;
    private static readonly int TrollShrineId = Constants.UNIT_O04X_LOA_SHRINE_ZANDALAR;

    /// <summary>
    /// 
    /// </summary>
    public QuestJinthaAlor() : base("The Ancient Egg",
      "The Vilebranch trolls of Jintha'Alor are controlled by their fear of the Soulflayer's egg, hidden within their shrine. Smash it to gain their loyalty.",
      "ReplaceableTextures\\CommandButtons\\BTNForestTrollShadowPriest.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Jinthaalor, false));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string CompletionPopup =>
      "Jintha'Alor has fallen. The Vilebranch trolls lend their might to the Zandalari";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string RewardDescription =>
      "Control of Jintha'Alor, 300 gold tribute and the ability to train " + GetObjectName(BearRiderId) +
      "s from the " + GetObjectName(TrollShrineId);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        SetPlayerTechResearched(completingFaction.Player, JinthaalorResearch, 1);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(JinthaalorResearch, Faction.UNLIMITED);
    }
  }
}