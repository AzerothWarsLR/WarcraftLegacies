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
      CrisisFootman = new Faction(FactionNames.Crisis2, PLAYER_COLOR_SNOW, "|cff9680b4",
        "ReplaceableTextures\\WorldEditUI\\Editor-Random-Unit.blp")
      {
        CinematicMusic = "SadMystery",
        IntroText = @"You are playing as the second Crisis|r. 

At turn 25, your captain will choose your crisis team. Then you will pick your crisis faction, and then your teamate will choose their crisis faction. 
Different factions will unlock depending on the game state. 

After 30 seconds of your pick being available, you will be attributed the Black Empire by default. 
Carefully select which faction to play depending on how the game is going, you have global vision to help you in your decision

You will spawn with a big army but no base, quickly start building infrastructure and securing the surrounding lands. 
Your shop sells Scrolls of Teleportation at a discount, use them to join your ally quickly"
      };
      FactionManager.Register(CrisisFootman);

      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R06D_TEAM_PICKED_OLD_GODS, Faction.UNLIMITED);
      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R07W_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R07E_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R086_FORTIFIED_HULLS, Faction.UNLIMITED);
      CrisisFootman.ModObjectLimit(Constants.UPGRADE_R08K_FORTIFIED_HULLS, Faction.UNLIMITED);



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