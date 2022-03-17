public class GeneralHelpers{

  
    private const float HERO_DROP_DIST = 50     ;//The radius in which heroes spread out items when they drop them
    private force DestForce = null;
    private group TempGroup = CreateGroup();
    private rect TempRect = Rect(0, 0, 0, 0);
  

  static integer GetUnitAverageDamage(unit whichUnit, int weaponIndex ){
    float baseDamage = BlzGetUnitBaseDamage(whichUnit, weaponIndex);
    float numberOfDice = BlzGetUnitDiceNumber(whichUnit, weaponIndex);
    float sidesPerDie = BlzGetUnitDiceSides(whichUnit, weaponIndex);
    return R2I(baseDamage + (numberOfDice + sidesPerDie*numberOfDice) / 2);
  }

  //Returns as percentage.
  static float GetUnitDamageReduction(unit whichUnit ){
    float armor = BlzGetUnitArmor(whichUnit);
    return (armor*006) / ((1+006)*armor);
  }

  static void KillNeutralHostileUnitsInRadius(float x, float y, float radius ){
    unit u;
    GroupEnumUnitsInRange(TempGroup, x, y, radius, null);
    while(true){
      u = FirstOfGroup(TempGroup);
      if ( u == null){ break; }
      if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !IsUnitType(u, UNIT_TYPE_SAPPER) && !IsUnitType(u, UNIT_TYPE_STRUCTURE)){
        KillUnit(u);
      }
      GroupRemoveUnit(TempGroup, u);
    }
  }

  static unit CreateStructureForced(player whichPlayer, int unitId, float x, float y, float face, float size ){
    unit u = null;
    SetRect(TempRect, x - size/2, y - size/2, x + size/2, y + size/2);
    GroupEnumUnitsInRect(TempGroup, TempRect, null);
    while(true){
      u = FirstOfGroup(TempGroup);
      if ( u == null){ break; }
      if (IsUnitType(u, UNIT_TYPE_STRUCTURE)){
        AdjustPlayerStateBJ(GetUnitGoldCost(GetUnitTypeId(u)), GetOwningPlayer(u), PLAYER_STATE_RESOURCE_GOLD);
        AdjustPlayerStateBJ(GetUnitWoodCost(GetUnitTypeId(u)), GetOwningPlayer(u), PLAYER_STATE_RESOURCE_LUMBER);
        KillUnit(u);
      }
      GroupRemoveUnit(TempGroup, u);
    }
    return CreateUnit(whichPlayer, unitId, x, y, face);
  }

  static void PlayDialogue(player whichPlayer, sound whichSound, string speakerName, string caption ){
    if (GetLocalPlayer() == whichPlayer){
      StartSound(whichSound);
      DisplayTimedTextToPlayer(whichPlayer, 0, 0, GetSoundDuration(whichSound) / 1000, "\n|cffffcc00" + speakerName + ":|r " + caption);
    }
  }

  static void CreateUnits(player whichPlayer, int unitId, float x, float y, float face, int count ){
    int i = 0;
    while(true){
      if ( i == count){ break; }
      CreateUnit(whichPlayer, unitId, x, y, face);
      i = i + 1;
    }
  }

  static float GetRectRandomY(rect whichRect ){
    return GetRandomReal(GetRectMinY(whichRect), GetRectMaxY(whichRect));
  }

  static float GetRectRandomX(rect whichRect ){
    return GetRandomReal(GetRectMinX(whichRect), GetRectMaxX(whichRect));
  }

  private static void ForceAddForceEnum( ){
    ForceAddPlayer(DestForce, GetEnumPlayer());
  }

  static void ForceAddForce(force sourceForce, force destForce ){
    DestForce = destForce;
    ForForce(sourceForce,  ForceAddForceEnum);
  }

  static void AddHeroAttributes(unit whichUnit, int str, int agi, int int ){
    string sfx = "";
    SetHeroStr(whichUnit, GetHeroStr(whichUnit, false) + str, true);
    SetHeroAgi(whichUnit, GetHeroAgi(whichUnit, false) + agi, true);
    SetHeroInt(whichUnit, GetHeroInt(whichUnit, false) + int, true);

    if (str > 0 && agi == 0 && int == 0){
      sfx = "Abilities\\Spells\\Items\\AIsm\\AIsmTarget.mdl";
    }else if (str == 0 && agi > 0 && int == 0){
      sfx = "Abilities\\Spells\\Items\\AIam\\AIamTarget.mdl";
    }else if (str == 0 && agi == 0 && int > 0){
      sfx = "Abilities\\Spells\\Items\\AIim\\AIimTarget.mdl";
    }else {
      sfx = "Abilities\\Spells\\Items\\AIlm\\AIlmTarget.mdl";
    }
    DestroyEffect(AddSpecialEffect(sfx, GetUnitX(whichUnit), GetUnitY(whichUnit)));
  }

  static void UnitRescue(unit whichUnit, player whichPlayer ){
    //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
    if (GetUnitFoodUsed(whichUnit) == 10){
      SetUnitOwner(whichUnit, Player(PLAYER_NEUTRAL_PASSIVE), true);
    }else {
      SetUnitOwner(whichUnit, whichPlayer, true);
    }
    ShowUnit(whichUnit, true);
    SetUnitInvulnerable(whichUnit, false);
  }

  static void RescueUnitsInGroup(group whichGroup, player whichPlayer ){
    group tempGroup = CreateGroup();
    unit u;
    BlzGroupAddGroupFast(whichGroup, tempGroup);
    while(true){
      u = FirstOfGroup(tempGroup);
      if ( u == null){ break; }
      UnitRescue(u, whichPlayer);
      GroupRemoveUnit(tempGroup, u);
    }
    DestroyGroup(tempGroup);
  }

  static void RescueHostileUnitsInRect(rect whichRect, player whichPlayer ){
    group tempGroup = CreateGroup();
    unit u;
    GroupEnumUnitsInRect(tempGroup, whichRect, null);
    while(true){
      u = FirstOfGroup(tempGroup);
      if ( u == null){ break; }
      if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
        UnitRescue(u, whichPlayer);
      }
      GroupRemoveUnit(tempGroup, u);
    }
    DestroyGroup(tempGroup);
  }

  static void RescueNeutralUnitsInRect(rect whichRect, player whichPlayer ){
    group tempGroup = CreateGroup();
    unit u;
    GroupEnumUnitsInRect(tempGroup, whichRect, null);
    while(true){
      u = FirstOfGroup(tempGroup);
      if ( u == null){ break; }
      if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
        UnitRescue(u, whichPlayer);
      }
      GroupRemoveUnit(tempGroup, u);
    }
    DestroyGroup(tempGroup);
  }

  static void UnitDropAllItems(unit u ){
    int i = 0;
    item dropItem = null;
    float unitX = GetUnitX(u);
    float unitY = GetUnitY(u);
    float x = 0;
    float y = 0;
    float ang = 0  ;//Radians
    while(true){
    if ( i > 6){ break; }
      x = unitX + HERO_DROP_DIST * Cos(ang);
      y = unitY + HERO_DROP_DIST * Sin(ang);
      ang = ang + (360*bj_DEGTORAD)/6;
      dropItem = UnitItemInSlot(u, i);
      if (BlzGetItemBooleanField(dropItem, ITEM_BF_DROPPED_WHEN_CARRIER_DIES) || BlzGetItemBooleanField(dropItem, ITEM_BF_CAN_BE_DROPPED)){
        UnitRemoveItem(u, dropItem);
        SetItemPosition(dropItem, x, y);
      }
      i = i + 1;
    }
  }

  static void UnitTransferItems(unit sender, unit receiver ){
    int i = 0;
    while(true){
    if ( i > 6){ break; }
      UnitAddItem(receiver, UnitItemInSlot(sender, i));
      i = i + 1;
    }
  }

  //Add an item to a unit. If the unit)s inventory is full, drop it on the ground near them instead.
  static void UnitAddItemSafe(unit whichUnit, item whichItem ){
    SetItemPosition(whichItem, GetUnitX(whichUnit), GetUnitY(whichUnit));
    UnitAddItem(whichUnit, whichItem);
  }

}
