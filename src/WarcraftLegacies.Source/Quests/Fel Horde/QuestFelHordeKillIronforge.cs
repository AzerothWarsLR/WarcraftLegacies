using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Fel_Horde;

public sealed class QuestFelHordeKillIronforge : QuestData
{
  private const int UnitLimit = 4;
  private const int UnittypeId = UNIT_NINA_INFERNAL_JUGGERNAUT_FEL;
  private const int BuildingId = UNIT_O030_FORTRESS_FEL_T3;

  public QuestFelHordeKillIronforge(Capital theGreatForge) : base("Felsteel Refining",
    "The smiths of Ironforge have long been put to use crafting goods and war machinery. In the hands of the Fel Horde, they could be used to smelt and refine the ultimate metal: Felsteel.",
    @"ReplaceableTextures\CommandButtons\BTNInfernalFlameCannon.blp")
  {
    AddObjective(new ObjectiveCapitalDead(theGreatForge));
    ResearchId = UPGRADE_R011_QUEST_COMPLETED_FELSTEEL_REFINING_FEL_HORDE;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Great Forge has been annihilated. The Fel Horde's peons immediately salvage its intact refineries and put them to purpose in the creation of Felsteel.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Learn to train " + I2S(UnitLimit) + " " +
                                                     GetObjectName(UnittypeId) + "s from the " +
                                                     GetObjectName(BuildingId) + " and acquire Felsteel Plating";

}
