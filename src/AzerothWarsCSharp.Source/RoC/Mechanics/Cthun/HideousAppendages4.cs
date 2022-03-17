
public class SpawnTentacle4{

    
        private const int UNIT4_ID = FourCC(U02C);
        private const int TENTACLE_COUNT_BASE = 3;
        private const int TENTACLE3_ID = FourCC(n0B8);
        private const float RADIUS_OFFSET = 300  ;//How far away from the caster to position the Tentacles
    


        readonly static Table tentacleSetsByCasterHandleId;
        readonly unit caster = null;
        readonly unit[] TentaclesByIndex[30];
        readonly int TentacleCount = 0;
        private int tick = 0;

        void destroy( ){
            thistype.tentacleSetsByCasterHandleId[GetHandleId(this.caster)] = 0;
            this.stopPeriodic();
            this.kill();
            this.deallocate();
        }

        void kill( ){
            int i = 0;
            while(true){
            if ( i > this.TentacleCount){ break; }
                KillUnit(this.TentaclesByIndex[i]);
                this.TentaclesByIndex[i] = null;
                i = i + 1;
            }
        }

        void spawnTentacle(float x, float y, int index ){
            unit tempUnit = CreateUnit(GetOwningPlayer(this.caster), TENTACLE3_ID, x, y, 0);
            SetUnitAnimation(tempUnit, "birth");
            QueueUnitAnimation(tempUnit, "stand");
            SetUnitVertexColor(tempUnit, 255, 255, 255, 255);
            UnitAddAbility(tempUnit, FourCC(Aloc));
            SetUnitPathing(tempUnit, false);
            this.TentaclesByIndex[index] = tempUnit;
        }

        void reposition( ){
            int i = 0;
            float offsetAngle = 0;
            float offsetX = 0;
            float offsetY = 0;
            this.TentacleCount = TENTACLE_COUNT_BASE;
            while(true){
            if ( i == this.TentacleCount){ break; }
                offsetAngle = ((bj_PI*2)/this.TentacleCount)*i;
                offsetX = GetUnitX(caster) + RADIUS_OFFSET*Cos(offsetAngle);
                offsetY = GetUnitY(caster) + RADIUS_OFFSET*Sin(offsetAngle);
                if (GetDistanceBetweenPoints(GetUnitX(this.TentaclesByIndex[i]), GetUnitY(this.TentaclesByIndex[i]), offsetX, offsetY) > 0){
                    if (this.TentaclesByIndex[i] != null){
                        SetUnitPosition(this.TentaclesByIndex[i], offsetX, offsetY);
                    }else {
                        this.spawnTentacle(offsetX, offsetY, i);
                    }
                }
                i = i + 1;
            }
        }

        void periodic( ){
            if (this.caster == null){
                this.destroy();
                return;
            }
            if (!IsUnitAliveBJ(this.caster)){
                this.kill();
                return;
            }
            this.reposition();
            this.tick = this.tick + 1;
            if (this.tick/T32_FPS == 1){
                this.tick = 0;
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
        tentacleAppendageSet4 temptentacleAppendageSet4 = 0;
        unit triggerUnit = null;
        int triggerUnitHandleId = 0;
            triggerUnit = gg_unit_U02C_2829;
            triggerUnitHandleId = UNIT4_ID;
            temptentacleAppendageSet4 = tentacleAppendageSet4tentacleSetsByCasterHandleId[triggerUnitHandleId];
            if (temptentacleAppendageSet4 == 0){
                temptentacleAppendageSet4 = tentacleAppendageSet4create(triggerUnit);
                tentacleAppendageSet4tentacleSetsByCasterHandleId[triggerUnitHandleId] = temptentacleAppendageSet4;
            }
            triggerUnit = null;
    }

    private static void OnInit( ){
        trigger trig = CreateTrigger();
        TriggerRegisterTimerEventSingle( trig, 5 );
        TriggerAddCondition( trig, ( Built));
    }

}
