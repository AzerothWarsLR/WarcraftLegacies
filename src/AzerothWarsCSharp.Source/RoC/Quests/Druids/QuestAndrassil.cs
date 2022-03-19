using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Druids
{
  public class QuestAndrassil{

  
    private const int RESEARCH_ID = FourCC(R002);
    private const int URSOC_ID = FourCC(E00A);
  



    protected override string CompletionPopup => 
      return "With Northrend finally free of the Lich KingFourCC(s influence, the time is ripe to regrow Andrassil in the hope that it can help reclaim this barren land.";
    }

    protected override string CompletionDescription => 
      return "A new capital at Grizzly Hills that can research a powerful upgrade for your Druids of the Claw, && you can train the hero Ursoc from the Altar of Elders";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      CreateUnit(Holder.Player, FourCC(n04F), GetRectCenterX(gg_rct_Andrassil), GetRectCenterY(gg_rct_Andrassil), 0);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(FourCC(R05X), UNLIMITED);
      Holder.ModObjectLimit(URSOC_ID, 1);
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Crown of the Snow", "Long ago, Fandral Staghelm cut a sapling from Nordrassil && used it to grow Andrassil in Northrend. Without the blessing of the Aspects, it fell to the Old GodsFourCC( corruption. If Northrend were to be reclaimed, Andrassil)s growth could begin anew.", "ReplaceableTextures\\CommandButtons\\BTNTreant.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n03U))));
      this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_GrizzlyHills, "Grizzly Hills", true));
      ;;
    }


  }
}
