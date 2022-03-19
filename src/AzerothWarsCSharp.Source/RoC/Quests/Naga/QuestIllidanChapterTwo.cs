//Escapes Kalimdor, Find the Skull of Guldan

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Naga
{
  public class QuestIllidanChapterTwo{



    private QuestData questToDiscover;

    protected override string CompletionPopup => 
      return "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";
    }

    protected override string CompletionDescription => 
      return "Chapter Three: Dwellers from the Deep";
    }

    protected override void OnComplete(){
      LEGEND_ILLIDAN.UnitType = FourCC(Eevi);
      questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  thistype (QuestData questToDiscover ){
      thistype this = thistype.allocate("Chapter Two: The Skull of GulFourCC(dan", "The mages of Dalaran are hiding a powerful artifact that will grant Illidan unlimited power: the Skull of Gul)dan.", "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_IllidanBoat1, "the escape boat"));
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_SkullOfGuldan, "the dungeons of Dalaran"));
      this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_ILLIDAN, ARTIFACT_SKULLOFGULDAN));
      this.questToDiscover = questToDiscover;

      ;;
    }


  }
}
