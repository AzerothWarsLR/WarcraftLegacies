
library QuestGreatTreachery requires Persons, GeneralHelpers

  globals 
    private constant integer QUEST_RESEARCH_ID = 'R075'   //This research is given when the quest is completed
  endglobals

  struct QuestGreatTreachery extends QuestData
    private method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The Blood Elves have joined the Burning Legion"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Unlock the summon Kil'jaeden quest and join the Burning Legion team"
    endmethod    

    private method OnComplete takes nothing returns nothing
      set STAY_LOYAL.Progress = QUEST_PROGRESS_FAILED
      call UnitRemoveAbilityBJ( 'A0IF', LEGEND_KAEL.Unit)
      call UnitRemoveAbilityBJ( 'A0IK', LEGEND_KAEL.Unit)
      call RemoveUnit(LEGEND_LORTHEMAR.Unit)
      call FACTION_QUELTHALAS.ModObjectLimit('H02E',-UNLIMITED)       //Lorthemar
      set this.Holder.Team = TEAM_LEGION
      set SUMMON_KIL.Progress = QUEST_PROGRESS_INCOMPLETE
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Great Treachery", "Kil'jaeden has approached Kael with an offer of power and salvation for his people. Only by accepting will his hunger for magic by satiated", "ReplaceableTextures\\CommandButtons\\BTNFelKaelthas.blp")
      call this.AddQuestItem(QuestItemCastSpell.create('A0IF', true))
      call this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_KAEL, 6))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary