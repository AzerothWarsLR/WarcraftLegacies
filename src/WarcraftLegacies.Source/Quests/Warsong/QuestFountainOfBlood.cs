using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestFountainOfBlood : QuestData
  {
    private static readonly int ResearchId = FourCC("R00X");

    public QuestFountainOfBlood() : base("The Blood of Mannoroth",
      "Long ago, the orcs drank the blood of Mannoroth and were infused with demonic fury. A mere taste of his blood would reignite those powers.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLifeBlood.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendNeutral.FountainOfBlood, false));
    }
    
    protected override string CompletionPopup =>
      "The Fountain of Blood is under Warsong control. As the orcs drink from it, they feel a a familiar fury awake within them.";

    protected override string RewardDescription =>
      "Allows Orcish units to increase their attack rate and movement speed temporarily";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}