library QuestTortolla initializer OnInit requires QuestData, DruidsSetup, GeneralHelpers, LegendDruids

  globals
    private constant integer HERO_ID = 'H04U'
  endglobals

  struct QuestTortolla extends QuestData
    static unit sleepingTortolla

    private method operator CompletionPopup takes nothing returns string
      return "Tortolla has finally awoken from his ancient slumber."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Tortolla from the Altar of Elders"
    endmethod

    private method OnComplete takes nothing returns nothing
      call RemoveUnit(thistype.sleepingTortolla)
    endmethod

    private method OnFail takes nothing returns nothing
      call RemoveUnit(thistype.sleepingTortolla)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Turtle Demigod", "Tortolla was badly wounded during the War of the Ancients, and has been resting ever since.", "ReplaceableTextures\\CommandButtons\\BTNSeaTurtleGreen.blp")
      call this.AddQuestItem(QuestItemTime.create(1200))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = 'R049'
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    set QuestTortolla.sleepingTortolla = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), HERO_ID, -12827, 5729, 333)
    call SetUnitInvulnerable(QuestTortolla.sleepingTortolla, true)
    call AddSpecialEffectTarget("Abilities\\Spells\\Undead\\Sleep\\SleepTarget.mdl", QuestTortolla.sleepingTortolla, "overhead")
    call SetHeroXP(QuestTortolla.sleepingTortolla, LEGEND_TORTOLLA.StartingXP, false)
  endfunction

endlibrary