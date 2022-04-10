using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class ScarletSetup{
    public static Faction FactionScarlet { get; private set; }
    
    public static void Setup( ){
      Faction f;
      FactionScarlet = new Faction("Militia", PLAYER_COLOR_MAROON, "|cff800000","ReplaceableTextures\\CommandButtons\\BTNPeasant.blp");
      f = FactionScarlet;
      f.Team = TeamSetup.TeamAlliance;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h07X"), Faction.UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC("h07Y"), Faction.UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC("h07Z"), Faction.UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC("h088"), Faction.UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC("h080"), Faction.UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC("h081"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("h06G"), Faction.UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC("h083"), Faction.UNLIMITED)   ;//Chapel
      f.ModObjectLimit(FourCC("h084"), Faction.UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("h085"), Faction.UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC("h087"), Faction.UNLIMITED)   ;//Guard Tower (Improved)
      f.ModObjectLimit(FourCC("hshy"), Faction.UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC("h086"), Faction.UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC("h082"), Faction.UNLIMITED)   ;//Aviary
      f.ModObjectLimit(FourCC("h097"), Faction.UNLIMITED)   ;//Training Camp
      f.ModObjectLimit(FourCC("h09M"), Faction.UNLIMITED)   ;//Training Camp 2
      f.ModObjectLimit(FourCC("h09N"), Faction.UNLIMITED)   ;//Training Camp 3
      f.ModObjectLimit(FourCC("h09P"), Faction.UNLIMITED)   ;//Training Camp 4
      f.ModObjectLimit(FourCC("h09O"), Faction.UNLIMITED)   ;//Training Camp 5
      f.ModObjectLimit(FourCC("h09Q"), Faction.UNLIMITED)   ;//Training Camp 6

      //Units
      f.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC("hbot"), 12) 	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12) 	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("h08I"), Faction.UNLIMITED)   ;//Crusader
      f.ModObjectLimit(FourCC("h08M"), Faction.UNLIMITED)   ;//Men-at-arms
      f.ModObjectLimit(FourCC("h095"), Faction.UNLIMITED)   ;//Bowman
      f.ModObjectLimit(FourCC("h096"), Faction.UNLIMITED)   ;//Light Cavalry
      f.ModObjectLimit(FourCC("h08L"), Faction.UNLIMITED)   ;//Cavalier
      f.ModObjectLimit(FourCC("n068"), Faction.UNLIMITED)   ;//Inquisitor
      f.ModObjectLimit(FourCC("h06B"), 6)           ;//Templar
      f.ModObjectLimit(FourCC("h08J"), Faction.UNLIMITED)   ;//Arbalest
      f.ModObjectLimit(FourCC("h08K"), Faction.UNLIMITED)   ;//Chaplain
      f.ModObjectLimit(FourCC("n09N"), 6)           ;//Bishop
      f.ModObjectLimit(FourCC("n07N"), 6)           ;//Airship
      f.ModObjectLimit(FourCC("o04C"), 6)           ;//Mortar
      f.ModObjectLimit(FourCC("o00X"), 3)           ;//Archangel
      f.ModObjectLimit(FourCC("h09X"), 12)           ;//Mounted Archer

      //Heroes
      f.ModObjectLimit(FourCC("H08G"), 1)           ;//Saiden
      f.ModObjectLimit(FourCC("H08H"), 1)           ;//Isilien
      f.ModObjectLimit(FourCC("H00Y"), 1)           ;//Brigitte
      f.ModObjectLimit(FourCC("H0A2"), 1)           ;//Renault
      f.ModObjectLimit(FourCC("H09Z"), 1)           ;//Tirion

      f.ModObjectLimit(FourCC("h09H"), 1)           ;//Herod
      f.ModObjectLimit(FourCC("h05W"), 1)           ;//Isilien

      //Upgrades
      f.ModObjectLimit(FourCC("R05D"), Faction.UNLIMITED)   ;//Chaplain Adept Training
      f.ModObjectLimit(FourCC("R04F"), Faction.UNLIMITED)   ;//Inquisitor traiing
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC("R06Q"), Faction.UNLIMITED)   ;//Paladin Adept Training

    }

  }
}
