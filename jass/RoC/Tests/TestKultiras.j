library TestKultiras requires Test, KultirasSetup

  struct TestKultiras extends Test
    method Run takes nothing returns nothing
      set Person.ById(0).Faction = FACTION_KULTIRAS
      call CreateUnits(Player(0), 'h01E', 10683, -28680, 270, 5)
    endmethod

    private static method onInit takes nothing returns nothing 
      call thistype.create("kul'tiras")
    endmethod
  endstruct

endlibrary