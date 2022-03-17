public class QuestItemChannelRect{

  
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
    private float tick = 0;
    private float maxDuration = 0;
    private float elapsedDuration = 0;
    private effect sfxProgress = null;
    private effect sfx = null;
    private QuestItemChannelRect questItemChannelRect;
    private timer channelingTimer;
    private timerdialog channelingDialog;

    private void destroy( ){
      BlzSetSpecialEffectPosition(this.sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(this.sfxProgress);
      DestroyEffect(this.sfx);
      DestroyTimer(channelingTimer);
      DestroyTimerDialog(channelingDialog);
      this.stopPeriodic();
      this.deallocate();
    }

    //Finished is true if the channel ended successfully, and false if it was interrupted.
    private void End(boolean finished ){
      PauseUnit(caster, false);
      if (finished){
        SetUnitAnimation(caster, "spell");
      }
      if (UnitAlive(this.caster)){
        QueueUnitAnimation(caster, "stand");
      }
      questItemChannelRect.OnChannelEnd(this, finished);
      this.destroy();
    }

    private void periodic( ){
      this.tick = this.tick+1;

      if (this.tick > T32_FPS){
        this.tick = 0;
        if (this.caster == null || !UnitAlive(this.caster) || GetDistanceBetweenPoints(GetUnitX(caster), GetUnitY(caster), this.questItemChannelRect.X, this.questItemChannelRect.Y) > 100){
          this.End(false);
        }
      }

      this.elapsedDuration = this.elapsedDuration + 1/T32_FPS;
      if (this.elapsedDuration >= this.maxDuration){
        this.End(true);
      }
    }



     thistype (unit caster, float duration, float facing, QuestItemChannelRect questItemChannelRect ){

      this.caster = caster;
      this.questItemChannelRect = questItemChannelRect;
      this.elapsedDuration = 0;
      this.maxDuration = duration;

      SetUnitX(caster, questItemChannelRect.X);
      SetUnitY(caster, questItemChannelRect.Y);
      this.sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(caster), GetUnitY(caster));
      BlzSetSpecialEffectTimeScale(this.sfxProgress, 10/duration);
      BlzSetSpecialEffectColorByPlayer(this.sfxProgress, GetOwningPlayer(caster));
      BlzSetSpecialEffectScale(sfxProgress, PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT + GetPositionZ(questItemChannelRect.X, questItemChannelRect.Y));
      this.sfx = AddSpecialEffect(EFFECT, GetUnitX(caster), GetUnitY(caster));
      PauseUnit(caster, true);
      SetUnitAnimation(caster, "channel");
      BlzSetUnitFacingEx(caster, facing);

      if (this.questItemChannelRect.ParentQuest.Global == true){
        this.channelingTimer = CreateTimer();
        TimerStart(this.channelingTimer, maxDuration, false, null);
        this.channelingDialog = CreateTimerDialog(this.channelingTimer);
        TimerDialogSetTitle(this.channelingDialog, this.questItemChannelRect.ParentQuest.Title);
        TimerDialogDisplay(this.channelingDialog, true);
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
    private int requiredUnitTypeId = 0;

    private static trigger entersRectTrig = CreateTrigger();
    private static int count = 0;
    private static thistype[] byIndex;
    private static group tempGroup = CreateGroup();

    float operator X( ){
      return GetRectCenterX(this.targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(this.targetRect);
    }

    //The Unit Type ID the entering unit must have to start channeling
    void operator RequiredUnitTypeId=(int value ){
      this.requiredUnitTypeId = value;
    }

    private void OnRegionEnter(unit whichUnit ){
      if (GetOwningPlayer(whichUnit) == this.Holder.Player && UnitAlive(whichUnit) && Legend.ByHandle(GetTriggerUnit()) == this.targetLegend && this.channel == 0 && this.Progress == QUEST_PROGRESS_INCOMPLETE){
        if (this.requiredUnitTypeId == 0 || this.requiredUnitTypeId == GetUnitTypeId(GetTriggerUnit())){
          this.channel = Channel.create(whichUnit, this.duration, this.facing, this);
        }
      }
    }

    //Called by a Channel object to let the QuestItemChannelRect know it has ended.
    //Finished is true if the channel ended successfully, and false if it was interrupted.
    void OnChannelEnd(Channel whichChannel, boolean finished ){
      if (whichChannel == this.channel){
        if (finished){
          this.Progress = QUEST_PROGRESS_COMPLETE;
        }
        this.channel = 0;
      }
    }

    private static void OnAnyRegionEnter( ){
      int i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].target){
          thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        }
        i = i + 1;
      }
    }

     thistype (rect targetRect, string rectName, Legend whichLegend, float duration, float facing ){

      trigger trig = CreateTrigger();
      this.target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.targetLegend = whichLegend;
      this.duration = duration;
      this.Description = "Have " + whichLegend.Name + " channel at " + rectName + " for " + I2S(R2I(duration)) + " seconds";
      this.facing = facing;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, this.target, null);
      this.MapEffectPath = TARGET_EFFECT;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  thistype.OnAnyRegionEnter);
    }



}
