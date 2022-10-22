using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class WarsongSetup
  {
    public static Faction? WarsongClan { get; private set; }
    
    public static void Setup()
    {
      WarsongClan = new Faction("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000",
        "ReplaceableTextures\\CommandButtons\\BTNHellScream.blp")
      {
        UndefeatedResearch = FourCC("R05W"),
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "DarkAgents",
        IntroText = @"You are playing as the proud |cffd45e19Warsong clan|r.

You start isolated in the woods of Ashenvale. The Warchief expects a large amount of lumber from you, begin harvesting with your Peons.

Travel South into the Barren to creep and colonise.

The Night Elves are aware of your presence and are gathering against you. Unlock Orgrimmar as soon as possible to defend against the Night Elf attacks."
      };

      WarsongClan.ModObjectLimit(FourCC("o00C"), Faction.UNLIMITED); //Great Hall
      WarsongClan.ModObjectLimit(FourCC("o02R"), Faction.UNLIMITED); //Stronghold
      WarsongClan.ModObjectLimit(FourCC("o02S"), Faction.UNLIMITED); //Fortress
      WarsongClan.ModObjectLimit(FourCC("o020"), Faction.UNLIMITED); //Altar of Storms
      WarsongClan.ModObjectLimit(FourCC("o01S"), Faction.UNLIMITED); //Barracks
      WarsongClan.ModObjectLimit(FourCC("o009"), Faction.UNLIMITED); //War Mill
      WarsongClan.ModObjectLimit(FourCC("o006"), Faction.UNLIMITED); //Ogre Barrack
      WarsongClan.ModObjectLimit(FourCC("o05G"), Faction.UNLIMITED); //Siege Workshop
      WarsongClan.ModObjectLimit(FourCC("o02Q"), Faction.UNLIMITED); //Bestiary
      WarsongClan.ModObjectLimit(FourCC("o028"), Faction.UNLIMITED); //Orc Burrow
      WarsongClan.ModObjectLimit(FourCC("n03E"), Faction.UNLIMITED); //Watch Tower
      WarsongClan.ModObjectLimit(FourCC("o01H"), Faction.UNLIMITED); //Troll Shrine
      WarsongClan.ModObjectLimit(FourCC("n0AL"), Faction.UNLIMITED); //Improved Watch Tower
      WarsongClan.ModObjectLimit(FourCC("o02T"), Faction.UNLIMITED); //Shipyard
      WarsongClan.ModObjectLimit(FourCC("o01T"), Faction.UNLIMITED); //Goblin Hardware Shop

      WarsongClan.ModObjectLimit(FourCC("o04L"), Faction.UNLIMITED); //Peon
      WarsongClan.ModObjectLimit(FourCC("o02M"), Faction.UNLIMITED); //Grunt
      WarsongClan.ModObjectLimit(FourCC("orai"), Faction.UNLIMITED); //Raider
      WarsongClan.ModObjectLimit(FourCC("n08E"), Faction.UNLIMITED); //Hexbinder
      WarsongClan.ModObjectLimit(FourCC("otbk"), Faction.UNLIMITED); //Troll Berseker
      WarsongClan.ModObjectLimit(FourCC("nogn"), Faction.UNLIMITED); //Stonemaul Ogre Magi
      WarsongClan.ModObjectLimit(FourCC("o00I"), 6); //Horde War Machine
      WarsongClan.ModObjectLimit(FourCC("e01L"), 2); //War Station
      WarsongClan.ModObjectLimit(FourCC("e01M"), 4); //Azerite Siege Engine
      WarsongClan.ModObjectLimit(FourCC("okod"), 4); //Kodo Beast
      WarsongClan.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      WarsongClan.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      WarsongClan.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught
      WarsongClan.ModObjectLimit(FourCC("o00G"), 6); //Blademaster
      WarsongClan.ModObjectLimit(FourCC("n03F"), 6); //Korkron elite
      WarsongClan.ModObjectLimit(FourCC("owyv"), 8); //Wind Rider

      WarsongClan.ModObjectLimit(FourCC("Ogrh"), 1); //Grom
      WarsongClan.ModObjectLimit(FourCC("Obla"), 1); //Varok

      WarsongClan.ModObjectLimit(FourCC("Robs"), Faction.UNLIMITED); //Berserker Strength
      WarsongClan.ModObjectLimit(FourCC("Rotr"), Faction.UNLIMITED); //Troll Regeneration
      WarsongClan.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      WarsongClan.ModObjectLimit(FourCC("R01J"), Faction.UNLIMITED); //Ensnare
      WarsongClan.ModObjectLimit(FourCC("R02I"), Faction.UNLIMITED); //Ogre Magi Adept Training
      WarsongClan.ModObjectLimit(FourCC("R03Q"), Faction.UNLIMITED); //Warlock Adept Training
      WarsongClan.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //Reinforced Defenses
      WarsongClan.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      WarsongClan.ModObjectLimit(FourCC("R016"), Faction.UNLIMITED); //Warlords
      WarsongClan.ModObjectLimit(FourCC("R019"), Faction.UNLIMITED); //Improved Shockwave
      WarsongClan.ModObjectLimit(Constants.UPGRADE_R01Z_BATTLE_STATIONS_ORC, Faction.UNLIMITED);
      WarsongClan.SetObjectLevel(Constants.UPGRADE_R01Z_BATTLE_STATIONS_ORC, 1);
      WarsongClan.ModObjectLimit(Constants.UPGRADE_R00D_FOR_THE_HORDE_FROSTWOLF, Faction.UNLIMITED);
      WarsongClan.ModObjectLimit(Constants.UPGRADE_ROVS_ENVENOMED_SPEARS_FROSTWOLF, Faction.UNLIMITED);
      WarsongClan.ModObjectLimit(Constants.UPGRADE_R017_IMPROVED_IGNORE_PAIN_WARSONG, Faction.UNLIMITED);

      WarsongClan.ModAbilityAvailability(Constants.ABILITY_A0PF_FEL_ENERGY_TEAL_FORTRESSES, -1);
      WarsongClan.ModAbilityAvailability(Constants.ABILITY_ANTR_TROLL_REGENERATION_PINK_WITCH_DOCTOR_TROLL_HEADHUNTER_TROLL_BATRIDER_DARKSPEAR_WARLORD_TROLL_BERSERKER_ICON, -1);
      WarsongClan.ModAbilityAvailability(Constants.ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
      WarsongClan.ModAbilityAvailability(Constants.ABILITY_A0M4_BATTLE_STATIONS_PINK_GREY_ORC_BURROW_BLOODPACT, -1);
      
      WarsongClan.AddGoldMine(PreplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-9755, 2277)));
      
      FactionManager.Register(WarsongClan);
    }
  }
}