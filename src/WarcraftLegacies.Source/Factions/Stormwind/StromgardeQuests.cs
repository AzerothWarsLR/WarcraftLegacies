using System.Linq;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Stormwind.Quests;
using WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Stormwind;

/// <summary>Gives Stromgarde its quests when Stormwind becomes it.</summary>
public static class StromgardeQuests
{
  /// <summary>Carries over the Stormwind quests that still matter and adds Stromgarde's own quests.</summary>
  public static void Setup(Faction stormwind, StromgardeFaction stromgarde)
  {
    var stormwindQuests = stormwind.GetAllQuests().ToList();
    var honorHold = stormwindQuests.OfType<QuestHonorHold>().FirstOrDefault();
    if (honorHold != null && IsOpen(honorHold))
    {
      Show(stromgarde, stromgarde.AddQuest(new QuestStromgardeHonorHold(honorHold, AllLegends.FelHorde.HellfireCitadel,
        AllLegends.Stormwind.Danath)));
    }

    var sunwellVial = stormwindQuests.OfType<QuestExtractSunwellVial>().FirstOrDefault();
    if (sunwellVial != null && IsOpen(sunwellVial))
    {
      Show(stromgarde, stromgarde.AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial)));
    }

    RetireOpenQuests(stormwindQuests);

    Show(stromgarde, stromgarde.AddQuest(new QuestStromgardeKingdomOfMan(Artifacts.CrownOfLordaeron, Artifacts.CrownOfStormwind,
      AllLegends.Stormwind.Thoras)));
    Show(stromgarde, stromgarde.AddQuest(new QuestBulwarkOfArathor()));
    Show(stromgarde, stromgarde.AddQuest(new QuestMastersOfTheSpan()));

    Show(stromgarde, stromgarde.AddQuest(new QuestTrollbaneLegacy(AllLegends.Stormwind.Thoras, AllLegends.Stormwind.Danath,
      AllLegends.Stormwind.Galen)));
  }

  private static void RetireOpenQuests(System.Collections.Generic.List<QuestData> stormwindQuests)
  {
    foreach (var quest in stormwindQuests)
    {
      if (!IsOpen(quest) || !IsStormwindOnly(quest))
      {
        continue;
      }

      quest.SuppressFailureDisplay = true;
      quest.Progress = QuestProgress.Failed;
    }
  }

  private static bool IsStormwindOnly(QuestData quest) =>
    quest is QuestExtractSunwellVial || quest is QuestKingdomOfManStormwind;

  private static bool IsOpen(QuestData quest) =>
    quest.Progress == QuestProgress.Incomplete || quest.Progress == QuestProgress.Undiscovered;

  private static void Show(Faction stromgarde, QuestData quest)
  {
    if (quest.Progress == QuestProgress.Incomplete)
    {
      stromgarde.DisplayDiscovered(quest, false);
    }
  }
}
