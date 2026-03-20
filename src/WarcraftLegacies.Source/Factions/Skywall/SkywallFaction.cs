using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ahnqiraj;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.Skywall.Powers;
using WarcraftLegacies.Source.Factions.Skywall.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Researches;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Skywall;

public sealed class SkywallFaction : Faction
{
  /// <inheritdoc />
  public SkywallFaction() : base("Skywall", playercolor.LightGray,
    @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
  {
    ControlPointDefenderUnitTypeId = UNIT_NECP_CONTROL_POINT_DEFENDER_SKYWALL_TOWER;
    TraditionalTeam = TeamSetup.OldGods;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 100,
      Turns = 10
    };
    IntroText = $"You are playing as the {PrefixCol}Elementals of Skywall|r.\n\n" +
                "At the start, clear Uldum and take control of Tanaris.\n\n" +
                "Coordinate with your Qiraji ally to push back the Horde before the Druids can intervene.\n\n" +
                "You have a powerful event in the Burning of the World Tree. Use it at the right time to surprise the Druids and possibly attack them from behind.";

    Nicknames = new List<string>
    {
      "sky",
      "skywall",
      "ele",
      "eles",
      "elemental",
      "elementals",
      "rag",
      "ragnaros"
    };
    ProcessObjectInfo(SkywallObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterResearches();
    SkywallTraits.Setup();
    SkywallSpells.Setup();
    RegisterQuests();
    RegisterFactionDependentInitializer<DruidsFaction, AhnqirajFaction>(RegisterInvasionRelatedQuests);
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var newQuest = AddQuest(new QuestVortexPinnacle(Regions.Tempest_Rain));
    StartingQuest = newQuest;
    AddQuest(new QuestEmissary());
    AddQuest(new QuestThroneWind(Regions.ThroneoftheFourWind));
    AddQuest(new QuestShimmering(Regions.SkywallShimmering_Unlock));
    AddQuest(new QuestSubduing());
    AddQuest(new QuestKillDruids(AllLegends.Druids.Nordrassil));
  }

  private void RegisterInvasionRelatedQuests(DruidsFaction druids, AhnqirajFaction ahnqiraj)
  {
    var invasionParameters = new InvasionParameters();
    invasionParameters.InvasionRects = new List<Rectangle>
    {
      Regions.Invasion1,
      Regions.Invasion2,
      Regions.Invasion3,
      Regions.Invasion4,
      Regions.Invasion5,
      Regions.Invasion6,
    };
    invasionParameters.InvasionArmySummonParameters = new List<InvasionArmySummonParameter>
    {
      new(1, UNIT_LS05_SHAPER_SKYWALL_WORKER),
      new(3, UNIT_N0CG_CORE_HOUND_RAGNAROS),
      new(3, UNIT_VSW0_FIRE_ELEMENTAL_SKYWALL),
    };
    invasionParameters.AttackTargets = new List<Point>
    {
      new Point(-9788, 11040),

    };

    AddQuest(new QuestFirelandInvasion(invasionParameters, druids, ahnqiraj, Regions.SulfuronSpire));
  }

  private static void RegisterResearches()
  {
    ResearchManager.Register(new PowerResearch(UPGRADE_RELT_WINDFORGING_SKYWALL, 100,
      new Windforging(UNIT_O01I_ANIMATED_ARMOR_SKYWALL, 0.25f, new Point(-10396.5f, -20963.6f), "the Vortex Pinnacle", Regions.ElementalRealm)
      {
        IconName = "ItemForging",
        Name = "Windforging",
      }));
  }
}
