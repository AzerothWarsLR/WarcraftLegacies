public class FelHordeSetup{

  
    Faction FACTION_FEL_HORDE
  

  public static void OnInit( ){
    Faction f;

    FACTION_FEL_HORDE = Faction.create("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000","ReplaceableTextures\\CommandButtons\\BTNPitLord.blp");
    f = FACTION_FEL_HORDE;
    f.Team = TEAM_LEGION;
    f.UndefeatedResearch = FourCC(R05L);
    f.StartingGold = 300;
    f.StartingLumber = 600;

    f.ModObjectLimit(FourCC(o02Y), UNLIMITED)   ;//Great Hall
    f.ModObjectLimit(FourCC(o02Z), UNLIMITED)   ;//Stronghold
    f.ModObjectLimit(FourCC(o030), UNLIMITED)   ;//Fortress
    f.ModObjectLimit(FourCC(o02V), UNLIMITED)   ;//Altar of Storms
    f.ModObjectLimit(FourCC(o02W), UNLIMITED)   ;//Barracks
    f.ModObjectLimit(FourCC(o031), UNLIMITED)   ;//War Mill
    f.ModObjectLimit(FourCC(o033), UNLIMITED)   ;//Spirit Lodge
    f.ModObjectLimit(FourCC(o02X), UNLIMITED)   ;//Bestiary
    f.ModObjectLimit(FourCC(o032), UNLIMITED)   ;//Shipyard
    f.ModObjectLimit(FourCC(o034), UNLIMITED)   ;//Watch Tower
    f.ModObjectLimit(FourCC(o035), UNLIMITED)   ;//Improved Watch Tower
    f.ModObjectLimit(FourCC(u00Q), UNLIMITED)   ;//Hellforge
    f.ModObjectLimit(FourCC(n0AM), UNLIMITED)   ;//Boulder Tower
    f.ModObjectLimit(FourCC(n0AN), UNLIMITED)   ;//Advanced Boulder Tower
    f.ModObjectLimit(FourCC(ocbw), UNLIMITED)   ;//Burrow
    f.ModObjectLimit(FourCC(n0AP), UNLIMITED)   ;//Focal Demon Gate

    f.ModObjectLimit(FourCC(nbdk), 6)           ;//Black Drake
    f.ModObjectLimit(FourCC(odkt), 6)           ;//Eredar Warlock
    f.ModObjectLimit(FourCC(nchw), UNLIMITED)   ;//Fel Orc Warlock
    f.ModObjectLimit(FourCC(nchg), UNLIMITED)   ;//Fel Orc Grunt
    f.ModObjectLimit(FourCC(nchr), UNLIMITED)   ;//Fel Orc Raider
    f.ModObjectLimit(FourCC(ncpn), UNLIMITED)   ;//Fel Orc Peon
    f.ModObjectLimit(FourCC(owar), UNLIMITED)   ;//Horde Cavarly
    f.ModObjectLimit(FourCC(o01L), 6)           ;//Executioner
    f.ModObjectLimit(FourCC(o01O), 8)           ;//Demolisher
    f.ModObjectLimit(FourCC(u018), 10)          ;//Eye of Grillok
    f.ModObjectLimit(FourCC(u00V), UNLIMITED)   ;//Necrolyte
    f.ModObjectLimit(FourCC(n057), -UNLIMITED)  ;//Nether Dragon Hatchling
    f.ModObjectLimit(FourCC(n058), UNLIMITED)   ;//Troll Axethrowers
    f.ModObjectLimit(FourCC(obot), 12)  	    ;//Transport Ship
    f.ModObjectLimit(FourCC(odes), 12)  	    ;//Orc Frigate
    f.ModObjectLimit(FourCC(ojgn), 6)          ;//Juggernaught

    f.ModObjectLimit(FourCC(n05T), 1)           ;//Kazzak
    f.ModObjectLimit(FourCC(n064), 1)           ;//Voone
    f.ModObjectLimit(FourCC(n08A), 1)           ;//neltharaktu
    f.ModObjectLimit(FourCC(Nmag), 1)           ;//Magtheridon
    f.ModObjectLimit(FourCC(N03D), 1)           ;//Kargath
    f.ModObjectLimit(FourCC(Nbbc), 1)           ;//Rend
    f.ModObjectLimit(FourCC(U02D), 1)           ;//Teron

    f.ModObjectLimit(FourCC(Robf), UNLIMITED)   ;//Demonic Flux
    f.ModObjectLimit(FourCC(R066), UNLIMITED)   ;//Burning Oil
    f.ModObjectLimit(FourCC(R00O), UNLIMITED)   ;//Ensnare
    f.ModObjectLimit(FourCC(Rorb), UNLIMITED)   ;//Reinforced Defenses
    f.ModObjectLimit(FourCC(Rosp), UNLIMITED)   ;//Spiked Barricades
    f.ModObjectLimit(FourCC(R023), UNLIMITED)   ;//Spiritual Infusion
    f.ModObjectLimit(FourCC(R000), -UNLIMITED)  ;//Skeletal Perserverance
    f.ModObjectLimit(FourCC(R024), UNLIMITED)   ;//Necrolyte adept Training
    f.ModObjectLimit(FourCC(R00M), UNLIMITED)   ;//Warlock Adept Training
    f.ModObjectLimit(FourCC(R03I), UNLIMITED)   ;//Eredar Warlock Adept Training
    f.ModObjectLimit(FourCC(R00Y), UNLIMITED)   ;//Improved Self-Bloodlust
    f.ModObjectLimit(FourCC(R03L), UNLIMITED)   ;//Improved Shadow Infusion
    f.ModObjectLimit(FourCC(R036), UNLIMITED)   ;//Incinerate
    f.ModObjectLimit(FourCC(R02L), UNLIMITED)   ;//Bloodcraze
    f.ModObjectLimit(FourCC(R03O), UNLIMITED)   ;//Bloodcraze
    f.ModObjectLimit(FourCC(R034), UNLIMITED)   ;//Enhanced Breath
    f.ModObjectLimit(FourCC(R035), UNLIMITED)   ;//Improved Firebolt
    f.ModObjectLimit(FourCC(R01Z), UNLIMITED)   ;//Battle Stations
    f.SetObjectLevel(FourCC(R01Z), 1)                ;//Battle Stations


    f.ModObjectLimit(FourCC(n05R), 1)           ;//Felguard
    f.ModObjectLimit(FourCC(n06H), 1)           ;//Pit Fiend
    f.ModObjectLimit(FourCC(n07B), 1)           ;//Queen
    f.ModObjectLimit(FourCC(n07D), 1)           ;//Maiden
    f.ModObjectLimit(FourCC(n07o), 1)           ;//Terror
    f.ModObjectLimit(FourCC(n07N), 1)           ;//Lord


  }

}
