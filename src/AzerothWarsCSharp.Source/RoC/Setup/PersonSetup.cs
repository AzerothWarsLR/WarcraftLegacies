using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public class PersonSetup{

    public static void Setup( ){
      Person p;

      p = Person.create(Player(0));
      p.Faction = FACTION_FROSTWOLF;

      p = Person.create(Player(1));
      p.Faction = FACTION_LORDAERON;

      p = Person.create(Player(2));
      p.Faction = FACTION_QUELTHALAS;

      p = Person.create(Player(3));
      p.Faction = FACTION_SCOURGE;

      p = Person.create(Player(4));
      p.Faction = FACTION_IRONFORGE;

      p = Person.create(Player(5));
      p.Faction = FACTION_WARSONG;

      p = Person.create(Player(6));
      p.Faction = FACTION_FEL_HORDE;

      p = Person.create(Player(7));
      p.Faction = FACTION_DALARAN;

      p = Person.create(Player(8));
      p.Faction = FACTION_GOBLIN;

      p = Person.create(Player(9));
      p.Faction = FACTION_FORSAKEN;

      p = Person.create(Player(10));
      p.Faction = FACTION_STORMWIND;

      p = Person.create(Player(11));
      p.Faction = FACTION_DRUIDS;

      p = Person.create(Player(12));
      p.Faction = FACTION_SCARLET;

      p = Person.create(Player(13));
      p.Faction = FACTION_DRAENEI;

      p = Person.create(Player(14));
      p.Faction = FACTION_BLACKEMPIRE;

      p = Person.create(Player(15));
      p.Faction = FACTION_NAGA;

      p = Person.create(Player(16));
      p.Faction = FACTION_CTHUN;

      p = Person.create(Player(17));
      p.Faction = FACTION_TROLL;

      p = Person.create(Player(18));
      p.Faction = FACTION_SENTINELS;

      p = Person.create(Player(19));
      p.Faction = FACTION_TWILIGHT;

      p = Person.create(Player(20));
      p.Faction = FACTION_GILNEAS;

      p = Person.create(Player(22));
      p.Faction = FACTION_KULTIRAS;

      p = Person.create(Player(23));
      p.Faction = FACTION_LEGION;

      Person.create(Player(21));

    }

  }
}
