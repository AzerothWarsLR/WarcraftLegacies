using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;

namespace WarcraftLegacies.Source.Factions.Skywall.Quests;

/// <summary>
/// Capture points and get Npetulond and tidelords
/// </summary>
public sealed class QuestSubduing : QuestData
{

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestSubduing"/> class.
  /// </summary>
  public QuestSubduing() : base("Subduing Neptulon",
    "Neptulon is refusing to join us, we will force him to",
    @"ReplaceableTextures\CommandButtons\BTNTidelord.blp")
  {
    AddObjective(new ObjectiveControlLevel(UNIT_N00P_THE_ABYSS, 5));
    AddObjective(new ObjectiveControlLevel(UNIT_N028_MAELSTROM, 5));
    AddObjective(new ObjectiveControlLevel(UNIT_N04Y_NAZJATAR, 5));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_RSW3_QUEST_COMPLETED_SUBDUING_NEPTULON;
  }

  /// <uz />
  protected override string RewardDescription => Loc.Format(
    "Learn to train Neptulon from the {altar}, Tidal Lords from the {building}, and unlocks the {ability} for {unit}.",
    ("{altar}", GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_SKYWALL_ALTAR)),
    ("{building}", GetObjectName(UNIT_N07N_PAVILION_SKYWALL_MAGIC)),
    ("{ability}", GetObjectName(ABILITY_A0Y4_EARTH_PROTECTION_ELEMENTAL_LORD)),
    ("{unit}", GetObjectName(UNIT_N08S_ELEMENTAL_LORD_SKYWALL)));
}
