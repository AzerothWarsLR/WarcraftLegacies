using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class NagaSetup{
  
    Faction FACTION_NAGA
  

    public static void Setup( ){
      Faction f;

      FACTION_NAGA = Faction.create("Illidan", PLAYER_COLOR_VIOLET, "|cffff00ff","ReplaceableTextures\\CommandButtons\\BTNEvilIllidan.blp");
      f = FACTION_NAGA;
      f.Team = TEAM_NAGA;
      f.UndefeatedResearch = FourCC(R02L);
      f.StartingGold = 0;
      f.StartingLumber = 2500;

      f.ModObjectLimit(FourCC(nntt), UNLIMITED)   ;//Pillar of Waves
      f.ModObjectLimit(FourCC(n04T), UNLIMITED)   ;//Monument of Currents
      f.ModObjectLimit(FourCC(n055), UNLIMITED)   ;//Temple of Tides
      f.ModObjectLimit(FourCC(nnad), UNLIMITED)   ;//Altar of the Depths
      f.ModObjectLimit(FourCC(nnsg), UNLIMITED)   ;//Spawning Grounds
      f.ModObjectLimit(FourCC(h06S), UNLIMITED)   ;//Coral Forge
      f.ModObjectLimit(FourCC(n0A3), UNLIMITED)   ;//Royal Pyramid
      f.ModObjectLimit(FourCC(nnsa), UNLIMITED)   ;//Temple of Azshara
      f.ModObjectLimit(FourCC(nnfm), UNLIMITED)   ;//Coral Beds
      f.ModObjectLimit(FourCC(nntg), UNLIMITED)   ;//Tidal Guardian
      f.ModObjectLimit(FourCC(n005), UNLIMITED)   ;//Improved Tidal Guardian
      f.ModObjectLimit(FourCC(nmrb), UNLIMITED)   ;//Deep Sea Vault

      f.ModObjectLimit(FourCC(nmpe), UNLIMITED)   ;//Mur)gul Slave
      f.ModObjectLimit(FourCC(nmyr), UNLIMITED)   ;//Myrmidon
      f.ModObjectLimit(FourCC(nsnp), UNLIMITED)   ;//Snap Dragon
      f.ModObjectLimit(FourCC(nnsw), UNLIMITED)   ;//Siren
      f.ModObjectLimit(FourCC(nmsc), UNLIMITED)   ;//Shadowcaster
      f.ModObjectLimit(FourCC(nnsu), 6)           ;//Summoner
      f.ModObjectLimit(FourCC(nnrg), 6)           ;//Royal Guard
      f.ModObjectLimit(FourCC(nhyc), 8)           ;//Dragon Turtle
      f.ModObjectLimit(FourCC(nwgs), 8)   	    ;//Couatl
      f.ModObjectLimit(FourCC(e00Y), 4)  	    ;//Scylla

      f.ModObjectLimit(FourCC(Hvsh), 1)  	    ;//Vashj
      f.ModObjectLimit(FourCC(U00S), 1)  	    ;//Najentus
      f.ModObjectLimit(FourCC(Naka), 1)  	    ;//Akama
      f.ModObjectLimit(FourCC(E015), 1)  	    ;//Akama
      f.ModObjectLimit(FourCC(Eevi), 1)  	    ;//Illidan

      f.ModObjectLimit(FourCC(R062), UNLIMITED)   ;//Redemption path
      f.ModObjectLimit(FourCC(R063), UNLIMITED)   ;//Exile Path
      f.ModObjectLimit(FourCC(R065), UNLIMITED)   ;//Madness Path

    }

  }
}
