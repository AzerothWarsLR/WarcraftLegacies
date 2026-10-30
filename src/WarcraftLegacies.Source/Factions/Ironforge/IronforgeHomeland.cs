using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Stormwind;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>What happens to Ironforge's lands when Ironforge leaves them behind for a new faction.</summary>
public static class IronforgeHomeland
{
  private static Dictionary<int, int> StormwindEquivalents => UnitEquivalents.Pair(
    IronforgeObjectInfo.GetAllObjectLimits(), StormwindObjectInfo.GetAllObjectLimits());

  private static Dictionary<int, int> KultirasEquivalents => UnitEquivalents.Pair(
    IronforgeObjectInfo.GetAllObjectLimits(), KultirasObjectInfo.GetAllObjectLimits());

  /// <summary>
  /// Completes <paramref name="keptQuest"/> so its lands come to Ironforge's player, and ends Ironforge's other
  /// unfinished land quests so the units they hold come to it instead of going hostile.
  /// </summary>
  public static void ClaimHeldLands(Faction ironforge, QuestData keptQuest)
  {
    foreach (var quest in ironforge.GetAllQuests())
    {
      quest.SuppressFailureDisplay = true;
    }

    if (IsUnfinished(keptQuest))
    {
      keptQuest.Progress = QuestProgress.Complete;
    }

    EndQuest(ironforge.GetQuestByType<QuestThelsamar>());
    EndQuest(ironforge.GetQuestByType<QuestDunMorogh>());
    EndQuest(ironforge.GetQuestByType<QuestDominion>());
    EndQuest(ironforge.GetQuestByType<QuestGnomeregan>());
    EndQuest(ironforge.GetQuestByType<QuestDarkIron>());
    EndQuest(ironforge.GetQuestByType<QuestWildhammer>());
  }

  /// <summary>
  /// Stormwind, otherwise Kul Tiras, whichever is still in the game on <paramref name="ironforgePlayer"/>'s side,
  /// otherwise the creeps, with the buildings each turns Ironforge buildings into.
  /// </summary>
  public static player GetHeir(player ironforgePlayer, out Dictionary<int, int>? equivalents)
  {
    if (FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind) && IsHeir(stormwind, ironforgePlayer))
    {
      equivalents = StormwindEquivalents;
      return stormwind.Player!;
    }

    if (FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras) && IsHeir(kultiras, ironforgePlayer))
    {
      equivalents = KultirasEquivalents;
      return kultiras.Player!;
    }

    equivalents = null;
    return player.NeutralAggressive;
  }

  private static void EndQuest(QuestData quest)
  {
    if (IsUnfinished(quest))
    {
      quest.Progress = QuestProgress.Failed;
    }
  }

  private static bool IsUnfinished(QuestData quest) =>
    quest.Progress != QuestProgress.Complete && quest.Progress != QuestProgress.Failed;

  private static bool IsHeir(Faction faction, player ironforgePlayer) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated &&
    TeamChanges.AreTeammates(faction.Player, ironforgePlayer);
}
