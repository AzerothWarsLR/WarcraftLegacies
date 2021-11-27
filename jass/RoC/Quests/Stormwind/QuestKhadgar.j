//When Black Temple is destroyed, Stormwind can train Khadgar.
library QuestKhadgar requires QuestData, StormwindSetup, GeneralHelpers

  globals
    private constant integer HERO_ID = 'H05Y'
  endglobals

  struct QuestKhadgar extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Khadgar has been freed from his confines under the Black Temple, and he is now free to serve the Kingdom of Stormwind."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Khadgar from the Altar of Kings"
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Keeper of the Eternal Watch", "At the end of the Second War, Khadgar remained in Draenor to seal the Dark Portal, effectively ending the conflict. He has been stranded deep in Outland ever since.", "ReplaceableTextures\\CommandButtons\\BTNMageWC2.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_BLACKTEMPLE))
      set this.ResearchId = 'R016'
      return this
    endmethod
  endstruct

endlibrary