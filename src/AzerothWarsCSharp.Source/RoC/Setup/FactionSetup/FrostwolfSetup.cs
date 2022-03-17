using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class FrostwolfSetup{

  
    Faction FACTION_FROSTWOLF
  

    public static void OnInit( ){
      Faction f;
      FACTION_FROSTWOLF = Faction.create("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303","ReplaceableTextures\\CommandButtons\\BTNThrall.blp");
      f = FACTION_FROSTWOLF;
      f.Team = TEAM_HORDE;
      f.UndefeatedResearch = FourCC(R05V);
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC(ogre), UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC(ostr), UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC(ofrt), UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC(oalt), UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC(obar), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(ofor), UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC(otto), UNLIMITED)   ;//Tauren Totem
      f.ModObjectLimit(FourCC(osld), UNLIMITED)   ;//Spirit Lodge
      f.ModObjectLimit(FourCC(otrb), UNLIMITED)   ;//Orc Burrow
      f.ModObjectLimit(FourCC(owtw), UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC(o002), UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC(ovln), UNLIMITED)   ;//Voodoo Lounge
      f.ModObjectLimit(FourCC(oshy), UNLIMITED)   ;//Shipyard

      f.ModObjectLimit(FourCC(opeo), UNLIMITED)   ;//Peon
      f.ModObjectLimit(FourCC(ogru), UNLIMITED)   ;//Grunt
      f.ModObjectLimit(FourCC(otau), UNLIMITED)   ;//Tauren
      f.ModObjectLimit(FourCC(ohun), UNLIMITED)   ;//Troll Headhunter
      f.ModObjectLimit(FourCC(ocat), 6)           ;//Catapult
      f.ModObjectLimit(FourCC(otbr), 12)          ;//Troll Batrider
      f.ModObjectLimit(FourCC(odoc), UNLIMITED)   ;//Troll Witch Doctor
      f.ModObjectLimit(FourCC(oshm), UNLIMITED)   ;//Shaman
      f.ModObjectLimit(FourCC(ospw), UNLIMITED)   ;//Spirit Walker
      f.ModObjectLimit(FourCC(o00A), 6)           ;//Far Seer
      f.ModObjectLimit(FourCC(obot), 12)  	    ;//Transport Ship
      f.ModObjectLimit(FourCC(odes), 12)  	    ;//Orc Frigate
      f.ModObjectLimit(FourCC(oosc), UNLIMITED)   ;//Pack Kodo
      f.ModObjectLimit(FourCC(ojgn), 6)          ;//Juggernaught

      f.ModObjectLimit(FourCC(h00C), 1)           ;//Drek)thar
      f.ModObjectLimit(FourCC(Othr), 1)           ;//Thrall
      f.ModObjectLimit(FourCC(Ocbh), 1)           ;//Cairne
      f.ModObjectLimit(FourCC(Orkn), 1)           ;//Voljin
      f.ModObjectLimit(FourCC(Orex), 1)           ;//Rexxar

      f.ModObjectLimit(FourCC(Rows), UNLIMITED)   ;//Improved Pulverize
      f.ModObjectLimit(FourCC(Rost), UNLIMITED)   ;//Shaman Adept Training
      f.ModObjectLimit(FourCC(Rowd), UNLIMITED)   ;//Witch Doctor Adept Training
      f.ModObjectLimit(FourCC(Rowt), UNLIMITED)   ;//Spirit Walker Adept Training
      f.ModObjectLimit(FourCC(R023), UNLIMITED)   ;//Spiritual Infusion
      f.ModObjectLimit(FourCC(Rolf), UNLIMITED)   ;//Liquid Fire
      f.ModObjectLimit(FourCC(Rosp), UNLIMITED)   ;//Spiked Barricades
      f.ModObjectLimit(FourCC(Rorb), UNLIMITED)   ;//reinforced Defenses
      f.ModObjectLimit(FourCC(R00H), UNLIMITED)   ;//Animal Companion
      f.ModObjectLimit(FourCC(R00R), UNLIMITED)   ;//Improved Chain Lightning
      f.ModObjectLimit(FourCC(R00W), UNLIMITED)   ;//Toughened Hides
      f.ModObjectLimit(FourCC(R01Z), UNLIMITED)   ;//Battle Stations
      f.SetObjectLevel(FourCC(R01Z), 1)                ;//Battle Stations
    }

  }
}
