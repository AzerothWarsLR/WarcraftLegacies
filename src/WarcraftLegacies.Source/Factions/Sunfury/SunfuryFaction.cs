using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Spells;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Quelthalas.Quests;
using WarcraftLegacies.Source.Factions.Sunfury.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Factions.Sunfury;

public sealed class SunfuryFaction : Faction
{
  /// <inheritdoc />
  public SunfuryFaction()
    : base("Sunfury", playercolor.Violet, @"ReplaceableTextures\CommandButtons\BTNBloodMage2.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 240,
      Turns = 10
    };
    CinematicMusic = "BloodElfTheme";
    FoodMaximum = 250;
    ControlPointDefenderUnitTypeId = UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS;
    IntroText = $"You are playing as the power-hungry {PrefixCol}Sunfury|r.\n\n" +
                "You begin in Netherstorm. Your first mission is to build three biodomes in the green areas protected by a bubble.\n\n" +
                "Unite with your fel ally to push through the Dark Portal and destroy Stormwind.\n\n" +
                "Your ultimate goal is to summon Kil'jaeden and annihilate your enemies.";
    Nicknames = new List<string>
    {
      "sf",
      "sun"
    };
    ProcessObjectInfo(SunfuryObjectInfo.GetAllObjectLimits());
  }
  private static void RegisterSpells()
  {
    var resurgentFlameStrike = new ResurgentSpell(ABILITY_A04H_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS,
      ABILITY_A0F9_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS_DUMMY, ORDER_FLAMESTRIKE)
    {
      Duration = 14,
      Interval = 7
    };
    SpellRegistry.Register(resurgentFlameStrike);

    var massBanish = new MassAnySpell(ABILITY_A0FD_MASS_BANISH_QUEL_THALAS_KAEL_THAS)
    {
      DummyAbilityId = ABILITY_A0FE_MASS_BANISH_QUEL_THALAS_KAEL_THAS_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_BANISH,
      Radius = 250,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massBanish);

    var siphoningRitual = new SiphoningRitualSpell(ABILITY_A0FA_SIPHONING_RITUAL_QUEL_THALAS_KAEL_THAS)
    {
      TargetCountBase = 24,
      TargetCountLevel = 0,
      LifeDrainedPerSecondBase = 30,
      LifeDrainedPerSecondLevel = 10,
      ManaDrainedPerSecondBase = 15,
      ManaDrainedPerSecondLevel = 5,
      Range = 800,
      Radius = 225,
      Interval = 0.1f
    };
    SpellRegistry.Register(siphoningRitual);
  }
  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    RegisterSpells();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  /// <inheritdoc />
  public override void OnNotPicked()
  {
    Regions.Area52Unlock.CleanupNeutralPassiveUnits();
    Regions.Netherstorm.CleanupNeutralPassiveUnits();
    Regions.UpperNetherstorm.CleanupNeutralPassiveUnits();
    Regions.TempestKeep.CleanupNeutralPassiveUnits();
    Regions.SunfuryStartingPosition.CleanupNeutralPassiveUnits();
    AllPreplacedWidgets.Units.Get(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER).Dispose();
    base.OnNotPicked();
  }

  private void RegisterQuests()
  {
    var newQuest =
      AddQuest(new QuestTempestKeep(Regions.TempestKeep, Regions.Biodome1, Regions.Biodome2, Regions.Biodome3));
    StartingQuest = newQuest;

    AddQuest(new QuestArea52(Regions.Area52Unlock));
    AddQuest(new QuestUpperNetherstorm(Regions.UpperNetherstorm));
    AddQuest(new QuestSolarian(Artifacts.EssenceofMurmur));
    AddQuest(new QuestSummonKil(AllLegends.Stormwind.StormwindKeep, AllLegends.Neutral.Karazhan,
      AllLegends.Sunfury.Kael));
    AddQuest(new QuestForgottenKnowledge());
    AddQuest(new QuestWellOfEternity(AllLegends.Sunfury.Kiljaeden));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }
}
