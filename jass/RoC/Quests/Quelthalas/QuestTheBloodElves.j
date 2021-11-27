//If Quel'thalas destroys the Legion Nexus, they can train Kael'thas and Blood Mages.
//If they instead lose the Sunwell, they lose everything. If that doesn't defeat them, they get Kael'thalas, Lorthemar, and some free units at Dalaran Dungeons.
library QuestTheBloodElves requires QuelthalasSetup, LegendLegion, LegendQuelthalas, Display

  globals
    private constant integer QUEST_RESEARCH_ID = 'R04Q'
    private constant integer UNITTYPE_ID = 'n048'
    private constant integer BUILDING_ID = 'n0A2'
    private constant integer HERO_ID = 'Hkal'
  endglobals

  struct QuestTheBloodElves extends QuestData
    private static group SecondChanceUnits

    private method operator CompletionPopup takes nothing returns string
      return "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demons' magic, becoming the first Blood Mages."
    endmethod

    private method operator FailurePopup takes nothing returns string
      return "The Sunwell has fallen. The survivors escape to Dalaran and name themselves the Blood Elves in remembrance of their fallen people."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + GetObjectName(UNITTYPE_ID) + "s from the Consortium, and you can summon Prince Kael'thas from the Altar of Prowess"
    endmethod

    private method operator FailureDescription takes nothing returns string
      return "You lose everything you control, but you gain Prince Kael'thas at the Dalaran Dungeons, and you can train " + GetObjectName(UNITTYPE_ID) + "s from the Consortium"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, QUEST_RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(Holder.Player, UNITTYPE_ID, "You can now train " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID) + ".")
    endmethod

    private method OnFail takes nothing returns nothing
      local unit u
      local player holderPlayer = this.Holder.Person.Player
      local Legend triggerLegend = GetTriggerLegend()
      set LEGEND_KAEL.StartingXP = GetHeroXP(LEGEND_ANASTERIAN.Unit)
      call this.Holder.obliterate()
      if this.Holder.ScoreStatus != SCORESTATUS_DEFEATED then
        loop
          set u = FirstOfGroup(thistype.SecondChanceUnits)
          exitwhen u == null
          call UnitRescue(u, holderPlayer)
          call GroupRemoveUnit(thistype.SecondChanceUnits, u)
        endloop
        call DestroyGroup(thistype.SecondChanceUnits)
        call SetPlayerTechResearched(Holder.Player, QUEST_RESEARCH_ID, 1)
        call LEGEND_KAEL.Spawn(this.Holder.Player, -11410, 21975, 110)
        call UnitAddItem(LEGEND_KAEL.Unit, CreateItem('I00M', GetUnitX(LEGEND_KAEL.Unit), GetUnitY(LEGEND_KAEL.Unit)))
        if GetLocalPlayer() == this.Holder.Player then
          call SetCameraPosition(GetRectCenterX(gg_rct_BloodElfSecondChanceSpawn), GetRectCenterY(gg_rct_BloodElfSecondChanceSpawn))
        endif
      endif
      call SetTriggerLegend(triggerLegend)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(QUEST_RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(UNITTYPE_ID, 6)
      call Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    private static method onInit takes nothing returns nothing
      //Setup initially invulnerable and hidden group at Dalaran Dungeons
      local group tempGroup = CreateGroup()
      local unit u
      local integer i = 0
      set thistype.SecondChanceUnits = CreateGroup()
      call GroupEnumUnitsInRect(tempGroup, gg_rct_BloodElfSecondChanceSpawn, null)
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call ShowUnit(u, false)
          call SetUnitInvulnerable(u, true)
          call GroupAddUnit(thistype.SecondChanceUnits, u)
        endif
        call GroupRemoveUnit(tempGroup, u)
        set i = i + 1
      endloop
      call DestroyGroup(tempGroup)
      set tempGroup = null
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Blood Elves", "The Elves of Quel'thalas have a deep reliance on the Sunwell's magic. Without it, they would have to turn to darker magicks to sate themselves.", "ReplaceableTextures\\CommandButtons\\BTNHeroBloodElfPrince.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LEGIONNEXUS))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ANASTERIAN, true))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, true))
      return this
    endmethod
  endstruct

endlibrary