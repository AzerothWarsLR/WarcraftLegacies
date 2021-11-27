library QuestTitanJailors requires QuestData, CthunSetup, QuestItemKillUnit, GeneralHelpers

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07B'   //This research is given when the quest is completed
  endglobals

  struct QuestTitanJailors extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Unlocks the Inner Ahn'qiraj base and enables us to start awakening C'thun."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Ahn'qirak inner temple and unlock the awakening spell for C'thun"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_TunnelUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
      call WaygateActivateBJ( true, gg_unit_h03V_0591 )
      call WaygateSetDestinationLocBJ( gg_unit_h03V_0591, GetRectCenter(gg_rct_Silithus_Stone_Interior) )
    endmethod

    private method OnComplete takes nothing returns nothing
      call WaygateActivateBJ( true, gg_unit_h03V_0591 )
      call WaygateSetDestinationLocBJ( gg_unit_h03V_0591, GetRectCenter(gg_rct_Silithus_Stone_Interior) )
      call RescueNeutralUnitsInRect(gg_rct_TunnelUnlock, this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Jailors of the Old God", "The Old God C'thun is imprisoned deep within the temple of Ahn'qiraj. Defeat the Jailors that guard him to start awakening him.", "ReplaceableTextures\\CommandButtons\\BTNArmorGolem.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nsgg_1490)) //Golem
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n02K')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n078')))
      call this.AddQuestItem(QuestItemExpire.create(1428))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary