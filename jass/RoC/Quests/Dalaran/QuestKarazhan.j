library QuestKarazhan requires LegendNeutral

  struct QuestKarazhan extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Karazhan has been captured. " + this.Holder.Name + "'s  archivists scour its halls for arcane resources."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to research three powerful upgrades at Karazhan."
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit('R020', UNLIMITED)   //Rain: An Amalgam
      call Holder.ModObjectLimit('R03M', UNLIMITED)   //Methods of Control
      call Holder.ModObjectLimit('R01B', UNLIMITED)   //A Treatise on Barriers
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Secrets of Karazhan", "The spire of Medivh stands mysteriously idle. Dalaran could make use of its grand magicks.", "ReplaceableTextures\\CommandButtons\\BTNTomeBrown.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_KARAZHAN, false))
      return this
    endmethod
  endstruct

endlibrary