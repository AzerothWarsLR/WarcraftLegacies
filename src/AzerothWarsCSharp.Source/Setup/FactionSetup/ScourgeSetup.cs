using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class ScourgeSetup
  {
    public static Faction? Scourge { get; private set; }

    public static void Setup()
    {
      Scourge = new Faction("Scourge", PLAYER_COLOR_PURPLE, "|c00540081",
        "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp")
      {
        UndefeatedResearch = FourCC("R05K"),
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "ArthasTheme",
        IntroText = @"You are playing as the the terrifying Undead Scourge.

Northrend is vast and isolated, a perfect place to raise an army of undying warriors to destroy your enemies.

The Nerubians of Northrend have declared war on you, destroy their decrepit holdings and kill their Queen to secure the continent.

Coordinate with the Cult of the Damned and Burning Legion for the Plague that will sweep Lordaeron. 

The Necropolis of Naxxramas is become the perfect weapon for the Scourge, but you will need a powerful necromancer to awaken it."
      };

      //Buildings
      Scourge.ModObjectLimit(FourCC("unpl"), Faction.UNLIMITED); //Necropolis
      Scourge.ModObjectLimit(FourCC("unp1"), Faction.UNLIMITED); //Halls of the Dead
      Scourge.ModObjectLimit(FourCC("unp2"), Faction.UNLIMITED); //Black Citadel
      Scourge.ModObjectLimit(FourCC("uzig"), Faction.UNLIMITED); //Ziggurat
      Scourge.ModObjectLimit(FourCC("uzg1"), Faction.UNLIMITED); //Spirit Tower
      Scourge.ModObjectLimit(FourCC("uzg2"), Faction.UNLIMITED); //Nerubian Tower
      Scourge.ModObjectLimit(FourCC("uaod"), Faction.UNLIMITED); //Altar of Darkness
      Scourge.ModObjectLimit(FourCC("usep"), Faction.UNLIMITED); //Crypt
      Scourge.ModObjectLimit(FourCC("ugrv"), Faction.UNLIMITED); //Graveyard
      Scourge.ModObjectLimit(FourCC("uslh"), Faction.UNLIMITED); //Slaughterhouse
      Scourge.ModObjectLimit(FourCC("utod"), Faction.UNLIMITED); //Temple of the Damned
      Scourge.ModObjectLimit(FourCC("ubon"), Faction.UNLIMITED); //Boneyard
      Scourge.ModObjectLimit(FourCC("utom"), Faction.UNLIMITED); //Tomb of Relics
      Scourge.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      Scourge.ModObjectLimit(FourCC("u002"), Faction.UNLIMITED); //Improved Spirit Tower
      Scourge.ModObjectLimit(FourCC("u003"), Faction.UNLIMITED); //Improved Nerubian Tower

      //Units
      Scourge.ModObjectLimit(FourCC("uaco"), Faction.UNLIMITED); //Acolyte
      Scourge.ModObjectLimit(FourCC("ushd"), Faction.UNLIMITED); //Shade
      Scourge.ModObjectLimit(FourCC("ugho"), Faction.UNLIMITED); //Ghoul
      Scourge.ModObjectLimit(FourCC("uabo"), Faction.UNLIMITED); //Abomination
      Scourge.ModObjectLimit(FourCC("umtw"), 6); //Meat Wagon
      Scourge.ModObjectLimit(FourCC("ucry"), Faction.UNLIMITED); //Crypt Fiend
      Scourge.ModObjectLimit(FourCC("ugar"), 12); //Gargoyle
      Scourge.ModObjectLimit(FourCC("h02G"), Faction.UNLIMITED); //Vrykul Warrior
      Scourge.ModObjectLimit(FourCC("h061"), 12); //Vrykul Champion
      Scourge.ModObjectLimit(FourCC("h00P"), 4); //Mammoth rider
      Scourge.ModObjectLimit(FourCC("uban"), Faction.UNLIMITED); //Banshee
      Scourge.ModObjectLimit(FourCC("unec"), Faction.UNLIMITED); //Necromancer
      Scourge.ModObjectLimit(FourCC("uobs"), 4); //Obsidian Statue
      Scourge.ModObjectLimit(FourCC("ufro"), 4); //Frost Wyrm
      Scourge.ModObjectLimit(FourCC("h00H"), 6); //Death Knight
      Scourge.ModObjectLimit(FourCC("ubot"), 12); //Undead Transport Ship
      Scourge.ModObjectLimit(FourCC("udes"), 12); //Undead Frigate
      Scourge.ModObjectLimit(FourCC("uubs"), 6); //Undead Battleship
      Scourge.ModObjectLimit(FourCC("ubsp"), 6); //Destroyer
      Scourge.ModObjectLimit(FourCC("nfgl"), 2); //Plague Titan

      //Demi-Heroes
      Scourge.ModObjectLimit(FourCC("ubdd"), 1); //Sapphiron
      Scourge.ModObjectLimit(FourCC("uswb"), 1); //Banshee
      Scourge.ModObjectLimit(FourCC("Uanb"), 1); //Anub'arak
      Scourge.ModObjectLimit(FourCC("U001"), 1); //Kel'thuzad
      Scourge.ModObjectLimit(FourCC("U00M"), 1); //Kel'thuzad (Ghost)
      Scourge.ModObjectLimit(FourCC("U00A"), 1); //Rivendare
      Scourge.ModObjectLimit(FourCC("Uktl"), 1); //Kel'thuzad (Lich)

      //Upgrades
      Scourge.ModObjectLimit(FourCC("Ruba"), Faction.UNLIMITED); //Banshee Adept Training
      Scourge.ModObjectLimit(FourCC("Rubu"), Faction.UNLIMITED); //Burrow
      Scourge.ModObjectLimit(FourCC("Ruex"), Faction.UNLIMITED); //Exhume Corpses
      Scourge.ModObjectLimit(FourCC("Rufb"), Faction.UNLIMITED); //Freezing Breath
      Scourge.ModObjectLimit(FourCC("Rugf"), Faction.UNLIMITED); //Ghoul Frenzy
      Scourge.ModObjectLimit(FourCC("Rune"), Faction.UNLIMITED); //Necromancer Adept Training
      Scourge.ModObjectLimit(FourCC("Ruwb"), Faction.UNLIMITED); //Web
      Scourge.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Chaos Infusion
      Scourge.ModObjectLimit(FourCC("R00Q"), Faction.UNLIMITED); //Chilling Aura
      Scourge.ModObjectLimit(FourCC("R04V"), Faction.UNLIMITED); //Improved Hypothermic Breath
      Scourge.ModObjectLimit(FourCC("R01X"), Faction.UNLIMITED); //Epidemic
      Scourge.ModObjectLimit(FourCC("R01D"), Faction.UNLIMITED); //Piercing Screech
      Scourge.ModObjectLimit(FourCC("R06N"), Faction.UNLIMITED); //Improved Orb of Annihilation
      Scourge.ModObjectLimit(FourCC("Rusl"), Faction.UNLIMITED); //Skeletal Mastery
      Scourge.ModObjectLimit(FourCC("Rusm"), Faction.UNLIMITED); //Skeletal Longevity

      //Abilities
      Scourge.ModAbilityAvailability(Constants.ABILITY_A0WG_SPELL_SHIELD_SPELL_BOOK_ORANGE_ANTONIDAS_RED_LICH_KING, -1);
      Scourge.ModAbilityAvailability(Constants.ABILITY_A0K2_RAISE_DEAD_AUTO_CAST_RED_TEMPLE_OF_THE_DAMNED_OFF, -1);
      Scourge.ModAbilityAvailability(Constants.ABILITY_A09N_PERMANENT_IMMOLATION_SCOURGE_ICECROWN_OBELISK, -1);
      
      //Powers
      var visionPower = new VisionPower("All-Seeing",
        "Grants permanent vision over Northrend.",
        "Charm", new[]
        {
          Regions.Storm_Peaks,
          Regions.Central_Northrend,
          Regions.The_Basin,
          Regions.Ice_Crown,
          Regions.Fjord,
          Regions.Eastern_Northrend,
          Regions.Far_Eastern_Northrend,
          Regions.Coldarra,
          Regions.Borean_Tundra,
          Regions.IcecrownShipyard
        });
      Scourge.AddPower(visionPower);
      
      Scourge.AddGoldMine(PreplacedUnitSystem.GetUnit(FourCC("ugol"), new Point(-4939, 18803)));
      
      FactionManager.Register(Scourge);
    }
  }
}