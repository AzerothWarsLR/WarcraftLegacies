using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.Display;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestCrystalGolem : QuestData
  {
    public QuestCrystalGolem() : base("Crystalsong Forest",
      "The living crystal of the Crystalsong Forest suffers from its proximity to the Legion. Freed from that corruption, it could be used to empower Dalaran's constructs."
      , "ReplaceableTextures\\CommandButtons\\BTNRockGolem.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02R"))));
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      ResearchId = FourCC("R045");
    }

    protected override string CompletionPopup => Holder.Name + "'s Earth Golems have been infused with living crystal.";

    protected override string RewardDescription => "Transform your Earth Golems into Crystal Golems";

    protected override void OnComplete()
    {
      DisplayResearchAcquired(Holder.Player, ResearchId, 1);
      Holder.ModObjectLimit(FourCC("n096"), -6);
      Holder.ModObjectLimit(FourCC("n0AD"), 6);
    }
  }
}