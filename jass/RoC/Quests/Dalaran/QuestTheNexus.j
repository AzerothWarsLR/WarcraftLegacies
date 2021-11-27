library QuestTheNexus requires Persons, DalaranSetup, GeneralHelpers

  struct QuestTheNexus extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The Nexus powers have been absorbed by Jaina and she joins the Lich King in the eternal ice of Northrend."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You become the Nexus faction, allied with the Scourge and enemy with everyone else. Jaina becomes much more powerful"
    endmethod    

    private method OnComplete takes nothing returns nothing
      call FACTION_DALARAN.ModObjectLimit('h069',-UNLIMITED)       //Military Quarters
      call FACTION_DALARAN.ModObjectLimit('h067',-UNLIMITED)       //Laboratory
      call FACTION_DALARAN.ModObjectLimit('n096',-UNLIMITED)       //Golem
      call FACTION_DALARAN.ModObjectLimit('o02U',-UNLIMITED)       //Crystal artillery
      call FACTION_DALARAN.ModObjectLimit('n0AD',-UNLIMITED)       //Crystal Golem
      call FACTION_DALARAN.ModObjectLimit('h032',-UNLIMITED)       //Battlemage
      call FACTION_DALARAN.ModObjectLimit('n007',-UNLIMITED)       //Kirintor
      call FACTION_DALARAN.ModObjectLimit('h022',-UNLIMITED)       //Peasant
      call FACTION_DALARAN.ModObjectLimit('Hant',-UNLIMITED)       //Antonidas
      call FACTION_DALARAN.ModObjectLimit('Haah',-UNLIMITED)       //Mediv
      call FACTION_DALARAN.ModObjectLimit('njks',-UNLIMITED)       //Kasan
      call FACTION_DALARAN.ModObjectLimit('R06O',-UNLIMITED)       //Phase Blade
      call FACTION_DALARAN.ModObjectLimit('R061',-UNLIMITED)       //Forked Lightning
      call RemoveUnit(LEGEND_ANTONIDAS.Unit)
      call RemoveUnit(LEGEND_MEDIVH.Unit)

      call FACTION_DALARAN.ModObjectLimit('U026',1)               //Malygos
      call FACTION_DALARAN.ModObjectLimit('U027',1)               //Kalecgos

      call FACTION_DALARAN.ModObjectLimit('n0A1',6)               //Elite
      call FACTION_DALARAN.ModObjectLimit('h09C',UNLIMITED)               //Worker
      call FACTION_DALARAN.ModObjectLimit('h099',UNLIMITED)               //Infantry
      call FACTION_DALARAN.ModObjectLimit('n0A4',UNLIMITED)               //Dragonspawn
      call FACTION_DALARAN.ModObjectLimit('u025',12)               //Elementalist
      call FACTION_DALARAN.ModObjectLimit('n09T',6)               //Judicator
      call FACTION_DALARAN.ModObjectLimit('h09A',UNLIMITED)               //Nexus
      call FACTION_DALARAN.ModObjectLimit('h09B',UNLIMITED)               //Roost

      set LEGEND_JAINA.UnitType = 'H04A'

      call UnitRemoveAbilityBJ( 'A0RB', LEGEND_JAINA.Unit)
      set this.Holder.Team = TEAM_SCOURGE
      set FACTION_SCOURGE.Team = TEAM_SCOURGE
      set this.Holder.Name = "The Nexus"
      set this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNJaina_Archmage.blp"
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Nexus", "The new Lich King calls for Jaina, tempts her with power. The Nexus needs a master, and Jaina is perfect for it.", "ReplaceableTextures\\CommandButtons\\BTNBlueDragonNexus.blp")
      call this.AddQuestItem(QuestItemChannelRect.create(gg_rct_JainaChannel, "The Nexus", LEGEND_JAINA, 15, 270))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_JAINA, true))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NEXUS, false))
      return this
    endmethod
  endstruct

endlibrary