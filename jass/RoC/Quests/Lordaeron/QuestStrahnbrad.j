library QuestStrahnbrad requires QuestData, LordaeronSetup, QuestItemControlPoint, QuestItemExpire, QuestItemSelfExists, GeneralHelpers


  struct QuestStrahnbrad extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Strahnbrad has been liberated."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all buildings in Strahnbrad"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_StrahnbradUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_StrahnbradUnlock, this.Holder.Player)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Defense of Strahnbrad", "The Strahnbrad is under attack by some brigands, clear them out", "ReplaceableTextures\\CommandButtons\\BTNFarm.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01C')))
      call this.AddQuestItem(QuestItemExpire.create(1170))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary