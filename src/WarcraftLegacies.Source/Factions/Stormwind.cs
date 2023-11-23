using MacroTools;
using MacroTools.FactionSystem;
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
      ModObjectLimit(FourCC("h06K"), Faction.UNLIMITED); //Town Hall
      ModObjectLimit(FourCC("h06M"), Faction.UNLIMITED); //Keep
      ModObjectLimit(FourCC("h06N"), Faction.UNLIMITED); //Castle
      ModObjectLimit(FourCC("h072"), Faction.UNLIMITED); //Farm
      ModObjectLimit(FourCC("h06T"), Faction.UNLIMITED); //Altar of Kings
      ModObjectLimit(FourCC("h06E"), Faction.UNLIMITED); //Barracks
      ModObjectLimit(FourCC("h06F"), Faction.UNLIMITED); //Blacksmith
      ModObjectLimit(FourCC("h06A"), Faction.UNLIMITED); //Workshop (Stormwind)
      ModObjectLimit(FourCC("hars"), Faction.UNLIMITED); //Arcane Sanctum
      ModObjectLimit(FourCC("h06V"), Faction.UNLIMITED); //Scout Tower
      ModObjectLimit(FourCC("h06W"), Faction.UNLIMITED); //Guard Tower
      ModObjectLimit(FourCC("h070"), Faction.UNLIMITED); //Guard Tower (Improved)
      ModObjectLimit(FourCC("h06X"), Faction.UNLIMITED); //Cannon Tower
      ModObjectLimit(FourCC("h071"), Faction.UNLIMITED); //Cannon Tower (Improved)
      ModObjectLimit(FourCC("n07T"), Faction.UNLIMITED); //Marketplace
      ModObjectLimit(FourCC("h06D"), Faction.UNLIMITED); //Alliance Shipyard
      ModObjectLimit(FourCC("h06Y"), Faction.UNLIMITED); //Arcane Tower
      ModObjectLimit(FourCC("h06Z"), Faction.UNLIMITED); //Arcane Tower (Improved)
      ModObjectLimit(FourCC("h024"), Faction.UNLIMITED); //Light House
      ModObjectLimit(Constants.UNIT_H05J_CHAMPION_S_HALL_STORMWIND_OTHER, 1);
      ModObjectLimit(Constants.UNIT_H05A_WIZARD_S_SANCTUM_STORMWIND_OTHER, 1);

      //Units
      ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      ModObjectLimit(FourCC("h02O"), Faction.UNLIMITED); //Militia
      ModObjectLimit(FourCC("h03K"), 12); //Marshal
      ModObjectLimit(FourCC("h03Z"), 12); //Marshal
      ModObjectLimit(FourCC("h00A"), Faction.UNLIMITED); //Spearman
      ModObjectLimit(FourCC("h01B"), Faction.UNLIMITED); //Outriders
      ModObjectLimit(FourCC("h05F"), 6); //Stormwind Champion
      ModObjectLimit(FourCC("n05L"), 6); //Conjurer
      ModObjectLimit(FourCC("h00J"), Faction.UNLIMITED); //Clergyman
      ModObjectLimit(Constants.UNIT_N06N_GUNSHIP_STORMWIND, 6);
      ModObjectLimit(FourCC("n093"), Faction.UNLIMITED); //Chaplain
      ModObjectLimit(FourCC("o06K"), 5); //Siege Tower

      //Ships
      ModObjectLimit(FourCC("hbot"), Faction.UNLIMITED); //Alliance Transport Ship
      ModObjectLimit(FourCC("h0AR"), Faction.UNLIMITED); //Alliance Scout
      ModObjectLimit(FourCC("h0AX"), Faction.UNLIMITED); //Alliance Frigate
      ModObjectLimit(FourCC("h0B3"), Faction.UNLIMITED); //Alliance Fireship
      ModObjectLimit(FourCC("h0B0"), Faction.UNLIMITED); //Alliance Galley
      ModObjectLimit(FourCC("h0B6"), Faction.UNLIMITED); //Alliance Boarding
      ModObjectLimit(FourCC("h0AN"), Faction.UNLIMITED); //Alliance Juggernaut
      ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard
      ModObjectLimit(FourCC("h060"), 3); //Arathor Flagship


      ModObjectLimit(FourCC("H00R"), 1); //Varian
      ModObjectLimit(FourCC("H017"), 1); //Bolvar
      ModObjectLimit(Constants.UNIT_H05Y_LORD_WIZARD_STORMWIND, 1);
      ModObjectLimit(Constants.UNIT_H00Z_CROWN_PRINCE_OF_STROMGARDE_STORMWIND, 1);

      //Researches
      ModObjectLimit(FourCC("R02E"), Faction.UNLIMITED); //Chaplain Adept Training
      ModObjectLimit(FourCC("R005"), Faction.UNLIMITED); //Clergyman Adept Training
      ModObjectLimit(FourCC("R02B"), Faction.UNLIMITED); //Steel Plating
      ModObjectLimit(FourCC("Rhan"), Faction.UNLIMITED); //Animal War Training
      ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      ModObjectLimit(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);

      ModObjectLimit(Constants.UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2, Faction.UNLIMITED);
      ModObjectLimit(FourCC("R030"), Faction.UNLIMITED); //Code of Chivalry
      ModObjectLimit(FourCC("R031"), Faction.UNLIMITED); //Elven Refugees
      ModObjectLimit(Constants.UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R03W_KNOWLEDGE_OF_HONOR_HOLD_ARATHOR_T2, Faction.UNLIMITED);

      //Tier researches
      ModObjectLimit(FourCC("R038"), Faction.UNLIMITED); //Enforcer Training
      ModObjectLimit(FourCC("R03E"), Faction.UNLIMITED); //Saboteur Training
      ModObjectLimit(FourCC("R02Y"), Faction.UNLIMITED); //Battle Tactics
      ModObjectLimit(FourCC("R03D"), Faction.UNLIMITED); //Veteran Guard
      ModObjectLimit(FourCC("R02W"), Faction.UNLIMITED); //Sanctuary of Light
      ModObjectLimit(FourCC("R03A"), Faction.UNLIMITED); //Focus In The Light
      ModObjectLimit(FourCC("R03T"), Faction.UNLIMITED); //Electric Strike Ritual
      ModObjectLimit(FourCC("R03U"), Faction.UNLIMITED); //Solar Flare Ritual
      ModObjectLimit(FourCC("R03X"), Faction.UNLIMITED); //Conjurers

      ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, 1);
      ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      ModAbilityAvailability(Constants.ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterDialogue()
    {
      throw new System.NotImplementedException();
    }
  }
}