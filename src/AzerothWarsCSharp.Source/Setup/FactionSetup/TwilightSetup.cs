using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Mechanics.TwilightHammer;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class TwilightSetup
  {
    public static Faction FACTION_TWILIGHT { get; private set; }
    
    public static void Setup()
    {
      FACTION_TWILIGHT = new Faction("Twilight", PLAYER_COLOR_LAVENDER, "|cff9178a8",
        "ReplaceableTextures\\CommandButtons\\BTNChogall.blp")
      {
        StartingGold = 150,
        StartingLumber = 350,
        IntroText = @"You are playing as the fanatical |cffcd8ccdTwilight Hammer Clan|r.

        You start isolated in the Twilight Highlands, the only way for an enemy to reach you is through the Dragonmaw Gate to the West, or the coast to the East.

        The Dragonmaw Gate is invulnerable, whoever controls Grim Batol controls the gate. When the gate is opened, it will take seven minutes to be able to close it again."
      };

      FACTION_TWILIGHT.ModObjectLimit(FourCC("o039"), Faction.UNLIMITED); //Great Hall
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03A"), Faction.UNLIMITED); //Stronghold
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03B"), Faction.UNLIMITED); //Fortress
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03C"), Faction.UNLIMITED); //Altar of Storms
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03D"), Faction.UNLIMITED); //Barracks
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03J"), Faction.UNLIMITED); //War Mill
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03E"), Faction.UNLIMITED); //Spirit Lodge
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03F"), Faction.UNLIMITED); //Bestiary
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03I"), Faction.UNLIMITED); //Shipyard
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03G"), Faction.UNLIMITED); //Watch Tower
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03H"), Faction.UNLIMITED); //Improved Watch Tower
      FACTION_TWILIGHT.ModObjectLimit(FourCC("u00Y"), Faction.UNLIMITED); //Shop
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o03K"), Faction.UNLIMITED); //Burrow

      FACTION_TWILIGHT.ModObjectLimit(FourCC("n051"), 4); //Black Drake
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o04J"), 8); //WindRider
      FACTION_TWILIGHT.ModObjectLimit(FourCC("n07X"), Faction.UNLIMITED); //Fel Orc Warlock
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o01H"), Faction.UNLIMITED); //Fel Orc Grunt
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o04B"), Faction.UNLIMITED); //Fel Orc Peon
      FACTION_TWILIGHT.ModObjectLimit(FourCC("n083"), Faction.UNLIMITED); //Horde Cavarly
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o04I"), 6); //Executioner
      FACTION_TWILIGHT.ModObjectLimit(FourCC("o04K"), 6); //Demolisher
      FACTION_TWILIGHT.ModObjectLimit(FourCC("n09O"), 6); //DK
      FACTION_TWILIGHT.ModObjectLimit(FourCC("u01T"), Faction.UNLIMITED); //Necrolyte
      FACTION_TWILIGHT.ModObjectLimit(FourCC("n087"), Faction.UNLIMITED); //Phase Grenadier
      FACTION_TWILIGHT.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      FACTION_TWILIGHT.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      FACTION_TWILIGHT.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      FACTION_TWILIGHT.ModObjectLimit(FourCC("O01P"), 1); //Chogall
      FACTION_TWILIGHT.ModObjectLimit(FourCC("H08Q"), 1); //Azil
      FACTION_TWILIGHT.ModObjectLimit(FourCC("U01S"), 1); //Feludius
      FACTION_TWILIGHT.ModObjectLimit(FourCC("O04H"), 1); //ignacius


      FACTION_TWILIGHT.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      FACTION_TWILIGHT.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      FACTION_TWILIGHT.ModObjectLimit(FourCC("R06X"), Faction.UNLIMITED); //Magic Training
      FACTION_TWILIGHT.ModObjectLimit(FourCC("R06Z"), Faction.UNLIMITED); //Herald Training

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
      FACTION_TWILIGHT.AddPower(power);

      FactionManager.Register(FACTION_TWILIGHT);
    }
  }
}