using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Dalaran.Quests;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>What happens to Dalaran's lands when Dalaran leaves them behind for a new faction.</summary>
public static class DalaranHomeland
{
  private static readonly Dictionary<int, int> _landmarks = new()
  {
    { UNIT_H00I_WINDMILL_LORDAERON_OTHER, UnitEquivalents.Keep },
    { UNIT_H05P_DALARAN_BUILDING_DALARAN_OTHER_1, UnitEquivalents.Keep },
    { UNIT_H05Q_DALARAN_BUILDING_DALARAN_OTHER_2, UnitEquivalents.Keep },
    { UNIT_H05O_DALARAN_BUILDING_DALARAN_OTHER_3, UnitEquivalents.Keep },
    { UNIT_N03G_VIOLET_TOWER_DALARAN, UnitEquivalents.Keep }
  };

  private static Dictionary<int, int> LordaeronEquivalents => UnitEquivalents.Pair(
    DalaranObjectInfo.GetAllObjectLimits(), LordaeronObjectInfo.GetAllObjectLimits(), _landmarks);

  private static Dictionary<int, int> QuelthalasEquivalents => UnitEquivalents.Pair(
    DalaranObjectInfo.GetAllObjectLimits(), QuelthalasObjectInfo.GetAllObjectLimits(), _landmarks);

  /// <summary>
  /// Makes <paramref name="heir"/> the new keeper of the Book of Medivh, able to take it from its pedestal without
  /// destroying the Violet Citadel, unless the book has already been taken.
  /// </summary>
  public static void MakeBookKeeper(player heir)
  {
    var heirFaction = heir.GetPlayerData().Faction;
    if (heirFaction == null)
    {
      return;
    }

    var sharedQuest = heirFaction.GetAllQuests().OfType<QuestBookOfMedivh>().FirstOrDefault();
    if (sharedQuest == null || sharedQuest.IsForKeeper || sharedQuest.Progress == QuestProgress.Complete ||
        sharedQuest.Progress == QuestProgress.Failed)
    {
      return;
    }

    heirFaction.RemoveQuest(sharedQuest);
    heirFaction.AddQuest(new QuestBookOfMedivh(AllLegends.Dalaran.Dalaran,
      new NamedRectangle("Dalaran", Regions.BookOfMedivhDalaran), Artifacts.BookOfMedivh, false, true));
  }

  /// <summary>Ends Dalaran's unfinished land quests so the units they hold come to Dalaran's player instead of going hostile.</summary>
  public static void ClaimHeldLands(Faction dalaran)
  {
    foreach (var quest in dalaran.GetAllQuests())
    {
      quest.SuppressFailureDisplay = true;
    }

    EndQuest(dalaran.GetQuestByType<QuestShadowfang>());
    EndQuest(dalaran.GetQuestByType<QuestSouthshore>());
    EndQuest(dalaran.GetQuestByType<QuestDalaran>());
  }

  private static void EndQuest(QuestData quest)
  {
    if (quest.Progress != QuestProgress.Complete && quest.Progress != QuestProgress.Failed)
    {
      quest.Progress = QuestProgress.Failed;
    }
  }

  /// <summary>Lordaeron if it's still in the game, otherwise Quel'thalas, otherwise nobody, with the buildings each turns Dalaran buildings into.</summary>
  public static player GetHeir(out Dictionary<int, int>? equivalents)
  {
    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) && IsStillInGame(lordaeron))
    {
      equivalents = LordaeronEquivalents;
      return lordaeron.Player!;
    }

    if (FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas) && IsStillInGame(quelthalas))
    {
      equivalents = QuelthalasEquivalents;
      return quelthalas.Player!;
    }

    equivalents = null;
    return player.NeutralPassive;
  }

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;
}
