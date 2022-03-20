using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class TrollSetup{

  
    Faction FACTION_TROLL
  

    public static void Setup( ){
      Faction f;
      FACTION_TROLL = Faction.create("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c","ReplaceableTextures\\CommandButtons\\BTNHeadHunterBerserker.blp");
      f = FACTION_TROLL;
      f.Team = TEAM_HORDE;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC(o03R), UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC(o03Y), UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC(o03Z), UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC(o040), UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC(o041), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(o042), UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC(o044), UNLIMITED)   ;//Tauren Totem
      f.ModObjectLimit(FourCC(o043), UNLIMITED)   ;//Spirit Lodge
      f.ModObjectLimit(FourCC(o045), UNLIMITED)   ;//Orc Burrow
      f.ModObjectLimit(FourCC(o046), UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC(o048), UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC(o047), UNLIMITED)   ;//Voodoo Lounge
      f.ModObjectLimit(FourCC(o049), UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC(o04X), UNLIMITED)   ;//Loa Shrine

      f.ModObjectLimit(FourCC(o04A), UNLIMITED)   ;//Peon
      f.ModObjectLimit(FourCC(h021), UNLIMITED)   ;//Grunt
      f.ModObjectLimit(FourCC(o04D), UNLIMITED)   ;//Troll Headhunter
      f.ModObjectLimit(FourCC(n09E), 2)           ;//Storm Wyrm
      f.ModObjectLimit(FourCC(e00Z), 8)           ;//Direhorn
      f.ModObjectLimit(FourCC(o04F), UNLIMITED)   ;//Troll Witch Doctor
      f.ModObjectLimit(FourCC(o04G), UNLIMITED)   ;//Haruspex
      f.ModObjectLimit(FourCC(o04E), 6)           ;//Boneseer
      f.ModObjectLimit(FourCC(h05D), UNLIMITED)   ;//Raptor Rider
      f.ModObjectLimit(FourCC(o04W), 24)  	      ;//Golden Vessel
      f.ModObjectLimit(FourCC(ojgn), 6)          ;//Juggernaught
      f.ModObjectLimit(FourCC(o021), 12)          ;//Ravager
      f.ModObjectLimit(FourCC(nftk), 12)          ;//Warlord
      f.ModObjectLimit(FourCC(o02K), 6)          ;//Bear Rider

      f.ModObjectLimit(FourCC(O026), 1)           ;//Rasthakan
      f.ModObjectLimit(FourCC(O01J), 1)           ;//Zul
      f.ModObjectLimit(FourCC(U023), 1)           ;//Hakkar

      f.ModObjectLimit(FourCC(Rers), UNLIMITED)   ;//Resistant Skin
      f.ModObjectLimit(FourCC(R00H), UNLIMITED)   ;//Animal Companion
      f.ModObjectLimit(FourCC(R070), UNLIMITED)   ;//Haruspex Training
      f.ModObjectLimit(FourCC(R071), UNLIMITED)   ;//Hex Training

    }

  }
}
