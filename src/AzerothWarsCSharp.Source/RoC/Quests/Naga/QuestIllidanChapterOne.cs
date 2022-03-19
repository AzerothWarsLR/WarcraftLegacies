//Illidan Goes to Aetheneum, Finds Immoltar and kills him

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Naga
{
  public class QuestIllidanChapterOne{



    private QuestData questToDiscover;

    protected override string CompletionPopup => 
      return "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";
    }

    protected override string CompletionDescription => 
      return "Chapter Two - The Skull of GulFourCC(dan";
    }

    protected override void OnComplete(){
      questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  thistype (QuestData questToDiscover ){
      thistype this = thistype.allocate("Chapter One: The Aetheneum Secrets", "In order to gain the power he craves, Illidan must plunder the hidden Aetheneum library for its secrets.", "ReplaceableTextures\\CommandButtons\\BTNDoomlord.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_Dire_Maul_Entrance, "Feralas"));
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_AethneumLibraryEntrance, "the Aetheneum Library"));
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_ImmolFight, "ImmolFourCC(thar)s Lair"));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_IMMOLTHAR));
      this.questToDiscover = questToDiscover;
      ;;
    }


  }
}
