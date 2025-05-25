using System.Collections.Generic;
using MacroTools.FactionSystem;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using MacroTools.Systems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.BlackEmpire;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {

    private readonly AllLegendSetup _allLegendSetup;
    private readonly PreplacedUnitSystem _preplacedUnitSystem;

    /// <inheritdoc />
    public BlackEmpire(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup) : base("BlackEmpire", new[] {PLAYER_COLOR_MAROON, PLAYER_COLOR_RED, PLAYER_COLOR_BROWN},
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      _allLegendSetup = allLegendSetup;
      _preplacedUnitSystem = preplacedUnitSystem;
      ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_BLACK_EMPIRE_TOWER;
      TraditionalTeam = TeamSetup.OldGods;
      StartingGold = 200;
      IntroText = @"You are playing as the Black Empire of N'zoth|r|r.

You start in Nyalotha, restore the city to it's glory by repelling the invaders from Azeroth.

Then, move onto Kalimdor with your allies. You will quickly run into the Sentinels.

Be sure to train Forsaken Ones, they are powerful units";
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
      AddQuest(new QuestBladeoftheBlackEmpire(Regions.TheAbyss));
      AddQuest(new QuestDestruction(_allLegendSetup.BlackEmpire.Nzoth));
      AddQuest(new QuestWorldStone(_allLegendSetup.BlackEmpire.Nzoth, _allLegendSetup.Warsong.Orgrimmar));
      AddQuest(new QuestAscension(_allLegendSetup.BlackEmpire.Nzoth));
      AddQuest(new QuestAlignement(_allLegendSetup.BlackEmpire.Nzoth));
    }

    private void RegisterSpells()
    {
      PassiveAbilityManager.Register(new HideousAppendages(UNIT_U01Z_OLD_GOD_NZOTH)
      {
        TentacleUnitTypeId = UNIT_N098_NZOTHTENTACLE_HIDEOUS_APPENDAGES_N_ZOTH,
        TentacleCount = 9,
        RadiusOffset = 520
      });

      PassiveAbilityManager.Register(new InfiniteInfluence(UNIT_U01Z_OLD_GOD_NZOTH)
      {
        Radius = 800
      });

      PassiveAbilityManager.Register(new NoTargetSpellOnCast(UNIT_E01D_HARBINGER_OF_NY_ALOTHA_YOGG, ABILITY_AXK2_VOID_RIFT_ICON_XKORR)
      {
        DummyAbilityId = ABILITY_AXK1_VOIDBOLTDUMMY_X_KORR_DUMMY_SPELL,
        DummyOrderId = OrderId("fanofknives"),
        ProcChance = 1.0f,
        AbilityWhitelist = new List<int>
        {
          ABILITY_A032_ARCANE_BOMBARDMENT_ORANGE_ANTONIDAS_MEDIVH,
          ABILITY_ABEH_HEALING_WAVE_BLACK_EMPIRE,
          ABILITY_A10U_MANA_BURN_DALARAN_YOGG,
          ABILITY_A11O_BLACK_HOLE_KHADGAR,
        }
      });

      var poisonYor = new Stomp(ABILITY_ABNT_VOID_TOXIN_BLACK_EMPIRE)
      {
        Radius = 500,
        DamageBase = 60,
        DamageLevel = 20,
        DurationBase = 3,
        DurationLevel = 0,
        StunAbilityId = ABILITY_ABSS_SHADOW_STRIKE_VOID_TOXIN_REAL,
        StunOrderId = OrderId("shadowstrike"),
        SpecialEffect = @"Abilities\Weapons\ChimaeraAcidMissile\ChimaeraAcidMissile.mdl"
      };
      SpellSystem.Register(poisonYor);

      var genesisAttack = new SpellOnAttack(UNIT_U029_STYGIAN_HULK_YOGG,
        ABILITY_ABES_GENESIS_ATTACK_ICON_STYGIAN_HULK)
      {
        DummyAbilityId = ABILITY_ABEG_PARASITE_GENESIS_ATTACK_REAL,
        DummyOrderId = OrderId("parasite"),
        ProcChance = 1.0f
      };
      PassiveAbilityManager.Register(genesisAttack);

      var shadowVeilPassive = new NoTargetSpellOnAttack(UNIT_N0AH_DEFORMED_CHIMERA_YOGG,
  ABILITY_ABEV_SHADOW_VEIL)
      {
        DummyAbilityId = ABILITY_ABSV_SHADOW_VEIL_SHADOW_VEIL_REAL,
        DummyOrderId = OrderId("howlofterror"),
        ProcChance = 0.10f,
        RequiredResearch = UPGRADE_RBEV_SHADOW_VEIL_BLACK_EMPIRE
      };
      PassiveAbilityManager.Register(shadowVeilPassive);

      var shadowVeilSpell = new MassAnySpell(ABILITY_ABSV_SHADOW_VEIL_SHADOW_VEIL_REAL)
      {
        DummyAbilityId = ABILITY_ACAM_ANTI_MAGIC_SHELL_BLACK_EMPIRE,
        DummyAbilityOrderId = OrderId("antimagicshell"),
        Radius = 150,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.None
      };
      SpellSystem.Register(shadowVeilSpell);

      var paralysingFear = new SpellOnAttack(UNIT_O01G_BRUTE_YOGG,
        ABILITY_ABPF_PARALYSING_FEAR)
      {
        DummyAbilityId = ABILITY_ABSF_SLOW_PARALYSING_FEAR,
        DummyOrderId = OrderId("slow"),
        ProcChance = 0.2f
      };
      PassiveAbilityManager.Register(paralysingFear);

      var greaterParalysingFear = new SpellOnAttack(UNIT_H09F_DEEP_FIEND_YOGG,
        ABILITY_ABGP_GREATER_PARALYSING_FEAR)
      {
        DummyAbilityId = ABILITY_ABSG_SLOW_GREATER_PARALYSING_FEAR,
        DummyOrderId = OrderId("slow"),
        ProcChance = 0.4f
      };
      PassiveAbilityManager.Register(greaterParalysingFear);
    }
  }
}