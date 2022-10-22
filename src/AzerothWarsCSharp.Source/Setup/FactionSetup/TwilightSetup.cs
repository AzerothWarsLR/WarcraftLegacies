using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Mechanics.TwilightHammer;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class TwilightSetup
  {
    public static Faction? TwilightsHammer { get; private set; }
    
    public static void Setup()
    {
      TwilightsHammer = new Faction("Twilight", PLAYER_COLOR_LAVENDER, "|cff9178a8",
        "ReplaceableTextures\\CommandButtons\\BTNChogall.blp")
      {
        StartingGold = 150,
        StartingLumber = 350,
        IntroText = @"You are playing as the fanatical |cffcd8ccdTwilight Hammer Clan|r.

You start isolated in the Twilight Highlands, the only way for an enemy to reach you is through the Dragonmaw Gate to the West, or the coast to the East.

The Dragonmaw Gate is invulnerable, whoever controls Grim Batol controls the gate. When the gate is opened, it will take seven minutes to be able to close it again."
      };

      TwilightsHammer.ModObjectLimit(FourCC("o039"), Faction.UNLIMITED); //Great Hall
      TwilightsHammer.ModObjectLimit(FourCC("o03A"), Faction.UNLIMITED); //Stronghold
      TwilightsHammer.ModObjectLimit(FourCC("o03B"), Faction.UNLIMITED); //Fortress
      TwilightsHammer.ModObjectLimit(FourCC("o03C"), Faction.UNLIMITED); //Altar of Storms
      TwilightsHammer.ModObjectLimit(FourCC("o03D"), Faction.UNLIMITED); //Barracks
      TwilightsHammer.ModObjectLimit(FourCC("o03J"), Faction.UNLIMITED); //War Mill
      TwilightsHammer.ModObjectLimit(FourCC("o03E"), Faction.UNLIMITED); //Spirit Lodge
      TwilightsHammer.ModObjectLimit(FourCC("o03F"), Faction.UNLIMITED); //Bestiary
      TwilightsHammer.ModObjectLimit(FourCC("o03I"), Faction.UNLIMITED); //Shipyard
      TwilightsHammer.ModObjectLimit(FourCC("o03G"), Faction.UNLIMITED); //Watch Tower
      TwilightsHammer.ModObjectLimit(FourCC("o03H"), Faction.UNLIMITED); //Improved Watch Tower
      TwilightsHammer.ModObjectLimit(FourCC("u00Y"), Faction.UNLIMITED); //Shop
      TwilightsHammer.ModObjectLimit(FourCC("o03K"), Faction.UNLIMITED); //Burrow

      TwilightsHammer.ModObjectLimit(FourCC("n051"), 4); //Black Drake
      TwilightsHammer.ModObjectLimit(FourCC("o04J"), 8); //WindRider
      TwilightsHammer.ModObjectLimit(FourCC("n07X"), Faction.UNLIMITED); //Fel Orc Warlock
      TwilightsHammer.ModObjectLimit(FourCC("o01H"), Faction.UNLIMITED); //Fel Orc Grunt
      TwilightsHammer.ModObjectLimit(FourCC("o04B"), Faction.UNLIMITED); //Fel Orc Peon
      TwilightsHammer.ModObjectLimit(FourCC("n083"), Faction.UNLIMITED); //Horde Cavarly
      TwilightsHammer.ModObjectLimit(FourCC("o04I"), 6); //Executioner
      TwilightsHammer.ModObjectLimit(FourCC("o04K"), 6); //Demolisher
      TwilightsHammer.ModObjectLimit(FourCC("n09O"), 6); //DK
      TwilightsHammer.ModObjectLimit(FourCC("u01T"), Faction.UNLIMITED); //Necrolyte
      TwilightsHammer.ModObjectLimit(FourCC("n087"), Faction.UNLIMITED); //Phase Grenadier
      TwilightsHammer.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      TwilightsHammer.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      TwilightsHammer.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      TwilightsHammer.ModObjectLimit(FourCC("O01P"), 1); //Chogall
      TwilightsHammer.ModObjectLimit(FourCC("H08Q"), 1); //Azil
      TwilightsHammer.ModObjectLimit(FourCC("U01S"), 1); //Feludius
      TwilightsHammer.ModObjectLimit(FourCC("O04H"), 1); //ignacius


      TwilightsHammer.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      TwilightsHammer.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      TwilightsHammer.ModObjectLimit(FourCC("R06X"), Faction.UNLIMITED); //Magic Training
      TwilightsHammer.ModObjectLimit(FourCC("R06Z"), Faction.UNLIMITED); //Herald Training

      var cultistUnitTypeIds = new[]
      {
        Constants.UNIT_N087_PHASE_GRENADIER_TWILIGHT,
        Constants.UNIT_O04B_CULTIST_TWILIGHT_HAMMER,
        Constants.UNIT_O01H_TWILIGHT_HAMMER_ENFORCER_TWILIGHT,
      };

      //Powers
      var power = new PowerCorruptWorker(30, Constants.ABILITY_A0BW_GLIMPSE_OF_THE_OLD_GODS_TWILIGHT, new[]
      {
        new Continent("Northern Eastern Kingdoms", Regions.Lordaeron_East),
        new Continent("Southern Eastern Kingdoms", Regions.Stormwind),
        new Continent("Kalimdor", Regions.Kalimdor),
        new Continent("Minor islands", Regions.KezanAmbient)
      }, cultistUnitTypeIds)
      {
        IconName = "OldGodWhispers"
      };
      TwilightsHammer.AddPower(power);

      FactionManager.Register(TwilightsHammer);
    }
  }
}