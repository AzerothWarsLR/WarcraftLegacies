library QuestReanimateSylvanas requires QuestData, ScourgeSetup, QuelthalasSetup, LegendQuelthalas

  globals
    private constant integer SYLVANAS_ID = 'Usyl'
    private constant integer ALTAR_ID = 'uaod'
  endglobals

  struct QuestReanimateSylvanas extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Quel'thalas has fallen to the Scourge's onslaught. The Sunwell itself has been corrupted, cutting the quel'dorei off from the source of their longevity. Sylvanas is denied a clean death following her tenacious defense, and she becomes the first of the High Elven Banshees."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Sylvanas from the " + GetObjectName(ALTAR_ID)
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetUnitAnimation(LEGEND_SUNWELL.Unit, "stand second")
      call SetUnitAnimation(LEGEND_SUNWELL.Unit, "stand third")
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The First Banshee", "Sylvanas, the Ranger-General of Silvermoon, stands between the legions of the Scourge and the Sunwell. Destroy her people, and her soul will be transformed into a tormented Banshee under the Scourge's control.", "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false))
      set this.ResearchId = 'R02D'
      return this
    endmethod
  endstruct

endlibrary