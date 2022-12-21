using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Frostwolf;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class FrostwolfSetup
  {
    public static Faction? Frostwolf { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Frostwolf = new Faction("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303",
        "ReplaceableTextures\\CommandButtons\\BTNThrall.blp")
      {
        UndefeatedResearch = Constants.UPGRADE_R05V_FROSTWOLF_EXISTS,
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "SadMystery",
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF,
        IntroText = @"You are playing as the honorable |cffff0000Frostwolf Clan|r.

You have been shipwrecked. Gather enough resources to sail South-West to Kalimdor. Until you reach Kalimdor, you will be unable to train any more peons or research new tech. 

Once you land, you will find a Tauren caravan with a Great Hall packed in it's inventory. 
Escort the kodo to Thunderbluff, where you will find a goldmine waiting for you."
      };

      Frostwolf.ModObjectLimit(Constants.UNIT_OGRE_GREAT_HALL_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OSTR_STRONGHOLD_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OFRT_FORTRESS_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OALT_ALTAR_OF_STORMS_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OBAR_WAR_CAMP_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OFOR_WAR_MILL_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OSLD_SPIRIT_LODGE_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OTRB_BURROW_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OWTW_WATCH_TOWER_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_O002_IMPROVED_WATCH_TOWER_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OVLN_VOODOO_LOUNGE_FROSTWOLF, Faction.UNLIMITED);
      Frostwolf.ModObjectLimit(Constants.UNIT_OSHY_HORDE_PIER_FROSTWOLF, Faction.UNLIMITED);

      Frostwolf.ModObjectLimit(FourCC("opeo"), Faction.UNLIMITED); //Peon
      Frostwolf.ModObjectLimit(FourCC("ogru"), Faction.UNLIMITED); //Grunt
      Frostwolf.ModObjectLimit(FourCC("otau"), Faction.UNLIMITED); //Tauren
      Frostwolf.ModObjectLimit(FourCC("ohun"), Faction.UNLIMITED); //Troll Headhunter
      Frostwolf.ModObjectLimit(FourCC("ocat"), 6); //Catapult
      Frostwolf.ModObjectLimit(FourCC("otbr"), 12); //Troll Batrider
      Frostwolf.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //Troll Witch Doctor
      Frostwolf.ModObjectLimit(FourCC("oshm"), Faction.UNLIMITED); //Shaman
      Frostwolf.ModObjectLimit(FourCC("ospw"), Faction.UNLIMITED); //Spirit Walker
      Frostwolf.ModObjectLimit(FourCC("o00A"), 6); //Far Seer
      Frostwolf.ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship
      Frostwolf.ModObjectLimit(FourCC("odes"), Faction.UNLIMITED); //Orc Frigate
      Frostwolf.ModObjectLimit(FourCC("oosc"), Faction.UNLIMITED); //Pack Kodo
      Frostwolf.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      Frostwolf.ModObjectLimit(FourCC("h00C"), 1); //Drek)thar
      Frostwolf.ModObjectLimit(FourCC("Othr"), 1); //Thrall
      Frostwolf.ModObjectLimit(FourCC("Ocbh"), 1); //Cairne
      Frostwolf.ModObjectLimit(FourCC("Orkn"), 1); //Voljin
      Frostwolf.ModObjectLimit(FourCC("Orex"), 1); //Rexxar

      Frostwolf.ModObjectLimit(FourCC("Rows"), Faction.UNLIMITED); //Improved Pulverize
      Frostwolf.ModObjectLimit(FourCC("Rost"), Faction.UNLIMITED); //Shaman Adept Training
      Frostwolf.ModObjectLimit(FourCC("Rowd"), Faction.UNLIMITED); //Witch Doctor Adept Training
      Frostwolf.ModObjectLimit(FourCC("Rowt"), Faction.UNLIMITED); //Spirit Walker Adept Training
      Frostwolf.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      Frostwolf.ModObjectLimit(FourCC("Rolf"), Faction.UNLIMITED); //Liquid Fire
      Frostwolf.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      Frostwolf.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //reinforced Defenses
      Frostwolf.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Animal Companion
      Frostwolf.ModObjectLimit(FourCC("R00R"), Faction.UNLIMITED); //Improved Chain Lightning
      Frostwolf.ModObjectLimit(FourCC("R00W"), Faction.UNLIMITED); //Toughened Hides
      Frostwolf.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      Frostwolf.SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations

      Frostwolf.ModAbilityAvailability(Constants.ABILITY_A0PF_FEL_ENERGY_TEAL_FORTRESSES, -1);
      Frostwolf.ModAbilityAvailability(Constants.ABILITY_ANTR_TROLL_REGENERATION_PINK_WITCH_DOCTOR_TROLL_HEADHUNTER_TROLL_BATRIDER_DARKSPEAR_WARLORD_TROLL_BERSERKER_ICON, -1);
      Frostwolf.ModAbilityAvailability(Constants.ABILITY_A0M4_BATTLE_STATIONS_PINK_GREY_ORC_BURROW_BLOODPACT, -1);
      Frostwolf.ModAbilityAvailability(Constants.ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
      
      Frostwolf.AddGoldMine(preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-1789, -1697)));
      Frostwolf.AddGoldMine(preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-14466, -4703)));
      
      FrostwolfStructurePackingConfig.Setup();
      FactionManager.Register(Frostwolf);
    }
  }
}