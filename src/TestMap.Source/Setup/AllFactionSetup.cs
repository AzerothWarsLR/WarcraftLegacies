using MacroTools.FactionSystem;
using MacroTools.Powers;
using TestMap.Source.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace TestMap.Source.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup()
    {
      DalaranSetup.Setup();
      DruidsSetup.Setup();
      CthunSetup.Setup();
      BlackEmpireSetup.Setup();
      DraeneiSetup.Setup();

      var spaceMarines = new Faction("Space Marines", PLAYER_COLOR_BLUE, "|c000042ff",
        "ReplaceableTextures\\CommandButtons\\BTNMarine.blp");
      var newPower = new DummyPower("Space", "You're from space, and can use spaceships.", "Marine");
      spaceMarines.AddPower(newPower);
      FactionManager.Register(spaceMarines);
    }
  }
}