using System;
using System.Linq;
using MacroTools.Artifacts;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.Stormwind.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>Gives the Mag'har their quests when the Fel Horde becomes them.</summary>
public static class MagharQuests
{
  /// <summary>Carries over the Fel Horde quests that still matter and adds the Mag'har's own quests.</summary>
  public static void Setup(Faction felHorde, MagharFaction maghar, LegendaryHero garrosh)
  {
    var felQuests = felHorde.GetAllQuests().ToList();
    var oldBlackrock = felQuests.OfType<QuestBlackrock>().FirstOrDefault();
    var oldPortal = felQuests.OfType<QuestDarkPortal>().FirstOrDefault();
    var oldDarkHorde = felQuests.OfType<QuestDarkHorde>().FirstOrDefault();
    var oldSunwellVial = felQuests.OfType<QuestExtractSunwellVial>().FirstOrDefault();

    var blackrock = oldBlackrock;
    if (oldBlackrock != null && IsOpen(oldBlackrock))
    {
      oldBlackrock.HandedOver = true;
      blackrock = new QuestBlackrock(Regions.BlackrockUnlock, Regions.DarkPortalUnlock, Array.Empty<QuestData>(),
        UNIT_O20T_GARADAR_MAGHAR, true)
      {
        OutpostWaitsForDarkPortal = oldBlackrock.OutpostWaitsForDarkPortal
      };
      Show(maghar, maghar.AddQuest(blackrock));
    }

    if (oldPortal != null && IsOpen(oldPortal))
    {
      Show(maghar, maghar.AddQuest(oldPortal.ResearchedAt(UNIT_O20T_GARADAR_MAGHAR, blackrock)));
    }

    if (oldDarkHorde != null && IsOpen(oldDarkHorde))
    {
      Show(maghar, maghar.AddQuest(new QuestDarkHorde(AllLegends.Stormwind.StormwindKeep, AllLegends.FelHorde.BlackrockSpire,
        AllLegends.FelHorde.Rend)
      { ForMaghar = true }));
    }

    if (oldSunwellVial != null && IsOpen(oldSunwellVial))
    {
      Show(maghar, maghar.AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial)));
    }

    RetireOpenQuests(felQuests);
    AddNewQuests(maghar, garrosh);
  }

  private static void AddNewQuests(MagharFaction maghar, LegendaryHero garrosh)
  {
    Show(maghar, maghar.AddQuest(new QuestRestoreHellfire(garrosh)));
    Show(maghar, maghar.AddQuest(new QuestTheGreatForge(AllLegends.Ironforge.GreatForge)));
    Show(maghar, maghar.AddQuest(new QuestMagharGuldansLegacy()));
    Show(maghar, maghar.AddQuest(new QuestThroneOfTheElements()));

    var gorehowl = ArtifactManager.GetFromTypeId(ITEM_I01V_GOREHOWL) ??
                   AllLegends.Orc.GromHellscream.StartingArtifacts.FirstOrDefault(x => x.Item.TypeId == ITEM_I01V_GOREHOWL);
    if (gorehowl != null)
    {
      Show(maghar, maghar.AddQuest(new QuestGorehowl(garrosh, gorehowl)));
    }

    if (FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind))
    {
      var stormwindHonorHold = stormwind.GetAllQuests().OfType<QuestHonorHold>().FirstOrDefault();
      if (stormwindHonorHold != null)
      {
        maghar.AddQuest(new QuestMagharHonorHold(stormwindHonorHold, stormwind,
          AllPreplacedWidgets.Units.Get(UNIT_H05Z_HONOR_HOLD_STORMWIND_OTHER)));
      }
    }
  }

  private static void RetireOpenQuests(System.Collections.Generic.List<QuestData> felQuests)
  {
    foreach (var quest in felQuests)
    {
      if (!IsOpen(quest) || !IsFelHordeOnly(quest))
      {
        continue;
      }

      quest.SuppressFailureDisplay = true;
      quest.Progress = QuestProgress.Failed;
    }
  }

  private static bool IsFelHordeOnly(QuestData quest) =>
    quest is QuestBlackrock || quest is QuestDarkPortal || quest is QuestDarkHorde || quest is QuestExtractSunwellVial ||
    quest is QuestFelHordeKillIronforge || quest is QuestFelHordeKillStormwind || quest is QuestGuldansLegacy ||
    quest is QuestRuinsofShadowmoon;

  private static bool IsOpen(QuestData quest) =>
    quest.Progress == QuestProgress.Incomplete || quest.Progress == QuestProgress.Undiscovered;

  private static void Show(MagharFaction maghar, QuestData quest)
  {
    if (quest.Progress == QuestProgress.Incomplete)
    {
      maghar.DisplayDiscovered(quest, false);
    }
  }
}
