
library QuestJoinCrusade requires Persons, KultirasSetup, GeneralHelpers

  globals 
    private constant integer QUEST_RESEARCH_ID = 'R06U'   //This research is given when the quest is completed
  endglobals

  struct QuestJoinCrusade extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "Kul Tiras has joined the Scarlet Crusade"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Unlock Order Inquisitor and join the Scarlet Crusade"
    endmethod    

    private method OnComplete takes nothing returns nothing
      call UnitRemoveAbilityBJ( 'A0JB', LEGEND_ADMIRAL.Unit)
      set this.Holder.Team = TEAM_SCARLET
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Join the Crusade", "Daelin Proudmoore sees the plight of the Scarlet Crusade. As human survivors of horrible war, they should join forces", "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
      call this.AddQuestItem(QuestItemCastSpell.create('A0JB', true))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary