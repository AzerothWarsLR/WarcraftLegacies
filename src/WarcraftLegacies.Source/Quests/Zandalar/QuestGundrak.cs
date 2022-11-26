using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Zandalar
{

  /// <summary>
  /// Capture <see cref="LegendNeutral.Gundrak"/> to unlock a new unit
  /// </summary>
  public sealed class QuestGundrak : QuestData
  {
    private static readonly int GundrakResearch = Constants.UPGRADE_R02Q_QUEST_COMPLETED_THE_DRAKKARI_FORTRESS_WARSONG;
    private static readonly int WarlordId = Constants.UNIT_NFTK_WARLORD_WARSONG;
    private static readonly int TrollShrineId = Constants.UNIT_O04X_LOA_SHRINE_ZANDALAR;


    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGundrak"/> class
    /// </summary>
    public QuestGundrak() : base("The Drakkari Fortress",
      "The Drakkari troll of Gundrak believe their fortress to be impregnable. Capture it to gain their loyalty.",
      "ReplaceableTextures\\CommandButtons\\BTNTerrorTroll.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Gundrak, false));
      
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string CompletionPopup =>
      "Gundrak has fallen. The Drakkari trolls lend their might to the Zandalari.";

    /// <summary>
    /// <inheritdoc/>
    /// </summary
    protected override string RewardDescription =>
      $"300 gold and the ability to train {GetObjectName(WarlordId)}s from the {GetObjectName(TrollShrineId)}.";

    /// <summary>
    /// <inheritdoc/>
    /// </summary
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        SetPlayerTechResearched(completingFaction.Player, GundrakResearch, 1);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
      }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(GundrakResearch, Faction.UNLIMITED);
    }
  }
}