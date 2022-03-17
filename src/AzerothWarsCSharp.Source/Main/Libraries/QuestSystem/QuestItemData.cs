using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem
{
  public class QuestItemData{


    private QuestData parentQuest;
    private QuestItemData parentQuestItem;
    private int progress = QUEST_PROGRESS_INCOMPLETE;
    private string description = "";
    private questitem questItem;
    private minimapicon minimapIcon = null;

    private effect mapEffect = null ;//The visual effect that appears on the map, usually a Circle of Power
    private string mapEffectPath = null;

    private effect overheadEffect = null;
    private string overheadEffectPath = null;
    widget targetWidget = null;

    private static Event progressChanged;
    private static thistype triggerQuestItemData = 0;

    static thistype operator TriggerQuestItemData( ){
      ;type.triggerQuestItemData;
    }

    static Event operator ProgressChanged( ){
      ;type.progressChanged;
    }

    //Overhead effects get rendered over the target widget.
    widget operator TargetWidget( ){
      ;.targetWidget;
    }

    //The file path for the overhead effect to use for this item.
    string operator OverheadEffectPath( ){
      ;.overheadEffectPath;
    }

    string operator MapEffectPath( ){
      ;.mapEffectPath;
    }

    void operator MapEffectPath=(string value ){
      this.mapEffectPath = value;
    }

    void operator ParentQuestItem=(QuestItemData value ){
      this.parentQuestItem = value;
    }

    QuestData operator ParentQuest( ){
      ;.parentQuest;
    }

    void operator ParentQuest=(QuestData value ){
      this.parentQuest = value;
    }

    questitem operator QuestItem( ){
      ;.questItem;
    }

    void operator QuestItem=(questitem value ){
      this.questItem = value;
    }

    //Whether or not this can be seen as a bullet point in the quest log
    stub boolean operator ShowsInQuestLog( ){
      return true;
    }

    stub float operator X( ){
      return 0;
    }

    stub float operator Y( ){
      return 0;
    }

    Faction operator Holder( ){
      if (this.parentQuest != 0){
        ;.parentQuest.Holder;
      }else if (this.parentQuestItem != 0){
        ;.parentQuestItem.Holder;
      }else {
        //call BJDebugMsg("ERROR: " + this.Description + I2S(this) + " has no holder")
        return 0;
      }
    }

    boolean operator ProgressLocked( ){
      if (this.parentQuest != 0){
        ;.parentQuest.ProgressLocked;
      }else if (this.parentQuestItem != 0){
        ;.parentQuestItem.ProgressLocked;
      }else {
        //call BJDebugMsg("ERROR: " + this.Description + I2S(this) + " has no holder")
        return true;
      }
    }

    stub integer operator Progress( ){
      ;.progress;
    }

    void operator Progress=(int value ){
      if (this.ProgressLocked || this.progress == value){
        return;
      }
      this.progress = value;
      if (this.ShowsInQuestLog){
        if (value == QUEST_PROGRESS_INCOMPLETE){
          QuestItemSetCompleted(this.questItem, false);
          if (GetLocalPlayer() == this.Holder.Player){
            this.ShowLocal();
          }
          this.ShowSync();
        }else if (value == QUEST_PROGRESS_COMPLETE){
          QuestItemSetCompleted(this.questItem, true);
          if (GetLocalPlayer() == this.Holder.Player){
            this.HideLocal();
          }
          this.HideSync();
        }else if (value == QUEST_PROGRESS_UNDISCOVERED){
          QuestItemSetCompleted(this.questItem, false);
        }else if (value == QUEST_PROGRESS_FAILED){
          QuestItemSetCompleted(this.questItem, false);
        }
      }
      thistype.triggerQuestItemData = this;
      thistype.progressChanged.fire();
    }

    stub string operator Description( ){
      ;.description;
    }

    stub void operator Description=(string value ){
      this.description = value;
      if (this.questItem != null){
        QuestItemSetDescription(this.questItem, this.description);
      }
    }

    stub string operator PingPath( ){
      return "MinimapQuestObjectivePrimary";
    }

    //Run when added to a Quest
    stub void OnAdd( ){

    }

    //Shows the local aspects of this QuestItem, namely the minimap icon.
    void ShowLocal( ){
      int i = 0;
      if (this.Progress == QUEST_PROGRESS_INCOMPLETE && this.ParentQuest.Progress == QUEST_PROGRESS_INCOMPLETE){
        if (this.minimapIcon == null && this.X != 0 && this.Y != 0){
          this.minimapIcon = CreateMinimapIcon(this.X, this.Y, 255, 255, 0, SkinManagerGetLocalPath(this.PingPath), FOG_OF_WAR_MASKED);
        }else if (this.minimapIcon != null){
          SetMinimapIconVisible(this.minimapIcon, true);
        }
      }
    }

    //Shows the synchronous aspects of this QuestItem, namely the visible target circle.
    void ShowSync( ){
      string effectPath;
      if (this.Progress == QUEST_PROGRESS_INCOMPLETE && this.ParentQuest.Progress == QUEST_PROGRESS_INCOMPLETE){
        if (this.mapEffectPath != null && this.mapEffect == null){
          if (GetLocalPlayer() == this.Holder.Player){
            effectPath = this.mapEffectPath;
          }else {
            effectPath = "";
          }
          this.mapEffect = AddSpecialEffect(effectPath, this.X, this.Y);
          BlzSetSpecialEffectColorByPlayer(this.mapEffect, this.Holder.Player);
          BlzSetSpecialEffectHeight(this.mapEffect, 100 + GetPositionZ(this.X, this.Y));
        }

        if (this.overheadEffectPath != null && this.overheadEffect == null && this.TargetWidget != null){
          if (GetLocalPlayer() == this.Holder.Player){
            effectPath = this.overheadEffectPath;
          }else {
            effectPath = "";
          }
          this.overheadEffect = AddSpecialEffectTarget(effectPath, this.TargetWidget, "overhead");
        }
      }
    }

    //Hides the synchronous aspects of this QuestItem, namely the minimap icon.
    void HideLocal( ){
      int i = 0;
      if (this.minimapIcon != null){
        SetMinimapIconVisible(this.minimapIcon, false);
      }
    }

    //Hides the synchronous aspects of this QuestItem, namely the minimap icon.
    void HideSync( ){
      if (this.mapEffect != null){
        DestroyEffect(this.mapEffect);
        this.mapEffect = null;
      }
      if (this.overheadEffectPath != null){
        DestroyEffect(this.overheadEffect);
        this.overheadEffect = null;
      }
    }

    private void destroy( ){

    }

    thistype ( ){

      this.overheadEffectPath = "Abilities\\Spells\\Other\\TalkToMe\\TalkToMe";
      ;;
    }

    private static void onInit( ){
      thistype.progressChanged = Event.create();
    }


  }
}
