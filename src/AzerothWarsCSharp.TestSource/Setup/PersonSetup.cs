using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class PersonSetup
  {
    public static void Setup()
    {
      Player(0).SetFaction(BlackEmpireSetup.BlackEmpire);
      Player(1).SetFaction(CthunSetup.FactionCthun);
      Player(2).SetFaction(DalaranSetup.Dalaran);
      Player(3).SetFaction(DraeneiSetup.Draenei);
      Player(4).SetFaction(DruidsSetup.FactionDruids);
    }
  }
}