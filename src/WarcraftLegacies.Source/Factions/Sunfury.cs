using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.PreplacedWidgetsSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Quelthalas;
using WarcraftLegacies.Source.Quests.Sunfury;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Sunfury : Faction
{
  private readonly AllLegendSetup _allLegendSetup;

  /// <inheritdoc />
  public Sunfury(AllLegendSetup allLegendSetup)
    : base("Sunfury", playercolor.Violet, @"ReplaceableTextures\CommandButtons\BTNBloodMage2.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    _allLegendSetup = allLegendSetup;
    StartingGold = 200;
    CinematicMusic = "BloodElfTheme";
    FoodMaximum = 250;
    ControlPointDefenderUnitTypeId = UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS;
    IntroText = $"You are playing as the power-hungry {PrefixCol}Sunfury|r.\n\n" +
                "You begin in Netherstorm. Your first mission is to build three biodomes in the green areas protected by a bubble.\n\n" +
                "Unite with your fel ally to push through the Dark Portal and destroy Stormwind.\n\n" +
                "Your ultimate goal is to summon Kil'jaeden and annihilate your enemies.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), 3295, -22670),
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), 2529, -19141),
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), Regions.Area52Unlock.Center)
    };
    Nicknames = new List<string>
    {
      "sf",
      "sun"
    };
    ProcessObjectInfo(SunfuryObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
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
    PreplacedWidgets.Units.Get(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER).Dispose();
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
    AddQuest(new QuestSummonKil(_allLegendSetup.Stormwind.StormwindKeep, _allLegendSetup.Neutral.Karazhan,
      _allLegendSetup.Sunfury.Kael));
    AddQuest(new QuestForgottenKnowledge());
    AddQuest(new QuestWellOfEternity(_allLegendSetup.Sunfury.Kiljaeden));
    AddQuest(new QuestExtractSunwellVial(_allLegendSetup.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }
}
