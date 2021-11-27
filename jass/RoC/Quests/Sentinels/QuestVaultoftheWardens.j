library QuestVaultoftheWardens requires QuestData, SentinelsSetup, QuestItemControlPoint

  globals
    private constant integer RESEARCH_ID = 'R06H'
    private constant integer WARDEN_ID = 'h045'
  endglobals

  struct QuestVaultoftheWardens extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "With the Broken Isles and the Tomb of Sargeras secured, work has begun on a maximum security prison named the Vault of the Wardens."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The Vault of the Wardens and 4 free Wardens appear at the Broken Isles, and you learn to train Wardens"
    endmethod

    private method OnComplete takes nothing returns nothing
      call CreateUnit(this.Holder.Player, 'n04G', GetRectCenterX(gg_rct_VaultoftheWardens), GetRectCenterY(gg_rct_VaultoftheWardens), 220)
      call CreateUnits(this.Holder.Player, WARDEN_ID, GetRectCenterX(gg_rct_VaultoftheWardens), GetRectCenterY(gg_rct_VaultoftheWardens), 270, 4)
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(Holder.Player, WARDEN_ID, "You can now train Wardens from the Vault of the Wardens, Sentinel Enclaves, and your capitals.")
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(WARDEN_ID, 8)
      call this.Holder.ModObjectLimit(RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Vault of the Wardens", "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari. The Broken Isles, now raised from the sea floor, would be a strategic location for a newer edition of such a prison.", "ReplaceableTextures\\CommandButtons\\BTNReincarnationWarden.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n05Y')))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary