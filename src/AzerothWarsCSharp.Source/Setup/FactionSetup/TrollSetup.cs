using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class TrollSetup
  {
    public static Faction FACTION_TROLL { get; private set; }


    public static void Setup()
    {
      Faction f;
      FACTION_TROLL = new Faction("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c",
        "ReplaceableTextures\\CommandButtons\\BTNHeadHunterBerserker.blp");
      f = FACTION_TROLL;
      f.Team = TeamSetup.Horde;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("o03R"), Faction.UNLIMITED); //Great Hall
      f.ModObjectLimit(FourCC("o03Y"), Faction.UNLIMITED); //Stronghold
      f.ModObjectLimit(FourCC("o03Z"), Faction.UNLIMITED); //Fortress
      f.ModObjectLimit(FourCC("o040"), Faction.UNLIMITED); //Altar of Storms
      f.ModObjectLimit(FourCC("o041"), Faction.UNLIMITED); //Barracks
      f.ModObjectLimit(FourCC("o042"), Faction.UNLIMITED); //War Mill
      f.ModObjectLimit(FourCC("o044"), Faction.UNLIMITED); //Tauren Totem
      f.ModObjectLimit(FourCC("o043"), Faction.UNLIMITED); //Spirit Lodge
      f.ModObjectLimit(FourCC("o045"), Faction.UNLIMITED); //Orc Burrow
      f.ModObjectLimit(FourCC("o046"), Faction.UNLIMITED); //Watch Tower
      f.ModObjectLimit(FourCC("o048"), Faction.UNLIMITED); //Improved Watch Tower
      f.ModObjectLimit(FourCC("o047"), Faction.UNLIMITED); //Voodoo Lounge
      f.ModObjectLimit(FourCC("o049"), Faction.UNLIMITED); //Shipyard
      f.ModObjectLimit(FourCC("o04X"), Faction.UNLIMITED); //Loa Shrine

      f.ModObjectLimit(FourCC("o04A"), Faction.UNLIMITED); //Peon
      f.ModObjectLimit(FourCC("h021"), Faction.UNLIMITED); //Grunt
      f.ModObjectLimit(FourCC("o04D"), Faction.UNLIMITED); //Troll Headhunter
      f.ModObjectLimit(FourCC("n09E"), 2); //Storm Wyrm
      f.ModObjectLimit(FourCC("e00Z"), 8); //Direhorn
      f.ModObjectLimit(FourCC("o04F"), Faction.UNLIMITED); //Troll Witch Doctor
      f.ModObjectLimit(FourCC("o04G"), Faction.UNLIMITED); //Haruspex
      f.ModObjectLimit(FourCC("o04E"), 6); //Boneseer
      f.ModObjectLimit(FourCC("h05D"), Faction.UNLIMITED); //Raptor Rider
      f.ModObjectLimit(FourCC("o04W"), 24); //Golden Vessel
      f.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught
      f.ModObjectLimit(FourCC("o021"), 12); //Ravager
      f.ModObjectLimit(FourCC("nftk"), 12); //Warlord
      f.ModObjectLimit(FourCC("o02K"), 6); //Bear Rider

      f.ModObjectLimit(FourCC("O026"), 1); //Rasthakan
      f.ModObjectLimit(FourCC("O01J"), 1); //Zul
      f.ModObjectLimit(FourCC("U023"), 1); //Hakkar

      f.ModObjectLimit(FourCC("Rers"), Faction.UNLIMITED); //Resistant Skin
      f.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Animal Companion
      f.ModObjectLimit(FourCC("R070"), Faction.UNLIMITED); //Haruspex Training
      f.ModObjectLimit(FourCC("R071"), Faction.UNLIMITED); //Hex Training

      FactionManager.Register(FACTION_TROLL);
    }
  }
}