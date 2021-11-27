library QuestThirdObelisk requires QuestData, BlackEmpirePortalSetup, Herald

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07K'   //This research is given when the quest is completed
  endglobals

  struct QuestThirdObelisk extends QuestData
    method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The Merging of Realities has come to pass. The Nya'lothan portals to Storm Peaks, Northern Highlands, and Tanaris have been permanently opened."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The Nya'lothan portals to Storm Peaks, Northern Highlands, and Tanaris will be permanently opened"
    endmethod

    //Opens the central portals in Nyalotha permanently.
    private method OpenPortals takes nothing returns nothing
      call this.Holder.ModObjectLimit('u02E', -UNLIMITED) //Herald
      call this.Holder.SetObjectLevel(QUEST_RESEARCH_ID, 1)
      set BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS.PortalState = BLACKEMPIREPORTALSTATE_OPEN
      set BLACKEMPIREPORTAL_TANARIS.PortalState = BLACKEMPIREPORTALSTATE_OPEN
      set BLACKEMPIREPORTAL_NORTHREND.PortalState = BLACKEMPIREPORTALSTATE_OPEN
      call RemoveDestructable(gg_dest_ATg2_35871)
      call RemoveDestructable(gg_dest_ATg1_35873)
      call RemoveDestructable(gg_dest_ATg3_35869)
      call RemoveDestructable(gg_dest_ATg3_35872)
      call RemoveUnit(Herald.Instance.unit)
      call BlackEmpirePortal.GoToNext()
      if GetLocalPlayer() == this.Holder.Player then
        call SetCameraPosition(-25528, -1979)
      endif
    endmethod

    private method OnComplete takes nothing returns nothing
      call PlayThematicMusicBJ("war3mapImported\\BlackEmpireTheme.mp3")
      call this.OpenPortals()
    endmethod

    private method OnFail takes nothing returns nothing
      call this.OpenPortals()
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Merging of Realities", "Reality frays at the seams as madness threatents to overtake it. Once an Obelisk has been established at Tanaris, the mirror worlds of Azeroth and Ny'alotha will finally be one, and the Black Empire will be unleashed.", "ReplaceableTextures\\CommandButtons\\BTNHorrorSoul.blp")
      call this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType('n02S')))
      call this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType('n04V')))
      call this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType('n020')))
      call this.AddQuestItem(QuestItemExpire.create(960))
      return this
    endmethod
  endstruct

endlibrary