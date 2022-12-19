using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static MacroTools.Libraries.GeneralHelpers;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Capture the Vault of the Wardens to learn to train Wardens.
  /// </summary>
  public sealed class QuestVaultoftheWardens : QuestData
  {
    private const int WardenId = Constants.UNIT_H045_WARDEN_SENTINELS;

    /// <inheritdoc />
    public QuestVaultoftheWardens() : base("Vault of the Wardens",
      "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari, but it was abandoned when the Broken Isles were shattered. In troubling times such as these, the Wardens could make great use of such a facility.",
      "ReplaceableTextures\\CommandButtons\\BTNReincarnationWarden.blp")
    {
      AddObjective(new ObjectiveChannelRect(Regions.VaultoftheWardens, "Vault of the Wardens", LegendSentinels.Maiev,
        120, 90));
      ResearchId = Constants.UPGRADE_R06H_QUEST_COMPLETED_VAULT_OF_THE_WARDENS_SENTINELS_JAROD;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The ancient Vault of the Wardens has been secured. Maiev and her Wardens take up residence within its ancient halls.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "4 free Wardens appear at the Broken Isles, and you learn to train Wardens";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      CreateUnits(completingFaction.Player, WardenId, Regions.VaultoftheWardens.Center.X,
        Regions.VaultoftheWardens.Center.Y, 270, 4);
      completingFaction.Player.DisplayUnitTypeAcquired(WardenId,
        "You can now train Wardens from the Vault of the Wardens, Sentinel Enclaves, and your capitals.");
      LegendSentinels.VaultOfTheWardens?.Unit?.Rescue(completingFaction.Player);
    }

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      LegendSentinels.VaultOfTheWardens?.Unit?.Kill();
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(WardenId, 8);
      LegendSentinels.VaultOfTheWardens?.Unit?.SetInvulnerable(true);
    }
  }
}