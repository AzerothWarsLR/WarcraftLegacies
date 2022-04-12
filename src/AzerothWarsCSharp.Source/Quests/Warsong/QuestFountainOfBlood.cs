using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestFountainOfBlood : QuestData
  {
    private static readonly int ResearchId = FourCC("R00X");

    public QuestFountainOfBlood() : base("The Blood of Mannoroth",
      "Long ago, the orcs drank the blood of Mannoroth and were infused with demonic fury. A mere taste of his blood would reignite those powers.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLifeBlood.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendFountainofblood, false));
    }


    protected override string CompletionPopup =>
      "The Fountain of Blood is under Warsong control. As the orcs drink from it, they feel a a familiar fury awake within them.";

    protected override string RewardDescription =>
      "Allows Orcish units to increase their attack rate and movement speed temporarily";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}