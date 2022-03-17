//A Legend is a wrapper for unique heroes. A Legend can continue to exist even if the unit it describes does not.
//A Legend might have other units it relies on to survive. If so, when it dies, it gets removed if those units are not under control.
//There is a dummy ability to represent this.

public class Legend{

  
    private const int DUMMY_DIESWITHOUT = FourCC(LEgn);
    private const int DUMMY_PERMADIES = FourCC(LEgo);
    private const int DUMMY_CAPITAL = FourCC(LEca);

    private Legend TriggerLegend = 0;
    private player LegendPreviousOwner;
    Event OnLegendChangeOwner
    Event OnLegendPrePermaDeath //Fired before the unit is removed
    Event OnLegendPermaDeath
    Event OnLegendDeath
  


    private static Table byHandle;
    private static thistype[] byIndex;
    private static int count = 0;

    private unit unit;
    private int unitType = 0;
    private string deathMessage;
    private string deathSfx;
    private boolean permaDies = false;
    private boolean hivemind = false  ;//This hero causes the death of its own faction if it dies
    private group diesWithout ;//This hero permanently dies if it dies without these under control]
    private trigger ownerTrig;
    private trigger deathTrig;
    private trigger castTrig;
    private trigger damageTrig;
    private boolean capturable;
    private int startingXP ;//A value indicating how much experience a hero should not distribute when refunded. Must be set manually per hero
    private boolean hasCustomColor = false;
    private playercolor playerColor;
    private boolean isCapital = false;
    private boolean essential = false;
    private boolean enableMessages = true;
    private string name = null;

    public boolean operator Essential( ){
      return essential;
    }

    public void operator Essential=(boolean value ){
      this.essential = value;
    }

    public boolean operator EnableMessages( ){
      return enableMessages;
    }

    public void operator EnableMessages=(boolean value ){
      this.enableMessages = value;
    }

    public static integer operator Count( ){
      ;type.count;
    }

    public static thistype ByIndex(int index ){
      ;type.byIndex[index];
    }

    public string operator Name( ){
      if (this.name != null){
        ;.name;
      }

      if (this.unit == null && this.unitType != 0){
        return GetObjectName(this.unitType);
      }

      if (IsUnitType(this.unit, UNIT_TYPE_HERO) == true){
        return GetHeroProperName(this.unit);
      }else {
        return GetUnitName(this.unit);
      }

      return "NONAME";
    }

    public void operator Name=(string value ){
      this.name = value;
    }

    public boolean operator IsCapital( ){
      ;.isCapital;
    }

    public void operator IsCapital=(boolean value ){
      this.isCapital = value;
      this.refreshDummy();
    }

    public boolean operator HasCustomColor( ){
      ;.hasCustomColor;
    }

    public playercolor operator PlayerColor( ){
      ;.playerColor;
    }

    public void operator PlayerColor=(playercolor playerColor ){
      this.playerColor = playerColor;
      this.hasCustomColor = true;
      if (this.unit != null){
        SetUnitColor(this.unit, playerColor);
      }
    }

    public integer operator StartingXP( ){
      ;.startingXP;
    }

    public void operator StartingXP=(int value ){
      this.startingXP = value;
    }

    public void operator PermaDies=(boolean b ){
      permaDies = b;
      refreshDummy();
    }

    public void operator DeathSfx=(string s ){
      deathSfx = s;
    }

    public void operator DeathMessage=(string s ){
      deathMessage = s;
    }

    public void operator Capturable=(boolean capturable ){
      this.capturable = capturable;
    }

    public void operator Unit=(unit u ){
      if (Unit != null){
        thistype.byHandle[GetHandleId(unit)] = 0;
        UnitDropAllItems(unit);
        RemoveUnit(unit);
      }
      unit = u;
      if (Unit != null){
        unitType = GetUnitTypeId(unit);
        //Death trig
        DestroyTrigger(deathTrig);
        deathTrig = CreateTrigger();
        TriggerRegisterUnitEvent(deathTrig, unit, EVENT_UNIT_DEATH);
        TriggerAddAction(deathTrig,  thistype.onUnitDeath);
        //Cast trig
        DestroyTrigger(castTrig);
        castTrig = CreateTrigger();
        TriggerRegisterUnitEvent(castTrig, unit, EVENT_UNIT_SPELL_FINISH);
        TriggerAddAction(castTrig,  thistype.onUnitCast);
        //Damage trig
        DestroyTrigger(damageTrig);
        damageTrig = CreateTrigger();
        TriggerRegisterUnitEvent(damageTrig, unit, EVENT_UNIT_DAMAGED);
        TriggerAddAction(damageTrig,  thistype.onUnitDamaged);
        //Ownership change trig
        DestroyTrigger(ownerTrig);
        ownerTrig = CreateTrigger();
        TriggerRegisterUnitEvent(ownerTrig, unit, EVENT_UNIT_CHANGE_OWNER);
        TriggerAddAction(ownerTrig,  thistype.onUnitChangeOwner);
        //
        if (this.hasCustomColor){
          SetUnitColor(unit, this.playerColor);
        }else {
          SetUnitColor(unit, GetPlayerColor(GetOwningPlayer(unit)));
        }
        //Set XP to starting XP
        if (GetHeroXP(unit) < this.startingXP){
          SetHeroXP(unit, this.startingXP, true);
        }
        //
        thistype.byHandle[GetHandleId(unit)] = this;
        refreshDummy();
      }
    }

    public unit operator Unit( ){
      if (GetOwningPlayer(unit) == null){
        return null;
      }
      return unit;
    }

    public void ClearUnitDependencies( ){
      DestroyGroup(diesWithout);
      diesWithout = null;
      refreshDummy();
    }

    public void AddUnitDependency(unit u ){
      if (diesWithout == null){
        diesWithout = CreateGroup();
      }
      GroupAddUnit(diesWithout, u);
      refreshDummy();
    }

    public void operator Hivemind=(boolean b ){
      hivemind = b;
    }

    public integer operator UnitType( ){
      return unitType;
    }

    public void operator UnitType=(int i ){
      unit newUnit;
      float oldX;
      float oldY;
      if (unit != null){
        newUnit = CreateUnit(OwningPlayer, i, GetUnitX(unit), GetUnitY(unit), GetUnitFacing(unit));
        SetUnitState(newUnit, UNIT_STATE_LIFE, GetUnitState(unit, UNIT_STATE_LIFE));
        SetUnitState(newUnit, UNIT_STATE_MANA, GetUnitState(unit, UNIT_STATE_MANA));
        SetHeroXP(newUnit, GetHeroXP(unit), false);
        UnitTransferItems(unit, newUnit);
        oldX = GetUnitX(this.unit);
        oldY = GetUnitY(this.unit);
        RemoveUnit(unit);
        Unit = newUnit;
        SetUnitPosition(this.unit, oldX, oldY);
      }
      unitType = i;
    }

    public Faction operator OwningFaction( ){
      ;.OwningPerson.Faction;
    }

    public Person operator OwningPerson( ){
      return Person.ByHandle(GetOwningPlayer(this.unit));
    }

    public player operator OwningPlayer( ){
      return GetOwningPlayer(unit);
    }

    public void Spawn(player owner, float x, float y, float face ){
      if (Unit == null){
        Unit = CreateUnit(owner, unitType, x, y, face);
        TriggerLegend = this;
        OnLegendChangeOwner.fire();
      }else if (!UnitAlive(Unit)){
        ReviveHero(Unit, x, y, false);
      }else {
        SetUnitX(Unit, x);
        SetUnitY(Unit, y);
        SetUnitFacing(Unit, face);
      }
      if (GetOwningPlayer(this.unit) != owner){
        SetUnitOwner(Unit, owner, true);
      }
      refreshDummy();
    }

    private void refreshDummy( ){
      group tempGroup;
      unit u;
      string tooltip;
      if (permaDies){
        UnitAddAbility(unit, DUMMY_PERMADIES);
      }else {
        UnitRemoveAbility(unit, DUMMY_PERMADIES);
        if (diesWithout != null){
          tempGroup = CreateGroup();
          tooltip = "When this unit dies, it will be unrevivable unless any of the following capitals are under your control:\n";
          BlzGroupAddGroupFast(diesWithout, tempGroup);
          while(true){
            u = FirstOfGroup(tempGroup);
            if ( u == null){ break; }
            tooltip = tooltip + " - " + GetUnitName(u) + "|n";
            GroupRemoveUnit(tempGroup, u);
          }
          tooltip = tooltip + "\nUsing this ability pings each of these capitals on the minimap.";
          UnitAddAbility(unit, DUMMY_DIESWITHOUT);
          BlzSetAbilityStringLevelField(BlzGetUnitAbility(unit, DUMMY_DIESWITHOUT), ABILITY_SLF_TOOLTIP_NORMAL_EXTENDED, 0, tooltip);
          DestroyGroup(tempGroup);
        }else {
          UnitRemoveAbility(unit, DUMMY_DIESWITHOUT);
        }
      }
      if (isCapital){
        UnitAddAbility(unit, DUMMY_CAPITAL);
      }else {
        UnitRemoveAbility(unit, DUMMY_CAPITAL);
      }
    }

    void PermaDeath( ){
      effect tempEffect;
      string displayString;
      TriggerLegend = this;
      OnLegendPrePermaDeath.fire();
      if (IsUnitType(unit, UNIT_TYPE_HERO)){
        tempEffect = AddSpecialEffect(deathSfx, GetUnitX(unit), GetUnitY(unit));
        BlzSetSpecialEffectScale(tempEffect, 20);
        DestroyEffect(tempEffect);
        UnitDropAllItems(unit);
        RemoveUnit(unit);
      }
      if (this.deathMessage != null && this.deathMessage != "" && this.enableMessages == true){
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE)){
          displayString = "\n|cffffcc00CAPITAL DESTROYED|r\n";
        }else {
          displayString = "\n|cffffcc00HERO SLAIN|r\n";
        }
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, displayString + deathMessage);
      }
      if (hivemind && OwningPerson != 0){
        OwningPerson.Faction.obliterate();
      }
      TriggerLegend = this;
      OnLegendPermaDeath.fire();
    }

    private void onChangeOwner( ){
      TriggerLegend = this;
      LegendPreviousOwner = GetChangingUnitPrevOwner();
      OnLegendChangeOwner.fire();
    }

    private void onDamaging( ){
      if (capturable && GetEventDamage() + 1 >= GetUnitState(unit, UNIT_STATE_LIFE)){
        SetUnitOwner(unit, GetOwningPlayer(GetEventDamageSource()), true);
        BlzSetEventDamage(0);
        SetUnitState(unit, UNIT_STATE_LIFE, GetUnitState(unit, UNIT_STATE_MAX_LIFE));
      }
    }

    private void onCast( ){
      group tempGroup;
      unit u;
      if (GetSpellAbilityId() == DUMMY_DIESWITHOUT){
        tempGroup = CreateGroup();
        BlzGroupAddGroupFast(diesWithout, tempGroup);
        while(true){
          u = FirstOfGroup(tempGroup);
          if ( u == null){ break; }
          if (GetLocalPlayer() == GetTriggerPlayer()){
            PingMinimap(GetUnitX(u), GetUnitY(u), 5);
          }
          GroupRemoveUnit(tempGroup, u);
        }
        DestroyGroup(tempGroup);
        tempGroup = null;
      }
    }

    private void onDeath( ){
      group tempGroup;
      boolean anyOwned = false;
      unit u;

      TriggerLegend = this;
      OnLegendDeath.fire();

      if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE) || GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && deathMessage != "" && deathMessage != null){
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "\n|cffffcc00LEGENDARY CREEP DEATH|r\n" + deathMessage);
      }

      if (permaDies || !IsUnitType(this.unit, UNIT_TYPE_HERO)){
        PermaDeath();
        return;
      }

      if (diesWithout != null){
        tempGroup = CreateGroup();
        BlzGroupAddGroupFast(diesWithout, tempGroup);
        while(true){
          u = FirstOfGroup(tempGroup);
          if ( u == null){ break; }
          if (GetOwningPlayer(u) == GetOwningPlayer(unit) && UnitAlive(u) == true){
            anyOwned = true;
          }
          GroupRemoveUnit(tempGroup, u);
        }
        if (anyOwned == false){
          PermaDeath();
        }
        DestroyGroup(tempGroup);
        tempGroup = null;
      }
    }

    static thistype ByHandle(unit whichUnit ){
      ;type.byHandle[GetHandleId(whichUnit)];
    }

    private static void onUnitChangeOwner( ){
      Legend triggerLegend = thistype.byHandle[GetHandleId(GetTriggerUnit())];
      if (triggerLegend != 0){
        triggerLegend.onChangeOwner();
      }
    }

    private static void onUnitDamaged( ){
      thistype(thistype.byHandle[GetHandleId(GetTriggerUnit())]).onDamaging();
    }

    private static void onUnitDeath( ){
      thistype(thistype.byHandle[GetHandleId(GetTriggerUnit())]).onDeath();
    }

    private static void onUnitCast( ){
      thistype(thistype.byHandle[GetHandleId(GetTriggerUnit())]).onCast();
    }

    //When any unit is trained, check if it has the unittype of a Legend, and assign it to that Legend if so
    private static void onUnitTrain( ){
      int i = 0;
      unit trainedUnit = GetTrainedUnit();
      player owningPlayer = GetOwningPlayer(trainedUnit);
      Person tempPerson;

      while(true){
        if ( i == thistype.count){ break; }
        if (thistype.byIndex[i].UnitType == GetUnitTypeId(trainedUnit)){
          thistype.byIndex[i].Unit = trainedUnit;
          LegendPreviousOwner = null;
          TriggerLegend = thistype.byIndex[i];
          OnLegendChangeOwner.fire();
          return;
        }
        i = i + 1;
      }

      trainedUnit = null;
      owningPlayer = null;
    }

    private void destroy( ){
      this.deallocate();
      UnitDropAllItems(unit);
      DestroyGroup(diesWithout);
      RemoveUnit(unit);
      DestroyGroup(diesWithout);
    }

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH,  thistype.onUnitTrain) ;//TODO: use filtered events
      thistype.byHandle = Table.create();
      OnLegendChangeOwner = Event.create();
      OnLegendPermaDeath = Event.create();
      OnLegendDeath = Event.create();
      OnLegendPrePermaDeath = Event.create();
    }

     thistype ( ){

      unit = null;
      this.deathSfx = "Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl";
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }


  static player GetLegendPreviousOwner( ){
    return LegendPreviousOwner;
  }

  //This is unbelievably stupid but it is also the only way I can see to support recursion of event parameters
  //This needs to be set at the end of functions which both respond to Legend events AND may modify TriggerLegend through their actions
  static void SetTriggerLegend(Legend value ){
    TriggerLegend = value;
  }

  static Legend GetTriggerLegend( ){
    return TriggerLegend;
  }

}
