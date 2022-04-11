using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup
{
  public static class CthunSetup
  {
    public static Faction FactionCthun { get; private set; }
    
    public static void Setup()
    {
      FactionCthun = new Faction("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80",
        "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      {
        Team = TeamSetup.TeamAlliance,
        StartingGold = 150,
        StartingLumber = 500
      };
    }
  }
}