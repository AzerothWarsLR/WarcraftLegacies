using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Turns Ironforge into the Dark Iron, holding Shadowforge City and Grim Batol and leaving Khaz Modan to the Alliance.</summary>
public sealed class DarkIronTransformation
{
  private const float GrimBatolGroundsRadius = 2500;

  private static readonly Rectangle _shadowforge = new(11264, -10112, 13312, -8320);

  private static readonly HashSet<int> _grimBatolBuildings = new()
  {
    UNIT_H01Z_GRIM_BATOL_CREEP_TWILIGHT,
    UNIT_O067_DUNGEON_CREEP_BARRACKS,
    UNIT_O068_QUARRY_CREEP_RESEARCH,
    UNIT_O069_DARK_CONCLAVE_CREEP_MAGIC
  };

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

  /// <summary>Turns <paramref name="ironforge"/>'s player into the Dark Iron.</summary>
  public void Execute(Faction ironforge)
  {
    var whichPlayer = ironforge.Player;
    if (whichPlayer == null)
    {
      return;
    }

    ClaimHeldLands(ironforge);
    var darkIron = new DarkIronFaction(ironforge);
    FactionTransition.AssignNewFaction(ironforge, darkIron);
    PathBase.RemoveHero(AllLegends.Ironforge.Magni);
    PathBase.RemoveHero(AllLegends.Ironforge.Muradin);
    PathBase.RemoveHero(AllLegends.Ironforge.Falstad);

    var heir = GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, _shadowforge, Regions.Grim_Batol);
    ClaimGrimBatol(whichPlayer);
    PathBase.ConvertStructures(whichPlayer, DarkIronFaction.UnitEquivalents, _shadowforge);
    PathBase.ConvertStructures(whichPlayer, DarkIronFaction.UnitEquivalents, Regions.Grim_Batol);

    var shadowforgeCity = new Point(11648, -9232);
    PathBase.RelocateArmy(whichPlayer, DarkIronFaction.UnitEquivalents, shadowforgeCity.X + 600, shadowforgeCity.Y - 600);
    PathBase.SummonLegend(AllLegends.Ironforge.Dagran, whichPlayer, new Point(shadowforgeCity.X + 400, shadowforgeCity.Y - 400));
  }

  /// <summary>
  /// Gives Ironforge's player the Shadowforge base it would win by allying with the Dark Iron, and ends its other
  /// unfinished land quests so the units they hold come to it instead of going hostile.
  /// </summary>
  private static void ClaimHeldLands(Faction ironforge)
  {
    var questDarkIron = ironforge.GetQuestByType<QuestDarkIron>();
    if (IsUnfinished(questDarkIron))
    {
      questDarkIron.Progress = QuestProgress.Complete;
    }

    EndQuest(ironforge.GetQuestByType<QuestThelsamar>());
    EndQuest(ironforge.GetQuestByType<QuestDunMorogh>());
    EndQuest(ironforge.GetQuestByType<QuestDominion>());
    EndQuest(ironforge.GetQuestByType<QuestGnomeregan>());
    EndQuest(ironforge.GetQuestByType<QuestWildhammer>());
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

  /// <summary>Takes Grim Batol and the buildings around it from whichever creeps hold them, unless a faction already does.</summary>
  private static void ClaimGrimBatol(player whichPlayer)
  {
    var grimBatol = AllLegends.Neutral.GrimBatol.Unit;
    if (grimBatol == null)
    {
      return;
    }

    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(grimBatol.X, grimBatol.Y, GrimBatolGroundsRadius))
    {
      if (whichUnit.Alive && _grimBatolBuildings.Contains(whichUnit.UnitType) && whichUnit.Owner.GetPlayerData().Faction == null)
      {
        whichUnit.SetOwner(whichPlayer);
      }
    }

    PathBase.ClaimArea(Regions.Grim_Batol, whichPlayer);
  }

  /// <summary>Stormwind if it's still in the game, otherwise Kul Tiras, otherwise nobody, with the buildings each turns Ironforge buildings into.</summary>
  private static player GetHeir(out Dictionary<int, int>? equivalents)
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

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;
}
