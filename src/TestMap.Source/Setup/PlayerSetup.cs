using MacroTools.Extensions;
using MacroTools.FactionSystem;
using TestMap.Source.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace TestMap.Source.Setup
{
  public static class PlayerSetup
  {
    public static void Setup()
    {
      Player(0).SetFaction(DalaranSetup.Dalaran);
      Player(0).SetTeam(TeamSetup.TeamAlliance);
      
      Player(1).SetFaction(DraeneiSetup.Draenei);
      Player(1).SetTeam(TeamSetup.TeamHorde);
      
      Player(2).SetFaction(DruidsSetup.FactionDruids);
      Player(2).SetTeam(TeamSetup.TeamAlliance);
    }
  }
}