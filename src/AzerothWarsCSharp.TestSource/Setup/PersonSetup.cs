using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class PersonSetup
  {
    public static void Setup()
    {
      Person.Register(new Person(Player(0)) 
        {Faction = BlackEmpireSetup.FactionBlackempire}
      );

      Person.Register(new Person(Player(1)) 
        {Faction = CthunSetup.FactionCthun}
      );

      Person.Register(new Person(Player(2)) 
        {Faction = DalaranSetup.Dalaran}
      );

      Person.Register(new Person(Player(3)) 
        {Faction = DraeneiSetup.Draenei}
      );

      Person.Register(new Person(Player(4)) 
        {Faction = DruidsSetup.factionDruids}
      );
    }
  }
}