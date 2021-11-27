library QuestSummonKil requires QuestData

  globals
    private constant integer RITUAL_ID = 'A0R7'
  endglobals

  struct QuestSummonKil extends QuestData
    private method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The greater demon Kil'jaeden has been summoned to Azeroth"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The hero Kil'jaeden"
    endmethod

    private method OnComplete takes nothing returns nothing
      call UnitRemoveAbilityBJ( 'A0R7', LEGEND_KAEL.Unit)
      call LEGEND_KILJAEDEN.Spawn(FACTION_QUELTHALAS.Player, GetRectCenterX(gg_rct_Sunwell), GetRectCenterY(gg_rct_Sunwell), 244)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Great Deceiver", "The greater demon Kil'jaeden has been scheming for aeons, will Kael finally be the one to summon him and consume Azeroth?", "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp")
      call this.AddQuestItem(QuestItemChannelRect.create(gg_rct_KaelSunwellChannel, "The Sunwell", LEGEND_KAEL, 15, 270))
      return this
    endmethod
  endstruct

endlibrary