using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class CrisisFootmanSetup
  {
    public static Faction? CrisisFootman { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      CrisisFootman = new Faction(FactionNames.Crisis2, PLAYER_COLOR_SNOW, "|c00e55bb0",
        "ReplaceableTextures\\CommandButtons\\BTNJaina.blp")
      {
        CinematicMusic = "SadMystery",
        IntroText = @"You are the footman"
      };
      FactionManager.Register(CrisisFootman);

      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R06D_TEAM_PICKED_OLD_GODS, Faction.UNLIMITED);
      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R07W_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R07E_FORTIFIED_HULLS, Faction.UNLIMITED);



      var visionPower = new VisionPower("All-Seeing",
        "Grants permanent vision over the map.",
        "Charm", new[]
        {
          Regions.EntireMap,
        });
      CrisisFootman.AddPower(visionPower);
    }
  }
}