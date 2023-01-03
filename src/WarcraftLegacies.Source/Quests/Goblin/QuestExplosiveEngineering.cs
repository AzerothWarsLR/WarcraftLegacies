using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  public sealed class QuestExplosiveEngineering : QuestData
  {
    protected override string CompletionPopup => "We now have acquired Oil and can begin constructing War Machines";

    protected override string RewardDescription => "Gazlowee is trainable at the altar";

    public QuestExplosiveEngineering() : base("Explosive Engineering",
      "The Goblin chief engineer, Gazlowee, is overseeing the construction of the overseas oil platforms.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    {
      AddObjective(new ObjectiveBuild(Constants.UNIT_O04R_OIL_RIG_GOBLIN, 1));
      ResearchId = Constants.UPGRADE_R01F_QUEST_COMPLETED_EXPLOSIVE_ENGINEERING_FROSTWOLF;
      Required = true;
    }
  }
}