using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  public sealed class QuestArathiVolunteers : QuestData
  {
    public QuestArathiVolunteers() : base("Arathi Volunteers", "The men of Stromgrade should join us in the fight.",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp")
    {
      AddObjective(
        new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01K_STROMGARDE_25GOLD_MIN)));
      AddObjective(
        new ObjectiveControlPoint(
          ControlPointManager.GetFromUnitType(Constants.UNIT_N01Z_ARATHI_HIGHLANDS_15GOLD_MIN)));
      ResearchId = FourCC("R089");
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "The Arathi have been convinced to join the fight.";

    protected override string RewardDescription => "Enable to train Mounted Archers";
  }
}