using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class ScarletSetup
  {
    public static Faction FactionScarlet { get; private set; }

    public static void Setup()
    {
      FactionScarlet = new Faction("Militia", PLAYER_COLOR_MAROON, "|cff800000",
        "ReplaceableTextures\\CommandButtons\\BTNPeasant.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        IntroText = @"You are playing as the zealous |cff940000Scarlet Crusade|r.

The Cult of the Damned has mobilized and is quietly spreading corruption throughout Lordaeron.

Build towers to detect the hidden cultists moving through the Kingdom and burn any buildings they have corrupted.

Your soldiers are weaker when alone, but gain substantial bonuses when paired with a variety of unit-types. 

Fortify your strongholds against the storm to come and make ready to unleash the Crusade on those who would defile your lands."
      };

      //Structures
      FactionScarlet.ModObjectLimit(FourCC("h07X"), Faction.UNLIMITED); //Town Hall
      FactionScarlet.ModObjectLimit(FourCC("h07Y"), Faction.UNLIMITED); //Keep
      FactionScarlet.ModObjectLimit(FourCC("h07Z"), Faction.UNLIMITED); //Castle
      FactionScarlet.ModObjectLimit(FourCC("h088"), Faction.UNLIMITED); //Farm
      FactionScarlet.ModObjectLimit(FourCC("h080"), Faction.UNLIMITED); //Altar of Kings
      FactionScarlet.ModObjectLimit(FourCC("h081"), Faction.UNLIMITED); //Barracks
      FactionScarlet.ModObjectLimit(FourCC("h06G"), Faction.UNLIMITED); //Blacksmith
      FactionScarlet.ModObjectLimit(FourCC("h083"), Faction.UNLIMITED); //Chapel
      FactionScarlet.ModObjectLimit(FourCC("h084"), Faction.UNLIMITED); //Scout Tower
      FactionScarlet.ModObjectLimit(FourCC("h085"), Faction.UNLIMITED); //Guard Tower
      FactionScarlet.ModObjectLimit(FourCC("h087"), Faction.UNLIMITED); //Guard Tower (Improved)
      FactionScarlet.ModObjectLimit(FourCC("hshy"), Faction.UNLIMITED); //Alliance Shipyard
      FactionScarlet.ModObjectLimit(FourCC("h086"), Faction.UNLIMITED); //Marketplace
      FactionScarlet.ModObjectLimit(FourCC("h082"), Faction.UNLIMITED); //Aviary
      FactionScarlet.ModObjectLimit(FourCC("h097"), Faction.UNLIMITED); //Training Camp
      FactionScarlet.ModObjectLimit(FourCC("h09M"), Faction.UNLIMITED); //Training Camp 2
      FactionScarlet.ModObjectLimit(FourCC("h09N"), Faction.UNLIMITED); //Training Camp 3
      FactionScarlet.ModObjectLimit(FourCC("h09P"), Faction.UNLIMITED); //Training Camp 4
      FactionScarlet.ModObjectLimit(FourCC("h09O"), Faction.UNLIMITED); //Training Camp 5
      FactionScarlet.ModObjectLimit(FourCC("h09Q"), Faction.UNLIMITED); //Training Camp 6

      //Units
      FactionScarlet.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      FactionScarlet.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FactionScarlet.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FactionScarlet.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      FactionScarlet.ModObjectLimit(FourCC("h08I"), Faction.UNLIMITED); //Crusader
      FactionScarlet.ModObjectLimit(FourCC("h08M"), Faction.UNLIMITED); //Men-at-arms
      FactionScarlet.ModObjectLimit(FourCC("h095"), Faction.UNLIMITED); //Bowman
      FactionScarlet.ModObjectLimit(FourCC("h096"), Faction.UNLIMITED); //Light Cavalry
      FactionScarlet.ModObjectLimit(FourCC("h08L"), Faction.UNLIMITED); //Cavalier
      FactionScarlet.ModObjectLimit(FourCC("n068"), Faction.UNLIMITED); //Inquisitor
      FactionScarlet.ModObjectLimit(FourCC("h06B"), 6); //Templar
      FactionScarlet.ModObjectLimit(FourCC("h08J"), Faction.UNLIMITED); //Arbalest
      FactionScarlet.ModObjectLimit(FourCC("h08K"), Faction.UNLIMITED); //Chaplain
      FactionScarlet.ModObjectLimit(FourCC("n09N"), 6); //Bishop
      FactionScarlet.ModObjectLimit(FourCC("n07N"), 6); //Airship
      FactionScarlet.ModObjectLimit(FourCC("o04C"), 6); //Mortar
      FactionScarlet.ModObjectLimit(FourCC("o00X"), 3); //Archangel
      FactionScarlet.ModObjectLimit(FourCC("h09X"), 12); //Mounted Archer

      //Heroes
      FactionScarlet.ModObjectLimit(FourCC("H08G"), 1); //Saiden
      FactionScarlet.ModObjectLimit(FourCC("H08H"), 1); //Isilien
      FactionScarlet.ModObjectLimit(FourCC("H00Y"), 1); //Brigitte
      FactionScarlet.ModObjectLimit(FourCC("H0A2"), 1); //Renault
      FactionScarlet.ModObjectLimit(FourCC("H09Z"), 1); //Tirion

      FactionScarlet.ModObjectLimit(FourCC("h09H"), 1); //Herod
      FactionScarlet.ModObjectLimit(FourCC("h05W"), 1); //Isilien

      //Upgrades
      FactionScarlet.ModObjectLimit(FourCC("R05D"), Faction.UNLIMITED); //Chaplain Adept Training
      FactionScarlet.ModObjectLimit(FourCC("R04F"), Faction.UNLIMITED); //Inquisitor traiing
      FactionScarlet.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      FactionScarlet.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      FactionScarlet.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      FactionScarlet.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      FactionScarlet.ModObjectLimit(FourCC("R06Q"), Faction.UNLIMITED); //Paladin Adept Training

      FactionManager.Register(FactionScarlet);
    }
  }
}