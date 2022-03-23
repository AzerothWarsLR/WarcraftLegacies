using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Goblin
{
  public sealed class QuestGoblinEmpire : QuestData
  {
    protected override string CompletionPopup => "With all the Goblin towns united, a new empire rises!";

    protected override string CompletionDescription => "Unlock the Intercontinental Artillery";

    public QuestGoblinEmpire() : base("Goblin Empire",
      "All the Goblin syndicatesFourCC( towns must be reunited under one banner.",
      "ReplaceableTextures\\CommandButtons\\BTNGoblinWarZeppelin.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n01X""))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n00L""))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n07Y""))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n01E""))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n04Z""))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n05C""))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC(""n0A6""))));
      ResearchId = FourCC(""R07F"");
    }
  }
}