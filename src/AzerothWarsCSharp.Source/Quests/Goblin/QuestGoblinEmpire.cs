using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Goblin
{
  public sealed class QuestGoblinEmpire : QuestData
  {
    public QuestGoblinEmpire() : base("Goblin Empire",
      "All the Goblin syndicatesFourCC( towns must be reunited under one banner.",
      "ReplaceableTextures\\CommandButtons\\BTNGoblinWarZeppelin.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01X"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00L"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n07Y"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01E"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n04Z"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n05C"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0A6"))));
      ResearchId = FourCC("R07F");
    }

    protected override string CompletionPopup => "With all the Goblin towns united, a new empire rises!";

    protected override string RewardDescription => "Unlock the Intercontinental Artillery";
  }
}