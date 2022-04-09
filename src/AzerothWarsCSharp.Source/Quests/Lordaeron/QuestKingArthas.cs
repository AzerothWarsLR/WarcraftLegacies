using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestKingArthas : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R08A"); //This research is given when the quest is completed
    private readonly unit _terenas;
    
    public QuestKingArthas(unit terenas) : base("Line of Succession",
      "Arthas Menethil is the one true heir of the Kingdom of Lordaeron. The only thing standing in the way of his coronation is the world-ending threat of the Scourge.",
      "ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
    {
      AddQuestItem(new QuestItemLegendNotPermanentlyDead(LegendLordaeron.LegendCapitalpalace));
      AddQuestItem(new QuestItemControlLegend(LegendLordaeron.LegendArthas, true));
      AddQuestItem(new QuestItemLegendDead(LegendScourge.LegendLichking));
      AddQuestItem(new QuestItemLegendInRect(LegendLordaeron.LegendArthas, Regions.King_Arthas_crown.Rect, "King Terenas"));
      ResearchId = QuestResearchId;
      _terenas = terenas;
    }


    protected override string CompletionPopup =>
      "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. King Terenas Menethil proudly abdicates in favor of his son.";

    protected override string RewardDescription =>
      "Arthas gains 2000 experience and the Crown of Lordaeron, and he can no longer permanently die";

    protected override void OnComplete()
    {
      BlzSetUnitName(LegendLordaeron.LegendArthas.Unit, "King of Lordaeron");
      BlzSetUnitName(_terenas, "King Emeritus Terenas Menethil");
      RemoveUnit(_terenas);
      AddHeroXP(LegendLordaeron.LegendArthas.Unit, 2000, true);
      UnitAddItemSafe(LegendLordaeron.LegendArthas.Unit, ArtifactSetup.ArtifactCrownlordaeron.Item);
      LegendLordaeron.LegendArthas.ClearUnitDependencies();
    }
  }
}