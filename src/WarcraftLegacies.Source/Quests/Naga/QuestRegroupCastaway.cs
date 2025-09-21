using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestRegroupCastaway : QuestData
{
  public QuestRegroupCastaway() : base("Ancient Libraries",
    "Illidan will need to collect more lost knowledge to be form a new generation of Naga Sea Witch",
    @"ReplaceableTextures\CommandButtons\BTNNagaSeaWitch.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N00W_ZUL_GURUB));
    AddObjective(new ObjectiveControlPoint(UNIT_N00Y_DEADWIND_PASS));
    AddObjective(new ObjectiveControlPoint(UNIT_N00U_SWAMP_OF_SORROWS));
  }

  public override string RewardFlavour => "The powerful Summoners are serving their Master once again.";
}
