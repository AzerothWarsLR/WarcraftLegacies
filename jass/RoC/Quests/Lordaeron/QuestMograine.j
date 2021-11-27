//Destroy the Frozen Throne to unlock Mograine.
library QuestMograine requires LordaeronSetup, LegendLordaeron, QuestItemLegendDead

  globals
    private constant integer ALTAR_ID = 'halt'
    private constant integer HERO_ID = 'H01J'
  endglobals

  struct QuestMograine extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. Alexandros Mograine gains recognition as a champion of the war, and prepares himself to aid Lordaeron in future conflicts in a greater capacity."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Alexandros Mograine from the " + GetObjectName(ALTAR_ID)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Exile", "The Lich King, looming over Northrend from Icecrown's peak, is the greatest threat Lordaeron has ever faced. He must be destroyed.", "ReplaceableTextures\\CommandButtons\\BTNAlexandros.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING))
      set this.ResearchId = 'R06P'
      return this
    endmethod
  endstruct

endlibrary