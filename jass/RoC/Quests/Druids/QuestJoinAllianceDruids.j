library QuestJoinAllianceDruid requires Persons, GeneralHelpers

  struct QuestJoinAllianceDruid extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "The Druids have joined the Alliance"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Join the Alliance team"
    endmethod    


    private method OnComplete takes nothing returns nothing
      call UnitRemoveAbilityBJ( 'A0IG', LEGEND_MALFURION.Unit)
      set this.Holder.Team = TEAM_ALLIANCE
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Join the Alliance", "With a world ending threat happening, the Alliance has reached to the Night Elves to join them", "ReplaceableTextures\\CommandButtons\\BTNalliance.blp")
      call this.AddQuestItem(QuestItemCastSpell.create('A0IG', true))
      return this
    endmethod
  endstruct

endlibrary