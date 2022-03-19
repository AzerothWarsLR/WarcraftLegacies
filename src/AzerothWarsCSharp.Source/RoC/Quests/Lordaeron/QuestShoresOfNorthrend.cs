using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Lordaeron
{
  public class QuestShoresOfNorthrend{

  
    private const int RESEARCH_ID = FourCC(R06F);
  


    protected override string CompletionPopup => 
      return "Crown Prince Arthas, && what remains of his forces, have landed on the shores of Northrend && established a base camp.";
    }

    protected override string CompletionDescription => 
      return "A new base near Dragonblight in Northrend, && Arthas revives there";
    }

    private void OnFail( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED);
    }

    protected override void OnComplete(){
      KillNeutralHostileUnitsInRadius(4152, 16521, 2300);
      KillNeutralHostileUnitsInRadius(-2190, 16803, 700);
      if (GetOwningPlayer(LEGEND_ARTHAS.Unit) == this.Holder.Player){
        ReviveHero(LEGEND_ARTHAS.Unit, 400, 16102, true);
        BlzSetUnitFacingEx(LEGEND_ARTHAS.Unit, 112);
      }
      CreateStructureForced(this.Holder.Player, FourCC(h01C), -5133152, 1667969, 4757993*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(nmrk), 1280, 16064, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hctw), -640, 16576, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hbar), -256, 16832, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(halt), 416, 16416, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hpea), 8187402, 1686473, 6156587*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hpea), 6240182, 1672541, 4578159*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hgtw), -960, 15872, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hdes), 5826755, 1551292, 43173*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hshy), 800, 15776, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hcas), -512, 15744, 4712389*bj_RADTODEG, 512);
      CreateStructureForced(this.Holder.Player, FourCC(hbla), 672, 16928, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hfoo), 7711509, 1606429, 06401012*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hgtw), -448, 16128, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hwtw), 704, 17152, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hhou), -1088, 16576, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(h035), -928, 16736, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hfoo), -1744257, 1663117, 3987584*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hfoo), -3887579, 1687145, 4113693*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hfoo), -5615654, 1652154, 602386*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hdes), 2519047, 1556937, 533097*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hbla), 800, 16288, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hgtw), 1472, 16384, 4712389*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(hkni), 8933604, 1617558, 4130178*bj_RADTODEG, 256);
      CreateStructureForced(this.Holder.Player, FourCC(nchp), -9312155, 1655475, 5458206*bj_RADTODEG, 256);
      this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Shores of Northrend", "MalFourCC(ganis) citadel lies somewhere within the arctic wastes of the north. In order to assault the Dreadlord, Arthas must first establish a base camp at the shores of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, true));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_SCHOLOMANCE));
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(hshy)));
      ;;
    }


  }
}
