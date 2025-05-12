using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Skywall
{

  public sealed class QuestKillDruids : QuestData
  {
    private const int LimitChange = 2;
    private static readonly int UnittypeId1 = Constants.UNIT_U02P_DJINN_ELEMENTAL;
    private static readonly int UnittypeId2 = Constants.UNIT_LS06_EFREET_ELEMENTAL;

    /// <inheritdoc/>
    public override string RewardFlavour => 
      "With Nordrassil under your control, the druids falter, and the elemental forces of Skywall grow strengthened.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Harness the magical essence of Nordrassil to empower your forces and unlocks the {GetObjectName(Constants.ABILITY_A0Y6_WATER_PRISON_ELEMENTAL_LORD)} for {GetObjectName(Constants.UNIT_N08S_ELEMENTAL_LORD_ELEMENTAL)}. The training limit of {GetObjectName(Constants.UNIT_U02P_DJINN_ELEMENTAL)}'s and {GetObjectName(Constants.UNIT_LS06_EFREET_ELEMENTAL)}'s is increased from 4 to 6.";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestKillDruids"/> class.
    /// </summary>
    public QuestKillDruids(Capital nordrassil) : base("Druids Demise",
      "Nordrassil, the World Tree, stands as a bastion of life and balance. By conquering it, Skywall can assert dominion and tip the scales of power.",
      @"ReplaceableTextures\CommandButtons\BTNTreeOfEternity.blp")
    {
      AddObjective(new ObjectiveControlCapital(nordrassil, false));
      ResearchId = Constants.UPGRADE_R01G_QUEST_COMPLETED_DRUIDS_DEMISE;
    }

    /// <inheritdoc/> 
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(UnittypeId1, LimitChange);
      completingFaction.ModObjectLimit(UnittypeId2, LimitChange);
    }
  }
}