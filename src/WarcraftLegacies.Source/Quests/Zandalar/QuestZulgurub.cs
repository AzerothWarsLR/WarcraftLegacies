using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.Zandalar
{
  /// <summary>
  /// Capture <see cref="LegendNeutral.Zulgurub"/> to unlock a new unit
  /// </summary>
  public sealed class QuestZulgurub : QuestData
  {
    private static readonly int ZulgurubResearch = Constants.UPGRADE_R02M_QUEST_COMPLETED_THE_HEART_OF_HAKKAR_WARSONG;
    private static readonly int TrollShrineId = Constants.UNIT_O04X_LOA_SHRINE_ZANDALAR;
    private static readonly int RavagerId = Constants.UNIT_O021_RAVAGER_WARSONG;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZulgurub"/> class
    /// </summary>
    public QuestZulgurub() : base("Heart of Hakkar",
      "The Gurubashi trolls of Zul'Gurub follow the sacred Heart of Hakkar, hidden within their shrine. Capture it to gain their loyalty.",
      "ReplaceableTextures\\CommandButtons\\BTNTrollRavager.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Zulgurub, false));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string CompletionPopup => "Zul'gurub has fallen. The Gurubashi trolls lend their might to the Zandalari.";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string RewardDescription => "300 gold and the ability to train " + GetObjectName(RavagerId) + "s from the " + GetObjectName(TrollShrineId);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnComplete(Faction completingFaction)
    {
      if(completingFaction.Player != null)
      {
        SetPlayerTechResearched(completingFaction.Player, ZulgurubResearch, 1);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ZulgurubResearch, Faction.UNLIMITED);
    }
  }
}