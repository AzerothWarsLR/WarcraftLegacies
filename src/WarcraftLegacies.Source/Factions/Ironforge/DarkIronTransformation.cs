using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Ironforge.Powers;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Turns Ironforge into the Dark Iron, who keep all of Khaz Modan and claim Grim Batol.</summary>
public sealed class DarkIronTransformation
{
  private const float GrimBatolGroundsRadius = 2500;

  private static readonly Point[] _armySpots =
  {
    new(10256, -5520),
    new(10096, -5008),
    new(10608, -4944)
  };

  private static readonly Dictionary<int, int> _grimBatolBuildings = new()
  {
    { UNIT_O067_DUNGEON_CREEP_BARRACKS, UNIT_H0DW_DARK_IRON_BARRACKS_DARKIRON_BARRACKS },
    { UNIT_O068_QUARRY_CREEP_RESEARCH, UNIT_H0DX_DARK_IRON_FORGE_DARKIRON_RESEARCH },
    { UNIT_O069_DARK_CONCLAVE_CREEP_MAGIC, UNIT_H0DY_SHADOWFORGE_SANCTUM_DARKIRON_MAGIC }
  };

  /// <summary>Turns <paramref name="ironforge"/>'s player into the Dark Iron.</summary>
  public void Execute(Faction ironforge)
  {
    var whichPlayer = ironforge.Player;
    if (whichPlayer == null)
    {
      return;
    }

    IronforgeHomeland.ClaimHeldLands(ironforge, ironforge.GetQuestByType<QuestDarkIron>());
    var darkIron = new DarkIronFaction(ironforge);
    FactionTransition.AssignNewFaction(ironforge, darkIron);
    darkIron.AddPower(new BloodOfTheMountain());
    PathBase.RemoveHero(AllLegends.Ironforge.Magni);
    PathBase.RemoveHero(AllLegends.Ironforge.Muradin);
    PathBase.RemoveHero(AllLegends.Ironforge.Falstad);

    RetireRagnarosWorldBoss(darkIron);
    CarryOverResearches(darkIron, whichPlayer);
    HandOverWildhammerLands(whichPlayer);
    ClaimGrimBatol(whichPlayer);
    PathBase.ConvertStructures(whichPlayer, DarkIronFaction.UnitEquivalents);

    PathBase.RelocateArmy(whichPlayer, DarkIronFaction.UnitEquivalents, _armySpots);
    PathBase.SummonLegend(AllLegends.Ironforge.Dagran, whichPlayer, _armySpots[0]);
    whichPlayer.Lumber = 0;
    if (darkIron.IntroText != null)
    {
      whichPlayer.DisplayTextTo(darkIron.IntroText());
    }

    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\Tension.mp3");
  }

  /// <summary>Once the Dark Iron exist, Ragnaros can only be summoned through their own quest.</summary>
  private static void RetireRagnarosWorldBoss(Faction darkIron)
  {
    var worldBossQuest = darkIron.GetAllQuests().OfType<QuestRagnaros>().FirstOrDefault();
    if (worldBossQuest != null)
    {
      worldBossQuest.Retire();
    }
  }

  /// <summary>Gives the Dark Iron their version of every research Ironforge already finished, including the tank choice.</summary>
  private static void CarryOverResearches(Faction darkIron, player whichPlayer)
  {
    foreach (var pair in DarkIronFaction.ResearchEquivalents)
    {
      var level = whichPlayer.GetTechResearched(pair.Key, false);
      if (level > 0)
      {
        darkIron.SetObjectLevel(pair.Value, level);
      }
    }
  }

  /// <summary>Gives Aerie Peak and the rest of the Hinterlands to whoever should hold them instead of the Dark Iron.</summary>
  private static void HandOverWildhammerLands(player whichPlayer)
  {
    var heir = GetWildhammerHeir();
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive)
      {
        continue;
      }

      var inAeriePeak = Regions.Aerie_Peak.Contains(whichUnit.X, whichUnit.Y);
      var isHinterlandsStructure = whichUnit.IsUnitType(unittype.Structure) &&
                                   (Regions.HinterlandAmbient1.Contains(whichUnit.X, whichUnit.Y) ||
                                    Regions.HinterlandAmbient2.Contains(whichUnit.X, whichUnit.Y));
      if (inAeriePeak || isHinterlandsStructure)
      {
        whichUnit.SetOwner(heir);
      }
    }
  }

  /// <summary>Stromgarde, then Dalaran, then Lordaeron, then Quel'thalas, whichever is still in the game, otherwise the creeps.</summary>
  private static player GetWildhammerHeir()
  {
    if (FactionManager.TryGetFactionByType<StromgardeFaction>(out var stromgarde) && IsStillInGame(stromgarde))
    {
      return stromgarde.Player!;
    }

    if (FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) && IsStillInGame(dalaran))
    {
      return dalaran.Player!;
    }

    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) && IsStillInGame(lordaeron))
    {
      return lordaeron.Player!;
    }

    if (FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas) && IsStillInGame(quelthalas))
    {
      return quelthalas.Player!;
    }

    return player.NeutralAggressive;
  }

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated && faction.Player.GetPlayerData().Faction == faction;

  /// <summary>Takes Grim Batol from the creeps holding it and swaps their buildings for Dark Iron ones.</summary>
  private static void ClaimGrimBatol(player whichPlayer)
  {
    var grimBatol = AllLegends.Neutral.GrimBatol.Unit;
    if (grimBatol == null)
    {
      return;
    }

    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(grimBatol.X, grimBatol.Y, GrimBatolGroundsRadius))
    {
      if (!whichUnit.Alive || whichUnit.Owner.GetPlayerData().Faction != null)
      {
        continue;
      }

      if (whichUnit.UnitType == UNIT_H01Z_GRIM_BATOL_CREEP_TWILIGHT)
      {
        whichUnit.SetOwner(whichPlayer);
      }
      else if (_grimBatolBuildings.TryGetValue(whichUnit.UnitType, out var darkIronType))
      {
        PathBase.ReplaceUnit(whichUnit, whichPlayer, darkIronType, whichUnit.X, whichUnit.Y);
      }
    }

    PathBase.ClaimArea(Regions.Grim_Batol, whichPlayer);
  }
}
