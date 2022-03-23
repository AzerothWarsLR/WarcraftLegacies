namespace AzerothWarsCSharp.Source.Mechanics.Fel_Horde
{
  public class DemonGate{

  
    private const float TICK_RATE = 1;
    private const float FACING_OFFSET = -45 ;//Demon gate model is spun around weirdly so this reverses that for code
    private const float SPAWN_DISTANCE = 300 ;//How far away from the gate to spawn units

    private const int TOGGLE_ABILITY = FourCC(A05V) ;//Gates can use this to toggle summoning
    private const int TOGGLE_BUFF = FourCC(B08B) ;//Gates need this buff to be able to summon
  


    readonly static Table ByUnitType;

    private int _spawnUnitType;
    private int _interval;
    private int _unitType;
    private int _count;

    public integer operator Count( ){
      return _count;
    }

    public integer operator Interval( ){
      return _interval;
    }

    public integer operator SpawnUnitType( ){
      return _spawnUnitType;
    }

    thistype (int gateUnitType, int spawnUnitType, int interval, int count ){

      _unitType = gateUnitType;
      this._interval = interval;
      this._spawnUnitType = spawnUnitType;
      this._count = count;
      ByUnitType[_unitType] = this;
      
    }

    private static void OnInit( ){
      ByUnitType = Table.create();
    }



    private static Table _byHandle;

    private unit _u;
    private bool _enabled;
    private int _tick;
    private group _spawnedDemons;
    private DemonGateType _gateType;

    private void Destroy( ){
      _byHandle[GetHandleId(_u)] = 0;
      _u = null;
      DestroyGroup(_spawnedDemons);
      stopPeriodic();
    }

    private void operator MaxMana=(int i ){
      BlzSetUnitMaxMana(_u, i);
    }

    private integer operator MaxMana( ){
      return BlzGetUnitMaxMana(_u);
    }

    private float operator Mana( ){
      return GetUnitState(_u, UNIT_STATE_MANA);
    }

    private void operator Mana=(float r ){
      SetUnitState(_u, UNIT_STATE_MANA, r);
    }

    private player operator Owner( ){
      return GetOwningPlayer(_u);
    }

    private float operator RallyX( ){
      location rally;
      float x;
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(_u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.RallyX;
      }
      rally = GetUnitRallyPoint(_u);
      x = GetLocationX(rally);
      RemoveLocation(rally);
      rally = null;
      return x;
    }

    private float operator RallyY( ){
      location rally;
      float y;
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(_u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.RallyY;
      }
      rally = GetUnitRallyPoint(_u);
      y = GetLocationY(rally);
      RemoveLocation(rally);
      rally = null;
      return y;
    }

    private float operator SpawnX( ){
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(_u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.SpawnX;
      }
      return GetPolarOffsetX(X, SPAWN_DISTANCE, Facing);
    }

    private float operator SpawnY( ){
      if (FocalDemonGate.Instance != 0 && FocalDemonGate.Instance.Alive == true && GetOwningPlayer(_u) == FACTION_FEL_HORDE.Player){
        return FocalDemonGate.Instance.SpawnY;
      }
      return GetPolarOffsetY(Y, SPAWN_DISTANCE, Facing);
    }

    private float operator X( ){
      return GetUnitX(_u);
    }

    private float operator Y( ){
      return GetUnitY(_u);
    }

    private float operator Facing( ){
      return GetUnitFacing(_u) + FACING_OFFSET;
    }

    private void operator GateType=(DemonGateType gateType ){
      if (_gateType == 0){
        BJDebugMsg("ERROR: invalid DemonGateType supplied to DemonGate " + I2S(this));
        return;
      }
      MaxMana = _gateType.Interval;
      _gateType = _gateType;
    }

    private void SpawnUnit( ){
      unit newUnit;
      var i = 0;
      while(true){
        if ( i == _gateType.Count){ break; }
        newUnit = CreateUnit(Owner, _gateType.SpawnUnitType, SpawnX, SpawnY, Facing);
        GroupAddUnit(_spawnedDemons, newUnit);
        IssuePointOrder(newUnit, "attack", this.RallyX, this.RallyY);
        i = i + 1;
      }
      newUnit = null;
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl", SpawnX, SpawnY));
    }

    private void OnUpgrade( ){
      GateType = DemonGateType.byUnitType[GetUnitTypeId(GetTriggerUnit())];
      UnitAddAbility(_u, TOGGLE_ABILITY);
      IssueImmediateOrder(_u, "immolation");
    }

    private void Periodic( ){
      _tick = _tick + 1;
      if (_tick == TICK_RATE * T32_FPS){
        Mana = Mana + 1*TICK_RATE;
        if (Mana == MaxMana){
          if (GetPlayerState(Owner, PLAYER_STATE_RESOURCE_FOOD_USED) < GetPlayerState(Owner, PLAYER_STATE_RESOURCE_FOOD_CAP) && GetPlayerState(Owner, PLAYER_STATE_RESOURCE_FOOD_USED) < GetPlayerState(Owner, PLAYER_STATE_FOOD_CAP_CEILING) && GetUnitAbilityLevel(_u, TOGGLE_BUFF) > 0){
            Mana = 0;
            SpawnUnit();
          }
        }
        if (!UnitAlive(_u) || GetOwningPlayer(_u) == Player(bj_PLAYER_NEUTRAL_VICTIM)){
          Destroy();
        }
        _tick = 0;
      }
    }



    thistype (unit u ){

      this._u = u;
      _tick = 0;
      _enabled = true;
      _spawnedDemons = CreateGroup();
      _byHandle[GetHandleId(u)] = this;
      this.GateType = DemonGateType.byUnitType[GetUnitTypeId(u)];
      IssuePointOrder(u, "setrally", this.SpawnX, this.SpawnY);
      startPeriodic();
      UnitAddAbility(u, TOGGLE_ABILITY);
      IssueImmediateOrder(u, "immolation");
      
    }

    private static void OnUnitUpgraded( ){
      //Unit was already a Demon Gate
      if (_byHandle[GetHandleId(GetTriggerUnit())] != 0){
        thistype(_byHandle[GetHandleId(GetTriggerUnit())]).onUpgrade();
        //Unit was not a Demon Gate
      }else if (DemonGateType.byUnitType[GetUnitTypeId(GetTriggerUnit())] != 0){
        DemonGate.create(GetTriggerUnit());
      }
    }


    if (DemonGateType.byUnitType[GetUnitTypeId(GetTriggerUnit())] != 0){
      DemonGate.create(GetTriggerUnit());
    }
  }
}

    private static void OnInit( ){

      //Should ideally only listen for buildings which are registered as Demon Gate types.
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH,  thistype.onUnitUpgraded);

      byHandle = Table.create();
    }


}
