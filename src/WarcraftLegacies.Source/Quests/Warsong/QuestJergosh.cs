using MacroTools.ControlPointSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  /// <summary>
  /// Unlock Jergosh as a hero.
  /// </summary>
  public sealed class QuestJergosh : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestJergosh"/> class.
    /// </summary>
    public QuestJergosh(LegendaryHero grom) : base("Gul'dan's Remains",
      "The legendary warlock Gul'dan is said to have perished in his quest to find the eye of Sargeras. His body should contain secrets of unfathomable power for our Warlocks",
      "ReplaceableTextures\\CommandButtons\\BTNGuldan.blp")
    {
      AddObjective(new ObjectiveLegendInRect(grom, Regions.GuldansCorpse, "Gul'dan's remains"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00J_TOMB_OF_SARGERAS_20GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R08N_QUEST_COMPLETED_GUL_DAN_S_REMAINS;
    }

    //todo: bad flavour
    /// <inheritdoc />
    protected override string RewardFlavour => "Grom has found the body of Gul'dan.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Jergosh the Invoker can be trained from the {GetObjectName(Constants.UNIT_O020_ALTAR_OF_CONQUERORS_WARSONG_ALTAR)}";
  }
}