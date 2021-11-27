library QuestLiberateLordaeron requires QuestData, ScarletSetup

  globals
    private constant integer QUESTRESEARCH_ID = 'R07P'   //This research is given when the quest is completed
  endglobals

  struct QuestLiberateLordaeron extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The lands of Lordaeron have been purged from Undeath and Corruption"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Enable to train Commander Goodchild and Isilien, Unlock New Hearthglen in Northrend and the Scarlet Harbor"
    endmethod

    private method OnComplete takes nothing returns nothing
      call RemoveDestructable(gg_dest_DTg6_36078)
      call RescueNeutralUnitsInRect(gg_rct_ScarletHarbor, this.Holder.Player)
      call KillNeutralHostileUnitsInRadius(415.2, 16521, 2300)
      call KillNeutralHostileUnitsInRadius(-2190, 16803, 700)
      call CreateStructureForced(this.Holder.Player, 'h08J', -51.33152, 16679.69, 4.757993*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h086', 1280, 16064, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h087', -640, 16576, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h081', -256, 16832, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h080', 416, 16416, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hpea', 818.7402, 16864.73, 6.156587*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hpea', 624.0182, 16725.41, 4.578159*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h085', -960, 15872, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hdes', 582.6755, 15512.92, 4.3173*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hshy', 800, 15776, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h07Z', -512, 15744, 4.712389*bj_RADTODEG, 512)
      call CreateStructureForced(this.Holder.Player, 'h06G', 672, 16928, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h08I', 771.1509, 16064.29, 0.6401012*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h085', -448, 16128, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h085', 704, 17152, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h088', -1088, 16576, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h083', -928, 16736, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h08I', -174.4257, 16631.17, 3.987584*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h08I', -388.7579, 16871.45, 4.113693*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h08I', -561.5654, 16521.54, 6.02386*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hdes', 251.9047, 15569.37, 5.33097*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h097', 800, 16288, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h085', 1472, 16384, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h08L', 893.3604, 16175.58, 4.130178*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'no68', -931.2155, 16554.75, 5.458206*bj_RADTODEG, 256)
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Liberation of Lordaeron", "The Lands of Lordaeron are overrun by corruption, everything must be purged", "ReplaceableTextures\\CommandButtons\\BTNNorthrendCastle.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_BRIGITTE, false))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01F')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n03P')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01H')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01M')))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUESTRESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary