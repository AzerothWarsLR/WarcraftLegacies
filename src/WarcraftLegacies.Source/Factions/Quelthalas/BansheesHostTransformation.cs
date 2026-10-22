using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Banshee's Host, with bases at Deathknell and En'kilah.</summary>
public sealed class BansheesHostTransformation
{
  /// <summary>The Banshee's Host's base in Northrend.</summary>
  public static Rectangle NorthrendBase => Regions.EnKilahUnlock;

  /// <summary>Turns <paramref name="quelthalas"/>'s player into the Banshee's Host.</summary>
  public void Execute(Faction quelthalas)
  {
    var whichPlayer = quelthalas.Player;
    if (whichPlayer == null)
    {
      return;
    }

    whichPlayer.RemoveAllUnits();
    FactionTransition.AssignNewFaction(quelthalas, new BansheesHostFaction());

    FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge);
    var plague = scourge?.GetAllQuests().OfType<QuestPlague>().FirstOrDefault();
    var enKilah = scourge?.GetAllQuests().OfType<QuestEnKilahUnlock>().FirstOrDefault();

    PathBase.ClaimArea(Regions.DeathknellUnlock, whichPlayer);
    CreateDeathknellBase(whichPlayer, plague);
    PathBase.ClaimArea(NorthrendBase, whichPlayer);
    CreateEnKilahBase(whichPlayer, enKilah);

    var deathknell = Regions.DeathknellUnlock.Center;
    PathBase.CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 5, deathknell.X, deathknell.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_UBAN_BANSHEE_SCOURGE, 6, deathknell.X - 250, deathknell.Y + 400);
    PathBase.CreateUnits(whichPlayer, UNIT_H08O_ROTGUARD_FORSAKEN, 4, deathknell.X + 250, deathknell.Y + 400);
    AllLegends.Quel.Sylvanas.UnitType = UNIT_U03B_BANSHEE_QUEEN_BANSHEESHOST;
    PathBase.SummonLegend(AllLegends.Quel.Sylvanas, whichPlayer, new Point(deathknell.X, deathknell.Y + 150));
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\TragicConfrontation.mp3");
  }

  /// <summary>Takes over the Scourge's Deathknell base, or builds the same base if there is none.</summary>
  private static void CreateDeathknellBase(player whichPlayer, QuestPlague? plague)
  {
    if (plague != null)
    {
      plague.HandOverDeathknell(whichPlayer);
      return;
    }

    PathBase.CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, 5152, 8736);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, 4928, 8960);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, 5440, 8896);
    PathBase.CreateStructure(whichPlayer, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, 4960, 9184);
    PathBase.CreateStructure(whichPlayer, UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, 5728, 9184);
    PathBase.CreateStructure(whichPlayer, UNIT_UBON_BONEYARD_SCOURGE_SIEGE, 4768, 9568);
    PathBase.CreateStructure(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, 5152, 9824);
    PathBase.CreateStructure(whichPlayer, UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, 4896, 9824);
    PathBase.CreateStructure(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 5632, 9792);
    PathBase.CreateStructure(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 5952, 9344);
  }

  /// <summary>Takes over the Scourge's En'kilah outpost, or builds the same outpost if there is none, with a Black Citadel at its heart.</summary>
  private static void CreateEnKilahBase(player whichPlayer, QuestEnKilahUnlock? enKilah)
  {
    if (enKilah == null)
    {
      PathBase.CreateStructure(whichPlayer, UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, -5792, 18592);
      return;
    }

    enKilah.HandOver(whichPlayer);
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRect(NorthrendBase))
    {
      if (whichUnit.Owner == whichPlayer && whichUnit.Alive &&
          (whichUnit.UnitType == UNIT_UNPL_NECROPOLIS_SCOURGE_T1 || whichUnit.UnitType == UNIT_UNP1_HALLS_OF_THE_DEAD_SCOURGE_T2))
      {
        UpgradeToBlackCitadel(whichUnit);
      }
    }
  }

  private static void UpgradeToBlackCitadel(unit necropolis)
  {
    var owner = necropolis.Owner;
    var x = necropolis.X;
    var y = necropolis.Y;
    var facing = necropolis.Facing;
    necropolis.Dispose();
    unit.Create(owner, UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, x, y, facing);
  }
}
