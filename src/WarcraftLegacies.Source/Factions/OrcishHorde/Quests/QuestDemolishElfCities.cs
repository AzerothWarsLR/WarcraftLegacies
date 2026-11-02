using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Quests;

public sealed class QuestDemolishElfCities : QuestData
{
  private const int GromXpReward = 2000;
  private const int GoldReward = 500;
  private bool _unlocksSaurfang;

  public QuestDemolishElfCities(QuestData previousQuest) : base(
    "Kalimdor Ablaze",
    "The Night Elves' cities stand as the last bastions of resistance against the Horde. Nordrassil itself, the World Tree where the druids first stirred, must fall to the Horde along with the rest.",
    @"ReplaceableTextures\CommandButtons\BTNTreeOfAges.blp")
  {
    AddObjective(new ObjectiveControlCapital(AllLegends.Druids.Nordrassil, false));
    AddObjective(new ObjectiveCapitalDead(AllLegends.Sentinels.Auberdine));
    AddObjective(new ObjectiveQuestResolved(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_R062_QUEST_COMPLETED_KALIMDOR_ABLAZE_ORCISH_HORDE;
  }

  public override string RewardFlavour =>
    "Nordrassil has fallen, and with it the Night Elves' last hope of standing united against the Horde. Grom Hellscream leads the charge, his warband growing richer and more battle-hardened with every city razed.";

  /// <summary>Whether the quest unlocks Varok Saurfang instead of Garrosh Hellscream.</summary>
  public bool UnlocksSaurfang
  {
    get => _unlocksSaurfang;
    set
    {
      _unlocksSaurfang = value;
      RefreshDescription();
    }
  }

  protected override string RewardDescription => UnlocksSaurfang
    ? "Grom Hellscream gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, you gain 500 gold, and you can train Varok Saurfang at the Altar of Storms"
    : "Grom Hellscream gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, you gain 500 gold, and you can train Garrosh Hellscream at the Altar of Storms";

  protected override void OnComplete(Faction completingFaction)
  {
    var grom = AllLegends.Orc.GromHellscream.Unit;
    if (grom != null)
    {
      grom.AddHeroAttributes(5, 5, 5);
      AddHeroXP(grom, GromXpReward, true);
    }

    if (completingFaction.Player == null)
    {
      return;
    }

    completingFaction.Player.Gold += GoldReward;
    if (UnlocksSaurfang)
    {
      completingFaction.Player.DisplayUnitTypeAcquired(UNIT_VSWS_HIGH_OVERLORD_OF_THE_KOR_KRON_WARSONG,
        "You can now train Varok Saurfang at the Altar of Storms.");
    }
    else
    {
      completingFaction.Player.DisplayUnitTypeAcquired(UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_ORCISH_HORDE,
        "You can now train Garrosh Hellscream at the Altar of Storms.");
    }
  }
}
