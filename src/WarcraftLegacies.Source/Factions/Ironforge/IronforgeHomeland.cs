using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Stormwind;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>What happens to Ironforge's lands when Ironforge leaves them behind for a new faction.</summary>
public static class IronforgeHomeland
{
  private static readonly Dictionary<int, int> _stormwindEquivalents = new()
  {
    { UNIT_H07E_MINING_COLONY_IRONFORGE_T1, UNIT_H06K_TOWN_HALL_STORMWIND_T1 },
    { UNIT_H07F_DWARF_HOLD_IRONFORGE_T2, UNIT_H06M_KEEP_STORMWIND_T2 },
    { UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, UNIT_H06N_CASTLE_STORMWIND_T3 },
    { UNIT_H01S_TAVERN_IRONFORGE_FARM, UNIT_H072_HOMESTEAD_STORMWIND_FARM },
    { UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR, UNIT_H06T_ALTAR_OF_KINGS_STORMWIND_ALTAR },
    { UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, UNIT_H06E_BARRACKS_STORMWIND_BARRACKS },
    { UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, UNIT_H06F_BLACKSMITH_STORMWIND_RESEARCH },
    { UNIT_H042_PINNACLE_IRONFORGE_MAGIC, UNIT_HARS_ARCANE_SANCTUM_STORMWIND_MAGIC },
    { UNIT_HARM_WORKSHOP_IRONFORGE_SPECIALIST, UNIT_H06A_SMITHY_STORMWIND_SPECIALIST },
    { UNIT_H07H_SCOUT_TOWER_IRONFORGE_TOWER, UNIT_H06V_SCOUT_TOWER_STORMWIND_TOWER },
    { UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H06W_GUARD_TOWER_STORMWIND_TOWER },
    { UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND_TOWER },
    { UNIT_H07J_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H06X_CANNON_TOWER_STORMWIND_TOWER },
    { UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H071_IMPROVED_CANNON_TOWER_STORMWIND_TOWER },
    { UNIT_N07U_EXPLORER_S_VAULT_IRONFORGE_SHOP, UNIT_N07T_AUCTION_HOUSE_STORMWIND_SHOP },
    { UNIT_H07D_SHIPYARD_IRONFORGE_SHIPYARD, UNIT_H06D_ROYAL_HARBOUR_STORMWIND_SHIPYARD }
  };

  private static readonly Dictionary<int, int> _kultirasEquivalents = new()
  {
    { UNIT_H07E_MINING_COLONY_IRONFORGE_T1, UNIT_H062_TOWN_HALL_KULTIRAS_T1 },
    { UNIT_H07F_DWARF_HOLD_IRONFORGE_T2, UNIT_H064_KEEP_KULTIRAS_T2 },
    { UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, UNIT_H06I_CASTLE_KULTIRAS_T3 },
    { UNIT_H01S_TAVERN_IRONFORGE_FARM, UNIT_H07N_HOMESTEAD_KULTIRAS_FARM },
    { UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR, UNIT_H07M_ALTAR_OF_ADMIRALS_KULTIRAS_ALTAR },
    { UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, UNIT_H06R_GARRISON_KULTIRAS_BARRACKS },
    { UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, UNIT_H07O_BLACKSMITH_KULTIRAS_RESEARCH },
    { UNIT_H042_PINNACLE_IRONFORGE_MAGIC, UNIT_H07Q_SCHOOL_OF_THE_TIDES_KULTIRAS_MAGIC },
    { UNIT_HARM_WORKSHOP_IRONFORGE_SPECIALIST, UNIT_H07P_WORKSHOP_KULTIRAS_SPECIALIST },
    { UNIT_H07H_SCOUT_TOWER_IRONFORGE_TOWER, UNIT_H07R_SCOUT_TOWER_KULTIRAS_TOWER },
    { UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER },
    { UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H07T_IMPROVED_GUARD_TOWER_KULTIRAS_TOWER },
    { UNIT_H07J_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H07U_CANNON_TOWER_KULTIRAS_TOWER },
    { UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H07V_IMPROVED_CANNON_TOWER_KULTIRAS_TOWER },
    { UNIT_N07U_EXPLORER_S_VAULT_IRONFORGE_SHOP, UNIT_N07H_TRADE_HOUSE_KULTIRAS_SHOP },
    { UNIT_H07D_SHIPYARD_IRONFORGE_SHIPYARD, UNIT_H07W_SHIPYARD_KULTIRAS_SHIPYARD }
  };

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

  /// <summary>Stormwind if it's still in the game, otherwise Kul Tiras, otherwise nobody, with the buildings each turns Ironforge buildings into.</summary>
  public static player GetHeir(out Dictionary<int, int>? equivalents)
  {
    if (FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind) && IsStillInGame(stormwind))
    {
      equivalents = _stormwindEquivalents;
      return stormwind.Player!;
    }

    if (FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras) && IsStillInGame(kultiras))
    {
      equivalents = _kultirasEquivalents;
      return kultiras.Player!;
    }

    equivalents = null;
    return player.NeutralPassive;
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

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;
}
