using MacroTools.FactionSystem;
using MacroTools.Powers;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  /// <summary>
  /// Responsible for creating and containing the Stormwind <see cref="Faction"/>.
  /// </summary>
  public static class StormwindSetup
  {
    public static Faction? Stormwind { get; private set; }
    
    public static void Setup()
    {
      Stormwind = new Faction("Stormwind", PLAYER_COLOR_AQUA, "|CFF106246",
        "ReplaceableTextures\\CommandButtons\\BTNKnight.blp")
      {
        UndefeatedResearch = FourCC("R060"),
        StartingGold = 150,
        StartingLumber = 500,
        IntroText = @"You are playing as the steadfast |cff005800Kingdom of Stormwind|r.

You are the first line of defense against the onslaught of the Fel Horde. 

Reunite your Kingdom, beginning with Darkshire, Lakeshire, and finally Stormwind City. Then race East to the Stronghold of Nethergarde near the Dark Portal and prepare for the Fel Horde's invasion.

Make sure to communicate with your Dwarven and Kul'tiran allies, they will be the ones to help you early on, as the rest of the Alliance will be too far to reach you in time."
      };

      //Structures
      Stormwind.ModObjectLimit(FourCC("h06K"), Faction.UNLIMITED); //Town Hall
      Stormwind.ModObjectLimit(FourCC("h06M"), Faction.UNLIMITED); //Keep
      Stormwind.ModObjectLimit(FourCC("h06N"), Faction.UNLIMITED); //Castle
      Stormwind.ModObjectLimit(FourCC("h072"), Faction.UNLIMITED); //Farm
      Stormwind.ModObjectLimit(FourCC("h06T"), Faction.UNLIMITED); //Altar of Kings
      Stormwind.ModObjectLimit(FourCC("h06E"), Faction.UNLIMITED); //Barracks
      Stormwind.ModObjectLimit(FourCC("h06F"), Faction.UNLIMITED); //Blacksmith
      Stormwind.ModObjectLimit(FourCC("h06A"), Faction.UNLIMITED); //Workshop (Stormwind)
      Stormwind.ModObjectLimit(FourCC("hars"), Faction.UNLIMITED); //Arcane Sanctum
      Stormwind.ModObjectLimit(FourCC("h06V"), Faction.UNLIMITED); //Scout Tower
      Stormwind.ModObjectLimit(FourCC("h06W"), Faction.UNLIMITED); //Guard Tower
      Stormwind.ModObjectLimit(FourCC("h070"), Faction.UNLIMITED); //Guard Tower (Improved)
      Stormwind.ModObjectLimit(FourCC("h06X"), Faction.UNLIMITED); //Cannon Tower
      Stormwind.ModObjectLimit(FourCC("h071"), Faction.UNLIMITED); //Cannon Tower (Improved)
      Stormwind.ModObjectLimit(FourCC("n07T"), Faction.UNLIMITED); //Marketplace
      Stormwind.ModObjectLimit(FourCC("h06D"), Faction.UNLIMITED); //Alliance Shipyard
      Stormwind.ModObjectLimit(FourCC("h06Y"), Faction.UNLIMITED); //Arcane Tower
      Stormwind.ModObjectLimit(FourCC("h06Z"), Faction.UNLIMITED); //Arcane Tower (Improved)
      Stormwind.ModObjectLimit(FourCC("h024"), Faction.UNLIMITED); //Light House
      Stormwind.ModObjectLimit(Constants.UNIT_H05J_CHAMPION_S_HALL_STORMWIND, 1);
      Stormwind.ModObjectLimit(Constants.UNIT_H05A_WIZARD_S_SANCTUM_DARK_GREEN, 1);

      //Units
      Stormwind.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      Stormwind.ModObjectLimit(FourCC("h02O"), Faction.UNLIMITED); //Militia
      Stormwind.ModObjectLimit(FourCC("h03K"), 12); //Marshal
      Stormwind.ModObjectLimit(FourCC("h03Z"), 12); //Marshal
      Stormwind.ModObjectLimit(FourCC("h00A"), Faction.UNLIMITED); //Spearman
      Stormwind.ModObjectLimit(FourCC("h01B"), Faction.UNLIMITED); //Outriders
      Stormwind.ModObjectLimit(FourCC("h05F"), 6); //Stormwind Champion
      Stormwind.ModObjectLimit(FourCC("n05L"), 6); //Conjurer
      Stormwind.ModObjectLimit(FourCC("h00J"), Faction.UNLIMITED); //Clergyman
      Stormwind.ModObjectLimit(FourCC("n06N"), 6); //Gyrobomber
      Stormwind.ModObjectLimit(FourCC("n093"), Faction.UNLIMITED); //Chaplain
      Stormwind.ModObjectLimit(FourCC("hbot"), Faction.UNLIMITED); //Alliance Transport Ship
      Stormwind.ModObjectLimit(FourCC("hdes"), Faction.UNLIMITED); //Alliance Frigate
      Stormwind.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      Stormwind.ModObjectLimit(FourCC("h060"), 3); //Arathor Flagship


      Stormwind.ModObjectLimit(FourCC("H00R"), 1); //Varian
      Stormwind.ModObjectLimit(FourCC("H017"), 1); //Bolvar

      //Researches
      Stormwind.ModObjectLimit(FourCC("R02E"), Faction.UNLIMITED); //Chaplain Adept Training
      Stormwind.ModObjectLimit(FourCC("R005"), Faction.UNLIMITED); //Clergyman Adept Training
      Stormwind.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      Stormwind.ModObjectLimit(FourCC("R02B"), Faction.UNLIMITED); //Steel Plating
      Stormwind.ModObjectLimit(FourCC("Rhan"), Faction.UNLIMITED); //Animal War Training
      Stormwind.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      Stormwind.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      Stormwind.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      Stormwind.ModObjectLimit(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);

      //Tier researches
      Stormwind.ModObjectLimit(FourCC("R038"), Faction.UNLIMITED); //Enforcer Training
      Stormwind.ModObjectLimit(FourCC("R03E"), Faction.UNLIMITED); //Saboteur Training
      Stormwind.ModObjectLimit(FourCC("R02Y"), Faction.UNLIMITED); //Battle Tactics
      Stormwind.ModObjectLimit(FourCC("R03D"), Faction.UNLIMITED); //Veteran Guard
      Stormwind.ModObjectLimit(FourCC("R02W"), Faction.UNLIMITED); //Sanctuary of Light
      Stormwind.ModObjectLimit(FourCC("R03A"), Faction.UNLIMITED); //Focus In The Light
      Stormwind.ModObjectLimit(FourCC("R03T"), Faction.UNLIMITED); //Electric Strike Ritual
      Stormwind.ModObjectLimit(FourCC("R03U"), Faction.UNLIMITED); //Solar Flare Ritual
      
      Stormwind.ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      Stormwind.ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      Stormwind.ModAbilityAvailability(Constants.ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);

      Stormwind.AddPower(new CityOfHeroes(0.125f, 1.5f)
      {
        IconName = "Angel",
        Name = "City of Heroes",
        HeroGlowAbilityTypeId = Constants.ABILITY_A0GK_HERO_GLOW_ORIGIN
      });
      
      FactionManager.Register(Stormwind);
    }
  }
}