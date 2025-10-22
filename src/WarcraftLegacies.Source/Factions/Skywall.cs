using System.Collections.Generic;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using MacroTools.ResearchSystems;
using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.PassiveAbilities;
using WarcraftLegacies.Source.Quests.Skywall;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.WarpedMalediction;
using WarcraftLegacies.Source.Spells.WhimOfTheWinds;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions;

public sealed class Skywall : Faction

{
  private readonly AllLegendSetup _allLegendSetup;
  /// <inheritdoc />
  public Skywall(AllLegendSetup allLegendSetup) : base("Skywall", playercolor.LightGray,
    @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
  {
    ControlPointDefenderUnitTypeId = UNIT_NECP_CONTROL_POINT_DEFENDER_SKYWALL_TOWER;
    TraditionalTeam = TeamSetup.OldGods;
    _allLegendSetup = allLegendSetup;
    StartingGold = 200;
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
    RegisterSpells();
    RegisterQuests();
    RegisterFactionDependentInitializer<Druids, Ahnqiraj>(RegisterInvasionRelatedQuests);
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
    AddQuest(new QuestKillDruids(_allLegendSetup.Druids.Nordrassil));



  }

  private void RegisterInvasionRelatedQuests(Druids druids, Ahnqiraj ahnqiraj)
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

  private static void RegisterSpells()
  {

    var purgeAttack = new SpellOnAttack(UNIT_O01I_ANIMATED_ARMOR_SKYWALL,
      ABILITY_AELP_SHOCKING_BLADES_ANIMATED_ARMOR)
    {
      DummyAbilityId = ABILITY_AEPU_PURGE_SHOCKING_BLADE,
      DummyOrderId = ORDER_PURGE,
      ProcChance = 0.20f,
      RequiredResearch = UPGRADE_RELP_SHOCKING_BLADES_SKYWALL
    };
    PassiveAbilityManager.Register(purgeAttack);


    var waterPrison = new SpellOnAttack(UNIT_N08S_ELEMENTAL_LORD_SKYWALL,
      ABILITY_A0Y6_WATER_PRISON_ELEMENTAL_LORD)
    {
      DummyAbilityId = ABILITY_A0Y0_WATER_PRISON_REAL,
      DummyOrderId = ORDER_ENTANGLING_ROOTS,
      ProcChance = 0.2f,
      Cooldown = 10f,
      RequiredResearch = UPGRADE_RSW3_QUEST_COMPLETED_SUBDUING_NEPTULON
    };
    PassiveAbilityManager.Register(waterPrison);

    var earthProtectionHero = new AnySpellNoTarget(ABILITY_A0Y4_EARTH_PROTECTION_ELEMENTAL_LORD)
    {
      DummyAbilityId = ABILITY_A0XY_EARTH_PROTECTION_HERO_DUMMY,
      DummyAbilityOrderId = ORDER_ROAR
    };
    SpellSystem.Register(earthProtectionHero);

    var stormSurge = new MassAnySpell(ABILITY_A104_STORM_SURGE_SKYWALL)
    {
      DummyAbilityId = ABILITY_TP04_PURGE_DUMMY,
      DummyAbilityOrderId = ORDER_PURGE,
      Radius = 200,
      DamageBase = 30,
      DamageLevel = 20,
      EnableDamage = true,
      TargetType = SpellTargetType.Point,
      CastFilter = CastFilters.IsTargetEnemyAndAlive
    };
    SpellSystem.Register(stormSurge);

    var massEnsnare = new MassAnySpell(ABILITY_A01N_MASS_ENSNARE_SKYWALL)
    {
      DummyAbilityId = ABILITY_A01V_MASS_ENSNARE_SKYWALL_DUMMY,
      DummyAbilityOrderId = ORDER_ENSNARE,
      Radius = 250,
      Chance = 0.75f,
      CastFilter = CastFilters.IsTargetEnemyAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellSystem.Register(massEnsnare);

    var whimOfTheWinds = new WhimOfTheWinds(ABILITY_WOTW_WHIM_OF_THE_WINDS_SKYWALL);
    SpellSystem.Register(whimOfTheWinds);

    var warpedMalediction = new WarpedMalediction(ABILITY_WMTP_WARPED_MALEDICTION_SKYWALL);
    SpellSystem.Register(warpedMalediction);


  }
}
