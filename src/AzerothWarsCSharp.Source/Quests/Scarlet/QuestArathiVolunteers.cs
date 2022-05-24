using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestArathiVolunteers : QuestData
  {
    public QuestArathiVolunteers() : base("Arathi Volunteers", "The men of Stromgrade should join us in the fight.",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01K"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01Z"))));
      ResearchId = FourCC("R089");
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "The Arathi have been convinced to join the fight.";

    protected override string RewardDescription => "Enable to train Mounted Archers";
  }
}