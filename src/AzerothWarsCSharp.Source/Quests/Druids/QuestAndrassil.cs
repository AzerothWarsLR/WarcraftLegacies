using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAndrassil : QuestData
  {
    private static readonly int ResearchId = FourCC("R002");
    private static readonly int UrsocId = FourCC("E00A");

    public QuestAndrassil() : base("Crown of the Snow",
      "Long ago, Fandral Staghelm cut a sapling from Nordrassil and used it to grow Andrassil in Northrend. Without the blessing of the Aspects, it fell to the Old Gods' corruption. If Northrend were to be reclaimed, Andrassil's growth could begin anew.",
      "ReplaceableTextures\\CommandButtons\\BTNTreant.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendScourge.LegendLichking));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n03U"))));
      AddObjective(new ObjectiveAnyUnitInRect(Regions.GrizzlyHills, "Grizzly Hills", true));
    }


    protected override string CompletionPopup =>
      "With Northrend finally free of the Lich KingFourCC(s influence, the time is ripe to regrow Andrassil in the hope that it can help reclaim this barren land.";

    protected override string RewardDescription =>
      "A new capital at Grizzly Hills that can research a powerful upgrade for your Druids of the Claw, and you can train the hero Ursoc from the Altar of Elders";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
      CreateUnit(completingFaction.Player, FourCC("n04F"), GetRectCenterX(Regions.Andrassil.Rect),
        GetRectCenterY(Regions.Andrassil.Rect), 0);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(FourCC("R05X"), Faction.UNLIMITED);
      whichFaction.ModObjectLimit(UrsocId, 1);
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}