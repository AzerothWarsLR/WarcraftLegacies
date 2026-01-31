using System;
using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Stores all shared <see cref="QuestData"/>s and distributes them to <see cref="Faction"/>s.
/// </summary>
public static class SharedQuestRepository
{
  private static readonly List<QuestData> _sharedQuests = new();

  private static readonly List<Func<Faction, QuestData>> _sharedQuestFactories = new();

  static SharedQuestRepository()
  {
    FactionManager.FactionRegistered += GiveFactionSharedQuests;
  }

  /// <summary>
  /// Registers the provided quest as shareable to all <see cref="Faction"/>s.
  /// </summary>
  /// <param name="sharedQuest"></param>
  public static void RegisterQuest(QuestData sharedQuest)
  {
    _sharedQuests.Add(sharedQuest);
    foreach (var faction in FactionManager.GetAllFactions())
    {
      faction.AddQuest(sharedQuest);
    }
  }

  /// <summary>
  /// Registers a function that should create a new <see cref="QuestData"/>. All <see cref="Faction"/>s will be given
  /// a quest generated from this function.
  /// </summary>
  public static void RegisterQuestFactory(Func<Faction, QuestData> questFactory)
  {
    _sharedQuestFactories.Add(questFactory);
    foreach (var faction in FactionManager.GetAllFactions())
    {
      faction.AddQuest(questFactory(faction));
    }
  }

  private static void GiveFactionSharedQuests(object? sender, Faction faction)
  {
    foreach (var quest in _sharedQuests)
    {
      faction.AddQuest(quest);
    }

    foreach (var questFactory in _sharedQuestFactories)
    {
      faction.AddQuest(questFactory(faction));
    }
  }
}
