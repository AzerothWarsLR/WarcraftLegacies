library QuestWarsongHold requires WarsongSetup, LegendWarsong, GeneralHelpers, QuestItemControlPoint

  globals
    private constant integer RESEARCH_ID = 'R06G'
    private constant integer ABILITY_ID = 'A0DZ'
  endglobals

  struct QuestWarsongHold extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Warsong Clan has set sail for the icy shores of Northrend and set up a formidable encampment at Borean Tundra."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "A new base at Borean Tundra in Northrend"
    endmethod

    private method OnComplete takes nothing returns nothing
      local unit boreanTundra = ControlPoint.ByUnitType('n00G').Unit
      local unit warsongHold
      call KillNeutralHostileUnitsInRadius(GetUnitX(boreanTundra), GetUnitY(boreanTundra), 2300)
      //Spawn the base
      call SetUnitOwner(boreanTundra, this.Holder.Player, true)
      set warsongHold = CreateStructureForced(this.Holder.Player, 'o02S', -7648, 15456, 270, 192)
      call BlzSetUnitName(warsongHold, "Warsong Hold")
      call BlzSetUnitMaxHP(warsongHold, 4000)
      call SetUnitLifePercentBJ(warsongHold, 100)
      call UnitAddAbility(warsongHold, ABILITY_ID)
      call CreateStructureForced(this.Holder.Player, 'n03E', -7296, 15680, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o01T', -7456, 15008, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o028', -7808, 16512, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o028', -7296, 16000, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o028', -7424, 16192, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o028', -6656, 15616, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o028', -6912, 15744, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'n08E', -8299.43, 16110.51, 1.850517*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o02Q', -8512, 15936, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'n08E', -8513.6, 16171.06, 1.126743*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o01S', -8192, 16576, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o02M', -8048.254, 16427.75, -0.7628738*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o02M', -8065.816, 15788.13, -0.08624744*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o028', -7936, 16768, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o02T', -6752, 14880, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'odes', -8633.19, 15012.82, -1.101598*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o020', -6976, 15552, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'n03E', -8064, 15360, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'n03E', -8320, 16000, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o02M', -7086.232, 15749.21, 1.348478*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'n03E', -7808, 16128, 4.712389*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'orai', -7319.426, 15134.72, 0.467489*bj_RADTODEG, 128)
      call CreateStructureForced(this.Holder.Player, 'o02T', -8672, 15328, 4.712389*bj_RADTODEG, 128)
      call this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Warsong Hold", "The far-off land of Northrend is the new home of the traitor shaman Ner'zhul. The Warsong must land its forces on its shores in order to end the existential threat he now represents.", "ReplaceableTextures\\CommandButtons\\BTNTuskaarBrown.blp")
      call this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, 'o02T'))
      return this
    endmethod
  endstruct

endlibrary