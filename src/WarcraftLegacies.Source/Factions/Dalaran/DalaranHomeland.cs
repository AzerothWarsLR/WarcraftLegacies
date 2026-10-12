using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
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
  private static readonly Dictionary<int, int> _lordaeronEquivalents = new()
  {
    { UNIT_H065_REFUGE_DALARAN_T1, UNIT_HTOW_TOWN_HALL_LORDAERON_T1 },
    { UNIT_H066_CONCLAVE_DALARAN_T2, UNIT_HKEE_KEEP_LORDAERON_T2 },
    { UNIT_H068_OBSERVATORY_DALARAN_T3, UNIT_HCAS_CASTLE_LORDAERON_T3 },
    { UNIT_H063_ARCANE_WELL_DALARAN_FARM, UNIT_HHOU_FARM_LORDAERON_FARM },
    { UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR, UNIT_HALT_ALTAR_OF_KINGS_LORDAERON_ALTAR },
    { UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, UNIT_HBAR_BARRACKS_LORDAERON_BARRACKS },
    { UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH, UNIT_HBLA_BLACKSMITH_LORDAERON_RESEARCH },
    { UNIT_H036_ARCANE_SANCTUARY_DALARAN_MAGIC, UNIT_H035_ARCANE_STUDY_LORDAERON_MAGIC },
    { UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP, UNIT_NMRK_MARKETPLACE_LORDAERON_SHOP },
    { UNIT_H076_SHIPYARD_DALARAN_SHIPYARD, UNIT_HSHY_SHIPYARD_LORDAERON_SHIPYARD },
    { UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, UNIT_H094_SIEGE_WORKSHOP_LORDAERON_SIEGE },
    { UNIT_H078_SCOUT_TOWER_DALARAN_TOWER, UNIT_HWTW_SCOUT_TOWER_LORDAERON_TOWER },
    { UNIT_H079_ARCANE_TOWER_DALARAN_TOWER, UNIT_HGTW_GUARD_TOWER_LORDAERON_TOWER },
    { UNIT_H07A_IMPROVED_ARCANE_TOWER_DALARAN_TOWER, UNIT_H006_IMPROVED_GUARD_TOWER_LORDAERON_TOWER },
    { UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER, UNIT_HCTW_CANNON_TOWER_LORDAERON_TOWER },
    { UNIT_N004_IMPROVED_KIRIN_TOR_TOWER_DALARAN_TOWER, UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER }
  };

  private static readonly Dictionary<int, int> _quelthalasEquivalents = new()
  {
    { UNIT_H065_REFUGE_DALARAN_T1, UNIT_H033_STEADING_QUELTHALAS_T1 },
    { UNIT_H066_CONCLAVE_DALARAN_T2, UNIT_H03S_MANSION_QUELTHALAS_T2 },
    { UNIT_H068_OBSERVATORY_DALARAN_T3, UNIT_H03T_PALACE_QUELTHALAS_T3 },
    { UNIT_H063_ARCANE_WELL_DALARAN_FARM, UNIT_NEFM_RESIDENCE_QUELTHALAS },
    { UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR, UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR },
    { UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, UNIT_NHEB_CANTONMENT_QUELTHALAS_BARRACKS },
    { UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH, UNIT_H02Y_ARTISAN_S_HALL_QUELTHALAS_RESEARCH },
    { UNIT_H036_ARCANE_SANCTUARY_DALARAN_MAGIC, UNIT_H034_ARCANE_SANCTUM_QUELTHALAS_MAGIC },
    { UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP, UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP },
    { UNIT_H076_SHIPYARD_DALARAN_SHIPYARD, UNIT_H077_SHIPYARD_QUELTHALAS_SHIPYARD },
    { UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST },
    { UNIT_H078_SCOUT_TOWER_DALARAN_TOWER, UNIT_H073_SCOUT_TOWER_QUELTHALAS_TOWER },
    { UNIT_H079_ARCANE_TOWER_DALARAN_TOWER, UNIT_H074_ARCANE_TOWER_QUELTHALAS_TOWER },
    { UNIT_H07A_IMPROVED_ARCANE_TOWER_DALARAN_TOWER, UNIT_H075_IMPROVED_ARCANE_TOWER_QUELTHALAS_TOWER },
    { UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER, UNIT_NEGT_SUN_TOWER },
    { UNIT_N004_IMPROVED_KIRIN_TOR_TOWER_DALARAN_TOWER, UNIT_N003_IMPROVED_SUN_TOWER_QUELTHALAS_TOWER }
  };

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
    if (sharedQuest == null || sharedQuest.Progress == QuestProgress.Complete || sharedQuest.Progress == QuestProgress.Failed)
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
      equivalents = _lordaeronEquivalents;
      return lordaeron.Player!;
    }

    if (FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas) && IsStillInGame(quelthalas))
    {
      equivalents = _quelthalasEquivalents;
      return quelthalas.Player!;
    }

    equivalents = null;
    return player.NeutralPassive;
  }

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;
}
