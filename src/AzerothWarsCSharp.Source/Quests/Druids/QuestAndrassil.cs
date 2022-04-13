using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAndrassil : QuestData
  {
    private static readonly int ResearchId = FourCC("R002");
    private static readonly int UrsocId = FourCC("E00A");

    public QuestAndrassil() : base("Crown of the Snow",
      "Long ago, Fandral Staghelm cut a sapling from Nordrassil && used it to grow Andrassil in Northrend. Without the blessing of the Aspects, it fell to the Old Gods' corruption. If Northrend were to be reclaimed, Andrassil's growth could begin anew.",
      "ReplaceableTextures\\CommandButtons\\BTNTreant.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendScourge.LegendLichking));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03U"))));
      this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.GrizzlyHills, "Grizzly Hills", true));
    }


    protected override string CompletionPopup =>
      "With Northrend finally free of the Lich KingFourCC(s influence, the time is ripe to regrow Andrassil in the hope that it can help reclaim this barren land.";

    protected override string RewardDescription =>
      "A new capital at Grizzly Hills that can research a powerful upgrade for your Druids of the Claw, && you can train the hero Ursoc from the Altar of Elders";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      CreateUnit(Holder.Player, FourCC("n04F"), GetRectCenterX(Regions.Andrassil.Rect),
        GetRectCenterY(Regions.Andrassil.Rect), 0);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(FourCC("R05X"), Faction.UNLIMITED);
      Holder.ModObjectLimit(UrsocId, 1);
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}