using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestCrystalGolem : QuestData
  {
    protected override string CompletionPopup => Holder.Name + "'s Earth Golems have been infused with living crystal.";

    protected override string RewardDescription => "Transform your Earth Golems into Crystal Golems";

    protected override void OnComplete()
    {
      DisplayResearchAcquired(Holder.Player, ResearchId, 1);
      Holder.ModObjectLimit(FourCC("n096"), -6);
      Holder.ModObjectLimit(FourCC("n0AD"), 6);
    }

    public QuestCrystalGolem() : base("Crystalsong Forest",
      "The living crystal of the Crystalsong Forest suffers from its proximity to the Legion. Freed from that corruption, it could be used to empower Dalaran's constructs."
      , "ReplaceableTextures\\CommandButtons\\BTNRockGolem.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02R"))));
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      ResearchId = FourCC("R045");
    }
  }
}