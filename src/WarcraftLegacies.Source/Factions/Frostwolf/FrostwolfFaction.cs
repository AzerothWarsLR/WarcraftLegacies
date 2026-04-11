using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Frostwolf.Quests;
using WarcraftLegacies.Source.Factions.Lordaeron.Researches;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;
using WarcraftLegacies.Source.Shared.Researches;

namespace WarcraftLegacies.Source.Factions.Frostwolf;

public sealed class FrostwolfFaction : Faction
{
  /// <inheritdoc />
  public FrostwolfFaction() : base("Frostwolf", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNThrall.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
    UndefeatedResearch = UPGRADE_R05V_FROSTWOLF_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 130,
      Turns = 10
    };
    CinematicMusic = "SadMystery";
    ControlPointDefenderUnitTypeId = UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF;
    IntroText = $"You are playing as the honorable {PrefixCol}Frostwolf Clan|r.\n\n" +
                "You begin in Ashenvale, make your way south to establish your bases, the Echo Isles and Thunder Bluff.\n\n" +
                "Your allies will be coming south to help you defend against the Old Gods, do not engage them alone.";
    Nicknames = new List<string>
    {
      "fw",
      "frost",
      "frostwolves",
      "frostwolve"
    };
    ProcessObjectInfo(FrostwolfObjectInfo.GetAllObjectLimits());
  }
  private void RegisterResearches()
  {
    ResearchManager.RegisterIncompatibleSet(
      new CustomResearch(UPGRADE_TP10_TAUREN_CHIEFTENS_HORDE, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_TP11_TAUREN_CHIEFTAIN_HORDE_ELITE, 6);
          faction?.ModObjectLimit(UPGRADE_TP14_IMPROVED_SHOCKWAVE_HORDE, 1);
        }
      },
      new CustomResearch(UPGRADE_TP09_BLADEMASTERS_HORDE, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_O005_BLADEMASTER_HORDE_ELITE, 6);
          faction?.ModObjectLimit(UPGRADE_TP08_IMPROVED_CRITICAL_STRIKE_HORDE, 1);
        }
      });
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterFlightPath();
    RegisterQuests();
    RegisterDialogue();
    FrostwolfSpells.Setup();
    Regions.ThunderBluff.CleanupHostileUnits();
    Regions.GromSpawn.CleanupHostileUnits();
    Regions.EchoUnlock.CleanupHostileUnits();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
    ModAbilityAvailability(ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, 1);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestThunderBluff(Regions.ThunderBluff));
    AddQuest(new QuestCrossroadsFrostwolf(Regions.Crossroads));
    AddQuest(new QuestDarkspear());
    AddQuest(new QuestOrgrimmarFrostwolf(Regions.Orgrimmar));
    AddQuest(new QuestDrektharsSpellbook(AllLegends.Skywall.Vortex, AllLegends.Frostwolf.Thrall));
    AddQuest(new QuestFreeNerzhul(AllLegends.Scourge.TheFrozenThrone, AllLegends.Frostwolf.Thrall));
    AddQuest(new QuestWorldShaman(AllLegends.Frostwolf.Thrall));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
  }

  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\OrcCampaign\Orc01\O01Grunt01",
            "Warchief, our ship sustained heavy damage when we passed through the raging maelstrom. It's unsalvageable.",
            "Grunt"),
          new Dialogue(
            @"Sound\Dialogue\OrcCampaign\Orc01\O01Thrall02",
            "I knew it. Can we confirm our location? Is this Kalimdor?",
            "Thrall"),
          new Dialogue(
            @"Sound\Dialogue\OrcCampaign\Orc01\O01Grunt03",
            "We traveled due west, as you instructed. This should be it.",
            "Grunt"))
        , new[]
        {
          this
        }, new[]
        {
          new ObjectiveControlLegend(AllLegends.Frostwolf.Thrall, false)
          {
            EligibleFactions = new List<Faction> { this }
          }
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\OrcCampaign\Orc01\O01Cairne23",
            "I am Cairne, chief of the Bloodhoof tauren. You greenskins fight with both savagery and valor. I am intrigued.",
            "Cairne Bloodhoof"),
          new Dialogue(
            @"Sound\Dialogue\OrcCampaign\Orc01\O01Thrall24",
            "I am Thrall, and these are my brethren, the orcs. We've come seeking the destiny promised to us.",
            "Thrall"))
        , new[]
        {
          this
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Frostwolf.Cairne, AllLegends.Frostwolf.Thrall)
        }));
  }



  private void RegisterFlightPath()
  {
    ResearchManager.Register(new FlightPath(
      this,
      UPGRADE_R09N_FLIGHT_PATH_FROSTWOLF,
      70));
  }
}
