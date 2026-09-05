using System.Collections.Generic;
using System.Linq;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.OrcishHorde.Mechanics;
using WarcraftLegacies.Source.Factions.OrcishHorde.Quests;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

public sealed class OrcishHordeFaction : Faction
{
  private static readonly Dialogue _trollDialogue09 = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Troll09.flac",
    "This island be sinking quick, we come with you, man!",
    "Troll");

  private static readonly Dialogue _trollDialogue10 = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Troll10.flac",
    "We don't have much time.",
    "Troll");

  private static readonly Dialogue _trollDialogue11 = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Troll11.flac",
    "You got a way off the island?",
    "Troll");

  private static readonly Dialogue _trollDialogue12 = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Troll12.flac",
    "Eh, where the others go? Dey go with you?",
    "Troll");

  /// <summary>
  /// One line is drawn at random (without replacement) each time a troll group is rescued, so with only 3
  /// rescue spots but 4 lines, one goes unused each playthrough for a bit of variety.
  /// </summary>
  private readonly List<Dialogue> _unusedTrollDialogue = new()
  {
    _trollDialogue09, _trollDialogue10, _trollDialogue11, _trollDialogue12
  };

  /// <inheritdoc />
  public OrcishHordeFaction() : base("Orcish Horde", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNThrall.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    ControlPointDefenderUnitTypeId = UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 130,
      Turns = 10
    };
    CinematicMusic = "SadMystery";
    IntroText = () => Loc.Format(
      "You are playing as the {faction}.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Orcish Horde")}|r"));
    Nicknames = new List<string>
    {
      "horde",
      "oh",
      "orc",
      "orcs"
    };
    ProcessObjectInfo(OrcishHordeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    OrcishHordeSpells.Setup();
    OrcishHordeTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    RegisterQuests();
  }

  private void RegisterQuests()
  {
    var greatHall = AllPreplacedWidgets.Units.GetClosest(UNIT_O078_GREAT_HALL_ORCISH_HORDE_T1, -2720f, -8544f);

    var quest = new QuestCountdownToExtinction(greatHall, Regions.Darkspear_Isles, Regions.Horde_Landing_Durotar);
    StartingQuest = AddQuest(quest);

    new SeaWitchAssault(this, quest, greatHall, Regions.Darkspear_Isles, Regions.Sea_Witch_Spawn_1,
      Regions.Sea_Witch_Spawn_2, Regions.Sea_Witch_Spawn_3);

    RegisterTrollRescue(Regions.Troll_Rescue_1);
    RegisterTrollRescue(Regions.Troll_Rescue_2);
    RegisterTrollRescue(Regions.Troll_Rescue_3);

    SetupShipRepairPeon(-2368f, -9600f);
    SetupShipRepairPeon(-3136f, -9664f);

    SetupInitialTowerAssault();
  }

  private const float InitialTowerAssaultMurlocHealth = 200f;

  private static void SetupInitialTowerAssault()
  {
    var tower = AllPreplacedWidgets.Units.GetClosest(UNIT_O07E_WATCH_TOWER_ORCISH_HORDE, -2488.3f, -9027.9f);
    var murlocOne = AllPreplacedWidgets.Units.GetClosest(UNIT_O07B_MURLOC_TIDERUNNER_DARKSPEAR_ISLES, -2438.3f,
      -8977.9f);
    var murlocTwo = AllPreplacedWidgets.Units.GetClosest(UNIT_O07B_MURLOC_TIDERUNNER_DARKSPEAR_ISLES, -2538.3f,
      -9077.9f);

    GameTimeManager.RegisterOnTurn(1, () =>
    {
      murlocOne.Life = InitialTowerAssaultMurlocHealth;
      murlocTwo.Life = InitialTowerAssaultMurlocHealth;
      murlocOne.IssueOrder(ORDER_ATTACK, tower);
      murlocTwo.IssueOrder(ORDER_ATTACK, tower);
    });
  }

  private static void SetupShipRepairPeon(float shipX, float shipY)
  {
    var peon = AllPreplacedWidgets.Units.GetClosest(UNIT_O07A_PEON_ORCISH_HORDE, shipX, shipY);
    peon.IsInvulnerable = true;
    GameTimeManager.RegisterOnTurn(1, () => peon.SetAnimation("work"));
  }

  private void RegisterTrollRescue(Rectangle rescueRegion)
  {
    var sentryWard = AllPreplacedWidgets.Units.GetClosest(UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR,
      rescueRegion.Center.X, rescueRegion.Center.Y);
    sentryWard.IsInvulnerable = true;

    var alreadyRescued = false;
    var enterTrigger = trigger.Create();
    enterTrigger.RegisterEnterRegion(rescueRegion.Region);
    enterTrigger.AddAction(() =>
    {
      if (alreadyRescued || @event.Unit.Owner != Player)
      {
        return;
      }

      var rescuedUnits = GlobalGroup.EnumUnitsInRect(rescueRegion)
        .Where(rescuable => rescuable.Owner == player.NeutralPassive ||
                             rescuable.UnitType == UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR)
        .ToList();
      if (rescuedUnits.Count == 0)
      {
        return;
      }

      alreadyRescued = true;
      Player.RescueGroup(rescuedUnits);
      PlayRandomTrollDialogue();
    });
  }

  private void PlayRandomTrollDialogue()
  {
    if (_unusedTrollDialogue.Count == 0)
    {
      return;
    }

    var index = GetRandomInt(0, _unusedTrollDialogue.Count - 1);
    var dialogue = _unusedTrollDialogue[index];
    _unusedTrollDialogue.RemoveAt(index);
    Player?.QueueDialogue(dialogue);
  }
}
