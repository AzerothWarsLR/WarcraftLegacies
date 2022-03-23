//Escapes Kalimdor, Find the Skull of Guldan

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterTwo : QuestData{



    private QuestData _questToDiscover;

    protected override string CompletionPopup => "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";

    protected override string CompletionDescription => "Chapter Three: Dwellers from the Deep";

    protected override void OnComplete(){
      LEGEND_ILLIDAN.UnitType = FourCC("Eevi");
      _questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  QuestIllidanChapterTwo (QuestData questToDiscover ){
      thistype this = thistype.allocate("Chapter Two: The Skull of GulFourCC("dan", "The mages of Dalaran are hiding a powerful artifact that will grant Illidan unlimited power: the Skull of Gul")dan.", "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp");
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, Regions.IllidanBoat1.Rect, "the escape boat"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, Regions.SkullOfGuldan.Rect, "the dungeons of Dalaran"));
      this.AddQuestItem(new QuestItemLegendHasArtifact(LEGEND_ILLIDAN, ARTIFACT_SKULLOFGULDAN));
      this._questToDiscover = questToDiscover;

      ;;
    }


  }
}
