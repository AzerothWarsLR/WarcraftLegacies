using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
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

  private const float MusterX = 5513;
  private const float MusterY = 9440;
  private const float RankSpacing = 90;
  private const float FileSpacing = 100;
  private const float MusterFacing = 270;

  /// <summary>Turns <paramref name="quelthalas"/>'s player into the Banshee's Host.</summary>
  public void Execute(Faction quelthalas)
  {
    var whichPlayer = quelthalas.Player;
    if (whichPlayer == null)
    {
      return;
    }

    whichPlayer.RemoveAllUnits();
    var bansheesHost = new BansheesHostFaction();
    FactionTransition.AssignNewFaction(quelthalas, bansheesHost);

    FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge);
    var plague = scourge?.GetAllQuests().OfType<QuestPlague>().FirstOrDefault();
    var enKilah = scourge?.GetAllQuests().OfType<QuestEnKilahUnlock>().FirstOrDefault();

    PathBase.ClaimArea(Regions.DeathknellUnlock, whichPlayer);
    CreateDeathknellBase(whichPlayer, plague);
    PathBase.ClaimArea(NorthrendBase, whichPlayer);
    CreateEnKilahBase(whichPlayer, enKilah);
    TakeEnKilahControlPoint(whichPlayer);

    CreateRank(whichPlayer, UNIT_H08O_ROTGUARD_FORSAKEN, 4, MusterY);
    CreateRank(whichPlayer, UNIT_UBAN_BANSHEE_SCOURGE, 3, MusterY + RankSpacing);
    CreateRank(whichPlayer, UNIT_UBAN_BANSHEE_SCOURGE, 3, MusterY + 2 * RankSpacing);
    CreateRank(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 5, MusterY + 3 * RankSpacing);
    AllLegends.Quel.Sylvanas.UnitType = UNIT_U03B_BANSHEE_QUEEN_BANSHEESHOST;
    PathBase.SummonLegend(AllLegends.Quel.Sylvanas, whichPlayer, new Point(MusterX, MusterY - RankSpacing));
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\TragicConfrontation.mp3");
    ArthasDialogue.SylvanasLiving.Fail();
    SylvanasDialogue.PlayBansheeRaised(bansheesHost);
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
    CreateEnKilahOutbuildings(whichPlayer);
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

  /// <summary>The Scourge's hold on En'kilah passes to the Banshee's Host with the base; an enemy who took it keeps it.</summary>
  private static void TakeEnKilahControlPoint(player whichPlayer)
  {
    var controlPoint = AllPreplacedWidgets.Units.Get(UNIT_N09H_EN_KILAH);
    if (controlPoint.Owner.GetPlayerData().Faction is ScourgeFaction)
    {
      controlPoint.SetOwner(whichPlayer);
    }
  }

  private static void CreateRank(player whichPlayer, int unitTypeId, int count, float y)
  {
    var startX = MusterX - (count - 1) * FileSpacing / 2;
    for (var i = 0; i < count; i++)
    {
      unit.Create(whichPlayer, unitTypeId, startX + i * FileSpacing, y, MusterFacing);
    }
  }

  private static void CreateEnKilahOutbuildings(player whichPlayer)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, -5152, 18496);
    PathBase.CreateStructure(whichPlayer, UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, -5334, 17709);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, -5830, 18204);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, -5369, 18110);
    PathBase.CreateStructure(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, -5568, 18848);
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
