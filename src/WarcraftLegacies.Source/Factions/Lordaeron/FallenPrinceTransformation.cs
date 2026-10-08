using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

/// <summary>Turns Lordaeron into the Fallen Prince, with bases at Stratholme and in Northrend.</summary>
public sealed class FallenPrinceTransformation
{
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
    PathBase.ClaimArea(Regions.StratholmeScourgeBase, whichPlayer);
    CreateStratholmeBase(whichPlayer, stratholme);

    var northrend = NorthrendOutpost.Center;
    PathBase.ClaimArea(NorthrendOutpost, whichPlayer);
    CreateNorthrendOutpost(whichPlayer, northrend);

    TakeArthasFromScourge(whichPlayer, stratholme);
    CreateFalric(whichPlayer, stratholme);
  }

  private static void CreateStratholmeBase(player whichPlayer, Point center)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, center.X, center.Y);
    PathBase.CreateStructure(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, center.X - 500, center.Y + 300);
    PathBase.CreateStructure(whichPlayer, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, center.X + 500, center.Y + 300);
    PathBase.CreateStructure(whichPlayer, UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, center.X, center.Y - 550);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X - 550, center.Y - 450);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X + 550, center.Y - 450);
    PathBase.CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 5, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_UGHO_GHOUL_SCOURGE, 6, center.X - 250, center.Y + 600);
    PathBase.CreateUnits(whichPlayer, UNIT_UABO_ABOMINATION_SCOURGE, 2, center.X + 250, center.Y + 600);
  }

  private static void CreateNorthrendOutpost(player whichPlayer, Point center)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, center.X, center.Y);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X - 450, center.Y - 350);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X + 450, center.Y - 350);
    PathBase.CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 3, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_UGHO_GHOUL_SCOURGE, 4, center.X, center.Y + 450);
  }

  private static void TakeArthasFromScourge(player whichPlayer, Point stratholme)
  {
    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      scourge.ModObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE, -scourge.GetObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE));
    }

    PathBase.SummonLegend(AllLegends.Scourge.Arthas, whichPlayer, new Point(stratholme.X, stratholme.Y + 300));
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
}
