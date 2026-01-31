using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Draenei;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Draenei : Faction
{
  /// <inheritdoc />
  public Draenei()
    : base("The Exodar", playercolor.Mint, @"ReplaceableTextures\CommandButtons\BTNBOSSVelen.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
    StartingGold = 200;
    ControlPointDefenderUnitTypeId = UNIT_U008_CONTROL_POINT_DEFENDER_DRAENEI;
    IntroText = $"You are playing as the exiled {PrefixCol}Draenei|r.\n\n" +
                "You begin on Azuremyst Island, amid the wreckage of your flight from the Burning Legion.\n\n" +
                "Further inland your Night-elf allies will need your help against the Old Gods. Quickly build your base and gain entry to the Exodar.\n\n" +
                "Power up your buildings with your Arcane Wells to unlock powerful global abilities.";

    GoldMines = new List<unit>
    {
      AllPreplacedWidgets.Units.GetClosest(FourCC("ngol"), -21000, 8600)
    };
    Nicknames = new List<string>
    {
      "draenei",
      "dranei",
      "exo",
      "exodar",
      "theexodar",
      "goats"
    };
    ProcessObjectInfo(DraeneiObjectInfo.GetAllObjectLimits());
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
    Regions.ExodarBaseUnlock.CleanupNeutralPassiveUnits();
    Regions.Darkshore.CleanupNeutralPassiveUnits();
    base.OnNotPicked();
  }

  private void RegisterQuests()
  {
    var questRepairHull = new QuestRepairExodarHull(Regions.ExodarBaseUnlock, AllLegends.Draenei.LegendExodar);
    StartingQuest = questRepairHull;
    AddQuest(questRepairHull);
    AddQuest(new QuestRebuildCivilisation(Regions.Darkshore));
    AddQuest(new QuestShipArgus(
      AllPreplacedWidgets.Units.GetClosest(UNIT_H03V_ENTRANCE_PORTAL, Regions.OutlandToArgus.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_H03V_ENTRANCE_PORTAL, Regions.TempestKeepSpawn.Center),
      AllLegends.Draenei.Velen
    ));
    var crystalProtectors = GlobalGroup
      .EnumUnitsInRect(Regions.ExodarBaseUnlock.Rect)
      .Where(x => x.UnitType == UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER);
    var questRepairGenerator = new QuestRepairGenerator(AllLegends.Draenei.LegendExodarGenerator, questRepairHull, crystalProtectors);
    AddQuest(questRepairGenerator);
    AddQuest(new QuestTriumvirate(AllLegends.Draenei.Velen));
    var questDimensionalShip = new QuestDimensionalShip(Regions.ExodarBaseUnlock, questRepairGenerator, AllLegends.Draenei.LegendExodarGenerator);
    AddQuest(questDimensionalShip);
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }
}
