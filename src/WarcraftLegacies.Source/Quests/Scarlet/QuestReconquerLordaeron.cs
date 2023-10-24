using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// Rebuild all the towns in Lordaeron to unlock the Divine Bastion and it's units.
  /// </summary>
  public sealed class QuestReconquerLordaeron : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestReconquerLordaeron"/> class.
    /// </summary>
    public QuestReconquerLordaeron(QuestData stratholme, QuestData capital, QuestData hearthglen, QuestData brill, QuestData andorhal) : base(
      "Reconquer Lordaeron",
      "The Scarlet Crusade ultimate objective is to purge all undead from the Plaguelands and rebuild Lordaeron to it's glory.",
      @"ReplaceableTextures/CommandButtons/BTNSalvationSpire.blp")
    {
      Required = true;
      AddObjective(new ObjectiveCompleteQuest(stratholme));
      AddObjective(new ObjectiveCompleteQuest(capital));
      AddObjective(new ObjectiveCompleteQuest(hearthglen));
      AddObjective(new ObjectiveCompleteQuest(brill));
      AddObjective(new ObjectiveCompleteQuest(andorhal));
      ResearchId = Constants.UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP; //TODO create research according to new title picked by writting team
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the safeguard of Lordaeron, the Scarlet Crusade gains the highest blessing of the Light";

    /// <inheritdoc/>
    protected override string RewardDescription => "Learn to build the Divine Bastion";
  }
}