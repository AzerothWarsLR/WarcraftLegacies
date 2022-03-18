
namespace AzerothWarsCSharp.Source.RoC.Mechanics.Illidari
{
    public class SpawnTentacle2{

    
        private const int UNIT_ID2 = FourCC(U01Z);
        private const int TENTACLE_COUNT_BASE = 6;
        private const int TENTACLE2_ID = FourCC(n098);
        private const float RADIUS_OFFSET = 250  ;//How far away from the caster to position the Tentacles
    


        readonly static Table tentacleSetsByCasterHandleId;
        readonly unit caster;
        readonly unit[] TentaclesByIndex[30];
        readonly int TentacleCount;
        private int tick;

        void destroy( ){
            thistype.tentacleSetsByCasterHandleId[GetHandleId(caster)] = 0;
            this.stopPeriodic();
            kill();
            this.deallocate();
        }

        void kill( ){
            var i = 0;
            while(true){
                if ( i > TentacleCount){ break; }
                KillUnit(TentaclesByIndex[i]);
                TentaclesByIndex[i] = null;
                i = i + 1;
            }
        }

        void spawnTentacle(float x, float y, int index ){
            unit tempUnit = CreateUnit(GetOwningPlayer(caster), TENTACLE2_ID, x, y, 0);
            SetUnitAnimation(tempUnit, "birth");
            QueueUnitAnimation(tempUnit, "stand");
            SetUnitVertexColor(tempUnit, 255, 255, 255, 255);
            UnitAddAbility(tempUnit, FourCC(Aloc));
            SetUnitPathing(tempUnit, false);
            TentaclesByIndex[index] = tempUnit;
        }

        void reposition( ){
            var i = 0;
            float offsetAngle = 0;
            float offsetX = 0;
            float offsetY = 0;
            TentacleCount = TENTACLE_COUNT_BASE;
            while(true){
                if ( i == TentacleCount){ break; }
                offsetAngle = ((bj_PI*2)/TentacleCount)*i;
                offsetX = GetUnitX(caster) + RADIUS_OFFSET*Cos(offsetAngle);
                offsetY = GetUnitY(caster) + RADIUS_OFFSET*Sin(offsetAngle);
                if (GetDistanceBetweenPoints(GetUnitX(TentaclesByIndex[i]), GetUnitY(TentaclesByIndex[i]), offsetX, offsetY) > 0){
                    if (TentaclesByIndex[i] != null){
                        SetUnitPosition(TentaclesByIndex[i], offsetX, offsetY);
                    }else {
                        spawnTentacle(offsetX, offsetY, i);
                    }
                }
                i = i + 1;
            }
        }

        void periodic( ){
            if (caster == null){
                destroy();
                return;
            }
            if (!IsUnitAliveBJ(caster)){
                kill();
                return;
            }
            reposition();
            tick = tick + 1;
            if (tick/T32_FPS == 1){
                tick = 0;
            }
        }



        static void onInit( ){
            thistype.tentacleSetsByCasterHandleId = Table.create();
        }

        thistype (unit caster ){

            this.caster = caster;
            thistype.tentacleSetsByCasterHandleId[GetHandleId(this.caster)] = this;
            this.startPeriodic();
            ;;
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
