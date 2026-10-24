using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Stormwind.Paths;
using WarcraftLegacies.Source.Factions.Stormwind.Quests;
using WarcraftLegacies.Source.Factions.Stormwind.Researches;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Stormwind;

public sealed class StormwindFaction : Faction, IHasRoleplayPaths, IHasRoleplayIntro
{
  /// <inheritdoc />
  public StormwindFaction() : base("Stormwind", playercolor.Blue,
    @"ReplaceableTextures\CommandButtons\BTNKnight.blp")
  {
    TraditionalTeam = TeamSetup.SouthAlliance;
    UndefeatedResearch = UPGRADE_R060_STORMWIND_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 100,
      Turns = 10
    };
    ControlPointDefenderUnitTypeId = UNIT_H05X_CONTROL_POINT_DEFENDER_STORMWIND;
    IntroText = () => Loc.Format(
      "You are playing as the steadfast {faction}.\n\nYou begin in Westfall, separated from the rest of the kingdom. Reunite your lands by liberating Darkshire, Lakeshire, and finally Stormwind City.\n\nOnce you have unified Stormwind's forces, race east to the Nethergarde Stronghold and prepare for the invasion of the Fel Horde.\n\nMake sure to communicate with your Dwarven and Kul Tiran allies, as they will be key to defeating the evil that lurks beyond the Dark Portal.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Kingdom of Stormwind")}|r"));

    Nicknames = new List<string>
    {
      "sw",
      "storm"
    };
    ProcessObjectInfo(StormwindObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public void AddRoleplayPaths()
  {
    if (GetAllPaths().Any(x => x is PathStromgarde))
    {
      return;
    }

    AddPath(new PathStromgarde(new StromgardeTransformation()));
  }

  /// <inheritdoc />
  public string RoleplayIntroText => Loc.Format(
    "You are playing as the steadfast {faction}.\n\nStormwind has risen from the ashes of the First War, its walls rebuilt and its people united behind King Varian. But in the Blasted Lands, the Dark Portal stirs once more.\n\nThe Fel Horde will soon pour through the Dark Portal. Hold the line beside Ironforge and Kul Tiras, your allies of the South Alliance, for together you are the bulwark of the south.\n\nOnce the Dark Portal is secured, the North Alliance will need your help against the Plague. Should Stormwind ever fall, the Trollbanes of Stromgarde will carry on the fight.",
    ("{faction}", $"{PrefixCol}{Loc.Get("Kingdom of Stormwind")}|r"));

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    RegisterResearches();
    StormwindSpells.Setup();
    StormwindTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, 1);
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
  }

  private void RegisterQuests()
  {
    var questDarkshire = AddQuest(new QuestDarkshire());
    StartingQuest = questDarkshire;
    var questLakeshire = AddQuest(new QuestLakeshire(Regions.LakeshireUnlock));
    var questGoldshire = AddQuest(new QuestGoldshire(Regions.ElwinForestAmbient));
    AddQuest(new QuestStormwindCity(Regions.StormwindUnlock, questDarkshire, questLakeshire, questGoldshire));
    AddQuest(new QuestNethergarde(AllLegends.Stormwind.Varian));
    AddQuest(new QuestStromgarde(Regions.Stromgarde));
    AddQuest(new QuestHonorHold(Regions.HonorHold, AllLegends.FelHorde.HellfireCitadel));
    AddQuest(new QuestKhadgar(AllLegends.FelHorde.BlackTemple));
    AddQuest(new QuestClosePortal(AllLegends.Stormwind.Khadgar));
    AddQuest(new QuestConstructionSites(new[]
    {
      AllPreplacedWidgets.Units.Get(UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM),
      AllPreplacedWidgets.Units.Get(UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
    }));
    AddQuest(new QuestKingdomOfManStormwind(Artifacts.CrownOfLordaeron, Artifacts.CrownOfStormwind,
      AllLegends.Stormwind.Varian));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
  }

  private static void RegisterResearches()
  {
    TierCodeOfChivalry.Setup();
    TierExpeditionSurvivors.Setup();
    TierReflectivePlating.Setup();
    TierVeteranGuard.Setup();
  }
}
