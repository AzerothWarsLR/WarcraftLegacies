using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Quests.Stormwind;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Stormwind : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Stormwind(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Stormwind", PLAYER_COLOR_BLUE, "|c000042ff",
      @"ReplaceableTextures\CommandButtons\BTNKnight.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      UndefeatedResearch = Constants.UPGRADE_R060_STORMWIND_EXISTS;
      StartingGold = 200;
      StartingLumber = 700;
      ControlPointDefenderUnitTypeId = Constants.UNIT_H05X_CONTROL_POINT_DEFENDER_STORMWIND;
      IntroText = @"You are playing as the steadfast |c000042FFKingdom of Stormwind|r.

You begin in Westfall, separated from the rest of the kingdom. Reunite your lands by liberating Darkshire, Lakeshire and finally Stormwind City. 

Once you have unified Stormwind's forces, race East to the Nethergarde Stronghold and prepare for the invasion of the Fel Horde.

Make sure to communicate with your Dwarven and Kul'tiran allies, as they will be key in helping you defeat the evil from beyond the Dark Portal.";
    }
        
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
    }

    private void RegisterObjectLimits()
    {
      //Structures
      ModObjectLimit(FourCC("h06K"), UNLIMITED); //Town Hall
      ModObjectLimit(FourCC("h06M"), UNLIMITED); //Keep
      ModObjectLimit(FourCC("h06N"), UNLIMITED); //Castle
      ModObjectLimit(FourCC("h072"), UNLIMITED); //Farm
      ModObjectLimit(FourCC("h06T"), UNLIMITED); //Altar of Kings
      ModObjectLimit(FourCC("h06E"), UNLIMITED); //Barracks
      ModObjectLimit(FourCC("h06F"), UNLIMITED); //Blacksmith
      ModObjectLimit(FourCC("h06A"), UNLIMITED); //Workshop (Stormwind)
      ModObjectLimit(FourCC("hars"), UNLIMITED); //Arcane Sanctum
      ModObjectLimit(FourCC("h06V"), UNLIMITED); //Scout Tower
      ModObjectLimit(FourCC("h06W"), UNLIMITED); //Guard Tower
      ModObjectLimit(FourCC("h070"), UNLIMITED); //Guard Tower (Improved)
      ModObjectLimit(FourCC("h06X"), UNLIMITED); //Cannon Tower
      ModObjectLimit(FourCC("h071"), UNLIMITED); //Cannon Tower (Improved)
      ModObjectLimit(FourCC("n07T"), UNLIMITED); //Marketplace
      ModObjectLimit(FourCC("h06D"), UNLIMITED); //Alliance Shipyard
      ModObjectLimit(FourCC("h06Y"), UNLIMITED); //Arcane Tower
      ModObjectLimit(FourCC("h06Z"), UNLIMITED); //Arcane Tower (Improved)
      ModObjectLimit(FourCC("h024"), UNLIMITED); //Light House
      ModObjectLimit(Constants.UNIT_H05J_CHAMPION_S_HALL_STORMWIND_OTHER, 1);
      ModObjectLimit(Constants.UNIT_H05A_WIZARD_S_SANCTUM_STORMWIND_OTHER, 1);

      //Units
      ModObjectLimit(FourCC("hpea"), UNLIMITED); //Peasant
      ModObjectLimit(FourCC("h02O"), UNLIMITED); //Militia
      ModObjectLimit(FourCC("h03K"), 12); //Marshal
      ModObjectLimit(FourCC("h03Z"), 12); //Marshal
      ModObjectLimit(FourCC("h00A"), UNLIMITED); //Spearman
      ModObjectLimit(FourCC("h01B"), UNLIMITED); //Outriders
      ModObjectLimit(FourCC("h05F"), 6); //Stormwind Champion
      ModObjectLimit(FourCC("n05L"), 6); //Conjurer
      ModObjectLimit(FourCC("h00J"), UNLIMITED); //Clergyman
      ModObjectLimit(Constants.UNIT_N06N_GUNSHIP_STORMWIND, 6);
      ModObjectLimit(FourCC("n093"), UNLIMITED); //Chaplain
      ModObjectLimit(FourCC("o06K"), 5); //Siege Tower

      //Ships
      ModObjectLimit(FourCC("hbot"), UNLIMITED); //Alliance Transport Ship
      ModObjectLimit(FourCC("h0AR"), UNLIMITED); //Alliance Scout
      ModObjectLimit(FourCC("h0AX"), UNLIMITED); //Alliance Frigate
      ModObjectLimit(FourCC("h0B3"), UNLIMITED); //Alliance Fireship
      ModObjectLimit(FourCC("h0B0"), UNLIMITED); //Alliance Galley
      ModObjectLimit(FourCC("h0B6"), UNLIMITED); //Alliance Boarding
      ModObjectLimit(FourCC("h0AN"), UNLIMITED); //Alliance Juggernaut
      ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard
      ModObjectLimit(FourCC("h060"), 3); //Arathor Flagship


      ModObjectLimit(FourCC("H00R"), 1); //Varian
      ModObjectLimit(FourCC("H017"), 1); //Bolvar
      ModObjectLimit(Constants.UNIT_H05Y_LORD_WIZARD_STORMWIND, 1);
      ModObjectLimit(Constants.UNIT_H00Z_CROWN_PRINCE_OF_STROMGARDE_STORMWIND, 1);

      //Researches
      ModObjectLimit(FourCC("R02E"), UNLIMITED); //Chaplain Adept Training
      ModObjectLimit(FourCC("R005"), UNLIMITED); //Clergyman Adept Training
      ModObjectLimit(FourCC("R02B"), UNLIMITED); //Steel Plating
      ModObjectLimit(FourCC("Rhan"), UNLIMITED); //Animal War Training
      ModObjectLimit(FourCC("Rhlh"), UNLIMITED); //Improved Lumber Harvesting
      ModObjectLimit(FourCC("Rhac"), UNLIMITED); //Improved Masonry
      ModObjectLimit(FourCC("Rhse"), UNLIMITED); //Magic Sentry
      ModObjectLimit(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);

      ModObjectLimit(Constants.UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2, UNLIMITED);
      ModObjectLimit(FourCC("R030"), UNLIMITED); //Code of Chivalry
      ModObjectLimit(FourCC("R031"), UNLIMITED); //Elven Refugees
      ModObjectLimit(Constants.UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2, UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R03W_KNOWLEDGE_OF_HONOR_HOLD_ARATHOR_T2, UNLIMITED);

      //Tier researches
      ModObjectLimit(FourCC("R038"), UNLIMITED); //Enforcer Training
      ModObjectLimit(FourCC("R03E"), UNLIMITED); //Saboteur Training
      ModObjectLimit(FourCC("R02Y"), UNLIMITED); //Battle Tactics
      ModObjectLimit(FourCC("R03D"), UNLIMITED); //Veteran Guard
      ModObjectLimit(FourCC("R02W"), UNLIMITED); //Sanctuary of Light
      ModObjectLimit(FourCC("R03A"), UNLIMITED); //Focus In The Light
      ModObjectLimit(FourCC("R03T"), UNLIMITED); //Electric Strike Ritual
      ModObjectLimit(FourCC("R03U"), UNLIMITED); //Solar Flare Ritual
      ModObjectLimit(FourCC("R03X"), UNLIMITED); //Conjurers

      ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, 1);
      ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      ModAbilityAvailability(Constants.ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
    }

    private void RegisterQuests()
    {
      var stormwind = StormwindSetup.Stormwind;
      var newQuest =
        stormwind.AddQuest(new QuestDarkshire(preplacedUnitSystem.GetUnit(FourCC("ngnv"), Regions.DarkshireUnlock.Center)));
      stormwind.StartingQuest = newQuest;
      stormwind.AddQuest(new QuestLakeshire(Regions.LakeshireUnlock,
        preplacedUnitSystem.GetUnit(FourCC("nogl"), new Point(14288, -14063))));
      stormwind.AddQuest(new QuestGoldshire(Regions.ElwinForestAmbient,
        preplacedUnitSystem.GetUnit(Constants.UNIT_N021_HOGGER)));
      stormwind.AddQuest(new QuestStormwindCity(Regions.StormwindUnlock));
      stormwind.AddQuest(new QuestNethergarde(preplacedUnitSystem, allLegendSetup.Stormwind.Varian));
      stormwind.AddQuest(new QuestStromgarde(Regions.Stromgarde));
      stormwind.AddQuest(new QuestHonorHold(Regions.HonorHold, allLegendSetup.FelHorde.HellfireCitadel));
      stormwind.AddQuest(new QuestKhadgar(allLegendSetup.FelHorde.BlackTemple));
      stormwind.AddQuest(new QuestClosePortal(preplacedUnitSystem, allLegendSetup.Stormwind.Khadgar));
      stormwind.AddQuest(new QuestConstructionSites(new[]
      {
        preplacedUnitSystem.GetUnit(Constants.UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
      }));
      stormwind.AddQuest(new QuestKingdomOfManStormwind(artifactSetup.CrownOfLordaeron, artifactSetup.CrownOfStormwind,
        allLegendSetup.Stormwind.Varian));
    }

    private void RegisterDialogue()
    {
      throw new System.NotImplementedException();
    }
  }
}