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
      f.Team = TeamSetup.TeamLegion;
      f.UndefeatedResearch = FourCC("R05K");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Buildings
      f.ModObjectLimit(FourCC("unpl"), Faction.UNLIMITED)   ;//Necropolis
      f.ModObjectLimit(FourCC("unp1"), Faction.UNLIMITED)   ;//Halls of the Dead
      f.ModObjectLimit(FourCC("unp2"), Faction.UNLIMITED)   ;//Black Citadel
      f.ModObjectLimit(FourCC("uzig"), Faction.UNLIMITED)   ;//Ziggurat
      f.ModObjectLimit(FourCC("uzg1"), Faction.UNLIMITED)   ;//Spirit Tower
      f.ModObjectLimit(FourCC("uzg2"), Faction.UNLIMITED)   ;//Nerubian Tower
      f.ModObjectLimit(FourCC("uaod"), Faction.UNLIMITED)   ;//Altar of Darkness
      f.ModObjectLimit(FourCC("usep"), Faction.UNLIMITED)   ;//Crypt
      f.ModObjectLimit(FourCC("ugrv"), Faction.UNLIMITED)   ;//Graveyard
      f.ModObjectLimit(FourCC("uslh"), Faction.UNLIMITED)   ;//Slaughterhouse
      f.ModObjectLimit(FourCC("utod"), Faction.UNLIMITED)   ;//Temple of the Damned
      f.ModObjectLimit(FourCC("ubon"), Faction.UNLIMITED)   ;//Boneyard
      f.ModObjectLimit(FourCC("utom"), Faction.UNLIMITED)   ;//Tomb of Relics
      f.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED)   ;//Undead Shipyard
      f.ModObjectLimit(FourCC("u002"), Faction.UNLIMITED)   ;//Improved Spirit Tower
      f.ModObjectLimit(FourCC("u003"), Faction.UNLIMITED)   ;//Improved Nerubian Tower

      //Units
      f.ModObjectLimit(FourCC("uaco"), Faction.UNLIMITED)   ;//Acolyte
      f.ModObjectLimit(FourCC("ushd"), Faction.UNLIMITED)   ;//Shade
      f.ModObjectLimit(FourCC("ugho"), Faction.UNLIMITED)   ;//Ghoul
      f.ModObjectLimit(FourCC("uabo"), Faction.UNLIMITED)   ;//Abomination
      f.ModObjectLimit(FourCC("umtw"), 6)           ;//Meat Wagon
      f.ModObjectLimit(FourCC("ucry"), Faction.UNLIMITED)   ;//Crypt Fiend
      f.ModObjectLimit(FourCC("ugar"), 12)           ;//Gargoyle
      f.ModObjectLimit(FourCC("h02G"), Faction.UNLIMITED)   ;//Vrykul Warrior
      f.ModObjectLimit(FourCC("h061"), 12)           ;//Vrykul Champion
      f.ModObjectLimit(FourCC("h00P"), 4)           ;//Mammoth rider
      f.ModObjectLimit(FourCC("uban"), Faction.UNLIMITED)   ;//Banshee
      f.ModObjectLimit(FourCC("unec"), Faction.UNLIMITED)   ;//Necromancer
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
      f.ModObjectLimit(FourCC("Ruba"), Faction.UNLIMITED)   ;//Banshee Adept Training
      f.ModObjectLimit(FourCC("Rubu"), Faction.UNLIMITED)   ;//Burrow
      f.ModObjectLimit(FourCC("Ruex"), Faction.UNLIMITED)   ;//Exhume Corpses
      f.ModObjectLimit(FourCC("Rufb"), Faction.UNLIMITED)   ;//Freezing Breath
      f.ModObjectLimit(FourCC("Rugf"), Faction.UNLIMITED)   ;//Ghoul Frenzy
      f.ModObjectLimit(FourCC("Rune"), Faction.UNLIMITED)   ;//Necromancer Adept Training
      f.ModObjectLimit(FourCC("Ruwb"), Faction.UNLIMITED)   ;//Web
      f.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED)   ;//Chaos Infusion
      f.ModObjectLimit(FourCC("R00Q"), Faction.UNLIMITED)   ;//Chilling Aura
      f.ModObjectLimit(FourCC("R04V"), Faction.UNLIMITED)   ;//Improved Hypothermic Breath
      f.ModObjectLimit(FourCC("R01X"), Faction.UNLIMITED)   ;//Epidemic
      f.ModObjectLimit(FourCC("R01D"), Faction.UNLIMITED)   ;//Piercing Screech
      f.ModObjectLimit(FourCC("R06N"), Faction.UNLIMITED)   ;//Improved Orb of Annihilation
      f.ModObjectLimit(FourCC("Rusl"), Faction.UNLIMITED)   ;//SkeletalMastery
      f.ModObjectLimit(FourCC("Rusm"), Faction.UNLIMITED)   ;//SkeletalLongevity
    }

  }
}
