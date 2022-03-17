public class SentinelsSetup{

  
    Faction FACTION_SENTINELS
  

  public static void OnInit( ){
    Faction f;

    FACTION_SENTINELS = Faction.create("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80","ReplaceableTextures\\CommandButtons\\BTNPriestessOfTheMoon.blp");
    f = FACTION_SENTINELS;
    f.Team = TEAM_NIGHT_ELVES;
    f.UndefeatedResearch = FourCC(R05Y);
    f.StartingGold = 150;
    f.StartingLumber = 500;

    f.ModObjectLimit(FourCC(e00V), UNLIMITED)   ;//Temple of Elune
    f.ModObjectLimit(FourCC(e00R), UNLIMITED)   ;//Altar of Watchers
    f.ModObjectLimit(FourCC(e00L), UNLIMITED)   ;//War Academy
    f.ModObjectLimit(FourCC(edob), UNLIMITED)   ;//Hunter)s Hall
    f.ModObjectLimit(FourCC(eden), UNLIMITED)   ;//Ancient of Wonders
    f.ModObjectLimit(FourCC(e011), UNLIMITED)   ;//Night Elf Shipyard
    f.ModObjectLimit(FourCC(h03N), UNLIMITED)   ;//Enchanged Runestone
    f.ModObjectLimit(FourCC(h03M), UNLIMITED)   ;//Runestone
    f.ModObjectLimit(FourCC(n06O), UNLIMITED)   ;//Sentinel Embassy
    f.ModObjectLimit(FourCC(n06P), UNLIMITED)   ;//Sentinel Enclave
    f.ModObjectLimit(FourCC(n06J), UNLIMITED)   ;//Sentinel Outpost
    f.ModObjectLimit(FourCC(n06M), UNLIMITED)   ;//Residence
    f.ModObjectLimit(FourCC(edos), UNLIMITED)   ;//Roost
    f.ModObjectLimit(FourCC(e00T), UNLIMITED)   ;//Bastion

    f.ModObjectLimit(FourCC(ewsp), UNLIMITED)   ;//Wisp
    f.ModObjectLimit(FourCC(e006), UNLIMITED)   ;//Priestess
    f.ModObjectLimit(FourCC(n06C), UNLIMITED)   ;//Trapper
    f.ModObjectLimit(FourCC(h04L), 6)           ;//Priestess of the Moon
    f.ModObjectLimit(FourCC(earc), UNLIMITED)   ;//Archer
    f.ModObjectLimit(FourCC(esen), UNLIMITED)   ;//Huntress
    f.ModObjectLimit(FourCC(h08V), UNLIMITED)   ;//Nightsaber Knight
    f.ModObjectLimit(FourCC(ebal), 8)           ;//Glaive Thrower
    f.ModObjectLimit(FourCC(ehpr), 6)           ;//Hippogryph Rider
    f.ModObjectLimit(FourCC(n034), 12)           ;//Guild Ranger
    f.ModObjectLimit(FourCC(nwat), UNLIMITED)   ;//Nightblade
    f.ModObjectLimit(FourCC(etrs), 12)   	    ;//Night Elf Transport Ship
    f.ModObjectLimit(FourCC(edes), 12)  	    ;//Night Elf Frigate
    f.ModObjectLimit(FourCC(ebsh), 6)          ;//Night Elf Battleship
    f.ModObjectLimit(FourCC(nnmg), 12)          ;//Redeemed Highborne

    f.ModObjectLimit(FourCC(e009), 1)           ;//Naisha
    f.ModObjectLimit(FourCC(Etyr), 1)           ;//Tyrande
    f.ModObjectLimit(FourCC(E002), 1)           ;//Shandris
    f.ModObjectLimit(FourCC(Ewrd), 1)           ;//Maiev
    f.ModObjectLimit(FourCC(O02E), 1)           ;//Jarod

    f.ModObjectLimit(FourCC(R00S), UNLIMITED)   ;//Priestess Adept Training
    f.ModObjectLimit(FourCC(R064), UNLIMITED)   ;//Sentinel Fortifications
    f.ModObjectLimit(FourCC(R01W), UNLIMITED)   ;//Trapper Adept Training
    f.ModObjectLimit(FourCC(R026), UNLIMITED)   ;//Elune)s Power Infusion
    f.ModObjectLimit(FourCC(Reib), UNLIMITED)   ;//Improved Bows
    f.ModObjectLimit(FourCC(Reuv), UNLIMITED)   ;//Ultravision
    f.ModObjectLimit(FourCC(Remg), UNLIMITED)   ;//Upgraded Moon Glaive
    f.ModObjectLimit(FourCC(Roen), UNLIMITED)   ;//Ensnare
    f.ModObjectLimit(FourCC(R04E), UNLIMITED)   ;//Ysera)s Gift (World Tree upgrade)
    f.ModObjectLimit(FourCC(R002), UNLIMITED)   ;//Blackwald Enhancement
    f.ModObjectLimit(FourCC(R03J), UNLIMITED)   ;//Wind Walk
    f.ModObjectLimit(FourCC(R013), UNLIMITED)   ;//Elune)s Blessing
  }

}
