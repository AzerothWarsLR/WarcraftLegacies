using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class PersonSetup
  {
    public static void Setup()
    {
      Person.Register(new Person(Player(0)) 
        {Faction = FrostwolfSetup.FACTION_FROSTWOLF}
      );

      Person.Register(new Person(Player(1)) 
        {Faction = LordaeronSetup.FactionLordaeron}
      );

      Person.Register(new Person(Player(2)) 
        {Faction = QuelthalasSetup.FactionQuelthalas}
      );

      Person.Register(new Person(Player(3)) 
        {Faction = ScourgeSetup.FactionScourge}
      );

      Person.Register(new Person(Player(4)) 
        {Faction = IronforgeSetup.FACTION_IRONFORGE}
      );

      Person.Register(new Person(Player(5)) 
        {Faction = WarsongSetup.FACTION_WARSONG}
      );

      Person.Register(new Person(Player(6)) 
        {Faction = FelHordeSetup.FactionFelHorde}
      );

      Person.Register(new Person(Player(7)) 
        {Faction = DalaranSetup.Dalaran}
      );

      Person.Register(new Person(Player(8)) 
        {Faction = GoblinSetup.factionGoblin}
      );

      Person.Register(new Person(Player(9)) 
        {Faction = ForsakenSetup.FACTION_FORSAKEN}
      );

      Person.Register(new Person(Player(10)) 
        {Faction = StormwindSetup.Stormwind}
      );

      Person.Register(new Person(Player(11)) 
        {Faction = DruidsSetup.factionDruids}
      );

      Person.Register(new Person(Player(12)) 
        {Faction = ScarletSetup.FactionScarlet}
      );

      Person.Register(new Person(Player(13)) 
        {Faction = DraeneiSetup.Draenei}
      );

      Person.Register(new Person(Player(14)) 
        {Faction = BlackEmpireSetup.FactionBlackempire}
      );

      Person.Register(new Person(Player(15)) 
        {Faction = NagaSetup.FactionNaga}
      );

      Person.Register(new Person(Player(16)) 
        {Faction = CthunSetup.FactionCthun}
      );

      Person.Register(new Person(Player(17)) 
        {Faction = TrollSetup.FACTION_TROLL}
      );

      Person.Register(new Person(Player(18)) 
        {Faction = SentinelsSetup.Sentinels}
      );

      Person.Register(new Person(Player(19)) 
        {Faction = TwilightSetup.FACTION_TWILIGHT}
      );

      Person.Register(new Person(Player(20)) 
        {Faction = GilneasSetup.FACTION_GILNEAS}
      );

      Person.Register(new Person(Player(22)) 
        {Faction = KultirasSetup.FACTION_KULTIRAS}
      );
      
      Person.Register(new Person(Player(23)) 
        {Faction = LegionSetup.FactionLegion}
      );

      Person.Register(new Person(Player(21))
      );
    }
  }
}