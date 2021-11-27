library GeneralHelpers

  globals
    private constant real HERO_DROP_DIST = 50.     //The radius in which heroes spread out items when they drop them
    private force DestForce = null
    private group TempGroup = CreateGroup()
    private rect TempRect = Rect(0, 0, 0, 0)
  endglobals

  function GetUnitAverageDamage takes unit whichUnit, integer weaponIndex returns integer
    local real baseDamage = BlzGetUnitBaseDamage(whichUnit, weaponIndex)
    local real numberOfDice = BlzGetUnitDiceNumber(whichUnit, weaponIndex)
    local real sidesPerDie = BlzGetUnitDiceSides(whichUnit, weaponIndex)
    return R2I(baseDamage + (numberOfDice + sidesPerDie*numberOfDice) / 2)
  endfunction

  //Returns as percentage.
  function GetUnitDamageReduction takes unit whichUnit returns real
    local real armor = BlzGetUnitArmor(whichUnit)
    return (armor*0.06) / ((1+0.06)*armor)
  endfunction

  function KillNeutralHostileUnitsInRadius takes real x, real y, real radius returns nothing
    local unit u
    call GroupEnumUnitsInRange(TempGroup, x, y, radius, null)
    loop
      set u = FirstOfGroup(TempGroup)
      exitwhen u == null
      if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE) and not IsUnitType(u, UNIT_TYPE_SAPPER) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) then
        call KillUnit(u)
      endif
      call GroupRemoveUnit(TempGroup, u)
    endloop
  endfunction

  function CreateStructureForced takes player whichPlayer, integer unitId, real x, real y, real face, real size returns unit
    local unit u = null
    call SetRect(TempRect, x - size/2, y - size/2, x + size/2, y + size/2)
    call GroupEnumUnitsInRect(TempGroup, TempRect, null)
    loop
      set u = FirstOfGroup(TempGroup)
      exitwhen u == null
      if IsUnitType(u, UNIT_TYPE_STRUCTURE) then
        call AdjustPlayerStateBJ(GetUnitGoldCost(GetUnitTypeId(u)), GetOwningPlayer(u), PLAYER_STATE_RESOURCE_GOLD)
        call AdjustPlayerStateBJ(GetUnitWoodCost(GetUnitTypeId(u)), GetOwningPlayer(u), PLAYER_STATE_RESOURCE_LUMBER)
        call KillUnit(u)
      endif
      call GroupRemoveUnit(TempGroup, u)
    endloop
    return CreateUnit(whichPlayer, unitId, x, y, face)
  endfunction

  function PlayDialogue takes player whichPlayer, sound whichSound, string speakerName, string caption returns nothing
    if GetLocalPlayer() == whichPlayer then
      call StartSound(whichSound)
      call DisplayTimedTextToPlayer(whichPlayer, 0, 0, GetSoundDuration(whichSound) / 1000, "\n|cffffcc00" + speakerName + ":|r " + caption)
    endif
  endfunction

  function CreateUnits takes player whichPlayer, integer unitId, real x, real y, real face, integer count returns nothing
    local integer i = 0
    loop
      exitwhen i == count
      call CreateUnit(whichPlayer, unitId, x, y, face)
      set i = i + 1
    endloop
  endfunction

  function GetRectRandomY takes rect whichRect returns real
    return GetRandomReal(GetRectMinY(whichRect), GetRectMaxY(whichRect))
  endfunction

  function GetRectRandomX takes rect whichRect returns real
    return GetRandomReal(GetRectMinX(whichRect), GetRectMaxX(whichRect))
  endfunction

  private function ForceAddForceEnum takes nothing returns nothing
    call ForceAddPlayer(DestForce, GetEnumPlayer())
  endfunction

  function ForceAddForce takes force sourceForce, force destForce returns nothing
    set DestForce = destForce
    call ForForce(sourceForce, function ForceAddForceEnum)
  endfunction

  function AddHeroAttributes takes unit whichUnit, integer str, integer agi, integer int returns nothing
    local string sfx = ""
    call SetHeroStr(whichUnit, GetHeroStr(whichUnit, false) + str, true)
    call SetHeroAgi(whichUnit, GetHeroAgi(whichUnit, false) + agi, true)
    call SetHeroInt(whichUnit, GetHeroInt(whichUnit, false) + int, true)

    if str > 0 and agi == 0 and int == 0 then
      set sfx = "Abilities\\Spells\\Items\\AIsm\\AIsmTarget.mdl"
    elseif str == 0 and agi > 0 and int == 0 then
      set sfx = "Abilities\\Spells\\Items\\AIam\\AIamTarget.mdl"
    elseif str == 0 and agi == 0 and int > 0 then
      set sfx = "Abilities\\Spells\\Items\\AIim\\AIimTarget.mdl"
    else
      set sfx = "Abilities\\Spells\\Items\\AIlm\\AIlmTarget.mdl"
    endif
    call DestroyEffect(AddSpecialEffect(sfx, GetUnitX(whichUnit), GetUnitY(whichUnit)))
  endfunction

  function UnitRescue takes unit whichUnit, player whichPlayer returns nothing
    //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
    if GetUnitFoodUsed(whichUnit) == 10 then
      call SetUnitOwner(whichUnit, Player(PLAYER_NEUTRAL_PASSIVE), true)
    else
      call SetUnitOwner(whichUnit, whichPlayer, true)
    endif
    call ShowUnit(whichUnit, true)
    call SetUnitInvulnerable(whichUnit, false)
  endfunction

  function RescueUnitsInGroup takes group whichGroup, player whichPlayer returns nothing
    local group tempGroup = CreateGroup()
    local unit u
    call BlzGroupAddGroupFast(whichGroup, tempGroup)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      call UnitRescue(u, whichPlayer)
      call GroupRemoveUnit(tempGroup, u)
    endloop
    call DestroyGroup(tempGroup)
  endfunction

  function RescueHostileUnitsInRect takes rect whichRect, player whichPlayer returns nothing
    local group tempGroup = CreateGroup()
    local unit u
    call GroupEnumUnitsInRect(tempGroup, whichRect, null)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE) then
        call UnitRescue(u, whichPlayer)
      endif
      call GroupRemoveUnit(tempGroup, u)
    endloop
    call DestroyGroup(tempGroup)
  endfunction

  function RescueNeutralUnitsInRect takes rect whichRect, player whichPlayer returns nothing
    local group tempGroup = CreateGroup()
    local unit u
    call GroupEnumUnitsInRect(tempGroup, whichRect, null)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
        call UnitRescue(u, whichPlayer)
      endif
      call GroupRemoveUnit(tempGroup, u)
    endloop
    call DestroyGroup(tempGroup)
  endfunction  

  function UnitDropAllItems takes unit u returns nothing
    local integer i = 0
    local item dropItem = null
    local real unitX = GetUnitX(u)
    local real unitY = GetUnitY(u)
    local real x = 0
    local real y = 0
    local real ang = 0  //Radians
    loop
    exitwhen i > 6
      set x = unitX + HERO_DROP_DIST * Cos(ang)
      set y = unitY + HERO_DROP_DIST * Sin(ang)
      set ang = ang + (360*bj_DEGTORAD)/6
      set dropItem = UnitItemInSlot(u, i)
      if BlzGetItemBooleanField(dropItem, ITEM_BF_DROPPED_WHEN_CARRIER_DIES) or BlzGetItemBooleanField(dropItem, ITEM_BF_CAN_BE_DROPPED) then                
        call UnitRemoveItem(u, dropItem)
        call SetItemPosition(dropItem, x, y)
      endif
      set i = i + 1
    endloop
  endfunction

  function UnitTransferItems takes unit sender, unit receiver returns nothing
    local integer i = 0
    loop
    exitwhen i > 6
      call UnitAddItem(receiver, UnitItemInSlot(sender, i))
      set i = i + 1
    endloop
  endfunction

  //Add an item to a unit. If the unit's inventory is full, drop it on the ground near them instead.
  function UnitAddItemSafe takes unit whichUnit, item whichItem returns nothing
    call SetItemPosition(whichItem, GetUnitX(whichUnit), GetUnitY(whichUnit))
    call UnitAddItem(whichUnit, whichItem)
  endfunction
    
endlibrary