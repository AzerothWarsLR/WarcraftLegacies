using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.PreplacedWidgetsSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Stormwind;
using WarcraftLegacies.Source.Researches.Stormwind;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Stormwind : Faction
{
  /// <inheritdoc />
  public Stormwind() : base("Stormwind", playercolor.Blue,
    @"ReplaceableTextures\CommandButtons\BTNKnight.blp")
  {
    TraditionalTeam = TeamSetup.SouthAlliance;
    UndefeatedResearch = UPGRADE_R060_STORMWIND_EXISTS;
    StartingGold = 200;
    ControlPointDefenderUnitTypeId = UNIT_H05X_CONTROL_POINT_DEFENDER_STORMWIND;
    IntroText = $"You are playing as the steadfast {PrefixCol}Kingdom of Stormwind|r.\n\n" +
                "You begin in Westfall, separated from the rest of the kingdom. Reunite your lands by liberating Darkshire, Lakeshire, and finally Stormwind City.\n\n" +
                "Once you have unified Stormwind's forces, race east to the Nethergarde Stronghold and prepare for the invasion of the Fel Horde.\n\n" +
                "Make sure to communicate with your Dwarven and Kul Tiran allies, as they will be key to defeating the evil that lurks beyond the Dark Portal.";

    Nicknames = new List<string>
    {
      "sw",
      "storm"
    };
    ProcessObjectInfo(StormwindObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    RegisterResearches();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, 1);
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
    ModAbilityAvailability(ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
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
      PreplacedWidgets.Units.Get(UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM),
      PreplacedWidgets.Units.Get(UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
    }));
    AddQuest(new QuestKingdomOfManStormwind(Artifacts.CrownOfLordaeron, Artifacts.CrownOfStormwind,
      AllLegends.Stormwind.Varian));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }

  private static void RegisterResearches()
  {
    TierCodeOfChivalry.Setup();
    TierExpeditionSurvivors.Setup();
    TierReflectivePlating.Setup();
    TierVeteranGuard.Setup();
  }
}
