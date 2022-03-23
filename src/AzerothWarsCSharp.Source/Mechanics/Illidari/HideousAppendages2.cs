
namespace AzerothWarsCSharp.Source.Mechanics.Illidari
{
    public class SpawnTentacle2{

    
        private const int UNIT_ID2 = FourCC(U01Z);
        private const int TENTACLE_COUNT_BASE = 6;
        private const int TENTACLE2_ID = FourCC(n098);
        private const float RADIUS_OFFSET = 250  ;//How far away from the caster to position the Tentacles
    


        readonly static Table TentacleSetsByCasterHandleId;
        readonly unit _caster;
        readonly unit[] _tentaclesByIndex[30];
        readonly int _tentacleCount;
        private int _tick;

        void Destroy( ){
            thistype.tentacleSetsByCasterHandleId[GetHandleId(_caster)] = 0;
            this.stopPeriodic();
            Kill();
            this.deallocate();
        }

        void Kill( ){
            var i = 0;
            while(true){
                if ( i > _tentacleCount){ break; }
                KillUnit(_tentaclesByIndex[i]);
                _tentaclesByIndex[i] = null;
                i = i + 1;
            }
        }

        void SpawnTentacle(float x, float y, int index ){
            unit tempUnit = CreateUnit(GetOwningPlayer(_caster), TENTACLE2_ID, x, y, 0);
            SetUnitAnimation(tempUnit, "birth");
            QueueUnitAnimation(tempUnit, "stand");
            SetUnitVertexColor(tempUnit, 255, 255, 255, 255);
            UnitAddAbility(tempUnit, FourCC(Aloc));
            SetUnitPathing(tempUnit, false);
            _tentaclesByIndex[index] = tempUnit;
        }

        void Reposition( ){
            var i = 0;
            float offsetAngle = 0;
            float offsetX = 0;
            float offsetY = 0;
            _tentacleCount = TENTACLE_COUNT_BASE;
            while(true){
                if ( i == _tentacleCount){ break; }
                offsetAngle = ((bj_PI*2)/_tentacleCount)*i;
                offsetX = GetUnitX(_caster) + RADIUS_OFFSET*Cos(offsetAngle);
                offsetY = GetUnitY(_caster) + RADIUS_OFFSET*Sin(offsetAngle);
                if (GetDistanceBetweenPoints(GetUnitX(_tentaclesByIndex[i]), GetUnitY(_tentaclesByIndex[i]), offsetX, offsetY) > 0){
                    if (_tentaclesByIndex[i] != null){
                        SetUnitPosition(_tentaclesByIndex[i], offsetX, offsetY);
                    }else {
                        SpawnTentacle(offsetX, offsetY, i);
                    }
                }
                i = i + 1;
            }
        }

        void Periodic( ){
            if (_caster == null){
                Destroy();
                return;
            }
            if (!IsUnitAliveBJ(_caster)){
                Kill();
                return;
            }
            Reposition();
            _tick = _tick + 1;
            if (_tick/T32_FPS == 1){
                _tick = 0;
            }
        }



        static void OnInit( ){
            thistype.tentacleSetsByCasterHandleId = Table.create();
        }

        thistype (unit caster ){

            this._caster = caster;
            thistype.tentacleSetsByCasterHandleId[GetHandleId(this._caster)] = this;
            this.startPeriodic();
            
        }


        private static void Built( ){
            tentacleAppendageSet2 temptentacleAppendageSet2 = 0;
            unit triggerUnit = null;
            var triggerUnitHandleId = 0;
            triggerUnit = gg_unit_U01Z_1237;
            triggerUnitHandleId = UNIT_ID2;
            temptentacleAppendageSet2 = tentacleAppendageSet2tentacleSetsByCasterHandleId[triggerUnitHandleId];
            if (temptentacleAppendageSet2 == 0){
                temptentacleAppendageSet2 = tentacleAppendageSet2create(triggerUnit);
                tentacleAppendageSet2tentacleSetsByCasterHandleId[triggerUnitHandleId] = temptentacleAppendageSet2;
            }
            triggerUnit = null;
        }

        public static void Setup( ){
            trigger trig = CreateTrigger();
            TriggerRegisterEnterRectSimple( trig, gg_rct_NzothIni);
            TriggerAddCondition( trig, ( Built));
        }

    }
}
