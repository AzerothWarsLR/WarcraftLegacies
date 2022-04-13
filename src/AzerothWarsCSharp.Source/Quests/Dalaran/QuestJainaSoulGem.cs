using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestJainaSoulGem : QuestData
  {
    public QuestJainaSoulGem() : base("The Soul Gem",
      "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered.",
      "ReplaceableTextures\\CommandButtons\\BTNSoulGem.blp")
    {
      AddQuestItem(new QuestItemLegendInRect(LegendDalaran.LegendJaina, Regions.Jaina_soul_gem, "Scholomance"));
      AddQuestItem(new QuestItemLegendDead(LegendForsaken.LegendScholomance));
    }


    protected override string CompletionPopup =>
      "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance.";

    protected override string RewardDescription => "The Soul Gem";

    protected override void OnComplete()
    {
      UnitAddItemSafe(LegendDalaran.LegendJaina.Unit, ArtifactSetup.ArtifactSoulgem.Item);
    }
  }
}