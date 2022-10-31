using MacroTools.FactionSystem;
using static War3Api.Common;

namespace TestMap.Source.Setup.FactionSetup.FactionSetup
{
  public static class CthunSetup
  {
    public static Faction? FactionCthun { get; private set; }
    
    public static void Setup()
    {
      FactionCthun = new Faction("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80",
        "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500
      };
      FactionManager.Register(FactionCthun);
    }
  }
}