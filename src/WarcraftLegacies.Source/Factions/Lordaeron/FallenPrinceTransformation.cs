using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

/// <summary>Turns Lordaeron into the Fallen Prince, with bases at Stratholme and in Northrend.</summary>
public sealed class FallenPrinceTransformation
{
  private const float Facing = 270;
  private const float StructureSize = 256;
  private const float CitadelSize = 512;
  private const float NorthrendX = -512;
  private const float NorthrendY = 15776;
  private const float NorthrendRadius = 2000;

  /// <summary>Turns <paramref name="lordaeron"/>'s player into the Fallen Prince.</summary>
  public void Execute(Faction lordaeron)
  {
    var whichPlayer = lordaeron.Player;
    if (whichPlayer == null)
    {
      return;
    }

    whichPlayer.RemoveAllUnits();
    FactionTransition.AssignNewFaction(lordaeron, new FallenPrinceFaction());

    var stratholme = Regions.StratholmeScourgeBase.Center;
    PathBase.ClaimArea(Regions.StratholmeScourgeBase, whichPlayer);
    CreateStratholmeBase(whichPlayer, stratholme);

    CreateNorthrendOutpost(whichPlayer);

    TakeArthasFromScourge(whichPlayer, stratholme);
  }

  /// <summary>Takes over the Scourge's Plague base on the Stratholme coast, or builds the same base if there is none.</summary>
  private static void CreateStratholmeBase(player whichPlayer, Point center)
  {
    var plague = FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge)
      ? scourge.GetAllQuests().OfType<QuestPlague>().FirstOrDefault()
      : null;
    if (plague != null)
    {
      plague.HandOverCoast(whichPlayer);
    }
    else
    {
      PathBase.CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, 11232, 12576);
      PathBase.CreateStructure(whichPlayer, UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, 11488, 12832);
      PathBase.CreateStructure(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, 11680, 12320);
      PathBase.CreateStructure(whichPlayer, UNIT_UBON_BONEYARD_SCOURGE_SIEGE, 11936, 12576);
      PathBase.CreateStructure(whichPlayer, UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, 11616, 13152);
      PathBase.CreateStructure(whichPlayer, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, 12192, 12768);
      PathBase.CreateStructure(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 11840, 13376);
      PathBase.CreateStructure(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 12416, 12992);
    }

    PathBase.CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 5, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_UGHO_GHOUL_SCOURGE, 6, center.X - 250, center.Y + 600);
    PathBase.CreateUnits(whichPlayer, UNIT_N009_REVENANT_SCOURGE, 2, center.X + 250, center.Y + 600);
  }

  /// <summary>Raises the Fallen Prince's camp on the Dragonblight shore, where Lordaeron's Northrend expedition lands.</summary>
  private static void CreateNorthrendOutpost(player whichPlayer)
  {
    RefundSystem.RefundEnemyStructuresInRange(whichPlayer, NorthrendX, NorthrendY, NorthrendRadius);
    KillNeutralHostileUnitsInRadius(NorthrendX, NorthrendY, NorthrendRadius);

    CreateStructureForced(whichPlayer, UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, -512, 15744, Facing, CitadelSize);
    CreateStructureForced(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, -256, 16832, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, 416, 16416, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, 672, 16928, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, 800, 16288, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, -928, 16736, Facing, StructureSize);
    TeleportScrollSetting.StockShop(CreateStructureForced(whichPlayer, UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP, 1280, 16064, Facing, StructureSize));
    CreateStructureForced(whichPlayer, UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, 800, 15776, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, -1088, 16576, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, 704, 17152, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, -960, 15872, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, -448, 16128, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 1472, 16384, Facing, StructureSize);
    CreateStructureForced(whichPlayer, UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, -640, 16576, Facing, StructureSize);

    unit.Create(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 818, 16864, Facing);
    unit.Create(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 624, 16725, Facing);
    unit.Create(whichPlayer, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 771, 16064, Facing);
    unit.Create(whichPlayer, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, -174, 16631, Facing);
    unit.Create(whichPlayer, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, -388, 16871, Facing);
    unit.Create(whichPlayer, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, -561, 16521, Facing);
    unit.Create(whichPlayer, UNIT_U103_RISEN_ARCHER_FALLENPRINCE, -513, 16679, Facing);
    unit.Create(whichPlayer, UNIT_N009_REVENANT_SCOURGE, 893, 16175, Facing);
    unit.Create(whichPlayer, UNIT_UNEC_NECROMANCER_SCOURGE, -931, 16554, Facing);
    unit.Create(whichPlayer, UNIT_H0AZ_GALLEY_EVIL, 251, 15569, Facing);
  }

  private static void TakeArthasFromScourge(player whichPlayer, Point stratholme)
  {
    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      scourge.ModObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE, -scourge.GetObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE));
    }

    PathBase.SummonLegend(AllLegends.Scourge.Arthas, whichPlayer, new Point(stratholme.X, stratholme.Y + 300));
  }
}
