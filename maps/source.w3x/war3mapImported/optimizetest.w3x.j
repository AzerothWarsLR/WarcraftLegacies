globals
trigger gg_trg_Duel=null
trigger gg_trg_Environment=null
endglobals
function InitGlobals takes nothing returns nothing
endfunction
library Duel requires Environment
globals
constant integer DUEL_STATUS_UNFINISHED=0
constant integer DUEL_STATUS_FINISHED=1
endglobals
struct Belligerent
private Faction array factions[5]
private group capitals
private integer factionCount
method operator Description takes nothing returns string
local integer i=0
local integer j=0
local string desc=""
loop
exitwhen i==factionCount
set desc=desc+factions[i].name+"
"
set j=0
loop
exitwhen j==BlzGroupGetSize(capitals)
set desc=desc+GetUnitName(BlzGroupUnitAt(capitals,j))+"
"
set j=j+1
endloop
set i=i+1
endloop
return desc
endmethod
method operator Alive takes nothing returns boolean
local boolean alive=false
local integer i=0
local integer j=0
loop
exitwhen i==factionCount
set j=0
loop
exitwhen j==BlzGroupGetSize(capitals)
if GetOwningPlayer(BlzGroupUnitAt(capitals,j))==factions[i].Person.p then
return true
endif
set j=j+1
endloop
set i=i+1
endloop
return alive
endmethod
method addFaction takes Faction whichFaction returns nothing
set factions[factionCount]=whichFaction
set factionCount=factionCount+1
endmethod
method addCapital takes unit u returns nothing
call GroupAddUnit(capitals,u)
endmethod
endstruct
struct Duel
private static trigger trigUnitChangeOwner
private static thistype first
private static thistype last
private string title
private Belligerent array belligerents[5]
private integer belligerentCount=0
private integer research
private integer status
private quest quest
private thistype next
method operator Research=takes integer newResearch returns nothing
if this.research==0 then
set this.research=newResearch
else
call BJDebugMsg("ERROR: Attempted to set research of duel "+this.title+" more than once")
endif
endmethod
private method updateDesc takes nothing returns nothing
local string desc="Belligerents
"
local integer i=0
loop
exitwhen i==belligerentCount
set desc=desc+belligerents[i].Description+"
"
set i=i+1
endloop
call QuestSetDescription(this.quest,desc)
endmethod
private method operator Status=takes integer whichStatus returns nothing
local integer i=0
if this.status==whichStatus then
return
endif
if this.status!=DUEL_STATUS_UNFINISHED then
call BJDebugMsg("ERROR: Attempted to change status of already finished duel "+this.title)
return
endif
set this.status=whichStatus
if this.status==DUEL_STATUS_FINISHED then
call QuestSetCompleted(this.quest,true)
loop
exitwhen i==MAX_PLAYERS
call SetPlayerTechMaxAllowed(Player(i),this.research,1)
call SetPlayerTechResearched(Player(i),this.research,1)
set i=i+1
endloop
endif
endmethod
private method operator Ongoing takes nothing returns boolean
local integer i=0
if this.status==DUEL_STATUS_FINISHED then
return false
endif
loop
exitwhen i==belligerentCount
if belligerents[i].Alive then
return true
endif
set i=i+1
endloop
return false
endmethod
private static method unitChangesOwner takes nothing returns nothing
local thistype nextDuel
set nextDuel=thistype.first
loop
exitwhen nextDuel.next==0
if not nextDuel.Ongoing then
set nextDuel.Status=DUEL_STATUS_FINISHED
endif
set nextDuel=nextDuel.next
endloop
endmethod
method addBelligerent takes Belligerent whichBelligerent returns nothing
set belligerents[belligerentCount]=whichBelligerent
set belligerentCount=belligerentCount+1
call updateDesc()
endmethod
static method create takes string title,string icon returns thistype
local thistype this=thistype.allocate()
set this.title=title
set this.quest=CreateQuest()
call QuestSetTitle(this.quest,title)
call QuestSetIconPath(this.quest,icon)
call QuestSetRequired(this.quest,true)
call QuestSetEnabled(this.quest,true)
set this.status=DUEL_STATUS_UNFINISHED
if thistype.first==0 then
set thistype.first=this
endif
set thistype.last.next=this
set thistype.last=this
return this
endmethod
private static method onInit takes nothing returns nothing
set trigUnitChangeOwner=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(trigUnitChangeOwner,EVENT_PLAYER_UNIT_CHANGE_OWNER)
call TriggerRegisterAnyUnitEventBJ(trigUnitChangeOwner,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddAction(trigUnitChangeOwner,function thistype.unitChangesOwner)
endmethod
endstruct
endlibrary
library Environment initializer OnInit
globals
constant integer MAX_PLAYERS=28
private unit PosUnit
endglobals
native UnitAlive takes unit id returns boolean
native GetUnitGoldCost takes integer unitid returns integer
native GetUnitWoodCost takes integer unitid returns integer
function GetPositionZ takes real x,real y returns real
call SetUnitX(PosUnit,x)
call SetUnitY(PosUnit,y)
return BlzGetUnitZ(PosUnit)
endfunction
function IsUnitInRect takes unit u,rect r returns boolean
return GetUnitX(u)>GetRectMinX(r)-32 and GetUnitX(u)<GetRectMaxX(r)+32 and GetUnitY(u)>GetRectMinY(r)-32 and GetUnitY(u)<GetRectMaxY(r)+32
endfunction
private function OnInit takes nothing returns nothing
set PosUnit=CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),'u00X',0,0,0)
endfunction
endlibrary
function InitCustomTriggers takes nothing returns nothing
call InitTrig_Duel()
call InitTrig_Environment()
endfunction
function InitCustomPlayerSlots takes nothing returns nothing
call SetPlayerStartLocation(Player(0),0)
call SetPlayerColor(Player(0),ConvertPlayerColor(0))
call SetPlayerRacePreference(Player(0),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(0),true)
call SetPlayerController(Player(0),MAP_CONTROL_USER)
endfunction
function InitCustomTeams takes nothing returns nothing
call SetPlayerTeam(Player(0),0)
endfunction
function main takes nothing returns nothing
call SetCameraBounds(-3328.0+GetCameraMargin(CAMERA_MARGIN_LEFT),-3584.0+GetCameraMargin(CAMERA_MARGIN_BOTTOM),3328.0-GetCameraMargin(CAMERA_MARGIN_RIGHT),3072.0-GetCameraMargin(CAMERA_MARGIN_TOP),-3328.0+GetCameraMargin(CAMERA_MARGIN_LEFT),3072.0-GetCameraMargin(CAMERA_MARGIN_TOP),3328.0-GetCameraMargin(CAMERA_MARGIN_RIGHT),-3584.0+GetCameraMargin(CAMERA_MARGIN_BOTTOM))
call SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl","Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
call NewSoundEnvironment("Default")
call SetAmbientDaySound("LordaeronSummerDay")
call SetAmbientNightSound("LordaeronSummerNight")
call SetMapMusic("Music",true,0)
call InitBlizzard()
call InitGlobals()
call InitCustomTriggers()
endfunction
function config takes nothing returns nothing
call SetMapName("TRIGSTR_001")
call SetMapDescription("TRIGSTR_003")
call SetPlayers(1)
call SetTeams(1)
call SetGamePlacement(MAP_PLACEMENT_USE_MAP_SETTINGS)
call DefineStartLocation(0,-2218.2,1854.2)
call InitCustomPlayerSlots()
call SetPlayerSlotAvailable(Player(0),MAP_CONTROL_USER)
call InitGenericPlayerSlots()
endfunction
