using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  public sealed class QuestGoblinEmpire : QuestData
  {
    public QuestGoblinEmpire() : base("Goblin Empire",
      "All the Goblin syndicate's towns must be reunited under one banner.",
      @"ReplaceableTextures\CommandButtons\BTNGoblinWarZeppelin.blp")
    {
      AddObjective(new ObjectiveControlPoint(FourCC("n01X")));
      AddObjective(new ObjectiveControlPoint(FourCC("n00L")));
      AddObjective(new ObjectiveControlPoint(FourCC("n07Y")));
      AddObjective(new ObjectiveControlPoint(FourCC("n01E")));
      AddObjective(new ObjectiveControlPoint(FourCC("n04Z")));
      AddObjective(new ObjectiveControlPoint(FourCC("n05C")));
      AddObjective(new ObjectiveControlPoint(FourCC("n0A6")));
      ResearchId = FourCC("R07F");
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "With all the Goblin towns united, a new empire rises!";

    /// <inheritdoc/>
    protected override string RewardDescription => "Unlock the Intercontinental Artillery";
  }
}