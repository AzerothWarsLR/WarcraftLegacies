using System.Collections.Generic;
using MacroTools.FactionSystem;
using MacroTools.Spells;
using MacroTools.Systems;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.BlackEmpire;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Factions;

public sealed class BlackEmpire : Faction
{

  private readonly AllLegendSetup _allLegendSetup;
  private readonly PreplacedUnitSystem _preplacedUnitSystem;

  /// <inheritdoc />
  public BlackEmpire(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup) : base("Black Empire",
    playercolor.Maroon, @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
  {
    _allLegendSetup = allLegendSetup;
    _preplacedUnitSystem = preplacedUnitSystem;
    ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_NZOTH_TOWER;
    TraditionalTeam = TeamSetup.OldGods;
    StartingGold = 200;
    IntroText = $"You are playing as the {PrefixCol}Black Empire of N'zoth|r.\n\n" +
                "You start in Nyalotha, restore the city to its glory by repelling the invaders from Azeroth.\n\n" +
                "Then, move onto Kalimdor with your allies. You will quickly run into the Sentinels.\n\n" +
                "Be sure to train Forsaken Ones, they are powerful units.";

    Nicknames = new List<string>
    {
      "be",
      "black empire",
      "blackempire",
      "black",
      "nzoth",
      "n'zoth",
      "nz"
    };
    ProcessObjectInfo(BlackEmpireObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    RegisterSpells();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var questGorma = AddQuest(new QuestTwilightlanding(Regions.BlackEmpireOutpost1));
    StartingQuest = questGorma;

    AddQuest(new QuestWakingCity(questGorma, _allLegendSetup, Regions.Nyalotha));
    AddQuest(new QuestGiftofFlesh());
    AddQuest(new QuestWakingDream(_allLegendSetup.BlackEmpire.Zaqul, _preplacedUnitSystem));
    AddQuest(new QuestMawofShuma(_allLegendSetup.BlackEmpire.Yorsahj));
    AddQuest(new QuestMawofGorath(_allLegendSetup.BlackEmpire.Zonozz));
    AddQuest(new QuestDesolace(Regions.BEDesolaceUnlock));
    AddQuest(new QuestBladeoftheBlackEmpire(Regions.TheAbyss));
    AddQuest(new QuestDestruction(_allLegendSetup.BlackEmpire.Nzoth));
    AddQuest(new QuestWorldStone(_allLegendSetup.BlackEmpire.Nzoth, _allLegendSetup.Warsong.Orgrimmar));
    AddQuest(new QuestAscension(_allLegendSetup.BlackEmpire.Nzoth));
    AddQuest(new QuestAlignement(_allLegendSetup.BlackEmpire.Nzoth));
  }

  private static void RegisterUnitTypeTraits()
  {
    UnitTypeTraitRegistry.Register(new HideousAppendages
    {
      TentacleUnitTypeId = UNIT_N098_NZOTHTENTACLE_HIDEOUS_APPENDAGES_N_ZOTH,
      TentacleCount = 9,
      RadiusOffset = 520
    }, UNIT_U01Z_OLD_GOD_NZOTH);

    UnitTypeTraitRegistry.Register(new InfiniteInfluence
    {
      Radius = 800
    }, UNIT_U01Z_OLD_GOD_NZOTH);

    UnitTypeTraitRegistry.Register(new NoTargetSpellOnCast(ABILITY_AXK2_VOID_RIFT_ICON_XKORR)
    {
      DummyAbilityId = ABILITY_AXK1_VOIDBOLTDUMMY_X_KORR_DUMMY_SPELL,
      DummyOrderId = ORDER_FAN_OF_KNIVES,
      ProcChance = 1.0f,
      AbilityWhitelist = new List<int>
      {
        ABILITY_A032_ARCANE_BOMBARDMENT_ORANGE_ANTONIDAS_MEDIVH,
        ABILITY_ABEH_HEALING_WAVE_BLACK_EMPIRE,
        ABILITY_A10U_MANA_BURN_DALARAN_YOGG,
        ABILITY_A11O_BLACK_HOLE_KHADGAR,
      }
    }, UNIT_E01D_HARBINGER_OF_NY_ALOTHA_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_ABES_GENESIS_ATTACK_ICON_STYGIAN_HULK)
    {
      DummyAbilityId = ABILITY_ABEG_PARASITE_GENESIS_ATTACK_REAL,
      DummyOrderId = ORDER_PARASITE,
      ProcChance = 1.0f
    }, UNIT_U029_STYGIAN_HULK_NZOTH);

    UnitTypeTraitRegistry.Register(new NoTargetSpellOnAttack(ABILITY_ABEV_SHADOW_VEIL_ICON)
    {
      DummyAbilityId = ABILITY_ABSV_SHADOW_VEIL_SHADOW_VEIL_REAL,
      DummyOrderId = ORDER_HOWL_OF_TERROR,
      ProcChance = 0.10f,
      RequiredResearch = UPGRADE_RBEV_SHADOW_VEIL_BLACK_EMPIRE
    }, UNIT_N0AH_DEFORMED_CHIMERA_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_ABPF_PARALYSING_FEAR_ICON)
    {
      DummyAbilityId = ABILITY_ABSF_SLOW_PARALYSING_FEAR,
      DummyOrderId = ORDER_SLOW,
      ProcChance = 0.2f
    }, UNIT_O01G_BRUTE_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_ABGP_GREATER_PARALYSING_FEAR_ICON)
    {
      DummyAbilityId = ABILITY_ABSG_SLOW_GREATER_PARALYSING_FEAR,
      DummyOrderId = ORDER_SLOW,
      ProcChance = 0.4f
    }, UNIT_H09F_DEEP_FIEND_NZOTH);
  }

  private static void RegisterSpells()
  {
    var poisonYor = new Stomp(ABILITY_ABNT_VOID_TOXIN_BLACK_EMPIRE)
    {
      Radius = 500,
      DamageBase = 60,
      DamageLevel = 20,
      DurationBase = 3,
      DurationLevel = 0,
      StunAbilityId = ABILITY_ABSS_SHADOW_STRIKE_VOID_TOXIN_REAL,
      StunOrderId = ORDER_SHADOWSTRIKE,
      SpecialEffect = @"Abilities\Weapons\ChimaeraAcidMissile\ChimaeraAcidMissile.mdl"
    };
    SpellRegistry.Register(poisonYor);

    var shadowVeilSpell = new MassAnySpell(ABILITY_ABSV_SHADOW_VEIL_SHADOW_VEIL_REAL)
    {
      DummyAbilityId = ABILITY_ACAM_ANTI_MAGIC_SHELL_BLACK_EMPIRE,
      DummyAbilityOrderId = ORDER_ANTI_MAGIC_SHELL,
      Radius = 200,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(shadowVeilSpell);
  }
}
