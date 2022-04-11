using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup
{
  public static class DraeneiSetup
  {
    public static Faction Draenei { get; private set; }

    public static void Setup()
    {
      Draenei = new Faction("The Exodar", PLAYER_COLOR_NAVY, "|cff000080",
        "ReplaceableTextures\\CommandButtons\\BTNBOSSVelen.blp")
      {
        Team = TeamSetup.TeamHorde,
        StartingGold = 150,
        StartingLumber = 500
      };
    }
  }
}