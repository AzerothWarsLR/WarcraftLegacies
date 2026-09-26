using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

/// <summary>
/// Capture the Vault of the Wardens to empower the Wardens, or Maiev if the faction chose Priestesses of the Moon.
/// </summary>
public sealed class QuestVaultoftheWardens : QuestData
{
  private readonly Capital _vaultOfTheWardens;
  private readonly LegendaryHero _maiev;
  private const int MaievXpReward = 2000;

  /// <inheritdoc />
  public QuestVaultoftheWardens(LegendaryHero maiev, Capital vaultOfTheWardens) : base("Vault of the Wardens",
    "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari, but it was abandoned when the Broken Isles were shattered. In troubling times such as these, the Wardens could make great use of such a facility.",
    @"ReplaceableTextures\CommandButtons\BTNReincarnationWarden.blp")
  {
    _vaultOfTheWardens = vaultOfTheWardens;
    _maiev = maiev;
    AddObjective(new ObjectiveChannelRect(Regions.VaultoftheWardens, "Vault of the Wardens", maiev,
      120, 90));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R06H_QUEST_COMPLETED_VAULT_OF_THE_WARDENS_SENTINELS_JAROD;

  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The ancient Vault of the Wardens has been secured. Maiev and her Wardens take up residence within its ancient halls.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Gain the {vault}. Wardens and Maiev gain 100 hit points and 5 attack damage, and their Blink costs no mana and has a 5 second cooldown. If you chose Priestesses of the Moon instead, Maiev gains 2000 experience and 5 Strength, Agility, and Intelligence",
    ("{vault}", GetObjectName(UNIT_N04G_VAULT_OF_THE_WARDENS_SENTINELS)));

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    _vaultOfTheWardens.Unit?.Rescue(completingFaction.Player);
    if (completingFaction.Player == null)
    {
      return;
    }

    if (completingFaction.Player.GetTechResearched(UPGRADE_RV01_PRIESTESSES_OF_THE_MOON_SENTINELS, false) > 0)
    {
      var maiev = _maiev.Unit;
      if (maiev != null)
      {
        maiev.AddHeroAttributes(5, 5, 5);
        AddHeroXP(maiev, MaievXpReward, true);
      }

      return;
    }

    completingFaction.Player.SetTechResearched(UPGRADE_RV03_WARDENS_OF_THE_VAULT_SENTINELS, 1);
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    if (_vaultOfTheWardens.Unit != null)
    {
      _vaultOfTheWardens.Unit.Kill();
    }
  }

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction)
  {
    if (_vaultOfTheWardens.Unit != null)
    {
      _vaultOfTheWardens.Unit.IsInvulnerable = true;
    }
  }
}
