using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.UserInterface;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

/// <summary>
/// Removes everything Lordaeron owns and restarts the player as the Fallen Prince, with a small base at Stratholme and an
/// outpost in Northrend. Arthas the death knight leaves the Scourge to lead them.
/// </summary>
public sealed class FallenPrinceTransformation
{
  private const float StructureSize = 256;
  private const float Facing = 270;
  private const int FalricStartingXp = 2800;

  /// <summary>Where the Northrend outpost goes. A placeholder until a spot is picked.</summary>
  private static Rectangle NorthrendOutpost => Regions.GrizzlyHills;

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
    ClearNeutralHostiles(Regions.StratholmeScourgeBase, whichPlayer);
    CreateStratholmeBase(whichPlayer, stratholme);

    var northrend = NorthrendOutpost.Center;
    ClearNeutralHostiles(NorthrendOutpost, whichPlayer);
    CreateNorthrendOutpost(whichPlayer, northrend);

    TakeArthasFromScourge(whichPlayer, stratholme);
    CreateFalric(whichPlayer, stratholme);
    CorrectLimitTooltips(whichPlayer);
  }

  private static void CreateStratholmeBase(player whichPlayer, Point center)
  {
    CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, center.X, center.Y);
    CreateStructure(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, center.X - 500, center.Y + 300);
    CreateStructure(whichPlayer, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, center.X + 500, center.Y + 300);
    CreateStructure(whichPlayer, UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, center.X, center.Y - 550);
    CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X - 550, center.Y - 450);
    CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X + 550, center.Y - 450);
    CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 5, center.X, center.Y - 250);
    CreateUnits(whichPlayer, UNIT_UGHO_GHOUL_SCOURGE, 6, center.X - 250, center.Y + 600);
    CreateUnits(whichPlayer, UNIT_UABO_ABOMINATION_SCOURGE, 2, center.X + 250, center.Y + 600);
  }

  private static void CreateNorthrendOutpost(player whichPlayer, Point center)
  {
    CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, center.X, center.Y);
    CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X - 450, center.Y - 350);
    CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X + 450, center.Y - 350);
    CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 3, center.X, center.Y - 250);
    CreateUnits(whichPlayer, UNIT_UGHO_GHOUL_SCOURGE, 4, center.X, center.Y + 450);
  }

  private static void TakeArthasFromScourge(player whichPlayer, Point stratholme)
  {
    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      scourge.ModObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE, -scourge.GetObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE));
    }

    var arthas = AllLegends.Scourge.Arthas;
    if (arthas.Unit != null && arthas.Unit.Alive)
    {
      arthas.Unit.SetOwner(whichPlayer);
      arthas.Unit.SetPosition(stratholme.X, stratholme.Y + 300);
      return;
    }

    arthas.ForceCreate(whichPlayer, new Point(stratholme.X, stratholme.Y + 300), Facing);
  }

  private static void CreateFalric(player whichPlayer, Point stratholme)
  {
    var falric = new LegendaryHero("Falric")
    {
      UnitType = UNIT_U020_DEATHGUARD_SCOURGE,
      StartingXp = FalricStartingXp
    };
    LegendaryHeroManager.Register(falric);
    falric.ForceCreate(whichPlayer, new Point(stratholme.X + 200, stratholme.Y + 300), Facing);
  }

  /// <summary>
  /// The Fallen Prince trains the Scourge's units, whose tooltips show the Scourge's limits, so the shown limits are
  /// shifted to the Fallen Prince's own.
  /// </summary>
  private static void CorrectLimitTooltips(player whichPlayer)
  {
    var scourgeLimits = new Dictionary<int, int>();
    foreach (var objectInfo in ScourgeObjectInfo.GetAllObjectLimits())
    {
      scourgeLimits[objectInfo.ObjectTypeId] = objectInfo.LimitTooltipOverride ?? objectInfo.Limit;
    }

    foreach (var objectInfo in FallenPrinceObjectInfo.GetAllObjectLimits())
    {
      if (scourgeLimits.TryGetValue(objectInfo.ObjectTypeId, out var shownLimit) &&
          shownLimit > 0 && shownLimit < Faction.Unlimited && shownLimit != objectInfo.Limit)
      {
        LimitTooltips.ShiftShownLimit(whichPlayer, objectInfo.ObjectTypeId, objectInfo.Limit - shownLimit);
      }
    }
  }

  private static void ClearNeutralHostiles(Rectangle area, player newOwner)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(area).Where(x => x.Owner == player.NeutralAggressive))
    {
      if (unit.IsRemovable())
      {
        unit.SafelyRemove();
      }
      else
      {
        unit.Rescue(newOwner);
      }
    }
  }

  private static void CreateStructure(player whichPlayer, int unitTypeId, float x, float y) =>
    GeneralHelpers.CreateStructureForced(whichPlayer, unitTypeId, x, y, Facing, StructureSize);

  private static void CreateUnits(player whichPlayer, int unitTypeId, int count, float x, float y)
  {
    for (var i = 0; i < count; i++)
    {
      unit.Create(whichPlayer, unitTypeId, x, y, Facing);
    }
  }
}
