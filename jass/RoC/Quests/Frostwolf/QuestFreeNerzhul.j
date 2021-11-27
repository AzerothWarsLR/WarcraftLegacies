library QuestFreeNerzhul requires QuestData, LegendFrostwolf, FrostwolfSetup

  struct QuestFreeNerzhul extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Ner'zhul is finally free from his tortured existence as the bearer of the Helm of Domination. With his dying breath, he passes his wisdom on to Thrall."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Thrall gains 10 Strength, 10 Agility and 10 Intelligence"
    endmethod   

    private method OnComplete takes nothing returns nothing
      call AddHeroAttributes(LEGEND_THRALL.Unit, 10, 10, 10)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Jailor of the Damned", "Before he became the Lich King, Ner'zhul was the chieftain and elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne.", "ReplaceableTextures\\CommandButtons\\BTNShaman.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(LEGEND_LICHKING.Unit))
      return this
    endmethod
  endstruct

endlibrary