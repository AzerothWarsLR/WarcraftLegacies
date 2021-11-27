library QuestMoreWyverns requires LegendSentinels, Display, QuestItemLegendDead

  globals
    private constant integer UNITTYPE_ID = 'owyv'
    private constant integer LIMIT_CHANGE = 2
  endglobals

  struct QuestMoreWyverns extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Sentinels have been eliminated. Warchief Thrall breathes a sigh of relief, knowing that his people are safe - for now."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + I2S(LIMIT_CHANGE) + " additional " + GetObjectName(UNITTYPE_ID) + "s"
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.Holder.ModObjectLimit(UNITTYPE_ID, LIMIT_CHANGE)
      call DisplayUnitLimit(this.Holder, UNITTYPE_ID)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Perfect Warriors", "The prowess and savagery of the Sentinels is to be respected - and feared. They must be eliminated.", "ReplaceableTextures\\CommandButtons\\BTNArcher.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_FEATHERMOON))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_AUBERDINE))
      return this
    endmethod
  endstruct

endlibrary