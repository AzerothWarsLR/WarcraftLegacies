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

      var power = new DummyPower("Waygates",
        "Allows you to construct 2 Waygates, which enable teleportation between them.",
        "Waygate");
      BlackEmpire.AddPower(power);

      power = new DummyPower("All-Seeing",
        "Grants permanent vision over Northrend.",
        "Charm");
      BlackEmpire.AddPower(power);

      FactionManager.Register(BlackEmpire);
    }
  }
}