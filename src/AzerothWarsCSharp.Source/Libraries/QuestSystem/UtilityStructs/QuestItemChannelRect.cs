using System.Threading.Channels;
using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemChannelRect : QuestItemData{

  
    private const string TARGET_EFFECT = "war3mapImported\\Fortitude Rune Aura.mdx" ;//Make it so this renders in the world on the target location
    private const string EFFECT = "Abilities\\Spells\\Other\\Drain\\ManaDrainCaster.mdl";
    private const string PROGRESS_EFFECT = "war3mapImported\\Progressbar10sec.mdx";
    private const float PROGRESS_SCALE = 15;
    private const float PROGRESS_HEIGHT = 285;
  

    private static region RectToRegion(rect whichRect ){
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    //The channel animation and duration tracker.

    private unit caster;
    private float tick;
    private float maxDuration;
    private float elapsedDuration;
    private effect sfxProgress;
    private effect sfx;
    private QuestItemChannelRect questItemChannelRect;
    private timer channelingTimer;
    private timerdialog channelingDialog;

    private void destroy( ){
      BlzSetSpecialEffectPosition(sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(sfxProgress);
      DestroyEffect(sfx);
      DestroyTimer(channelingTimer);
      DestroyTimerDialog(channelingDialog);
      this.stopPeriodic();
      this.deallocate();
    }

    //Finished is true if the channel ended successfully, and false if it was interrupted.
    private void End(bool finished ){
      PauseUnit(caster, false);
      if (finished){
        SetUnitAnimation(caster, "spell");
      }
      if (UnitAlive(caster)){
        QueueUnitAnimation(caster, "stand");
      }
      questItemChannelRect.OnChannelEnd(this, finished);
      destroy();
    }

    private void periodic( ){
      tick = tick+1;

      if (tick > T32_FPS){
        tick = 0;
        if (caster == null || !UnitAlive(caster) || GetDistanceBetweenPoints(GetUnitX(caster), GetUnitY(caster), questItemChannelRect.X, questItemChannelRect.Y) > 100){
          this.End(false);
        }
      }

      elapsedDuration = elapsedDuration + 1/T32_FPS;
      if (elapsedDuration >= maxDuration){
        this.End(true);
      }
    }



    public QuestItemChannelRect(unit caster, float duration, float facing, QuestItemChannelRect questItemChannelRect ){

      this.caster = caster;
      this.questItemChannelRect = questItemChannelRect;
      elapsedDuration = 0;
      maxDuration = duration;

      SetUnitX(caster, questItemChannelRect.X);
      SetUnitY(caster, questItemChannelRect.Y);
      sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(caster), GetUnitY(caster));
      BlzSetSpecialEffectTimeScale(sfxProgress, 10/duration);
      BlzSetSpecialEffectColorByPlayer(sfxProgress, GetOwningPlayer(caster));
      BlzSetSpecialEffectScale(sfxProgress, PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT + GetPositionZ(questItemChannelRect.X, questItemChannelRect.Y));
      sfx = AddSpecialEffect(EFFECT, GetUnitX(caster), GetUnitY(caster));
      PauseUnit(caster, true);
      SetUnitAnimation(caster, "channel");
      BlzSetUnitFacingEx(caster, facing);

      if (this.questItemChannelRect.ParentQuest.Global == true){
        channelingTimer = CreateTimer();
        TimerStart(channelingTimer, maxDuration, false, null);
        channelingDialog = CreateTimerDialog(channelingTimer);
        TimerDialogSetTitle(channelingDialog, this.questItemChannelRect.ParentQuest.Title);
        TimerDialogDisplay(channelingDialog, true);
      }

      this.startPeriodic();
      ;;
    }


    //Bring a unit to a location, where they will channel for some period of time. When it)s over, the QuestItem is completed.

    private region target;
    private rect targetRect;
    private float duration;
    private Legend targetLegend;
    private Channel channel = 0;
    private float facing ;//Which way the unit faces while it is channeling
    private int requiredUnitTypeId;

    private static trigger entersRectTrig = CreateTrigger();
    private static int count = 0;
    private static thistype[] byIndex;
    private static group tempGroup = CreateGroup();

    float operator X( ){
      return GetRectCenterX(targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(targetRect);
    }

    //The Unit Type ID the entering unit must have to start channeling
    void operator RequiredUnitTypeId=(int value ){
      requiredUnitTypeId = value;
    }

    private void OnRegionEnter(unit whichUnit ){
      if (GetOwningPlayer(whichUnit) == this.Holder.Player && UnitAlive(whichUnit) && Legend.ByHandle(GetTriggerUnit()) == targetLegend && channel == 0 && this.Progress == QUEST_PROGRESS_INCOMPLETE){
        if (requiredUnitTypeId == 0 || requiredUnitTypeId == GetUnitTypeId(GetTriggerUnit())){
          channel = Channel.create(whichUnit, duration, facing, this);
        }
      }
    }

    //Called by a Channel object to let the QuestItemChannelRect know it has ended.
    //Finished is true if the channel ended successfully, and false if it was interrupted.
    void OnChannelEnd(Channel whichChannel, bool finished ){
      if (whichChannel == channel){
        if (finished){
          this.Progress = QUEST_PROGRESS_COMPLETE;
        }
        channel = 0;
      }
    }

    private static void OnAnyRegionEnter( ){
      var i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].target){
          thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        }
        i = i + 1;
      }
    }

    public QuestItemChannelRect(rect targetRect, string rectName, Legend whichLegend, float duration, float facing ){
      trigger trig = CreateTrigger();
      target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      targetLegend = whichLegend;
      this.duration = duration;
      this.Description = "Have " + whichLegend.Name + " channel at " + rectName + " for " + I2S(R2I(duration)) + " seconds";
      this.facing = facing;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, target, null);
      this.MapEffectPath = TARGET_EFFECT;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  thistype.OnAnyRegionEnter);
    }



  }
}
