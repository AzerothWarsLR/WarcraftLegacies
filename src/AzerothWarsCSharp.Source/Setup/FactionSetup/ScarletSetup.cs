using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class ScarletSetup{

  
    Faction FACTION_SCARLET
  

    public static void Setup( ){
      Faction f;
      FACTION_SCARLET = Faction.create("Militia", PLAYER_COLOR_MAROON, "|cff800000","ReplaceableTextures\\CommandButtons\\BTNPeasant.blp");
      f = FACTION_SCARLET;
      f.Team = TEAM_ALLIANCE;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC(h07X), UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC(h07Y), UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC(h07Z), UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC(h088), UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC(h080), UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC(h081), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(h06G), UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC(h083), UNLIMITED)   ;//Chapel
      f.ModObjectLimit(FourCC(h084), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC(h085), UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC(h087), UNLIMITED)   ;//Guard Tower (Improved)
      f.ModObjectLimit(FourCC(hshy), UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC(h086), UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC(h082), UNLIMITED)   ;//Aviary
      f.ModObjectLimit(FourCC(h097), UNLIMITED)   ;//Training Camp
      f.ModObjectLimit(FourCC(h09M), UNLIMITED)   ;//Training Camp 2
      f.ModObjectLimit(FourCC(h09N), UNLIMITED)   ;//Training Camp 3
      f.ModObjectLimit(FourCC(h09P), UNLIMITED)   ;//Training Camp 4
      f.ModObjectLimit(FourCC(h09O), UNLIMITED)   ;//Training Camp 5
      f.ModObjectLimit(FourCC(h09Q), UNLIMITED)   ;//Training Camp 6

      //Units
      f.ModObjectLimit(FourCC(hpea), UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC(hbot), 12) 	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC(hdes), 12) 	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC(hbsh), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC(h08I), UNLIMITED)   ;//Crusader
      f.ModObjectLimit(FourCC(h08M), UNLIMITED)   ;//Men-at-arms
      f.ModObjectLimit(FourCC(h095), UNLIMITED)   ;//Bowman
      f.ModObjectLimit(FourCC(h096), UNLIMITED)   ;//Light Cavalry
      f.ModObjectLimit(FourCC(h08L), UNLIMITED)   ;//Cavalier
      f.ModObjectLimit(FourCC(n068), UNLIMITED)   ;//Inquisitor
      f.ModObjectLimit(FourCC(h06B), 6)           ;//Templar
      f.ModObjectLimit(FourCC(h08J), UNLIMITED)   ;//Arbalest
      f.ModObjectLimit(FourCC(h08K), UNLIMITED)   ;//Chaplain
      f.ModObjectLimit(FourCC(n09N), 6)           ;//Bishop
      f.ModObjectLimit(FourCC(n07N), 6)           ;//Airship
      f.ModObjectLimit(FourCC(o04C), 6)           ;//Mortar
      f.ModObjectLimit(FourCC(o00X), 3)           ;//Archangel
      f.ModObjectLimit(FourCC(h09X), 12)           ;//Mounted Archer

      //Heroes
      f.ModObjectLimit(FourCC(H08G), 1)           ;//Saiden
      f.ModObjectLimit(FourCC(H08H), 1)           ;//Isilien
      f.ModObjectLimit(FourCC(H00Y), 1)           ;//Brigitte
      f.ModObjectLimit(FourCC(H0A2), 1)           ;//Renault
      f.ModObjectLimit(FourCC(H09Z), 1)           ;//Tirion

      f.ModObjectLimit(FourCC(h09H), 1)           ;//Herod
      f.ModObjectLimit(FourCC(h05W), 1)           ;//Isilien

      //Upgrades
      f.ModObjectLimit(FourCC(R05D), UNLIMITED)   ;//Chaplain Adept Training
      f.ModObjectLimit(FourCC(R04F), UNLIMITED)   ;//Inquisitor traiing
      f.ModObjectLimit(FourCC(R00K), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC(Rhse), UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC(Rhlh), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC(Rhac), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC(R06Q), UNLIMITED)   ;//Paladin Adept Training

    }

  }
}
