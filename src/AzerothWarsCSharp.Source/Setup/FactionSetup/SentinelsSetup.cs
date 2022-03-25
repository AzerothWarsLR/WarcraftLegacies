using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class SentinelsSetup{

  
    Faction FACTION_SENTINELS
  

    public static void Setup( ){
      Faction f;

      FACTION_SENTINELS = Faction.create("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80","ReplaceableTextures\\CommandButtons\\BTNPriestessOfTheMoon.blp");
      f = FACTION_SENTINELS;
      f.Team = TEAM_NIGHT_ELVES;
      f.UndefeatedResearch = FourCC("R05Y");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("e00V"), Faction.UNLIMITED)   ;//Temple of Elune
      f.ModObjectLimit(FourCC("e00R"), Faction.UNLIMITED)   ;//Altar of Watchers
      f.ModObjectLimit(FourCC("e00L"), Faction.UNLIMITED)   ;//War Academy
      f.ModObjectLimit(FourCC("edob"), Faction.UNLIMITED)   ;//Hunter)s Hall
      f.ModObjectLimit(FourCC("eden"), Faction.UNLIMITED)   ;//Ancient of Wonders
      f.ModObjectLimit(FourCC("e011"), Faction.UNLIMITED)   ;//Night Elf Shipyard
      f.ModObjectLimit(FourCC("h03N"), Faction.UNLIMITED)   ;//Enchanged Runestone
      f.ModObjectLimit(FourCC("h03M"), Faction.UNLIMITED)   ;//Runestone
      f.ModObjectLimit(FourCC("n06O"), Faction.UNLIMITED)   ;//Sentinel Embassy
      f.ModObjectLimit(FourCC("n06P"), Faction.UNLIMITED)   ;//Sentinel Enclave
      f.ModObjectLimit(FourCC("n06J"), Faction.UNLIMITED)   ;//Sentinel Outpost
      f.ModObjectLimit(FourCC("n06M"), Faction.UNLIMITED)   ;//Residence
      f.ModObjectLimit(FourCC("edos"), Faction.UNLIMITED)   ;//Roost
      f.ModObjectLimit(FourCC("e00T"), Faction.UNLIMITED)   ;//Bastion

      f.ModObjectLimit(FourCC("ewsp"), Faction.UNLIMITED)   ;//Wisp
      f.ModObjectLimit(FourCC("e006"), Faction.UNLIMITED)   ;//Priestess
      f.ModObjectLimit(FourCC("n06C"), Faction.UNLIMITED)   ;//Trapper
      f.ModObjectLimit(FourCC("h04L"), 6)           ;//Priestess of the Moon
      f.ModObjectLimit(FourCC("earc"), Faction.UNLIMITED)   ;//Archer
      f.ModObjectLimit(FourCC("esen"), Faction.UNLIMITED)   ;//Huntress
      f.ModObjectLimit(FourCC("h08V"), Faction.UNLIMITED)   ;//Nightsaber Knight
      f.ModObjectLimit(FourCC("ebal"), 8)           ;//Glaive Thrower
      f.ModObjectLimit(FourCC("ehpr"), 6)           ;//Hippogryph Rider
      f.ModObjectLimit(FourCC("n034"), 12)           ;//Guild Ranger
      f.ModObjectLimit(FourCC("nwat"), Faction.UNLIMITED)   ;//Nightblade
      f.ModObjectLimit(FourCC("etrs"), 12)   	    ;//Night Elf Transport Ship
      f.ModObjectLimit(FourCC("edes"), 12)  	    ;//Night Elf Frigate
      f.ModObjectLimit(FourCC("ebsh"), 6)          ;//Night Elf Battleship
      f.ModObjectLimit(FourCC("nnmg"), 12)          ;//Redeemed Highborne

      f.ModObjectLimit(FourCC("e009"), 1)           ;//Naisha
      f.ModObjectLimit(FourCC("Etyr"), 1)           ;//Tyrande
      f.ModObjectLimit(FourCC("E002"), 1)           ;//Shandris
      f.ModObjectLimit(FourCC("Ewrd"), 1)           ;//Maiev
      f.ModObjectLimit(FourCC("O02E"), 1)           ;//Jarod

      f.ModObjectLimit(FourCC("R00S"), Faction.UNLIMITED)   ;//Priestess Adept Training
      f.ModObjectLimit(FourCC("R064"), Faction.UNLIMITED)   ;//Sentinel Fortifications
      f.ModObjectLimit(FourCC("R01W"), Faction.UNLIMITED)   ;//Trapper Adept Training
      f.ModObjectLimit(FourCC("R026"), Faction.UNLIMITED)   ;//Elune)s Power Infusion
      f.ModObjectLimit(FourCC("Reib"), Faction.UNLIMITED)   ;//Improved Bows
      f.ModObjectLimit(FourCC("Reuv"), Faction.UNLIMITED)   ;//Ultravision
      f.ModObjectLimit(FourCC("Remg"), Faction.UNLIMITED)   ;//Upgraded Moon Glaive
      f.ModObjectLimit(FourCC("Roen"), Faction.UNLIMITED)   ;//Ensnare
      f.ModObjectLimit(FourCC("R04E"), Faction.UNLIMITED)   ;//Ysera)s Gift (World Tree upgrade)
      f.ModObjectLimit(FourCC("R002"), Faction.UNLIMITED)   ;//Blackwald Enhancement
      f.ModObjectLimit(FourCC("R03J"), Faction.UNLIMITED)   ;//Wind Walk
      f.ModObjectLimit(FourCC("R013"), Faction.UNLIMITED)   ;//Elune)s Blessing
    }

  }
}
