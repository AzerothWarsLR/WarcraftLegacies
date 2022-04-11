using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup
{
  public static class BlackEmpireSetup
  {
    public static Faction FactionBlackempire { get; private set; }

    public static void Setup()
    {
      FactionBlackempire = new Faction("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080",
        "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        Team = TeamSetup.TeamAlliance
      };
    }
  }
}