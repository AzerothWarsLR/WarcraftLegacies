using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire
{
  public class BlackEmpireObelisk{

  
    private const int ABIL_ID = FourCC(A06Z);
    private const float DURATION = 180      ;//This duration needs to match the in-editor duration of the channel spell
    private const int OBELISK_ID = FourCC(n0BA);
    private const string PROGRESS_EFFECT = "war3mapImported\\Progressbar10sec.mdx";
    private const float PROGRESS_SCALE = 15;
    private const float PROGRESS_HEIGHT = 125;

    Event BlackEmpireObeliskSummoned
  


    private static thistype[] byCaster;
    private unit caster;
    private float tick;
    private float maxDuration;
    private float elapsedDuration;
    private ControlPoint controlPoint;
    private unit obeliskUnit;
    private effect sfxProgress;
    static thistype triggerObelisk

    private void destroy( ){
      BlzSetSpecialEffectPosition(sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(sfxProgress);
      obeliskUnit = null;
      sfxProgress = null;
      this.stopPeriodic();
      this.deallocate();
    }

    public ControlPoint operator ControlPoint( ){
      ;.controlPoint;
    }

    private void End(boolean finished ){
      if (elapsedDuration >= maxDuration){
        thistype.triggerObelisk = this;
        BlackEmpireObeliskSummoned.fire();
      }else {
        RemoveUnit(obeliskUnit);
      }
      destroy();
    }

    public static void OnAnyStopChannel( ){
      thistype.byCaster[GetUnitId(GetTriggerUnit())].End(false);
    }

    public static void OnAnyStartChannel( ){
      unit caster = GetTriggerUnit();
      ControlPoint controlPoint = ControlPoint.ByHandle(GetSpellTargetUnit());
      if (controlPoint != 0 && controlPoint == BlackEmpirePortal.Objective.NearbyControlPoint){
        thistype.byCaster[GetUnitId(caster)] = thistype.create(caster, controlPoint, DURATION);
        SetUnitInvulnerable(caster, false);
        SetUnitOwner(GetSpellTargetUnit(), GetOwningPlayer(caster), true);
      }else {
        IssueImmediateOrder(caster, "stop");
      }
    }

    private void periodic( ){
      tick = tick+1;
      elapsedDuration = elapsedDuration + 1/T32_FPS;
    }



    thistype (unit caster, ControlPoint controlPoint, float duration ){

      this.caster = caster;
      this.controlPoint = controlPoint;
      elapsedDuration = 0;
      maxDuration = duration;
      obeliskUnit = CreateUnit(GetOwningPlayer(caster), OBELISK_ID, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit), 270);

      sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit));
      BlzSetSpecialEffectTimeScale(sfxProgress, 10/duration);
      BlzSetSpecialEffectColorByPlayer(sfxProgress, GetOwningPlayer(caster));
      BlzSetSpecialEffectScale(sfxProgress, PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT + GetPositionZ(GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit)));

      this.startPeriodic();
      ;;
    }


    static BlackEmpireObelisk GetTriggerBlackEmpireObelisk( ){
      return BlackEmpireObelisk.triggerObelisk;
    }

    public static void Setup( ){
      RegisterSpellChannelAction(ABIL_ID,  BlackEmpireObelisk.OnAnyStartChannel);
      RegisterSpellEndcastAction(ABIL_ID,  BlackEmpireObelisk.OnAnyStopChannel);
      BlackEmpireObeliskSummoned = Event.create();
    }

  }
}
