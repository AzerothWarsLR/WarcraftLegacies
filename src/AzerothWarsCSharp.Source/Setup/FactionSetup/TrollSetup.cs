using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class TrollSetup
  {
    public static Faction FACTION_TROLL { get; private set; }
    
    public static void Setup()
    {
      FACTION_TROLL = new Faction("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c",
        "ReplaceableTextures\\CommandButtons\\BTNHeadHunterBerserker.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        IntroText = @"You are playing as the mighty |cffe1946cZandalari Empire|r.

        You start off on Zandalar. Raise an army and deal with the uprising in Nazmir, then head West to Crestfall to claim more gold mines. 

        The Kul'tiran Navy is mounting an assault on you from the North, brace for a tough fight and counter-attack. 

        Once the human menace has been dealt with, sail West and help the Horde in Kalimdor."
      };

      FACTION_TROLL.ModObjectLimit(FourCC("o03R"), Faction.UNLIMITED); //Great Hall
      FACTION_TROLL.ModObjectLimit(FourCC("o03Y"), Faction.UNLIMITED); //Stronghold
      FACTION_TROLL.ModObjectLimit(FourCC("o03Z"), Faction.UNLIMITED); //Fortress
      FACTION_TROLL.ModObjectLimit(FourCC("o040"), Faction.UNLIMITED); //Altar of Storms
      FACTION_TROLL.ModObjectLimit(FourCC("o041"), Faction.UNLIMITED); //Barracks
      FACTION_TROLL.ModObjectLimit(FourCC("o042"), Faction.UNLIMITED); //War Mill
      FACTION_TROLL.ModObjectLimit(FourCC("o044"), Faction.UNLIMITED); //Tauren Totem
      FACTION_TROLL.ModObjectLimit(FourCC("o043"), Faction.UNLIMITED); //Spirit Lodge
      FACTION_TROLL.ModObjectLimit(FourCC("o045"), Faction.UNLIMITED); //Orc Burrow
      FACTION_TROLL.ModObjectLimit(FourCC("o046"), Faction.UNLIMITED); //Watch Tower
      FACTION_TROLL.ModObjectLimit(FourCC("o048"), Faction.UNLIMITED); //Improved Watch Tower
      FACTION_TROLL.ModObjectLimit(FourCC("o047"), Faction.UNLIMITED); //Voodoo Lounge
      FACTION_TROLL.ModObjectLimit(FourCC("o049"), Faction.UNLIMITED); //Shipyard
      FACTION_TROLL.ModObjectLimit(FourCC("o04X"), Faction.UNLIMITED); //Loa Shrine

      FACTION_TROLL.ModObjectLimit(FourCC("o04A"), Faction.UNLIMITED); //Peon
      FACTION_TROLL.ModObjectLimit(FourCC("h021"), Faction.UNLIMITED); //Grunt
      FACTION_TROLL.ModObjectLimit(FourCC("o04D"), Faction.UNLIMITED); //Troll Headhunter
      FACTION_TROLL.ModObjectLimit(FourCC("n09E"), 2); //Storm Wyrm
      FACTION_TROLL.ModObjectLimit(FourCC("e00Z"), 8); //Direhorn
      FACTION_TROLL.ModObjectLimit(FourCC("o04F"), Faction.UNLIMITED); //Troll Witch Doctor
      FACTION_TROLL.ModObjectLimit(FourCC("o04G"), Faction.UNLIMITED); //Haruspex
      FACTION_TROLL.ModObjectLimit(FourCC("o04E"), 6); //Boneseer
      FACTION_TROLL.ModObjectLimit(FourCC("h05D"), Faction.UNLIMITED); //Raptor Rider
      FACTION_TROLL.ModObjectLimit(FourCC("o04W"), 24); //Golden Vessel
      FACTION_TROLL.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught
      FACTION_TROLL.ModObjectLimit(FourCC("o021"), 12); //Ravager
      FACTION_TROLL.ModObjectLimit(FourCC("nftk"), 12); //Warlord
      FACTION_TROLL.ModObjectLimit(FourCC("o02K"), 6); //Bear Rider

      FACTION_TROLL.ModObjectLimit(FourCC("O026"), 1); //Rasthakan
      FACTION_TROLL.ModObjectLimit(FourCC("O01J"), 1); //Zul
      FACTION_TROLL.ModObjectLimit(FourCC("U023"), 1); //Hakkar

      FACTION_TROLL.ModObjectLimit(FourCC("Rers"), Faction.UNLIMITED); //Resistant Skin
      FACTION_TROLL.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Animal Companion
      FACTION_TROLL.ModObjectLimit(FourCC("R070"), Faction.UNLIMITED); //Haruspex Training
      FACTION_TROLL.ModObjectLimit(FourCC("R071"), Faction.UNLIMITED); //Hex Training

      FactionManager.Register(FACTION_TROLL);
    }
  }
}