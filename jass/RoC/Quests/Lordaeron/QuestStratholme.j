library QuestStratholme requires QuestData, LordaeronSetup, QuestItemKillUnit, GeneralHelpers


  struct QuestStratholme extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Stratholme has been liberated, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Stratholme"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_StratholmeUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_StratholmeUnlock, this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Blackrock and Roll", "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron", "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_o00B_1316)) //Jubei
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n019')))
      call this.AddQuestItem(QuestItemUpgrade.create('hcas', 'htow'))
      call this.AddQuestItem(QuestItemExpire.create(1470))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary