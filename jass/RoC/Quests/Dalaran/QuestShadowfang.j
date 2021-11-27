library QuestShadowfang requires QuestData, LordaeronSetup, QuestItemKillUnit, GeneralHelpers


  struct QuestShadowfang extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Shadowfang has been liberated, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Shadowfang"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_ShadowfangUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_ShadowfangUnlock, this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Shadows of Silverspine Forest", "The woods of Silverspine are unsafe for travellers, they need to be investigated", "ReplaceableTextures\\CommandButtons\\BTNworgen.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_o02J_0984)) //Worgen
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01D')))
      call this.AddQuestItem(QuestItemExpire.create(1444))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary