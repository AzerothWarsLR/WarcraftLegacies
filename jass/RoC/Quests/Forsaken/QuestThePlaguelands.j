library QuestThePlaguelands requires QuestData, ForsakenSetup

  struct QuestThePlaguelands extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The ravaged lands of Lordaeron are now under the control of the Forsaken and able to train up to 4 Val'kyr join their ranks. 500 gold was plundered."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Enable 4 Val'kyr to be raised and grants 500 gold"
    endmethod

    private method OnComplete takes nothing returns nothing
    call FACTION_FORSAKEN.ModObjectLimit('u01V', 4)           //Valyr
    call AdjustPlayerStateBJ( 500, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD )
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Plaguelands", "The ravaged lands of Lordaeron must be conquered by the Forsaken, their survival depends on it", "ReplaceableTextures\\CommandButtons\\BTNNathanosBlightcaller.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NATHANOS, false))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01F')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n044')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01H')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n03P')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01M')))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary