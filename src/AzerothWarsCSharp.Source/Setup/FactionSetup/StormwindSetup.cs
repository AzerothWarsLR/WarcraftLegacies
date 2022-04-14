using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class StormwindSetup
  {
    public static Faction Stormwind { get; private set; }


    public static void Setup()
    {
      Faction f;

      Stormwind = new Faction("Stormwind", PLAYER_COLOR_AQUA, "|CFF106246",
        "ReplaceableTextures\\CommandButtons\\BTNKnight.blp");
      f = Stormwind;
      f.Team = TeamSetup.TeamAlliance;
      f.UndefeatedResearch = FourCC("R060");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h06K"), Faction.UNLIMITED); //Town Hall
      f.ModObjectLimit(FourCC("h06M"), Faction.UNLIMITED); //Keep
      f.ModObjectLimit(FourCC("h06N"), Faction.UNLIMITED); //Castle
      f.ModObjectLimit(FourCC("h072"), Faction.UNLIMITED); //Farm
      f.ModObjectLimit(FourCC("h06T"), Faction.UNLIMITED); //Altar of Kings
      f.ModObjectLimit(FourCC("h06E"), Faction.UNLIMITED); //Barracks
      f.ModObjectLimit(FourCC("h06F"), Faction.UNLIMITED); //Blacksmith
      f.ModObjectLimit(FourCC("h06A"), Faction.UNLIMITED); //Workshop (Stormwind)
      f.ModObjectLimit(FourCC("hars"), Faction.UNLIMITED); //Arcane Sanctum
      f.ModObjectLimit(FourCC("h06V"), Faction.UNLIMITED); //Scout Tower
      f.ModObjectLimit(FourCC("h06W"), Faction.UNLIMITED); //Guard Tower
      f.ModObjectLimit(FourCC("h070"), Faction.UNLIMITED); //Guard Tower (Improved)
      f.ModObjectLimit(FourCC("h06X"), Faction.UNLIMITED); //Cannon Tower
      f.ModObjectLimit(FourCC("h071"), Faction.UNLIMITED); //Cannon Tower (Improved)
      f.ModObjectLimit(FourCC("n07T"), Faction.UNLIMITED); //Marketplace
      f.ModObjectLimit(FourCC("h06D"), Faction.UNLIMITED); //Alliance Shipyard
      f.ModObjectLimit(FourCC("h06Y"), Faction.UNLIMITED); //Arcane Tower
      f.ModObjectLimit(FourCC("h06Z"), Faction.UNLIMITED); //Arcane Tower (Improved)
      f.ModObjectLimit(FourCC("h024"), Faction.UNLIMITED); //Light House

      //Units
      f.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      f.ModObjectLimit(FourCC("h02O"), Faction.UNLIMITED); //Militia
      f.ModObjectLimit(FourCC("h03K"), 12); //Marshal
      f.ModObjectLimit(FourCC("h03Z"), 12); //Marshal
      f.ModObjectLimit(FourCC("h00A"), Faction.UNLIMITED); //Spearman
      f.ModObjectLimit(FourCC("h01B"), Faction.UNLIMITED); //Outriders
      f.ModObjectLimit(FourCC("h05F"), 6); //Stormwind Champion
      f.ModObjectLimit(FourCC("n05L"), 6); //Conjurer
      f.ModObjectLimit(FourCC("h00J"), Faction.UNLIMITED); //Clergyman
      f.ModObjectLimit(FourCC("n06N"), 6); //Gyrobomber
      f.ModObjectLimit(FourCC("n093"), Faction.UNLIMITED); //Chaplain
      f.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      f.ModObjectLimit(FourCC("h060"), 3); //Arathor Flagship


      f.ModObjectLimit(FourCC("H00R"), 1); //Varian
      f.ModObjectLimit(FourCC("H017"), 1); //Bolvar

      //Researches
      f.ModObjectLimit(FourCC("R02E"), Faction.UNLIMITED); //Chaplain Adept Training
      f.ModObjectLimit(FourCC("R005"), Faction.UNLIMITED); //Clergyman Adept Training
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      f.ModObjectLimit(FourCC("R02B"), Faction.UNLIMITED); //Steel Plating
      f.ModObjectLimit(FourCC("Rhan"), Faction.UNLIMITED); //Animal War Training
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      f.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      f.ModObjectLimit(FourCC("R014"), Faction.UNLIMITED); //Deeprun Tram

      //Tier researches
      f.ModObjectLimit(FourCC("R02S"), Faction.UNLIMITED); //Cathedral of Light
      f.ModObjectLimit(FourCC("R02U"), Faction.UNLIMITED); //SI:7 Headquarters
      f.ModObjectLimit(FourCC("R02K"), Faction.UNLIMITED); //Wizard)s Sanctum
      f.ModObjectLimit(FourCC("R02V"), Faction.UNLIMITED); //Champion)s Hall
      f.ModObjectLimit(FourCC("R038"), Faction.UNLIMITED); //Enforcer Training
      f.ModObjectLimit(FourCC("R03E"), Faction.UNLIMITED); //Saboteur Training
      f.ModObjectLimit(FourCC("R02Y"), Faction.UNLIMITED); //Battle Tactics
      f.ModObjectLimit(FourCC("R03D"), Faction.UNLIMITED); //Veteran Guard
      f.ModObjectLimit(FourCC("R02W"), Faction.UNLIMITED); //Sanctuary of Light
      f.ModObjectLimit(FourCC("R03A"), Faction.UNLIMITED); //Focus In The Light
      f.ModObjectLimit(FourCC("R03T"), Faction.UNLIMITED); //Electric Strike Ritual
      f.ModObjectLimit(FourCC("R03U"), Faction.UNLIMITED); //Solar Flare Ritual

      FactionManager.Register(Stormwind);
    }
  }
}