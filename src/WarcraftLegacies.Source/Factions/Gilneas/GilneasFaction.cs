using System;
using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Factions.Choices;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.Gilneas.Quests;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Gilneas;

public sealed class GilneasFaction : Faction
{
  /// <inheritdoc />
  public GilneasFaction() : this(playercolor.Pink)
  {
  }

  /// <summary>Creates Gilneas with a specific player colour.</summary>
  public GilneasFaction(playercolor playerColor)
    : base("Gilneas", playerColor, @"ReplaceableTextures\CommandButtons\BTNGreymane.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 100,
      Turns = 10
    };
    ControlPointDefenderUnitTypeId = UNIT_H0AF_CONTROL_POINT_DEFENDER_GILNEAS;
    IntroText = () => Loc.Format(
      "You are playing as the accursed {faction}.\n\nYou start beyond the Greymane Wall at Pyrewood Village;\n\nYou must raise an army and fight back against the feral wolves of Silverpine and the bandit lords of Durnholde that have taken over Southern-Lordaeron.\n\nOnce you have reclaimed Southern-Lordaeron, open Greymane's Gate and march North to assist Lordaeron and Dalaran with the plague, if it's not too late.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Kingdom of Gilneas")}|r"));
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
    RegisterFactionDependentInitializer<LegionFaction>(RegisterBookOfMedivhQuest);
    RegisterFactionDependentInitializer<DruidsFaction>(RegisterDruidsQuests);
  }

  /// <summary>Whether Gilneas is formed partway through the game, leaving the map's units where they are.</summary>
  public bool FormedMidGame { get; init; }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    if (!FormedMidGame)
    {
      ReplaceWithFactionUnits(this);
    }

    RegisterQuests();
    GilneasSpells.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    if (FormedMidGame)
    {
      ModObjectLimit(UPGRADE_R02R_QUEST_COMPLETED_LIBERATION_OF_GILNEAS, 1);
      SetObjectLevel(UPGRADE_R02R_QUEST_COMPLETED_LIBERATION_OF_GILNEAS, 1);
    }
    else
    {
      StartingQuest = AddQuest(new QuestShadowfangKeep(Regions.ShadowfangUnlock));
      AddQuest(new QuestSouthshoregil(Regions.SouthshoreUnlock));
      AddQuest(new QuestGilneasCity(Regions.Gilneas));
      AddQuest(new QuestDalarangilneas(Regions.Dalaran));
    }

    AddQuest(new QuestCrowley());
    var sunwell = AllLegends.Quel.Sunwell.Unit;
    if (sunwell != null && sunwell.Alive)
    {
      AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
    }
  }
  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
    ModAbilityAvailability(UPGRADE_R0A7_ESCAPE_TO_THERAMORE_DALARAN, -1);
  }

  private static void ReplaceWithFactionUnits(Faction pickedFaction)
  {
    if (pickedFaction == null)
    {
      throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
    }

    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.ShadowfangUnlock, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.SouthshoreUnlock, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Gilneas, pickedFaction);
    AllPreplacedWidgets.Units.Get(UNIT_N0DS_POWER_GENERATOR).Dispose();
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Dalaran, pickedFaction);
  }

  private void RegisterBookOfMedivhQuest(LegionFaction legion)
  {
    if (FormedMidGame)
    {
      return;
    }

    SharedQuestRepository.RegisterQuestFactory(faction => new QuestBookOfMedivh(AllLegends.Gilneas.GilneasCastle,
      new NamedRectangle("Gilneas", Regions.BookOfMedivhGilneas), Artifacts.BookOfMedivh,
      faction != this, faction == this, faction == legion));
  }

  private void RegisterDruidsQuests(DruidsFaction druids)
  {
    AddQuest(new QuestGoldrinn(AllLegends.Gilneas.Tess, AllLegends.Gilneas.Goldrinn, druids));
  }
}
