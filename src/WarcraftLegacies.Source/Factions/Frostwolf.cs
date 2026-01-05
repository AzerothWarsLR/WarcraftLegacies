using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.ResearchSystems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Frostwolf;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Frostwolf : Faction
{
  /// <inheritdoc />
  public Frostwolf() : base("Frostwolf", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNThrall.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
    UndefeatedResearch = UPGRADE_R05V_FROSTWOLF_EXISTS;
    StartingGold = 200;
    CinematicMusic = "SadMystery";
    ControlPointDefenderUnitTypeId = UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF;
    IntroText = $"You are playing as the honorable {PrefixCol}Frostwolf Clan|r.\n\n" +
                "You begin in Ashenvale, make your way south to establish your bases, the Echo Isles and Thunder Bluff.\n\n" +
                "Your allies will be coming south to help you defend against the Old Gods, do not engage them alone.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), -9729, 2426),
    };
    Nicknames = new List<string>
    {
      "fw",
      "frost",
      "frostwolves",
      "frostwolve"
    };
    ProcessObjectInfo(FrostwolfObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterFlightPath();
    RegisterQuests();
    RegisterDialogue();
    Regions.ThunderBluff.CleanupHostileUnits();
    Regions.Highmountain_Unlock.CleanupHostileUnits();
    Regions.GromSpawn.CleanupHostileUnits();
    Regions.EchoUnlock.CleanupHostileUnits();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);

  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0PF_FEL_ENERGY_TEAL_FORTRESSES, -1);
    ModAbilityAvailability(
      ABILITY_ANTR_TROLL_REGENERATION_PINK_WITCH_DOCTOR_TROLL_HEADHUNTER_TROLL_BATRIDER_DARKSPEAR_WARLORD_TROLL_BERSERKER_ICON,
      -1);
    ModAbilityAvailability(ABILITY_A0M4_BATTLE_STATIONS_PINK_GREY_ORC_BURROW_BLOODPACT, -1);
    ModAbilityAvailability(ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
    ModAbilityAvailability(ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, 1);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestThunderBluff(Regions.ThunderBluff));
    AddQuest(new QuestCrossroadsFrostwolf(Regions.Crossroads));
    AddQuest(new QuestDarkspear());
    AddQuest(new QuestOrgrimmarFrostwolf(Regions.Orgrimmar));
    AddQuest(new QuestRagetotem(AllLegends.Frostwolf.Cairne));
    AddQuest(new QuestHighmountain(AllLegends.Frostwolf.Cairne, Regions.Highmountain_Unlock));
    AddQuest(new QuestMammoth(AllLegends.Frostwolf.Rexxar));
    AddQuest(new QuestDrektharsSpellbook(AllLegends.Skywall.Vortex, AllLegends.Frostwolf.Thrall));
    AddQuest(new QuestFreeNerzhul(AllLegends.Scourge.TheFrozenThrone, AllLegends.Frostwolf.Thrall));
    AddQuest(new QuestWorldShaman(AllLegends.Frostwolf.Thrall));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }

  public override void OnNotPicked()
  {
    Regions.Highmountain_Unlock.CleanupNeutralPassiveUnits();

    base.OnNotPicked();
  }

  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar01",
            "I have wandered alone for many years, little Misha. Yet sometimes, even I grow weary of this endless solitude.",
            "Rexxar"),
          new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar02",
            "I have watched the other races. I have seen their squabbling, their ruthlessness. Their wars do nothing but scar the land and drive the wild things to extinction.",
            "Rexxar"),
          new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar03",
            "No, they cannot be trusted. Only beasts are above deceit.",
            "Rexxar"))
        , new[]
        {
          this
        }, new[]
        {
          new ObjectiveControlLegend(AllLegends.Frostwolf.Rexxar, false)
          {
            EligibleFactions = new List<Faction> { this }
          }
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Thrall25",
            "Who are you, warrior?",
            "Thrall"),
          new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar26",
            "I am Rexxar, last son of the Mok'Nathal.",
            "Rexxar"))
        , new[]
        {
          this
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Frostwolf.Thrall, AllLegends.Frostwolf.Rexxar)
        }));

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
      UPGRADE_R09N_FLIGHT_PATH_WARSONG,
      70));
  }
}
