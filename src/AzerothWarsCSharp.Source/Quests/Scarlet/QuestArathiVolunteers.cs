using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestArathiVolunteers : QuestData
  {
    //Todo: bad flavour
    protected override string CompletionPopup => "The Arathi have been convinced to join the fight.";

    protected override string RewardDescription => "Enable to train Mounted Archers";

    public QuestArathiVolunteers() : base("Arathi Volunteers", "The men of Stromgrade should join us in the fight.",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01k"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01Z"))));
      ResearchId = FourCC("R089");
    }
  }
}