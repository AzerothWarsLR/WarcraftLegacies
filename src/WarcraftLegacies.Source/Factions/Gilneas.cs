using System;
using System.Collections.Generic;
using MacroTools.FactionChoices;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.Systems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Gilneas;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions;

public sealed class Gilneas : Faction
{
  private readonly ArtifactSetup _artifactSetup;
  private readonly AllLegendSetup _allLegendSetup;

  /// <inheritdoc />
  public Gilneas(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    : base("Gilneas", playercolor.Pink, @"ReplaceableTextures\CommandButtons\BTNGreymane.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    _artifactSetup = artifactSetup;
    _allLegendSetup = allLegendSetup;
    StartingGold = 200;
    ControlPointDefenderUnitTypeId = UNIT_H0AF_CONTROL_POINT_DEFENDER_GILNEAS;
    IntroText = $"You are playing as the accursed {PrefixCol}Kingdom of Gilneas|r.\n\n" +
                "You start beyond the Greymane Wall at Pyrewood Village;\n\n" +
                "You must raise an army and fight back against the feral wolves of Silverpine and the bandit lords of Durnholde that have taken over Southern-Lordaeron.\n\n" +
                "Once you have reclaimed Southern-Lordaeron, open Greymane's Gate and march North to assist Lordaeron and Dalaran with the plague, if it's not too late.";

    GoldMines = new List<unit>
    {
      preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(5466, 3210)),
    };
    Nicknames = new List<string>
    {
      "gil",
      "giln",
      "worgen",
      "worg",
      "dog",
      "dogs"
    };
    ProcessObjectInfo(GilneasObjectInfo.GetAllObjectLimits());
    RegisterFactionDependentInitializer<Legion>(RegisterBookOfMedivhQuest);
    RegisterFactionDependentInitializer<Druids>(RegisterDruidsQuests);
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    ReplaceWithFactionUnits(this);
    RegisterQuests();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestShadowfangKeep(Regions.ShadowfangUnlock));
    AddQuest(new QuestSouthshoregil(Regions.SouthshoreUnlock));
    AddQuest(new QuestGilneasCity(Regions.Gilneas));
    AddQuest(new QuestDalarangilneas(Regions.Dalaran));
    AddQuest(new QuestCrowley());
    AddQuest(new QuestExtractSunwellVial(_allLegendSetup.Quelthalas.Sunwell, _artifactSetup.SunwellVial));
  }
  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
    ModAbilityAvailability(ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
    ModAbilityAvailability(ABILITY_A0JV_SUMMON_INITIATE_MAGE_DALARAN_GARRISON, -1);
    ModAbilityAvailability(UPGRADE_R0A7_ESCAPE_TO_THERAMORE_DALARAN, -1);
    ModAbilityAvailability(ABILITY_A0KT_ARCANE_RECALL_DALARAN, -1);
  }

  private void ReplaceWithFactionUnits(Faction pickedFaction)
  {
    if (pickedFaction == null)
    {
      throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
    }

    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.ShadowfangUnlock, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.SouthshoreUnlock, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Gilneas, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Dalaran, pickedFaction);
  }

  private void RegisterBookOfMedivhQuest(Legion legion)
  {
    SharedQuestRepository.RegisterQuestFactory(faction => new QuestBookOfMedivh(_allLegendSetup.Gilneas.GilneasCastle,
      new NamedRectangle("Gilneas", Regions.BookOfMedivhGilneas), _artifactSetup.BookOfMedivh,
      faction == legion, faction == this));
  }

  private void RegisterDruidsQuests(Druids druids)
  {
    AddQuest(new QuestGoldrinn(_allLegendSetup.Gilneas.Tess, _allLegendSetup.Gilneas.Goldrinn, druids));
  }
}
