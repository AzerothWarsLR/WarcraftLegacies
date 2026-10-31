using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>The Wildhammer dwarves of Aerie Peak, who carry on after Ironforge is lost.</summary>
public sealed class WildhammerFaction : Faction
{
  private static readonly Dictionary<int, int> _wildhammerEquivalents = new()
  {
    { UNIT_H019_MASON_IRONFORGE_WORKER, UNIT_H0EZ_GROUNDSKEEPER_WILDHAMMER_WORKER },
    { UNIT_H018_WARRIOR_IRONFORGE, UNIT_H0F1_CLANSMAN_WILDHAMMER },
    { UNIT_HRIF_RIFLEMAN_IRONFORGE, UNIT_H0F2_MOUNTAINEER_WILDHAMMER },
    { UNIT_H01L_THANE_IRONFORGE, UNIT_H0F3_SLAYER_WILDHAMMER },
    { UNIT_HMTM_MORTAR_TEAM_IRONFORGE, UNIT_H0F4_SIEGEBREAKER_WILDHAMMER },
    { UNIT_H037_ENGINEER_IRONFORGE_ELITE, UNIT_H0F5_CLOUD_GUARDIAN_WILDHAMMER_ELITE },
    { UNIT_HGRY_GRYPHON_RIDER_IRONFORGE, UNIT_H0FL_GRYPHON_RIDER_WILDHAMMER },
    { UNIT_N00C_RUNE_PRIEST_IRONFORGE, UNIT_H0F8_SHAMAN_OF_THE_WILDS_WILDHAMMER },
    { UNIT_TP05_RUNE_SMITH_IRONFORGE, UNIT_H0F9_ELEMENTALIST_WILDHAMMER },
    { UNIT_H07E_MINING_COLONY_IRONFORGE_T1, UNIT_H0EJ_LONG_HOUSE_WILDHAMMER },
    { UNIT_H07F_DWARF_HOLD_IRONFORGE_T2, UNIT_H0EK_MEAD_HALL_WILDHAMMER },
    { UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, UNIT_H0EL_GREAT_KEEP_WILDHAMMER },
    { UNIT_H01S_TAVERN_IRONFORGE_FARM, UNIT_H0EM_CLAN_HOUSE_WILDHAMMER },
    { UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR, UNIT_H0EN_ALTAR_OF_THE_WILDS_WILDHAMMER },
    { UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, UNIT_H0EO_WARRIORS_LODGE_WILDHAMMER },
    { UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, UNIT_H0EP_WILDHAMMER_FORGE_WILDHAMMER },
    { UNIT_H042_PINNACLE_IRONFORGE_MAGIC, UNIT_H0EQ_MYSTIC_DEN_WILDHAMMER },
    { UNIT_HARM_WORKSHOP_IRONFORGE_SPECIALIST, UNIT_H0ER_WILDHAMMER_WORKSHOP_WILDHAMMER },
    { UNIT_HGRA_GRYPHON_AVIARY_IRONFORGE_AIR, UNIT_H0ES_GRYPHON_AVIARY_WILDHAMMER },
    { UNIT_H07H_SCOUT_TOWER_IRONFORGE_TOWER, UNIT_H0ET_WATCH_TOWER_WILDHAMMER },
    { UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H0EU_GUARD_TOWER_WILDHAMMER },
    { UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H0EV_IMPROVED_GUARD_TOWER_WILDHAMMER },
    { UNIT_H07J_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H0EW_CANNON_TOWER_WILDHAMMER },
    { UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H0EX_IMPROVED_CANNON_TOWER_WILDHAMMER },
    { UNIT_N07U_EXPLORER_S_VAULT_IRONFORGE_SHOP, UNIT_N0Z4_WILDHAMMER_TAVERN_WILDHAMMER }
  };

  private static readonly Dictionary<int, int> _researchEquivalents = new()
  {
    { UPGRADE_R00V_RUNE_PRIEST_ADEPT_TRAINING_IRONFORGE, UPGRADE_R110_SHAMAN_OF_THE_WILDS_ADEPT_TRAINING_WILDHAMMER },
    { UPGRADE_TP42_RUNE_SMITH_ADEPT_TRAINING_IRONFORGE, UPGRADE_R111_ELEMENTALIST_ADEPT_TRAINING_WILDHAMMER },
    { UPGRADE_TP41_POTENT_STORMBREW_IRONFORGE, UPGRADE_R112_POTENT_STORMBREW_WILDHAMMER },
    { UPGRADE_RHRI_LONG_RIFLES_IRONFORGE, UPGRADE_R113_IMPROVED_BOWS_WILDHAMMER },
    { UPGRADE_VP31_MASTERS_OF_LIGHTNING_IRONFORGE, UPGRADE_R114_MASTERS_OF_LIGHTNING_WILDHAMMER },
    { UPGRADE_R02K_GRYPHON_SUPERIOR_BREED_KHAZ_MODAN, UPGRADE_R115_GRYPHON_SUPERIOR_BREED_WILDHAMMER },
    { UPGRADE_RHHB_STORM_HAMMERS_KHAZ_MODAN, UPGRADE_R116_STORM_HAMMERS_WILDHAMMER }
  };

  private static readonly Dictionary<int, int> _sharedResearchEquivalents = new()
  {
    { UPGRADE_VP31_MASTERS_OF_LIGHTNING_IRONFORGE, UPGRADE_R114_MASTERS_OF_LIGHTNING_WILDHAMMER },
    { UPGRADE_R02K_GRYPHON_SUPERIOR_BREED_KHAZ_MODAN, UPGRADE_R115_GRYPHON_SUPERIOR_BREED_WILDHAMMER },
    { UPGRADE_RHHB_STORM_HAMMERS_KHAZ_MODAN, UPGRADE_R116_STORM_HAMMERS_WILDHAMMER }
  };

  /// <summary>Wildhammer units that capitals shared with Ironforge can train.</summary>
  /// <summary>The most Soarers the Wildhammer can have at once.</summary>
  public const int SoarerLimit = 6;

  public static readonly int[] CapitalUnits =
  {
    UNIT_H0EZ_GROUNDSKEEPER_WILDHAMMER_WORKER,
    UNIT_H0F3_SLAYER_WILDHAMMER,
    UNIT_H0F5_CLOUD_GUARDIAN_WILDHAMMER_ELITE
  };

  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE,
    UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE,
    UNIT_H03G_EMPEROR_OF_BLACKROCK_IRONFORGE,
    UNIT_H01P_STEAM_TANK_IRONFORGE,
    UNIT_TP01_FLAME_TANK_IRONFORGE,
    UNIT_TP02_ARTILLERY_TANK_IRONFORGE,
    UNIT_N02D_WAR_GOLEM_IRONFORGE,
    UNIT_N0CZ_DREADNAUGHT_IRONFORGE
  };

  /// <summary>Creates the Wildhammer with whatever <paramref name="ironforge"/> can currently build, train and research.</summary>
  public WildhammerFaction(Faction ironforge)
    : base("Wildhammer", playercolor.Aqua, @"ReplaceableTextures\CommandButtons\BTNHeroGriffonWarrior.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    ControlPointDefenderUnitTypeId = UNIT_H0F0_CONTROL_POINT_DEFENDER_WILDHAMMER;
    CinematicMusic = ironforge.CinematicMusic;
    FoodMaximum = ironforge.FoodMaximum;
    Nicknames = new List<string>
    {
      "wh",
      "wild",
      "wildhammer"
    };

    ProcessObjectInfo(IronforgeObjectInfo.GetAllObjectLimits()
      .Where(x => !_leftBehind.Contains(x.ObjectTypeId))
      .Select(ToWildhammerEquivalent));
    foreach (var (objectId, limit) in ironforge.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId) && !CapitalUnits.Contains(objectId))
      {
        SetObjectLimit(GetWildhammerEquivalent(objectId), limit);
      }
    }

    SetObjectLimit(UNIT_H0CW_SKY_THANE_OF_THE_WILDHAMMER_WILDHAMMER, 1);
    SetObjectLimit(UNIT_H0CX_GRYPHON_MASTER_OF_AERIE_PEAK_WILDHAMMER, 1);
    SetObjectLimit(UNIT_H0F6_GRYPHON_WILDHAMMER, 6);
    SetObjectLimit(UNIT_H0FL_GRYPHON_RIDER_WILDHAMMER, 6);
    SetObjectLimit(UNIT_H0F7_SOARER_WILDHAMMER, SoarerLimit);
    SetObjectLimit(UNIT_H0FA_MESSENGER_WILDHAMMER, 6);
    SetObjectLimit(UNIT_H0FB_RAM_VANGUARD_WILDHAMMER, 4);
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    AddQuest(new QuestReturnToGrimBatol());
    AddQuest(new QuestSonsOfLothar(AllLegends.FelHorde.BlackTemple, AllLegends.Ironforge.Kurdran));
    AddQuest(new QuestTheHammerFalls(AllLegends.Legion.Malganis, AllLegends.Legion.Tichondrius));
    AddQuest(new QuestWrathOfTheThunderaan(AllLegends.Ironforge.Falstad, AllLegends.Ironforge.Kurdran));
    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      AddQuest(new QuestStormOverNorthrend(AllLegends.Scourge.Utgarde, scourge.GetQuestByType<QuestLichKingArthas>()));
    }
  }

  /// <summary>Every Ironforge unit and building the Wildhammer replace with one of their own.</summary>
  public static IReadOnlyDictionary<int, int> UnitEquivalents => _wildhammerEquivalents;

  /// <summary>Every Ironforge research the Wildhammer replace with one of their own.</summary>
  public static IReadOnlyDictionary<int, int> ResearchEquivalents => _researchEquivalents;

  /// <summary>Wildhammer researches that also grant the Ironforge original, because units both factions share check for it.</summary>
  public static IReadOnlyDictionary<int, int> SharedResearchEquivalents => _sharedResearchEquivalents;

  /// <summary>The Wildhammer version of an Ironforge object, or the object itself if they share it.</summary>
  public static int GetWildhammerEquivalent(int objectId)
  {
    if (_wildhammerEquivalents.TryGetValue(objectId, out var equivalent))
    {
      return equivalent;
    }

    if (_researchEquivalents.TryGetValue(objectId, out var research))
    {
      return research;
    }

    return objectId;
  }

  private static ObjectInfo ToWildhammerEquivalent(ObjectInfo objectInfo) =>
    new(GetWildhammerEquivalent(objectInfo.ObjectTypeId), objectInfo.Limit, objectInfo.Categories, objectInfo.LimitIncreaseHint);
}
