public class DemonGate{

  
    private const float TICK_RATE = 1;
    private const float FACING_OFFSET = -45 ;//Demon gate model is spun around weirdly so this reverses that for code
    private const float SPAWN_DISTANCE = 300 ;//How far away from the gate to spawn units

    private const int TOGGLE_ABILITY = FourCC(A05V) ;//Gates can use this to toggle summoning
    private const int TOGGLE_BUFF = FourCC(B08B) ;//Gates need this buff to be able to summon
  


    readonly static Table byUnitType;

    private int spawnUnitType;
    private int interval;
    private int unitType;
    private int count;

    public integer operator Count( ){
      return count;
    }

    public integer operator Interval( ){
      return interval;
    }

    public integer operator SpawnUnitType( ){
      return spawnUnitType;
    }

     thistype (int gateUnitType, int spawnUnitType, int interval, int count ){

      this.unitType = gateUnitType;
      this.interval = interval;
      this.spawnUnitType = spawnUnitType;
      this.count = count;
      byUnitType[unitType] = this;
      ;;
    }

    private static void onInit( ){
      byUnitType = Table.create();
    }



    private static Table byHandle;

    private unit u;
    private boolean enabled;
    private int tick;
    private group spawnedDemons;
    private DemonGateType gateType;

    private void destroy( ){
      byHandle[GetHandleId(u)] = 0;
      u = null;
      DestroyGroup(spawnedDemons);
      stopPeriodic();
    }

    private void operator MaxMana=(int i ){
      BlzSetUnitMaxMana(u, i);
    }

    private integer operator MaxMana( ){
      return BlzGetUnitMaxMana(u);
    }

    private float operator Mana( ){
      return GetUnitState(u, UNIT_STATE_MANA);
    }

    private void operator Mana=(float r ){
      SetUnitState(u, UNIT_STATE_MANA, r);
    }

    private player operator Owner( ){
      return GetOwningPlayer(u);
    }

    private float operator RallyX( ){
      location rally;
      float x;
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(this.u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.RallyX;
      }
      rally = GetUnitRallyPoint(u);
      x = GetLocationX(rally);
      RemoveLocation(rally);
      rally = null;
      return x;
    }

     private float operator RallyY( ){
      location rally;
      float y;
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(this.u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.RallyY;
      }
      rally = GetUnitRallyPoint(u);
      y = GetLocationY(rally);
      RemoveLocation(rally);
      rally = null;
      return y;
    }

    private float operator SpawnX( ){
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(this.u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.SpawnX;
      }
      return GetPolarOffsetX(X, SPAWN_DISTANCE, Facing);
    }

    private float operator SpawnY( ){
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(this.u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.SpawnY;
      }
      return GetPolarOffsetY(Y, SPAWN_DISTANCE, Facing);
    }

    private float operator X( ){
      return GetUnitX(u);
    }

    private float operator Y( ){
      return GetUnitY(u);
    }

    private float operator Facing( ){
      return GetUnitFacing(u) + FACING_OFFSET;
    }

    private void operator GateType=(DemonGateType gateType ){
      if (gateType == 0){
        BJDebugMsg("ERROR: invalid DemonGateType supplied to DemonGate " + I2S(this));
        return;
      }
      MaxMana = gateType.Interval;
      this.gateType = gateType;
    }

    private void spawnUnit( ){
      unit newUnit;
      int i = 0;
      while(true){
        if ( i == gateType.Count){ break; }
        newUnit = CreateUnit(Owner, gateType.SpawnUnitType, SpawnX, SpawnY, Facing);
        GroupAddUnit(spawnedDemons, newUnit);
        IssuePointOrder(newUnit, "attack", this.RallyX, this.RallyY);
        i = i + 1;
      }
      newUnit = null;
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl", SpawnX, SpawnY));
    }

    private void onUpgrade( ){
      GateType = DemonGateType.byUnitType[GetUnitTypeId(GetTriggerUnit())];
      UnitAddAbility(u, TOGGLE_ABILITY);
      IssueImmediateOrder(u, "immolation");
    }

    private void periodic( ){
      tick = tick + 1;
      if (tick == TICK_RATE * T32_FPS){
        Mana = Mana + 1*TICK_RATE;
        if (Mana == MaxMana){
          if (GetPlayerState(Owner, PLAYER_STATE_RESOURCE_FOOD_USED) < GetPlayerState(Owner, PLAYER_STATE_RESOURCE_FOOD_CAP) && GetPlayerState(Owner, PLAYER_STATE_RESOURCE_FOOD_USED) < GetPlayerState(Owner, PLAYER_STATE_FOOD_CAP_CEILING) && GetUnitAbilityLevel(u, TOGGLE_BUFF) > 0){
            Mana = 0;
            spawnUnit();
          }
        }
        if (!UnitAlive(u) || GetOwningPlayer(u) == Player(bj_PLAYER_NEUTRAL_VICTIM)){
          destroy();
        }
        tick = 0;
      }
    }



     thistype (unit u ){

      this.u = u;
      this.tick = 0;
      this.enabled = true;
      spawnedDemons = CreateGroup();
      byHandle[GetHandleId(u)] = this;
      this.GateType = DemonGateType.byUnitType[GetUnitTypeId(u)];
      IssuePointOrder(u, "setrally", this.SpawnX, this.SpawnY);
      startPeriodic();
      UnitAddAbility(u, TOGGLE_ABILITY);
      IssueImmediateOrder(u, "immolation");
      ;;
    }

    private static void onUnitUpgraded( ){
      //Unit was already a Demon Gate
      if (byHandle[GetHandleId(GetTriggerUnit())] != 0){
        thistype(byHandle[GetHandleId(GetTriggerUnit())]).onUpgrade();
      //Unit was not a Demon Gate
      }else if (DemonGateType.byUnitType[GetUnitTypeId(GetTriggerUnit())] != 0){
        DemonGate.create(GetTriggerUnit());
      }
    }


      if (DemonGateType.byUnitType[GetUnitTypeId(GetTriggerUnit())] != 0){
        DemonGate.create(GetTriggerUnit());
      }
    }

    private static void onInit( ){

      //Should ideally only listen for buildings which are registered as Demon Gate types.
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH,  thistype.onUnitUpgraded);

      byHandle = Table.create();
    }


}
