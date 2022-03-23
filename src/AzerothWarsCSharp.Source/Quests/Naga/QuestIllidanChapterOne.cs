//Illidan Goes to Aetheneum, Finds Immoltar and kills him

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterOne : QuestData{



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
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_Dire_Maul_Entrance, "Feralas"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_AethneumLibraryEntrance, "the Aetheneum Library"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_ImmolFight, "ImmolFourCC("thar")s Lair"));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_IMMOLTHAR));
      this.questToDiscover = questToDiscover;
      ;;
    }


  }
}
