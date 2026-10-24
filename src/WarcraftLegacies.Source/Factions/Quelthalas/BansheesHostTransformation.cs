using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Banshee's Host, with a base in Northrend.</summary>
public sealed class BansheesHostTransformation
{
  /// <summary>Where the Northrend base goes. A placeholder until a spot is picked.</summary>
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

    var center = NorthrendBase.Center;
    PathBase.ClaimArea(NorthrendBase, whichPlayer);
    CreateBase(whichPlayer, center);
    PathBase.SummonLegend(AllLegends.Quel.Sylvanas, whichPlayer, new Point(center.X, center.Y + 300));
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\TragicConfrontation.mp3");
  }

  private static void CreateBase(player whichPlayer, Point center)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_UNPL_NECROPOLIS_SCOURGE_T1, center.X, center.Y);
    PathBase.CreateStructure(whichPlayer, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, center.X - 500, center.Y + 300);
    PathBase.CreateStructure(whichPlayer, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, center.X + 500, center.Y + 300);
    PathBase.CreateStructure(whichPlayer, UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, center.X, center.Y - 550);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X - 550, center.Y - 450);
    PathBase.CreateStructure(whichPlayer, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, center.X + 550, center.Y - 450);
    PathBase.CreateUnits(whichPlayer, UNIT_UACO_ACOLYTE_SCOURGE_WORKER, 5, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_UBAN_BANSHEE_SCOURGE, 6, center.X - 250, center.Y + 600);
    PathBase.CreateUnits(whichPlayer, UNIT_UGHO_GHOUL_SCOURGE, 4, center.X + 250, center.Y + 600);
  }
}
