//Anyone on the Night Elves team approaches Moonglade with a unit with the Horn of Cenarius,
//Causing Malfurion to spawn.
library QuestMalfurionAwakens initializer OnInit requires DruidsSetup, LegendDruids, Display, GeneralHelpers

  globals
    private group MoongladeUnits

    private constant integer HORN_OF_CENARIUS = 'cnhn'
    private constant integer GHANIR = 'I00C'
  endglobals

  struct QuestMalfurionAwakens extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Malfurion has emerged from his deep slumber in the Barrow Den."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gain the hero Malfurion and the artifact G'hanir"
    endmethod

    private method GiveMoonglade takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Moonglade
      call GroupEnumUnitsInRect(tempGroup, gg_rct_MoongladeVillage, null)
      set u = FirstOfGroup(tempGroup)
      loop
      exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, whichPlayer)
        endif
        call GroupRemoveUnit(tempGroup, u)
        set u = FirstOfGroup(tempGroup)
      endloop

      //Cleanup
      call DestroyGroup(tempGroup)
      set tempGroup = null
    endmethod

    private method OnFail takes nothing returns nothing
      call this.GiveMoonglade(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GiveMoonglade(this.Holder.Player)
      if LEGEND_MALFURION.Unit == null then
        call LEGEND_MALFURION.Spawn(Holder.Player, GetRectCenterX(gg_rct_Moonglade), GetRectCenterY(gg_rct_Moonglade), 270)
        call SetHeroLevel(LEGEND_MALFURION.Unit, 3, false)
        call UnitAddItemSafe(LEGEND_MALFURION.Unit, ARTIFACT_GHANIR.item)
      else
        call SetItemPosition(ARTIFACT_GHANIR.item, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()))
      endif
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Awakening of Stormrage", "Ever since the War of the Ancients ten thousand years ago, Malfurion Stormrage and his druids have slumbered within the Barrow Den. Now, their help is required once again.", "ReplaceableTextures\\CommandButtons\\BTNFurion.blp")
      call this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_HORNOFCENARIUS))
      call this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_HORNOFCENARIUS, gg_rct_Moonglade, "The Barrow Den"))
      call this.AddQuestItem(QuestItemExpire.create(1440))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    //Setup initially invulnerable and hidden group at Moonglade
    local group tempGroup = CreateGroup()
    local unit u
    local integer i = 0
    set MoongladeUnits = CreateGroup()
    call GroupEnumUnitsInRect(tempGroup, gg_rct_MoongladeVillage, null)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
        call SetUnitInvulnerable(u, true)
        call GroupAddUnit(MoongladeUnits, u)
      endif
      call GroupRemoveUnit(tempGroup, u)
      set i = i + 1
    endloop
    call DestroyGroup(tempGroup)
    set tempGroup = null
    //Add quest
  endfunction

endlibrary