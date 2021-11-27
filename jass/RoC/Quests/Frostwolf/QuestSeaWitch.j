//Frostwolf kills the Sea Witch. Thrall gets some boats to leave the Darkspear Isles.
//Presently this ONLY deals with the final component of the event. The rest is done in GUI. 
library QuestSeaWitch requires FrostwolfSetup, LegendNeutral, Display, QuestItemLegendDead

  globals
    private weathereffect Storm
    private constant integer QUEST_RESEARCH_ID = 'R05H' 
  endglobals

  struct QuestSeaWitch extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The sea witch Zar'jira has been slain. Thrall and Vol'jin can now set sail."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gain control of all neutral units on the Darkspear Isles and teleport to shore"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_EchoUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      local Person killingPerson = Person.ByHandle(GetOwningPlayer(GetKillingUnit()))
      local group tempGroup = CreateGroup()
      local unit u
      //Transfer control of all passive units on island and teleport all Frostwolf units to shore
      call RescueNeutralUnitsInRect(gg_rct_CairneStart, this.Holder.Player)
      call GroupEnumUnitsInRect(tempGroup, gg_rct_Darkspear_Island, null)
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, this.Holder.Player)
        endif
        if GetOwningPlayer(u) == FACTION_FROSTWOLF.Player and IsUnitType(u, UNIT_TYPE_STRUCTURE) == false then
          call SetUnitPosition(u, GetRandomReal(GetRectMinX(gg_rct_ThrallLanding), GetRectMaxX(gg_rct_ThrallLanding)), GetRandomReal(GetRectMinY(gg_rct_ThrallLanding), GetRectMaxY(gg_rct_ThrallLanding)))
        endif
        call GroupRemoveUnit(tempGroup, u)
      endloop
      call DestroyGroup(tempGroup)
      call RemoveWeatherEffectBJ(Storm)
      call CreateUnits(this.Holder.Player, 'opeo', -1818, -2070, 270, 3)
      call RescueNeutralUnitsInRect(gg_rct_EchoUnlock, this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ("war3mapImported\\WarsongTheme.mp3")
      endif
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Riders on the Storm", "Warchief Thrall and his forces have been shipwrecked on the Darkspear Isles. Kill the Sea Witch there to give them a chance to rebuild their fleet and escape.", "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(LEGEND_SEAWITCH.Unit))
      call this.AddQuestItem(QuestItemExpire.create(600))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      set Storm = AddWeatherEffect(gg_rct_Darkspear_Island, 'RAhr')
      call EnableWeatherEffect(Storm, true)
    endmethod
  endstruct

endlibrary