using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class BlackEmpireObelisk{

  
    private const int ABIL_ID = FourCC(A06Z);
    private const float DURATION = 180      ;//This duration needs to match the in-editor duration of the channel spell
    private const int OBELISK_ID = FourCC(n0BA);
    private const string PROGRESS_EFFECT = "war3mapImported\\Progressbar10sec.mdx";
    private const float PROGRESS_SCALE = 15;
    private const float PROGRESS_HEIGHT = 125;

    Event BlackEmpireObeliskSummoned
  


    private static thistype[] _byCaster;
    private unit _caster;
    private float _tick;
    private float _maxDuration;
    private float _elapsedDuration;
    private ControlPoint _controlPoint;
    private unit _obeliskUnit;
    private effect _sfxProgress;
    static thistype TriggerObelisk

    private void Destroy( ){
      BlzSetSpecialEffectPosition(_sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(_sfxProgress);
      _obeliskUnit = null;
      _sfxProgress = null;
      this.stopPeriodic();
      this.deallocate();
    }

    public ControlPoint operator ControlPoint( ){
      ;._controlPoint;
    }

    private void End(bool finished ){
      if (_elapsedDuration >= _maxDuration){
        thistype.triggerObelisk = this;
        BlackEmpireObeliskSummoned.fire();
      }else {
        RemoveUnit(_obeliskUnit);
      }
      Destroy();
    }

    public static void OnAnyStopChannel( ){
      thistype.byCaster[GetUnitId(GetTriggerUnit())].End(false);
    }

    public static void OnAnyStartChannel( ){
      unit caster = GetTriggerUnit();
      ControlPoint controlPoint = ControlPoint.GetFromUnit(GetSpellTargetUnit());
      if (controlPoint != 0 && controlPoint == BlackEmpirePortal.Objective.NearbyControlPoint){
        thistype.byCaster[GetUnitId(caster)] = thistype.create(caster, controlPoint, DURATION);
        SetUnitInvulnerable(caster, false);
        SetUnitOwner(GetSpellTargetUnit(), GetOwningPlayer(caster), true);
      }else {
        IssueImmediateOrder(caster, "stop");
      }
    }

    private void Periodic( ){
      _tick = _tick+1;
      _elapsedDuration = _elapsedDuration + 1/T32_FPS;
    }



    thistype (unit caster, ControlPoint controlPoint, float duration ){

      this._caster = caster;
      this._controlPoint = controlPoint;
      _elapsedDuration = 0;
      _maxDuration = duration;
      _obeliskUnit = CreateUnit(GetOwningPlayer(caster), OBELISK_ID, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit), 270);

      _sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit));
      BlzSetSpecialEffectTimeScale(_sfxProgress, 10/duration);
      BlzSetSpecialEffectColorByPlayer(_sfxProgress, GetOwningPlayer(caster));
      BlzSetSpecialEffectScale(_sfxProgress, PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(_sfxProgress, PROGRESS_HEIGHT + GetPositionZ(GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit)));

      this.startPeriodic();
      ;;
    }


    static BlackEmpireObelisk GetTriggerBlackEmpireObelisk( ){
      return BlackEmpireObelisk.TriggerObelisk;
    }

    public static void Setup( ){
      RegisterSpellChannelAction(ABIL_ID,  BlackEmpireObelisk.OnAnyStartChannel);
      RegisterSpellEndcastAction(ABIL_ID,  BlackEmpireObelisk.OnAnyStopChannel);
      BlackEmpireObeliskSummoned = Event.create();
    }

  }
}
