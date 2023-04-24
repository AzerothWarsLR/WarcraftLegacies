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
      CrisisCaptain = new Faction(FactionNames.Crisis, PLAYER_COLOR_SNOW, "|cffaaa050",
        "ReplaceableTextures\\WorldEditUI\\Editor-Random-Unit.blp")
      {
        CinematicMusic = "SadMystery",
        IntroText = @"You are playing as the Crisis captain|r.

At turn 25, you will choose your crisis team. Then your teamate will pick their crisis faction, and then you will choose your crisis faction.                    
Different factions will unlock depending on the game state.

After 30 seconds of your pick being available, you will be attributed the Old God team by default.
Carefully select which faction to play depending on how the game is going, you have global vision to help you in your decision

You will spawn with a big army but no base, quickly start building infrastructure and securing the surrounding lands. 
Your shop sells Scrolls of Teleportation at a discount, use them to join your ally quickly"
      };
      FactionManager.Register(CrisisCaptain);

      CrisisCaptain.ModObjectLimit(Constants.UPGRADE_R06D_TEAM_PICKED_OLD_GODS, Faction.UNLIMITED);
      CrisisCaptain.ModObjectLimit(Constants.UPGRADE_R07W_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisCaptain.ModObjectLimit(Constants.UPGRADE_R07E_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisCaptain.ModObjectLimit(Constants.UPGRADE_R086_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisCaptain.ModObjectLimit(Constants.UPGRADE_R08K_FORTIFIED_HULLS, Faction.UNLIMITED);



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