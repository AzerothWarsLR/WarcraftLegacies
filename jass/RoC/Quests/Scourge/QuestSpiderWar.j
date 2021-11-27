library QuestSpiderWar requires QuestData, QuestItemKillUnit, QuestItemExpire, QuestItemSelfExists, GeneralHelpers

  globals
    private constant integer QUEST_RESEARCH_ID = 'R03A'
  endglobals

  struct QuestSpiderWar extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Northrend and the Icecrown Citadel is now under full control of the Lich King and the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Access to the Plague Research at the Frozen Throne, Kel'tuzad and Rivendare trainable and a base in Icecrown"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Ice_Crown, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Ice_Crown, this.Holder.Player)
      call SetPlayerTechResearched(Holder.Player, 'R03A', 1) 
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\ScourgeTheme.mp3" )
      endif
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("War of the Spider", "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNNerubianQueen.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00I')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n08D')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00G')))
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_n074_1565)) //Nezar'azret
      call this.AddQuestItem(QuestItemUpgrade.create('unp2', 'unpl'))
      call this.AddQuestItem(QuestItemExpire.create(1480))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary