using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Skywall;


public sealed class QuestKillDruids : QuestData
{
  private const int LimitChange = 2;
  private static readonly int _unittypeId1 = UNIT_U02P_DJINN_SKYWALL;
  private static readonly int _unittypeId2 = UNIT_LS06_EFREET_SKYWALL;

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "With Nordrassil under your control, the druids falter, and the elemental forces of Skywall grow strengthened.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Harness the magical essence of Nordrassil to empower your forces and unlocks the {GetObjectName(ABILITY_A0Y6_WATER_PRISON_ELEMENTAL_LORD)} for {GetObjectName(UNIT_N08S_ELEMENTAL_LORD_SKYWALL)}. The training limit of {GetObjectName(UNIT_U02P_DJINN_SKYWALL)}'s and {GetObjectName(UNIT_LS06_EFREET_SKYWALL)}'s is increased from 4 to 6";

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestKillDruids"/> class.
  /// </summary>
  public QuestKillDruids(Capital nordrassil) : base("Druids Demise",
    "Nordrassil, the World Tree, stands as a bastion of life and balance. By conquering it, Skywall can assert dominion and tip the scales of power.",
    @"ReplaceableTextures\CommandButtons\BTNTreeOfEternity.blp")
  {
    AddObjective(new ObjectiveControlCapital(nordrassil, false));
    ResearchId = UPGRADE_R01G_QUEST_COMPLETED_DRUIDS_DEMISE;
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.ModObjectLimit(_unittypeId1, LimitChange);
    completingFaction.ModObjectLimit(_unittypeId2, LimitChange);
  }
}
