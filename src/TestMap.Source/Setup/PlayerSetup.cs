using MacroTools.FactionSystem;
using TestMap.Source.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace TestMap.Source.Setup
{
  public static class PlayerSetup
  {
    public static void Setup()
    {
      Player(0).SetFaction(BlackEmpireSetup.BlackEmpire);
      Player(0).SetTeam(TeamSetup.TeamAlliance);
      
      Player(1).SetFaction(CthunSetup.FactionCthun);
      Player(1).SetTeam(TeamSetup.TeamLegion);
      
      Player(2).SetFaction(DalaranSetup.Dalaran);
      Player(2).SetTeam(TeamSetup.TeamAlliance);
      
      Player(3).SetFaction(DraeneiSetup.Draenei);
      Player(3).SetTeam(TeamSetup.TeamHorde);
      
      Player(4).SetFaction(DruidsSetup.FactionDruids);
      Player(4).SetTeam(TeamSetup.TeamAlliance);
    }
  }
}