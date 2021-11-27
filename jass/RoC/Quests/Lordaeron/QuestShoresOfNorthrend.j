library QuestShoresOfNorthrend requires LordaeronSetup, LegendLordaeron, GeneralHelpers

  globals
    private constant integer RESEARCH_ID = 'R06F'
  endglobals

  struct QuestShoresOfNorthrend extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Crown Prince Arthas, and what remains of his forces, have landed on the shores of Northrend and established a base camp."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "A new base near Dragonblight in Northrend, and Arthas revives there"
    endmethod

    private method OnFail takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED)
    endmethod

    private method OnComplete takes nothing returns nothing
      call KillNeutralHostileUnitsInRadius(415.2, 16521, 2300)
      call KillNeutralHostileUnitsInRadius(-2190, 16803, 700)
      if GetOwningPlayer(LEGEND_ARTHAS.Unit) == this.Holder.Player then
        call ReviveHero(LEGEND_ARTHAS.Unit, 400., 16102., true)
        call BlzSetUnitFacingEx(LEGEND_ARTHAS.Unit, 112.)
      endif
      call CreateStructureForced(this.Holder.Player, 'h01C', -51.33152, 16679.69, 4.757993*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'nmrk', 1280, 16064, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hctw', -640, 16576, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hbar', -256, 16832, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'halt', 416, 16416, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hpea', 818.7402, 16864.73, 6.156587*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hpea', 624.0182, 16725.41, 4.578159*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hgtw', -960, 15872, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hdes', 582.6755, 15512.92, 4.3173*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hshy', 800, 15776, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hcas', -512, 15744, 4.712389*bj_RADTODEG, 512)
      call CreateStructureForced(this.Holder.Player, 'hbla', 672, 16928, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hfoo', 771.1509, 16064.29, 0.6401012*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hgtw', -448, 16128, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hwtw', 704, 17152, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hhou', -1088, 16576, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'h035', -928, 16736, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hfoo', -174.4257, 16631.17, 3.987584*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hfoo', -388.7579, 16871.45, 4.113693*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hfoo', -561.5654, 16521.54, 6.02386*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hdes', 251.9047, 15569.37, 5.33097*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hbla', 800, 16288, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hgtw', 1472, 16384, 4.712389*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'hkni', 893.3604, 16175.58, 4.130178*bj_RADTODEG, 256)
      call CreateStructureForced(this.Holder.Player, 'nchp', -931.2155, 16554.75, 5.458206*bj_RADTODEG, 256)
      call this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Shores of Northrend", "Mal'ganis' citadel lies somewhere within the arctic wastes of the north. In order to assault the Dreadlord, Arthas must first establish a base camp at the shores of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, true))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_SCHOLOMANCE))
      call this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, 'hshy'))
      return this
    endmethod
  endstruct

endlibrary