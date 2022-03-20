using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class TwilightSetup{

  
    Faction FACTION_TWILIGHT
  

    public static void Setup( ){
      Faction f;

      FACTION_TWILIGHT = Faction.create("Twilight", PLAYER_COLOR_LAVENDER, "|cff9178a8","ReplaceableTextures\\CommandButtons\\BTNChogall.blp");
      f = FACTION_TWILIGHT;
      f.Team = TEAM_OLDGOD;
      f.StartingGold = 150;
      f.StartingLumber = 350;

      f.ModObjectLimit(FourCC(o039), UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC(o03A), UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC(o03B), UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC(o03C), UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC(o03D), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(o03J), UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC(o03E), UNLIMITED)   ;//Spirit Lodge
      f.ModObjectLimit(FourCC(o03F), UNLIMITED)   ;//Bestiary
      f.ModObjectLimit(FourCC(o03I), UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC(o03G), UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC(o03H), UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC(u00Y), UNLIMITED)   ;//Shop
      f.ModObjectLimit(FourCC(o03K), UNLIMITED)   ;//Burrow

      f.ModObjectLimit(FourCC(n051), 4)           ;//Black Drake
      f.ModObjectLimit(FourCC(o04J), 8)           ;//WindRider
      f.ModObjectLimit(FourCC(n07X), UNLIMITED)   ;//Fel Orc Warlock
      f.ModObjectLimit(FourCC(o01H), UNLIMITED)   ;//Fel Orc Grunt
      f.ModObjectLimit(FourCC(o04B), UNLIMITED)   ;//Fel Orc Peon
      f.ModObjectLimit(FourCC(n083), UNLIMITED)   ;//Horde Cavarly
      f.ModObjectLimit(FourCC(o04I), 6)           ;//Executioner
      f.ModObjectLimit(FourCC(o04K), 6)           ;//Demolisher
      f.ModObjectLimit(FourCC(n09O), 6)           ;//DK
      f.ModObjectLimit(FourCC(u01T), UNLIMITED)   ;//Necrolyte
      f.ModObjectLimit(FourCC(n087), UNLIMITED)   ;//Phase Grenadier
      f.ModObjectLimit(FourCC(obot), 12)  	    ;//Transport Ship
      f.ModObjectLimit(FourCC(odes), 12)  	    ;//Orc Frigate
      f.ModObjectLimit(FourCC(ojgn), 6)          ;//Juggernaught

      f.ModObjectLimit(FourCC(O01P), 1)           ;//Chogall
      f.ModObjectLimit(FourCC(H08Q), 1)           ;//Azil
      f.ModObjectLimit(FourCC(U01S), 1)           ;//Feludius
      f.ModObjectLimit(FourCC(O04H), 1)           ;//ignacius


      f.ModObjectLimit(FourCC(R023), UNLIMITED)   ;//Spiritual Infusion
      f.ModObjectLimit(FourCC(Rosp), UNLIMITED)   ;//Spiked Barricades
      f.ModObjectLimit(FourCC(R06X), UNLIMITED)   ;//Magic Training
      f.ModObjectLimit(FourCC(R06Z), UNLIMITED)   ;//Herald Training



    }

  }
}
