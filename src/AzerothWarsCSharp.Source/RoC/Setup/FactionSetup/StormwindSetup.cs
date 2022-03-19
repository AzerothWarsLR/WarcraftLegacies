using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class StormwindSetup{

  
    Faction FACTION_STORMWIND
  

    public static void Setup( ){
      Faction f;

      FACTION_STORMWIND = Faction.create("Stormwind", PLAYER_COLOR_AQUA, "|CFF106246","ReplaceableTextures\\CommandButtons\\BTNKnight.blp");
      f = FACTION_STORMWIND;
      f.Team = TEAM_ALLIANCE;
      f.UndefeatedResearch = FourCC(R060);
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC(h06K), UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC(h06M), UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC(h06N), UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC(h072), UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC(h06T), UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC(h06E), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(h06F), UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC(h06A), UNLIMITED)   ;//Workshop (Stormwind)
      f.ModObjectLimit(FourCC(hars), UNLIMITED)   ;//Arcane Sanctum
      f.ModObjectLimit(FourCC(h06V), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC(h06W), UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC(h070), UNLIMITED)   ;//Guard Tower (Improved)
      f.ModObjectLimit(FourCC(h06X), UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC(h071), UNLIMITED)   ;//Cannon Tower (Improved)
      f.ModObjectLimit(FourCC(n07T), UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC(h06D), UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC(h06Y), UNLIMITED)   ;//Arcane Tower
      f.ModObjectLimit(FourCC(h06Z), UNLIMITED)   ;//Arcane Tower (Improved)
      f.ModObjectLimit(FourCC(h024), UNLIMITED)   ;//Light House

      //Units
      f.ModObjectLimit(FourCC(hpea), UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC(h02O), UNLIMITED)   ;//Militia
      f.ModObjectLimit(FourCC(h03K), 12)          ;//Marshal
      f.ModObjectLimit(FourCC(h03Z), 12)          ;//Marshal
      f.ModObjectLimit(FourCC(h00A), UNLIMITED)   ;//Spearman
      f.ModObjectLimit(FourCC(h01B), UNLIMITED)   ;//Outriders
      f.ModObjectLimit(FourCC(h05F), 6)           ;//Stormwind Champion
      f.ModObjectLimit(FourCC(n05L), 6)           ;//Conjurer
      f.ModObjectLimit(FourCC(h00J), UNLIMITED)   ;//Clergyman
      f.ModObjectLimit(FourCC(n06N), 6)           ;//Gyrobomber
      f.ModObjectLimit(FourCC(n093), UNLIMITED)   ;//Chaplain
      f.ModObjectLimit(FourCC(hbot), 12)   	      ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC(hdes), 12)   	      ;//Alliance Frigate
      f.ModObjectLimit(FourCC(hbsh), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC(h060), 3)           ;//Arathor Flagship



      f.ModObjectLimit(FourCC(H00R), 1)           ;//Varian
      f.ModObjectLimit(FourCC(H017), 1)           ;//Bolvar

      //Researches
      f.ModObjectLimit(FourCC(R02E), UNLIMITED)   ;//Chaplain Adept Training
      f.ModObjectLimit(FourCC(R005), UNLIMITED)   ;//Clergyman Adept Training
      f.ModObjectLimit(FourCC(R00K), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC(R02B), UNLIMITED)   ;//Steel Plating
      f.ModObjectLimit(FourCC(Rhan), UNLIMITED)   ;//Animal War Training
      f.ModObjectLimit(FourCC(Rhlh), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC(Rhac), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC(Rhse), UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC(R014), UNLIMITED)   ;//Deeprun Tram

      //Tier researches
      f.ModObjectLimit(FourCC(R02S), UNLIMITED)   ;//Cathedral of Light
      f.ModObjectLimit(FourCC(R02U), UNLIMITED)   ;//SI:7 Headquarters
      f.ModObjectLimit(FourCC(R02K), UNLIMITED)   ;//Wizard)s Sanctum
      f.ModObjectLimit(FourCC(R02V), UNLIMITED)   ;//Champion)s Hall
      f.ModObjectLimit(FourCC(R038), UNLIMITED)   ;//Enforcer Training
      f.ModObjectLimit(FourCC(R03E), UNLIMITED)   ;//Saboteur Training
      f.ModObjectLimit(FourCC(R02Y), UNLIMITED)   ;//Battle Tactics
      f.ModObjectLimit(FourCC(R03D), UNLIMITED)   ;//Veteran Guard
      f.ModObjectLimit(FourCC(R02W), UNLIMITED)   ;//Sanctuary of Light
      f.ModObjectLimit(FourCC(R03A), UNLIMITED)   ;//Focus In The Light
      f.ModObjectLimit(FourCC(R03T), UNLIMITED)   ;//Electric Strike Ritual
      f.ModObjectLimit(FourCC(R03U), UNLIMITED)   ;//Solar Flare Ritual
    }

  }
}
