using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup
{
  public static class BlackEmpireSetup
  {
    public static Faction BlackEmpire { get; private set; }

    public static void Setup()
    {
      BlackEmpire = new Faction("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080",
        "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        Team = TeamSetup.TeamAlliance
      };
      FactionManager.Register(BlackEmpire);

      var power = new DummyPower("Waygates",
        "Allows you to construct 2 Waygates, which enable teleportation between them.",
        "Waygate");
      FactionManager.FactionAddPower(BlackEmpire, power);
      
      power = new DummyPower("All-Seeing",
        "Grants permanent vision over Northrend.",
        "Charm");
      FactionManager.FactionAddPower(BlackEmpire, power);
    }
  }
}