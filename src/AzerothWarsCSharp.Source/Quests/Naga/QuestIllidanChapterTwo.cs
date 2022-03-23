//Escapes Kalimdor, Find the Skull of Guldan

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterTwo : QuestData{



    private QuestData questToDiscover;

    protected override string CompletionPopup => 
      return "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";
    }

    protected override string CompletionDescription => 
      return "Chapter Three: Dwellers from the Deep";
    }

    protected override void OnComplete(){
      LEGEND_ILLIDAN.UnitType = FourCC("Eevi");
      questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  thistype (QuestData questToDiscover ){
      thistype this = thistype.allocate("Chapter Two: The Skull of GulFourCC("dan", "The mages of Dalaran are hiding a powerful artifact that will grant Illidan unlimited power: the Skull of Gul")dan.", "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp");
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_IllidanBoat1, "the escape boat"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_SkullOfGuldan, "the dungeons of Dalaran"));
      this.AddQuestItem(new QuestItemLegendHasArtifact(LEGEND_ILLIDAN, ARTIFACT_SKULLOFGULDAN));
      this.questToDiscover = questToDiscover;

      ;;
    }


  }
}
