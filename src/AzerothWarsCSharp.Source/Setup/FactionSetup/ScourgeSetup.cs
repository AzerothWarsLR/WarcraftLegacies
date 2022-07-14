using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class ScourgeSetup
  {
    public static Faction FactionScourge { get; private set; }

    public static void Setup()
    {
      FactionScourge = new Faction("Scourge", PLAYER_COLOR_PURPLE, "|c00540081",
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
      FactionScourge.ModObjectLimit(FourCC("unpl"), Faction.UNLIMITED); //Necropolis
      FactionScourge.ModObjectLimit(FourCC("unp1"), Faction.UNLIMITED); //Halls of the Dead
      FactionScourge.ModObjectLimit(FourCC("unp2"), Faction.UNLIMITED); //Black Citadel
      FactionScourge.ModObjectLimit(FourCC("uzig"), Faction.UNLIMITED); //Ziggurat
      FactionScourge.ModObjectLimit(FourCC("uzg1"), Faction.UNLIMITED); //Spirit Tower
      FactionScourge.ModObjectLimit(FourCC("uzg2"), Faction.UNLIMITED); //Nerubian Tower
      FactionScourge.ModObjectLimit(FourCC("uaod"), Faction.UNLIMITED); //Altar of Darkness
      FactionScourge.ModObjectLimit(FourCC("usep"), Faction.UNLIMITED); //Crypt
      FactionScourge.ModObjectLimit(FourCC("ugrv"), Faction.UNLIMITED); //Graveyard
      FactionScourge.ModObjectLimit(FourCC("uslh"), Faction.UNLIMITED); //Slaughterhouse
      FactionScourge.ModObjectLimit(FourCC("utod"), Faction.UNLIMITED); //Temple of the Damned
      FactionScourge.ModObjectLimit(FourCC("ubon"), Faction.UNLIMITED); //Boneyard
      FactionScourge.ModObjectLimit(FourCC("utom"), Faction.UNLIMITED); //Tomb of Relics
      FactionScourge.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      FactionScourge.ModObjectLimit(FourCC("u002"), Faction.UNLIMITED); //Improved Spirit Tower
      FactionScourge.ModObjectLimit(FourCC("u003"), Faction.UNLIMITED); //Improved Nerubian Tower

      //Units
      FactionScourge.ModObjectLimit(FourCC("uaco"), Faction.UNLIMITED); //Acolyte
      FactionScourge.ModObjectLimit(FourCC("ushd"), Faction.UNLIMITED); //Shade
      FactionScourge.ModObjectLimit(FourCC("ugho"), Faction.UNLIMITED); //Ghoul
      FactionScourge.ModObjectLimit(FourCC("uabo"), Faction.UNLIMITED); //Abomination
      FactionScourge.ModObjectLimit(FourCC("umtw"), 6); //Meat Wagon
      FactionScourge.ModObjectLimit(FourCC("ucry"), Faction.UNLIMITED); //Crypt Fiend
      FactionScourge.ModObjectLimit(FourCC("ugar"), 12); //Gargoyle
      FactionScourge.ModObjectLimit(FourCC("h02G"), Faction.UNLIMITED); //Vrykul Warrior
      FactionScourge.ModObjectLimit(FourCC("h061"), 12); //Vrykul Champion
      FactionScourge.ModObjectLimit(FourCC("h00P"), 4); //Mammoth rider
      FactionScourge.ModObjectLimit(FourCC("uban"), Faction.UNLIMITED); //Banshee
      FactionScourge.ModObjectLimit(FourCC("unec"), Faction.UNLIMITED); //Necromancer
      FactionScourge.ModObjectLimit(FourCC("uobs"), 4); //Obsidian Statue
      FactionScourge.ModObjectLimit(FourCC("ufro"), 4); //Frost Wyrm
      FactionScourge.ModObjectLimit(FourCC("h00H"), 6); //Death Knight
      FactionScourge.ModObjectLimit(FourCC("ubot"), 12); //Undead Transport Ship
      FactionScourge.ModObjectLimit(FourCC("udes"), 12); //Undead Frigate
      FactionScourge.ModObjectLimit(FourCC("uubs"), 6); //Undead Battleship
      FactionScourge.ModObjectLimit(FourCC("ubsp"), 6); //Destroyer
      FactionScourge.ModObjectLimit(FourCC("nfgl"), 2); //Plague Titan

      //Demi-Heroes
      FactionScourge.ModObjectLimit(FourCC("ubdd"), 1); //Sapphiron
      FactionScourge.ModObjectLimit(FourCC("uswb"), 1); //Banshee
      FactionScourge.ModObjectLimit(FourCC("Uanb"), 1); //Anub'arak
      FactionScourge.ModObjectLimit(FourCC("U001"), 1); //Kel'thuzad
      FactionScourge.ModObjectLimit(FourCC("U00M"), 1); //Kel'thuzad (Ghost)
      FactionScourge.ModObjectLimit(FourCC("U00A"), 1); //Rivendare
      FactionScourge.ModObjectLimit(FourCC("Uktl"), 1); //Kel'thuzad (Lich)

      //Upgrades
      FactionScourge.ModObjectLimit(FourCC("Ruba"), Faction.UNLIMITED); //Banshee Adept Training
      FactionScourge.ModObjectLimit(FourCC("Rubu"), Faction.UNLIMITED); //Burrow
      FactionScourge.ModObjectLimit(FourCC("Ruex"), Faction.UNLIMITED); //Exhume Corpses
      FactionScourge.ModObjectLimit(FourCC("Rufb"), Faction.UNLIMITED); //Freezing Breath
      FactionScourge.ModObjectLimit(FourCC("Rugf"), Faction.UNLIMITED); //Ghoul Frenzy
      FactionScourge.ModObjectLimit(FourCC("Rune"), Faction.UNLIMITED); //Necromancer Adept Training
      FactionScourge.ModObjectLimit(FourCC("Ruwb"), Faction.UNLIMITED); //Web
      FactionScourge.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Chaos Infusion
      FactionScourge.ModObjectLimit(FourCC("R00Q"), Faction.UNLIMITED); //Chilling Aura
      FactionScourge.ModObjectLimit(FourCC("R04V"), Faction.UNLIMITED); //Improved Hypothermic Breath
      FactionScourge.ModObjectLimit(FourCC("R01X"), Faction.UNLIMITED); //Epidemic
      FactionScourge.ModObjectLimit(FourCC("R01D"), Faction.UNLIMITED); //Piercing Screech
      FactionScourge.ModObjectLimit(FourCC("R06N"), Faction.UNLIMITED); //Improved Orb of Annihilation
      FactionScourge.ModObjectLimit(FourCC("Rusl"), Faction.UNLIMITED); //Skeletal Mastery
      FactionScourge.ModObjectLimit(FourCC("Rusm"), Faction.UNLIMITED); //Skeletal Longevity

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
      FactionScourge.AddPower(visionPower);
      
      FactionManager.Register(FactionScourge);
    }
  }
}