using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class CrisisCaptainSetup
  {
    public static Faction? CrisisCaptain { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      CrisisCaptain = new Faction(FactionNames.Crisis, PLAYER_COLOR_SNOW, "|c00e55bb0",
        "ReplaceableTextures\\CommandButtons\\BTNJaina.blp")
      {
        CinematicMusic = "SadMystery",
        IntroText = @"You are the captain"
      };
      FactionManager.Register(CrisisCaptain);

      CrisisCaptain.ModObjectLimit(Constants.UPGRADE_R06D_TEAM_PICKED_OLD_GODS, Faction.UNLIMITED);



      var visionPower = new VisionPower("All-Seeing",
        "Grants permanent vision over the map.",
        "Charm", new[]
        {
          Regions.EntireMap,
        });
      CrisisCaptain.AddPower(visionPower);
    }
  }
}