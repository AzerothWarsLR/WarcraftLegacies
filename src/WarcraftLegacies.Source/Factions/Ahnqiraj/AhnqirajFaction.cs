using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ahnqiraj.Quests;
using WarcraftLegacies.Source.Factions.Ahnqiraj.Researches;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Researches;

namespace WarcraftLegacies.Source.Factions.Ahnqiraj;

public sealed class AhnqirajFaction : Faction
{
  private readonly unit _gateAhnQiraj;

  /// <inheritdoc />
  public AhnqirajFaction() : base("Ahn'qiraj",
    playercolor.Wheat, @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
  {
    _gateAhnQiraj = AllPreplacedWidgets.Units.Get(UNIT_H02U_GATES_OF_AHN_QIRAJ_GATE_CLOSED);
    ControlPointDefenderUnitTypeId = UNIT_N0DW_CONTROL_POINT_DEFENDER_CTHUN_TOWER;
    TraditionalTeam = TeamSetup.OldGods;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 250,
      Turns = 10
    };
    IntroText = $"You are playing as {PrefixCol}C'thun and his Qiraji followers|r.\n\n" +
                "You start deep in the tunnels of Ahn'qiraj. You will need to awaken C'thun and free yourself from the Titan Guardians.\n\n" +
                "Then, quickly start making your move north, coordinate with your elemental ally to attack Kalimdor.\n\n" +
                "You do not possess boats, but your workers can burrow through water, use them to outmaneuver your enemies.";

    Nicknames = new List<string>
    {
      "aq",
      "ahnqiraj",
      "ahn'qiraj",
      "cthun",
      "c'thun"
    };
    ProcessObjectInfo(AhnqirajObjectInfo.GetAllObjectInfos());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterResearches();
    AhnqirajSpells.Setup();
    AhnqirajTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    RegisterQuests();
  }

  private void RegisterQuests()
  {
    var newQuest = AddQuest(new QuestTitanJailors(Regions.QirajInsideUnlock));
    StartingQuest = newQuest;
    AddQuest(new QuestRebuildAhnqiraj(Regions.QirajOutsideUnlock, _gateAhnQiraj));
    AddQuest(new QuestSlitheringForward(Regions.QirajOutpost1, Regions.QirajOutpost2, Regions.QirajOutpost3));
    AddQuest(new QuestTanarisOutpost(Regions.QirajOutpost5));
    AddQuest(new QuestFeralas(Regions.AQFeralasUnlock));
    AddQuest(new QuestEmperorConstruct());
    AddQuest(new QuestMockeryOfLife());
    AddQuest(new QuestDesolation(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestFreshMeat(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestAwakening(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestWarOfTheShiftingSand(AllLegends.Ahnqiraj.Cthun, AllLegends.Druids.Nordrassil));
    AddQuest(new QuestFiendThousandFaces(AllLegends.Neutral.YoggSaron));
  }

  private static void RegisterResearches()
  {
    ResearchManager.Register(new Progenesis(UPGRADE_R003_PROGENESIS_C_THUN, 20)
    {
      TransformableUnitTypeIds = new int[]
      {
        UNIT_U019_WORKER_CTHUN_WORKER,
        UNIT_UCBD_BURROWED_WORKER_CTHUN_WORKER
      },
      TransformedUnitTypeId = UNIT_N06I_SOLDIER_CTHUN_SILITHID_WARRIOR
    });
    ResearchManager.RegisterIncompatibleSet(new BasicResearch(UPGRADE_ZBML_SPELL_CONDUCTION_C_THUN, 170),
      new RemoveAbilityResearch(UPGRADE_ZBHS_SHAPED_OBSIDIAN_C_THUN, 100)
      {
        RemovedAbility = ABILITY_A13J_SPELL_RESISTANCE_RIFLEMAN_OBSIDIAN_ERADICATOR_ANIMATED_ARMOR
      });
  }
}
