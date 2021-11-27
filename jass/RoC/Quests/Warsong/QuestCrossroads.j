//If any Horde unit enters the Crossroads area, OR a time elapses, OR someone becomes a solo Horde Path, give the Crossroads to a Horde player.

library QuestCrossroads requires Persons, FrostwolfSetup, WarsongSetup, GeneralHelpers

  struct QuestCrossroads extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "The Crossroads have been constructed."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of the Crossroads"
    endmethod    

    private method GiveCrossroads takes player whichPlayer returns nothing
      local unit u

      //Transfer all Neutral Passive units in Crossroads to one of the above factions
      set u = FirstOfGroup(udg_Crossroad)
      loop
      exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, whichPlayer)
        endif
        call GroupRemoveUnit(udg_Crossroad, u)
        set u = FirstOfGroup(udg_Crossroad)
      endloop
      //Give resources and display message
      call CreateUnit(whichPlayer, 'oeye', -12844, -1975, 0)
      call CreateUnit(whichPlayer, 'oeye', -10876, -2066, 0)
      call CreateUnit(whichPlayer, 'oeye', -11922, -824, 0)

      //Cleanup
      call DestroyGroup(udg_Crossroad)
      call AdjustPlayerStateBJ( 2000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER )
    endmethod

    private method OnFail takes nothing returns nothing
        call this.GiveCrossroads(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GiveCrossroads(this.Holder.Player)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Crossroads", "The Horde still needs to establish a strong strategic foothold into Kalimdor. There is an opportune crossroads nearby.", "ReplaceableTextures\\CommandButtons\\BTNBarracks.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nrzm_0113)) //Razorman Medicine Man
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01T')))
      call this.AddQuestItem(QuestItemExpire.create(1460))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary