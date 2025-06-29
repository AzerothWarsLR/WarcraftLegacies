using System;
using System.Collections.Generic;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.Systems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.Gilneas;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using MacroTools.FactionChoices;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Gilneas : Faction
  {
    private readonly ArtifactSetup _artifactSetup;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly unit _gilneasGate;
    private readonly PreplacedUnitSystem _preplacedUnitSystem;

    /// <inheritdoc />
    public Gilneas(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
      : base("Gilneas", new[] {PLAYER_COLOR_COAL, PLAYER_COLOR_LIGHT_GRAY, PLAYER_COLOR_MINT},
      @"ReplaceableTextures\CommandButtons\BTNGreymane.blp")
    {
      TraditionalTeam = TeamSetup.NorthAlliance;
      _artifactSetup = artifactSetup;
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _gilneasGate = preplacedUnitSystem.GetUnit(UNIT_H02K_GREYMANE_S_GATE_CLOSED);
      StartingGold = 200;
      ControlPointDefenderUnitTypeId = UNIT_H0AF_CONTROL_POINT_DEFENDER_GILNEAS;
      IntroText = $"You are playing as the accursed {PrefixCol}Kingdom of Gilneas|r.\n\n" +
                  "You start isolated behind the Greymane Wall; the only way for an enemy to reach you is through the Greymane Gate or via the coast.\n\n" +
                  "You must raise an army and fight back against the feral wolves and worgen that have overrun your Kingdom.\n\n" +
                  "Once you have reclaimed Gilneas, open Greymane's Gate and march North to assist Lordaeron and Dalaran with the plague, if it's not too late.";

      GoldMines = new List<unit>
      {
        _preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(5466, 3210)),
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

    /// <inheritdoc />
    public override void OnNotPicked()
    {
      base.OnNotPicked();
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
        throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
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
      AddQuest(new QuestGoldrinn(_allLegendSetup.Gilneas.Tess, _allLegendSetup.Gilneas.Goldrinn, _artifactSetup.ScytheOfElune, druids));
    }
  }
}