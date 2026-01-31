using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Fel_Horde;

public sealed class QuestFelHordeKillStormwind : QuestData
{
  private const int UnittypeId = UNIT_N086_FEL_DEATH_KNIGHT_FEL_ELITE_TIER;
  private const int UnitLimit = 6;
  private const int BuildingId = UNIT_O030_FORTRESS_FEL_T3;

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Stormwind's annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Teron Gorefiend can be trained at the altar and learn to train {UnitLimit} {GetObjectName(UnittypeId)}s from the {GetObjectName(BuildingId)}";

  public QuestFelHordeKillStormwind(Capital stormwindKeep) : base("Those Who Came Before",
    "During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return.",
    @"ReplaceableTextures\CommandButtons\BTNAcolyte.blp")
  {
    AddObjective(new ObjectiveCapitalDead(stormwindKeep));
    ResearchId = UPGRADE_R05Z_QUEST_COMPLETED_THOSE_WHO_CAME_BEFORE_FEL_HORDE;
  }

}
