using System.Text;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class ScourgeSetup{

  
    public static Faction FactionScourge { get; private set; }
  

    public static void Setup( ){
      Faction f;

      FactionScourge = Faction.create("Scourge", PLAYER_COLOR_PURPLE, "|c00540081","ReplaceableTextures\\CommandButtons\\BTNRevenant.blp");
      f = FactionScourge;
      f.Team = TEAM_LEGION;
      f.UndefeatedResearch = FourCC("R05K");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Buildings
      f.ModObjectLimit(FourCC("unpl"), UNLIMITED)   ;//Necropolis
      f.ModObjectLimit(FourCC("unp1"), UNLIMITED)   ;//Halls of the Dead
      f.ModObjectLimit(FourCC("unp2"), UNLIMITED)   ;//Black Citadel
      f.ModObjectLimit(FourCC("uzig"), UNLIMITED)   ;//Ziggurat
      f.ModObjectLimit(FourCC("uzg1"), UNLIMITED)   ;//Spirit Tower
      f.ModObjectLimit(FourCC("uzg2"), UNLIMITED)   ;//Nerubian Tower
      f.ModObjectLimit(FourCC("uaod"), UNLIMITED)   ;//Altar of Darkness
      f.ModObjectLimit(FourCC("usep"), UNLIMITED)   ;//Crypt
      f.ModObjectLimit(FourCC("ugrv"), UNLIMITED)   ;//Graveyard
      f.ModObjectLimit(FourCC("uslh"), UNLIMITED)   ;//Slaughterhouse
      f.ModObjectLimit(FourCC("utod"), UNLIMITED)   ;//Temple of the Damned
      f.ModObjectLimit(FourCC("ubon"), UNLIMITED)   ;//Boneyard
      f.ModObjectLimit(FourCC("utom"), UNLIMITED)   ;//Tomb of Relics
      f.ModObjectLimit(FourCC("ushp"), UNLIMITED)   ;//Undead Shipyard
      f.ModObjectLimit(FourCC("u002"), UNLIMITED)   ;//Improved Spirit Tower
      f.ModObjectLimit(FourCC("u003"), UNLIMITED)   ;//Improved Nerubian Tower

      //Units
      f.ModObjectLimit(FourCC("uaco"), UNLIMITED)   ;//Acolyte
      f.ModObjectLimit(FourCC("ushd"), UNLIMITED)   ;//Shade
      f.ModObjectLimit(FourCC("ugho"), UNLIMITED)   ;//Ghoul
      f.ModObjectLimit(FourCC("uabo"), UNLIMITED)   ;//Abomination
      f.ModObjectLimit(FourCC("umtw"), 6)           ;//Meat Wagon
      f.ModObjectLimit(FourCC("ucry"), UNLIMITED)   ;//Crypt Fiend
      f.ModObjectLimit(FourCC("ugar"), 12)           ;//Gargoyle
      f.ModObjectLimit(FourCC("h02G"), UNLIMITED)   ;//Vrykul Warrior
      f.ModObjectLimit(FourCC("h061"), 12)           ;//Vrykul Champion
      f.ModObjectLimit(FourCC("h00P"), 4)           ;//Mammoth rider
      f.ModObjectLimit(FourCC("uban"), UNLIMITED)   ;//Banshee
      f.ModObjectLimit(FourCC("unec"), UNLIMITED)   ;//Necromancer
      f.ModObjectLimit(FourCC("uobs"), 4)           ;//Obsidian Statue
      f.ModObjectLimit(FourCC("ufro"), 4)           ;//Frost Wyrm
      f.ModObjectLimit(FourCC("h00H"), 6)           ;//Death Knight
      f.ModObjectLimit(FourCC("ubot"), 12)	    ;//Undead Transport Ship
      f.ModObjectLimit(FourCC("udes"), 12) 	    ;//Undead Frigate
      f.ModObjectLimit(FourCC("uubs"), 6)          ;//Undead Battleship
      f.ModObjectLimit(FourCC("ubsp"), 6)           ;//Destroyer
      f.ModObjectLimit(FourCC("nfgl"), 2)           ;//Plague Titan

      //Demi-Heroes
      f.ModObjectLimit(FourCC("ubdd"), 1)           ;//Sapphiron
      f.ModObjectLimit(FourCC("uswb"), 1)           ;//Banshee
      f.ModObjectLimit(FourCC("Uanb"), 1)           ;//Anubarak
      f.ModObjectLimit(FourCC("U001"), 1)           ;//Keltuzad
      f.ModObjectLimit(FourCC("U00M"), 1)           ;//Ghost
      f.ModObjectLimit(FourCC("U00A"), 1)           ;//Rivendare
      f.ModObjectLimit(FourCC("Uktl"), 1)           ;//Kel Lich

      //Upgrades
      f.ModObjectLimit(FourCC("Ruba"), UNLIMITED)   ;//Banshee Adept Training
      f.ModObjectLimit(FourCC("Rubu"), UNLIMITED)   ;//Burrow
      f.ModObjectLimit(FourCC("Ruex"), UNLIMITED)   ;//Exhume Corpses
      f.ModObjectLimit(FourCC("Rufb"), UNLIMITED)   ;//Freezing Breath
      f.ModObjectLimit(FourCC("Rugf"), UNLIMITED)   ;//Ghoul Frenzy
      f.ModObjectLimit(FourCC("Rune"), UNLIMITED)   ;//Necromancer Adept Training
      f.ModObjectLimit(FourCC("Ruwb"), UNLIMITED)   ;//Web
      f.ModObjectLimit(FourCC("R02A"), UNLIMITED)   ;//Chaos Infusion
      f.ModObjectLimit(FourCC("R00Q"), UNLIMITED)   ;//Chilling Aura
      f.ModObjectLimit(FourCC("R04V"), UNLIMITED)   ;//Improved Hypothermic Breath
      f.ModObjectLimit(FourCC("R01X"), UNLIMITED)   ;//Epidemic
      f.ModObjectLimit(FourCC("R01D"), UNLIMITED)   ;//Piercing Screech
      f.ModObjectLimit(FourCC("R06N"), UNLIMITED)   ;//Improved Orb of Annihilation
      f.ModObjectLimit(FourCC("Rusl"), UNLIMITED)   ;//SkeletalMastery
      f.ModObjectLimit(FourCC("Rusm"), UNLIMITED)   ;//SkeletalLongevity
    }

  }
}
