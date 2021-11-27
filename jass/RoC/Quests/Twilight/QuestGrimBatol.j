library QuestGrimBatol requires QuestData, TwilightSetup, GeneralHelpers

  globals
    private constant integer QUEST_RESEARCH_ID = 'R06Y'   //This research is given when the quest is completed
  endglobals

  struct QuestGrimBatol extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Grim Batol is now under our control, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Grim Batol and able to train Orcish Death Knights"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Grim_Batol, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetUnitOwner(gg_unit_h01Z_0618, this.Holder.Player, true)
      call WaygateActivateBJ( true, gg_unit_n08R_2209 )
      call WaygateActivateBJ( true, gg_unit_n08R_2214 )
      call RescueNeutralUnitsInRect(gg_rct_Grim_Batol, this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Cursed Fortress", "The mountain fortress of Grim Batol will be the perfect stronghold for the Twilight hammer clan. It has served well in the past and will do so again.", "ReplaceableTextures\\CommandButtons\\BTNFortressWC2.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_VAELASTRASZ))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n03X')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n04V')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n09F')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n08T')))
      call this.AddQuestItem(QuestItemExpire.create(1428))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary